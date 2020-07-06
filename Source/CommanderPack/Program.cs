using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PikaLib.File;
using Commander;
using Commander.Script;
using Commander.Script.CLI;

namespace CommanderPack
{
    /// <summary>
    /// プログラム
    /// </summary>
    class Program
    {
        #region 定数
        /// <summary>設定ファイルパス</summary>
        private static readonly string SettingFilePath = @"Setting.xml";
        /// <summary>スクリプトディレクトリパス</summary>
        private static readonly string ScriptDirectoryPath = @"Script/";
        /// <summary>スクリプト プロパティ</summary>
        private static readonly string ScriptPropertysPath = ScriptDirectoryPath + @"Propertys.xml";
        /// <summary>スクリプト インポート</summary>
        private static readonly string ScriptImportPath = ScriptDirectoryPath + @"Import.xml";
        /// <summary>スクリーンディレクトリパス</summary>
        private static readonly string ScreenDirectoryPath = @"Screen/";

        #endregion

        /// <summary>
        /// プログラムのエントリポイント
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        static void Main(string[] args)
        {
            // 暫定
            // 引数1: パックしたいディレクトリ
            // 引数2: 出力先
            if (args.Length > 0)
            {
                if (args[0].LastIndexOfAny(new char[] { '\\', '/' }) != (args[0].Length - 1))
                {
                    args[0] += @"\";
                }

                try
                {
                    CommanderSetting setting = (CommanderSetting)SerializableXML.ReadXMLFile(args[0] + SettingFilePath, typeof(CommanderSetting), false);
                    CommanderScript script = LoadScript(args[0], setting, DateTime.Now);
                    CommanderFile file = new CommanderFile(setting, script);
                    var save = new Action<string>((output) =>
                    {
                        if (System.IO.File.Exists(output))
                        {
                            System.IO.File.Delete(output);
                        }
                        CommanderFile.SaveCommanderFile(output, file);
                    });

                    if (args.Length >= 2)
                    {
                        save(args[1]);
                        Console.WriteLine("保存しました");
                    }
                    else if (args.Length == 1)
                    {
                        save(Path.GetDirectoryName(Path.GetDirectoryName(args[0])) + @"\" + setting.Information.Name + ".cmder");
                        Console.WriteLine("保存しました");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType() + "\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                }
            }
            else
            {
                Console.WriteLine("書式: CommanderPack [パックしたいディレクトリのパス] [出力先のパス]");
            }
        }

        private static CommanderScript LoadScript(string directoryPath, CommanderSetting setting, DateTime updateTime)
        {
            // プロパティ、インポートの読み込み
            var loadXml = new Func<string, Type, object>((path, type) =>
            {
                return SerializableXML.ReadXMLFile((directoryPath + path), type, false);
            });

            // スクリプトオブジェクトの生成
            CommanderScript result = null;
            // 言語の判定
            string filter = null;
            switch (setting.Programming.Language)
            {
                case ProgrammingLanguage.CSharp:
                    if (setting.Programming.WithComplement)
                    {
                        result = new CSharpScriptWithComplement(setting.Information.Name,
                            (Propertys)loadXml(ScriptPropertysPath, typeof(Propertys)),
                            (CLIWithComplementImport)loadXml(ScriptImportPath, typeof(CLIWithComplementImport)),
                            updateTime);
                    }
                    else
                    {
                        result = new CSharpScript(setting.Information.Name,
                            (Import)loadXml(ScriptImportPath, typeof(Import)),
                            updateTime);
                    }
                    filter = "*.cs";
                    break;
                case ProgrammingLanguage.VB:
                    if (setting.Programming.WithComplement)
                    {
                    }
                    else
                    {
                    }
                    break;
                default:
                    // 例外
                    break;
            }
            // スクリプトファイルの読み込み
            Func<string, string> openFile = new Func<string, string>((fileName) =>
            {
                string str;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName, Encoding.UTF8))
                {
                    str = sr.ReadToEnd();
                }
                return str;
            });
            string aaa = directoryPath + @"Script\";
            foreach (string fileName in Directory.GetFiles(aaa, filter, SearchOption.AllDirectories))
            {
                result.SourceCodes[fileName.Substring((directoryPath + ScriptDirectoryPath).Length)] = openFile(fileName);
            }

            // 結果を返す
            return result;
        }
    }
}
