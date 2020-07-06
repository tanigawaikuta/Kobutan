namespace Kobutan.SubForm
{
    partial class OptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_ApplyButton = new System.Windows.Forms.Button();
            this.m_CancelButton = new System.Windows.Forms.Button();
            this.m_OKButton = new System.Windows.Forms.Button();
            this.m_TreeView = new System.Windows.Forms.TreeView();
            this.m_ConfigScreenPanel = new PikaLib.Controls.UserControlSwitchingPanel();
            this.SuspendLayout();
            // 
            // m_ApplyButton
            // 
            this.m_ApplyButton.Enabled = false;
            this.m_ApplyButton.Location = new System.Drawing.Point(506, 330);
            this.m_ApplyButton.Name = "m_ApplyButton";
            this.m_ApplyButton.Size = new System.Drawing.Size(75, 28);
            this.m_ApplyButton.TabIndex = 9;
            this.m_ApplyButton.Text = "適用(&A)";
            this.m_ApplyButton.UseVisualStyleBackColor = true;
            // 
            // m_CancelButton
            // 
            this.m_CancelButton.Location = new System.Drawing.Point(425, 330);
            this.m_CancelButton.Name = "m_CancelButton";
            this.m_CancelButton.Size = new System.Drawing.Size(75, 28);
            this.m_CancelButton.TabIndex = 8;
            this.m_CancelButton.Text = "キャンセル";
            this.m_CancelButton.UseVisualStyleBackColor = true;
            // 
            // m_OKButton
            // 
            this.m_OKButton.Location = new System.Drawing.Point(344, 330);
            this.m_OKButton.Name = "m_OKButton";
            this.m_OKButton.Size = new System.Drawing.Size(75, 28);
            this.m_OKButton.TabIndex = 7;
            this.m_OKButton.Text = "OK";
            this.m_OKButton.UseVisualStyleBackColor = true;
            // 
            // m_TreeView
            // 
            this.m_TreeView.Location = new System.Drawing.Point(4, 4);
            this.m_TreeView.Name = "m_TreeView";
            this.m_TreeView.Size = new System.Drawing.Size(170, 320);
            this.m_TreeView.TabIndex = 5;
            // 
            // m_ConfigScreenPanel
            // 
            this.m_ConfigScreenPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_ConfigScreenPanel.Location = new System.Drawing.Point(181, 4);
            this.m_ConfigScreenPanel.Name = "m_ConfigScreenPanel";
            this.m_ConfigScreenPanel.Size = new System.Drawing.Size(400, 320);
            this.m_ConfigScreenPanel.TabIndex = 6;
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.m_ApplyButton);
            this.Controls.Add(this.m_CancelButton);
            this.Controls.Add(this.m_OKButton);
            this.Controls.Add(this.m_TreeView);
            this.Controls.Add(this.m_ConfigScreenPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "オプション";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ApplyButton;
        private System.Windows.Forms.Button m_CancelButton;
        private System.Windows.Forms.Button m_OKButton;
        private System.Windows.Forms.TreeView m_TreeView;
        private PikaLib.Controls.UserControlSwitchingPanel m_ConfigScreenPanel;
    }
}