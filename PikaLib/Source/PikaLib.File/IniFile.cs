using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace PikaLib.File
{
    /// <summary>
    /// INIファイル。
    /// </summary>
    [Serializable]
    public class IniFile
    {
        #region DLLの読み込み
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpDefault,
            StringBuilder lpReturnedstring,
            int nSize,
            string lpFileName);

        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(
            string lpApplicationName,
            string lpKeyName,
            string lpstring,
            string lpFileName);

        #endregion

        #region インデクサ
        /// <summary>
        /// sectionとkeyからiniファイルの設定値を取得または設定します。 
        /// </summary>
        /// <returns>指定したsectionとkeyの組合せが無い場合は""が返ります。</returns>
        public string this[string section, string key]
        {
            set
            {
                WritePrivateProfileString(section, key, value, FilePath);
            }
            get
            {
                return GetValue(section, key, "");
            }
        }

        #endregion

        #region プロパティ
        /// <summary>
        /// ファイルパスを取得または設定します。
        /// ファイルが存在しない場合は初回書き込み時に作成されます。
        /// </summary>
        public string FilePath { get; set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// INIファイルのファイルパスを使用して、
        /// PikaLib.File.IniFile クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="filePath">INIファイルのファイルパス。</param>
        public IniFile(string filePath)
        {
            FilePath = filePath;
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// sectionとkeyからiniファイルの設定値を取得します。
        /// 指定したsectionとkeyの組合せが無い場合はdefaultvalueで指定した値が返ります。
        /// </summary>
        /// <returns>
        /// sectionとkeyに対応したiniファイルの設定値。
        /// </returns>
        public string GetValue(string section, string key, string defaultvalue)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, defaultvalue, sb, sb.Capacity, FilePath);
            return sb.ToString();
        }

        #endregion
    }
}
