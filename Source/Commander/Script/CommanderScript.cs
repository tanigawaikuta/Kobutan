using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;

namespace Commander.Script
{
    /// <summary>
    /// コマンダ スクリプト
    /// </summary>
    public abstract class CommanderScript
    {
        #region 定数
        /// <summary>
        /// BOM (utf-8でテキストファイルの先頭につく文字)
        /// </summary>
        private static readonly string Bom = Encoding.UTF8.GetString(new byte[] { 0xEF, 0xBB, 0xBF });

        #endregion

        #region プロパティ
        /// <summary>
        /// クラス名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 親となるスクリプト。
        /// 無い場合はnullを設定する。
        /// </summary>
        public CommanderScript BaseScript { get; set; }

        /// <summary>
        /// インデント
        /// </summary>
        public string Indent { get; set; }

        /// <summary>
        /// 改行
        /// </summary>
        public string NewLine { get; set; }

        /// <summary>
        /// ソースコード
        /// Key:ファイル名, Value:ソースコード
        /// </summary>
        public Dictionary<string, string> SourceCodes { get; private set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コマンダ スクリプト
        /// </summary>
        /// <param name="className">クラス名</param>
        public CommanderScript(string className)
            : this(className, DateTime.Now, null)
        {
        }

        /// <summary>
        /// コマンダ スクリプト
        /// </summary>
        /// <param name="className">クラス名</param>
        /// <param name="updateTime">更新日時</param>
        public CommanderScript(string className, DateTime updateTime)
            : this(className, updateTime, null)
        {
        }

        /// <summary>
        /// コマンダ スクリプト
        /// </summary>
        /// <param name="className">クラス名</param>
        /// <param name="import">インポート</param>
        /// <param name="updateTime">更新日時</param>
        /// <param name="baseScript">親となるスクリプト</param>
        public CommanderScript(string className, DateTime updateTime, CommanderScript baseScript)
        {
            // パラメータの受け渡し
            ClassName = className;
            UpdateTime = updateTime;
            BaseScript = baseScript;
            // インデント、改行
            Indent = "    ";
            NewLine = "\r\n";

            // その他メソッドを格納するためのリスト
            SourceCodes = new Dictionary<string, string>();
        }

        #endregion

        #region 抽象メソッド, 仮想メソッド
        /// <summary>
        /// コンパイル
        /// </summary>
        /// <returns>コンパイル結果</returns>
        public abstract CompilerResults Compile();

        /// <summary>
        /// ソースコードの取得
        /// </summary>
        /// <returns>ソースコード</returns>
        public virtual string GetSourceCode()
        {
            // スクリプトエンジンに渡す文字列を生成
            StringBuilder sb = new StringBuilder();
            // 親のスクリプトがあれば、追加
            //if (BaseScript != null)
            //{
            //    sb.AppendLine(BaseScript.GetSourceCode());
            //    sb.AppendLine();
            //}
            // 全ソースコードを結合
            string[] newLines = new string[] { "\r\n" };    // 適当
            m_FileInfos.Clear();
            Action<string> addCode = new Action<string>((code) => sb.AppendLine(RemoveBom(code)));
            foreach (string fileName in SourceCodes.Keys)
            {
                int line = sb.ToString().Split(newLines, StringSplitOptions.None).Length;
                m_FileInfos.Add(new FileInfo(fileName, line, 4));
                addCode(SourceCodes[fileName]);
            }
            // 結果を返す
            return sb.ToString();
        }

        #endregion

        #region 継承先で使用されるメソッド
        /// <summary>
        /// BOM (utf-8でテキストファイルの先頭につく文字)の削除
        /// </summary>
        /// <param name="text">元の文字列</param>
        /// <returns>BOMを取り除いた文字列</returns>
        protected string RemoveBom(string text)
        {
            // ファイルの先頭文字を除去
            if (text.IndexOf(Bom) == 0)
            {
                // 取り除いた結果を返す
                return text.Remove(0, Bom.Length);
            }
            // 無ければそのままの結果を返す
            return text;
        }

        #endregion

        #region コンパイルエラー用
        // 適当
        // そのうち修正予定

        /// <summary>ファイル情報</summary>
        protected List<FileInfo> m_FileInfos = new List<FileInfo>();
        /// <summary>ファイル情報</summary>
        protected class FileInfo
        {
            /// <summary>ファイル名</summary>
            public string FileName;
            /// <summary>行番号</summary>
            public int Line;
            /// <summary>列番号</summary>
            public int Column;

            public FileInfo(string fileName, int line, int column)
            {
                FileName = fileName;
                Line = line;
                Column = column;
            }
        }

        #endregion
    }
}
