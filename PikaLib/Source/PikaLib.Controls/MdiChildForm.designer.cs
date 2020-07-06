namespace PikaLib.Controls
{
    partial class MdiChildForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージリソースが破棄される場合 true、破棄されない場合は false です。</param>
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
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.m_MdiPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // m_MdiPanel
            // 
            this.m_MdiPanel.AutoScroll = true;
            this.m_MdiPanel.AutoSize = true;
            this.m_MdiPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_MdiPanel.Location = new System.Drawing.Point(0, 0);
            this.m_MdiPanel.Margin = new System.Windows.Forms.Padding(0);
            this.m_MdiPanel.Name = "m_MdiPanel";
            this.m_MdiPanel.Size = new System.Drawing.Size(284, 262);
            this.m_MdiPanel.TabIndex = 0;
            // 
            // MdiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.m_MdiPanel);
            this.Name = "MdiForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "MdiForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel m_MdiPanel;
    }
}