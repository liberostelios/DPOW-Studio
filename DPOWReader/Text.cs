using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DPOW.Reader
{
    [Serializable]
    public class Text
    {
        private short id, stringid, fileid;
        private bool visible;
        private byte align, shadow, color, alpha, unb1;
        private float unf1;
        private Point center;
        private Point size;

        public Text()
        {
        }

        public Text(byte[] buffer)
        {
            MemoryStream stream = new MemoryStream(buffer);
            BinaryReader binfile = new BinaryReader(stream);

            id = binfile.ReadInt16();
            visible = binfile.ReadBoolean();
            unb1 = binfile.ReadByte();
            align = binfile.ReadByte();
            shadow = binfile.ReadByte();
            color = binfile.ReadByte();
            alpha = binfile.ReadByte();
            unf1 = binfile.ReadSingle();
            stringid = binfile.ReadInt16();
            fileid = binfile.ReadInt16();
            center = new Point((float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192);
            size = new Point((float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192);

            binfile.Close();
            stream.Close();
        }

        public void Write(Stream thefile)
        {
            BinaryWriter binfile = new BinaryWriter(thefile);

            binfile.Write(id);
            binfile.Write(visible);
            binfile.Write(unb1); // ????
            binfile.Write(align);
            binfile.Write(shadow);
            binfile.Write(color);
            binfile.Write(alpha);
            binfile.Write(unf1); // ????
            binfile.Write(stringid); // ????
            binfile.Write(fileid); // ????
            binfile.Write((short)(center.X * 8192));
            binfile.Write((short)(center.Y * 8192));
            binfile.Write((short)(center.Z * 8192));
            binfile.Write((short)(size.X * 8192));
            binfile.Write((short)(size.Y * 8192));
            binfile.Write((short)(size.Z * 8192));
        }

        public short ID
        {
            get
            { return id; }
        }

        public short StringID
        {
            get
            {
                return stringid;
            }
            set
            {
                stringid = value;
            }
        }

        public short FileID
        {
            get
            {
                return fileid;
            }
            set
            {
                fileid = value;
            }
        }

        public float Unf1
        {
            get
            {
                return unf1;
            }
        }

        public float Unb1
        {
            get
            {
                return unb1;
            }
        }

        public Point Position
        {
            get
            { return center; }
            set
            { center = value;  }
        }

        public Point Size
        {
            get
            { return size; }
            set
            { size = value; }
        }

        public bool Visible
        {
            get
            { return visible; }
            set
            { visible = value; }
        }

        public byte Align
        {
            get
            { return align; }
            set
            { align = value; }
        }

        public byte ShadowType
        {
            get
            { return shadow; }
            set
            { shadow = value; }
        }

        public byte ColorType
        {
            get
            { return color; }
            set
            { color = value; }
        }

        public byte Alpha
        {
            get
            { return alpha; }
            set
            { alpha = value; }
        }
    }
}
