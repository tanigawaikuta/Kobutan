namespace ConfigApp
{
    partial class MainForm
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.m_ConfigScreenPanel = new PikaLib.Controls.UserControlSwitchingPanel();
            this.m_TreeView = new System.Windows.Forms.TreeView();
            this.m_OKButton = new System.Windows.Forms.Button();
            this.m_CancelButton = new System.Windows.Forms.Button();
            this.m_ApplyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_ConfigScreenPanel
            // 
            this.m_ConfigScreenPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_ConfigScreenPanel.Location = new System.Drawing.Point(180, 3);
            this.m_ConfigScreenPanel.Name = "m_ConfigScreenPanel";
            this.m_ConfigScreenPanel.Size = new System.Drawing.Size(400, 320);
            this.m_ConfigScreenPanel.TabIndex = 1;
            // 
            // m_TreeView
            // 
            this.m_TreeView.Location = new System.Drawing.Point(3, 3);
            this.m_TreeView.Name = "m_TreeView";
            this.m_TreeView.Size = new System.Drawing.Size(170, 320);
            this.m_TreeView.TabIndex = 0;
            this.m_TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_TreeView_AfterSelect);
            // 
            // m_OKButton
            // 
            this.m_OKButton.Location = new System.Drawing.Point(343, 329);
            this.m_OKButton.Name = "m_OKButton";
            this.m_OKButton.Size = new System.Drawing.Size(75, 28);
            this.m_OKButton.TabIndex = 2;
            this.m_OKButton.Text = "OK";
            this.m_OKButton.UseVisualStyleBackColor = true;
            this.m_OKButton.Click += new System.EventHandler(this.m_OKButton_Click);
            // 
            // m_CancelButton
            // 
            this.m_CancelButton.Location = new System.Drawing.Point(424, 329);
            this.m_CancelButton.Name = "m_CancelButton";
            this.m_CancelButton.Size = new System.Drawing.Size(75, 28);
            this.m_CancelButton.TabIndex = 3;
            this.m_CancelButton.Text = "キャンセル";
            this.m_CancelButton.UseVisualStyleBackColor = true;
            this.m_CancelButton.Click += new System.EventHandler(this.m_CancelButton_Click);
            // 
            // m_ApplyButton
            // 
            this.m_ApplyButton.Enabled = false;
            this.m_ApplyButton.Location = new System.Drawing.Point(505, 329);
            this.m_ApplyButton.Name = "m_ApplyButton";
            this.m_ApplyButton.Size = new System.Drawing.Size(75, 28);
            this.m_ApplyButton.TabIndex = 4;
            this.m_ApplyButton.Text = "適用(&A)";
            this.m_ApplyButton.UseVisualStyleBackColor = true;
            this.m_ApplyButton.Click += new System.EventHandler(this.m_ApplyButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.m_ApplyButton);
            this.Controls.Add(this.m_CancelButton);
            this.Controls.Add(this.m_OKButton);
            this.Controls.Add(this.m_TreeView);
            this.Controls.Add(this.m_ConfigScreenPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ConfigApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private PikaLib.Controls.UserControlSwitchingPanel m_ConfigScreenPanel;
        private System.Windows.Forms.TreeView m_TreeView;
        private System.Windows.Forms.Button m_OKButton;
        private System.Windows.Forms.Button m_CancelButton;
        private System.Windows.Forms.Button m_ApplyButton;
    }
}

