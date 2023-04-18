namespace Prisoners_Management_System.views.components.facial
{
    partial class capture
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
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblFullname = new System.Windows.Forms.Label();
            this.btnCapture = new Bunifu.Framework.UI.BunifuFlatButton();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.ImageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxFrameGrabber)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(192, 479);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 15);
            this.label8.TabIndex = 49;
            this.label8.Text = "Code";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(192, 518);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 50;
            this.label1.Text = "Full Name";
            // 
            // lblCode
            // 
            this.lblCode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCode.AutoSize = true;
            this.lblCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.White;
            this.lblCode.Location = new System.Drawing.Point(192, 498);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(48, 15);
            this.lblCode.TabIndex = 51;
            this.lblCode.Text = "_Code";
            // 
            // lblFullname
            // 
            this.lblFullname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFullname.AutoSize = true;
            this.lblFullname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.lblFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullname.ForeColor = System.Drawing.Color.White;
            this.lblFullname.Location = new System.Drawing.Point(192, 537);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(81, 15);
            this.lblFullname.TabIndex = 52;
            this.lblFullname.Text = "_Full Name";
            // 
            // btnCapture
            // 
            this.btnCapture.Active = false;
            this.btnCapture.Activecolor = System.Drawing.Color.Green;
            this.btnCapture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCapture.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCapture.BorderRadius = 5;
            this.btnCapture.ButtonText = "Capture";
            this.btnCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapture.DisabledColor = System.Drawing.Color.Gray;
            this.btnCapture.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCapture.Iconimage = global::Prisoners_Management_System.Properties.Resources.camera;
            this.btnCapture.Iconimage_right = null;
            this.btnCapture.Iconimage_right_Selected = null;
            this.btnCapture.Iconimage_Selected = null;
            this.btnCapture.IconMarginLeft = 0;
            this.btnCapture.IconMarginRight = 0;
            this.btnCapture.IconRightVisible = true;
            this.btnCapture.IconRightZoom = 0D;
            this.btnCapture.IconVisible = true;
            this.btnCapture.IconZoom = 50D;
            this.btnCapture.IsTab = true;
            this.btnCapture.Location = new System.Drawing.Point(564, 524);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnCapture.OnHovercolor = System.Drawing.Color.Green;
            this.btnCapture.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCapture.selected = false;
            this.btnCapture.Size = new System.Drawing.Size(110, 45);
            this.btnCapture.TabIndex = 53;
            this.btnCapture.Text = "Capture";
            this.btnCapture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapture.Textcolor = System.Drawing.Color.White;
            this.btnCapture.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // imageBox1
            // 
            this.imageBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.imageBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.imageBox1.BackgroundImage = global::Prisoners_Management_System.Properties.Resources.user;
            this.imageBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageBox1.Location = new System.Drawing.Point(86, 469);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(100, 100);
            this.imageBox1.TabIndex = 34;
            this.imageBox1.TabStop = false;
            // 
            // ImageBoxFrameGrabber
            // 
            this.ImageBoxFrameGrabber.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ImageBoxFrameGrabber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.ImageBoxFrameGrabber.BackgroundImage = global::Prisoners_Management_System.Properties.Resources.camera_identification;
            this.ImageBoxFrameGrabber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ImageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageBoxFrameGrabber.Location = new System.Drawing.Point(74, 17);
            this.ImageBoxFrameGrabber.Name = "ImageBoxFrameGrabber";
            this.ImageBoxFrameGrabber.Size = new System.Drawing.Size(600, 440);
            this.ImageBoxFrameGrabber.TabIndex = 35;
            this.ImageBoxFrameGrabber.TabStop = false;
            // 
            // capture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.lblFullname);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.ImageBoxFrameGrabber);
            this.Name = "capture";
            this.Size = new System.Drawing.Size(748, 633);
            this.Load += new System.EventHandler(this.capture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxFrameGrabber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Emgu.CV.UI.ImageBox imageBox1;
        private Emgu.CV.UI.ImageBox ImageBoxFrameGrabber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblCode;
        public System.Windows.Forms.Label lblFullname;
        public Bunifu.Framework.UI.BunifuFlatButton btnCapture;
    }
}
