using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DPOWEditor
{
    public partial class frmAddAnimationChild : Form
    {
        public DPOW.Reader.Animation[] currentAnimations;
        public int icons;
        public short icon;
        public DPOW.Reader.Animation selectedAnimation;

        public frmAddAnimationChild()
        {
            InitializeComponent();
        }

        private void frmAddAnimationChild_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < currentAnimations.Length; i++)
                cmbAnimations.Items.Add(currentAnimations[i].Name);
            cmbAnimations.SelectedIndex = 0;
            selectedAnimation = currentAnimations[0];
            numericUpDown1.Maximum = icons - 1;
            icon = -1;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbAnimations_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAnimation = currentAnimations[cmbAnimations.SelectedIndex];
        }

        private void radExisingAnimation_CheckedChanged(object sender, EventArgs e)
        {
            selectedAnimation = currentAnimations[cmbAnimations.SelectedIndex];

            cmbAnimations.Enabled = true;
            prpNewAnimation.Enabled = false;
        }

        private void radNewAnimation_CheckedChanged(object sender, EventArgs e)
        {
            if (prpNewAnimation.SelectedObject == null)
                prpNewAnimation.SelectedObject = new DPOW.Reader.Animation();

            selectedAnimation = (DPOW.Reader.Animation)prpNewAnimation.SelectedObject;

            cmbAnimations.Enabled = false;
            prpNewAnimation.Enabled = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            icon = (short)numericUpDown1.Value;
        }
    }
}
