namespace CommanderCreater.MDI.MdiEditorScreens
{
    partial class ScriptEditor
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
            Sgry.Azuki.FontInfo fontInfo1 = new Sgry.Azuki.FontInfo();
            this.m_EditPanel = new System.Windows.Forms.Panel();
            this.azukiControl1 = new Sgry.Azuki.WinForms.AzukiControl();
            this.m_EditPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_EditPanel
            // 
            this.m_EditPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_EditPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_EditPanel.Controls.Add(this.azukiControl1);
            this.m_EditPanel.Location = new System.Drawing.Point(3, 3);
            this.m_EditPanel.Name = "m_EditPanel";
            this.m_EditPanel.Size = new System.Drawing.Size(480, 273);
            this.m_EditPanel.TabIndex = 0;
            // 
            // azukiControl1
            // 
            this.azukiControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(240)))));
            this.azukiControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.azukiControl1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.azukiControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.azukiControl1.DrawingOption = ((Sgry.Azuki.DrawingOption)(((((((Sgry.Azuki.DrawingOption.DrawsFullWidthSpace | Sgry.Azuki.DrawingOption.DrawsTab) 
            | Sgry.Azuki.DrawingOption.DrawsEol) 
            | Sgry.Azuki.DrawingOption.HighlightCurrentLine) 
            | Sgry.Azuki.DrawingOption.ShowsLineNumber) 
            | Sgry.Azuki.DrawingOption.ShowsDirtBar) 
            | Sgry.Azuki.DrawingOption.HighlightsMatchedBracket)));
            this.azukiControl1.FirstVisibleLine = 0;
            this.azukiControl1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            fontInfo1.Name = "MS UI Gothic";
            fontInfo1.Size = 9;
            fontInfo1.Style = System.Drawing.FontStyle.Regular;
            this.azukiControl1.FontInfo = fontInfo1;
            this.azukiControl1.ForeColor = System.Drawing.Color.Black;
            this.azukiControl1.Location = new System.Drawing.Point(0, 0);
            this.azukiControl1.Name = "azukiControl1";
            this.azukiControl1.Size = new System.Drawing.Size(476, 269);
            this.azukiControl1.TabIndex = 0;
            this.azukiControl1.Text = "azukiControl1";
            this.azukiControl1.ViewWidth = 4129;
            // 
            // ScriptEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_EditPanel);
            this.Name = "ScriptEditor";
            this.Controls.SetChildIndex(this.m_EditPanel, 0);
            this.m_EditPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_EditPanel;
        private Sgry.Azuki.WinForms.AzukiControl azukiControl1;
    }
}
