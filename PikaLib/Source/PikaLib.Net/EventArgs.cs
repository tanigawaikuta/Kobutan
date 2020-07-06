using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PikaLib.Net
{
    #region サーバイベント 関連
    /// <summary>
    /// TcpServerクラスで発生するイベントを処理するメソッドのデリゲート。
    /// </summary>
    /// <param name="sender">イベントのソース。</param>
    /// <param name="e">イベントデータを格納している PikaLib.Net.ServerEventArgs。</param>
    public delegate void ServerEventHandler(object sender, ServerEventArgs e);

    /// <summary>
    /// ServerEventHandlerのイベントデータを格納するクラス。
    /// </summary>
    public class ServerEventArgs : EventArgs
    {
        #region プロパティ
        /// <summary>クライアントを取得します。</summary>
        public TcpClient Client { get; private set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// クライアントを使用して、
        /// PikaLib.Net.ServerEventArgs クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="client">クライアント</param>
        public ServerEventArgs(TcpClient client)
        {
            Client = client;
        }

        #endregion
    }

    #endregion

    #region データ受信イベント 関連
    /// <summary>
    /// データ受信時に発生するイベントを処理するメソッドのデリゲート。
    /// </summary>
    /// <param name="sender">イベントのソース。</param>
    /// <param name="e">イベントデータを格納している PikaLib.Net.DataReceivedEventArgs。</param>
    public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);

    /// <summary>
    /// DataReceivedEventHandlerのイベントデータを格納するクラス。
    /// </summary>
    public class DataReceivedEventArgs : EventArgs
    {
        #region プロパティ
        /// <summary>クライアントを取得します。</summary>
        public TcpClient Client { get; private set; }
        /// <summary>受信データを取得します。</summary>
        public byte[] ReceivedData { get; private set; }
        /// <summary>受信データの長さを取得します。</summary>
        public int ReceivedDataLength { get; private set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// クライアント、受信データ、受信データの長さを使用して、
        /// PikaLib.Net.DataReceivedEventArgs クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="client">クライアント。</param>
        /// <param name="receivedData">受信データ。</param>
        /// <param name="receivedDataLength">受信データの長さ。</param>
        public DataReceivedEventArgs(TcpClient client, byte[] receivedData, int receivedDataLength)
        {
            Client = client;
            ReceivedData = receivedData;
            ReceivedDataLength = receivedDataLength;
        }

        #endregion
    }

    #endregion
}
