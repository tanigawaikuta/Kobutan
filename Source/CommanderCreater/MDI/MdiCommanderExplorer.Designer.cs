namespace CommanderCreater.MDI
{
    partial class MdiCommanderExplorer
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
            this.BasePanel = new System.Windows.Forms.Panel();
            this.m_TreeView = new System.Windows.Forms.TreeView();
            this.m_TreePanel = new System.Windows.Forms.Panel();
            this.BasePanel.SuspendLayout();
            this.m_TreePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BasePanel
            // 
            this.BasePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BasePanel.Controls.Add(this.m_TreePanel);
            this.BasePanel.Location = new System.Drawing.Point(3, 3);
            this.BasePanel.Name = "BasePanel";
            this.BasePanel.Size = new System.Drawing.Size(198, 257);
            this.BasePanel.TabIndex = 0;
            // 
            // m_TreeView
            // 
            this.m_TreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_TreeView.Location = new System.Drawing.Point(0, 0);
            this.m_TreeView.Name = "m_TreeView";
            this.m_TreeView.Size = new System.Drawing.Size(194, 253);
            this.m_TreeView.TabIndex = 0;
            // 
            // m_TreePanel
            // 
            this.m_TreePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_TreePanel.Controls.Add(this.m_TreeView);
            this.m_TreePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_TreePanel.Location = new System.Drawing.Point(0, 0);
            this.m_TreePanel.Name = "m_TreePanel";
            this.m_TreePanel.Size = new System.Drawing.Size(198, 257);
            this.m_TreePanel.TabIndex = 0;
            // 
            // MdiCommanderExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BasePanel);
            this.Name = "MdiCommanderExplorer";
            this.Size = new System.Drawing.Size(204, 263);
            this.BasePanel.ResumeLayout(false);
            this.m_TreePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BasePanel;
        private System.Windows.Forms.Panel m_TreePanel;
        private System.Windows.Forms.TreeView m_TreeView;
    }
}
