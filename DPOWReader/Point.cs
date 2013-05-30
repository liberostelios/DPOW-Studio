using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace DPOW.Reader
{
    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    [Serializable]
    public class Point
    {
        private float x, y, z, u, v;
        private Color gradient;

        public Point()
        {
            x = 0;
            y = 0;
            z = 0;

            gradient = Color.FromArgb(255, Color.White);
        }

        public Point(float X, float Y, float Z)
        {
            x = X;
            y = Y;
            z = Z;

            gradient = Color.FromArgb(255, Color.White);
        }

        public Point(float X, float Y, float Z, float U, float V)
        {
            x = X;
            y = Y;
            z = Z;
            u = U;
            v = V;

            gradient = Color.FromArgb(255, Color.White);
        }

        public Point(float X, float Y, float Z, float U, float V, Color color)
        {
            x = X;
            y = Y;
            z = Z;
            u = U;
            v = V;
            gradient = color;
        }


        public Point Clone()
        {
            return (Point)MemberwiseClone();
        }

        public float X
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

        public float Y
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

        public float Z
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

        public float U
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

        public float V
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

        public Color Color
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
}
