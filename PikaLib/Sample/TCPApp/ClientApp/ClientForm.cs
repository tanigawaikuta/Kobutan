using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using PikaLib.Net;

namespace ClientApp
{
    /// <summary>
    /// クライアントアプリ側のフォーム
    /// </summary>
    public partial class ClientForm : Form
    {
        #region メンバ変数
        /// <summary>クライアント</summary>
        private TcpClient m_Client;
        /// <summary>TCP/IP通信 送信バッファ</summary>
        private byte[] m_TcpSendBuf = new byte[1024];

        #endregion

        #region コンストラクタ
        /// <summary>
        /// クライアントアプリ側のフォーム
        /// </summary>
        public ClientForm()
        {
            // コンポーネントの初期化
            InitializeComponent();
        }

        #endregion

        #region オーバーライド
        /// <summary>
        /// フォーム読み込み時の処理
        /// </summary>
        /// <param name="e">イベント引数</param>
        protected override void OnLoad(EventArgs e)
        {
            // 初期化
            Initialize();
            // 基底クラスのメソッドを呼び出す
            base.OnLoad(e);
        }

        /// <summary>
        /// フォームが閉じられる際の処理
        /// </summary>
        /// <param name="e">イベント引数</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                // 通信を閉じる
                if (m_Client != null)
                {
                    m_Client.Close();
                }
            }
            catch (Exception)
            {
                // 例外を握りつぶす！
                // 本来はならエラーメッセージとか出した方が良いかも・・・
            }
            // 基底クラスのメソッドを呼び出す
            base.OnClosing(e);
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
            // 切断 
            // 本当はイベントハンドラを呼び出すんじゃなくて、
            // 普通の非公開メソッドを呼び出す形にした方が良いが、めんどくさいです・・・
            if (m_Client != null)
            {
                m_DisconnectButton_Click(this, new EventArgs());
            }
        }

        /// <summary>
        /// TCP/IP通信関連のコントロールの状態変化
        /// </summary>
        /// <param name="connecting">接続中フラグ</param>
        private void ChangeControlStates_Tcp(bool connecting)
        {
            if (connecting)
            {
                m_ConnectButton.Enabled = false;
                m_HostNameTextBox.Enabled = false;
                m_PortTextBox.Enabled = false;
                m_DisconnectButton.Enabled = true;
                m_TcpSendButton.Enabled = true;
            }
            else
            {
                m_ConnectButton.Enabled = true;
                m_HostNameTextBox.Enabled = true;
                m_PortTextBox.Enabled = true;
                m_DisconnectButton.Enabled = false;
                m_TcpSendButton.Enabled = false;
            }
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// メニューバーで閉じるが押された際の処理
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_MainMenu_File_Exit_Click(object sender, EventArgs e)
        {
            // フォームを閉じる
            Close();
        }

        /// <summary>
        /// 接続ボタンが押された際の処理
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_ConnectButton_Click(object sender, EventArgs e)
        {
            // エラーメッセージ
            if (m_Client != null)
            {
                MessageBox.Show(this,
                    "すでに接続中です。",
                    "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // インスタンス化
                m_Client = new TcpClient();
                m_Client.DataReceived += new DataReceivedEventHandler(m_Client_DataReceived);
                m_Client.Connected += new EventHandler(m_Client_Connected);
                m_Client.Disconnected += new EventHandler(m_Client_Disconnected);
                // 接続
                m_Client.Connect(m_HostNameTextBox.Text, int.Parse(m_PortTextBox.Text));
            }
            catch (Exception ex)
            {
                // エラーメッセージ
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace, ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (m_Client != null)
                {
                    try { m_Client.Close(); }
                    catch (Exception) { }
                    m_Client = null;
                }
            }
        }

        /// <summary>
        /// 切断ボタンが押された際の処理
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_DisconnectButton_Click(object sender, EventArgs e)
        {
            // エラーメッセージ
            if (m_Client == null)
            {
                MessageBox.Show(this,
                    "接続していません。",
                    "エラー",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 破棄
                m_Client.Close();
                m_Client = null;
            }
            catch (Exception ex)
            {
                // エラーメッセージ
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace, ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// サーバに送信ボタンを押した際の処理
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_TcpSendButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 送信バッファの設定
                m_TcpSendBuf[0] = (m_TcpSendData1TextBox.Text != "") ?      // 送信データ1バイト目
                    byte.Parse(m_TcpSendData1TextBox.Text, NumberStyles.HexNumber) : (byte)0;
                m_TcpSendBuf[1] = (m_TcpSendData2TextBox.Text != "") ?      // 送信データ2バイト目
                    byte.Parse(m_TcpSendData2TextBox.Text, NumberStyles.HexNumber) : (byte)0;
                m_TcpSendBuf[2] = (m_TcpSendData3TextBox.Text != "") ?      // 送信データ3バイト目
                    byte.Parse(m_TcpSendData3TextBox.Text, NumberStyles.HexNumber) : (byte)0;
                m_TcpSendBuf[3] = (m_TcpSendData4TextBox.Text != "") ?      // 送信データ4バイト目
                    byte.Parse(m_TcpSendData4TextBox.Text, NumberStyles.HexNumber) : (byte)0;
                m_TcpSendBuf[4] = (m_TcpSendData5TextBox.Text != "") ?      // 送信データ5バイト目
                    byte.Parse(m_TcpSendData5TextBox.Text, NumberStyles.HexNumber) : (byte)0;
                m_TcpSendBuf[5] = (m_TcpSendData6TextBox.Text != "") ?      // 送信データ6バイト目
                    byte.Parse(m_TcpSendData6TextBox.Text, NumberStyles.HexNumber) : (byte)0;
                m_TcpSendBuf[6] = (m_TcpSendData7TextBox.Text != "") ?      // 送信データ7バイト目
                    byte.Parse(m_TcpSendData7TextBox.Text, NumberStyles.HexNumber) : (byte)0;
                m_TcpSendBuf[7] = (m_TcpSendData8TextBox.Text != "") ?      // 送信データ8バイト目
                    byte.Parse(m_TcpSendData8TextBox.Text, NumberStyles.HexNumber) : (byte)0;
                // 送信
                m_Client.Send(m_TcpSendBuf, 0, 8);
            }
            catch (Exception ex)
            {
                // エラーメッセージ
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace, ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// テキストボックスでキーボードの入力をした際の処理
        /// 16進の文字以外は受け付けないようにする
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void SendDataTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 小文字なら、大文字に変換
            if (char.IsLower(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);

            // 16進の文字と一部制御文字に対応
            if (!((e.KeyChar >= '0' && e.KeyChar <= '9') ||
                (e.KeyChar >= 'A' && e.KeyChar <= 'F') ||
                (e.KeyChar == '\b') || (e.KeyChar == '\t')))
            {
                // キャンセル
                e.Handled = true;
            }
        }

        /// <summary>
        /// データ受信時の処理
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_Client_DataReceived(object sender, DataReceivedEventArgs e)
        {
            // 受け取ったデータをリストに追加
            string str = "";
            for (int i = 0; i < e.ReceivedDataLength; ++i)
            {
                str += e.ReceivedData[i].ToString("X2") + ", ";
            }
            this.Invoke(new Action(() =>
            {
                m_TcpReceiveListBox.Items.Add(str);
            }));
        }

        /// <summary>
        /// 接続時の処理
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_Client_Connected(object sender, EventArgs e)
        {
            // コントロール有効無効の設定
            ChangeControlStates_Tcp(true);
        }

        /// <summary>
        /// 切断時の処理
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_Client_Disconnected(object sender, EventArgs e)
        {
            // コントロール有効無効の設定
            ChangeControlStates_Tcp(false);
            m_Client = null;
        }

        #endregion
    }
}
