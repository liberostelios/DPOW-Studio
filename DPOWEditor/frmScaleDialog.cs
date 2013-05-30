using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DPOWEditor
{
    public partial class frmScaleDialog : Form
    {
        DPOW.Reader.Image refImage;

        public frmScaleDialog(DPOW.Reader.Image image)
        {
            InitializeComponent();

            refImage = image;

            txtRefPointX.Text = refImage.Position.X.ToString();
            txtRefPointY.Text = refImage.Position.Y.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            refImage.Scale((float)numScaleFactorX.Value, (float)numScaleFactorY.Value);
            this.Close();
        }
    }
}
