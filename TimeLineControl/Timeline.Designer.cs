namespace TimeLineControl
{
    partial class TimeLine
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
            this.components = new System.ComponentModel.Container();
            this.scrHorizontalBar = new System.Windows.Forms.HScrollBar();
            this.ctxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addKeyframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeKeyframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSameKeyframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrHorizontalBar
            // 
            this.scrHorizontalBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrHorizontalBar.Location = new System.Drawing.Point(1, 441);
            this.scrHorizontalBar.Margin = new System.Windows.Forms.Padding(1, 1, 2, 1);
            this.scrHorizontalBar.Name = "scrHorizontalBar";
            this.scrHorizontalBar.Size = new System.Drawing.Size(692, 20);
            this.scrHorizontalBar.TabIndex = 0;
            this.scrHorizontalBar.ValueChanged += new System.EventHandler(this.hScrollBar2_ValueChanged);
            // 
            // ctxMenu
            // 
            this.ctxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addKeyframeToolStripMenuItem,
            this.addSameKeyframeToolStripMenuItem,
            this.removeKeyframeToolStripMenuItem});
            this.ctxMenu.Name = "ctxMenu";
            this.ctxMenu.Size = new System.Drawing.Size(180, 92);
            this.ctxMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenu_Opening);
            // 
            // addKeyframeToolStripMenuItem
            // 
            this.addKeyframeToolStripMenuItem.Name = "addKeyframeToolStripMenuItem";
            this.addKeyframeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.addKeyframeToolStripMenuItem.Text = "Add keyframe";
            this.addKeyframeToolStripMenuItem.Click += new System.EventHandler(this.addKeyframeToolStripMenuItem_Click);
            // 
            // removeKeyframeToolStripMenuItem
            // 
            this.removeKeyframeToolStripMenuItem.Name = "removeKeyframeToolStripMenuItem";
            this.removeKeyframeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.removeKeyframeToolStripMenuItem.Text = "Remove keyframe";
            this.removeKeyframeToolStripMenuItem.Click += new System.EventHandler(this.removeKeyframeToolStripMenuItem_Click);
            // 
            // addSameKeyframeToolStripMenuItem
            // 
            this.addSameKeyframeToolStripMenuItem.Name = "addSameKeyframeToolStripMenuItem";
            this.addSameKeyframeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.addSameKeyframeToolStripMenuItem.Text = "Add same keyframe";
            this.addSameKeyframeToolStripMenuItem.Click += new System.EventHandler(this.addSameKeyframeToolStripMenuItem_Click);
            // 
            // TimeLine
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.scrHorizontalBar);
            this.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.Name = "TimeLine";
            this.Size = new System.Drawing.Size(695, 462);
            this.Load += new System.EventHandler(this.TimeLine_Load);
            this.ctxMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.HScrollBar scrHorizontalBar;
        private System.Windows.Forms.ContextMenuStrip ctxMenu;
        private System.Windows.Forms.ToolStripMenuItem addKeyframeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeKeyframeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addSameKeyframeToolStripMenuItem;
    }
}
