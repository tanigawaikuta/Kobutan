using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;

namespace Communication
{
    /// <summary>
    /// 通信マネージャ
    /// </summary>
    public class CommunicationManager
    {
        #region メンバ変数
        /// <summary>シリアルポートマネージャ</summary>
        private SerialPortManager m_SerialPortManager;
        /// <summary>送信バッファ</summary>
        private byte[] m_SendBuf = new byte[2048];
        /// <summary>受信バッファ</summary>
        private byte[] m_ReceiveBuf = new byte[2048];
        //private MemoryStream m_SendStream;

        #endregion

        #region プロパティ
        /// <summary>
        /// 送信バッファ
        /// </summary>
        public byte[] SendBuf { get { return m_SendBuf; } }

        /// <summary>
        /// 受信バッファ
        /// </summary>
        public byte[] ReceiveBuf { get { return m_ReceiveBuf; } }

        /// <summary>
        /// 受信バッファのバイト数
        /// </summary>
        public int BytesToRead { get { return m_SerialPortManager.BytesToRead; } }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 通信マネージャ
        /// </summary>
        /// <param name="protocolSpecification">プロトコル仕様</param>
        /// <param name="serialPortManager">シリアルポートマネージャ</param>
        public CommunicationManager(ProtocolSpecification protocolSpecification, SerialPortManager serialPortManager)
        {
            // シリアルポートマネージャ
            m_SerialPortManager = serialPortManager;
            // メモリストリーム
            //m_SendStream = new MemoryStream(m_SendBuf);
            // プロトコル仕様の読み込み
            LoadProtocolSpecification(protocolSpecification);
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// プロトコル仕様の読み込み
        /// </summary>
        /// <param name="protocolSpecification">プロトコル仕様</param>
        public void LoadProtocolSpecification(ProtocolSpecification protocolSpecification)
        {
        }

        /// <summary>
        /// SendBuf(生データ)の送信
        /// </summary>
        /// <param name="offset">オフセット</param>
        /// <param name="count">送信サイズ</param>
        public void Send(int offset, int count)
        {
            // 送信
            m_SerialPortManager.Write(m_SendBuf, offset, count);
        }

        /// <summary>
        /// 生の受信データをReceiveBufに取り込む
        /// </summary>
        /// <param name="offset">オフセット</param>
        /// <param name="count">送信サイズ</param>
        public void Receive(int offset, int count)
        {
            // 受信
            m_SerialPortManager.Read(m_ReceiveBuf, offset, count);
        }

        /*
        public void SendCommand()
        {
        }

        public void UpdateFeedback()
        {
        }

        public void AddCommand(string commandName, params dynamic[] args)
        {
        }

        public void GetFeedback(string feedbackName)
        {
        }
        */
        #endregion

        #region 非公開メソッド
        #endregion
    }
}
