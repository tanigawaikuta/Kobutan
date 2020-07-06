using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ConfigApp.ConfigScreens
{
    /// <summary>
    /// スクリーン1_2
    /// </summary>
    public partial class Screen1_2 : ConfigScreen
    {
        #region コンストラクタ
        /// <summary>
        /// スクリーン1_2
        /// </summary>
        public Screen1_2()
        {
            // コンポーネントの初期化
            InitializeComponent();
            // バインド
            m_NumTextBox.DataBindings.Add("Text", m_TrackBar, "Value");
        }

        #endregion

        #region オーバーライド
        /// <summary>
        /// 適用
        /// </summary>
        public override void Apply()
        {
            // 各種設定
            Config.Screen1.Screen1_2.DateTime = m_DateTimePicker.Value;
            Config.Screen1.Screen1_2.FilePath = m_FilePathTextBox.Text;
            Config.Screen1.Screen1_2.Color = m_ColorTextBox.Text;
            Config.Screen1.Screen1_2.Font = m_FontTextBox.Text;
            Config.Screen1.Screen1_2.TrackBarNumber = m_TrackBar.Value;
            // ラジオボタン
            if (m_RadioButton2.Checked)
                Config.Screen1.Screen1_2.RadioButtonNumber = 2;
            else if (m_RadioButton3.Checked)
                Config.Screen1.Screen1_2.RadioButtonNumber = 3;
            else if (m_RadioButton4.Checked)
                Config.Screen1.Screen1_2.RadioButtonNumber = 4;
            else
                Config.Screen1.Screen1_2.RadioButtonNumber = 1;
            // チェックリストボックス
            if (m_CheckedListBox.GetItemChecked(0))
                Config.Screen1.Screen1_2.CheckListBoxItem0 = true;
            if (m_CheckedListBox.GetItemChecked(1))
                Config.Screen1.Screen1_2.CheckListBoxItem1 = true;
            if (m_CheckedListBox.GetItemChecked(2))
                Config.Screen1.Screen1_2.CheckListBoxItem2 = true;
            if (m_CheckedListBox.GetItemChecked(3))
                Config.Screen1.Screen1_2.CheckListBoxItem3 = true;
        }

        /// <summary>
        /// コンフィグの読み込み
        /// </summary>
        public override void LoadConfig()
        {
            // コンバータ
            ColorConverter cc = new ColorConverter();
            FontConverter fc = new FontConverter();
            // 各種設定
            m_DateTimePicker.Value = Config.Screen1.Screen1_2.DateTime;
            m_FilePathTextBox.Text = Config.Screen1.Screen1_2.FilePath;
            m_ColorTextBox.Text = Config.Screen1.Screen1_2.Color;
            m_ColorTextBox.BackColor = SystemColors.Control;                                // これを入れとかないと字の色が変わらない
            m_ColorTextBox.ForeColor = (Color)(cc.ConvertFromString(m_ColorTextBox.Text));
            m_FontTextBox.Text = Config.Screen1.Screen1_2.Font;
            m_FontTextBox.Font = (Font)(fc.ConvertFromString(m_FontTextBox.Text));
            m_TrackBar.Value = Config.Screen1.Screen1_2.TrackBarNumber;
            // ラジオボタン
            if (Config.Screen1.Screen1_2.RadioButtonNumber == 2)
                m_RadioButton2.Checked = true;
            else if(Config.Screen1.Screen1_2.RadioButtonNumber == 3)
                m_RadioButton3.Checked = true;
            else if (Config.Screen1.Screen1_2.RadioButtonNumber == 4)
                m_RadioButton4.Checked = true;
            else
                m_RadioButton1.Checked = true;
            // チェックリストボックス
            if (Config.Screen1.Screen1_2.CheckListBoxItem0)
                m_CheckedListBox.SetItemChecked(0, true);
            if (Config.Screen1.Screen1_2.CheckListBoxItem1)
                m_CheckedListBox.SetItemChecked(1, true);
            if (Config.Screen1.Screen1_2.CheckListBoxItem2)
                m_CheckedListBox.SetItemChecked(2, true);
            if (Config.Screen1.Screen1_2.CheckListBoxItem3)
                m_CheckedListBox.SetItemChecked(3, true);
        }

        /// <summary>
        /// 適用イベントハンドラの設置
        /// </summary>
        protected override void SetEnableApplyEventHandler()
        {
            // 内容更新時に適用ボタンを有効化するイベントハンドラを追加
            m_DateTimePicker.ValueChanged += new EventHandler(EventHandler_EnableApply);
            m_FilePathTextBox.TextChanged += new EventHandler(EventHandler_EnableApply);
            m_ColorTextBox.TextChanged += new EventHandler(EventHandler_EnableApply);
            m_FontTextBox.TextChanged += new EventHandler(EventHandler_EnableApply);
            m_TrackBar.ValueChanged += new EventHandler(EventHandler_EnableApply);
            m_RadioButton1.CheckedChanged += new EventHandler(EventHandler_EnableApply);
            m_RadioButton2.CheckedChanged += new EventHandler(EventHandler_EnableApply);
            m_RadioButton3.CheckedChanged += new EventHandler(EventHandler_EnableApply);
            m_RadioButton4.CheckedChanged += new EventHandler(EventHandler_EnableApply);
            m_CheckedListBox.ItemCheck += new ItemCheckEventHandler( (sender, e) => { EventHandler_EnableApply(sender, e); } );
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// ファイル選択ダイアログボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_FilePathButton_Click(object sender, EventArgs e)
        {
            // ダイアログの生成
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;                                                 // 複数選択の禁止
            dialog.FileName = Path.GetFileName(m_FilePathTextBox.Text);                 // 初期のファイル名
            dialog.InitialDirectory = Path.GetDirectoryName(m_FilePathTextBox.Text);    // 初期のディレクトリ
            // 表示
            dialog.ShowDialog();
            // 選択されたファイルのパスをテキストボックスに書き込む
            m_FilePathTextBox.Text = dialog.FileName;
        }

        /// <summary>
        /// 色選択ダイアログボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_ColorButton_Click(object sender, EventArgs e)
        {
            // コンバータの生成
            ColorConverter converter = new ColorConverter();
            // ダイアログの生成
            ColorDialog dialog = new ColorDialog();
            dialog.Color = (Color)converter.ConvertFromString(m_ColorTextBox.Text);     // 初期カラー
            // 表示
            dialog.ShowDialog();
            // 選択された色をテキストボックスに書き込む
            m_ColorTextBox.Text = converter.ConvertToString(dialog.Color);
            m_ColorTextBox.ForeColor = dialog.Color;
        }

        /// <summary>
        /// フォント選択ダイアログボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_FontButton_Click(object sender, EventArgs e)
        {
            // コンバータの生成
            FontConverter converter = new FontConverter();
            // ダイアログの生成
            FontDialog dialog = new FontDialog();
            dialog.Font = (Font)converter.ConvertFromString(m_FontTextBox.Text);    // 初期フォント
            // 表示
            dialog.ShowDialog();
            // 選択された色をテキストボックスに書き込む
            m_FontTextBox.Text = converter.ConvertToString(dialog.Font);
            m_FontTextBox.Font = dialog.Font;
        }

        #endregion
    }
}
