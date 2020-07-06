using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ionic.Zip;
using Ionic.Zlib;
using PikaLib.File;
using Commander.Script;
using Commander.Script.CLI;

namespace Commander
{
    /// <summary>
    /// コマンダファイル
    /// </summary>
    public class CommanderFile
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

        #region プロパティ
        /// <summary>
        /// ファイルパス
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// 親コマンダ
        /// </summary>
        public CommanderFile BaseCommander
        {
            get { return _BaseCommander; }
            set
            {
                _BaseCommander = value;
                if (_BaseCommander != null)
                    Script.BaseScript = _BaseCommander.Script;
            }
        }
        private CommanderFile _BaseCommander;

        /// <summary>
        /// スクリプト
        /// </summary>
        public CommanderScript Script { get; set; }

        /// <summary>
        /// 設定
        /// </summary>
        public CommanderSetting Setting { get; set; }

        /// <summary>
        /// 更新日時
        /// </summary>
        public DateTime UpdateTime { get; set; }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コマンダファイル
        /// </summary>
        public CommanderFile()
            : this(null, null)
        {
        }

        /// <summary>
        /// コマンダファイル
        /// </summary>
        /// <param name="setting">設定</param>
        /// <param name="script">スクリプト</param>
        public CommanderFile(CommanderSetting setting, CommanderScript script)
        {
            // パラメータの受け取り
            Setting = setting;
            Script = script;
            // 更新日時を現在の時刻に設定
            UpdateTime = DateTime.Now;
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            // 保存
            SaveCommanderFile(FilePath, this);
        }

        #endregion

        #region オーバーライド
        /// <summary>
        /// 現在のCommanderFileを表す文字列を返す
        /// </summary>
        /// <returns>コマンダの名前</returns>
        public override string ToString()
        {
            // コマンダの名前を返す
            return Setting.Information.Name;
        }

        #endregion

        #region 静的メソッド
        /// <summary>
        /// コマンダファイルの読み込み
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>読み込まれたコマンダファイル</returns>
        public static CommanderFile LoadCommanderFile(string filePath)
        {
            // 結果として返すためのインスタンス
            CommanderFile result = new CommanderFile();
            result.FilePath = filePath;                             // ファイルパスの設定
            result.UpdateTime = File.GetLastWriteTime(filePath);    // ファイルの更新日時を取得

            // zipファイルを開く
            ReadOptions options = new ReadOptions();
            options.Encoding = Encoding.UTF8;
            using (ZipFile zipFile = ZipFile.Read(filePath, options))
            {
                // 設定ファイルの読み込み
                using (Stream stream = zipFile[SettingFilePath].OpenReader())
                {
                    result.Setting = (CommanderSetting)SerializableXML.ReadXMLFile(stream, typeof(CommanderSetting), "", false);
                }
                // スクリプトの読み込み
                result.Script = LoadScript(zipFile, result.Setting, result.UpdateTime);
            }

            // 結果を返す
            return result;
        }

        /// <summary>
        /// コマンダファイルの保存
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="instance">保存するインスタンス</param>
        public static void SaveCommanderFile(string filePath, CommanderFile instance)
        {
            using (ZipFile zipFile = new ZipFile(filePath, Encoding.UTF8))
            {
                // 設定ファイル
                zipFile.AddEntry(SettingFilePath, instance.Setting.ToStream());
                // スクリプト
                switch (instance.Setting.Programming.Language)
                {
                    case ProgrammingLanguage.CSharp:
                        if (instance.Setting.Programming.WithComplement)
                        {
                            zipFile.AddEntry(ScriptPropertysPath, ((CSharpScriptWithComplement)instance.Script).Propertys.ToStream());
                            zipFile.AddEntry(ScriptImportPath, ((CSharpScriptWithComplement)instance.Script).Import.ToStream());
                        }
                        else
                        {
                            zipFile.AddEntry(ScriptImportPath, ((CSharpScript)instance.Script).Import.ToStream());
                        }
                        break;
                    case ProgrammingLanguage.VB:
                        break;
                    default:
                        break;
                }
                foreach (string fileName in instance.Script.SourceCodes.Keys)
                {
                    zipFile.AddEntry(ScriptDirectoryPath + fileName, instance.Script.SourceCodes[fileName], Encoding.UTF8);
                }

                // 保存
                zipFile.Save(filePath);
            }
        }

        #endregion

        #region 静的な非公開メソッド
        /// <summary>
        /// スクリプトの読み込み
        /// </summary>
        /// <param name="zipFile">ZIPファイル</param>
        /// <param name="setting">設定</param>
        /// <param name="updateTime">更新日時</param>
        /// <returns>読み込んだスクリプト</returns>
        private static CommanderScript LoadScript(ZipFile zipFile, CommanderSetting setting, DateTime updateTime)
        {
            // プロパティ、インポートの読み込み
            var loadXml = new Func<string, Type, object>((path, type) =>
            {
                using (Stream stream = zipFile[path].OpenReader())
                {
                    return SerializableXML.ReadXMLFile(stream, type, "", false);
                }
            });

            // スクリプトオブジェクトの生成
            CommanderScript result = null;
            // 言語の判定
            string extension = null;
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
                    extension = ".cs";
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
            Func<ZipEntry, string> loadScriptFile = new Func<ZipEntry, string>(
                (arg) =>
                {
                    string str = "";
                    using (Stream stream = arg.OpenReader())
                    {
                        byte[] buf = new byte[stream.Length];
                        stream.Read(buf, 0, (int)stream.Length);
                        str = Encoding.UTF8.GetString(buf);
                    }
                    return str;
                });
            foreach (ZipEntry entry in zipFile)
            {
                // スクリプトのその他メソッド
                if ((entry.FileName.IndexOf(ScriptDirectoryPath) == 0) &&
                    (Path.GetExtension(entry.FileName) == extension))
                {
                    result.SourceCodes[entry.FileName.Substring(ScriptDirectoryPath.Length)]
                        = loadScriptFile(entry);
                }
            }

            // 結果を返す
            return result;
        }

        #endregion
    }
}
