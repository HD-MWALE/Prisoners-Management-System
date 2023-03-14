namespace Roll_Call_And_Management_System.views.components
{
    partial class dashboardControl 
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
            this.label17 = new System.Windows.Forms.Label();
            this.flowLayoutPanelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.flowLayoutPanelBody = new System.Windows.Forms.FlowLayoutPanel();
            this.dpnMonth = new Bunifu.UI.WinForms.BunifuDropdown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Population = new LiveCharts.WinForms.CartesianChart();
            this.flowLayoutPanelBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(41, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 24);
            this.label17.TabIndex = 5;
            this.label17.Text = "Dashboard";
            // 
            // flowLayoutPanelTop
            // 
            this.flowLayoutPanelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelTop.Location = new System.Drawing.Point(45, 75);
            this.flowLayoutPanelTop.Name = "flowLayoutPanelTop";
            this.flowLayoutPanelTop.Size = new System.Drawing.Size(830, 200);
            this.flowLayoutPanelTop.TabIndex = 8;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(45, 280);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(830, 1);
            this.bunifuSeparator2.TabIndex = 9;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // flowLayoutPanelBody
            // 
            this.flowLayoutPanelBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelBody.AutoScroll = true;
            this.flowLayoutPanelBody.Controls.Add(this.Population);
            this.flowLayoutPanelBody.Location = new System.Drawing.Point(45, 323);
            this.flowLayoutPanelBody.Name = "flowLayoutPanelBody";
            this.flowLayoutPanelBody.Size = new System.Drawing.Size(830, 448);
            this.flowLayoutPanelBody.TabIndex = 9;
            // 
            // dpnMonth
            // 
            this.dpnMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dpnMonth.AutoCompleteCustomSource.AddRange(new string[] {
            "Male",
            "Female",
            "Underage"});
            this.dpnMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.dpnMonth.BorderRadius = 1;
            this.dpnMonth.Color = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.dpnMonth.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.dpnMonth.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dpnMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dpnMonth.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.dpnMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dpnMonth.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dpnMonth.FillDropDown = true;
            this.dpnMonth.FillIndicator = false;
            this.dpnMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dpnMonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dpnMonth.ForeColor = System.Drawing.Color.White;
            this.dpnMonth.FormattingEnabled = true;
            this.dpnMonth.Icon = null;
            this.dpnMonth.IndicatorColor = System.Drawing.Color.White;
            this.dpnMonth.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dpnMonth.ItemBackColor = System.Drawing.Color.White;
            this.dpnMonth.ItemBorderColor = System.Drawing.Color.White;
            this.dpnMonth.ItemForeColor = System.Drawing.Color.Black;
            this.dpnMonth.ItemHeight = 26;
            this.dpnMonth.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.dpnMonth.Items.AddRange(new object[] {
            "JANUARY",
            "FEBRUARY",
            "MARCH",
            "APRIL",
            "MAY",
            "JUNE",
            "JULY",
            "AUGUST",
            "SEPTEMBER",
            "OCTOBER",
            "NOVEMBER",
            "DECEMBER"});
            this.dpnMonth.Location = new System.Drawing.Point(580, 285);
            this.dpnMonth.Name = "dpnMonth";
            this.dpnMonth.Size = new System.Drawing.Size(295, 32);
            this.dpnMonth.TabIndex = 37;
            this.dpnMonth.Text = "Select";
            this.dpnMonth.SelectedIndexChanged += new System.EventHandler(this.dpnMonth_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(602, 777);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(76, 21);
            this.panel1.TabIndex = 38;
            // 
            // Population
            // 
            this.Population.BackColorTransparent = true;
            this.Population.Location = new System.Drawing.Point(3, 3);
            this.Population.Name = "Population";
            this.Population.Size = new System.Drawing.Size(527, 355);
            this.Population.TabIndex = 14;
            this.Population.Text = "cartesianChart4";
            // 
            // dashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dpnMonth);
            this.Controls.Add(this.flowLayoutPanelBody);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.flowLayoutPanelTop);
            this.Controls.Add(this.label17);
            this.Name = "dashboardControl";
            this.Size = new System.Drawing.Size(900, 798);
            this.Load += new System.EventHandler(this.dashboardControl_Load);
            this.flowLayoutPanelBody.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTop;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        public Bunifu.UI.WinForms.BunifuDropdown dpnMonth;
        private System.Windows.Forms.Panel panel1;
        public LiveCharts.WinForms.CartesianChart Population;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBody;
    }
}
