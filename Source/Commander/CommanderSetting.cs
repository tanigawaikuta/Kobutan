using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PikaLib.File;

namespace Commander
{
    /// <summary>
    /// コマンダ 設定
    /// </summary>
    [Serializable]
    public class CommanderSetting : SerializableXML
    {
        #region 各種情報
        /// <summary>各種情報</summary>
        public CInformation Information;
        /// <summary>各種情報</summary>
        public struct CInformation
        {
            /// <summary>名前</summary>
            public string Name;
            /// <summary>バージョン</summary>
            public string Version;
            /// <summary>親コマンダ</summary>
            public string BaseCommander;
            /// <summary>説明</summary>
            public string Description;
        }

        #endregion

        #region 通信設定
        /// <summary>通信設定</summary>
        public CCommunication Communication;
        /// <summary>通信設定</summary>
        public struct CCommunication
        {
            /// <summary>プロトコル</summary>
            public string Protocol;
            /// <summary>送信スレッドが有効かどうか</summary>
            public bool SendThreadEnable;
            /// <summary>送信スレッドの周期</summary>
            public uint SendCycle;
        }

        #endregion

        #region プログラム設定
        /// <summary>プログラム設定</summary>
        public CProgramming Programming;
        /// <summary>プログラム設定</summary>
        public struct CProgramming
        {
            /// <summary>言語</summary>
            public ProgrammingLanguage Language;
            /// <summary>自動補完が有効かどうか</summary>
            public bool WithComplement;
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コマンダ 設定
        /// </summary>
        public CommanderSetting()
        {
        }

        #endregion

        #region デフォルト設定
        /// <summary>
        /// デフォルト設定の適用
        /// </summary>
        public override void ApplyDefault()
        {
            // 各種情報
            Information.Name = "NewCommander";
            Information.Version = "1.0";
            Information.BaseCommander = "";
            Information.Description = "";
            // 通信設定
            Communication.Protocol = "Kobuki";
            Communication.SendThreadEnable = false;
            Communication.SendCycle = 80;
            // プログラム設定
            Programming.Language = ProgrammingLanguage.CSharp;
            Programming.WithComplement = true;
        }

        #endregion
    }

    /// <summary>
    /// プログラミング言語
    /// </summary>
    public enum ProgrammingLanguage
    {
        /// <summary>C#</summary>
        CSharp,
        /// <summary>VB</summary>
        VB,
    }
}
