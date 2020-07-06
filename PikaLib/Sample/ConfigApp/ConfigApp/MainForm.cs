using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConfigApp.ConfigScreens;

namespace ConfigApp
{
    /// <summary>
    /// メインフォーム
    /// </summary>
    public partial class MainForm : Form
    {
        #region メンバ変数
        /// <summary>コンフィグ</summary>
        private Config m_Config;
        /// <summary>コンフィグスクリーン</summary>
        private List<ConfigScreen> m_ConfigScreens = new List<ConfigScreen>();

        #endregion

        #region プロパティ
        /// <summary>
        /// 適用ボタンが有効かどうか
        /// </summary>
        public bool IsEnableApplyButton
        {
            get { return m_ApplyButton.Enabled; }
            set { m_ApplyButton.Enabled = value; }
        }

        #endregion

        #region コンストラクタ
        /// <summary>
        /// メインフォーム
        /// </summary>
        public MainForm()
        {
            // コンポーネントの初期化
            InitializeComponent();
        }

        #endregion

        #region 非公開メソッド
        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
            // コンフィグファイルの読み込み
            try
            {
                m_Config = (Config)PikaLib.File.SerializableXML.ReadXMLFile("Config.xml", typeof(Config), false);
            }
            catch (Exception)
            {
                // 失敗した場合、初期設定を適用
                m_Config = new Config();
                m_Config.FilePath = "Config.xml";
                m_Config.ApplyDefault();
                m_Config.Save();
            }
            // コンフィグスクリーンの生成
            CreateConfigScreens();
            // ツリービューの初期化
            InitializeTreeView();
        }

        /// <summary>
        /// コンフィグスクリーンの生成
        /// </summary>
        private void CreateConfigScreens()
        {
            // Screen1_1
            Screen1_1 s1_1 = new Screen1_1();
            s1_1.Initialize(m_Config);
            m_ConfigScreens.Add(s1_1);
            // Screen1_2
            Screen1_2 s1_2 = new Screen1_2();
            s1_2.Initialize(m_Config);
            m_ConfigScreens.Add(s1_2);
            // Screen2
            Screen2 s2 = new Screen2();
            s2.Initialize(m_Config);
            m_ConfigScreens.Add(s2);
        }

        /// <summary>
        /// ツリービューの初期化
        /// </summary>
        private void InitializeTreeView()
        {
            // ノードの作成
            TreeNode treeNodeScreen1 = new TreeNode("Screen1",
                new TreeNode[] { new TreeNode("Screen1_1"), new TreeNode("Screen1_2") });
            TreeNode treeNodeScreen2 = new TreeNode("Screen2");
            // ノードの追加
            m_TreeView.Nodes.Add(treeNodeScreen1);
            m_TreeView.Nodes.Add(treeNodeScreen2);
            // ツリービューの初期化
            m_TreeView.TopNode.Expand();
            m_TreeView.SelectedNode = treeNodeScreen1;
        }

        /// <summary>
        /// 適用
        /// </summary>
        private void Apply()
        {
            if (m_ApplyButton.Enabled)
            {
                // 適用処理
                foreach (ConfigScreen cs in m_ConfigScreens)
                {
                    // 各スクリーン内容を適用
                    cs.Apply();
                }
                // コンフィグファイルに保存
                m_Config.Save();

                // 適用ボタンの無効化
                m_ApplyButton.Enabled = false;
            }
        }

        #endregion

        #region オーバーライド
        /// <summary>
        /// フォームロード時の処理
        /// </summary>
        /// <param name="e">イベント引数</param>
        protected override void OnLoad(EventArgs e)
        {
            // 初期化処理
            Initialize();
            // 基底クラスのメソッド呼び出し
            base.OnLoad(e);
        }

        #endregion

        #region イベントハンドラ
        /// <summary>
        /// ツリービューの選択が変わった際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // ノードに応じたコンフィグスクリーンに切り替える
            if ((e.Node.Text == "Screen1") || (e.Node.Text == "Screen1_1"))
            {
                m_ConfigScreenPanel.ChangeUserContorol(m_ConfigScreens.Find((arg) => { return arg.GetType() == typeof(Screen1_1); }));
            }
            else if (e.Node.Text == "Screen1_2")
            {
                m_ConfigScreenPanel.ChangeUserContorol(m_ConfigScreens.Find((arg) => { return arg.GetType() == typeof(Screen1_2); }));
            }
            else if (e.Node.Text == "Screen2")
            {
                m_ConfigScreenPanel.ChangeUserContorol(m_ConfigScreens.Find((arg) => { return arg.GetType() == typeof(Screen2); }));
            }
        }

        /// <summary>
        /// OKボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 適用
                Apply();
                // 閉じる
                Close();
            }
            catch (Exception ex)
            {
                // エラー報告
                MessageBox.Show(ex.Message, @"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// キャンセルボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_CancelButton_Click(object sender, EventArgs e)
        {
            // 閉じる際の確認イベントを取り除く
            FormClosing -= MainForm_FormClosing;
            // 閉じる
            Close();
        }

        /// <summary>
        /// 適用ボタンが押された際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void m_ApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 適用
                Apply();
            }
            catch (Exception ex)
            {
                // エラー報告
                MessageBox.Show(ex.Message, @"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// フォームが閉じられた際のイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 変更があることを知らせる
            if (m_ApplyButton.Enabled == true)
            {
                // 確認メッセージの表示
                DialogResult result =
                    MessageBox.Show(@"変更内容があります。保存しますか？",
                    @"確認", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                // YESの場合
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // 適用
                        Apply();
                    }
                    catch (Exception ex)
                    {
                        // エラー報告と終了処理のキャンセル
                        MessageBox.Show(ex.Message, @"エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                    }
                }
                // キャンセルの場合
                else if (result == DialogResult.Cancel)
                {
                    // 終了処理のキャンセル
                    e.Cancel = true;
                }
            }
        }

        #endregion
    }
}
