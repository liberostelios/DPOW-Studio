namespace DPOWEditor
{
    partial class frmInterpolateDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.prtEquations = new System.Windows.Forms.PropertyGrid();
            this.cmbAnimations = new System.Windows.Forms.ComboBox();
            this.tmlTimeLine = new TimeLineControl.FullTimeLine();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numEndFrame = new System.Windows.Forms.NumericUpDown();
            this.numStartFrame = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbImage = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // prtEquations
            // 
            this.prtEquations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prtEquations.Location = new System.Drawing.Point(671, 12);
            this.prtEquations.Name = "prtEquations";
            this.prtEquations.Size = new System.Drawing.Size(244, 411);
            this.prtEquations.TabIndex = 0;
            // 
            // cmbAnimations
            // 
            this.cmbAnimations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnimations.FormattingEnabled = true;
            this.cmbAnimations.Location = new System.Drawing.Point(113, 3);
            this.cmbAnimations.Name = "cmbAnimations";
            this.cmbAnimations.Size = new System.Drawing.Size(187, 21);
            this.cmbAnimations.TabIndex = 1;
            this.cmbAnimations.SelectedIndexChanged += new System.EventHandler(this.cmbAnimations_SelectedIndexChanged);
            // 
            // tmlTimeLine
            // 
            this.tmlTimeLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tmlTimeLine.CurrentFrame = 0;
            this.tmlTimeLine.HandleAnimationEvents = false;
            this.tmlTimeLine.Location = new System.Drawing.Point(12, 284);
            this.tmlTimeLine.Name = "tmlTimeLine";
            this.tmlTimeLine.SelectedAnimation = null;
            this.tmlTimeLine.ShowChildren = false;
            this.tmlTimeLine.Size = new System.Drawing.Size(653, 139);
            this.tmlTimeLine.TabIndex = 2;
            this.tmlTimeLine.ElementSelected += new TimeLineControl.FullTimeLine.ElementSelectedEventHandler(this.tmlTimeLine_ElementSelected);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(3, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start Time";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.84533F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.15467F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbAnimations, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numEndFrame, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.numStartFrame, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbImage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnApply, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(653, 266);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Animation";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "End Time";
            // 
            // numEndFrame
            // 
            this.numEndFrame.Location = new System.Drawing.Point(113, 81);
            this.numEndFrame.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numEndFrame.Name = "numEndFrame";
            this.numEndFrame.Size = new System.Drawing.Size(57, 21);
            this.numEndFrame.TabIndex = 6;
            this.numEndFrame.ValueChanged += new System.EventHandler(this.numEndFrame_ValueChanged);
            // 
            // numStartFrame
            // 
            this.numStartFrame.Location = new System.Drawing.Point(113, 55);
            this.numStartFrame.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numStartFrame.Name = "numStartFrame";
            this.numStartFrame.Size = new System.Drawing.Size(57, 21);
            this.numStartFrame.TabIndex = 4;
            this.numStartFrame.ValueChanged += new System.EventHandler(this.numStartFrame_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.Location = new System.Drawing.Point(3, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Object";
            // 
            // cmbImage
            // 
            this.cmbImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImage.FormattingEnabled = true;
            this.cmbImage.Location = new System.Drawing.Point(113, 29);
            this.cmbImage.Name = "cmbImage";
            this.cmbImage.Size = new System.Drawing.Size(187, 21);
            this.cmbImage.TabIndex = 10;
            this.cmbImage.SelectedIndexChanged += new System.EventHandler(this.cmbImage_SelectedIndexChanged);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(3, 107);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(104, 23);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmInterpolateDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 435);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tmlTimeLine);
            this.Controls.Add(this.prtEquations);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmInterpolateDialog";
            this.Text = "Interpolate Animation";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartFrame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid prtEquations;
        private System.Windows.Forms.ComboBox cmbAnimations;
        private TimeLineControl.FullTimeLine tmlTimeLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numStartFrame;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numEndFrame;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbImage;
        private System.Windows.Forms.Button btnApply;
    }
}