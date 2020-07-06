using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace PikaLib.Net
{
    /// <summary>
    /// TCPサーバー。
    /// </summary>
    public class TcpServer : IDisposable
    {
        #region メンバ変数
        /// <summary>接続中のクライアントリスト。</summary>
        protected List<TcpClient> m_AcceptedClients = new List<TcpClient>();
        /// <summary>すでに破棄済みかどうかを表すフラグ。</summary>
        private bool m_Disposed = false;
        /// <summary>スレッド間の同期用。</summary>
        private readonly object m_SyncSocket = new object();

        #endregion

        #region プロパティ
        /// <summary>
        /// 基になるSocketを取得します。
        /// </summary>
        protected Socket Server { get; private set; }

        /// <summary>
        /// Listening状態かどうかを取得または設定します。
        /// </summary>
        public bool IsListening { get; protected set; }

        /// <summary>
        /// ローカルエンドポイントを取得します。
        /// </summary>
        public IPEndPoint LocalEndPoint { get; private set; }

        /// <summary>
        /// 同時接続を許可するクライアント数を取得または設定します。
        /// </summary>
        public int MaxClients { get; set; }

        /// <summary>
        /// 接続中のクライアントを取得します。
        /// </summary>
        public virtual TcpClient[] AcceptedClients { get { return m_AcceptedClients.ToArray(); } }

        #endregion

        #region イベント
        /// <summary>
        /// クライアントを受け入れた際に発生します。
        /// </summary>
        public event ServerEventHandler ClientAccepted;
        /// <summary>
        /// PikaLib.Net.TcpServer.ClientAccepted イベントを発生させます。
        /// </summary>
        /// <param name="e">イベントデータを格納している PikaLib.Net.ServerEventArgs。</param>
        protected virtual void OnClientAccepted(ServerEventArgs e)
        {
            if (ClientAccepted != null)
            {
                ClientAccepted(this, e);
            }
        }

        /// <summary>
        /// クライアントからデータを受信した際に発生します。
        /// </summary>
        public event DataReceivedEventHandler DataReceived;
        /// <summary>
        /// PikaLib.Net.TcpServer.DataReceived イベントを発生させます。
        /// </summary>
        /// <param name="e">イベントデータを格納している PikaLib.Net.DataReceivedEventArgs。</param>
        protected virtual void OnDataReceived(DataReceivedEventArgs e)
        {
            if (this.DataReceived != null)
            {
                this.DataReceived(this, e);
            }
        }

        /// <summary>
        /// クライアントから切断された際に発生します。
        /// </summary>
        public event ServerEventHandler ClientDisconnected;
        /// <summary>
        /// PikaLib.Net.TcpServer.ClientDisconnected イベントを発生させます。
        /// </summary>
        /// <param name="e">イベントデータを格納している PikaLib.Net.ServerEventArgs。</param>
        protected virtual void OnClientDisconnected(ServerEventArgs e)
        {
            if (this.ClientDisconnected != null)
            {
                this.ClientDisconnected(this, e);
            }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// PikaLib.Net.TcpServer クラスの新しいインスタンスを初期化します。
        /// </summary>
        public TcpServer()
            : this(100)
        {
        }

        /// <summary>
        /// 同時接続を許可するクライアント数を使用して、
        /// PikaLib.Net.TcpServer クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="maxClients">同時接続を許可するクライアント数。</param>
        public TcpServer(int maxClients)
        {
            MaxClients = maxClients;
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// Listenを開始します。
        /// </summary>
        /// <param name="portNum">ポート番号。</param>
        public void Listen(int portNum)
        {
            Listen(portNum, 100);
        }

        /// <summary>
        /// Listenを開始します。
        /// </summary>
        /// <param name="portNum">ポート番号。</param>
        /// <param name="backlog">保留中の接続のキューの最大長。</param>
        public void Listen(int portNum, int backlog)
        {
            // 例外処理
            if (Server == null)
                throw new ApplicationException("破棄されています。");
            if (IsListening == true)
                throw new ApplicationException("すでにListen中です。");

            // ローカルエンドポイントの作成
            LocalEndPoint = new IPEndPoint(IPAddress.Any, portNum);
            Server.Bind(LocalEndPoint);

            //Listenを開始する
            Server.Listen(backlog);
            IsListening = true;

            //接続要求施行を開始する
            Server.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        /// <summary>
        /// 接続を閉じ、リソースを解放します。
        /// </summary>
        public void Close()
        {
            // 例外処理
            if (m_Disposed == true)
                throw new ApplicationException("破棄されています。");
            // 閉じる
            this.StopListen();
            this.CloseAllClients();
        }

        /// <summary>
        /// 指定したクライアントとの通信を閉じます。
        /// </summary>
        /// <param name="client">通信を閉じたいクライアント。</param>
        public void CloseClient(TcpClient client)
        {
            // 例外処理
            if (m_Disposed == true)
                throw new ApplicationException("破棄されています。");
            // 閉じる
            m_AcceptedClients.Remove(client);
            client.Disconnected -= new EventHandler(client_Disconnected);
            client.DataReceived -= new DataReceivedEventHandler(client_DataReceived);
            client.Close();
        }

        /// <summary>
        /// 接続中のすべてのクライアントとの通信を閉じます。
        /// </summary>
        public void CloseAllClients()
        {
            // 例外処理
            if (m_Disposed == true)
                throw new ApplicationException("破棄されています。");
            // すべてのクライアントを閉じる
            lock (((System.Collections.ICollection)m_AcceptedClients).SyncRoot)
            {
                while (m_AcceptedClients.Count > 0)
                {
                    CloseClient(m_AcceptedClients[0]);
                }
            }
        }

        /// <summary>
        /// 全てのクライアントにデータを送信します。
        /// </summary>
        /// <param name="data">送信するデータ。</param>
        public void SendToAllClients(byte[] data)
        {
            // 全てのクライアントにデータを送信する
            SendToAllClients(data, 0, data.Length);
        }

        /// <summary>
        /// 全てのクライアントにデータを送信します。
        /// </summary>
        /// <param name="data">送信するデータ。</param>
        /// <param name="offset">オフセット。</param>
        /// <param name="size">サイズ。</param>
        public virtual void SendToAllClients(byte[] data, int offset, int size)
        {
            // 例外処理
            if (m_Disposed == true)
                throw new ApplicationException("破棄されています。");
            // 全てのクライアントにデータを送信する
            lock (((System.Collections.ICollection)m_AcceptedClients).SyncRoot)
            {
                foreach (TcpClient client in m_AcceptedClients)
                {
                    client.Send(data, offset, size);
                }
            }
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// サーバーで使用するクライアントクラスを作成します。
        /// </summary>
        /// <param name="soc">基になるSocket。</param>
        /// <returns>クライアントクラス。</returns>
        protected virtual TcpClient CreateClient(Socket soc)
        {
            return new TcpClient(soc);
        }

        /// <summary>
        /// 監視を中止します (復帰不可)。
        /// </summary>
        protected void StopListen()
        {
            // 例外処理
            if (m_Disposed == true)
                throw new ApplicationException("破棄されています。");

            // 監視を中止
            lock (m_SyncSocket)
            {
                if (Server == null)
                    return;
                Server.Close();
                Server = null;
                IsListening = false;
            }
        }

        /// <summary>
        /// BeginAcceptのコールバック。
        /// </summary>
        /// <param name="ar">非同期操作のステータスを表します。</param>
        private void AcceptCallback(IAsyncResult ar)
        {
            // 接続要求を受け入れる
            Socket soc = null;
            try
            {
                lock (m_SyncSocket)
                {
                    soc = Server.EndAccept(ar);
                }
            }
            catch
            {
                // サーバを閉じる
                if (Server != null)
                    Server.Close();
                return;
            }

            // TCPClientの作成
            TcpClient client = CreateClient(soc);
            // 最大数を超えていないか
            if (m_AcceptedClients.Count >= MaxClients)
            {
                client.Close();
            }
            else
            {
                // コレクションに追加
                m_AcceptedClients.Add(client);
                // イベントハンドラの追加
                client.Disconnected += new EventHandler(client_Disconnected);
                client.DataReceived += new DataReceivedEventHandler(client_DataReceived);
                // イベントを発生
                OnClientAccepted(new ServerEventArgs(client));
                // データ受信開始
                if (!client.IsClosed)
                {
                    client.StartReceive();
                }
            }

            // 接続要求施行を再開する
            Server.BeginAccept(new AsyncCallback(this.AcceptCallback), null);
        }

        #endregion

        #region クライアントのイベントハンドラ
        /// <summary>
        /// クライアントが切断した時のイベントハンドラ。
        /// </summary>
        /// <param name="sender">イベントのソース。</param>
        /// <param name="e">イベントデータを格納している System.EventArgs。</param>
        private void client_Disconnected(object sender, EventArgs e)
        {
            // リストから削除する
            m_AcceptedClients.Remove((TcpClient)sender);
            // イベントを発生させる
            OnClientDisconnected(new ServerEventArgs((TcpClient)sender));
        }

        /// <summary>
        /// クライアントからデータを受信した時のイベントハンドラ。
        /// </summary>
        /// <param name="sender">イベントのソース。</param>
        /// <param name="e">イベントデータを格納している PikaLib.Net.DataReceivedEventArgs。</param>
        private void client_DataReceived(object sender, DataReceivedEventArgs e)
        {
            // イベントを発生させる
            OnDataReceived(new DataReceivedEventArgs((TcpClient)sender, e.ReceivedData, e.ReceivedDataLength));
        }

        #endregion

        #region IDisposableメンバの実装
        /// <summary>
        /// 使用中のリソースを解放します。
        /// </summary>
        public void Dispose()
        {
            //マネージリソースおよびアンマネージリソースの解放
            this.Dispose(true);
            //ガベコレから、このオブジェクトのデストラクタを対象外とする
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 使用中のリソースを解放します。
        /// </summary>
        /// <param name="disposing">マネージリソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected virtual void Dispose(bool disposing)
        {
            // 既に破棄されていれば何もしない
            if (m_Disposed)
                return;

            // リソースの解放
            if (disposing)
            {
                // マネージリソースの解放
                Close();
            }
            // アンマネージリソースの解放

            // 破棄済みフラグを設定
            m_Disposed = true;
        }

        #endregion
    }
}
