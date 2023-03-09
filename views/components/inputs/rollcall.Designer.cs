namespace Roll_Call_And_Management_System.views.components.inputs
{
    partial class rollcall
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
            this.lblTotalInmates = new System.Windows.Forms.Label();
            this.btnStart = new Bunifu.Framework.UI.BunifuFlatButton();
            this.dpnDormitory = new Bunifu.UI.WinForms.BunifuDropdown();
            this.SuspendLayout();
            // 
            // lblTotalInmates
            // 
            this.lblTotalInmates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalInmates.AutoSize = true;
            this.lblTotalInmates.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalInmates.ForeColor = System.Drawing.Color.White;
            this.lblTotalInmates.Location = new System.Drawing.Point(37, 35);
            this.lblTotalInmates.Name = "lblTotalInmates";
            this.lblTotalInmates.Size = new System.Drawing.Size(90, 21);
            this.lblTotalInmates.TabIndex = 87;
            this.lblTotalInmates.Text = "Dormitory";
            // 
            // btnStart
            // 
            this.btnStart.Active = false;
            this.btnStart.Activecolor = System.Drawing.Color.Green;
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStart.BackColor = System.Drawing.Color.DarkGreen;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.BorderRadius = 5;
            this.btnStart.ButtonText = "Start";
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.DisabledColor = System.Drawing.Color.Gray;
            this.btnStart.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStart.Iconimage = global::Roll_Call_And_Management_System.Properties.Resources.facial_recognition;
            this.btnStart.Iconimage_right = null;
            this.btnStart.Iconimage_right_Selected = null;
            this.btnStart.Iconimage_Selected = null;
            this.btnStart.IconMarginLeft = 20;
            this.btnStart.IconMarginRight = 0;
            this.btnStart.IconRightVisible = true;
            this.btnStart.IconRightZoom = 0D;
            this.btnStart.IconVisible = true;
            this.btnStart.IconZoom = 50D;
            this.btnStart.IsTab = true;
            this.btnStart.Location = new System.Drawing.Point(299, 111);
            this.btnStart.Name = "btnStart";
            this.btnStart.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnStart.OnHovercolor = System.Drawing.Color.Green;
            this.btnStart.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStart.selected = false;
            this.btnStart.Size = new System.Drawing.Size(107, 45);
            this.btnStart.TabIndex = 88;
            this.btnStart.Text = "Start";
            this.btnStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart.Textcolor = System.Drawing.Color.White;
            this.btnStart.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dpnDormitory
            // 
            this.dpnDormitory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.dpnDormitory.BorderRadius = 1;
            this.dpnDormitory.Color = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.dpnDormitory.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.dpnDormitory.DisabledColor = System.Drawing.Color.Gray;
            this.dpnDormitory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dpnDormitory.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.dpnDormitory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dpnDormitory.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dpnDormitory.FillDropDown = false;
            this.dpnDormitory.FillIndicator = false;
            this.dpnDormitory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dpnDormitory.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.dpnDormitory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.dpnDormitory.FormattingEnabled = true;
            this.dpnDormitory.Icon = null;
            this.dpnDormitory.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.dpnDormitory.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dpnDormitory.ItemBackColor = System.Drawing.Color.White;
            this.dpnDormitory.ItemBorderColor = System.Drawing.Color.White;
            this.dpnDormitory.ItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.dpnDormitory.ItemHeight = 26;
            this.dpnDormitory.ItemHighLightColor = System.Drawing.Color.Thistle;
            this.dpnDormitory.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.dpnDormitory.Location = new System.Drawing.Point(41, 59);
            this.dpnDormitory.Name = "dpnDormitory";
            this.dpnDormitory.Size = new System.Drawing.Size(365, 32);
            this.dpnDormitory.TabIndex = 89;
            this.dpnDormitory.Text = "Select";
            this.dpnDormitory.SelectedIndexChanged += new System.EventHandler(this.dpnDormitory_SelectedIndexChanged);
            // 
            // rollcall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.dpnDormitory);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTotalInmates);
            this.Name = "rollcall";
            this.Size = new System.Drawing.Size(450, 223);
            this.Load += new System.EventHandler(this.rollcall_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label lblTotalInmates;
        public Bunifu.Framework.UI.BunifuFlatButton btnStart;
        public Bunifu.UI.WinForms.BunifuDropdown dpnDormitory;
    }
}
