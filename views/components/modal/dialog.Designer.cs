namespace Prisoners_Management_System.views.components.modal
{
    partial class dialog
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
            this.SecondaryButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Icon = new Bunifu.Framework.UI.BunifuImageButton();
            this.PrimaryButton = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Message = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // SecondaryButton
            // 
            this.SecondaryButton.Active = false;
            this.SecondaryButton.Activecolor = System.Drawing.Color.Firebrick;
            this.SecondaryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SecondaryButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.SecondaryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SecondaryButton.BorderRadius = 5;
            this.SecondaryButton.ButtonText = "Cancel";
            this.SecondaryButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SecondaryButton.DisabledColor = System.Drawing.Color.Gray;
            this.SecondaryButton.Iconcolor = System.Drawing.Color.Transparent;
            this.SecondaryButton.Iconimage = null;
            this.SecondaryButton.Iconimage_right = null;
            this.SecondaryButton.Iconimage_right_Selected = null;
            this.SecondaryButton.Iconimage_Selected = null;
            this.SecondaryButton.IconMarginLeft = 0;
            this.SecondaryButton.IconMarginRight = 0;
            this.SecondaryButton.IconRightVisible = true;
            this.SecondaryButton.IconRightZoom = 0D;
            this.SecondaryButton.IconVisible = false;
            this.SecondaryButton.IconZoom = 50D;
            this.SecondaryButton.IsTab = true;
            this.SecondaryButton.Location = new System.Drawing.Point(234, 116);
            this.SecondaryButton.Name = "SecondaryButton";
            this.SecondaryButton.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.SecondaryButton.OnHovercolor = System.Drawing.Color.Firebrick;
            this.SecondaryButton.OnHoverTextColor = System.Drawing.Color.White;
            this.SecondaryButton.selected = false;
            this.SecondaryButton.Size = new System.Drawing.Size(70, 26);
            this.SecondaryButton.TabIndex = 18;
            this.SecondaryButton.Text = "Cancel";
            this.SecondaryButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SecondaryButton.Textcolor = System.Drawing.Color.White;
            this.SecondaryButton.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.SecondaryButton.Click += new System.EventHandler(this.SecondaryButton_Click);
            // 
            // Icon
            // 
            this.Icon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Icon.Image = global::Prisoners_Management_System.Properties.Resources.info;
            this.Icon.ImageActive = null;
            this.Icon.Location = new System.Drawing.Point(13, 13);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(51, 48);
            this.Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Icon.TabIndex = 16;
            this.Icon.TabStop = false;
            this.Icon.Zoom = 0;
            // 
            // PrimaryButton
            // 
            this.PrimaryButton.Active = false;
            this.PrimaryButton.Activecolor = System.Drawing.Color.Green;
            this.PrimaryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PrimaryButton.BackColor = System.Drawing.Color.DarkGreen;
            this.PrimaryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PrimaryButton.BorderRadius = 5;
            this.PrimaryButton.ButtonText = "Retry";
            this.PrimaryButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrimaryButton.DisabledColor = System.Drawing.Color.Gray;
            this.PrimaryButton.Iconcolor = System.Drawing.Color.Transparent;
            this.PrimaryButton.Iconimage = null;
            this.PrimaryButton.Iconimage_right = null;
            this.PrimaryButton.Iconimage_right_Selected = null;
            this.PrimaryButton.Iconimage_Selected = null;
            this.PrimaryButton.IconMarginLeft = 20;
            this.PrimaryButton.IconMarginRight = 0;
            this.PrimaryButton.IconRightVisible = true;
            this.PrimaryButton.IconRightZoom = 0D;
            this.PrimaryButton.IconVisible = true;
            this.PrimaryButton.IconZoom = 50D;
            this.PrimaryButton.IsTab = true;
            this.PrimaryButton.Location = new System.Drawing.Point(148, 116);
            this.PrimaryButton.Name = "PrimaryButton";
            this.PrimaryButton.Normalcolor = System.Drawing.Color.DarkGreen;
            this.PrimaryButton.OnHovercolor = System.Drawing.Color.Green;
            this.PrimaryButton.OnHoverTextColor = System.Drawing.Color.White;
            this.PrimaryButton.selected = false;
            this.PrimaryButton.Size = new System.Drawing.Size(70, 26);
            this.PrimaryButton.TabIndex = 31;
            this.PrimaryButton.Text = "Retry";
            this.PrimaryButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PrimaryButton.Textcolor = System.Drawing.Color.White;
            this.PrimaryButton.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.PrimaryButton.Click += new System.EventHandler(this.PrimaryButton_Click);
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.ForeColor = System.Drawing.Color.White;
            this.Message.Location = new System.Drawing.Point(70, 28);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(61, 17);
            this.Message.TabIndex = 32;
            this.Message.Text = "Message";
            // 
            // dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.Message);
            this.Controls.Add(this.PrimaryButton);
            this.Controls.Add(this.SecondaryButton);
            this.Controls.Add(this.Icon);
            this.Name = "dialog";
            this.Size = new System.Drawing.Size(327, 162);
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Bunifu.Framework.UI.BunifuFlatButton SecondaryButton;
        public Bunifu.Framework.UI.BunifuFlatButton PrimaryButton;
        public Bunifu.Framework.UI.BunifuImageButton Icon;
        public System.Windows.Forms.Label Message;
    }
}
