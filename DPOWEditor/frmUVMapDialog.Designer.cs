namespace DPOWEditor
{
    partial class frmUVMapDialog
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
            this.picTexture = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.txtPoint1 = new System.Windows.Forms.TextBox();
            this.txtPoint2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkScaleObject = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radScaleX = new System.Windows.Forms.RadioButton();
            this.radScaleY = new System.Windows.Forms.RadioButton();
            this.btnApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picTexture)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picTexture
            // 
            this.picTexture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picTexture.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picTexture.Location = new System.Drawing.Point(12, 12);
            this.picTexture.Name = "picTexture";
            this.picTexture.Size = new System.Drawing.Size(512, 512);
            this.picTexture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTexture.TabIndex = 0;
            this.picTexture.TabStop = false;
            this.picTexture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picTexture_MouseClick);
            this.picTexture.Paint += new System.Windows.Forms.PaintEventHandler(this.picTexture_Paint);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(530, 12);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(185, 31);
            this.btnLoadImage.TabIndex = 1;
            this.btnLoadImage.Text = "Load Image...";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // txtPoint1
            // 
            this.txtPoint1.Location = new System.Drawing.Point(530, 64);
            this.txtPoint1.Name = "txtPoint1";
            this.txtPoint1.ReadOnly = true;
            this.txtPoint1.Size = new System.Drawing.Size(185, 21);
            this.txtPoint1.TabIndex = 2;
            // 
            // txtPoint2
            // 
            this.txtPoint2.Location = new System.Drawing.Point(530, 103);
            this.txtPoint2.Name = "txtPoint2";
            this.txtPoint2.ReadOnly = true;
            this.txtPoint2.Size = new System.Drawing.Size(185, 21);
            this.txtPoint2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.Location = new System.Drawing.Point(530, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Top Left";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(530, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bottom Right";
            // 
            // chkScaleObject
            // 
            this.chkScaleObject.AutoSize = true;
            this.chkScaleObject.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.chkScaleObject.Location = new System.Drawing.Point(529, 130);
            this.chkScaleObject.Name = "chkScaleObject";
            this.chkScaleObject.Size = new System.Drawing.Size(93, 17);
            this.chkScaleObject.TabIndex = 10;
            this.chkScaleObject.Text = "ScaleObject";
            this.chkScaleObject.UseVisualStyleBackColor = true;
            this.chkScaleObject.CheckedChanged += new System.EventHandler(this.chkScaleObject_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radScaleY);
            this.groupBox1.Controls.Add(this.radScaleX);
            this.groupBox1.Location = new System.Drawing.Point(533, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 52);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scale";
            // 
            // radScaleX
            // 
            this.radScaleX.AutoSize = true;
            this.radScaleX.Location = new System.Drawing.Point(48, 20);
            this.radScaleX.Name = "radScaleX";
            this.radScaleX.Size = new System.Drawing.Size(31, 17);
            this.radScaleX.TabIndex = 0;
            this.radScaleX.Text = "X";
            this.radScaleX.UseVisualStyleBackColor = true;
            // 
            // radScaleY
            // 
            this.radScaleY.AutoSize = true;
            this.radScaleY.Checked = true;
            this.radScaleY.Location = new System.Drawing.Point(97, 20);
            this.radScaleY.Name = "radScaleY";
            this.radScaleY.Size = new System.Drawing.Size(31, 17);
            this.radScaleY.TabIndex = 1;
            this.radScaleY.TabStop = true;
            this.radScaleY.Text = "Y";
            this.radScaleY.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.btnApply.Location = new System.Drawing.Point(530, 493);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(185, 31);
            this.btnApply.TabIndex = 12;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmUVMapDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 536);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkScaleObject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPoint2);
            this.Controls.Add(this.txtPoint1);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.picTexture);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmUVMapDialog";
            this.Text = "frmUVMapDialog";
            ((System.ComponentModel.ISupportInitialize)(this.picTexture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTexture;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.TextBox txtPoint1;
        private System.Windows.Forms.TextBox txtPoint2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkScaleObject;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radScaleY;
        private System.Windows.Forms.RadioButton radScaleX;
        private System.Windows.Forms.Button btnApply;
    }
}