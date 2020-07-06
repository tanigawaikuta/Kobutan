using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDIApp
{
    /// <summary>
    /// MDIフォーム1のユーザーコントロール
    /// </summary>
    public partial class MdiUserControl1 : UserControl
    {
        #region コンストラクタ
        /// <summary>
        /// MDIフォーム1のユーザーコントロール
        /// </summary>
        public MdiUserControl1()
        {
            // コンポーネントの初期化
            InitializeComponent();
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// Closeボタンが押された際のイベントハンドラ
        /// </summary>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            // 搭載先のフォームを閉じる
            ParentForm.Close();
        }

        #endregion
    }
}
