using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PikaLib.File;

namespace Commander.Script
{
    /// <summary>
    /// インポート
    /// </summary>
    [Serializable]
    public class Import : SerializableXML
    {
        #region 項目
        /// <summary>
        /// インポート Dll
        /// </summary>
        public string[] ImportDlls;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// インポート
        /// </summary>
        public Import()
        {
        }

        #endregion

        #region デフォルト設定
        /// <summary>
        /// デフォルト設定の適用
        /// </summary>
        public override void ApplyDefault()
        {
            ImportDlls = null;
        }

        #endregion
    }
}
