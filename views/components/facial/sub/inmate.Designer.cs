namespace Prisoners_Management_System.views.components.facial.sub
{
    partial class inmate
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
            this.lblInmate = new System.Windows.Forms.Label();
            this.Icon = new Bunifu.Framework.UI.BunifuImageButton();
            this.Cancel = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnCheck = new Bunifu.Framework.UI.BunifuImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInmate
            // 
            this.lblInmate.AutoSize = true;
            this.lblInmate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.lblInmate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInmate.ForeColor = System.Drawing.Color.White;
            this.lblInmate.Location = new System.Drawing.Point(36, 7);
            this.lblInmate.Name = "lblInmate";
            this.lblInmate.Size = new System.Drawing.Size(51, 15);
            this.lblInmate.TabIndex = 28;
            this.lblInmate.Text = "Inmate";
            // 
            // Icon
            // 
            this.Icon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon.Image = global::Prisoners_Management_System.Properties.Resources.checked_user;
            this.Icon.ImageActive = null;
            this.Icon.Location = new System.Drawing.Point(2, 2);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(25, 25);
            this.Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon.TabIndex = 29;
            this.Icon.TabStop = false;
            this.Icon.Zoom = 11;
            // 
            // Cancel
            // 
            this.Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel.Image = global::Prisoners_Management_System.Properties.Resources.cancel;
            this.Cancel.ImageActive = null;
            this.Cancel.Location = new System.Drawing.Point(262, 2);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(25, 25);
            this.Cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Cancel.TabIndex = 30;
            this.Cancel.TabStop = false;
            this.Cancel.Zoom = 11;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.Image = global::Prisoners_Management_System.Properties.Resources.ok;
            this.btnCheck.ImageActive = null;
            this.btnCheck.Location = new System.Drawing.Point(133, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(25, 25);
            this.btnCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCheck.TabIndex = 31;
            this.btnCheck.TabStop = false;
            this.btnCheck.Zoom = 11;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // inmate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Icon);
            this.Controls.Add(this.lblInmate);
            this.Name = "inmate";
            this.Size = new System.Drawing.Size(290, 30);
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblInmate;
        public Bunifu.Framework.UI.BunifuImageButton Icon;
        public Bunifu.Framework.UI.BunifuImageButton Cancel;
        public Bunifu.Framework.UI.BunifuImageButton btnCheck;
    }
}
