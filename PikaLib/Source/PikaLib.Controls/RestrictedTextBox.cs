using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PikaLib.Controls
{
    /*
    /// <summary>
    /// 入力制限をかけられるテキストボックス。
    /// </summary>
    public partial class RestrictedTextBox : TextBox
    {
        #region メンバ変数
        #endregion

        #region プロパティ
        #endregion

        #region コンストラクタ
        /// <summary>
        /// PikaLib.Controls.RestrictedTextBox クラスの新しいインスタンスを初期化します。
        /// </summary>
        public RestrictedTextBox()
        {
            // コンポーネントの初期化
            InitializeComponent();
        }

        #endregion

        #region　WndProc メソッド (override)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_CHAR = 0x0102;
            const int WM_PASTE = 0x0302;

            switch (m.Msg)
            {
                case WM_CHAR:
                    if ((this.PermitChars != null) && (this.PermitChars.Length > 0))
                    {
                        KeyPressEventArgs eKeyPress = new KeyPressEventArgs((char)(m.WParam.ToInt32()));
                        this.OnChar(eKeyPress);

                        if (eKeyPress.Handled)
                        {
                            return;
                        }
                    }
                    break;
                case WM_PASTE:
                    if ((this.PermitChars != null) && (this.PermitChars.Length > 0))
                    {
                        this.OnPaste(new System.EventArgs());
                        return;
                    }
                    break;
            }

            base.WndProc(ref m);
        }

        #endregion

        #region　WndProcでの処理
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChar(KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (!HasPermitChars(e.KeyChar, this.PermitChars))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPaste(System.EventArgs e)
        {
            string stString = Clipboard.GetDataObject().GetData(System.Windows.Forms.DataFormats.Text).ToString();

            if (stString != null)
            {
                this.SelectedText = GetPermitedString(stString, this.PermitChars);
            }
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chTarget"></param>
        /// <param name="chPermits"></param>
        /// <returns></returns>
        private static bool HasPermitChars(char chTarget, char[] chPermits)
        {
            foreach (char ch in chPermits)
            {
                if (chTarget == ch)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stTarget"></param>
        /// <param name="chPermits"></param>
        /// <returns></returns>
        private static string GetPermitedString(string stTarget, char[] chPermits)
        {
            string stReturn = string.Empty;

            foreach (char chTarget in stTarget)
            {
                if (HasPermitChars(chTarget, chPermits))
                {
                    stReturn += chTarget;
                }
            }

            return stReturn;
        }

        #endregion
    }
     */
}
