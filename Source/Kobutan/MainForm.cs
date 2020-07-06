using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using PikaLib.Controls;
using PikaLib.File;
using Commander;
using Communication;
using Kobutan.Config;

namespace Kobutan
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        #region メンバ変数
        /// <summary>コンフィグ</summary>
        private KobutanConfig m_Config;
        /// <summary>プロトコル仕様</summary>
        private List<ProtocolSpecification> m_ProtocolSpecifications = new List<ProtocolSpecification>();
        /// <summary>コマンダインスタンス</summary>
        private CommanderInstance m_CommanderInstance;

        /// <summary>コマンダフォーム</summary>
        private MdiChildForm m_CommanderForm;
        /// <summary>インスタンスリストフォーム</summary>
        private MdiChildForm m_InstanceListForm;
        /// <summary>インスタンスフォーム</summary>
        private MdiChildForm m_InstanceForm;
        /// <summary>メッセージフォーム</summary>
        private MdiChildForm m_MessageForm;

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

        #region 公開メソッド
        /// <summary>
        /// コマンダのアクティベート
        /// </summary>
        /// <param name="commanderFile">アクティベートするファイル</param>
        /// <param name="instanceName">インスタンスの名前</param>
        /// <param name="serialPortName">シリアルポートの名前</param>
        public void ActivateCommander(Commander.CommanderFile commanderFile, string instanceName, string serialPortName)
        {
            try
            {
                // プロトコル仕様
                ProtocolSpecification protocol = m_ProtocolSpecifications.Find(
                    (arg) => { return arg.Information.Name == commanderFile.Setting.Communication.Protocol; });
                if (protocol == null) throw new ApplicationException("プロトコル仕様\"" + commanderFile.Setting.Communication.Protocol + "\"が見つかりませんでした");
                // シリアルポートマネージャのインスタンス化
                SerialPortManager portManager = new SerialPortManager(serialPortName,
                    protocol.SerialPortSetting.BaudRate, protocol.SerialPortSetting.Parity,
                    protocol.SerialPortSetting.DataBits, protocol.SerialPortSetting.StopBits);
                // 通信マネージャ
                CommunicationManager communicationManager = new CommunicationManager(protocol, portManager);
                // オブジェクトベースの生成
                ObjectBase objBase = new ObjectBase(communicationManager);

                // コマンダインスタンスの生成
                m_CommanderInstance = new CommanderInstance(commanderFile, objBase, portManager);
                m_CommanderInstance.OnActivated();

                MDI.MdiInstance aaa = new MDI.MdiInstance(m_CommanderInstance);
                m_InstanceForm = new MdiChildForm(aaa, this, instanceName);
                m_InstanceForm.FormClosing += new FormClosingEventHandler((sender, e) => { aaa.Disconnect(); });
                objBase.AddObject("MdiInstance", aaa);

                m_InstanceForm.Show();
                m_InstanceForm.Activate();
            }
            catch (Exception ex)
            {
                // エラーメッセージ
                MessageBox.Show("コマンダのアクティベートに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_MessageForm.Show();
                ((MDI.MdiMessage)m_MessageForm.MdiUserControl).Clear();
                ((MDI.MdiMessage)m_MessageForm.MdiUserControl).Write(ex.Message);
            }
        }

        /// <summary>
        /// コマンダのディアクティベート
        /// </summary>
        public void DeactivateCommander()
        {
            try
            {
                m_CommanderInstance.OnDeactivating();
            }
            catch (Exception ex)
            {
                // エラーメッセージ
                MessageBox.Show("コマンダのディアクティベートに失敗しました。\r\n理由: " + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            // プロトコル仕様の読み込み
            LoadProtocolSpecifications();
            // MDIフォームの初期化
            InitializeMdiForms();
            // 一時ファイルの削除
            DeleteTMPFiles(@"TMP\");

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
            SaveConfig();

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
                m_Config = (KobutanConfig)SerializableXML.ReadXMLFile(@"KobutanConfig.xml", typeof(KobutanConfig), false);
            }
            catch (Exception)
            {
                // 失敗した場合、初期設定を適用
                m_Config = new KobutanConfig();
                m_Config.FilePath = "KobutanConfig.xml";
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
        /// プロトコル仕様を読み込む
        /// </summary>
        private void LoadProtocolSpecifications()
        {
            foreach (string fileName in Directory.GetFiles(m_Config.Setting.Directory.ProtocolSpecifiations, "*.xml"))
            {
                try
                {
                    // プロトコル仕様を読み込み,リストに追加
                    m_ProtocolSpecifications.Add((ProtocolSpecification)SerializableXML.ReadXMLFile(fileName, typeof(ProtocolSpecification), false));
                }
                catch (Exception)
                {
                    // エラーメッセージ
                    MessageBox.Show(Path.GetFileName(fileName) + @"を開くのに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// MDI子フォームの初期化
        /// </summary>
        private void InitializeMdiForms()
        {
            // コマンダウィンドウ
            m_CommanderForm = new MdiChildForm(new MDI.MdiCommander(m_Config), this, @"コマンダウィンドウ");
            // インスタンスリストウィンドウ
            m_InstanceListForm = new MdiChildForm(new MDI.MdiInstanceList(m_Config), this, @"インスタンスリストウィンドウ");
            // メッセージウィンドウ
            m_MessageForm = new MdiChildForm(new MDI.MdiMessage(), this, @"メッセージウィンドウ");
            // インスタンスウィンドウ
            //m_InstanceForm = CreateMdiChildForm(new MDI.MdiInstance(), @"インスタンスウィンドウ");
        }

        /// <summary>
        /// 一時ファイルの削除
        /// </summary>
        /// <param name="TMPFolderPath">一時フォルダのパス</param>
        private void DeleteTMPFiles(string TMPFolderPath)
        {
            foreach (string fileName in Directory.GetFiles(TMPFolderPath))
            {
                try
                {
                    // 削除
                    File.Delete(fileName);
                }
                catch (Exception) { }
            }
        }

        #endregion

        #region メニューバーのイベントハンドラ
        /// <summary>
        /// 「ファイル(F)」→「終了(X)」
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_File_Exit_Click(object sender, EventArgs e)
        {
            // フォームを閉じる
            Close();
        }

        /// <summary>
        /// 「編集(E)」→「コマンダの再読み込み(C)」
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_Edit_LoadCommander_Click(object sender, EventArgs e)
        {
            // コマンダの読み込みを依頼する
            ((MDI.MdiCommander)m_CommanderForm.MdiUserControl).LoadCommanders();
        }

        /// <summary>
        /// 「編集(E)」→「シリアルポートの再読み込み(P)」
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_Edit_LoadPorts_Click(object sender, EventArgs e)
        {
            // シリアルポートの読み込みを依頼する
            ((MDI.MdiCommander)m_CommanderForm.MdiUserControl).LoadPorts();
        }

        /// <summary>
        /// 「表示(V)」→「コマンダウィンドウ(C)」
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_View_Commander_Click(object sender, EventArgs e)
        {
            // コマンダフォームの表示
            m_CommanderForm.Show();
            m_CommanderForm.Activate();
        }

        /// <summary>
        /// 「表示(V)」→「インスタンスリストウィンドウ(I)」
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_View_InstanceList_Click(object sender, EventArgs e)
        {
            // インスタンスリストウィンドウの表示
            m_InstanceListForm.Show();
            m_InstanceListForm.Activate();
        }

        /// <summary>
        /// 「表示(V)」→「メッセージウィンドウ(M)」
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_View_Message_Click(object sender, EventArgs e)
        {
            // メッセージウィンドウの表示
            m_MessageForm.Show();
            m_MessageForm.Activate();
        }

        /// <summary>
        /// 「ツール(T)」→「デバイスマネージャ(D)」
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_Tool_DeviceManager_Click(object sender, EventArgs e)
        {
            try
            {
                // デバイスマネージャの起動
                System.Diagnostics.Process.Start("devmgmt.msc");
            }
            catch (Exception ex)
            {
                // エラーメッセージ
                MessageBox.Show(ex.Message, @"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「ツール(T)」→「コマンダクリエータ(C)」
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_Tool_CommanderCreater_Click(object sender, EventArgs e)
        {
            try
            {
                // コマンダクリエータの起動
                System.Diagnostics.Process.Start("CommanderCreater.exe");
            }
            catch (Exception ex)
            {
                // エラーメッセージ
                MessageBox.Show(ex.Message, @"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「ツール(T)」→「オプション(O)」
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_Tool_Option_Click(object sender, EventArgs e)
        {
            // オプションフォームの表示
            Form form = new SubForm.OptionForm();
            form.Owner = this;
            form.ShowDialog();
        }

        /// <summary>
        /// 「ヘルプ(H)」→「ヘルプの表示(V)」
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_Help_ViewHelp_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 「ヘルプ(H)」→「バージョン情報(A)」
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void Menu_Help_Version_Click(object sender, EventArgs e)
        {
            // バージョンフォームの表示
            Form form = new SubForm.VersionForm();
            form.Owner = this;
            form.ShowDialog();
        }

        #endregion
    }
}
