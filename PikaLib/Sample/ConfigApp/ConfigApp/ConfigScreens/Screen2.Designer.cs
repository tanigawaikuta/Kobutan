namespace ConfigApp.ConfigScreens
{
    partial class Screen2
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
            this.m_ListBox = new System.Windows.Forms.ListBox();
            this.m_AddButton = new System.Windows.Forms.Button();
            this.m_RemoveButton = new System.Windows.Forms.Button();
            this.m_NumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_TextBox = new System.Windows.Forms.TextBox();
            this.m_CheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // m_ListBox
            // 
            this.m_ListBox.FormattingEnabled = true;
            this.m_ListBox.ItemHeight = 12;
            this.m_ListBox.Location = new System.Drawing.Point(3, 3);
            this.m_ListBox.Name = "m_ListBox";
            this.m_ListBox.Size = new System.Drawing.Size(394, 244);
            this.m_ListBox.TabIndex = 0;
            // 
            // m_AddButton
            // 
            this.m_AddButton.Location = new System.Drawing.Point(241, 293);
            this.m_AddButton.Name = "m_AddButton";
            this.m_AddButton.Size = new System.Drawing.Size(75, 23);
            this.m_AddButton.TabIndex = 1;
            this.m_AddButton.Text = "追加";
            this.m_AddButton.UseVisualStyleBackColor = true;
            this.m_AddButton.Click += new System.EventHandler(this.m_AddButton_Click);
            // 
            // m_RemoveButton
            // 
            this.m_RemoveButton.Location = new System.Drawing.Point(322, 293);
            this.m_RemoveButton.Name = "m_RemoveButton";
            this.m_RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.m_RemoveButton.TabIndex = 2;
            this.m_RemoveButton.Text = "削除";
            this.m_RemoveButton.UseVisualStyleBackColor = true;
            this.m_RemoveButton.Click += new System.EventHandler(this.m_RemoveButton_Click);
            // 
            // m_NumericUpDown
            // 
            this.m_NumericUpDown.Location = new System.Drawing.Point(3, 257);
            this.m_NumericUpDown.Name = "m_NumericUpDown";
            this.m_NumericUpDown.Size = new System.Drawing.Size(120, 19);
            this.m_NumericUpDown.TabIndex = 3;
            // 
            // m_TextBox
            // 
            this.m_TextBox.Location = new System.Drawing.Point(131, 257);
            this.m_TextBox.Name = "m_TextBox";
            this.m_TextBox.Size = new System.Drawing.Size(180, 19);
            this.m_TextBox.TabIndex = 4;
            // 
            // m_CheckBox
            // 
            this.m_CheckBox.AutoSize = true;
            this.m_CheckBox.Location = new System.Drawing.Point(317, 259);
            this.m_CheckBox.Name = "m_CheckBox";
            this.m_CheckBox.Size = new System.Drawing.Size(80, 16);
            this.m_CheckBox.TabIndex = 5;
            this.m_CheckBox.Text = "checkBox1";
            this.m_CheckBox.UseVisualStyleBackColor = true;
            // 
            // Screen2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_CheckBox);
            this.Controls.Add(this.m_TextBox);
            this.Controls.Add(this.m_NumericUpDown);
            this.Controls.Add(this.m_RemoveButton);
            this.Controls.Add(this.m_AddButton);
            this.Controls.Add(this.m_ListBox);
            this.Name = "Screen2";
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox m_ListBox;
        private System.Windows.Forms.Button m_AddButton;
        private System.Windows.Forms.Button m_RemoveButton;
        private System.Windows.Forms.NumericUpDown m_NumericUpDown;
        private System.Windows.Forms.TextBox m_TextBox;
        private System.Windows.Forms.CheckBox m_CheckBox;
    }
}
