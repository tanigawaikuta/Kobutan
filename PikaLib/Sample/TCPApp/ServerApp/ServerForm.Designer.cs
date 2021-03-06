﻿namespace ServerApp
{
    partial class ServerForm
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
            this.m_MainMenu = new System.Windows.Forms.MenuStrip();
            this.m_MainMenu_File = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MainMenu_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_StopListenButton = new System.Windows.Forms.Button();
            this.m_StartListenButton = new System.Windows.Forms.Button();
            this.m_PortTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.m_TcpSendButton = new System.Windows.Forms.Button();
            this.m_TcpSendData8TextBox = new System.Windows.Forms.TextBox();
            this.m_TcpSendData7TextBox = new System.Windows.Forms.TextBox();
            this.m_TcpSendData6TextBox = new System.Windows.Forms.TextBox();
            this.m_TcpSendData5TextBox = new System.Windows.Forms.TextBox();
            this.m_TcpSendData4TextBox = new System.Windows.Forms.TextBox();
            this.m_TcpSendData3TextBox = new System.Windows.Forms.TextBox();
            this.m_TcpSendData2TextBox = new System.Windows.Forms.TextBox();
            this.m_TcpSendData1TextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_TcpReceiveListBox = new System.Windows.Forms.ListBox();
            this.m_MainMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_MainMenu
            // 
            this.m_MainMenu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MainMenu_File});
            this.m_MainMenu.Location = new System.Drawing.Point(0, 0);
            this.m_MainMenu.Name = "m_MainMenu";
            this.m_MainMenu.Size = new System.Drawing.Size(354, 26);
            this.m_MainMenu.TabIndex = 0;
            this.m_MainMenu.Text = "menuStrip1";
            // 
            // m_MainMenu_File
            // 
            this.m_MainMenu_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_MainMenu_File_Exit});
            this.m_MainMenu_File.Name = "m_MainMenu_File";
            this.m_MainMenu_File.Size = new System.Drawing.Size(85, 22);
            this.m_MainMenu_File.Text = "ファイル(&F)";
            // 
            // m_MainMenu_File_Exit
            // 
            this.m_MainMenu_File_Exit.Name = "m_MainMenu_File_Exit";
            this.m_MainMenu_File_Exit.Size = new System.Drawing.Size(152, 22);
            this.m_MainMenu_File_Exit.Text = "終了(&X)";
            this.m_MainMenu_File_Exit.Click += new System.EventHandler(this.m_MainMenu_File_Exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_StopListenButton);
            this.groupBox1.Controls.Add(this.m_StartListenButton);
            this.groupBox1.Controls.Add(this.m_PortTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 72);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "サーバ設定";
            // 
            // m_StopListenButton
            // 
            this.m_StopListenButton.Enabled = false;
            this.m_StopListenButton.Location = new System.Drawing.Point(259, 42);
            this.m_StopListenButton.Name = "m_StopListenButton";
            this.m_StopListenButton.Size = new System.Drawing.Size(75, 23);
            this.m_StopListenButton.TabIndex = 3;
            this.m_StopListenButton.Text = "Listen停止";
            this.m_StopListenButton.UseVisualStyleBackColor = true;
            this.m_StopListenButton.Click += new System.EventHandler(this.m_StopListenButton_Click);
            // 
            // m_StartListenButton
            // 
            this.m_StartListenButton.Location = new System.Drawing.Point(181, 42);
            this.m_StartListenButton.Name = "m_StartListenButton";
            this.m_StartListenButton.Size = new System.Drawing.Size(75, 23);
            this.m_StartListenButton.TabIndex = 2;
            this.m_StartListenButton.Text = "Listen開始";
            this.m_StartListenButton.UseVisualStyleBackColor = true;
            this.m_StartListenButton.Click += new System.EventHandler(this.m_StartListenButton_Click);
            // 
            // m_PortTextBox
            // 
            this.m_PortTextBox.Location = new System.Drawing.Point(52, 17);
            this.m_PortTextBox.Name = "m_PortTextBox";
            this.m_PortTextBox.Size = new System.Drawing.Size(282, 19);
            this.m_PortTextBox.TabIndex = 1;
            this.m_PortTextBox.Text = "2345";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ポート :";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_TcpSendButton);
            this.groupBox5.Controls.Add(this.m_TcpSendData8TextBox);
            this.groupBox5.Controls.Add(this.m_TcpSendData7TextBox);
            this.groupBox5.Controls.Add(this.m_TcpSendData6TextBox);
            this.groupBox5.Controls.Add(this.m_TcpSendData5TextBox);
            this.groupBox5.Controls.Add(this.m_TcpSendData4TextBox);
            this.groupBox5.Controls.Add(this.m_TcpSendData3TextBox);
            this.groupBox5.Controls.Add(this.m_TcpSendData2TextBox);
            this.groupBox5.Controls.Add(this.m_TcpSendData1TextBox);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.m_TcpReceiveListBox);
            this.groupBox5.Location = new System.Drawing.Point(4, 111);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(343, 149);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "TCPIP 通信テスト";
            // 
            // m_TcpSendButton
            // 
            this.m_TcpSendButton.Enabled = false;
            this.m_TcpSendButton.Location = new System.Drawing.Point(43, 118);
            this.m_TcpSendButton.Name = "m_TcpSendButton";
            this.m_TcpSendButton.Size = new System.Drawing.Size(130, 23);
            this.m_TcpSendButton.TabIndex = 9;
            this.m_TcpSendButton.Text = "クライアントに一斉送信";
            this.m_TcpSendButton.UseVisualStyleBackColor = true;
            this.m_TcpSendButton.Click += new System.EventHandler(this.m_TcpSendButton_Click);
            // 
            // m_TcpSendData8TextBox
            // 
            this.m_TcpSendData8TextBox.Location = new System.Drawing.Point(136, 66);
            this.m_TcpSendData8TextBox.MaxLength = 2;
            this.m_TcpSendData8TextBox.Name = "m_TcpSendData8TextBox";
            this.m_TcpSendData8TextBox.Size = new System.Drawing.Size(37, 19);
            this.m_TcpSendData8TextBox.TabIndex = 8;
            this.m_TcpSendData8TextBox.Text = "00";
            this.m_TcpSendData8TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendDataTextBox_KeyPress);
            // 
            // m_TcpSendData7TextBox
            // 
            this.m_TcpSendData7TextBox.Location = new System.Drawing.Point(93, 66);
            this.m_TcpSendData7TextBox.MaxLength = 2;
            this.m_TcpSendData7TextBox.Name = "m_TcpSendData7TextBox";
            this.m_TcpSendData7TextBox.Size = new System.Drawing.Size(37, 19);
            this.m_TcpSendData7TextBox.TabIndex = 7;
            this.m_TcpSendData7TextBox.Text = "00";
            this.m_TcpSendData7TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendDataTextBox_KeyPress);
            // 
            // m_TcpSendData6TextBox
            // 
            this.m_TcpSendData6TextBox.Location = new System.Drawing.Point(50, 66);
            this.m_TcpSendData6TextBox.MaxLength = 2;
            this.m_TcpSendData6TextBox.Name = "m_TcpSendData6TextBox";
            this.m_TcpSendData6TextBox.Size = new System.Drawing.Size(37, 19);
            this.m_TcpSendData6TextBox.TabIndex = 6;
            this.m_TcpSendData6TextBox.Text = "00";
            this.m_TcpSendData6TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendDataTextBox_KeyPress);
            // 
            // m_TcpSendData5TextBox
            // 
            this.m_TcpSendData5TextBox.Location = new System.Drawing.Point(7, 66);
            this.m_TcpSendData5TextBox.MaxLength = 2;
            this.m_TcpSendData5TextBox.Name = "m_TcpSendData5TextBox";
            this.m_TcpSendData5TextBox.Size = new System.Drawing.Size(37, 19);
            this.m_TcpSendData5TextBox.TabIndex = 5;
            this.m_TcpSendData5TextBox.Text = "00";
            this.m_TcpSendData5TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendDataTextBox_KeyPress);
            // 
            // m_TcpSendData4TextBox
            // 
            this.m_TcpSendData4TextBox.Location = new System.Drawing.Point(136, 41);
            this.m_TcpSendData4TextBox.MaxLength = 2;
            this.m_TcpSendData4TextBox.Name = "m_TcpSendData4TextBox";
            this.m_TcpSendData4TextBox.Size = new System.Drawing.Size(37, 19);
            this.m_TcpSendData4TextBox.TabIndex = 4;
            this.m_TcpSendData4TextBox.Text = "00";
            this.m_TcpSendData4TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendDataTextBox_KeyPress);
            // 
            // m_TcpSendData3TextBox
            // 
            this.m_TcpSendData3TextBox.Location = new System.Drawing.Point(93, 41);
            this.m_TcpSendData3TextBox.MaxLength = 2;
            this.m_TcpSendData3TextBox.Name = "m_TcpSendData3TextBox";
            this.m_TcpSendData3TextBox.Size = new System.Drawing.Size(37, 19);
            this.m_TcpSendData3TextBox.TabIndex = 3;
            this.m_TcpSendData3TextBox.Text = "00";
            this.m_TcpSendData3TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendDataTextBox_KeyPress);
            // 
            // m_TcpSendData2TextBox
            // 
            this.m_TcpSendData2TextBox.Location = new System.Drawing.Point(50, 41);
            this.m_TcpSendData2TextBox.MaxLength = 2;
            this.m_TcpSendData2TextBox.Name = "m_TcpSendData2TextBox";
            this.m_TcpSendData2TextBox.Size = new System.Drawing.Size(37, 19);
            this.m_TcpSendData2TextBox.TabIndex = 2;
            this.m_TcpSendData2TextBox.Text = "00";
            this.m_TcpSendData2TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendDataTextBox_KeyPress);
            // 
            // m_TcpSendData1TextBox
            // 
            this.m_TcpSendData1TextBox.Location = new System.Drawing.Point(7, 41);
            this.m_TcpSendData1TextBox.MaxLength = 2;
            this.m_TcpSendData1TextBox.Name = "m_TcpSendData1TextBox";
            this.m_TcpSendData1TextBox.Size = new System.Drawing.Size(37, 19);
            this.m_TcpSendData1TextBox.TabIndex = 1;
            this.m_TcpSendData1TextBox.Text = "00";
            this.m_TcpSendData1TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SendDataTextBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "送信データ (8byte 16進で指定)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "受信データ";
            // 
            // m_TcpReceiveListBox
            // 
            this.m_TcpReceiveListBox.FormattingEnabled = true;
            this.m_TcpReceiveListBox.ItemHeight = 12;
            this.m_TcpReceiveListBox.Location = new System.Drawing.Point(175, 41);
            this.m_TcpReceiveListBox.Name = "m_TcpReceiveListBox";
            this.m_TcpReceiveListBox.Size = new System.Drawing.Size(159, 100);
            this.m_TcpReceiveListBox.TabIndex = 10;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 262);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.m_MainMenu;
            this.Name = "ServerForm";
            this.Text = "ServerApp";
            this.m_MainMenu.ResumeLayout(false);
            this.m_MainMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip m_MainMenu;
        private System.Windows.Forms.ToolStripMenuItem m_MainMenu_File;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button m_StopListenButton;
        private System.Windows.Forms.Button m_StartListenButton;
        private System.Windows.Forms.TextBox m_PortTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button m_TcpSendButton;
        private System.Windows.Forms.TextBox m_TcpSendData8TextBox;
        private System.Windows.Forms.TextBox m_TcpSendData7TextBox;
        private System.Windows.Forms.TextBox m_TcpSendData6TextBox;
        private System.Windows.Forms.TextBox m_TcpSendData5TextBox;
        private System.Windows.Forms.TextBox m_TcpSendData4TextBox;
        private System.Windows.Forms.TextBox m_TcpSendData3TextBox;
        private System.Windows.Forms.TextBox m_TcpSendData2TextBox;
        private System.Windows.Forms.TextBox m_TcpSendData1TextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox m_TcpReceiveListBox;
        private System.Windows.Forms.ToolStripMenuItem m_MainMenu_File_Exit;
    }
}

