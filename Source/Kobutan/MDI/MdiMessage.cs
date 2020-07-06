using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kobutan.MDI
{
    /// <summary>
    /// MDIメッセージ
    /// </summary>
    public partial class MdiMessage : UserControl
    {
        #region コンストラクタ
        /// <summary>
        /// MDIメッセージ
        /// </summary>
        public MdiMessage()
        {
            // コンポーネントの初期化
            InitializeComponent();
        }

        #endregion

        #region 公開メソッド
        public void Write(string message)
        {
            m_MessageTextBox.Text += message + "\r\n";
        }

        public void Clear()
        {
            m_MessageTextBox.Text = "";
        }

        #endregion
    }
}
