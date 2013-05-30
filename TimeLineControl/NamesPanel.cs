using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TimeLineControl
{
    public partial class NamesPanel : UserControl
    {
        DPOW.Reader.Animation mSelectedAnimation;
        bool mShowChildren = true;

        public delegate void VerticalOffsetChangedEventHandler();

        public event VerticalOffsetChangedEventHandler VerticalOffsetChanged;

        public NamesPanel()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Refresh();
        }

        public DPOW.Reader.Animation selectedAnimation
        {
            get
            {
                return mSelectedAnimation;
            }
            set
            {
                mSelectedAnimation = value;

                Refresh();
            }
        }

        public bool ShowChildren
        {
            get
            {
                return mShowChildren;
            }
            set
            {
                mShowChildren = value;

                Refresh();
            }
        }

        public int VerticalOffset
        {
            get
            {
                return scrVerticalBar.Value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (mSelectedAnimation == null)
                return;

            Font boldfont = new Font(Font, FontStyle.Bold);

            List<int> starts = new List<int>();

            Graphics g = e.Graphics;

            g.DrawString(mSelectedAnimation.Name, Font, Brushes.Black, 0, 24 - scrVerticalBar.Value);
            int y = 20;
            if (mShowChildren)
                y = DrawChilds(mSelectedAnimation, 40, 0, g);

            if (y > Height)
            {
                scrVerticalBar.Visible = true;
                scrVerticalBar.Maximum = y - Height + 30;
            }
            else
            {
                scrVerticalBar.Value = 0;
                scrVerticalBar.Visible = false;
            }

            g.FillRectangle(Brushes.LightGray, 0, 0, Width, 20);
            g.DrawRectangle(Pens.Gray, 0, 0, Width - 2, 19);
            g.DrawString("Animations", boldfont, Brushes.Black, 0, 4);
        }

        private int DrawChilds(DPOW.Reader.Animation anim, int y, int offset, Graphics g)
        {
            offset += 10;
            for (int i = 0; i < anim.Childs.Length; i++)
            {
                g.DrawString(anim.getChild(i).Name, Font, Brushes.Black, offset, y + 4 - scrVerticalBar.Value);
                y += 20;
                y = DrawChilds(anim.getChild(i), y, offset, g);
            }

            return y;
        }

        private void hScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void TimeLine_Load(object sender, EventArgs e)
        {

        }

        private void scrVerticalBar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                VerticalOffsetChanged();
            }
            catch
            {
            }

            Refresh();
        }
    }
}
