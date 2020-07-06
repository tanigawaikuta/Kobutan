using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConfigApp.ConfigScreens
{
    /// <summary>
    /// スクリーン1_1
    /// </summary>
    public partial class Screen1_1 : ConfigScreen
    {
        #region コンストラクタ
        /// <summary>
        /// スクリーン1_1
        /// </summary>
        public Screen1_1()
        {
            // コンポーネントの初期化
            InitializeComponent();
        }

        #endregion

        #region オーバーライド
        /// <summary>
        /// 適用
        /// </summary>
        public override void Apply()
        {
            // チェックボックス
            Config.Screen1.Screen1_1.CheckBox1 = m_CheckBox1.Checked;
            Config.Screen1.Screen1_1.CheckBox2 = m_CheckBox2.Checked;
            Config.Screen1.Screen1_1.CheckBox3 = m_CheckBox3.Checked;
            Config.Screen1.Screen1_1.CheckBox4 = m_CheckBox4.Checked;
            Config.Screen1.Screen1_1.CheckBox5 = m_CheckBox5.Checked;
            Config.Screen1.Screen1_1.CheckBox6 = m_CheckBox6.Checked;
            Config.Screen1.Screen1_1.CheckBox7 = m_CheckBox7.Checked;
            Config.Screen1.Screen1_1.CheckBox8 = m_CheckBox8.Checked;
            // コンボボックス
            Config.Screen1.Screen1_1.ComboBoxIndex = m_ComboBox.SelectedIndex;
            // テキストボックス
            Config.Screen1.Screen1_1.Text1 = m_TextBox1.Text;
            Config.Screen1.Screen1_1.Text2 = m_TextBox2.Text;
            // リストボックス
            string[] items = new string[m_ListBox.Items.Count];
            for (int i = 0; i < m_ListBox.Items.Count; ++i)
            {
                items[i] = m_ListBox.Items[i].ToString();
            }
            Config.Screen1.Screen1_1.ListTexts = items;
        }

        /// <summary>
        /// コンフィグの読み込み
        /// </summary>
        public override void LoadConfig()
        {
            // チェックボックス
            m_CheckBox1.Checked = Config.Screen1.Screen1_1.CheckBox1;
            m_CheckBox2.Checked = Config.Screen1.Screen1_1.CheckBox2;
            m_CheckBox3.Checked = Config.Screen1.Screen1_1.CheckBox3;
            m_CheckBox4.Checked = Config.Screen1.Screen1_1.CheckBox4;
            m_CheckBox5.Checked = Config.Screen1.Screen1_1.CheckBox5;
            m_CheckBox6.Checked = Config.Screen1.Screen1_1.CheckBox6;
            m_CheckBox7.Checked = Config.Screen1.Screen1_1.CheckBox7;
            m_CheckBox8.Checked = Config.Screen1.Screen1_1.CheckBox8;
            // コンボボックス
            if ((Config.Screen1.Screen1_1.ComboBoxIndex >= 0) &&
                (Config.Screen1.Screen1_1.ComboBoxIndex < 4))
            {
                m_ComboBox.SelectedIndex = Config.Screen1.Screen1_1.ComboBoxIndex;
            }
            else
            {
                m_ComboBox.SelectedIndex = 0;
            }
            // テキストボックス
            m_TextBox1.Text = Config.Screen1.Screen1_1.Text1;
            m_TextBox2.Text = Config.Screen1.Screen1_1.Text2;
            // リストボックス
            foreach (string s in Config.Screen1.Screen1_1.ListTexts)
            {
                m_ListBox.Items.Add(s);
            }
        }

        /// <summary>
        /// 適用イベントハンドラの設置
        /// </summary>
        protected override void SetEnableApplyEventHandler()
        {
            // 内容更新時に適用ボタンを有効化するイベントハンドラを追加
            m_CheckBox1.CheckedChanged += new EventHandler(EventHandler_EnableApply);
            m_CheckBox2.CheckedChanged += new EventHandler(EventHandler_EnableApply);
            m_CheckBox3.CheckedChanged += new EventHandler(EventHandler_EnableApply);
            m_CheckBox4.CheckedChanged += new EventHandler(EventHandler_EnableApply);
            m_CheckBox5.CheckedChanged += new EventHandler(EventHandler_EnableApply);
            m_CheckBox6.CheckedChanged += new EventHandler(EventHandler_EnableApply);
            m_CheckBox7.CheckedChanged += new EventHandler(EventHandler_EnableApply);
            m_CheckBox8.CheckedChanged += new EventHandler(EventHandler_EnableApply);
            m_ComboBox.SelectedIndexChanged += new EventHandler(EventHandler_EnableApply);
            m_TextBox1.TextChanged += new EventHandler(EventHandler_EnableApply);
            m_TextBox2.TextChanged += new EventHandler(EventHandler_EnableApply);
            m_AddButton.Click += new EventHandler(EventHandler_EnableApply);
            m_RemoveButton.Click += new EventHandler(EventHandler_EnableApply);
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// 追加ボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_AddButton_Click(object sender, EventArgs e)
        {
            // テキストボックスの内容を追加
            m_ListBox.Items.Add(m_ListItemTextBox.Text);
            // テキストのクリア
            m_ListItemTextBox.Text = "";
        }

        /// <summary>
        /// 削除ボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_RemoveButton_Click(object sender, EventArgs e)
        {
            // 選択されたアイテムの削除
            if (m_ListBox.SelectedIndex >= 0)
            {
                m_ListBox.Items.RemoveAt(m_ListBox.SelectedIndex);
            }
        }

        #endregion
    }
}
