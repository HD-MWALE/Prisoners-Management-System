namespace Prisoners_Management_System.views.components.dashboard
{
    partial class search
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
            this.searchflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // searchflowLayoutPanel
            // 
            this.searchflowLayoutPanel.AutoScroll = true;
            this.searchflowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchflowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.searchflowLayoutPanel.Name = "searchflowLayoutPanel";
            this.searchflowLayoutPanel.Size = new System.Drawing.Size(277, 237);
            this.searchflowLayoutPanel.TabIndex = 0;
            // 
            // search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.searchflowLayoutPanel);
            this.MaximumSize = new System.Drawing.Size(277, 237);
            this.MinimumSize = new System.Drawing.Size(277, 1);
            this.Name = "search";
            this.Size = new System.Drawing.Size(277, 237);
            this.Load += new System.EventHandler(this.search_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel searchflowLayoutPanel;
    }
}
