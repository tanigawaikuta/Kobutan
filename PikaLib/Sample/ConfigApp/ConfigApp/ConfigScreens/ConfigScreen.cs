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
    /// コンフィグスクリーン
    /// </summary>
    public partial class ConfigScreen : UserControl
    {
        #region プロパティ
        /// <summary>
        /// コンフィグ
        /// </summary>
        public Config Config { get; private set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンフィグスクリーン
        /// </summary>
        public ConfigScreen()
        {
            // コンポーネントの初期化
            InitializeComponent();
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="config">コンフィグ</param>
        public void Initialize(Config config)
        {
            // 引数の受け渡し
            Config = config;

            // コンフィグの読み込み
            LoadConfig();
            // 適用イベントハンドラの設置
            SetEnableApplyEventHandler();
        }

        #endregion

        #region 仮想メソッド
        /// <summary>
        /// 適用
        /// </summary>
        public virtual void Apply() { }

        /// <summary>
        /// コンフィグの読み込み
        /// </summary>
        public virtual void LoadConfig() { }

        /// <summary>
        /// 適用イベントハンドラの設置
        /// </summary>
        protected virtual void SetEnableApplyEventHandler() { }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// 適用ボタンを有効化するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        protected void EventHandler_EnableApply(object sender, EventArgs e)
        {
            // 適用ボタン有効化
            MainForm form = (MainForm)this.Parent.Parent;
            form.IsEnableApplyButton = true;
        }

        #endregion
    }
}
