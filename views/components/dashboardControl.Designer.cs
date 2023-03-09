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
            System.Windows.Forms.DataVisualization.Charting.LineAnnotation lineAnnotation1 = new System.Windows.Forms.DataVisualization.Charting.LineAnnotation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label17 = new System.Windows.Forms.Label();
            this.chartInmatesInDormitories = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.flowLayoutPanelBody = new System.Windows.Forms.FlowLayoutPanel();
            this.chartCrimesCommitted = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dpnMonth = new Bunifu.UI.WinForms.BunifuDropdown();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chartInmatesInDormitories)).BeginInit();
            this.flowLayoutPanelBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCrimesCommitted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
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
            // chartInmatesInDormitories
            // 
            lineAnnotation1.Name = "LineAnnotation1";
            this.chartInmatesInDormitories.Annotations.Add(lineAnnotation1);
            chartArea1.Name = "ChartArea1";
            this.chartInmatesInDormitories.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartInmatesInDormitories.Legends.Add(legend1);
            this.chartInmatesInDormitories.Location = new System.Drawing.Point(5, 5);
            this.chartInmatesInDormitories.Margin = new System.Windows.Forms.Padding(5);
            this.chartInmatesInDormitories.Name = "chartInmatesInDormitories";
            this.chartInmatesInDormitories.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Dormitory";
            this.chartInmatesInDormitories.Series.Add(series1);
            this.chartInmatesInDormitories.Size = new System.Drawing.Size(355, 355);
            this.chartInmatesInDormitories.TabIndex = 6;
            this.chartInmatesInDormitories.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Number of Inmates In Dormitories";
            this.chartInmatesInDormitories.Titles.Add(title1);
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
            this.flowLayoutPanelBody.Controls.Add(this.chartInmatesInDormitories);
            this.flowLayoutPanelBody.Controls.Add(this.chartCrimesCommitted);
            this.flowLayoutPanelBody.Controls.Add(this.chart1);
            this.flowLayoutPanelBody.Location = new System.Drawing.Point(45, 323);
            this.flowLayoutPanelBody.Name = "flowLayoutPanelBody";
            this.flowLayoutPanelBody.Size = new System.Drawing.Size(830, 448);
            this.flowLayoutPanelBody.TabIndex = 9;
            // 
            // chartCrimesCommitted
            // 
            chartArea2.Name = "ChartArea1";
            this.chartCrimesCommitted.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartCrimesCommitted.Legends.Add(legend2);
            this.chartCrimesCommitted.Location = new System.Drawing.Point(5, 370);
            this.chartCrimesCommitted.Margin = new System.Windows.Forms.Padding(5);
            this.chartCrimesCommitted.Name = "chartCrimesCommitted";
            this.chartCrimesCommitted.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Inmates";
            this.chartCrimesCommitted.Series.Add(series2);
            this.chartCrimesCommitted.Size = new System.Drawing.Size(700, 355);
            this.chartCrimesCommitted.TabIndex = 7;
            this.chartCrimesCommitted.Text = "chart2";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Crimes Committed By Inmates";
            this.chartCrimesCommitted.Titles.Add(title2);
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(5, 735);
            this.chart1.Margin = new System.Windows.Forms.Padding(5);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Dormitory";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(355, 355);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart2";
            title3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Title1";
            title3.Text = "Crimes Committed By Inmates";
            this.chart1.Titles.Add(title3);
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
            ((System.ComponentModel.ISupportInitialize)(this.chartInmatesInDormitories)).EndInit();
            this.flowLayoutPanelBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCrimesCommitted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTop;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBody;
        public Bunifu.UI.WinForms.BunifuDropdown dpnMonth;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartInmatesInDormitories;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartCrimesCommitted;
    }
}
