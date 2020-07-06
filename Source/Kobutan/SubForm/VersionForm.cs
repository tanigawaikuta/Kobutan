using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kobutan.SubForm
{
    public partial class VersionForm : Form
    {
        public VersionForm()
        {
            InitializeComponent();
            // バージョン情報
            VersionText.Text = System.Diagnostics.FileVersionInfo.GetVersionInfo(
                System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
        }

        private void m_OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
