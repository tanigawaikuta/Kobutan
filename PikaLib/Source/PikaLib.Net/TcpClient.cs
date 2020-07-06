using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace PikaLib.Net
{
    /// <summary>
    /// TCPクライアント。
    /// </summary>
    public class TcpClient : IDisposable
    {
        #region メンバ変数
        /// <summary>受信開始フラグ。</summary>
        private bool m_StartedReceiving = false;
        /// <summary>すでに破棄済みかどうかを表すフラグ。</summary>
        private bool m_Disposed = false;
        /// <summary>スレッド間の同期用。</summary>
        private readonly object m_SyncSocket = new object();

        #endregion

        #region プロパティ
        /// <summary>
        /// 基になるSocketを取得します。
        /// </summary>
        protected Socket Client { get; private set; }

        /// <summary>
        /// ローカルエンドポイントを取得します。
        /// </summary>
        public IPEndPoint LocalEndPoint { get; private set; }

        /// <summary>
        /// リモートエンドポイントを取得します。
        /// </summary>
        public IPEndPoint RemoteEndPoint { get; private set; }

        /// <summary>
        /// 受信バッファサイズを取得または設定します。
        /// </summary>
        public int ReceiveBufferSize { get; set; }

        /// <summary>
        /// 閉じているかどうかの真偽値を取得します。
        /// </summary>
        public bool IsClosed { get { return (Client == null); } }

        #endregion

        #region イベント
        /// <summary>
        /// サーバーに接続した際に発生します。
        /// </summary>
        public event EventHandler Connected;
        /// <summary>
        /// PikaLib.Net.TcpClient.Connected イベントを発生させます。
        /// </summary>
        /// <param name="e">イベントデータを格納している System.EventArgs。</param>
        protected virtual void OnConnected(EventArgs e)
        {
            if (this.Connected != null)
            {
                this.Connected(this, e);
            }
        }

        /// <summary>
        /// データを受信した際に発生します。
        /// </summary>
        public event DataReceivedEventHandler DataReceived;
        /// <summary>
        /// PikaLib.Net.TcpClient.DataReceived イベントを発生させます。
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
        /// サーバーから切断された、あるいは切断した際に発生します。
        /// </summary>
        public event EventHandler Disconnected;
        /// <summary>
        /// PikaLib.Net.TcpClient.Disconnected イベントを発生させます。
        /// </summary>
        /// <param name="e">イベントデータを格納している System.EventArgs。</param>
        protected virtual void OnDisconnected(EventArgs e)
        {
            if (this.Disconnected != null)
            {
                this.Disconnected(this, e);
            }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// PikaLib.Net.TcpClient クラスの新しいインスタンスを初期化します。
        /// </summary>
        public TcpClient()
            : this(1024)
        {
        }

        /// <summary>
        /// 受信バッファサイズを使用して、
        /// PikaLib.Net.TcpClient クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="receiveBufferSize">受信バッファサイズ。</param>
        /// <exception cref="System.ArgumentOutOfRangeException">許容範囲外のパラメータが渡された際に発生します。</exception>
        public TcpClient(int receiveBufferSize)
        {
            // 例外処理
            if (receiveBufferSize < 0)
                throw new ArgumentOutOfRangeException("receiveBufferSize");

            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ReceiveBufferSize = receiveBufferSize;
        }

        /// <summary>
        /// 元となるソケットを使用して、
        /// PikaLib.Net.TcpClient クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="socket">元となるソケット。</param>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        public TcpClient(Socket socket)
            : this(socket, 1024)
        {
        }

        /// <summary>
        /// 元となるソケットと受信バッファサイズを使用して、
        /// PikaLib.Net.TcpClient クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="socket">元となるソケット。</param>
        /// <param name="receiveBufferSize">受信バッファサイズ。</param>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">許容範囲外のパラメータが渡された際に発生します。</exception>
        public TcpClient(Socket socket, int receiveBufferSize)
        {
            // 例外処理
            if (socket == null)
                throw new ArgumentNullException("socket");
            if (!(socket is Socket))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "socket");
            if (receiveBufferSize < 0)
                throw new ArgumentOutOfRangeException("receiveBufferSize");

            Client = socket;
            LocalEndPoint = (IPEndPoint)socket.LocalEndPoint;
            RemoteEndPoint = (IPEndPoint)socket.RemoteEndPoint;
            ReceiveBufferSize = receiveBufferSize;
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// サーバーに接続します。
        /// </summary>
        /// <param name="host">ホスト名。</param>
        /// <param name="port">ポート番号。</param>
        public void Connect(string host, int port)
        {
            // 例外処理
            if (IsClosed)
                throw new ApplicationException("閉じています。");
            if (Client.Connected)
                throw new ApplicationException("すでに接続されています。");

            // 接続する
            IPAddress[] addressList = Dns.GetHostEntry(host).AddressList;
            foreach (IPAddress address in addressList)
            {
                // IPV4
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    IPEndPoint ipEnd = new IPEndPoint(address, port);
                    Client.Connect(ipEnd);
                    break;
                }
            }
            LocalEndPoint = (IPEndPoint)Client.LocalEndPoint;
            RemoteEndPoint = (IPEndPoint)Client.RemoteEndPoint;

            // イベントを発生
            this.OnConnected(new EventArgs());

            // 非同期データ受信を開始する
            this.StartReceive();
        }

        /// <summary>
        /// サーバーとの接続を閉じ、リソースを解放します。
        /// </summary>
        public void Close()
        {
            lock (m_SyncSocket)
            {
                if (this.IsClosed)
                    return;

                // 閉じる
                Client.Shutdown(SocketShutdown.Both);
                Client.Close();
                Client = null;
            }
            // イベントを発生
            this.OnDisconnected(new EventArgs());
        }

        /// <summary>
        /// サーバーにデータを送信します。
        /// </summary>
        /// <param name="data">送信するデータ。</param>
        public void Send(byte[] data)
        {
            // データを送信する
            Send(data, 0, data.Length);
        }

        /// <summary>
        /// サーバーにデータを送信します。
        /// </summary>
        /// <param name="data">送信するデータ。</param>
        /// <param name="offset">オフセット。</param>
        /// <param name="size">サイズ。</param>
        public void Send(byte[] data, int offset, int size)
        {
            // 例外処理
            if (IsClosed)
                throw new ApplicationException("閉じています。");

            lock (m_SyncSocket)
            {
                // データを送信する
                Client.Send(data, offset, size, SocketFlags.None);
            }
        }

        /// <summary>
        /// データの非同期受信を開始します。
        /// </summary>
        public void StartReceive()
        {
            // 例外処理
            if (IsClosed)
                throw new ApplicationException("閉じています。");
            if (m_StartedReceiving)
                throw new ApplicationException("StartReceiveがすでに呼び出されています。");

            // 初期化
            byte[] receiveBuffer = new byte[ReceiveBufferSize];
            m_StartedReceiving = true;

            // 非同期受信を開始
            Client.BeginReceive(receiveBuffer,
                0, receiveBuffer.Length,
                SocketFlags.None, new AsyncCallback(ReceiveDataCallback),
                receiveBuffer);
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// BeginReceiveのコールバック。
        /// </summary>
        /// <param name="ar">非同期操作のステータス。</param>
        private void ReceiveDataCallback(IAsyncResult ar)
        {
            int len = -1;
            // 読み込んだ長さを取得
            try
            {
                lock (m_SyncSocket)
                {
                    len = Client.EndReceive(ar);
                }
            }
            catch
            {
            }
            // 切断されたか調べる
            if (len <= 0)
            {
                this.Close();
                return;
            }

            // 受信したデータを取得する
            byte[] receiveBuffer = (byte[])ar.AsyncState;
            // イベントを発生
            OnDataReceived(new DataReceivedEventArgs(this, receiveBuffer, len));

            lock (m_SyncSocket)
            {
                // 再び受信開始
                Client.BeginReceive(receiveBuffer,
                    0, receiveBuffer.Length,
                    SocketFlags.None, new AsyncCallback(ReceiveDataCallback)
                    , receiveBuffer);
            }
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
