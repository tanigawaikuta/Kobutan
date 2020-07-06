namespace Kobutan.MDI
{
    partial class MdiInstanceList
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
            this.m_DeactivateButton = new System.Windows.Forms.Button();
            this.m_ShowInstanceWindowButton = new System.Windows.Forms.Button();
            this.m_InstanceTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // m_DeactivateButton
            // 
            this.m_DeactivateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_DeactivateButton.Location = new System.Drawing.Point(173, 217);
            this.m_DeactivateButton.Name = "m_DeactivateButton";
            this.m_DeactivateButton.Size = new System.Drawing.Size(95, 30);
            this.m_DeactivateButton.TabIndex = 2;
            this.m_DeactivateButton.Text = "ディアクティベート";
            this.m_DeactivateButton.UseVisualStyleBackColor = true;
            // 
            // m_ShowInstanceWindowButton
            // 
            this.m_ShowInstanceWindowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ShowInstanceWindowButton.Location = new System.Drawing.Point(72, 217);
            this.m_ShowInstanceWindowButton.Name = "m_ShowInstanceWindowButton";
            this.m_ShowInstanceWindowButton.Size = new System.Drawing.Size(95, 30);
            this.m_ShowInstanceWindowButton.TabIndex = 1;
            this.m_ShowInstanceWindowButton.Text = "ウィンドウの表示";
            this.m_ShowInstanceWindowButton.UseVisualStyleBackColor = true;
            // 
            // m_InstanceTreeView
            // 
            this.m_InstanceTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_InstanceTreeView.Location = new System.Drawing.Point(4, 4);
            this.m_InstanceTreeView.Name = "m_InstanceTreeView";
            this.m_InstanceTreeView.Size = new System.Drawing.Size(263, 208);
            this.m_InstanceTreeView.TabIndex = 0;
            // 
            // MdiInstanceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(200, 70);
            this.Controls.Add(this.m_InstanceTreeView);
            this.Controls.Add(this.m_ShowInstanceWindowButton);
            this.Controls.Add(this.m_DeactivateButton);
            this.Name = "MdiInstanceList";
            this.Size = new System.Drawing.Size(270, 250);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_DeactivateButton;
        private System.Windows.Forms.Button m_ShowInstanceWindowButton;
        private System.Windows.Forms.TreeView m_InstanceTreeView;
    }
}
