using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DPOW.Reader
{
    [System.ComponentModel.TypeConverterAttribute(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class Animation
    {
        private string name;
        private short parent, unk1;
        private Frame[] frames;
        private Event[] events;
        private Child[] childs;
        private byte[] untable;
        private DPOWObject dpow;

        public Animation()
        {
            events = new Event[0];
            childs = new Child[0];
            frames = new Frame[0];

            untable = new byte[]{255,255,255,0};
        }

        public Animation(Stream thefile, DPOWObject dpow)
        {
            this.dpow = dpow;

            BinaryReader binfile = new BinaryReader(thefile);

            int foff, eoff, noff;
            byte unb1, unb2;

            parent = binfile.ReadInt16();

            frames = new Frame[binfile.ReadInt16()];
            unk1 = binfile.ReadInt16();
            unb1 = binfile.ReadByte();
            unb2 = binfile.ReadByte();

            events = new Event[unb1];
            childs = new Child[unb2];

            untable = new byte[4];
            thefile.Read(untable, 0, 4);

            foff = binfile.ReadInt32();
            eoff = binfile.ReadInt32();
            noff = binfile.ReadInt32();

            thefile.Seek(foff, SeekOrigin.Begin);
            for (int j = 0; j < frames.Length; j++)
            {
                frames[j] = new Frame(binfile.ReadInt16(), binfile.ReadInt16(), this);
            }

            thefile.Seek(eoff, SeekOrigin.Begin);
            for (int j = 0; j < events.Length; j++)
            {
                events[j] = new Event(binfile.ReadInt16(), binfile.ReadInt16(), binfile.ReadInt16(), binfile.ReadInt16());
            }

            thefile.Seek(noff, SeekOrigin.Begin);
            for (int j = 0; j < childs.Length; j++)
            {
                childs[j] = new Child(binfile.ReadInt16(), binfile.ReadInt16());
            }
        }

        public void Write(Stream thefile)
        {
            BinaryWriter binfile = new BinaryWriter(thefile);

            int foff, eoff, noff;

            binfile.Write(parent);

            binfile.Write((short)frames.Length);
            binfile.Write(unk1);
            binfile.Write((byte)events.Length);
            binfile.Write((byte)childs.Length);

            binfile.Write(untable);

            int smallhead = (int)thefile.Position;
            thefile.Seek(12, SeekOrigin.Current);

            foff = (int)thefile.Position;
            for (int j = 0; j < frames.Length; j++)
            {
                binfile.Write(frames[j].ElementId);
                binfile.Write(frames[j].Time);
            }

            eoff = (int)thefile.Position;
            for (int j = 0; j < events.Length; j++)
            {
                binfile.Write(events[j].EventId);
                binfile.Write(events[j].Unk);
                binfile.Write(events[j].Start);
                binfile.Write(events[j].End);
            }

            noff = (int)thefile.Position;
            for (int j = 0; j < childs.Length; j++)
            {
                binfile.Write(childs[j].ChildId);
                binfile.Write(childs[j].ChildIcon);                
            }

            int tmpoff = (int)thefile.Position;
            thefile.Seek(smallhead, SeekOrigin.Begin);
            binfile.Write(foff);
            binfile.Write(eoff);
            binfile.Write(noff);

            thefile.Seek(tmpoff, SeekOrigin.Begin);
        }

        public void setDPOW(DPOWObject dpow)
        {
            this.dpow = dpow;
        }

        public DPOWObject getDPOW()
        {
            return dpow;
        }

        public short ParentId
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        public Frame getFrameOnTime(int time)
        {
            return getFrameOnTime(time, true);
        }

        public Frame getFrameOnTime(int time, bool handleEvents)
        {
            Frame result = frames[0];

            for (int i = 1; i < frames.Length; i++)
            {
                if (frames[i].Time <= time && (isTimeEnabled(frames[i].Time) || !handleEvents))
                    result = frames[i];
            }

            if (result.Time > time)
                return null;

            return result;
        }

        public bool isTimeEnabled(int time)
        {
            for (int i = 0; i < events.Length; i++)
            {
                if (events[i].EventId > dpow.Variables.Length - 1)
                    return true;
                if (events[i].Start <= time && events[i].End >= time && dpow.Variables[events[i].EventId].Enabled)
                    return true;
            }

            return false;
        }

        public int MaxTime
        {
            get
            {
                int max = frames[frames.Length - 1].Time;

                for (int i = 0; i < childs.Length; i++)
                {
                    if (getChild(i).MaxTime > max)
                        max = getChild(i).MaxTime;
                }

                return max;
            }
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        public void AddKeyFrame(short time)
        {
            if (getFrameOnTime(time, false).Time == time)
                throw new Exception("There is already a keyframe for that time");

            Frame oldframe = getFrameOnTime(time, false);
            Element newelem = DeepClone<Element>(dpow.Elements[oldframe.ElementId]);
            Frame newframe = new Frame(dpow.AddElement(newelem), time, this);

            List<Frame> temp = new List<Frame>(frames);
            temp.Insert(temp.IndexOf(oldframe) + 1, newframe);
            frames = temp.ToArray();
        }

        public void RemoveKeyFrame(short time)
        {
            if (getFrameOnTime(time, false).Time != time)
                throw new Exception("There is no keyframe here");

            List<Frame> temp = new List<Frame>(frames);
            temp.Remove(getFrameOnTime(time, false));
            frames = temp.ToArray();
        }

        public bool HasElement(Element elem)
        {
            for (int i = 0; i < frames.Length; i++)
                if (frames[i].Element == elem)
                    return true;

            return false;
        }

        public void MoveKeyFrame(short srctime, short desttime)
        {
            if (getFrameOnTime(srctime, false).Time != srctime)
                throw new Exception("There is no keyframe here");

            if (getFrameOnTime(desttime, false).Time == desttime)
            {
                MoveKeyFrame(srctime, (short)(desttime + 1));
                return;
            }

            getFrameOnTime(srctime, false).Time = desttime;

            Array.Sort(frames, delegate(Frame frame1, Frame frame2)
            {
                return frame1.Time.CompareTo(frame2.Time);
            });
        }

        public Frame[] Frames
        {
            get
            {
                return frames;
            }
            set
            {
                frames = value;
            }
        }

        public Event[] Events
        {
            get
            {
                return events;
            }
            set
            {
                events = value;
            }
        }

        public Child[] Childs
        {
            get
            {
                return childs;
            }
            set
            {
                childs = value;
            }
        }

        public Animation getChild(int i)
        {
            return dpow.Animations[childs[i].ChildId];
        }

        public void addChild(Animation child, short icon)
        {
            short id;
            if (dpow.getAnimation(child.Name) == null)
                id = dpow.addAnimation(child);
            else
                id = dpow.getAnimationId(child.Name);

            List<Child> temp = new List<Child>(childs);
            temp.Add(new Child(id, icon));
            childs = temp.ToArray();
        }

        public void removeChild(Animation child)
        {
            short childid = dpow.getAnimationId(child.Name);

            Child tmpchild = new Child(-1, -1);
            for (int i = 0; i < childs.Length; i++)
                if (childs[i].ChildId == childid)
                    tmpchild = childs[i];

            List<Child> temp = new List<Child>(childs);
            temp.Remove(tmpchild);
            childs = temp.ToArray();
        }

        public Variable getVariable(int i)
        {
            if (events[i].EventId < dpow.Variables.Length)
                return dpow.Variables[events[i].EventId];

            return new Variable("OUT OF BOUNDS");
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public byte[] UnTable
        {
            get
            {
                return untable;
            }
            set
            {
                untable = value;
            }
        }

        public void AddSameKeyFrame(short time)
        {
            if (getFrameOnTime(time, false).Time == time)
                throw new Exception("There is already a keyframe for that time");

            Frame oldframe = getFrameOnTime(time, false);
            Frame newframe = new Frame(oldframe.ElementId, time, this);

            List<Frame> temp = new List<Frame>(frames);
            temp.Insert(temp.IndexOf(oldframe) + 1, newframe);
            frames = temp.ToArray();
        }
    }

    public class Frame
    {
        private Element element;
        private short time;
        private Animation parent;

        public Frame(short elementid, short time, Animation parent)
        {
            this.parent = parent;
            this.ElementId = elementid;
            this.time = time;
        }

        public Element Element
        {
            get
            {
                return element;
            }
            set
            {
                element = value;
            }
        }

        public short ElementId
        {
            get
            {
                return parent.getDPOW().getElementId(element);
            }
            set
            {
                element = parent.getDPOW().Elements[value];
            }
        }

        public short Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
    }

    public class Event
    {
        private short eventid, unk, start, end;

        public Event()
        {
        }

        public Event(short eventid, short unk, short start, short end)
        {
            this.eventid = eventid;
            this.unk = unk;
            this.start = start;
            this.end = end;
        }

        public short EventId
        {
            get
            {
                return eventid;
            }
            set
            {
                eventid = value;
            }
        }

        public short Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value;
            }
        }

        public short End
        {
            get
            {
                return end;
            }
            set
            {
                end = value;
            }
        }

        public short Unk
        {
            get
            {
                return unk;
            }
            set
            {
                unk = value;
            }
        }
    }

    public class Child
    {
        private short childid, childicon;

        public Child()
        {
            this.childid = 0;
            childicon = -1;
        }

        public Child(short childid, short childicon)
        {
            this.childid = childid;
            this.childicon = childicon;
        }

        public short ChildId
        {
            get
            {
                return childid;
            }
            set
            {
                childid = value;
            }
        }

        public short ChildIcon
        {
            get
            {
                return childicon;
            }
            set
            {
                childicon = value;
            }
        }
    }
}
