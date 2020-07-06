using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Commander.Script.CLI
{
    /// <summary>
    /// CLIスクリプトマネージャ
    /// </summary>
    internal class CLIScriptManager
    {
        #region シングルトン
        /// <summary>
        /// CLIスクリプトマネージャ
        /// </summary>
        internal static CLIScriptManager Instance
        {
            get { return _Instance; }
        }
        private static readonly CLIScriptManager _Instance = new CLIScriptManager();

        #endregion

        #region メンバ変数
        /// <summary>
        /// キャッシュ
        /// </summary>
        private Dictionary<string, CacheItem> m_Cache = new Dictionary<string, CacheItem>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// CLIスクリプトマネージャ
        /// </summary>
        private CLIScriptManager()
        {
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// C#コンパイル
        /// </summary>
        /// <param name="scriptName">スクリプト名</param>
        /// <param name="script">スクリプト</param>
        /// <param name="assemblyNames">参照アセンブリ</param>
        /// <param name="updateTime">更新日時</param>
        /// <returns>コンパイル結果</returns>
        public CompilerResults CSharpCompile(string scriptName, string script, string[] assemblyNames, DateTime updateTime)
        {
            using (CodeDomProvider compiler = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } }))
            {
                return Compile(compiler, scriptName, script, assemblyNames, updateTime);
            }
        }

        /// <summary>
        /// VBコンパイル
        /// </summary>
        /// <param name="scriptName">スクリプト名</param>
        /// <param name="script">スクリプト</param>
        /// <param name="assemblyNames">参照アセンブリ</param>
        /// <param name="updateTime">更新日時</param>
        /// <returns>コンパイル結果</returns>
        public CompilerResults VBCompile(string scriptName, string script, string[] assemblyNames, DateTime updateTime)
        {
            using (CodeDomProvider compiler = new VBCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v4.0" } }))
            {
                return Compile(compiler, scriptName, script, assemblyNames, updateTime);
            }
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// コンパイル
        /// </summary>
        /// <param name="compiler">コンパイラ</param>
        /// <param name="scriptName">スクリプト名</param>
        /// <param name="script">スクリプト</param>
        /// <param name="assemblyNames">参照アセンブリ</param>
        /// <param name="updateTime">更新日時</param>
        /// <returns>コンパイル結果</returns>
        private CompilerResults Compile(CodeDomProvider compiler, string scriptName, string script, string[] assemblyNames, DateTime updateTime)
        {
            // キャッシュにコンパイル済みの結果が残っている場合、そのまま返す
            if ((m_Cache.ContainsKey(scriptName)) &&
                (m_Cache[scriptName].UpdateTime == updateTime))
            {
                return m_Cache[scriptName].CompilerResults;
            }

            // コンパイル時のオプション
            CompilerParameters param = new CompilerParameters(assemblyNames);
            param.GenerateInMemory = false;         // メモリ上だと、別のアセンブリから読み込めない
            param.IncludeDebugInformation = true;   // デバッグ情報を付加
            param.GenerateExecutable = false;       // 実行ファイルは作らない
            param.OutputAssembly = @"TMP\" + scriptName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".dll";
            // コンパイル
            CompilerResults results = compiler.CompileAssemblyFromSource(param, script);
            // 結果をキャッシュに格納
            m_Cache[scriptName] = new CacheItem(results, updateTime);
            // 結果を返す
            return results;
        }

        #endregion

        #region サブクラス
        /// <summary>
        /// キャッシュの要素
        /// </summary>
        private struct CacheItem
        {
            /// <summary>
            /// コンパイル結果
            /// </summary>
            public CompilerResults CompilerResults;

            /// <summary>
            /// 更新日時
            /// </summary>
            public DateTime UpdateTime;

            /// <summary>
            /// キャッシュの要素
            /// </summary>
            /// <param name="results">コンパイル結果</param>
            /// <param name="updateTime">更新日時</param>
            public CacheItem(CompilerResults results, DateTime updateTime)
            {
                CompilerResults = results;
                UpdateTime = updateTime;
            }
        }

        #endregion
    }
}
