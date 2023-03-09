namespace Roll_Call_And_Management_System.views.components.facial
{
    partial class scan
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
            this.ImageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            this.flowLayoutPanelRemaining = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDormitory = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnCapture = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.flowLayoutPanelScanned = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.bunifuSeparator4 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lblScanned = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxFrameGrabber)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageBoxFrameGrabber
            // 
            this.ImageBoxFrameGrabber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.ImageBoxFrameGrabber.BackgroundImage = global::Roll_Call_And_Management_System.Properties.Resources.camera_identification;
            this.ImageBoxFrameGrabber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ImageBoxFrameGrabber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageBoxFrameGrabber.Location = new System.Drawing.Point(17, 21);
            this.ImageBoxFrameGrabber.Name = "ImageBoxFrameGrabber";
            this.ImageBoxFrameGrabber.Size = new System.Drawing.Size(545, 400);
            this.ImageBoxFrameGrabber.TabIndex = 36;
            this.ImageBoxFrameGrabber.TabStop = false;
            // 
            // flowLayoutPanelRemaining
            // 
            this.flowLayoutPanelRemaining.AutoScroll = true;
            this.flowLayoutPanelRemaining.Location = new System.Drawing.Point(568, 95);
            this.flowLayoutPanelRemaining.Name = "flowLayoutPanelRemaining";
            this.flowLayoutPanelRemaining.Size = new System.Drawing.Size(320, 167);
            this.flowLayoutPanelRemaining.TabIndex = 37;
            // 
            // lblDormitory
            // 
            this.lblDormitory.AutoSize = true;
            this.lblDormitory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.lblDormitory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDormitory.ForeColor = System.Drawing.Color.White;
            this.lblDormitory.Location = new System.Drawing.Point(654, 16);
            this.lblDormitory.Name = "lblDormitory";
            this.lblDormitory.Size = new System.Drawing.Size(69, 15);
            this.lblDormitory.TabIndex = 91;
            this.lblDormitory.Text = "Dormitory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(576, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 27;
            this.label2.Text = "Dormitory";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(568, 88);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(320, 1);
            this.bunifuSeparator1.TabIndex = 86;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Active = false;
            this.btnCapture.Activecolor = System.Drawing.Color.Green;
            this.btnCapture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCapture.BackColor = System.Drawing.Color.DarkGreen;
            this.btnCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCapture.BorderRadius = 5;
            this.btnCapture.ButtonText = "Finish";
            this.btnCapture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapture.DisabledColor = System.Drawing.Color.Gray;
            this.btnCapture.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCapture.Iconimage = global::Roll_Call_And_Management_System.Properties.Resources.camera;
            this.btnCapture.Iconimage_right = null;
            this.btnCapture.Iconimage_right_Selected = null;
            this.btnCapture.Iconimage_Selected = null;
            this.btnCapture.IconMarginLeft = 20;
            this.btnCapture.IconMarginRight = 0;
            this.btnCapture.IconRightVisible = true;
            this.btnCapture.IconRightZoom = 0D;
            this.btnCapture.IconVisible = true;
            this.btnCapture.IconZoom = 50D;
            this.btnCapture.IsTab = true;
            this.btnCapture.Location = new System.Drawing.Point(439, 433);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnCapture.OnHovercolor = System.Drawing.Color.Green;
            this.btnCapture.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCapture.selected = false;
            this.btnCapture.Size = new System.Drawing.Size(110, 32);
            this.btnCapture.TabIndex = 87;
            this.btnCapture.Text = "Finish";
            this.btnCapture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapture.Textcolor = System.Drawing.Color.White;
            this.btnCapture.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnCapture.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(576, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 15);
            this.label3.TabIndex = 88;
            this.label3.Text = "Remaining Inmates";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.White;
            this.lblCode.Location = new System.Drawing.Point(683, 38);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(40, 15);
            this.lblCode.TabIndex = 89;
            this.lblCode.Text = "Code";
            // 
            // flowLayoutPanelScanned
            // 
            this.flowLayoutPanelScanned.AutoScroll = true;
            this.flowLayoutPanelScanned.Location = new System.Drawing.Point(568, 298);
            this.flowLayoutPanelScanned.Name = "flowLayoutPanelScanned";
            this.flowLayoutPanelScanned.Size = new System.Drawing.Size(320, 167);
            this.flowLayoutPanelScanned.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(576, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 15);
            this.label5.TabIndex = 91;
            this.label5.Text = "Scanned Inmates";
            // 
            // bunifuSeparator4
            // 
            this.bunifuSeparator4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator4.LineThickness = 1;
            this.bunifuSeparator4.Location = new System.Drawing.Point(568, 291);
            this.bunifuSeparator4.Name = "bunifuSeparator4";
            this.bunifuSeparator4.Size = new System.Drawing.Size(320, 1);
            this.bunifuSeparator4.TabIndex = 90;
            this.bunifuSeparator4.Transparency = 255;
            this.bunifuSeparator4.Vertical = false;
            // 
            // lblScanned
            // 
            this.lblScanned.AutoSize = true;
            this.lblScanned.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.lblScanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanned.ForeColor = System.Drawing.Color.White;
            this.lblScanned.Location = new System.Drawing.Point(815, 273);
            this.lblScanned.Name = "lblScanned";
            this.lblScanned.Size = new System.Drawing.Size(15, 15);
            this.lblScanned.TabIndex = 92;
            this.lblScanned.Text = "0";
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.lblRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemaining.ForeColor = System.Drawing.Color.White;
            this.lblRemaining.Location = new System.Drawing.Point(814, 69);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(15, 15);
            this.lblRemaining.TabIndex = 93;
            this.lblRemaining.Text = "0";
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(568, 34);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(320, 1);
            this.bunifuSeparator2.TabIndex = 94;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(576, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 95;
            this.label1.Text = "Roll Call Code";
            // 
            // scan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.lblDormitory);
            this.Controls.Add(this.lblRemaining);
            this.Controls.Add(this.lblScanned);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bunifuSeparator4);
            this.Controls.Add(this.flowLayoutPanelScanned);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.flowLayoutPanelRemaining);
            this.Controls.Add(this.ImageBoxFrameGrabber);
            this.Name = "scan";
            this.Size = new System.Drawing.Size(908, 530);
            this.Load += new System.EventHandler(this.scan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBoxFrameGrabber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox ImageBoxFrameGrabber;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        public System.Windows.Forms.Label lblDormitory;
        public System.Windows.Forms.Label label2;
        public Bunifu.Framework.UI.BunifuFlatButton btnCapture;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblCode;
        public System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator4;
        public System.Windows.Forms.Label lblScanned;
        public System.Windows.Forms.Label lblRemaining;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRemaining;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelScanned;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        public System.Windows.Forms.Label label1;
    }
}
