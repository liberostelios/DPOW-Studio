using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DPOW.Reader
{
    public class DPOWObject
    {
        private Animation[] animations;
        private Element[] elements;
        private Variable[] variables;
        private int[] unknowntable;
        private string[] textures;

        private string loadstring(Stream thestream)
        {
            string result;
            byte[] newchar = new byte[1];
            newchar[0] = (byte)thestream.ReadByte();
            result = "";
            while (newchar[0] != 0)
            {
                result += System.Text.Encoding.UTF8.GetString(newchar);
                newchar[0] = (byte)thestream.ReadByte();
            }
            return result;
        }

        public DPOWObject(Stream thefile)
        {
            int imageoff, elementsoff, animoff, unknownoff, eventsoff, tempoff1, tempoff2;
            int[] imageoffs;

            BinaryReader binfile = new BinaryReader(thefile);

            //Read basic block offsets
            thefile.Seek(8, SeekOrigin.Begin);
            imageoff = binfile.ReadInt32();
            elementsoff = binfile.ReadInt32();
            animoff = binfile.ReadInt32();
            unknownoff = binfile.ReadInt32();
            eventsoff = binfile.ReadInt32();

            //Read images
            thefile.Seek(imageoff, SeekOrigin.Begin);
            textures = new string[binfile.ReadInt32()];
            imageoffs = new int[textures.Length];
            thefile.Seek(binfile.ReadInt32(), SeekOrigin.Begin);
            for (int i = 0; i < textures.Length; i++)
            {
                imageoffs[i] = binfile.ReadInt32();
            }
            for (int i = 0; i < textures.Length; i++)
            {
                thefile.Seek(imageoffs[i], SeekOrigin.Begin);
                textures[i] = loadstring(thefile);
            }

            //Read elements
            thefile.Seek(elementsoff, SeekOrigin.Begin);
            Elements = new DPOW.Reader.Element[binfile.ReadInt32()];
            int[] eloffset = new int[Elements.Length];
            thefile.Seek(binfile.ReadInt32(), SeekOrigin.Begin);
            for (int i = 0; i < Elements.Length; i++)
            {
                eloffset[i] = binfile.ReadInt32();
            }

            //Fill the elements
            for (int i = 0; i < Elements.Length; i++)
            {
                thefile.Seek(eloffset[i], SeekOrigin.Begin);

                Elements[i] = new DPOW.Reader.Element(thefile);
            }

            //ANIMATIONS
            thefile.Seek(animoff, SeekOrigin.Begin);

            Animations = new DPOW.Reader.Animation[binfile.ReadInt32()];
            int[] anoffset = new int[Animations.Length];
            tempoff1 = binfile.ReadInt32();
            tempoff2 = binfile.ReadInt32();

            thefile.Seek(tempoff1, SeekOrigin.Begin);
            for (int i = 0; i < Animations.Length; i++)
            {
                anoffset[i] = binfile.ReadInt32();
            }

            for (int i = 0; i < Animations.Length; i++)
            {
                thefile.Seek(anoffset[i], SeekOrigin.Begin);

                Animations[i] = new DPOW.Reader.Animation(thefile, this);
            }

            for (int i = 0; i < Animations.Length; i++)
            {
                thefile.Seek(tempoff2 + i * 4, SeekOrigin.Begin);
                thefile.Seek(binfile.ReadInt32(), SeekOrigin.Begin);

                Animations[i].Name = loadstring(thefile);
            }

            thefile.Seek(unknownoff, SeekOrigin.Begin);
            unknowntable = new int[binfile.ReadInt32()];
            tempoff1 = binfile.ReadInt32();
            for (int i = 0; i < unknowntable.Length; i++)
            {
                thefile.Seek(tempoff1 + i * 4, SeekOrigin.Begin);
                thefile.Seek(binfile.ReadInt32(), SeekOrigin.Begin);
                unknowntable[i] = binfile.ReadInt32();
            }

            // EVENTS
            thefile.Seek(eventsoff, SeekOrigin.Begin);
            variables = new Variable[binfile.ReadInt32()];
            tempoff1 = binfile.ReadInt32();
            tempoff2 = binfile.ReadInt32();

            thefile.Seek(tempoff1, SeekOrigin.Begin);
            for (int i = 0; i < variables.Length; i++)
            {
                variables[i] = new Variable();
                variables[i].Enabled = binfile.ReadBoolean();
            }

            for (int i = 0; i < variables.Length; i++)
            {
                thefile.Seek(tempoff2 + i * 4, SeekOrigin.Begin);
                thefile.Seek(binfile.ReadInt32(), SeekOrigin.Begin);
                variables[i].Name = loadstring(thefile);
            }
        }

        public void SaveToFile(Stream thefile)
        {
            int imageoff, elementsoff, animoff, unknownoff, eventsoff, tempoff1, tempoff2, smallhead;
            int[] imageoffs;

            BinaryWriter binfile = new BinaryWriter(thefile);

            // Starting description
            binfile.Write(ASCIIEncoding.ASCII.GetBytes("DPOW"));
            binfile.Write((int)0x1003); // Unknown - sometimes 0x1002
            
            // Leave space for basic headers
            thefile.Seek(0x1c, SeekOrigin.Begin);

            // Write images
            imageoff = (int)thefile.Position;
            binfile.Write((int)textures.Length);
            imageoffs = new int[textures.Length];
            binfile.Write((int)thefile.Position + 4);
            thefile.Seek(textures.Length * 4, SeekOrigin.Current);
            for (int i = 0; i < textures.Length; i++)
            {
                imageoffs[i] = (int)thefile.Position;
                binfile.Write(ASCIIEncoding.ASCII.GetBytes(textures[i]));
                binfile.Write('\0');
            }
            while (thefile.Position % 4 != 0)
                thefile.WriteByte(0);

            smallhead = (int)thefile.Position;
            thefile.Seek(imageoff+8, SeekOrigin.Begin);
            for (int i = 0; i < textures.Length; i++)
            {
                binfile.Write(imageoffs[i]);
            }

            // Write elements
            int[] eloffset = new int[elements.Length];
            thefile.Seek(smallhead + elements.Length * 4, SeekOrigin.Begin);

            //Fill the elements
            for (int i = 0; i < Elements.Length; i++)
            {
                eloffset[i] = (int)thefile.Position;
                Elements[i].Write(thefile);
            }

            elementsoff = (int)thefile.Position;

            // Finish headers
            binfile.Write(elements.Length);
            binfile.Write(smallhead);

            animoff = (int)thefile.Position;

            thefile.Seek(smallhead, SeekOrigin.Begin);
            for (int i = 0; i < Elements.Length; i++)
            {
                binfile.Write(eloffset[i]);
            }

            //ANIMATIONS
            thefile.Seek(animoff, SeekOrigin.Begin);

            binfile.Write(animations.Length);
            int[] anoffset = new int[animations.Length];

            binfile.Write(0x0);
            binfile.Write(0x0);

            tempoff1 = (int)thefile.Position;

            thefile.Seek(tempoff1 + animations.Length * 4, SeekOrigin.Begin);
            for (int i = 0; i < animations.Length; i++)
            {
                anoffset[i] = (int)thefile.Position;
                animations[i].Write(thefile);
            }

            tempoff2 = (int)thefile.Position;

            thefile.Seek(tempoff1, SeekOrigin.Begin);
            for (int i = 0; i < animations.Length; i++)
            {
                binfile.Write(anoffset[i]);
            }

            thefile.Seek(tempoff2 + animations.Length * 4, SeekOrigin.Begin);
            for (int i = 0; i < animations.Length; i++)
            {
                anoffset[i] = (int)thefile.Position;
                binfile.Write(ASCIIEncoding.ASCII.GetBytes(animations[i].Name));
                binfile.Write('\0');
            }
            while (thefile.Position % 4 != 0)
                binfile.Write((byte)0);

            unknownoff = (int)thefile.Position;

            thefile.Seek(tempoff2, SeekOrigin.Begin);
            for (int i = 0; i < animations.Length; i++)
            {
                binfile.Write(anoffset[i]);
            }

            thefile.Seek(animoff + 4, SeekOrigin.Begin);
            binfile.Write(tempoff1);
            binfile.Write(tempoff2);

            //UNKNOWNS
            thefile.Seek(unknownoff, SeekOrigin.Begin);
            binfile.Write(unknowntable.Length);
            binfile.Write((int)thefile.Position + 4);
            for (int i = 0; i < unknowntable.Length; i++)
            {
                thefile.Seek(unknownoff + 8 + i * 4, SeekOrigin.Begin);
                binfile.Write(unknownoff + 8 + unknowntable.Length * 4 + i * 4);
                thefile.Seek(unknownoff + 8 + unknowntable.Length * 4 + i * 4, SeekOrigin.Begin);
                binfile.Write(unknowntable[i]);
            }

            // EVENTS
            eventsoff = (int)thefile.Position;
            binfile.Write(variables.Length);
            binfile.Write(0x0);
            binfile.Write(0x0);

            tempoff1 = (int)thefile.Position;
            for (int i = 0; i < variables.Length; i++)
            {
                binfile.Write(variables[i].Enabled);
            }
            while (thefile.Position % 4 != 0)
                binfile.Write((byte)0);

            tempoff2 = (int)thefile.Position;
            thefile.Seek(tempoff2 + variables.Length * 4, SeekOrigin.Begin);
            int[] varnames = new int[variables.Length];
            for (int i = 0; i < variables.Length; i++)
            {
                varnames[i] = (int)thefile.Position;
                binfile.Write(ASCIIEncoding.ASCII.GetBytes(variables[i].Name));
                binfile.Write('\0');
            }

            thefile.Seek(tempoff2, SeekOrigin.Begin);
            for (int i = 0; i < variables.Length; i++)
            {
                binfile.Write(varnames[i]);
            }

            thefile.Seek(eventsoff+4, SeekOrigin.Begin);
            binfile.Write(tempoff1);
            binfile.Write(tempoff2);

            // Set main headers
            thefile.Seek(8, SeekOrigin.Begin);
            binfile.Write(imageoff);
            binfile.Write(elementsoff);
            binfile.Write(animoff);
            binfile.Write(unknownoff);
            binfile.Write(eventsoff);
        }

        public Animation[] Animations
        {
            get
            {
                return animations;
            }
            set
            {
                animations = value;
            }
        }

        public Animation getAnimation(string name)
        {
            foreach (Animation anim in animations)
                if (anim.Name == name)
                    return anim;

            return null;
        }

        public short getAnimationId(string name)
        {
            for (short i = 0; i < animations.Length; i++)
                if (animations[i].Name == name)
                    return i;

            return -1;
        }

        public short addAnimation(Animation newanimation)
        {
            newanimation.setDPOW(this);
            if (newanimation.Frames.Length == 0)
            {
                newanimation.Frames = new Frame[1];
                newanimation.Frames[0] = new Frame(this.CreateElement(), 0, newanimation);
            }

            List<Animation> temp = new List<Animation>(animations);
            temp.Add(newanimation);
            animations = temp.ToArray();

            return getAnimationId(newanimation.Name);
        }

        public short CreateElement()
        {
            return AddElement(new Element());
        }

        public void RemoveElement(Element element)
        {
            List<Element> temp = new List<Element>(elements);
            temp.Remove(element);
            elements = temp.ToArray();
        }

        public short AddElement(Element element)
        {
            List<Element> temp = new List<Element>(elements);
            temp.Add(element);
            elements = temp.ToArray();

            return (short)(elements.Length - 1);
        }

        public short getElementId(Element element)
        {
            for (short i = 0; i < elements.Length; i++)
            {
                if (element == elements[i])
                    return i;
            }

            throw new Exception("No element found");
        }

        public void AddTexture(string newtexture)
        {
            List<string> temp = new List<string>(textures);
            temp.Add(newtexture);
            textures = temp.ToArray();
        }

        public Element[] Elements
        {
            get
            {
                return elements;
            }
            set
            {
                elements = value;
            }
        }

        public Variable[] Variables
        {
            get
            {
                return variables;
            }
            set
            {
                variables = value;
            }
        }

        public Variable getVariable(string name)
        {
            for (int i = 0; i < variables.Length; i++)
                if (variables[i].Name == name)
                    return variables[i];

            return null;
        }

        public string[] Textures
        {
            get
            {
                return textures;
            }
            set
            {
                textures = value;
            }
        }
    }
}
