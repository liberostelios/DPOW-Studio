using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DPOWEditor
{
    public partial class frmTextDialog : Form
    {
        public frmTextDialog(string Title, string LabelText)
        {
            InitializeComponent();

            this.Text = Title;
            lblMainLabel.Text = LabelText;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
