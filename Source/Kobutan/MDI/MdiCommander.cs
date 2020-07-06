using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Commander;

namespace Kobutan.MDI
{
    /// <summary>
    /// MDI コマンダ
    /// </summary>
    public partial class MdiCommander : UserControl
    {
        #region メンバ変数
        /// <summary>
        /// コンフィグ
        /// </summary>
        private Config.KobutanConfig m_Config;

        /// <summary>
        /// コマンダファイル
        /// </summary>
        private Dictionary<string, CommanderFile> m_CommanderFiles = new Dictionary<string, CommanderFile>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// MDI コマンダ
        /// </summary>
        /// <param name="config">コンフィグ</param>
        public MdiCommander(Config.KobutanConfig config)
        {
            // コンポーネントの初期化
            InitializeComponent();
            // 初期化
            Initialize(config);
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// コマンダの読み込み
        /// </summary>
        public void LoadCommanders()
        {
            // 現在選択中のノードを取得
            string selectNode = m_CommanderTreeView.SelectedNode != null ? m_CommanderTreeView.SelectedNode.Name : null;
            // 現在の内容をクリア
            m_CommanderFiles.Clear();
            m_CommanderTreeView.Nodes.Clear();
            m_CommanderNameTextBox.Text = "";
            m_CommanderVersionTextBox.Text = "";
            m_CommanderBaseTextBox.Text = "";
            m_CommanderProtocolTextBox.Text = "";
            m_CommanderDescriptionTextBox.Text = "";

            // コマンダフォルダ内のコマンダファイルをすべて読み込む
            var treeNodes = new Dictionary<string, TreeNode>();
            foreach (string fileName in Directory.GetFiles(m_Config.Setting.Directory.Commanders, "*.cmder"))
            {
                try
                {
                    // コマンダファイルを読み込む
                    CommanderFile commander = CommanderFile.LoadCommanderFile(fileName);
                    if (!m_CommanderFiles.ContainsKey(commander.Setting.Information.Name))
                    {
                        // そのまま追加
                        m_CommanderFiles[commander.Setting.Information.Name] = commander;
                        TreeNode node = new TreeNode(commander.Setting.Information.Name);
                        node.Name = commander.Setting.Information.Name;
                        treeNodes[commander.Setting.Information.Name] = node;
                    }
                    else
                    {
                        // エラーメッセージ
                        MessageBox.Show(@"コマンダ名が重複しているため、" + Path.GetFileName(fileName) + @"の読み込みを飛ばします。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    // エラーメッセージ
                    MessageBox.Show(Path.GetFileName(fileName) + @"を開くのに失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // 継承関係の構築
            foreach (string name in m_CommanderFiles.Keys)
            {
                string baseName = m_CommanderFiles[name].Setting.Information.BaseCommander;
                if ((baseName != null) && (baseName != ""))
                {
                    if (treeNodes.ContainsKey(baseName))
                    {
                        // 親コマンダの設定
                        m_CommanderFiles[name].BaseCommander = m_CommanderFiles[baseName];
                        // 親コマンダのノードに子ノードを追加
                        treeNodes[baseName].Nodes.Add(treeNodes[name]);
                    }
                    else
                    {
                        // エラーメッセージ
                        MessageBox.Show(name + @"の親コマンダ" + baseName + @"が読み込まれていません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // 取り除く
                        m_CommanderFiles.Remove(name);
                        treeNodes.Remove(name);
                    }
                }
            }
            // ツリービューの生成
            foreach (TreeNode node in treeNodes.Values)
            {
                // トップレベルのノードを追加
                if (node.Parent == null)
                {
                    m_CommanderTreeView.Nodes.Add(node);
                }
                node.Expand();
            }
            // ソート
            m_CommanderTreeView.Sort();
            // 前回選択されていたものを選択するようにする
            Action<TreeNodeCollection> selectNodeAction = null;
            selectNodeAction = (nodes) =>
                {
                    foreach (TreeNode node in nodes)
                    {
                        if ((selectNode != null) && (selectNode == node.Name))
                        {
                            m_CommanderTreeView.SelectedNode = node;
                        }
                        else if (node.Nodes.Count > 0)
                        {
                            selectNodeAction(node.Nodes);
                        }
                    }
                };
            selectNodeAction(m_CommanderTreeView.Nodes);
            m_CommanderTreeView.Focus();
        }

        /// <summary>
        /// シリアルポートの読み込み
        /// </summary>
        public void LoadPorts()
        {
            // 現在選択中のポート名を取得
            string portName = m_PortNameComboBox.Text;
            // ポートリストの初期化
            m_PortNameComboBox.Items.Clear();
            m_PortNameComboBox.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            // 初期化前のポート名を選択させる
            if (m_PortNameComboBox.Items.Contains(portName))
                m_PortNameComboBox.SelectedItem = portName;
            else if (m_PortNameComboBox.Items.Count > 0)
                m_PortNameComboBox.SelectedIndex = 0;
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize(Config.KobutanConfig config)
        {
            // 引数の受け渡し
            m_Config = config;          // コンフィグ

            // コマンダの読み込み
            LoadCommanders();
            // シリアルポートの読み込み
            LoadPorts();
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// アクティベートボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_ActivateButton_Click(object sender, EventArgs e)
        {
            // 選択されているものがなければ何もしない
            if (m_CommanderTreeView.SelectedNode == null)
                return;

            // コマンダのアクティベートを依頼
            ((MainForm)ParentForm.ParentForm).ActivateCommander(
                (CommanderFile)m_CommanderFiles[m_CommanderTreeView.SelectedNode.Text],
                m_InstanceNameTextBox.Text, m_PortNameComboBox.Text);
        }

        /// <summary>
        /// コマンダツリービューの選択が変更された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_CommanderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                // 選択されたコマンダの情報を反映
                CommanderFile commanderFile = (CommanderFile)m_CommanderFiles[e.Node.Text];
                m_CommanderNameTextBox.Text = commanderFile.Setting.Information.Name;
                m_CommanderVersionTextBox.Text = commanderFile.Setting.Information.Version;
                m_CommanderBaseTextBox.Text = commanderFile.Setting.Information.BaseCommander;
                m_CommanderProtocolTextBox.Text = commanderFile.Setting.Communication.Protocol;
                m_CommanderDescriptionTextBox.Text = commanderFile.Setting.Information.Description;
                m_InstanceNameTextBox.Text = e.Node.Text + "_1";
            }
            else
            {
                // 選択されていなければリセット
                m_CommanderNameTextBox.Text = "";
                m_CommanderVersionTextBox.Text = "";
                m_CommanderBaseTextBox.Text = "";
                m_CommanderProtocolTextBox.Text = "";
                m_CommanderDescriptionTextBox.Text = "";
                m_InstanceNameTextBox.Text = "";
            }
        }

        #endregion
    }
}
