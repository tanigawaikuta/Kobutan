using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDIApp
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        #region メンバ変数
        // MDI子フォーム
        private PikaLib.Controls.MdiChildForm m_MdiForm1;
        private PikaLib.Controls.MdiChildForm m_MdiForm2;
        private PikaLib.Controls.MdiChildForm m_MdiForm3;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// メインフォーム
        /// </summary>
        public MainForm()
        {
            // コンポーネントの初期化
            InitializeComponent();

            // MDIウィンドウの初期化
            InitializeMdiWindow();
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// MDIウィンドウの初期化
        /// </summary>
        public void InitializeMdiWindow()
        {
            // MDIForm1
            UserControl mdi1 = new MdiUserControl1();                   // ユーザーコントロール
            m_MdiForm1 = new PikaLib.Controls.MdiChildForm(mdi1, this); // MDI子フォーム
            // MDIForm2
            UserControl mdi2 = new MdiUserControl2();                   // ユーザーコントロール
            m_MdiForm2 = new PikaLib.Controls.MdiChildForm(mdi2, this); // MDI子フォーム
            m_MdiForm2.Size = new System.Drawing.Size(170, 190);        // サイズ固定
            m_MdiForm2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            m_MdiForm2.MaximizeBox = false;
            // MDIForm3
            UserControl mdi3 = new MdiUserControl3();                   // ユーザーコントロール
            m_MdiForm3 = new PikaLib.Controls.MdiChildForm(mdi3, this); // MDI子フォーム
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// 「ファイル」メニューの「終了」が押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_File_Exit_Click(object sender, EventArgs e)
        {
            // メインフォームを閉じる
            Close();
        }

        /// <summary>
        /// 「表示」メニューの「MDIWindow1」が押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_View_MDI1_Click(object sender, EventArgs e)
        {
            // 表示
            m_MdiForm1.Show();
            m_MdiForm1.Activate();
        }

        /// <summary>
        /// 「表示」メニューの「MDIWindow2」が押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_View_MDI2_Click(object sender, EventArgs e)
        {
            // 表示
            m_MdiForm2.Show();
            m_MdiForm2.Activate();
        }

        /// <summary>
        /// 「表示」メニューの「MDIWindow3」が押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_View_MDI3_Click(object sender, EventArgs e)
        {
            // 表示
            m_MdiForm3.Show();
            m_MdiForm3.Activate();
        }

        #endregion
    }
}
