namespace Prisoners_Management_System.views.components.inputs
{
    partial class pardonedlist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pardonedlist));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            this.lblTotalInmates = new System.Windows.Forms.Label();
            this.btnComeUpWithList = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtReason = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.btnView = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // lblTotalInmates
            // 
            this.lblTotalInmates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalInmates.AutoSize = true;
            this.lblTotalInmates.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalInmates.ForeColor = System.Drawing.Color.White;
            this.lblTotalInmates.Location = new System.Drawing.Point(37, 35);
            this.lblTotalInmates.Name = "lblTotalInmates";
            this.lblTotalInmates.Size = new System.Drawing.Size(215, 21);
            this.lblTotalInmates.TabIndex = 87;
            this.lblTotalInmates.Text = "Reason to Pardorn Inmates";
            // 
            // btnComeUpWithList
            // 
            this.btnComeUpWithList.Active = false;
            this.btnComeUpWithList.Activecolor = System.Drawing.Color.Green;
            this.btnComeUpWithList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnComeUpWithList.BackColor = System.Drawing.Color.DarkGreen;
            this.btnComeUpWithList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnComeUpWithList.BorderRadius = 5;
            this.btnComeUpWithList.ButtonText = "Come Up With List";
            this.btnComeUpWithList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComeUpWithList.DisabledColor = System.Drawing.Color.Gray;
            this.btnComeUpWithList.Iconcolor = System.Drawing.Color.Transparent;
            this.btnComeUpWithList.Iconimage = global::Prisoners_Management_System.Properties.Resources.add_list;
            this.btnComeUpWithList.Iconimage_right = null;
            this.btnComeUpWithList.Iconimage_right_Selected = null;
            this.btnComeUpWithList.Iconimage_Selected = null;
            this.btnComeUpWithList.IconMarginLeft = 20;
            this.btnComeUpWithList.IconMarginRight = 0;
            this.btnComeUpWithList.IconRightVisible = true;
            this.btnComeUpWithList.IconRightZoom = 0D;
            this.btnComeUpWithList.IconVisible = true;
            this.btnComeUpWithList.IconZoom = 50D;
            this.btnComeUpWithList.IsTab = true;
            this.btnComeUpWithList.Location = new System.Drawing.Point(210, 121);
            this.btnComeUpWithList.Name = "btnComeUpWithList";
            this.btnComeUpWithList.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnComeUpWithList.OnHovercolor = System.Drawing.Color.Green;
            this.btnComeUpWithList.OnHoverTextColor = System.Drawing.Color.White;
            this.btnComeUpWithList.selected = false;
            this.btnComeUpWithList.Size = new System.Drawing.Size(196, 45);
            this.btnComeUpWithList.TabIndex = 88;
            this.btnComeUpWithList.Text = "Come Up With List";
            this.btnComeUpWithList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComeUpWithList.Textcolor = System.Drawing.Color.White;
            this.btnComeUpWithList.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnComeUpWithList.Click += new System.EventHandler(this.btnComeUpWithList_Click);
            // 
            // txtReason
            // 
            this.txtReason.AcceptsReturn = false;
            this.txtReason.AcceptsTab = false;
            this.txtReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReason.AnimationSpeed = 200;
            this.txtReason.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtReason.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtReason.BackColor = System.Drawing.Color.White;
            this.txtReason.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtReason.BackgroundImage")));
            this.txtReason.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtReason.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtReason.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtReason.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtReason.BorderRadius = 1;
            this.txtReason.BorderThickness = 1;
            this.txtReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtReason.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReason.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.txtReason.DefaultText = "";
            this.txtReason.FillColor = System.Drawing.Color.White;
            this.txtReason.HideSelection = true;
            this.txtReason.IconLeft = null;
            this.txtReason.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReason.IconPadding = 10;
            this.txtReason.IconRight = null;
            this.txtReason.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReason.Lines = new string[0];
            this.txtReason.Location = new System.Drawing.Point(41, 60);
            this.txtReason.MaxLength = 32767;
            this.txtReason.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtReason.Modified = false;
            this.txtReason.Multiline = false;
            this.txtReason.Name = "txtReason";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtReason.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.Empty;
            stateProperties6.FillColor = System.Drawing.Color.White;
            stateProperties6.ForeColor = System.Drawing.Color.Empty;
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtReason.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtReason.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtReason.OnIdleState = stateProperties8;
            this.txtReason.PasswordChar = '\0';
            this.txtReason.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtReason.PlaceholderText = "Enter Reason";
            this.txtReason.ReadOnly = false;
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtReason.SelectedText = "";
            this.txtReason.SelectionLength = 0;
            this.txtReason.SelectionStart = 0;
            this.txtReason.ShortcutsEnabled = true;
            this.txtReason.Size = new System.Drawing.Size(365, 45);
            this.txtReason.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Material;
            this.txtReason.TabIndex = 140;
            this.txtReason.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtReason.TextMarginBottom = 0;
            this.txtReason.TextMarginLeft = 5;
            this.txtReason.TextMarginTop = 0;
            this.txtReason.TextPlaceholder = "Enter Reason";
            this.txtReason.UseSystemPasswordChar = false;
            this.txtReason.WordWrap = true;
            // 
            // btnView
            // 
            this.btnView.Active = false;
            this.btnView.Activecolor = System.Drawing.Color.Green;
            this.btnView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnView.BackColor = System.Drawing.Color.DarkGreen;
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnView.BorderRadius = 5;
            this.btnView.ButtonText = "View";
            this.btnView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnView.DisabledColor = System.Drawing.Color.Gray;
            this.btnView.Iconcolor = System.Drawing.Color.Transparent;
            this.btnView.Iconimage = global::Prisoners_Management_System.Properties.Resources.list;
            this.btnView.Iconimage_right = null;
            this.btnView.Iconimage_right_Selected = null;
            this.btnView.Iconimage_Selected = null;
            this.btnView.IconMarginLeft = 20;
            this.btnView.IconMarginRight = 0;
            this.btnView.IconRightVisible = true;
            this.btnView.IconRightZoom = 0D;
            this.btnView.IconVisible = true;
            this.btnView.IconZoom = 50D;
            this.btnView.IsTab = true;
            this.btnView.Location = new System.Drawing.Point(41, 121);
            this.btnView.Name = "btnView";
            this.btnView.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnView.OnHovercolor = System.Drawing.Color.Green;
            this.btnView.OnHoverTextColor = System.Drawing.Color.White;
            this.btnView.selected = false;
            this.btnView.Size = new System.Drawing.Size(105, 45);
            this.btnView.TabIndex = 141;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Textcolor = System.Drawing.Color.White;
            this.btnView.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // pardonedlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.btnComeUpWithList);
            this.Controls.Add(this.lblTotalInmates);
            this.Name = "pardonedlist";
            this.Size = new System.Drawing.Size(450, 223);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblTotalInmates;
        public Bunifu.Framework.UI.BunifuFlatButton btnComeUpWithList;
        public Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtReason;
        public Bunifu.Framework.UI.BunifuFlatButton btnView;
    }
}
