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
    /// スクリーン2
    /// </summary>
    public partial class Screen2 : ConfigScreen
    {
        #region コンストラクタ
        /// <summary>
        /// スクリーン2
        /// </summary>
        public Screen2()
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
            // 保存するための配列を作成
            var items = new List<Config.CScreen2.CListItem>();
            foreach (Config.CScreen2.CListItem item in m_ListBox.Items)
            {
                // アイテムの追加
                items.Add(item);
            }
            // コンフィグに渡す
            Config.Screen2.ListItems = items.ToArray();
        }

        /// <summary>
        /// コンフィグの読み込み
        /// </summary>
        public override void LoadConfig()
        {
            // リストボックスの設定
            foreach (object item in Config.Screen2.ListItems)
            {
                m_ListBox.Items.Add(item);
            }
        }

        /// <summary>
        /// 適用イベントハンドラの設置
        /// </summary>
        protected override void SetEnableApplyEventHandler()
        {
            // 内容更新時に適用ボタンを有効化するイベントハンドラを追加
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
            Config.CScreen2.CListItem item =
                new Config.CScreen2.CListItem((int)m_NumericUpDown.Value, m_TextBox.Text, m_CheckBox.Checked);
            m_ListBox.Items.Add(item);
            // クリア
            m_NumericUpDown.Value = 0;
            m_TextBox.Text = "";
            m_CheckBox.Checked = false;
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
