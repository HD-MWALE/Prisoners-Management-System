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
            this.Population = new LiveCharts.WinForms.CartesianChart();
            this.DormitoryPopulation = new LiveCharts.WinForms.CartesianChart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelRight = new System.Windows.Forms.FlowLayoutPanel();
            this.CrimesCommitted = new LiveCharts.WinForms.CartesianChart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.flowLayoutPanelTop.Size = new System.Drawing.Size(453, 190);
            this.flowLayoutPanelTop.TabIndex = 8;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(45, 271);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(815, 1);
            this.bunifuSeparator2.TabIndex = 9;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // Population
            // 
            this.Population.BackColor = System.Drawing.Color.Transparent;
            this.Population.BackColorTransparent = true;
            this.Population.Location = new System.Drawing.Point(12, 34);
            this.Population.Name = "Population";
            this.Population.Size = new System.Drawing.Size(527, 355);
            this.Population.TabIndex = 14;
            this.Population.Text = "cartesianChart4";
            // 
            // DormitoryPopulation
            // 
            this.DormitoryPopulation.BackColor = System.Drawing.Color.Transparent;
            this.DormitoryPopulation.BackColorTransparent = true;
            this.DormitoryPopulation.Location = new System.Drawing.Point(545, 34);
            this.DormitoryPopulation.Name = "DormitoryPopulation";
            this.DormitoryPopulation.Size = new System.Drawing.Size(527, 355);
            this.DormitoryPopulation.TabIndex = 15;
            this.DormitoryPopulation.Text = "cartesianChart4";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(602, 777);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(76, 21);
            this.panel1.TabIndex = 38;
            // 
            // flowLayoutPanelRight
            // 
            this.flowLayoutPanelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelRight.AutoScroll = true;
            this.flowLayoutPanelRight.Location = new System.Drawing.Point(498, 75);
            this.flowLayoutPanelRight.Name = "flowLayoutPanelRight";
            this.flowLayoutPanelRight.Size = new System.Drawing.Size(385, 190);
            this.flowLayoutPanelRight.TabIndex = 9;
            // 
            // CrimesCommitted
            // 
            this.CrimesCommitted.BackColor = System.Drawing.Color.Transparent;
            this.CrimesCommitted.BackColorTransparent = true;
            this.CrimesCommitted.Location = new System.Drawing.Point(12, 438);
            this.CrimesCommitted.Name = "CrimesCommitted";
            this.CrimesCommitted.Size = new System.Drawing.Size(527, 355);
            this.CrimesCommitted.TabIndex = 16;
            this.CrimesCommitted.Text = "cartesianChart4";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.Population);
            this.panel2.Controls.Add(this.CrimesCommitted);
            this.panel2.Controls.Add(this.DormitoryPopulation);
            this.panel2.Location = new System.Drawing.Point(45, 278);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(815, 493);
            this.panel2.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(140, 411);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(281, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "MOST COMMITTED CRIMES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(617, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(410, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "INMATES POPULATION IN DORMITORIES";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(177, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "INMATES POPULATION";
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
            this.Size = new System.Drawing.Size(900, 798);
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
        private System.Windows.Forms.Panel panel1;
        public LiveCharts.WinForms.CartesianChart Population;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelRight;
        public LiveCharts.WinForms.CartesianChart DormitoryPopulation;
        public LiveCharts.WinForms.CartesianChart CrimesCommitted;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
