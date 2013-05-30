namespace TimeLineControl
{
    partial class FullTimeLine
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.namesPanel1 = new TimeLineControl.NamesPanel();
            this.timeLine1 = new TimeLineControl.TimeLine();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.namesPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.timeLine1);
            this.splitContainer1.Size = new System.Drawing.Size(813, 520);
            this.splitContainer1.SplitterDistance = 268;
            this.splitContainer1.TabIndex = 0;
            // 
            // namesPanel1
            // 
            this.namesPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.namesPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.namesPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.namesPanel1.Location = new System.Drawing.Point(0, 0);
            this.namesPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.namesPanel1.Name = "namesPanel1";
            this.namesPanel1.selectedAnimation = null;
            this.namesPanel1.Size = new System.Drawing.Size(268, 520);
            this.namesPanel1.TabIndex = 0;
            this.namesPanel1.VerticalOffsetChanged += new TimeLineControl.NamesPanel.VerticalOffsetChangedEventHandler(this.namesPanel1_VerticalOffsetChanged);
            // 
            // timeLine1
            // 
            this.timeLine1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLine1.BackColor = System.Drawing.SystemColors.Window;
            this.timeLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeLine1.CurrentFrame = 0;
            this.timeLine1.HandleAnimationEvents = false;
            this.timeLine1.Location = new System.Drawing.Point(0, 0);
            this.timeLine1.Margin = new System.Windows.Forms.Padding(0);
            this.timeLine1.Name = "timeLine1";
            this.timeLine1.selectedAnimation = null;
            this.timeLine1.Size = new System.Drawing.Size(541, 520);
            this.timeLine1.TabIndex = 0;
            this.timeLine1.VerticalOffset = 0;
            this.timeLine1.KeyFrameRemoved += new TimeLineControl.TimeLine.KeyFrameEventHandler(this.timeLine1_KeyFrameRemoved);
            this.timeLine1.FrameChanged += new TimeLineControl.TimeLine.FrameChangedEventHadler(this.timeLine1_FrameChanged);
            this.timeLine1.ElementSelected += new TimeLineControl.TimeLine.ElementSelectedEventHandler(this.timeLine1_ElementSelected);
            this.timeLine1.KeyFrameAdded += new TimeLineControl.TimeLine.KeyFrameEventHandler(this.timeLine1_KeyFrameAdded);
            this.timeLine1.SameKeyFrameAdded += new TimeLineControl.TimeLine.KeyFrameEventHandler(this.timeLine1_SameKeyFrameAdded);
            // 
            // FullTimeLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FullTimeLine";
            this.Size = new System.Drawing.Size(813, 520);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private TimeLine timeLine1;
        private NamesPanel namesPanel1;
    }
}
