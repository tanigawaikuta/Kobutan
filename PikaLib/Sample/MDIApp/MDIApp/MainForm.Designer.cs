namespace MDIApp
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.Menu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_View_MDI1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_View_MDI2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_View_MDI3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File,
            this.Menu_View});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 26);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // Menu_File
            // 
            this.Menu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File_Exit});
            this.Menu_File.Name = "Menu_File";
            this.Menu_File.Size = new System.Drawing.Size(85, 22);
            this.Menu_File.Text = "ファイル(&F)";
            // 
            // Menu_File_Exit
            // 
            this.Menu_File_Exit.Name = "Menu_File_Exit";
            this.Menu_File_Exit.Size = new System.Drawing.Size(152, 22);
            this.Menu_File_Exit.Text = "終了(&X)";
            this.Menu_File_Exit.Click += new System.EventHandler(this.Menu_File_Exit_Click);
            // 
            // Menu_View
            // 
            this.Menu_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_View_MDI1,
            this.Menu_View_MDI2,
            this.Menu_View_MDI3});
            this.Menu_View.Name = "Menu_View";
            this.Menu_View.Size = new System.Drawing.Size(62, 22);
            this.Menu_View.Text = "表示(&V)";
            // 
            // Menu_View_MDI1
            // 
            this.Menu_View_MDI1.Name = "Menu_View_MDI1";
            this.Menu_View_MDI1.Size = new System.Drawing.Size(153, 22);
            this.Menu_View_MDI1.Text = "MDIWindow1";
            this.Menu_View_MDI1.Click += new System.EventHandler(this.Menu_View_MDI1_Click);
            // 
            // Menu_View_MDI2
            // 
            this.Menu_View_MDI2.Name = "Menu_View_MDI2";
            this.Menu_View_MDI2.Size = new System.Drawing.Size(153, 22);
            this.Menu_View_MDI2.Text = "MDIWindow2";
            this.Menu_View_MDI2.Click += new System.EventHandler(this.Menu_View_MDI2_Click);
            // 
            // Menu_View_MDI3
            // 
            this.Menu_View_MDI3.Name = "Menu_View_MDI3";
            this.Menu_View_MDI3.Size = new System.Drawing.Size(153, 22);
            this.Menu_View_MDI3.Text = "MDIWindow3";
            this.Menu_View_MDI3.Click += new System.EventHandler(this.Menu_View_MDI3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.MainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "MDIApp";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem Menu_File;
        private System.Windows.Forms.ToolStripMenuItem Menu_File_Exit;
        private System.Windows.Forms.ToolStripMenuItem Menu_View;
        private System.Windows.Forms.ToolStripMenuItem Menu_View_MDI1;
        private System.Windows.Forms.ToolStripMenuItem Menu_View_MDI2;
        private System.Windows.Forms.ToolStripMenuItem Menu_View_MDI3;
    }
}

