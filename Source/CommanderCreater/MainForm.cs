using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PikaLib.Controls;
using PikaLib.File;
using Commander;
using Commander.Script;
using CommanderCreater.Config;

namespace CommanderCreater
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        #region メンバ変数
        /// <summary>コンフィグ</summary>
        private CommanderCreaterConfig m_Config;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// メインフォーム
        /// </summary>
        public MainForm()
        {
            // コンポーネントの初期化
            InitializeComponent();
            // バインド
            ToolBar.DataBindings.Add(new Binding("Visible", Menu_View_ToolBar, "Checked"));
            StatusBar.DataBindings.Add(new Binding("Visible", Menu_View_StatusBar, "Checked"));
        }

        #endregion

        #region オーバーライド
        /// <summary>
        /// フォームが読み込まれる際に実行される
        /// </summary>
        /// <param name="e">イベント引数</param>
        protected override void OnLoad(EventArgs e)
        {
            // コンフィグファイルの読み込み
            LoadConfig();
            // MDIフォームの初期化
            InitializeMdiForms();

            // テスト用
            try
            {
                /*
                Commander.Communication.ProtocolSpecification s = new Commander.Communication.ProtocolSpecification();
                s.ApplyDefault();
                s.FilePath = @".\ProtocolSpecifiations\Kobuki.xml";
                s.Save();
                 * */
                /*
                string commanderFileName = "KobukiSampleBase";
                string commanderPath = @".\Commanders\" + commanderFileName + @"\";
                CommanderSetting setting = (CommanderSetting)SerializableXML.ReadXMLFile(commanderPath + @"Setting.xml", typeof(CommanderSetting), false);
                Commander.Script.Propertys propertys = (Commander.Script.Propertys)SerializableXML.ReadXMLFile(commanderPath + @"Script\Propertys.xml", typeof(Commander.Script.Propertys), false);
                CommanderScript script = new CommanderScript(setting.Information.Name, propertys, setting.Import);
                Func<string, string> openFile = new Func<string, string>((fileName) =>
                {
                    string result;
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName, Encoding.UTF8))
                    {
                        result = sr.ReadToEnd();
                    }
                    return result;
                });
                script.OnActivatedCode = openFile(commanderPath + @"Script\OnActivated.py");
                script.OnDeactivatingCode = openFile(commanderPath + @"Script\OnDeactivating.py");
                script.OnConnectedCode = openFile(commanderPath + @"Script\OnConnected.py");
                script.OnDisconnectingCode = openFile(commanderPath + @"Script\OnDisconnecting.py");
                script.OnDataReceivedCode = openFile(commanderPath + @"Script\OnDataReceived.py");
                script.OnDataSendingCode = openFile(commanderPath + @"Script\OnDataSending.py");
                foreach (string fileName in System.IO.Directory.GetFiles(commanderPath + @"Script\OtherMethods\", "*.py"))
                {
                    script.SourceCodes[System.IO.Path.GetFileName(fileName)] = openFile(fileName);
                }
                CommanderFile file = new CommanderFile(setting, script);

                if (System.IO.File.Exists(@".\Commanders\" + commanderFileName + @".cmder"))
                {
                    System.IO.File.Delete(@".\Commanders\" + commanderFileName + @".cmder");
                }
                CommanderFile.SaveCommanderFile(@".\Commanders\" + commanderFileName + @".cmder", file);
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // 基底クラスのメソッドを呼び出す
            base.OnLoad(e);
        }

        /// <summary>
        /// フォームが閉じられる際に実行される
        /// </summary>
        /// <param name="e">イベント引数</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // コンフィグファイルの保存
            try
            {
                SaveConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // 基底クラスのメソッドを呼び出す
            base.OnFormClosing(e);
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// コンフィグファイルの読み込み
        /// </summary>
        private void LoadConfig()
        {
            try
            {
                // 読み込み
                m_Config = (CommanderCreaterConfig)CommanderCreaterConfig.ReadXMLFile(@"CommanderCreaterConfig.xml", typeof(CommanderCreaterConfig), false);
            }
            catch (Exception)
            {
                // 失敗した場合、初期設定を適用
                m_Config = new CommanderCreaterConfig();
                m_Config.FilePath = "CommanderCreaterConfig.xml";
                m_Config.ApplyDefault();
                m_Config.Save();
            }

            // メインフォームの初期化
            Size = m_Config.Information.MainWindow.Size;
            Location = m_Config.Information.MainWindow.Location;
            if (m_Config.Information.MainWindow.WindowState != FormWindowState.Minimized)
                WindowState = m_Config.Information.MainWindow.WindowState;
            else
                WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// コンフィグファイルの保存
        /// </summary>
        private void SaveConfig()
        {
            // メインフォームの状態を保存
            m_Config.Information.MainWindow.WindowState = WindowState;
            if (WindowState == FormWindowState.Normal)
            {
                m_Config.Information.MainWindow.Size = Size;
                m_Config.Information.MainWindow.Location = Location;
            }
            else if (WindowState == FormWindowState.Minimized)
            {
                m_Config.Information.MainWindow.WindowState = FormWindowState.Maximized;
            }

            // 保存
            try
            {
                m_Config.Save();
            }
            catch (Exception ex)
            {
                // エラーメッセージ
                MessageBox.Show("コンフィグファイルの保存に失敗しました。\r\n理由: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// MDI子フォームの初期化
        /// </summary>
        private void InitializeMdiForms()
        {
            /*
            // コマンダウィンドウ
            m_CommanderForm = CreateMdiChildForm(new MDI.MdiCommander(m_Config), @"コマンダウィンドウ");
            // インスタンスウィンドウ
            m_InstanceForm = CreateMdiChildForm(new MDI.MdiInstance(), @"インスタンスウィンドウ");
             * */
        }

        /// <summary>
        /// MDI子フォームの生成
        /// </summary>
        /// <param name="uc">子フォーム上に配置するユーザーコントロール</param>
        /// <param name="title">子フォームのタイトル</param>
        /// <returns>生成された子フォーム</returns>
        //private MdiChildForm CreateMdiChildForm(UserControl uc, string title)
        //{
            /*
            // インスタンス化とプロパティの設定
            MdiChildForm result = new MdiChildForm(uc, this);
            result.Text = title;
            result.ClientSize = uc.Size;
            uc.Dock = DockStyle.Fill;
            // 結果を返す
            return result;
             * */
        //}

        #endregion

        #region メニューバーのイベントハンドラ
        private void Menu_View_CommanderExplorer_Click(object sender, EventArgs e)
        {
            UserControl uc = new MDI.MdiCommanderExplorer();
            MdiChildForm test = new MdiChildForm(uc, this);
            uc.Dock = DockStyle.Fill;
            test.Show();
        }

        #endregion
    }
}
