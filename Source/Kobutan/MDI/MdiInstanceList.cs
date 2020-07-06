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
    /// MDI インスタンスリスト
    /// </summary>
    public partial class MdiInstanceList : UserControl
    {
        #region メンバ変数
        /// <summary>
        /// コンフィグ
        /// </summary>
        private Config.KobutanConfig m_Config;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// MDI コマンダ
        /// </summary>
        /// <param name="config">コンフィグ</param>
        public MdiInstanceList(Config.KobutanConfig config)
        {
            // コンポーネントの初期化
            InitializeComponent();
            // コンフィグの受け取り
            m_Config = config;
        }

        #endregion
    }
}
