namespace Prisoners_Management_System.views.components.rows
{
    partial class rollcall
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
            this.btnDelete = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnView = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblNo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblScannedInmates = new System.Windows.Forms.Label();
            this.lblTotalInmates = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDormitory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Active = false;
            this.btnDelete.Activecolor = System.Drawing.Color.Green;
            this.btnDelete.BackColor = System.Drawing.Color.DarkGreen;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.ButtonText = "Delete";
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.DisabledColor = System.Drawing.Color.Gray;
            this.btnDelete.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDelete.Iconimage = global::Prisoners_Management_System.Properties.Resources.remove;
            this.btnDelete.Iconimage_right = null;
            this.btnDelete.Iconimage_right_Selected = null;
            this.btnDelete.Iconimage_Selected = null;
            this.btnDelete.IconMarginLeft = 8;
            this.btnDelete.IconMarginRight = 0;
            this.btnDelete.IconRightVisible = true;
            this.btnDelete.IconRightZoom = 0D;
            this.btnDelete.IconVisible = true;
            this.btnDelete.IconZoom = 40D;
            this.btnDelete.IsTab = true;
            this.btnDelete.Location = new System.Drawing.Point(909, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnDelete.OnHovercolor = System.Drawing.Color.Green;
            this.btnDelete.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDelete.selected = false;
            this.btnDelete.Size = new System.Drawing.Size(85, 45);
            this.btnDelete.TabIndex = 91;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Textcolor = System.Drawing.Color.White;
            this.btnDelete.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnView
            // 
            this.btnView.Active = false;
            this.btnView.Activecolor = System.Drawing.Color.Green;
            this.btnView.BackColor = System.Drawing.Color.DarkGreen;
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnView.BorderRadius = 5;
            this.btnView.ButtonText = "View";
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.DisabledColor = System.Drawing.Color.Gray;
            this.btnView.Iconcolor = System.Drawing.Color.Transparent;
            this.btnView.Iconimage = global::Prisoners_Management_System.Properties.Resources.view;
            this.btnView.Iconimage_right = null;
            this.btnView.Iconimage_right_Selected = null;
            this.btnView.Iconimage_Selected = null;
            this.btnView.IconMarginLeft = 12;
            this.btnView.IconMarginRight = 0;
            this.btnView.IconRightVisible = true;
            this.btnView.IconRightZoom = 0D;
            this.btnView.IconVisible = true;
            this.btnView.IconZoom = 40D;
            this.btnView.IsTab = true;
            this.btnView.Location = new System.Drawing.Point(818, 0);
            this.btnView.Name = "btnView";
            this.btnView.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnView.OnHovercolor = System.Drawing.Color.Green;
            this.btnView.OnHoverTextColor = System.Drawing.Color.White;
            this.btnView.selected = false;
            this.btnView.Size = new System.Drawing.Size(85, 45);
            this.btnView.TabIndex = 90;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Textcolor = System.Drawing.Color.White;
            this.btnView.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // lblNo
            // 
            this.lblNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNo.AutoSize = true;
            this.lblNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNo.ForeColor = System.Drawing.Color.White;
            this.lblNo.Location = new System.Drawing.Point(4, 16);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(27, 16);
            this.lblNo.TabIndex = 103;
            this.lblNo.Text = "No";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(266, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 16);
            this.lblDate.TabIndex = 102;
            this.lblDate.Text = "Date";
            // 
            // lblScannedInmates
            // 
            this.lblScannedInmates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScannedInmates.AutoSize = true;
            this.lblScannedInmates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannedInmates.ForeColor = System.Drawing.Color.White;
            this.lblScannedInmates.Location = new System.Drawing.Point(721, 16);
            this.lblScannedInmates.Name = "lblScannedInmates";
            this.lblScannedInmates.Size = new System.Drawing.Size(68, 16);
            this.lblScannedInmates.TabIndex = 101;
            this.lblScannedInmates.Text = "Scanned";
            // 
            // lblTotalInmates
            // 
            this.lblTotalInmates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalInmates.AutoSize = true;
            this.lblTotalInmates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInmates.ForeColor = System.Drawing.Color.White;
            this.lblTotalInmates.Location = new System.Drawing.Point(649, 16);
            this.lblTotalInmates.Name = "lblTotalInmates";
            this.lblTotalInmates.Size = new System.Drawing.Size(43, 16);
            this.lblTotalInmates.TabIndex = 100;
            this.lblTotalInmates.Text = "Total";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(561, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 16);
            this.lblStatus.TabIndex = 99;
            this.lblStatus.Text = "Status";
            // 
            // lblCode
            // 
            this.lblCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.ForeColor = System.Drawing.Color.White;
            this.lblCode.Location = new System.Drawing.Point(49, 16);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(44, 16);
            this.lblCode.TabIndex = 98;
            this.lblCode.Text = "Code";
            // 
            // lblDormitory
            // 
            this.lblDormitory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDormitory.AutoSize = true;
            this.lblDormitory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDormitory.ForeColor = System.Drawing.Color.White;
            this.lblDormitory.Location = new System.Drawing.Point(446, 16);
            this.lblDormitory.Name = "lblDormitory";
            this.lblDormitory.Size = new System.Drawing.Size(74, 16);
            this.lblDormitory.TabIndex = 97;
            this.lblDormitory.Text = "Dormitory";
            // 
            // rollcall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.lblNo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblScannedInmates);
            this.Controls.Add(this.lblTotalInmates);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblDormitory);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnView);
            this.Name = "rollcall";
            this.Size = new System.Drawing.Size(1000, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Bunifu.Framework.UI.BunifuFlatButton btnDelete;
        public Bunifu.Framework.UI.BunifuFlatButton btnView;
        public System.Windows.Forms.Label lblNo;
        public System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.Label lblScannedInmates;
        public System.Windows.Forms.Label lblTotalInmates;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.Label lblCode;
        public System.Windows.Forms.Label lblDormitory;
    }
}
