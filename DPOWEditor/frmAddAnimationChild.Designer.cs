namespace DPOWEditor
{
    partial class frmAddAnimationChild
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
            this.radExisingAnimation = new System.Windows.Forms.RadioButton();
            this.radNewAnimation = new System.Windows.Forms.RadioButton();
            this.cmbAnimations = new System.Windows.Forms.ComboBox();
            this.grpNewProperties = new System.Windows.Forms.GroupBox();
            this.prpNewAnimation = new System.Windows.Forms.PropertyGrid();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.grpNewProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // radExisingAnimation
            // 
            this.radExisingAnimation.AutoSize = true;
            this.radExisingAnimation.Checked = true;
            this.radExisingAnimation.Location = new System.Drawing.Point(18, 12);
            this.radExisingAnimation.Name = "radExisingAnimation";
            this.radExisingAnimation.Size = new System.Drawing.Size(66, 17);
            this.radExisingAnimation.TabIndex = 0;
            this.radExisingAnimation.TabStop = true;
            this.radExisingAnimation.Text = "Existing:";
            this.radExisingAnimation.UseVisualStyleBackColor = true;
            this.radExisingAnimation.CheckedChanged += new System.EventHandler(this.radExisingAnimation_CheckedChanged);
            // 
            // radNewAnimation
            // 
            this.radNewAnimation.AutoSize = true;
            this.radNewAnimation.Location = new System.Drawing.Point(18, 35);
            this.radNewAnimation.Name = "radNewAnimation";
            this.radNewAnimation.Size = new System.Drawing.Size(85, 17);
            this.radNewAnimation.TabIndex = 1;
            this.radNewAnimation.Text = "Create new:";
            this.radNewAnimation.UseVisualStyleBackColor = true;
            this.radNewAnimation.CheckedChanged += new System.EventHandler(this.radNewAnimation_CheckedChanged);
            // 
            // cmbAnimations
            // 
            this.cmbAnimations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnimations.FormattingEnabled = true;
            this.cmbAnimations.Location = new System.Drawing.Point(90, 11);
            this.cmbAnimations.Name = "cmbAnimations";
            this.cmbAnimations.Size = new System.Drawing.Size(224, 21);
            this.cmbAnimations.TabIndex = 2;
            this.cmbAnimations.SelectedIndexChanged += new System.EventHandler(this.cmbAnimations_SelectedIndexChanged);
            // 
            // grpNewProperties
            // 
            this.grpNewProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNewProperties.Controls.Add(this.prpNewAnimation);
            this.grpNewProperties.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.grpNewProperties.Location = new System.Drawing.Point(12, 58);
            this.grpNewProperties.Name = "grpNewProperties";
            this.grpNewProperties.Size = new System.Drawing.Size(575, 267);
            this.grpNewProperties.TabIndex = 3;
            this.grpNewProperties.TabStop = false;
            this.grpNewProperties.Text = "New Animation Properties";
            // 
            // prpNewAnimation
            // 
            this.prpNewAnimation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prpNewAnimation.Enabled = false;
            this.prpNewAnimation.Location = new System.Drawing.Point(6, 19);
            this.prpNewAnimation.Name = "prpNewAnimation";
            this.prpNewAnimation.Size = new System.Drawing.Size(563, 242);
            this.prpNewAnimation.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(487, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 22);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(487, 37);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 22);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(443, 12);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(38, 21);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Icon:";
            // 
            // frmAddAnimationChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 337);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpNewProperties);
            this.Controls.Add(this.cmbAnimations);
            this.Controls.Add(this.radNewAnimation);
            this.Controls.Add(this.radExisingAnimation);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddAnimationChild";
            this.ShowIcon = false;
            this.Text = "Add Animation Child";
            this.Load += new System.EventHandler(this.frmAddAnimationChild_Load);
            this.grpNewProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radExisingAnimation;
        private System.Windows.Forms.RadioButton radNewAnimation;
        private System.Windows.Forms.ComboBox cmbAnimations;
        private System.Windows.Forms.GroupBox grpNewProperties;
        private System.Windows.Forms.PropertyGrid prpNewAnimation;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
    }
}