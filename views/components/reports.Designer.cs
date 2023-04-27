namespace Prisoners_Management_System.views.components
{
    partial class reports
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label1 = new System.Windows.Forms.Label();
            this.CrimesCommittedReport = new LiveCharts.WinForms.CartesianChart();
            this.DormitoryPopulationPie = new LiveCharts.WinForms.PieChart();
            this.DormitoryPopulationBar = new LiveCharts.WinForms.CartesianChart();
            this.PopulationPie = new LiveCharts.WinForms.PieChart();
            this.PopulationLine = new LiveCharts.WinForms.CartesianChart();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(45, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(174, 24);
            this.label17.TabIndex = 82;
            this.label17.Text = "Statistical Reports";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.bunifuSeparator1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CrimesCommittedReport);
            this.panel1.Controls.Add(this.DormitoryPopulationPie);
            this.panel1.Controls.Add(this.DormitoryPopulationBar);
            this.panel1.Controls.Add(this.PopulationPie);
            this.panel1.Controls.Add(this.PopulationLine);
            this.panel1.Controls.Add(this.bunifuSeparator2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(49, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 491);
            this.panel1.TabIndex = 83;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(-24, 664);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(968, 10);
            this.bunifuSeparator1.TabIndex = 108;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(315, 699);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 24);
            this.label1.TabIndex = 107;
            this.label1.Text = "Most Committed Crimes in Malawi";
            // 
            // CrimesCommittedReport
            // 
            this.CrimesCommittedReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CrimesCommittedReport.BackColorTransparent = true;
            this.CrimesCommittedReport.Location = new System.Drawing.Point(3, 726);
            this.CrimesCommittedReport.Name = "CrimesCommittedReport";
            this.CrimesCommittedReport.Size = new System.Drawing.Size(905, 250);
            this.CrimesCommittedReport.TabIndex = 106;
            this.CrimesCommittedReport.Text = "cartesianChart3";
            // 
            // DormitoryPopulationPie
            // 
            this.DormitoryPopulationPie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DormitoryPopulationPie.Location = new System.Drawing.Point(499, 373);
            this.DormitoryPopulationPie.Name = "DormitoryPopulationPie";
            this.DormitoryPopulationPie.Size = new System.Drawing.Size(409, 250);
            this.DormitoryPopulationPie.TabIndex = 105;
            this.DormitoryPopulationPie.Text = "pieChart3";
            // 
            // DormitoryPopulationBar
            // 
            this.DormitoryPopulationBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DormitoryPopulationBar.BackColorTransparent = true;
            this.DormitoryPopulationBar.Location = new System.Drawing.Point(3, 373);
            this.DormitoryPopulationBar.Name = "DormitoryPopulationBar";
            this.DormitoryPopulationBar.Size = new System.Drawing.Size(490, 250);
            this.DormitoryPopulationBar.TabIndex = 104;
            this.DormitoryPopulationBar.Text = "cartesianChart3";
            // 
            // PopulationPie
            // 
            this.PopulationPie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PopulationPie.Location = new System.Drawing.Point(499, 38);
            this.PopulationPie.Name = "PopulationPie";
            this.PopulationPie.Size = new System.Drawing.Size(400, 250);
            this.PopulationPie.TabIndex = 103;
            this.PopulationPie.Text = "pieChart1";
            // 
            // PopulationLine
            // 
            this.PopulationLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PopulationLine.BackColorTransparent = true;
            this.PopulationLine.Location = new System.Drawing.Point(3, 38);
            this.PopulationLine.Name = "PopulationLine";
            this.PopulationLine.Size = new System.Drawing.Size(490, 250);
            this.PopulationLine.TabIndex = 102;
            this.PopulationLine.Text = "PopulationBar";
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(0, 317);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(968, 10);
            this.bunifuSeparator2.TabIndex = 91;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(345, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(275, 24);
            this.label6.TabIndex = 90;
            this.label6.Text = "Population of Prison Inmates";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(266, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(410, 24);
            this.label2.TabIndex = 84;
            this.label2.Text = "Population of Prison Inmates in Dormitories";
            // 
            // reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label17);
            this.Name = "reports";
            this.Size = new System.Drawing.Size(1017, 589);
            this.Load += new System.EventHandler(this.reports_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private LiveCharts.WinForms.PieChart PopulationPie;
        public LiveCharts.WinForms.CartesianChart PopulationLine;
        private LiveCharts.WinForms.PieChart DormitoryPopulationPie;
        public LiveCharts.WinForms.CartesianChart DormitoryPopulationBar;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label label1;
        public LiveCharts.WinForms.CartesianChart CrimesCommittedReport;
    }
}
