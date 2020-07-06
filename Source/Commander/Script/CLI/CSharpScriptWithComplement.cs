using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commander.Script.CLI
{
    /// <summary>
    /// C#スクリプト 補完機能付き
    /// </summary>
    public class CSharpScriptWithComplement : CSharpScript
    {
        #region プロパティ
        /// <summary>
        /// プロパティ
        /// </summary>
        public Propertys Propertys { get; set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// C#スクリプト
        /// </summary>
        /// <param name="className">クラス名</param>
        public CSharpScriptWithComplement(string className)
            : this(className, new Propertys(), new CLIWithComplementImport(), DateTime.Now, null)
        {
        }

        /// <summary>
        /// C#スクリプト
        /// </summary>
        /// <param name="className">クラス名</param>
        /// <param name="propertys">プロパティ</param>
        /// <param name="import">インポート</param>
        public CSharpScriptWithComplement(string className, Propertys propertys, CLIWithComplementImport import)
            : this(className, propertys, import, DateTime.Now, null)
        {
        }

        /// <summary>
        /// C#スクリプト
        /// </summary>
        /// <param name="className">クラス名</param>
        /// <param name="propertys">プロパティ</param>
        /// <param name="import">インポート</param>
        /// <param name="updateTime">更新日時</param>
        public CSharpScriptWithComplement(string className, Propertys propertys, CLIWithComplementImport import, DateTime updateTime)
            : this(className, propertys, import, updateTime, null)
        {
        }

        /// <summary>
        /// C#スクリプト
        /// </summary>
        /// <param name="className">クラス名</param>
        /// <param name="propertys">プロパティ</param>
        /// <param name="import">インポート</param>
        /// <param name="updateTime">更新日時</param>
        /// <param name="baseScript">親となるスクリプト</param>
        public CSharpScriptWithComplement(string className, Propertys propertys, CLIWithComplementImport import, DateTime updateTime, CommanderScript baseScript)
            : base(className, import, updateTime, baseScript)
        {
            // パラメータの受け渡し
            Propertys = propertys;
            // 初期のコードをセット
            InitializeMethodCodes();
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// ソースコードの取得
        /// </summary>
        /// <returns>ソースコード</returns>
        public override string GetSourceCode()
        {
            // クラス単位のソースコード
            return GetClassCode();
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// 全てのメソッドのコードを初期化
        /// </summary>
        private void InitializeMethodCodes()
        {
            // 基底スクリプトの名前
            string baseScriptName = null;
            if (BaseScript != null)
                baseScriptName = BaseScript.ClassName;
        }

        /// <summary>
        /// クラス単位のソースコードを生成する
        /// </summary>
        /// <returns>クラス単位のソースコード</returns>
        private string GetClassCode()
        {
            // 文字列ビルダーの生成
            StringBuilder sb = new StringBuilder();

            // 親のスクリプトがあれば、追加
            //if (BaseScript != null)
            //{
            //    sb.AppendLine(BaseScript.GetSourceCode());
            //    sb.AppendLine();
            //}
            // クラスヘッダーの追加
            AddClassHeader(sb);
            // プロパティの追加
            AddPropertys(sb, "public", Propertys.PublicPropertys);
            AddPropertys(sb, "private", Propertys.PrivatePropertys);
            // メソッドの追加
            string[] newLines = new string[] { "\r\n" };    // 適当
            m_FileInfos.Clear();
            foreach (string fileName in SourceCodes.Keys)
            {
                int line = sb.ToString().Split(newLines, StringSplitOptions.None).Length;
                m_FileInfos.Add(new FileInfo(fileName, line, 4));
                AddMethod(sb, SourceCodes[fileName]);
            }
            sb.AppendLine(@"}");

            // 結果を返す
            return sb.ToString();
        }

        /// <summary>
        /// クラスヘッダーの追加
        /// </summary>
        /// <param name="sb"></param>
        private void AddClassHeader(StringBuilder sb)
        {
            // インポート関連
            if (((CLIWithComplementImport)Import).UsingNamespaces != null)
            {
                foreach (string un in ((CLIWithComplementImport)Import).UsingNamespaces)
                {
                    sb.Append("using ");
                    sb.Append(un);
                    sb.AppendLine(";");
                }
            }
            // クラスの先頭のコードを生成
            sb.Append(@"public class ");
            sb.Append(ClassName);
            sb.Append(@" : ");
            // 基底クラスの設定
            string baseClass = "";
            if (BaseScript != null)
                baseClass = BaseScript.ClassName;
            else
                baseClass = @"Commander.Script.CommanderBase";
            sb.AppendLine(baseClass);
            sb.AppendLine("{");
            // コンストラクタの追加
            sb.Append(Indent);
            sb.Append(@"public ");
            sb.Append(ClassName);
            sb.AppendLine(@"(Commander.ObjectBase objectBase) : base(objectBase)");
            sb.Append(Indent);
            sb.AppendLine(@"{");
            sb.Append(Indent);
            sb.AppendLine(@"}");
            sb.AppendLine();
        }

        /// <summary>
        /// プロパティの追加
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="accessModifier"></param>
        /// <param name="propertys"></param>
        private void AddPropertys(StringBuilder sb, string accessModifier, Propertys.Property[] propertys)
        {
            if (propertys != null)
            {
                foreach (Propertys.Property p in propertys)
                {
                    sb.Append(Indent);
                    sb.Append(accessModifier);
                    sb.Append(@" ");
                    sb.Append(p.Type);
                    sb.Append(@" ");
                    sb.Append(p.Name);
                    sb.Append(@" = ");
                    sb.Append(p.InitialValue);
                    sb.AppendLine(@";");
                }
            }
        }

        /// <summary>
        /// メソッドの追加
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="methodCode"></param>
        private void AddMethod(StringBuilder sb, string methodCode)
        {
            // 行ごとに読み取る
            string line = "";
            System.IO.StringReader sr = new System.IO.StringReader(RemoveBom(methodCode));

            // 行ごとの処理
            while ((line = sr.ReadLine()) != null)
            {
                sb.Append(Indent);
                sb.AppendLine(line);
            }
            sb.AppendLine();
        }

        #endregion
    }
}
