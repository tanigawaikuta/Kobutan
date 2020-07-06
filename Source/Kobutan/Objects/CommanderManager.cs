using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Commander;

namespace Kobutan.Objects
{
    /// <summary>
    /// コマンダ管理者
    /// </summary>
    class CommanderManager
    {
        #region メンバ変数
        /// <summary>
        /// コマンダファイル
        /// </summary>
        private Dictionary<string, CommanderFile> m_CommanderFiles = new Dictionary<string, CommanderFile>();

        /// <summary>
        /// コマンダツリーノード
        /// </summary>
        private List<TreeNode> m_CommanderTreeNodes = new List<TreeNode>();

        /// <summary>
        /// コマンダインスタンス
        /// </summary>
        //private Dictionary<string, CommanderFile> m_CommanderFiles = new Dictionary<string, CommanderFile>();

        #endregion

        #region プロパティ
        /// <summary>
        /// コマンダツリーノード
        /// </summary>
        public TreeNode[] CommanderTreeNodes { get { return m_CommanderTreeNodes.ToArray(); } }

        #endregion

        #region イベント
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コマンダ管理者
        /// </summary>
        public CommanderManager()
        {
        }

        #endregion

        #region 公開メソッド
        /// <summary>
        /// コマンダの読み込み
        /// </summary>
        public void LoadCommanders(string commanderDirectoryPath)
        {
            // 現在の内容をクリア
            m_CommanderFiles.Clear();
            m_CommanderTreeNodes.Clear();

            // コマンダフォルダ内のコマンダファイルをすべて読み込む
            var treeNodes = new Dictionary<string, TreeNode>();
            foreach (string fileName in Directory.GetFiles(commanderDirectoryPath, "*.cmder"))
            {
                try
                {
                    // コマンダファイルを読み込む
                    CommanderFile commander = CommanderFile.LoadCommanderFile(fileName);
                    if (!m_CommanderFiles.ContainsKey(commander.Setting.Information.Name))
                    {
                        // そのまま追加
                        m_CommanderFiles[commander.Setting.Information.Name] = commander;
                        treeNodes[commander.Setting.Information.Name] = new TreeNode(commander.Setting.Information.Name);
                    }
                    else
                    {
                        // 重複した場合、更新日時が新しい方を読み込む
                        if (commander.UpdateTime > m_CommanderFiles[commander.Setting.Information.Name].UpdateTime)
                        {
                            m_CommanderFiles[commander.Setting.Information.Name] = commander;
                        }
                        // メッセージ
                        MessageBox.Show(@"コマンダ名が重複しているため、更新日時が新しい方を読み込みます。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // ツリーノードの保管
            foreach (TreeNode node in treeNodes.Values)
            {
                // トップレベルのノードを追加
                if (node.Parent == null)
                {
                    m_CommanderTreeNodes.Add(node);
                }
                node.Expand();
            }
            m_CommanderTreeNodes.Sort();
        }

        /// <summary>
        /// 指定された名前のコマンダを取得
        /// </summary>
        /// <param name="commanderName"></param>
        /// <returns></returns>
        public CommanderFile GetCommanderFile(string commanderName)
        {
            if (m_CommanderFiles.ContainsKey(commanderName))
            {
                return m_CommanderFiles[commanderName];
            }
            return null;
        }

        /// <summary>
        /// コマンダのアクティベート
        /// </summary>
        /// <param name="commanderName">アクティベートするコマンダ名</param>
        /// <param name="instanceName">インスタンスの名前</param>
        /// <param name="serialPortName">シリアルポートの名前</param>
        public void ActivateCommander(string commanderName, string instanceName, string serialPortName)
        {
        }

        /// <summary>
        /// コマンダのディアクティベート
        /// </summary>
        /// <param name="instanceName">ディアクティベートするインスタンス名</param>
        public void DeactivateCommander(string instanceName)
        {
        }

        #endregion
    }
}
