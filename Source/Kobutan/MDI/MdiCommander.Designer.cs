namespace Kobutan.MDI
{
    partial class MdiCommander
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
            this.m_ActivateButton = new System.Windows.Forms.Button();
            this.m_PortNameComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_InformationPanel = new System.Windows.Forms.Panel();
            this.m_CommanderBaseTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_CommanderProtocolTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_CommanderVersionTextBox = new System.Windows.Forms.TextBox();
            this.m_CommanderNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_CommanderDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_InstanceNameTextBox = new System.Windows.Forms.TextBox();
            this.m_CommanderPanel = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_TreePanel = new System.Windows.Forms.Panel();
            this.m_CommanderTreeView = new System.Windows.Forms.TreeView();
            this.m_InformationPanel.SuspendLayout();
            this.m_CommanderPanel.SuspendLayout();
            this.m_TreePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ActivateButton
            // 
            this.m_ActivateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ActivateButton.Location = new System.Drawing.Point(397, 309);
            this.m_ActivateButton.Name = "m_ActivateButton";
            this.m_ActivateButton.Size = new System.Drawing.Size(95, 30);
            this.m_ActivateButton.TabIndex = 3;
            this.m_ActivateButton.Text = "アクティベート";
            this.m_ActivateButton.UseVisualStyleBackColor = true;
            this.m_ActivateButton.Click += new System.EventHandler(this.m_ActivateButton_Click);
            // 
            // m_PortNameComboBox
            // 
            this.m_PortNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PortNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_PortNameComboBox.FormattingEnabled = true;
            this.m_PortNameComboBox.Location = new System.Drawing.Point(85, 283);
            this.m_PortNameComboBox.Name = "m_PortNameComboBox";
            this.m_PortNameComboBox.Size = new System.Drawing.Size(407, 20);
            this.m_PortNameComboBox.Sorted = true;
            this.m_PortNameComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "ポート名 :";
            // 
            // m_InformationPanel
            // 
            this.m_InformationPanel.AutoScroll = true;
            this.m_InformationPanel.AutoScrollMinSize = new System.Drawing.Size(150, 0);
            this.m_InformationPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_InformationPanel.Controls.Add(this.m_CommanderBaseTextBox);
            this.m_InformationPanel.Controls.Add(this.label6);
            this.m_InformationPanel.Controls.Add(this.m_CommanderProtocolTextBox);
            this.m_InformationPanel.Controls.Add(this.label5);
            this.m_InformationPanel.Controls.Add(this.m_CommanderVersionTextBox);
            this.m_InformationPanel.Controls.Add(this.m_CommanderNameTextBox);
            this.m_InformationPanel.Controls.Add(this.label4);
            this.m_InformationPanel.Controls.Add(this.label3);
            this.m_InformationPanel.Controls.Add(this.label2);
            this.m_InformationPanel.Controls.Add(this.m_CommanderDescriptionTextBox);
            this.m_InformationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_InformationPanel.Location = new System.Drawing.Point(143, 0);
            this.m_InformationPanel.Name = "m_InformationPanel";
            this.m_InformationPanel.Size = new System.Drawing.Size(351, 247);
            this.m_InformationPanel.TabIndex = 1;
            // 
            // m_CommanderBaseTextBox
            // 
            this.m_CommanderBaseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CommanderBaseTextBox.Location = new System.Drawing.Point(70, 59);
            this.m_CommanderBaseTextBox.Name = "m_CommanderBaseTextBox";
            this.m_CommanderBaseTextBox.ReadOnly = true;
            this.m_CommanderBaseTextBox.Size = new System.Drawing.Size(274, 19);
            this.m_CommanderBaseTextBox.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "親コマンダ :";
            // 
            // m_CommanderProtocolTextBox
            // 
            this.m_CommanderProtocolTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CommanderProtocolTextBox.Location = new System.Drawing.Point(70, 84);
            this.m_CommanderProtocolTextBox.Name = "m_CommanderProtocolTextBox";
            this.m_CommanderProtocolTextBox.ReadOnly = true;
            this.m_CommanderProtocolTextBox.Size = new System.Drawing.Size(274, 19);
            this.m_CommanderProtocolTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "プロトコル :";
            // 
            // m_CommanderVersionTextBox
            // 
            this.m_CommanderVersionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CommanderVersionTextBox.Location = new System.Drawing.Point(70, 34);
            this.m_CommanderVersionTextBox.Name = "m_CommanderVersionTextBox";
            this.m_CommanderVersionTextBox.ReadOnly = true;
            this.m_CommanderVersionTextBox.Size = new System.Drawing.Size(274, 19);
            this.m_CommanderVersionTextBox.TabIndex = 1;
            // 
            // m_CommanderNameTextBox
            // 
            this.m_CommanderNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CommanderNameTextBox.Location = new System.Drawing.Point(70, 8);
            this.m_CommanderNameTextBox.Name = "m_CommanderNameTextBox";
            this.m_CommanderNameTextBox.ReadOnly = true;
            this.m_CommanderNameTextBox.Size = new System.Drawing.Size(274, 19);
            this.m_CommanderNameTextBox.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "バージョン :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "コマンダ名 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "説明 :";
            // 
            // m_CommanderDescriptionTextBox
            // 
            this.m_CommanderDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CommanderDescriptionTextBox.Location = new System.Drawing.Point(4, 128);
            this.m_CommanderDescriptionTextBox.Multiline = true;
            this.m_CommanderDescriptionTextBox.Name = "m_CommanderDescriptionTextBox";
            this.m_CommanderDescriptionTextBox.ReadOnly = true;
            this.m_CommanderDescriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_CommanderDescriptionTextBox.Size = new System.Drawing.Size(340, 112);
            this.m_CommanderDescriptionTextBox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "インスタンス名 :";
            // 
            // m_InstanceNameTextBox
            // 
            this.m_InstanceNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_InstanceNameTextBox.Location = new System.Drawing.Point(85, 257);
            this.m_InstanceNameTextBox.Name = "m_InstanceNameTextBox";
            this.m_InstanceNameTextBox.Size = new System.Drawing.Size(407, 19);
            this.m_InstanceNameTextBox.TabIndex = 1;
            // 
            // m_CommanderPanel
            // 
            this.m_CommanderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CommanderPanel.Controls.Add(this.m_InformationPanel);
            this.m_CommanderPanel.Controls.Add(this.splitter1);
            this.m_CommanderPanel.Controls.Add(this.m_TreePanel);
            this.m_CommanderPanel.Location = new System.Drawing.Point(3, 3);
            this.m_CommanderPanel.Name = "m_CommanderPanel";
            this.m_CommanderPanel.Size = new System.Drawing.Size(494, 247);
            this.m_CommanderPanel.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(140, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 247);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // m_TreePanel
            // 
            this.m_TreePanel.AutoScroll = true;
            this.m_TreePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_TreePanel.Controls.Add(this.m_CommanderTreeView);
            this.m_TreePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_TreePanel.Location = new System.Drawing.Point(0, 0);
            this.m_TreePanel.Name = "m_TreePanel";
            this.m_TreePanel.Size = new System.Drawing.Size(140, 247);
            this.m_TreePanel.TabIndex = 0;
            // 
            // m_CommanderTreeView
            // 
            this.m_CommanderTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_CommanderTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_CommanderTreeView.HideSelection = false;
            this.m_CommanderTreeView.Location = new System.Drawing.Point(0, 0);
            this.m_CommanderTreeView.Name = "m_CommanderTreeView";
            this.m_CommanderTreeView.Size = new System.Drawing.Size(136, 243);
            this.m_CommanderTreeView.TabIndex = 0;
            this.m_CommanderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_CommanderTreeView_AfterSelect);
            // 
            // MdiCommander
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(210, 270);
            this.Controls.Add(this.m_ActivateButton);
            this.Controls.Add(this.m_PortNameComboBox);
            this.Controls.Add(this.m_CommanderPanel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_InstanceNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "MdiCommander";
            this.Size = new System.Drawing.Size(500, 345);
            this.m_InformationPanel.ResumeLayout(false);
            this.m_InformationPanel.PerformLayout();
            this.m_CommanderPanel.ResumeLayout(false);
            this.m_TreePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_ActivateButton;
        private System.Windows.Forms.ComboBox m_PortNameComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel m_InformationPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_CommanderDescriptionTextBox;
        private System.Windows.Forms.TextBox m_CommanderVersionTextBox;
        private System.Windows.Forms.TextBox m_CommanderNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_CommanderBaseTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox m_CommanderProtocolTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox m_InstanceNameTextBox;
        private System.Windows.Forms.Panel m_CommanderPanel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView m_CommanderTreeView;
        private System.Windows.Forms.Panel m_TreePanel;
    }
}
