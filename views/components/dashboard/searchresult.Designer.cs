namespace Roll_Call_And_Management_System.views.components.dashboard
{
    partial class searchresult
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
            this.Result = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // Result
            // 
            this.Result.Active = true;
            this.Result.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.Result.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.Result.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Result.BorderRadius = 5;
            this.Result.ButtonText = "  Profile";
            this.Result.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Result.DisabledColor = System.Drawing.Color.Gray;
            this.Result.Iconcolor = System.Drawing.Color.Transparent;
            this.Result.Iconimage = null;
            this.Result.Iconimage_right = null;
            this.Result.Iconimage_right_Selected = null;
            this.Result.Iconimage_Selected = null;
            this.Result.IconMarginLeft = 13;
            this.Result.IconMarginRight = 0;
            this.Result.IconRightVisible = true;
            this.Result.IconRightZoom = 0D;
            this.Result.IconVisible = true;
            this.Result.IconZoom = 50D;
            this.Result.IsTab = true;
            this.Result.Location = new System.Drawing.Point(0, 0);
            this.Result.Name = "Result";
            this.Result.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.Result.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.Result.OnHoverTextColor = System.Drawing.Color.White;
            this.Result.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Result.selected = true;
            this.Result.Size = new System.Drawing.Size(277, 32);
            this.Result.TabIndex = 10;
            this.Result.Text = "  Profile";
            this.Result.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Result.Textcolor = System.Drawing.Color.White;
            this.Result.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            // 
            // searchresult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Result);
            this.Name = "searchresult";
            this.Size = new System.Drawing.Size(277, 32);
            this.ResumeLayout(false);

        }

        #endregion

        public Bunifu.Framework.UI.BunifuFlatButton Result;
    }
}
