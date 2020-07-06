namespace Kobutan.MDI
{
    partial class MdiInstance
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.m_DisconnectButton = new System.Windows.Forms.Button();
            this.m_ConnectButton = new System.Windows.Forms.Button();
            this.m_TreeView = new System.Windows.Forms.TreeView();
            this.m_ScreenPanel = new PikaLib.Controls.UserControlSwitchingPanel();
            this.SaveFileButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.m_BasePanel = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_TreePanel = new System.Windows.Forms.Panel();
            this.m_ScreenPanel.SuspendLayout();
            this.m_BasePanel.SuspendLayout();
            this.m_TreePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_DisconnectButton
            // 
            this.m_DisconnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_DisconnectButton.Location = new System.Drawing.Point(359, 310);
            this.m_DisconnectButton.Name = "m_DisconnectButton";
            this.m_DisconnectButton.Size = new System.Drawing.Size(100, 30);
            this.m_DisconnectButton.TabIndex = 2;
            this.m_DisconnectButton.Text = "通信終了";
            this.m_DisconnectButton.UseVisualStyleBackColor = true;
            this.m_DisconnectButton.Click += new System.EventHandler(this.m_DisconnectButton_Click);
            // 
            // m_ConnectButton
            // 
            this.m_ConnectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ConnectButton.Location = new System.Drawing.Point(253, 310);
            this.m_ConnectButton.Name = "m_ConnectButton";
            this.m_ConnectButton.Size = new System.Drawing.Size(100, 30);
            this.m_ConnectButton.TabIndex = 1;
            this.m_ConnectButton.Text = "通信開始";
            this.m_ConnectButton.UseVisualStyleBackColor = true;
            this.m_ConnectButton.Click += new System.EventHandler(this.m_ConnectButton_Click);
            // 
            // m_TreeView
            // 
            this.m_TreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_TreeView.Location = new System.Drawing.Point(0, 0);
            this.m_TreeView.Name = "m_TreeView";
            this.m_TreeView.Size = new System.Drawing.Size(148, 296);
            this.m_TreeView.TabIndex = 0;
            // 
            // m_ScreenPanel
            // 
            this.m_ScreenPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_ScreenPanel.Controls.Add(this.SaveFileButton);
            this.m_ScreenPanel.Controls.Add(this.ClearButton);
            this.m_ScreenPanel.Controls.Add(this.listBox1);
            this.m_ScreenPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ScreenPanel.Location = new System.Drawing.Point(155, 0);
            this.m_ScreenPanel.Name = "m_ScreenPanel";
            this.m_ScreenPanel.Size = new System.Drawing.Size(300, 300);
            this.m_ScreenPanel.TabIndex = 1;
            // 
            // SaveFileButton
            // 
            this.SaveFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveFileButton.Location = new System.Drawing.Point(135, 272);
            this.SaveFileButton.Name = "SaveFileButton";
            this.SaveFileButton.Size = new System.Drawing.Size(75, 23);
            this.SaveFileButton.TabIndex = 1;
            this.SaveFileButton.Text = "ファイル保存";
            this.SaveFileButton.UseVisualStyleBackColor = true;
            this.SaveFileButton.Click += new System.EventHandler(this.SaveFileButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Location = new System.Drawing.Point(218, 272);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "クリア";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(2, 1);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(291, 268);
            this.listBox1.TabIndex = 0;
            // 
            // m_BasePanel
            // 
            this.m_BasePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_BasePanel.Controls.Add(this.m_ScreenPanel);
            this.m_BasePanel.Controls.Add(this.splitter1);
            this.m_BasePanel.Controls.Add(this.m_TreePanel);
            this.m_BasePanel.Location = new System.Drawing.Point(4, 4);
            this.m_BasePanel.Name = "m_BasePanel";
            this.m_BasePanel.Size = new System.Drawing.Size(455, 300);
            this.m_BasePanel.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(152, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 300);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // m_TreePanel
            // 
            this.m_TreePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_TreePanel.Controls.Add(this.m_TreeView);
            this.m_TreePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_TreePanel.Location = new System.Drawing.Point(0, 0);
            this.m_TreePanel.Name = "m_TreePanel";
            this.m_TreePanel.Size = new System.Drawing.Size(152, 300);
            this.m_TreePanel.TabIndex = 0;
            // 
            // MdiInstance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.m_BasePanel);
            this.Controls.Add(this.m_DisconnectButton);
            this.Controls.Add(this.m_ConnectButton);
            this.Name = "MdiInstance";
            this.Size = new System.Drawing.Size(464, 345);
            this.m_ScreenPanel.ResumeLayout(false);
            this.m_BasePanel.ResumeLayout(false);
            this.m_TreePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_DisconnectButton;
        private System.Windows.Forms.Button m_ConnectButton;
        private System.Windows.Forms.TreeView m_TreeView;
        private PikaLib.Controls.UserControlSwitchingPanel m_ScreenPanel;
        private System.Windows.Forms.Panel m_BasePanel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel m_TreePanel;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button SaveFileButton;
    }
}
