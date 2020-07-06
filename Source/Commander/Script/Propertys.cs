using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PikaLib.File;

namespace Commander.Script
{
    /// <summary>
    /// プロパティ
    /// </summary>
    [Serializable]
    public class Propertys : SerializableXML
    {
        #region プロパティ一覧
        /// <summary>
        /// コマンダ実行中のユーザによって変更できるプロパティ
        /// </summary>
        public Property[] PublicPropertys;

        /// <summary>
        /// コマンダ実行中のユーザによって変更できないプロパティ
        /// </summary>
        public Property[] PrivatePropertys;

        /// <summary>
        /// プロパティ
        /// </summary>
        public struct Property
        {
            /// <summary>名前</summary>
            public string Name;
            /// <summary>型</summary>
            public string Type;
            /// <summary>初期値</summary>
            public string InitialValue;
            /// <summary>説明</summary>
            public string Description;
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// プロパティ一覧
        /// </summary>
        public Propertys()
        {
        }

        #endregion

        #region デフォルト設定
        /// <summary>
        /// デフォルト設定の適用
        /// </summary>
        public override void ApplyDefault()
        {
            PublicPropertys = null;
            PrivatePropertys = null;
        }

        #endregion
    }
}
