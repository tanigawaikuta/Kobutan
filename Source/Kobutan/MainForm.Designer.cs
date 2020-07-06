namespace Kobutan
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
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.Menu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Edit_LoadCommander = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Edit_LoadPorts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Edit_ActivateCommander = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Edit_DeactivateCommander = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_View_Commander = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_View_InstanceList = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_View_Message = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_View_ToolBar = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_View_StatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Tool = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Tool_DeviceManager = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Tool_CommanderCreater = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Tool_Option = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_Help_ViewHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Menu_Help_Version = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.Status_DescriptionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_Description = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolBar = new System.Windows.Forms.ToolStrip();
            this.Tool_LoadCommander = new System.Windows.Forms.ToolStripButton();
            this.Tool_LoadPorts = new System.Windows.Forms.ToolStripButton();
            this.MenuBar.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.ToolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_File,
            this.Menu_Edit,
            this.Menu_View,
            this.Menu_Tool,
            this.Menu_Help});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(784, 26);
            this.MenuBar.TabIndex = 0;
            this.MenuBar.Text = "MenuBar";
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
            this.Menu_File_Exit.Size = new System.Drawing.Size(118, 22);
            this.Menu_File_Exit.Text = "終了(&X)";
            this.Menu_File_Exit.Click += new System.EventHandler(this.Menu_File_Exit_Click);
            // 
            // Menu_Edit
            // 
            this.Menu_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Edit_LoadCommander,
            this.Menu_Edit_LoadPorts,
            this.toolStripSeparator4,
            this.Menu_Edit_ActivateCommander,
            this.Menu_Edit_DeactivateCommander});
            this.Menu_Edit.Name = "Menu_Edit";
            this.Menu_Edit.Size = new System.Drawing.Size(61, 22);
            this.Menu_Edit.Text = "編集(&E)";
            // 
            // Menu_Edit_LoadCommander
            // 
            this.Menu_Edit_LoadCommander.Name = "Menu_Edit_LoadCommander";
            this.Menu_Edit_LoadCommander.Size = new System.Drawing.Size(263, 22);
            this.Menu_Edit_LoadCommander.Text = "コマンダの再読み込み(&C)";
            this.Menu_Edit_LoadCommander.Click += new System.EventHandler(this.Menu_Edit_LoadCommander_Click);
            // 
            // Menu_Edit_LoadPorts
            // 
            this.Menu_Edit_LoadPorts.Name = "Menu_Edit_LoadPorts";
            this.Menu_Edit_LoadPorts.Size = new System.Drawing.Size(263, 22);
            this.Menu_Edit_LoadPorts.Text = "シリアルポートの再読み込み(&P)";
            this.Menu_Edit_LoadPorts.Click += new System.EventHandler(this.Menu_Edit_LoadPorts_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(260, 6);
            this.toolStripSeparator4.Visible = false;
            // 
            // Menu_Edit_ActivateCommander
            // 
            this.Menu_Edit_ActivateCommander.Name = "Menu_Edit_ActivateCommander";
            this.Menu_Edit_ActivateCommander.Size = new System.Drawing.Size(263, 22);
            this.Menu_Edit_ActivateCommander.Text = "コマンダのアクティベート(&A)";
            this.Menu_Edit_ActivateCommander.Visible = false;
            // 
            // Menu_Edit_DeactivateCommander
            // 
            this.Menu_Edit_DeactivateCommander.Name = "Menu_Edit_DeactivateCommander";
            this.Menu_Edit_DeactivateCommander.Size = new System.Drawing.Size(263, 22);
            this.Menu_Edit_DeactivateCommander.Text = "コマンダのディアクティベート(&D)";
            this.Menu_Edit_DeactivateCommander.Visible = false;
            // 
            // Menu_View
            // 
            this.Menu_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_View_Commander,
            this.Menu_View_InstanceList,
            this.Menu_View_Message,
            this.toolStripSeparator5,
            this.Menu_View_ToolBar,
            this.Menu_View_StatusBar});
            this.Menu_View.Name = "Menu_View";
            this.Menu_View.Size = new System.Drawing.Size(62, 22);
            this.Menu_View.Text = "表示(&V)";
            // 
            // Menu_View_Commander
            // 
            this.Menu_View_Commander.Name = "Menu_View_Commander";
            this.Menu_View_Commander.Size = new System.Drawing.Size(259, 22);
            this.Menu_View_Commander.Text = "コマンダウィンドウ(&C)";
            this.Menu_View_Commander.Click += new System.EventHandler(this.Menu_View_Commander_Click);
            // 
            // Menu_View_InstanceList
            // 
            this.Menu_View_InstanceList.Name = "Menu_View_InstanceList";
            this.Menu_View_InstanceList.Size = new System.Drawing.Size(259, 22);
            this.Menu_View_InstanceList.Text = "インスタンスリストウィンドウ(&I)";
            this.Menu_View_InstanceList.Click += new System.EventHandler(this.Menu_View_InstanceList_Click);
            // 
            // Menu_View_Message
            // 
            this.Menu_View_Message.Name = "Menu_View_Message";
            this.Menu_View_Message.Size = new System.Drawing.Size(259, 22);
            this.Menu_View_Message.Text = "メッセージウィンドウ(&M)";
            this.Menu_View_Message.Click += new System.EventHandler(this.Menu_View_Message_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(256, 6);
            // 
            // Menu_View_ToolBar
            // 
            this.Menu_View_ToolBar.Checked = true;
            this.Menu_View_ToolBar.CheckOnClick = true;
            this.Menu_View_ToolBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menu_View_ToolBar.Name = "Menu_View_ToolBar";
            this.Menu_View_ToolBar.Size = new System.Drawing.Size(259, 22);
            this.Menu_View_ToolBar.Text = "ツールバー(&T)";
            // 
            // Menu_View_StatusBar
            // 
            this.Menu_View_StatusBar.Checked = true;
            this.Menu_View_StatusBar.CheckOnClick = true;
            this.Menu_View_StatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Menu_View_StatusBar.Name = "Menu_View_StatusBar";
            this.Menu_View_StatusBar.Size = new System.Drawing.Size(259, 22);
            this.Menu_View_StatusBar.Text = "ステータスバー(&S)";
            // 
            // Menu_Tool
            // 
            this.Menu_Tool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Tool_DeviceManager,
            this.Menu_Tool_CommanderCreater,
            this.toolStripSeparator3,
            this.Menu_Tool_Option});
            this.Menu_Tool.Name = "Menu_Tool";
            this.Menu_Tool.Size = new System.Drawing.Size(74, 22);
            this.Menu_Tool.Text = "ツール(&T)";
            // 
            // Menu_Tool_DeviceManager
            // 
            this.Menu_Tool_DeviceManager.Name = "Menu_Tool_DeviceManager";
            this.Menu_Tool_DeviceManager.Size = new System.Drawing.Size(203, 22);
            this.Menu_Tool_DeviceManager.Text = "デバイスマネージャ(&D)";
            this.Menu_Tool_DeviceManager.Click += new System.EventHandler(this.Menu_Tool_DeviceManager_Click);
            // 
            // Menu_Tool_CommanderCreater
            // 
            this.Menu_Tool_CommanderCreater.Name = "Menu_Tool_CommanderCreater";
            this.Menu_Tool_CommanderCreater.Size = new System.Drawing.Size(203, 22);
            this.Menu_Tool_CommanderCreater.Text = "コマンダクリエータ(&C)";
            this.Menu_Tool_CommanderCreater.Visible = false;
            this.Menu_Tool_CommanderCreater.Click += new System.EventHandler(this.Menu_Tool_CommanderCreater_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(200, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // Menu_Tool_Option
            // 
            this.Menu_Tool_Option.Name = "Menu_Tool_Option";
            this.Menu_Tool_Option.Size = new System.Drawing.Size(203, 22);
            this.Menu_Tool_Option.Text = "オプション(&O)";
            this.Menu_Tool_Option.Visible = false;
            this.Menu_Tool_Option.Click += new System.EventHandler(this.Menu_Tool_Option_Click);
            // 
            // Menu_Help
            // 
            this.Menu_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Help_ViewHelp,
            this.toolStripSeparator2,
            this.Menu_Help_Version});
            this.Menu_Help.Name = "Menu_Help";
            this.Menu_Help.Size = new System.Drawing.Size(75, 22);
            this.Menu_Help.Text = "ヘルプ(&H)";
            // 
            // Menu_Help_ViewHelp
            // 
            this.Menu_Help_ViewHelp.Name = "Menu_Help_ViewHelp";
            this.Menu_Help_ViewHelp.Size = new System.Drawing.Size(178, 22);
            this.Menu_Help_ViewHelp.Text = "ヘルプの表示(&V)";
            this.Menu_Help_ViewHelp.Visible = false;
            this.Menu_Help_ViewHelp.Click += new System.EventHandler(this.Menu_Help_ViewHelp_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // Menu_Help_Version
            // 
            this.Menu_Help_Version.Name = "Menu_Help_Version";
            this.Menu_Help_Version.Size = new System.Drawing.Size(178, 22);
            this.Menu_Help_Version.Text = "バージョン情報(&A)";
            this.Menu_Help_Version.Click += new System.EventHandler(this.Menu_Help_Version_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status_DescriptionLabel,
            this.Status_Description});
            this.StatusBar.Location = new System.Drawing.Point(0, 539);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(784, 23);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "StatusStrip";
            // 
            // Status_DescriptionLabel
            // 
            this.Status_DescriptionLabel.Name = "Status_DescriptionLabel";
            this.Status_DescriptionLabel.Size = new System.Drawing.Size(0, 18);
            // 
            // Status_Description
            // 
            this.Status_Description.Name = "Status_Description";
            this.Status_Description.Size = new System.Drawing.Size(12, 18);
            this.Status_Description.Text = " ";
            // 
            // ToolBar
            // 
            this.ToolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tool_LoadCommander,
            this.Tool_LoadPorts});
            this.ToolBar.Location = new System.Drawing.Point(0, 26);
            this.ToolBar.Name = "ToolBar";
            this.ToolBar.Size = new System.Drawing.Size(784, 25);
            this.ToolBar.TabIndex = 1;
            this.ToolBar.Text = "toolStrip1";
            // 
            // Tool_LoadCommander
            // 
            this.Tool_LoadCommander.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tool_LoadCommander.Image = global::Kobutan.Properties.Resources.LoadCommander;
            this.Tool_LoadCommander.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tool_LoadCommander.Name = "Tool_LoadCommander";
            this.Tool_LoadCommander.Size = new System.Drawing.Size(23, 22);
            this.Tool_LoadCommander.Text = "toolStripButton1";
            this.Tool_LoadCommander.ToolTipText = "コマンダの再読み込み";
            this.Tool_LoadCommander.Click += new System.EventHandler(this.Menu_Edit_LoadCommander_Click);
            // 
            // Tool_LoadPorts
            // 
            this.Tool_LoadPorts.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Tool_LoadPorts.Image = global::Kobutan.Properties.Resources.LoadPorts;
            this.Tool_LoadPorts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tool_LoadPorts.Name = "Tool_LoadPorts";
            this.Tool_LoadPorts.Size = new System.Drawing.Size(23, 22);
            this.Tool_LoadPorts.Text = "toolStripButton2";
            this.Tool_LoadPorts.ToolTipText = "シリアルポートの再読み込み";
            this.Tool_LoadPorts.Click += new System.EventHandler(this.Menu_Edit_LoadPorts_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.ToolBar);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MenuBar);
            this.Icon = global::Kobutan.Properties.Resources.Kobutan;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.Text = "こぶたん";
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ToolBar.ResumeLayout(false);
            this.ToolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem Menu_File;
        private System.Windows.Forms.ToolStripMenuItem Menu_Edit;
        private System.Windows.Forms.ToolStripMenuItem Menu_View;
        private System.Windows.Forms.ToolStripMenuItem Menu_Help;
        private System.Windows.Forms.ToolStripMenuItem Menu_File_Exit;
        private System.Windows.Forms.ToolStripMenuItem Menu_Tool;
        private System.Windows.Forms.ToolStripMenuItem Menu_Tool_Option;
        private System.Windows.Forms.ToolStripMenuItem Menu_Help_Version;
        private System.Windows.Forms.ToolStripMenuItem Menu_View_Commander;
        private System.Windows.Forms.ToolStripMenuItem Menu_View_InstanceList;
        private System.Windows.Forms.ToolStripMenuItem Menu_Help_ViewHelp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Menu_Tool_DeviceManager;
        private System.Windows.Forms.ToolStripMenuItem Menu_Tool_CommanderCreater;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem Menu_Edit_LoadPorts;
        private System.Windows.Forms.ToolStripMenuItem Menu_Edit_ActivateCommander;
        private System.Windows.Forms.ToolStripMenuItem Menu_Edit_LoadCommander;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem Menu_Edit_DeactivateCommander;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel Status_DescriptionLabel;
        private System.Windows.Forms.ToolStripStatusLabel Status_Description;
        private System.Windows.Forms.ToolStrip ToolBar;
        private System.Windows.Forms.ToolStripButton Tool_LoadCommander;
        private System.Windows.Forms.ToolStripButton Tool_LoadPorts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem Menu_View_ToolBar;
        private System.Windows.Forms.ToolStripMenuItem Menu_View_StatusBar;
        private System.Windows.Forms.ToolStripMenuItem Menu_View_Message;
    }
}

