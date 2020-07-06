using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Commander;

namespace Kobutan.MDI
{
    /// <summary>
    /// MDI インスタンス
    /// </summary>
    public partial class MdiInstance : UserControl
    {
        #region メンバ変数
        /// <summary>
        /// コマンダインスタンス
        /// </summary>
        private CommanderInstance m_CommanderInstance;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// MDI インスタンス
        /// </summary>
        /// <param name="commanderInstance">コマンダインスタンス</param>
        public MdiInstance(CommanderInstance commanderInstance)
        {
            // コンポーネントの初期化
            InitializeComponent();

            // パラメータの受け渡し
            m_CommanderInstance = commanderInstance;
            UpdateButtonEnable();
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 接続
                m_CommanderInstance.Connect();
                UpdateButtonEnable();
            }
            catch (Exception ex)
            {
                // エラーメッセージ
                MessageBox.Show("接続に失敗しました。\r\n理由: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_DisconnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 切断
                m_CommanderInstance.Disconnect();
                UpdateButtonEnable();
            }
            catch (Exception ex)
            {
                // エラーメッセージ
                MessageBox.Show("切断に失敗しました。\r\n理由: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// ボタンの有効性の更新
        /// </summary>
        private void UpdateButtonEnable()
        {
            m_ConnectButton.Enabled = !m_CommanderInstance.IsConnect;
            m_DisconnectButton.Enabled = m_CommanderInstance.IsConnect;
        }

        #endregion

        #region 授業用
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "新しいファイル.txt";
            sfd.InitialDirectory = @".\ReceivedData\";
            sfd.Filter = "すべてのファイル(*.*)|*.*";
            sfd.FilterIndex = 1;
            //sfd.Title = "保存先のファイルを選択してください";

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using(StreamWriter sw = new StreamWriter(sfd.FileName, false))
                {
                    for (int i = 0; i < listBox1.Items.Count; ++i)
                    {
                        sw.WriteLine(listBox1.Items[i].ToString());
                    }
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        public void AddMessage(string message)
        {
            this.Invoke(new Action(() =>
            {
                listBox1.Items.Add(message);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }));
        }

        public void Disconnect()
        {
            if (m_CommanderInstance.IsConnect)
            {
                // 切断
                m_CommanderInstance.Disconnect();
            }
        }

        #endregion
    }
}
