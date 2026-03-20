using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SCBAlogger
{
    public partial class ProgressDialog : Form
    {
        public ProgressDialog()
        {
            InitializeComponent();
        }

        public void UpdateStatus(string message, int percent)
        {
            lblStatus.Text = message;
            progressBar.Value = percent;
            progressBar.Refresh();
        }
    }
}
