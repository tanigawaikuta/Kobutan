using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace Communication
{
    /// <summary>
    /// シリアルポート管理者
    /// </summary>
    public class SerialPortManager
    {
        #region メンバ変数
        /// <summary>
        /// シリアルポート
        /// </summary>
        private SerialPort m_SerialPort;

        /// <summary>
        /// 送信スレッド
        /// </summary>
        private SendThread m_SendThread;

        /// <summary>
        /// 送信タイマ
        /// </summary>
        //private Timer m_SendTimer;

        #endregion

        #region プロパティ
        /// <summary>
        /// 接続中かどうか
        /// </summary>
        public bool IsConnect { get { return m_SerialPort != null; } }

        /// <summary>
        /// 送信スレッドが有効かどうかの真偽値
        /// </summary>
        public bool SendThreadEnable { get; protected set; }

        /// <summary>
        /// 送信スレッドの送信周期(ミリ秒単位)
        /// </summary>
        public uint SendCycle
        {
            get { return _SendCycle; }
            set
            {
                if (SendThreadEnable)
                {
                    m_SendThread.SendCycle = value;
                }
                _SendCycle = value;
            }
        }
        private uint _SendCycle;

        /// <summary>
        /// ポート名
        /// </summary>
        public string PortName
        {
            get { return _PortName; }
            set
            {
                if (IsConnect)
                {
                    m_SerialPort.PortName = value;
                }
                _PortName = value;
            }
        }
        private string _PortName;

        /// <summary>
        /// ボーレート
        /// </summary>
        public int BaudRate
        {
            get { return _BaudRate; }
            set
            {
                if (IsConnect)
                {
                    m_SerialPort.BaudRate = value;
                }
                _BaudRate = value;
            }
        }
        private int _BaudRate;

        /// <summary>
        /// パリティ
        /// </summary>
        public Parity Parity
        {
            get { return _Parity; }
            set
            {
                if (IsConnect)
                {
                    m_SerialPort.Parity = value;
                }
                _Parity = value;
            }
        }
        private Parity _Parity;

        /// <summary>
        /// 通信単位
        /// </summary>
        public int DataBits
        {
            get { return _DataBits; }
            set
            {
                if (IsConnect)
                {
                    m_SerialPort.DataBits = value;
                }
                _DataBits = value;
            }
        }
        private int _DataBits;

        /// <summary>
        /// ストップビット
        /// </summary>
        public StopBits StopBits
        {
            get { return _StopBits; }
            set
            {
                if (IsConnect)
                {
                    m_SerialPort.StopBits = value;
                }
                _StopBits = value;
            }
        }
        private StopBits _StopBits;

        /// <summary>
        /// 受信バッファのバイト数
        /// </summary>
        public int BytesToRead
        {
            get
            {
                if (IsConnect)
                {
                    return m_SerialPort.BytesToRead;
                }
                return 0;
            }
        }

        #endregion

        #region イベント
        /// <summary>
        /// データ受信時に発生するイベント
        /// </summary>
        public event SerialDataReceivedEventHandler DataReceived;
        /// <summary>
        /// データ受信時のアクション
        /// </summary>
        /// <param name="e">イベント引数</param>
        protected virtual void OnDataReceived(SerialDataReceivedEventArgs e)
        {
            if (DataReceived != null)
            {
                DataReceived(this, e);
            }
        }

        /// <summary>
        /// 送信スレッドの送信タイミングで発生するイベント
        /// </summary>
        public event EventHandler DataSending;
        /// <summary>
        /// 送信スレッドの送信タイミングのときのアクション
        /// </summary>
        /// <param name="e">イベント引数</param>
        protected virtual void OnDataSending(EventArgs e)
        {
            if (DataSending != null)
            {
                DataSending(this, e);
            }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// シリアルポート管理者
        /// </summary>
        public SerialPortManager()
            : this("COM1", 9600, Parity.None, 8, StopBits.One)
        {
        }
        
        /// <summary>
        /// シリアルポート管理者
        /// </summary>
        /// <param name="portName">ポート名</param>
        /// <param name="baudRate">ボーレート</param>
        public SerialPortManager(string portName, int baudRate)
            : this(portName, baudRate, Parity.None, 8, StopBits.One)
        {
        }

        /// <summary>
        /// シリアルポート管理者
        /// </summary>
        /// <param name="portName">ポート名</param>
        /// <param name="baudRate">ボーレート</param>
        /// <param name="parity">パリティ</param>
        /// <param name="dataBits">通信単位</param>
        /// <param name="stopBits">ストップビット</param>
        public SerialPortManager(string portName, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            PortName = portName;
            BaudRate = baudRate;
            Parity = parity;
            DataBits = dataBits;
            StopBits = stopBits;
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// 接続
        /// </summary>
        public void Connect()
        {
            // 未接続なら
            if (!IsConnect)
            {
                try
                {
                    // シリアルポートをインスタンス化
                    m_SerialPort = new SerialPort(PortName, BaudRate, Parity, DataBits, StopBits);
                    // 受信イベントの追加
                    m_SerialPort.DataReceived += new SerialDataReceivedEventHandler(m_SerialPort_DataReceived);
                    // シリアルポートのオープン
                    m_SerialPort.Open();
                }
                catch (Exception)
                {
                    // 失敗したら、Connect呼び出し前の状態まで戻す
                    m_SerialPort.DataReceived -= new SerialDataReceivedEventHandler(m_SerialPort_DataReceived);
                    try { if (m_SerialPort.IsOpen) m_SerialPort.Close(); }
                    catch (Exception) { }
                    m_SerialPort = null;
                    // 再スロー
                    throw;
                }
            }
        }

        /// <summary>
        /// 切断
        /// </summary>
        public void Disconnect()
        {
            // 接続中なら
            if (IsConnect)
            {
                try
                {
                    // 受信イベントの削除
                    m_SerialPort.DataReceived -= new SerialDataReceivedEventHandler(m_SerialPort_DataReceived);
                    // スレッドを止める
                    StopSendThread();
                    // シリアルポートを閉じる
                    m_SerialPort.Close();
                    // 変数をnullで埋める
                    m_SerialPort = null;
                }
                catch (Exception)
                {
                    // 出来る範囲で終了処理
                    try { if (m_SerialPort.IsOpen) m_SerialPort.Close(); }
                    catch (Exception) { }
                    m_SerialPort = null;
                    // 再スロー
                    throw;
                }
            }
        }

        /// <summary>
        /// 読み込み
        /// </summary>
        /// <param name="buf">読み込むバッファ</param>
        /// /// <param name="offset">読み込むバッファのオフセット</param>
        /// <param name="length">読み込むバッファの長さ</param>
        /// <returns>読み込まれたデータのサイズ</returns>
        public int Read(byte[] buf, int offset, int length)
        {
            // シリアルポートより受信
            return m_SerialPort.Read(buf, offset, length);
        }

        /// <summary>
        /// 書き込み
        /// </summary>
        /// <param name="buf">書き込むバッファ</param>
        /// <param name="offset">書き込むバッファのオフセット</param>
        /// <param name="length">書き込むバッファの長さ</param>
        public void Write(byte[] buf, int offset, int length)
        {
            // シリアルポートより送信
            m_SerialPort.Write(buf, offset, length);
        }

        /// <summary>
        /// 送信スレッドのスタート
        /// </summary>
        public void StartSendThread()
        {
            if (!SendThreadEnable)
            {
                // スレッドの生成
                m_SendThread = new SendThread(() =>
                {
                    if (IsConnect)
                    {
                        OnDataSending(new EventArgs());
                    }
                }, SendCycle);
                m_SendThread.Start();
                // スレッド有効フラグを立てる
                SendThreadEnable = true;
            }
        }

        /// <summary>
        /// 送信スレッドのストップ
        /// </summary>
        public void StopSendThread()
        {
            if (SendThreadEnable)
            {
                SendThreadEnable = false;   // スレッド有効フラグを降ろす
                m_SendThread.Stop();
                m_SendThread = null;
            }
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// シリアルポートからデータ受信時のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // 委譲
            OnDataReceived(e);
        }

        #endregion
    }
}
