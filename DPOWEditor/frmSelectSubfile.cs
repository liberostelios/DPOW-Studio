using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DPOWEditor
{
    public partial class frmSelectSubfile : Form
    {
        public string[] subfiles;

        public frmSelectSubfile()
        {
            InitializeComponent();
        }

        private void frmSelectSubfile_Load(object sender, EventArgs e)
        {
            foreach (string subfile in subfiles)
                cmbSubfile.Items.Add(subfile);

            cmbSubfile.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
