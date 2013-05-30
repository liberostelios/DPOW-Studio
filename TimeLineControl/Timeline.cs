using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TimeLineControl
{
    public partial class TimeLine : UserControl
    {
        DPOW.Reader.Animation mSelectedAnimation;
        List<DPOW.Reader.Animation> mListedAnimations;
        int mCurrentFrame = 0;
        int mColumnWidth = 30;
        int mVerticalOffset = 0;
        int clickedAnimation = 0;
        int clickedTime = 0;
        bool handleEvents = false;
        bool showChildren = true;
        bool movingKeyframe = false;
        ToolTip mToolTip = new ToolTip();

        public delegate void FrameChangedEventHadler();
        public event FrameChangedEventHadler FrameChanged;

        public delegate void ElementSelectedEventHandler(int SelectedElementId);
        public event ElementSelectedEventHandler ElementSelected;

        public delegate void KeyFrameEventHandler(DPOW.Reader.Animation animation, int Time);
        public event KeyFrameEventHandler KeyFrameAdded;
        public event KeyFrameEventHandler SameKeyFrameAdded;
        public event KeyFrameEventHandler KeyFrameRemoved;

        public TimeLine()
        {
            InitializeComponent();

            mListedAnimations = new List<DPOW.Reader.Animation>();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            
            int i = (e.Y - 20 + mVerticalOffset) / 20;
            int j = e.X / mColumnWidth + scrHorizontalBar.Value;

            if (e.Button == MouseButtons.Left)
            {
                mCurrentFrame = j;

                if (FrameChanged != null)
                    FrameChanged();

                if (e.Y > 20)
                {
                    if (i < mListedAnimations.Count)
                        if (j <= mListedAnimations[i].MaxTime)
                            if (ElementSelected != null)
                                ElementSelected(mListedAnimations[i].getFrameOnTime(j, handleEvents).ElementId);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (e.Y > 20)
                {
                    clickedAnimation = (e.Y - 20 + mVerticalOffset) / 20;
                    clickedTime = e.X / mColumnWidth + scrHorizontalBar.Value;

                    if (clickedTime == 0)
                        return;

                    if(mListedAnimations[i].getFrameOnTime(j, false).Time == j)
                    {
                        addKeyframeToolStripMenuItem.Visible = false;
                        addSameKeyframeToolStripMenuItem.Visible = false;
                        removeKeyframeToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        addKeyframeToolStripMenuItem.Visible = true;
                        addSameKeyframeToolStripMenuItem.Visible = true;
                        removeKeyframeToolStripMenuItem.Visible = false;
                    }

                    ctxMenu.Show(this, e.X, e.Y);
                }
            }

            Refresh();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            int i = (e.Y - 20 + mVerticalOffset) / 20;
            int j = e.X / mColumnWidth + scrHorizontalBar.Value;

            if (e.Button == MouseButtons.Left)
            {
                if (i >= 0 && i < mListedAnimations.Count)
                    if (mListedAnimations[i].getFrameOnTime(j, false).Time == j)
                    {
                        clickedAnimation = i;
                        clickedTime = j;
                        movingKeyframe = true;

                        return;
                    }
            }
            else if (e.Button == MouseButtons.Right)
            {
                return;
            }

            movingKeyframe = false;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            int i = (e.Y - 20 + mVerticalOffset) / 20;
            int j = e.X / mColumnWidth + scrHorizontalBar.Value;

            if (movingKeyframe)
                if (mListedAnimations[clickedAnimation].getFrameOnTime(j, false).Time != j)
                {
                    try
                    {

                        mListedAnimations[clickedAnimation].MoveKeyFrame((short)clickedTime, (short)j);
                    }
                    catch
                    {
                    }

                    movingKeyframe = false;
                }

            Refresh();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            movingKeyframe = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            // for events editing and more
            
        }

        public bool HandleAnimationEvents
        {
            get
            {
                return handleEvents;
            }
            set
            {
                handleEvents = value;

                Refresh();
            }
        }

        public DPOW.Reader.Animation selectedAnimation
        {
            get
            {
                return mSelectedAnimation;
            }
            set
            {
                if (value == null)
                    return;

                mSelectedAnimation = value;

                if (mSelectedAnimation.MaxTime * mColumnWidth > Width)
                {
                    scrHorizontalBar.Visible = true;
                    scrHorizontalBar.Maximum = mSelectedAnimation.MaxTime;
                }
                else
                {
                    scrHorizontalBar.Visible = false;
                }

                Refresh();
            }
        }

        public bool ShowChildren
        {
            get
            {
                return showChildren;
            }
            set
            {
                showChildren = value;

                Refresh();
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

                if (mCurrentFrame < scrHorizontalBar.Value)
                    scrHorizontalBar.Value = mCurrentFrame;
                else if (mCurrentFrame > scrHorizontalBar.Value + Width / mColumnWidth - 1)
                    scrHorizontalBar.Value = mCurrentFrame - Width/mColumnWidth + 1;

                Refresh();
            }
        }

        public int VerticalOffset
        {
            get
            {
                return mVerticalOffset;
            }
            set
            {
                mVerticalOffset = value;

                Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (mSelectedAnimation == null)
                return;

            Graphics g = e.Graphics;
            Font boldfont = new Font(Font, FontStyle.Bold);

            // Draw selected animation
            mListedAnimations.Clear();
            mListedAnimations.Add(mSelectedAnimation);
            DrawLine(mSelectedAnimation, 20 - mVerticalOffset, g);

            // DrawChilds
            if (showChildren)
                DrawChild(mSelectedAnimation, 40 - mVerticalOffset, g);

            // Draw header
            g.FillRectangle(Brushes.LightGray, 0, 0, (scrHorizontalBar.Value + Width/mColumnWidth + 1) * mColumnWidth, 20);
            g.FillRectangle(Brushes.Gray, (mCurrentFrame - scrHorizontalBar.Value) * mColumnWidth, 0, mColumnWidth, 20);
            for (int i = scrHorizontalBar.Value; i <= scrHorizontalBar.Value + Width/mColumnWidth + 1; i++)
            {
                g.DrawRectangle(Pens.Gray, (i - scrHorizontalBar.Value) * mColumnWidth, 0, mColumnWidth, 19);
                g.DrawString(i.ToString(), boldfont, Brushes.Black, (i - scrHorizontalBar.Value) * 30, 4);
            }
        }

        private int DrawChild(DPOW.Reader.Animation anim, int y, Graphics g)
        {
            for (int i = 0; i < anim.Childs.Length; i++)
            {
                mListedAnimations.Add(anim.getChild(i));
                DrawLine(anim.getChild(i), y, g);
                y += 20;
                y = DrawChild(anim.getChild(i), y, g);
            }

            return y;
        }

        private void DrawLine(DPOW.Reader.Animation anim, int y, Graphics g)
        {
            List<int> starts = new List<int>();

            if (anim.getFrameOnTime(scrHorizontalBar.Value, handleEvents) != null)
            {
                if (scrHorizontalBar.Value != anim.getFrameOnTime(scrHorizontalBar.Value, handleEvents).Time)
                    starts.Add(anim.getFrameOnTime(scrHorizontalBar.Value).Time);
            }
            for (int i = scrHorizontalBar.Value; i <= Math.Min(anim.MaxTime, scrHorizontalBar.Value + Width / mColumnWidth + 1); i++)
            {
                if (anim.getFrameOnTime(i) == null)
                {
                    g.DrawRectangle(Pens.LightGray, (i - scrHorizontalBar.Value) * mColumnWidth, y, mColumnWidth, 20);
                }
                else
                {
                    if (anim.getFrameOnTime(i, handleEvents).Time == i)
                        starts.Add(i);
                }
            }
            starts.Add(Math.Min(anim.MaxTime + 1, scrHorizontalBar.Value + Width / mColumnWidth + 1));

            // Draw timeline
            for (int i = 0; i < starts.Count - 1; i++)
            {
                g.FillRectangle(Brushes.DarkSeaGreen, (starts[i] - scrHorizontalBar.Value) * mColumnWidth, y, (starts[i + 1] - starts[i]) * mColumnWidth, 20);
                g.DrawRectangle(Pens.Black, (starts[i] - scrHorizontalBar.Value) * mColumnWidth, y, (starts[i + 1] - starts[i]) * mColumnWidth, 20);
                g.DrawString(anim.getFrameOnTime(starts[i], handleEvents).ElementId.ToString(), Font, Brushes.Black, (starts[i] - scrHorizontalBar.Value) * mColumnWidth, y + 4);
            }

            Pen boldpen = new Pen(Color.DarkRed, 2);
            boldpen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;

            // Draw events
            for (int i = 0; i < anim.Events.Length; i++)
            {
                g.DrawRectangle(boldpen, (anim.Events[i].Start - scrHorizontalBar.Value) * mColumnWidth, y, (anim.Events[i].End - anim.Events[i].Start + 1) * mColumnWidth, 20);
            }
        }

        private void hScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void TimeLine_Load(object sender, EventArgs e)
        {

        }

        private void addKeyframeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KeyFrameAdded != null)
                KeyFrameAdded(mListedAnimations[clickedAnimation], clickedTime);

            Refresh();
        }

        private void removeKeyframeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(KeyFrameRemoved != null)
                KeyFrameRemoved(mListedAnimations[clickedAnimation], clickedTime);

            Refresh();
        }

        private void ctxMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void addSameKeyframeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SameKeyFrameAdded != null)
                SameKeyFrameAdded(mListedAnimations[clickedAnimation], clickedTime);

            Refresh();
        }
    }
}
