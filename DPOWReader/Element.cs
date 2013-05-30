using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DPOW.Reader
{
    [Serializable]
    public class Element
    {
        private Image[] images;
        private Text[] texts;
        private Icon[] icons;
        private Point position;

        public Element()
        {
            images = new Image[0];
            texts = new Text[0];
            icons = new Icon[0];

            position = new Point();
        }

        public Element(Stream thefile)
        {
            BinaryReader binfile = new BinaryReader(thefile);

            images = new Image[binfile.ReadInt16()];
            texts = new Text[binfile.ReadInt16()];
            icons = new Icon[binfile.ReadInt16()];

            Position = new Point((float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192, (float)binfile.ReadInt16() / 8192);

            int texoff = binfile.ReadInt32();
            int stroff = binfile.ReadInt32();
            int flagoff = binfile.ReadInt32();

            //Loading Images
            for (int j = 0; j < images.Length; j++)
            {
                thefile.Seek(texoff + j * 4, SeekOrigin.Begin);
                thefile.Seek(binfile.ReadInt32(), SeekOrigin.Begin);

                images[j] = new Image(thefile);
            }

            //Loading Texts
            thefile.Seek(stroff, SeekOrigin.Begin);
            for (int j = 0; j < texts.Length; j++)
            {
                texts[j] = new Text(binfile.ReadBytes(28));
            }

            //Loading Icons
            thefile.Seek(flagoff, SeekOrigin.Begin);
            for (int j = 0; j < icons.Length; j++)
            {
                icons[j] = new Icon(binfile.ReadBytes(20));
            }
        }

        public void Write(Stream thefile)
        {
            BinaryWriter binfile = new BinaryWriter(thefile);

            // Write subitems count
            binfile.Write((short)images.Length);
            binfile.Write((short)texts.Length);
            binfile.Write((short)icons.Length);

            // Write position
            binfile.Write((short)(position.X * 8192));
            binfile.Write((short)(position.Y * 8192));
            binfile.Write((short)(position.Z * 8192));

            int texoff;
            int stroff;
            int flagoff;
            int smallhead = (int)thefile.Position;
            thefile.Seek(12, SeekOrigin.Current);

            //Loading Images
            texoff = (int)thefile.Position;
            if (images.Length == 0)
                texoff = 0;
            int tmpoff = texoff + images.Length * 4;
            for (int j = 0; j < images.Length; j++)
            {
                thefile.Seek(texoff + j * 4, SeekOrigin.Begin);
                binfile.Write(tmpoff);
                thefile.Seek(tmpoff, SeekOrigin.Begin);

                images[j].Write(thefile);

                tmpoff = (int)thefile.Position;
            }

            //Loading Texts
            stroff = (int)thefile.Position;
            if (texts.Length == 0)
                stroff = 0;
            for (int j = 0; j < texts.Length; j++)
            {
                texts[j].Write(thefile);
            }

            //Loading Icons
            flagoff = (int)thefile.Position;
            if (icons.Length == 0)
                flagoff = 0;
            for (int j = 0; j < icons.Length; j++)
            {
                icons[j].Write(thefile);
            }
            tmpoff = (int)thefile.Position;

            // Go back and write the small header
            thefile.Seek(smallhead, SeekOrigin.Begin);
            binfile.Write(texoff);
            binfile.Write(stroff);
            binfile.Write(flagoff);

            // Revert cursor to the end of element
            thefile.Seek(tmpoff, SeekOrigin.Begin);
        }

        public Element Clone()
        {
            return (Element)MemberwiseClone();
        }

        public Image[] Images
        {
            get
            {
                return images;
            }
            set
            {
                images = value;
            }
        }

        public Text[] Texts
        {
            get
            {
                return texts;
            }
            set
            {
                texts = value;
            }
        }

        public Icon[] Icons
        {
            get
            {
                return icons;
            }
            set
            {
                icons = value;
            }
        }
        
        public void addImage(Image newimage)
        {
            List<Image> temp = new List<Image>(images);
            temp.Add(newimage);
            images = temp.ToArray();
        }

        public void addText(Text newtext)
        {
            List<Text> temp = new List<Text>(texts);
            temp.Add(newtext);
            texts = temp.ToArray();
        }

        public void addIcon(Icon newicon)
        {
            List<Icon> temp = new List<Icon>(icons);
            temp.Add(newicon);
            icons = temp.ToArray();
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
    }
}
