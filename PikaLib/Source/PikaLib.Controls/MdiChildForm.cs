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
    /// MDI子フォーム。
    /// このフォームは閉じられた後でも再表示することが可能です。
    /// フォームのデザインはユーザーコントロールを渡すことで行います。
    /// </summary>
    /// <example> C#における使用例
    /// <code>
    /// class ParentForm
    /// {
    ///     // 子フォームの参照
    ///     private PikaLib.Controls.MdiChildForm m_ChildForm;
    ///     
    ///     public void Initialize()
    ///     {
    ///         // MDIコンテナを有効にする (デザイナ上からでも可)
    ///         this.IsMdiContainer = true;
    ///         // 子フォームとその上で表示させるユーザーコントロールを生成
    ///         UserControl uc = new MyUserControl();
    ///         m_ChildForm = new PikaLib.Controls.MdiChildForm(uc);
    ///         // その他 m_ChildFormの設定など…
    ///     }
    ///     
    ///     public void ShowChildForm()
    ///     {
    ///         // 初回、または閉じられている状態ならば子フォームを表示
    ///         // すでに表示中の場合は何も起こらない
    ///         m_ChildForm.Show();
    ///     }
    /// }
    /// </code>
    /// </example>
    public partial class MdiChildForm : Form
    {
        #region プロパティ
        /// <summary>
        /// MDI子フォーム上に表示するユーザーコントロールを取得します。
        /// </summary>
        /// <returns>MDI子フォーム上に表示するユーザーコントロール。</returns>
        public UserControl MdiUserControl { get; private set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// MDI子フォーム上に表示するユーザーコントロールと、
        /// 親となるフォームを使用して、
        /// PikaLib.Controls. MdiChildForm クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="userControl">MDI子フォーム上に表示するユーザーコントロール。</param>
        /// <param name="parent">親となるフォーム。</param>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        public MdiChildForm(UserControl userControl, Form parent)
            : this(userControl, parent, "MDIForm")
        {
        }
        
        /// <summary>
        /// MDI子フォーム上に表示するユーザーコントロールと、
        /// 親となるフォームと、
        /// フォームのタイトルを使用して、
        /// PikaLib.Controls. MdiChildForm クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="userControl">MDI子フォーム上に表示するユーザーコントロール。</param>
        /// <param name="parent">親となるフォーム。</param>
        /// <param name="title">フォームのタイトル。</param>
        /// <exception cref="System.ArgumentException">不正なパラメータが渡された際に発生します。</exception>
        /// <exception cref="System.ArgumentNullException">nullがパラメータとして渡された際に発生します。</exception>
        public MdiChildForm(UserControl userControl, Form parent, string title)
        {
            // 例外処理
            if (userControl == null)
                throw new ArgumentNullException("userControl");
            if (!(userControl is UserControl))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "userControl");
            if (parent == null)
                throw new ArgumentNullException("parent");
            if (!(parent is Form))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "parent");
            if (title == null)
                throw new ArgumentNullException("title");
            if (!(title is string))
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "title");

            // コンポーネントの初期化
            InitializeComponent();
            try
            {
                // パラメータの受け取り
                MdiUserControl = userControl;
                MdiParent = parent;
                // フォームの設定
                Text = title;
                ClientSize = MdiUserControl.Size;
                // ユーザーコントロールの設定
                MdiUserControl.Location = new Point(0, 0);
                MdiUserControl.Dock = DockStyle.Fill;
                m_MdiPanel.Controls.Add(MdiUserControl);
            }
            catch (System.ArgumentException ex)
            {
                // 引数の例外
                throw new ArgumentException(ExceptionMessages.ArgumentExceptionMessage1, "userControl", ex);
            }
        }

        #endregion

        #region オーバーライド
        /// <summary>
        /// フォームが閉じられる際に実行されます。
        /// </summary>
        /// <param name="e">イベントデータを格納している System.Windows.Forms.FormClosingEventArgs。</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // 通常は閉じずに隠すのみ
            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                this.Visible = false;
                e.Cancel = true;
            }
            // MDI親フォームが閉じられた際の処理
            else
            {
                // そのまま閉じる
                e.Cancel = false;
            }

            // 基底クラスで呼び出す
            base.OnFormClosing(e);
        }

        #endregion
    }
}
