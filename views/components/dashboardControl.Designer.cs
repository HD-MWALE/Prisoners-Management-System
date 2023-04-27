namespace Prisoners_Management_System.views.components
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
            this.flowLayoutPanelRight = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DormitoryPopulationPie = new LiveCharts.WinForms.PieChart();
            this.PopulationPie = new LiveCharts.WinForms.PieChart();
            this.label6 = new System.Windows.Forms.Label();
            this.DormitoryPopulationBar = new LiveCharts.WinForms.CartesianChart();
            this.PopulationLine = new LiveCharts.WinForms.CartesianChart();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CrimesCommittedReport = new LiveCharts.WinForms.CartesianChart();
            this.panel2.SuspendLayout();
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
            this.flowLayoutPanelTop.Size = new System.Drawing.Size(455, 190);
            this.flowLayoutPanelTop.TabIndex = 8;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(58, 271);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(815, 1);
            this.bunifuSeparator2.TabIndex = 9;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // flowLayoutPanelRight
            // 
            this.flowLayoutPanelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelRight.AutoScroll = true;
            this.flowLayoutPanelRight.Location = new System.Drawing.Point(500, 75);
            this.flowLayoutPanelRight.Name = "flowLayoutPanelRight";
            this.flowLayoutPanelRight.Size = new System.Drawing.Size(385, 190);
            this.flowLayoutPanelRight.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(636, 605);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(76, 21);
            this.panel1.TabIndex = 38;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.CrimesCommittedReport);
            this.panel2.Controls.Add(this.DormitoryPopulationPie);
            this.panel2.Controls.Add(this.PopulationPie);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.DormitoryPopulationBar);
            this.panel2.Controls.Add(this.PopulationLine);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(45, 278);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 321);
            this.panel2.TabIndex = 39;
            // 
            // DormitoryPopulationPie
            // 
            this.DormitoryPopulationPie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DormitoryPopulationPie.Location = new System.Drawing.Point(402, 364);
            this.DormitoryPopulationPie.Name = "DormitoryPopulationPie";
            this.DormitoryPopulationPie.Size = new System.Drawing.Size(409, 250);
            this.DormitoryPopulationPie.TabIndex = 102;
            this.DormitoryPopulationPie.Text = "pieChart3";
            // 
            // PopulationPie
            // 
            this.PopulationPie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PopulationPie.Location = new System.Drawing.Point(402, 43);
            this.PopulationPie.Name = "PopulationPie";
            this.PopulationPie.Size = new System.Drawing.Size(400, 250);
            this.PopulationPie.TabIndex = 101;
            this.PopulationPie.Text = "pieChart1";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(257, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(288, 24);
            this.label6.TabIndex = 98;
            this.label6.Text = "Population of Inmates By Year";
            // 
            // DormitoryPopulationBar
            // 
            this.DormitoryPopulationBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DormitoryPopulationBar.BackColorTransparent = true;
            this.DormitoryPopulationBar.Location = new System.Drawing.Point(0, 364);
            this.DormitoryPopulationBar.Name = "DormitoryPopulationBar";
            this.DormitoryPopulationBar.Size = new System.Drawing.Size(396, 250);
            this.DormitoryPopulationBar.TabIndex = 96;
            this.DormitoryPopulationBar.Text = "cartesianChart3";
            // 
            // PopulationLine
            // 
            this.PopulationLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PopulationLine.BackColorTransparent = true;
            this.PopulationLine.Location = new System.Drawing.Point(0, 43);
            this.PopulationLine.Name = "PopulationLine";
            this.PopulationLine.Size = new System.Drawing.Size(396, 250);
            this.PopulationLine.TabIndex = 95;
            this.PopulationLine.Text = "PopulationBar";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(244, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(322, 24);
            this.label2.TabIndex = 97;
            this.label2.Text = "Inmates Population in Dormitories";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(280, 648);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 24);
            this.label1.TabIndex = 109;
            this.label1.Text = "Most Committed Crimes in Malawi";
            // 
            // CrimesCommittedReport
            // 
            this.CrimesCommittedReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CrimesCommittedReport.BackColorTransparent = true;
            this.CrimesCommittedReport.Location = new System.Drawing.Point(0, 681);
            this.CrimesCommittedReport.Name = "CrimesCommittedReport";
            this.CrimesCommittedReport.Size = new System.Drawing.Size(811, 250);
            this.CrimesCommittedReport.TabIndex = 108;
            this.CrimesCommittedReport.Text = "cartesianChart3";
            // 
            // dashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutPanelRight);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.flowLayoutPanelTop);
            this.Controls.Add(this.label17);
            this.Name = "dashboardControl";
            this.Size = new System.Drawing.Size(900, 645);
            this.Load += new System.EventHandler(this.dashboardControl_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTop;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        public LiveCharts.WinForms.CartesianChart DormitoryPopulationBar;
        public LiveCharts.WinForms.CartesianChart PopulationLine;
        private System.Windows.Forms.Label label2;
        private LiveCharts.WinForms.PieChart DormitoryPopulationPie;
        private LiveCharts.WinForms.PieChart PopulationPie;
        private System.Windows.Forms.Label label1;
        public LiveCharts.WinForms.CartesianChart CrimesCommittedReport;
    }
}
