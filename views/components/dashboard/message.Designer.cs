namespace Prisoners_Management_System.views.components.dashboard
{
    partial class message
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.Icon = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(43, 30);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(61, 17);
            this.lblMessage.TabIndex = 63;
            this.lblMessage.Text = "Message";
            this.lblMessage.Click += new System.EventHandler(this.message_Click);
            this.lblMessage.MouseLeave += new System.EventHandler(this.message_MouseLeave);
            this.lblMessage.MouseHover += new System.EventHandler(this.message_MouseHover);
            // 
            // Icon
            // 
            this.Icon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon.Image = global::Prisoners_Management_System.Properties.Resources.checked_user;
            this.Icon.ImageActive = null;
            this.Icon.Location = new System.Drawing.Point(8, 13);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(32, 32);
            this.Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon.TabIndex = 64;
            this.Icon.TabStop = false;
            this.Icon.Zoom = 11;
            this.Icon.Click += new System.EventHandler(this.message_Click);
            this.Icon.MouseLeave += new System.EventHandler(this.message_MouseLeave);
            this.Icon.MouseHover += new System.EventHandler(this.message_MouseHover);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(43, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(44, 21);
            this.lblTitle.TabIndex = 65;
            this.lblTitle.Text = "Title";
            this.lblTitle.Click += new System.EventHandler(this.message_Click);
            this.lblTitle.MouseEnter += new System.EventHandler(this.message_MouseHover);
            this.lblTitle.MouseHover += new System.EventHandler(this.message_MouseLeave);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(43, 50);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 17);
            this.lblDate.TabIndex = 66;
            this.lblDate.Text = "Date";
            // 
            // message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.Icon);
            this.Controls.Add(this.lblMessage);
            this.Name = "message";
            this.Size = new System.Drawing.Size(300, 75);
            this.Load += new System.EventHandler(this.message_Load);
            this.Click += new System.EventHandler(this.message_Click);
            this.MouseLeave += new System.EventHandler(this.message_MouseLeave);
            this.MouseHover += new System.EventHandler(this.message_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblMessage;
        public Bunifu.Framework.UI.BunifuImageButton Icon;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblDate;
    }
}
