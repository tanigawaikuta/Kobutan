namespace Kobutan.MDI
{
    partial class MdiMessage
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
            this.m_MessageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_MessageTextBox
            // 
            this.m_MessageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_MessageTextBox.Location = new System.Drawing.Point(0, 0);
            this.m_MessageTextBox.Multiline = true;
            this.m_MessageTextBox.Name = "m_MessageTextBox";
            this.m_MessageTextBox.ReadOnly = true;
            this.m_MessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_MessageTextBox.Size = new System.Drawing.Size(250, 250);
            this.m_MessageTextBox.TabIndex = 0;
            this.m_MessageTextBox.WordWrap = false;
            // 
            // MdiMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_MessageTextBox);
            this.Name = "MdiMessage";
            this.Size = new System.Drawing.Size(250, 250);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_MessageTextBox;
    }
}
