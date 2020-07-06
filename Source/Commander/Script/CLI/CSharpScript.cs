using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.CodeDom.Compiler;

namespace Commander.Script.CLI
{
    /// <summary>
    /// C#スクリプト
    /// </summary>
    public class CSharpScript : CommanderScript
    {
        #region プロパティ
        /// <summary>
        /// インポート
        /// </summary>
        public Import Import { get; set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// C#スクリプト
        /// </summary>
        /// <param name="className">クラス名</param>
        public CSharpScript(string className)
            : this(className, new Import(), DateTime.Now, null)
        {
        }

        /// <summary>
        /// C#スクリプト
        /// </summary>
        /// <param name="className">クラス名</param>
        /// <param name="import">インポート</param>
        public CSharpScript(string className, Import import)
            : this(className, import, DateTime.Now, null)
        {
        }

        /// <summary>
        /// C#スクリプト
        /// </summary>
        /// <param name="className">クラス名</param>
        /// <param name="import">インポート</param>
        /// <param name="updateTime">更新日時</param>
        public CSharpScript(string className, Import import, DateTime updateTime)
            : this(className, import, updateTime, null)
        {
        }

        /// <summary>
        /// C#スクリプト
        /// </summary>
        /// <param name="className">クラス名</param>
        /// <param name="import">インポート</param>
        /// <param name="updateTime">更新日時</param>
        /// <param name="baseScript">親となるスクリプト</param>
        public CSharpScript(string className, Import import, DateTime updateTime, CommanderScript baseScript)
            : base(className, updateTime, baseScript)
        {
            // パラメータの受け渡し
            Import = import;
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// コンパイル
        /// </summary>
        public override CompilerResults Compile()
        {
            // 継承用　かなり適当
            int a = 0;
            string baseDllPath = "";
            if (BaseScript != null)
            {
                baseDllPath = BaseScript.Compile().PathToAssembly;
                ++a;
            }
            string[] importDlls = new string[Import.ImportDlls.Length + a];
            for (int i = 0; i < Import.ImportDlls.Length; ++i)
            {
                importDlls[i] = Import.ImportDlls[i];
            }
            if (a != 0)
                importDlls[Import.ImportDlls.Length] = baseDllPath;

            // コンパイル
            CompilerResults results =
                CLIScriptManager.Instance.CSharpCompile(ClassName, GetSourceCode(), importDlls, UpdateTime);
            // エラーがあれば、例外を送出
            if (results.Errors.HasErrors)
            {
                // 後でちゃんとした処理に書き換える
                string errorMessage = "";
                foreach (CompilerError error in results.Errors)
                {
                    int index = (m_FileInfos.Count - 1);
                    for (int i = 0; i < (m_FileInfos.Count - 1); ++i)
                    {
                        if (error.Line >= m_FileInfos[i].Line && error.Line < m_FileInfos[i + 1].Line)
                        {
                            index = i;
                        }
                    }
                    int line = error.Line - m_FileInfos[index].Line + 1;
                    int column = error.Column - 4;
                    errorMessage += (m_FileInfos[index].FileName + ":" + line + ": " + error.ErrorText + "\r\n");
                }
                throw new Exception(errorMessage);
            }

            return results;

            // コンパイル結果からインスタンスを生成し、返す
            //Type type = results.CompiledAssembly.GetType(ClassName);
            //ConstructorInfo constructorInfo = type.GetConstructor(new Type[] { typeof(ObjectBase) });
            //return (CommanderBase)constructorInfo.Invoke(new object[] { objectBase });
        }

        #endregion
    }
}
