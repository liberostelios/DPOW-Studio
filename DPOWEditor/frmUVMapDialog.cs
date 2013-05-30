using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DPOWEditor
{
    public partial class frmUVMapDialog : Form
    {
        DPOW.Reader.Image refImage;
        string ImageName;
        System.Drawing.Image Texture;
        Point p1, p2;
        int nextPoint = 1;

        public frmUVMapDialog(DPOW.Reader.Image image, String imagename)
        {
            InitializeComponent();

            refImage = image;
            ImageName = imagename;
            this.Text = "UV Map - Texture: " + imagename;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpenImage = new OpenFileDialog();
            dlgOpenImage.Filter = "All supported files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp|PNG Files (*.png)|*.png";
            dlgOpenImage.FileName = ImageName;
            if (dlgOpenImage.ShowDialog() != DialogResult.OK)
                return;

            Texture = Image.FromFile(dlgOpenImage.FileName);
            picTexture.Image = Texture;
        }

        private void picTexture_MouseClick(object sender, MouseEventArgs e)
        {
            if (nextPoint == 1)
            {
                p1.X = e.X;
                p1.Y = e.Y;
            }
            else
            {
                p2.X = e.X;
                p2.Y = e.Y;
            }

            txtPoint1.Text = p1.X.ToString() + ", " + p1.Y.ToString();
            txtPoint2.Text = p2.X.ToString() + ", " + p2.Y.ToString();
            nextPoint = (nextPoint + 1) % 2;

            picTexture.Refresh();
        }

        private void chkScaleObject_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = chkScaleObject.Checked;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            float minU, minV, maxU, maxV;

            minU = (float)p1.X / picTexture.Width;
            minV = (float)p1.Y / picTexture.Height;
            maxU = (float)p2.X / picTexture.Width;
            maxV = (float)p2.Y / picTexture.Height;

            refImage.Points[0].U = minU;
            refImage.Points[1].U = minU;
            refImage.Points[2].U = maxU;
            refImage.Points[3].U = maxU;

            refImage.Points[0].V = maxV;
            refImage.Points[1].V = minV;
            refImage.Points[2].V = maxV;
            refImage.Points[3].V = minV;

            if (chkScaleObject.Checked)
                if (radScaleX.Checked)
                {
                    float scaleF = (maxU - minU) / (maxV - minV);
                    refImage.Scale(scaleF, 1.0f);
                }
                else
                {
                    float scaleF = (maxV - minV) / (maxU - minU);
                    refImage.Scale(1.0f, scaleF);
                }

            this.Close();
        }

        private void picTexture_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(p1.X, p1.Y, p2.X-p1.X, p2.Y-p1.Y);
            Pen pen = new Pen(Color.Crimson, 1);
            e.Graphics.DrawRectangle(pen, rect);
        }
    }
}
