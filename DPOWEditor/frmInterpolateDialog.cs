using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DPOWEditor
{
    public partial class frmInterpolateDialog : Form
    {
        DPOW.Reader.DPOWObject refDpow;
        DPOW.Reader.Animation activeAnimation;

        public frmInterpolateDialog(DPOW.Reader.DPOWObject dpow)
        {
            InitializeComponent();

            refDpow = dpow;

            for (int i = 0; i < dpow.Animations.Length; i++)
                cmbAnimations.Items.Add(dpow.Animations[i].Name);
        }

        public frmInterpolateDialog(DPOW.Reader.DPOWObject dpow, DPOW.Reader.Animation animation)
        {
            InitializeComponent();

            refDpow = dpow;

            cmbAnimations.Enabled = false;
            activeAnimation = animation;

            refreshControls();
        }

        private void cmbAnimations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnimations.Text != string.Empty)
            {
                activeAnimation = refDpow.getAnimation(cmbAnimations.Text);
                refreshControls();
            }
        }

        private void refreshControls()
        {
            tmlTimeLine.SelectedAnimation = activeAnimation;

            cmbImage.Items.Clear();
            for (int i = 0; i < activeAnimation.getFrameOnTime((int)numStartFrame.Value).Element.Images.Length; i++)
                cmbImage.Items.Add("Image " + i.ToString());
            for (int i = 0; i < activeAnimation.getFrameOnTime((int)numStartFrame.Value).Element.Icons.Length; i++)
                cmbImage.Items.Add("Icon " + i.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbImage.SelectedIndex < 0)
            {
                MessageBox.Show("Cannot proceed without a selected Object!");
                return;
            }

            short StartFrame = (short)numStartFrame.Value;
            short EndFrame = (short)numEndFrame.Value;
            float t = 0;
            int ImageIndex;
            if (prtEquations.SelectedObject is ParametricImage)
                ImageIndex = cmbImage.SelectedIndex;
            else
                ImageIndex = int.Parse(cmbImage.Text.Split(' ')[1]);

            for (short frame = StartFrame; frame <= EndFrame; frame++)
            {
                if (activeAnimation.getFrameOnTime(frame, false).Time < frame)
                    activeAnimation.AddKeyFrame(frame);

                t = ((float)(frame - StartFrame)) / (EndFrame - StartFrame);
                try
                {
                    if (prtEquations.SelectedObject is ParametricImage)
                        ((ParametricImage)prtEquations.SelectedObject).ApplyToImage(activeAnimation.getFrameOnTime(frame, false).Element.Images[ImageIndex], t);
                    else
                        ((ParametricIcon)prtEquations.SelectedObject).ApplyToIcon(activeAnimation.getFrameOnTime(frame, false).Element.Icons[ImageIndex], t);
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Problem with calculation on frame " + frame.ToString() + ": " + exp.Message);
                }
            }

            tmlTimeLine.Refresh();
        }

        private void cmbImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbImage.SelectedIndex >= 0)
            {
                if (cmbImage.Text.Split(' ')[0] == "Image")
                {
                    prtEquations.SelectedObject = new ParametricImage(activeAnimation.getFrameOnTime((int)numStartFrame.Value).Element.Images[cmbImage.SelectedIndex]);
                }
                else
                {
                    int i = int.Parse(cmbImage.Text.Split(' ')[1]);
                    prtEquations.SelectedObject = new ParametricIcon(activeAnimation.getFrameOnTime((int)numStartFrame.Value).Element.Icons[i]);
                }
            }
        }

        private void numStartFrame_ValueChanged(object sender, EventArgs e)
        {
            if (numEndFrame.Value <= numStartFrame.Value)
                numEndFrame.Value = numStartFrame.Value + 1;

            numEndFrame.Minimum = numStartFrame.Value + 1;

            refreshControls();
        }

        private void numEndFrame_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tmlTimeLine_ElementSelected(int SelectedElementId)
        {
            if (cmbImage.SelectedIndex >= 0)
            {
                if (cmbImage.Text.Split(' ')[0] == "Image")
                {
                    prtEquations.SelectedObject = new ParametricImage(refDpow.Elements[SelectedElementId].Images[cmbImage.SelectedIndex]);
                }
                else
                {
                    int i = int.Parse(cmbImage.Text.Split(' ')[1]);
                    prtEquations.SelectedObject = new ParametricIcon(refDpow.Elements[SelectedElementId].Icons[i]);
                }
            }
        }
    }

    [Serializable]
    public class ParametricImage
    {
        private bool visible;
        private bool gradient;
        private int texid;
        private ParametricColor color;
        private ParametricPoint center;
        private ParametricPoint[] points;

        public ParametricImage(DPOW.Reader.Image originalImage)
        {
            color = new ParametricColor(originalImage.Color);
            center = new ParametricPoint(originalImage.Position);
            points = new ParametricPoint[originalImage.Points.Length];
            for (int i = 0; i < points.Length; i++)
                points[i] = new ParametricPoint(originalImage.Points[i]);

            visible = originalImage.Visible;
            gradient = originalImage.isGradient;
            texid = originalImage.TextureId;
        }

        public ParametricColor Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
            }
        }

        public bool isGradient
        {
            get
            {
                return gradient;
            }
            set
            {
                gradient = value;
            }
        }

        public int TextureId
        {
            get
            {
                return texid;
            }
            set
            {
                texid = value;
            }
        }

        public ParametricPoint Position
        {
            get
            {
                return center;
            }
            set
            {
                center = value;
            }
        }

        public ParametricPoint[] Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }

        public void ApplyToImage(DPOW.Reader.Image destImage, float t)
        {
            destImage.Visible = visible;
            destImage.isGradient = gradient;
            destImage.TextureId = texid;

            center.ApplyToPoint(destImage.Position, t);
            for (int i = 0; i < points.Length; i++)
            {
                points[i].ApplyToPoint(destImage.Points[i], t);
            }

            Color newColor = destImage.Color;
            color.ApplyToColor(ref newColor, t);
            destImage.Color = newColor;
        }
    }

    [Serializable]
    public class ParametricIcon
    {
        private short id, uns1;
        private bool visible;
        private byte shadow, wtf, unk1, unk2;
        private string alpha;
        private ParametricPoint position;
        private ParametricPoint size;

        public ParametricIcon(DPOW.Reader.Icon OriginalIcon)
        {
            position = new ParametricPoint(OriginalIcon.Position);
            size = new ParametricPoint(OriginalIcon.Position);
            alpha = OriginalIcon.Alpha.ToString();
            wtf = OriginalIcon.WTF;
            visible = OriginalIcon.Visible;
            shadow = OriginalIcon.ShadowType;
            unk1 = OriginalIcon.Unknown1;
            unk2 = OriginalIcon.Unknown2;
            uns1 = OriginalIcon.UnknownS1;
        }

        public void ApplyToIcon(DPOW.Reader.Icon destIcon, float t)
        {
            position.ApplyToPoint(destIcon.Position, t);
            size.ApplyToPoint(destIcon.Size, t);
            destIcon.WTF = wtf;
            destIcon.Visible = visible;
            destIcon.ShadowType = shadow;
            destIcon.Unknown1 = unk1;
            destIcon.Unknown2 = unk2;
            destIcon.UnknownS1 = uns1;

            Ciloci.Flee.ExpressionContext c = new Ciloci.Flee.ExpressionContext();
            c.Imports.AddType(typeof(Math));
            c.Variables["t"] = t;
            if (alpha != "")
                destIcon.Alpha = (byte)c.CompileGeneric<double>(alpha).Evaluate();
        }

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
            }
        }

        public byte ShadowType
        {
            get
            {
                return shadow;
            }
            set
            {
                shadow = value;
            }
        }

        public string Alpha
        {
            get
            {
                return alpha;
            }
            set
            {
                alpha = value;
            }
        }

        public byte WTF
        {
            get
            {
                return wtf;
            }
            set
            {
                wtf = value;
            }
        }

        public byte Unknown1
        {
            get
            {
                return unk1;
            }
            set
            {
                unk1 = value;
            }
        }

        public byte Unknown2
        {
            get
            {
                return unk2;
            }
            set
            {
                unk2 = value;
            }
        }

        public ParametricPoint Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        public ParametricPoint Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        public short ID
        {
            get
            {
                return id;
            }
        }

        public short UnknownS1
        {
            get
            {
                return uns1;
            }
            set
            {
                uns1 = value;
            }
        }
    }

    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    [Serializable]
    public class ParametricPoint
    {
        private string x, y, z, u, v;
        private ParametricColor gradient;

        public ParametricPoint()
        {
            x = "0";
            y = "0";
            z = "0";
            u = "0";
            v = "0";

            gradient = new ParametricColor();
        }

        public ParametricPoint(DPOW.Reader.Point originalPoint)
        {
            x = originalPoint.X.ToString();
            y = originalPoint.Y.ToString();
            z = originalPoint.Z.ToString();
            u = originalPoint.U.ToString();
            v = originalPoint.V.ToString();

            gradient = new ParametricColor(originalPoint.Color);
        }

        public void ApplyToPoint(DPOW.Reader.Point destPoint, float t)
        {
            Ciloci.Flee.ExpressionContext c = new Ciloci.Flee.ExpressionContext();
            c.Imports.AddType(typeof(Math));
            c.Variables["t"] = t;
            if (x != string.Empty)
                destPoint.X = (float)c.CompileGeneric<double>(x).Evaluate();
            if (y != string.Empty)
                destPoint.Y = (float)c.CompileGeneric<double>(y).Evaluate();
            if (z != string.Empty)
                destPoint.Z = (float)c.CompileGeneric<double>(z).Evaluate();
            if (u != string.Empty)
                destPoint.U = (float)c.CompileGeneric<double>(u).Evaluate();
            if (v != string.Empty)
                destPoint.V = (float)c.CompileGeneric<double>(v).Evaluate();

            Color newColor = destPoint.Color;
            gradient.ApplyToColor(ref newColor, t);
            destPoint.Color = newColor;
        }

        public string X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public string Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public string Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        public string U
        {
            get
            {
                return u;
            }
            set
            {
                u = value;
            }
        }

        public string V
        {
            get
            {
                return v;
            }
            set
            {
                v = value;
            }
        }

        public ParametricColor Color
        {
            get
            {
                return gradient;
            }
            set
            {
                gradient = value;
            }
        }
    }

    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    [Serializable]
    public class ParametricColor
    {
        private string r, g, b, a;

        public ParametricColor()
        {
            r = "0";
            g = "0";
            b = "0";
            a = "0";
        }

        public ParametricColor(Color originalColor)
        {
            r = originalColor.R.ToString();
            g = originalColor.G.ToString();
            b = originalColor.B.ToString();
            a = originalColor.A.ToString();
        }

        public void ApplyToColor(ref Color destColor, float t)
        {
            Ciloci.Flee.ExpressionContext c = new Ciloci.Flee.ExpressionContext();
            c.Imports.AddType(typeof(Math));
            c.Variables["t"] = t;
            int aa = destColor.A;
            if (a != string.Empty)
                aa = (int)c.CompileGeneric<double>(a).Evaluate();
            int rr = destColor.R;
            if (r != string.Empty)
                rr = (int)c.CompileGeneric<double>(r).Evaluate();
            int gg = destColor.G;
            if (g != string.Empty)
                gg = (int)c.CompileGeneric<double>(g).Evaluate();
            int bb = destColor.B;
            if (b != string.Empty)
                bb = (int)c.CompileGeneric<double>(b).Evaluate();

            destColor = Color.FromArgb(aa, rr, gg, bb);
        }

        public string R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
            }
        }

        public string G
        {
            get
            {
                return g;
            }
            set
            {
                g = value;
            }
        }

        public string B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
            }
        }

        public string A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
            }
        }
    }
}