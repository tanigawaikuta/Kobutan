using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commander.Script.CLI
{
    /// <summary>
    /// 補完機能付きCLIスクリプトのインポート
    /// </summary>
    [Serializable]
    public class CLIWithComplementImport : Import
    {
        #region 項目
        /// <summary>
        /// 名前空間
        /// </summary>
        public string[] UsingNamespaces;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 補完機能付きCLIスクリプトのインポート
        /// </summary>
        public CLIWithComplementImport()
        {
        }

        #endregion

        #region デフォルト設定
        /// <summary>
        /// デフォルト設定の適用
        /// </summary>
        public override void ApplyDefault()
        {
            UsingNamespaces = new string[] {
                "System",  "System.Collections.Generic",
                "System.Linq", "System.Text" };
            base.ApplyDefault();
        }

        #endregion
    }
}
