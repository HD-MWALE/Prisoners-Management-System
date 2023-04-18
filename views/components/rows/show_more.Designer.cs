namespace Prisoners_Management_System.views.components.rows
{
    partial class show_more
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
            this.lblShowmore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblShowmore
            // 
            this.lblShowmore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowmore.AutoSize = true;
            this.lblShowmore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowmore.ForeColor = System.Drawing.Color.White;
            this.lblShowmore.Location = new System.Drawing.Point(43, 8);
            this.lblShowmore.Name = "lblShowmore";
            this.lblShowmore.Size = new System.Drawing.Size(83, 16);
            this.lblShowmore.TabIndex = 81;
            this.lblShowmore.Text = "Show More";
            // 
            // show_more
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.lblShowmore);
            this.Name = "show_more";
            this.Size = new System.Drawing.Size(1000, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblShowmore;
    }
}
