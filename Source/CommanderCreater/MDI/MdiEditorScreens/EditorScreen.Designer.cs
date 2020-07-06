namespace CommanderCreater.MDI.MdiEditorScreens
{
    partial class EditorScreen
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
            this.m_ApplyButton = new System.Windows.Forms.Button();
            this.m_CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_ApplyButton
            // 
            this.m_ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ApplyButton.Enabled = false;
            this.m_ApplyButton.Location = new System.Drawing.Point(327, 282);
            this.m_ApplyButton.Name = "m_ApplyButton";
            this.m_ApplyButton.Size = new System.Drawing.Size(75, 28);
            this.m_ApplyButton.TabIndex = 12;
            this.m_ApplyButton.Text = "適用";
            this.m_ApplyButton.UseVisualStyleBackColor = true;
            // 
            // m_CancelButton
            // 
            this.m_CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CancelButton.Location = new System.Drawing.Point(408, 282);
            this.m_CancelButton.Name = "m_CancelButton";
            this.m_CancelButton.Size = new System.Drawing.Size(75, 28);
            this.m_CancelButton.TabIndex = 11;
            this.m_CancelButton.Text = "閉じる";
            this.m_CancelButton.UseVisualStyleBackColor = true;
            // 
            // EditorScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_ApplyButton);
            this.Controls.Add(this.m_CancelButton);
            this.Name = "EditorScreen";
            this.Size = new System.Drawing.Size(486, 313);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_ApplyButton;
        private System.Windows.Forms.Button m_CancelButton;
    }
}
