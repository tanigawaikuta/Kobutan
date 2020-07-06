using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using PikaLib.File;

namespace CommanderCreater.Config
{
    /// <summary>
    /// コマンダクリエータのコンフィグ
    /// </summary>
    [Serializable]
    public class CommanderCreaterConfig : SerializableXML
    {
        #region 各種情報
        /// <summary>各種情報</summary>
        public CInformation Information;
        /// <summary>各種情報</summary>
        public struct CInformation
        {
            /// <summary>メインウィンドウ</summary>
            public CWindowState MainWindow;
            /// <summary>ウィンドウの状態</summary>
            public struct CWindowState
            {
                /// <summary>サイズ</summary>
                public Size Size;
                /// <summary>位置</summary>
                public Point Location;
                /// <summary>ウィンドウの状態</summary>
                public FormWindowState WindowState;
            }
        }

        #endregion

        #region 設定
        /// <summary>設定</summary>
        public CSetting Setting;
        /// <summary>設定</summary>
        public struct CSetting
        {
            /// <summary>ディレクトリ</summary>
            public CDirectory Directory;
            /// <summary>ディレクトリ</summary>
            public struct CDirectory
            {
                /// <summary>コマンダディレクトリ</summary>
                public string Commanders;
                /// <summary>受信データディレクトリ</summary>
                public string ReceivedData;
                /// <summary>プラグイン</summary>
                public string Plugins;
            }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コマンダクリエータのコンフィグ
        /// </summary>
        public CommanderCreaterConfig()
        {
        }

        #endregion

        #region デフォルト設定
        /// <summary>
        /// デフォルト設定の適用
        /// </summary>
        public override void ApplyDefault()
        {
            //=========================
            // 各種情報
            //=========================
            // メインウィンドウ
            Information.MainWindow.Size = new Size(800, 600);
            Information.MainWindow.Location = new Point(0, 0);
            Information.MainWindow.WindowState = FormWindowState.Maximized;

            //=========================
            // 設定
            //=========================
            // ディレクトリ
            Setting.Directory.Commanders = @".\Commanders\";
            Setting.Directory.ReceivedData = @".\ReceivedData\";
            Setting.Directory.Plugins = @".\Plugins\";
        }

        #endregion
    }
}
