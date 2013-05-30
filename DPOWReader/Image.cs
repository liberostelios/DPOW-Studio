using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace DPOW.Reader
{
    [Serializable]
    public class Image
    {
        private bool visible;
        private bool gradient;
        private int texid;
        private byte unb1;
        private Color color;
        private Point center;
        private Point[] points;

        public Image()
        {
            center = new Point();
            points = new Point[4];
            points[0] = new Point(-0.25f,0.25f,0.0f,0.0f,1.0f);
            points[1] = new Point(-0.25f, -0.25f, 0.0f, 0.0f, 0.0f);
            points[2] = new Point(0.25f, 0.25f, 0.0f, 1.0f, 1.0f);
            points[3] = new Point(0.25f, -0.25f, 0.0f, 1.0f, 0.0f);
            color = Color.FromArgb(255, 255, 255, 255);
            visible = true;
        }

        public Image(Stream thefile)
        {
            BinaryReader binfile = new BinaryReader(thefile);

            visible = binfile.ReadBoolean();
            unb1 = binfile.ReadByte();
            gradient = binfile.ReadBoolean();
            texid = (int)binfile.ReadByte();

            int rr = (int)binfile.ReadByte();
            int rg = (int)binfile.ReadByte();
            int rb = (int)binfile.ReadByte();
            int ra = (int)binfile.ReadByte();
            color = Color.FromArgb(ra, rr, rg, rb);

            center = new Point ((float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192);

            points = new Point[binfile.ReadInt16()];

            int tempoff1 = binfile.ReadInt32();
            int tempoff2 = binfile.ReadInt32();
            int tempoff3 = 0;
            if (gradient)
                tempoff3 = binfile.ReadInt32();

            thefile.Seek(tempoff1, SeekOrigin.Begin);
            for (int k = 0; k < points.Length; k++)
            {
                points[k] = new Point((float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192);
            }

            thefile.Seek(tempoff2, SeekOrigin.Begin);
            for (int k = 0; k < points.Length; k++)
            {
                points[k].U = (float)binfile.ReadInt16() / 4096;
                points[k].V = (float)binfile.ReadInt16() / 4096;
            }

            if (gradient)
            {
                thefile.Seek(tempoff3, SeekOrigin.Begin);
                for (int k = 0; k < points.Length; k++)
                {
                    rr = (int)binfile.ReadByte();
                    rg = (int)binfile.ReadByte();
                    rb = (int)binfile.ReadByte();
                    ra = (int)binfile.ReadByte();

                    points[k].Color = Color.FromArgb(ra, rr, rg, rb);
                }
            }
            else
            {
                for (int k = 0; k < points.Length; k++)
                {
                    points[k].Color = Color.White;
                }
            }
        }

        public void Write(Stream thefile)
        {
            BinaryWriter binfile = new BinaryWriter(thefile);

            binfile.Write(visible);
            binfile.Write(unb1); // ????
            binfile.Write(gradient);
            binfile.Write((byte)texid);

            binfile.Write(color.R);
            binfile.Write(color.G);
            binfile.Write(color.B);
            binfile.Write(color.A);

            binfile.Write((short)(center.X * 8192));
            binfile.Write((short)(center.Y * 8192));
            binfile.Write((short)(center.Z * 8192));

            binfile.Write((short)points.Length);

            int offset = (int)thefile.Position + 8;
            if (gradient)
                offset += 4;
            binfile.Write(offset);
            binfile.Write(offset + points.Length * 6);
            if (gradient)
                binfile.Write(offset + points.Length * 10);

            for (int k = 0; k < points.Length; k++)
            {
                binfile.Write((short)(points[k].X * 8192));
                binfile.Write((short)(points[k].Y * 8192));
                binfile.Write((short)(points[k].Z * 8192));
            }

            for (int k = 0; k < points.Length; k++)
            {
                binfile.Write((short)(points[k].U * 4096));
                binfile.Write((short)(points[k].V * 4096));
            }

            if (gradient)
            {
                for (int k = 0; k < points.Length; k++)
                {
                    binfile.Write(points[k].Color.R);
                    binfile.Write(points[k].Color.G);
                    binfile.Write(points[k].Color.B);
                    binfile.Write(points[k].Color.A);
                }
            }
        }

        public Color Color
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

        public Point Position
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

        public Point[] Points
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

        public void Scale(float factorX, float factorY)
        {
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X *= factorX;
                points[i].Y *= factorY;
            }
        }

        public void FlipHorizontal()
        {
            if (points.Length == 4)
            {
                points[0].U = points[2].U;
                points[2].U = points[1].U;
                points[1].U = points[0].U;
                points[3].U = points[2].U;
            }
        }

        public void FlipVertical()
        {
            if (points.Length == 4)
            {
                points[0].V = points[1].V;
                points[1].V = points[2].V;
                points[2].V = points[0].V;
                points[3].V = points[1].V;
            }
        }
    }
}
