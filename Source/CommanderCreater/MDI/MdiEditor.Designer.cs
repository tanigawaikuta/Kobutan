namespace CommanderCreater.MDI
{
    partial class MdiEditor
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.propertyEditor1 = new CommanderCreater.MDI.MdiEditorScreens.PropertyEditor();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.scriptEditor1 = new CommanderCreater.MDI.MdiEditorScreens.ScriptEditor();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(500, 345);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.propertyEditor1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(492, 319);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "プロパティ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // propertyEditor1
            // 
            this.propertyEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyEditor1.Location = new System.Drawing.Point(3, 3);
            this.propertyEditor1.Name = "propertyEditor1";
            this.propertyEditor1.Size = new System.Drawing.Size(486, 313);
            this.propertyEditor1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.scriptEditor1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(492, 319);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "OnDataSending";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // scriptEditor1
            // 
            this.scriptEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptEditor1.Location = new System.Drawing.Point(3, 3);
            this.scriptEditor1.Name = "scriptEditor1";
            this.scriptEditor1.Size = new System.Drawing.Size(486, 313);
            this.scriptEditor1.TabIndex = 0;
            // 
            // MdiEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "MdiEditor";
            this.Size = new System.Drawing.Size(500, 345);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private MdiEditorScreens.PropertyEditor propertyEditor1;
        private System.Windows.Forms.TabPage tabPage1;
        private MdiEditorScreens.ScriptEditor scriptEditor1;

    }
}
