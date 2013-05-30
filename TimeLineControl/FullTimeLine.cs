using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TimeLineControl
{
    public partial class FullTimeLine : UserControl
    {
        private DPOW.Reader.Animation mSelectedAnimation;
        private int mCurrentFrame = 0;

        public delegate void FrameChangedEventHadler();
        public event FrameChangedEventHadler FrameChanged;

        public delegate void ElementSelectedEventHandler(int SelectedElementId);
        public event ElementSelectedEventHandler ElementSelected;

        public delegate void KeyFrameEventHandler(DPOW.Reader.Animation animation, int Time);
        public event KeyFrameEventHandler KeyFrameAdded;
        public event KeyFrameEventHandler SameKeyFrameAdded;
        public event KeyFrameEventHandler KeyFrameRemoved;

        public FullTimeLine()
        {
            InitializeComponent();
        }

        public DPOW.Reader.Animation SelectedAnimation
        {
            get
            {
                return mSelectedAnimation;
            }
            set
            {
                mSelectedAnimation = value;
                timeLine1.selectedAnimation = mSelectedAnimation;
                namesPanel1.selectedAnimation = mSelectedAnimation;
            }
        }

        public bool ShowChildren
        {
            get
            {
                return timeLine1.ShowChildren;
            }
            set
            {
                timeLine1.ShowChildren = value;
                namesPanel1.ShowChildren = value;
            }
        }

        public bool HandleAnimationEvents
        {
            get
            {
                return timeLine1.HandleAnimationEvents;
            }
            set
            {
                timeLine1.HandleAnimationEvents = value;
            }
        }

        public int CurrentFrame
        {
            get
            {
                return mCurrentFrame;
            }
            set
            {
                mCurrentFrame = value;
                timeLine1.CurrentFrame = mCurrentFrame;
            }
        }

        private void namesPanel1_VerticalOffsetChanged()
        {
            timeLine1.VerticalOffset = namesPanel1.VerticalOffset;
        }

        private void timeLine1_FrameChanged()
        {
            mCurrentFrame = timeLine1.CurrentFrame;

            if(FrameChanged != null)
                FrameChanged();
        }

        private void timeLine1_ElementSelected(int SelectedElementId)
        {
            if (ElementSelected != null)
                ElementSelected(SelectedElementId);
        }

        private void timeLine1_KeyFrameAdded(DPOW.Reader.Animation animation, int Time)
        {
            if (KeyFrameAdded != null)
                KeyFrameAdded(animation, Time);
        }

        private void timeLine1_KeyFrameRemoved(DPOW.Reader.Animation animation, int Time)
        {
            if (KeyFrameRemoved != null)
                KeyFrameRemoved(animation, Time);
        }

        private void timeLine1_SameKeyFrameAdded(DPOW.Reader.Animation animation, int Time)
        {
            if (SameKeyFrameAdded != null)
                SameKeyFrameAdded(animation, Time);
        }
    }
}
