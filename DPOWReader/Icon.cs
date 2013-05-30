using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DPOW.Reader
{
    [Serializable]
    public class Icon
    {
        private short id, uns1;
        private bool visible;
        private byte shadow, alpha, wtf, unk1, unk2;
        private Point position;
        private Point size;

        public Icon()
        {
            position = new Point();
            size = new Point();
            size.X = 0.0234375f;
            size.Y = 0.0234375f;
        }

        public Icon(byte[] buffer)
        {
            MemoryStream stream = new MemoryStream(buffer);
            BinaryReader binfile = new BinaryReader(stream);

            id = binfile.ReadInt16();
            visible = binfile.ReadBoolean();
            wtf = binfile.ReadByte();
            shadow = binfile.ReadByte();
            alpha = binfile.ReadByte();
            unk1 = binfile.ReadByte(); // ????
            unk2 = binfile.ReadByte(); // ????
            uns1 = binfile.ReadInt16(); // ????
            position = new Point((float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192);
            size = new Point((float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192, 0);

            binfile.Close();
            stream.Close();
        }

        public void Write(Stream thefile)
        {
            BinaryWriter binfile = new BinaryWriter(thefile);

            binfile.Write(id);
            binfile.Write(visible);
            binfile.Write(wtf);
            binfile.Write(shadow);
            binfile.Write(alpha);
            binfile.Write(unk1); // ????
            binfile.Write(unk2); // ????
            binfile.Write(uns1); // ????
            binfile.Write((short)(position.X * 8192));
            binfile.Write((short)(position.Y * 8192));
            binfile.Write((short)(position.Z * 8192));
            binfile.Write((short)(size.X * 8192));
            binfile.Write((short)(size.Y * 8192));
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

        public byte Alpha
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

        public Point Position
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

        public Point Size
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
}
