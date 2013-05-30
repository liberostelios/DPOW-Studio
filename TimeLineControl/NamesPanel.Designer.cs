namespace TimeLineControl
{
    partial class NamesPanel
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
            this.scrVerticalBar = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // scrVerticalBar
            // 
            this.scrVerticalBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrVerticalBar.Location = new System.Drawing.Point(240, 2);
            this.scrVerticalBar.Margin = new System.Windows.Forms.Padding(2);
            this.scrVerticalBar.Name = "scrVerticalBar";
            this.scrVerticalBar.Size = new System.Drawing.Size(18, 458);
            this.scrVerticalBar.TabIndex = 0;
            this.scrVerticalBar.Visible = false;
            this.scrVerticalBar.ValueChanged += new System.EventHandler(this.scrVerticalBar_ValueChanged);
            // 
            // NamesPanel
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.scrVerticalBar);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.Name = "NamesPanel";
            this.Size = new System.Drawing.Size(260, 462);
            this.Load += new System.EventHandler(this.TimeLine_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar scrVerticalBar;

    }
}
