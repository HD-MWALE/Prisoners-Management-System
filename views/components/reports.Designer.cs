namespace Roll_Call_And_Management_System.views.components
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
            this.flowLayoutPanelBody = new System.Windows.Forms.FlowLayoutPanel();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChart3 = new LiveCharts.WinForms.CartesianChart();
            this.label17 = new System.Windows.Forms.Label();
            this.flowLayoutPanelBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanelBody
            // 
            this.flowLayoutPanelBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelBody.AutoScroll = true;
            this.flowLayoutPanelBody.Controls.Add(this.cartesianChart1);
            this.flowLayoutPanelBody.Controls.Add(this.pieChart1);
            this.flowLayoutPanelBody.Controls.Add(this.cartesianChart2);
            this.flowLayoutPanelBody.Controls.Add(this.cartesianChart3);
            this.flowLayoutPanelBody.Location = new System.Drawing.Point(45, 72);
            this.flowLayoutPanelBody.Name = "flowLayoutPanelBody";
            this.flowLayoutPanelBody.Size = new System.Drawing.Size(801, 382);
            this.flowLayoutPanelBody.TabIndex = 10;
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColorTransparent = true;
            this.cartesianChart1.Location = new System.Drawing.Point(3, 3);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(527, 355);
            this.cartesianChart1.TabIndex = 9;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // pieChart1
            // 
            this.pieChart1.BackColorTransparent = true;
            this.pieChart1.Location = new System.Drawing.Point(3, 364);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(527, 355);
            this.pieChart1.TabIndex = 10;
            this.pieChart1.Text = "pieChart1";
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.BackColorTransparent = true;
            this.cartesianChart2.Location = new System.Drawing.Point(3, 725);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(527, 355);
            this.cartesianChart2.TabIndex = 11;
            this.cartesianChart2.Text = "cartesianChart2";
            // 
            // cartesianChart3
            // 
            this.cartesianChart3.BackColorTransparent = true;
            this.cartesianChart3.Location = new System.Drawing.Point(3, 1086);
            this.cartesianChart3.Name = "cartesianChart3";
            this.cartesianChart3.Size = new System.Drawing.Size(527, 355);
            this.cartesianChart3.TabIndex = 12;
            this.cartesianChart3.Text = "cartesianChart3";
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
            // reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.label17);
            this.Controls.Add(this.flowLayoutPanelBody);
            this.Name = "reports";
            this.Size = new System.Drawing.Size(900, 480);
            this.Load += new System.EventHandler(this.reports_Load);
            this.flowLayoutPanelBody.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBody;
        private System.Windows.Forms.Label label17;
        public LiveCharts.WinForms.CartesianChart cartesianChart1;
        public LiveCharts.WinForms.PieChart pieChart1;
        public LiveCharts.WinForms.CartesianChart cartesianChart2;
        public LiveCharts.WinForms.CartesianChart cartesianChart3;
    }
}
