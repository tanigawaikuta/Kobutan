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
    /// <summary>
    /// ユーザコントロール切り替えパネル。
    /// </summary>
    public partial class UserControlSwitchingPanel : Panel
    {
        #region プロパティ
        /// <summary>
        /// 現在表示中のユーザコントロールを取得します。
        /// </summary>
        /// <returns>現在表示中のユーザコントロール。</returns>
        public UserControl UserContorol { get; private set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// PikaLib.Controls.UserControlSwitchingPanel クラスの新しいインスタンスを初期化します。
        /// </summary>
        public UserControlSwitchingPanel()
        {
            // コンポーネントの初期化
            InitializeComponent();
        }

        /// <summary>
        /// 表示したいユーザコントロールを使用して、
        /// PikaLib.Controls.UserControlSwitchingPanel クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="userControl">表示したいユーザコントロール。</param>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        public UserControlSwitchingPanel(UserControl userControl)
        {
            // コンポーネントの初期化
            InitializeComponent();

            // 与えられたユーザコントロールにチェンジ
            ChangeUserContorol(userControl);
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// 渡されたユーザコントロールに切り替えます。
        /// </summary>
        /// <param name="userControl">切り替えたいユーザコントロール。</param>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        public void ChangeUserContorol(UserControl userControl)
        {
            // 例外処理
            if (userControl == null)
                throw new ArgumentNullException("userControl");
            if (!(userControl is UserControl))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "userControl");

            try
            {
                // 渡されたユーザーコントロールが表示中のものと別なら切り替え
                if (userControl != UserContorol)
                {
                    // 前回のユーザコントロールを取り除く
                    ClearPanel();
                    // 新たなユーザコントロールを追加
                    UserContorol = userControl;
                    Controls.Add(UserContorol);
                }
            }
            catch (System.ArgumentException ex)
            {
                // 引数の例外
                ClearPanel();
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "userControl", ex);
            }
            catch (System.Exception)
            {
                // その他例外
                ClearPanel();
                throw;
            }
        }

        /// <summary>
        /// パネルをクリアします。
        /// </summary>
        public void ClearPanel()
        {
            // 取り除く
            if (UserContorol != null)
            {
                Controls.Remove(UserContorol);
                UserContorol = null;
            }
        }

        #endregion
    }
}
