namespace Prisoners_Management_System.views.components
{
    partial class visitors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(visitors));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            this.btnAddNew = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label17 = new System.Windows.Forms.Label();
            this.VisitorflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInmate = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lblentries = new System.Windows.Forms.Label();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.btnPrevious = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnNext = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnRefresh = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSearch = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtSearch = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.Active = false;
            this.btnAddNew.Activecolor = System.Drawing.Color.Green;
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.BackColor = System.Drawing.Color.DarkGreen;
            this.btnAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddNew.BorderRadius = 5;
            this.btnAddNew.ButtonText = "New Visitor";
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.DisabledColor = System.Drawing.Color.Gray;
            this.btnAddNew.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAddNew.Iconimage = global::Prisoners_Management_System.Properties.Resources.add;
            this.btnAddNew.Iconimage_right = null;
            this.btnAddNew.Iconimage_right_Selected = null;
            this.btnAddNew.Iconimage_Selected = null;
            this.btnAddNew.IconMarginLeft = 20;
            this.btnAddNew.IconMarginRight = 0;
            this.btnAddNew.IconRightVisible = true;
            this.btnAddNew.IconRightZoom = 0D;
            this.btnAddNew.IconVisible = true;
            this.btnAddNew.IconZoom = 50D;
            this.btnAddNew.IsTab = true;
            this.btnAddNew.Location = new System.Drawing.Point(901, 23);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnAddNew.OnHovercolor = System.Drawing.Color.Green;
            this.btnAddNew.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddNew.selected = false;
            this.btnAddNew.Size = new System.Drawing.Size(153, 45);
            this.btnAddNew.TabIndex = 68;
            this.btnAddNew.Text = "New Visitor";
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNew.Textcolor = System.Drawing.Color.White;
            this.btnAddNew.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(41, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(115, 24);
            this.label17.TabIndex = 4;
            this.label17.Text = "Visitors List";
            // 
            // VisitorflowLayoutPanel
            // 
            this.VisitorflowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VisitorflowLayoutPanel.AutoScroll = true;
            this.VisitorflowLayoutPanel.Location = new System.Drawing.Point(40, 160);
            this.VisitorflowLayoutPanel.Name = "VisitorflowLayoutPanel";
            this.VisitorflowLayoutPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VisitorflowLayoutPanel.Size = new System.Drawing.Size(1017, 294);
            this.VisitorflowLayoutPanel.TabIndex = 70;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblInmate);
            this.panel1.Controls.Add(this.lblContact);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Location = new System.Drawing.Point(40, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1017, 27);
            this.panel1.TabIndex = 79;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(6, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 16);
            this.label9.TabIndex = 91;
            this.label9.Text = "No";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(618, 7);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(26, 16);
            this.lblDate.TabIndex = 90;
            this.lblDate.Text = "On";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(956, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 85;
            this.label4.Text = "Action";
            // 
            // lblInmate
            // 
            this.lblInmate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInmate.AutoSize = true;
            this.lblInmate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInmate.ForeColor = System.Drawing.Color.White;
            this.lblInmate.Location = new System.Drawing.Point(450, 7);
            this.lblInmate.Name = "lblInmate";
            this.lblInmate.Size = new System.Drawing.Size(55, 16);
            this.lblInmate.TabIndex = 89;
            this.lblInmate.Text = "Visited";
            // 
            // lblContact
            // 
            this.lblContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.ForeColor = System.Drawing.Color.White;
            this.lblContact.Location = new System.Drawing.Point(266, 7);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(135, 16);
            this.lblContact.TabIndex = 88;
            this.lblContact.Text = "Contact && Address";
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(49, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(48, 16);
            this.lblName.TabIndex = 86;
            this.lblName.Text = "Name";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(40, 151);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1017, 10);
            this.bunifuSeparator1.TabIndex = 80;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // lblentries
            // 
            this.lblentries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblentries.AutoSize = true;
            this.lblentries.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblentries.ForeColor = System.Drawing.Color.White;
            this.lblentries.Location = new System.Drawing.Point(45, 464);
            this.lblentries.Name = "lblentries";
            this.lblentries.Size = new System.Drawing.Size(135, 21);
            this.lblentries.TabIndex = 103;
            this.lblentries.Text = "25 of 100 entries";
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPageNumber.ForeColor = System.Drawing.Color.White;
            this.lblPageNumber.Location = new System.Drawing.Point(983, 464);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(37, 21);
            this.lblPageNumber.TabIndex = 100;
            this.lblPageNumber.Text = "100";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.Image = global::Prisoners_Management_System.Properties.Resources.go_back;
            this.btnPrevious.ImageActive = null;
            this.btnPrevious.Location = new System.Drawing.Point(943, 460);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(34, 30);
            this.btnPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPrevious.TabIndex = 102;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.Zoom = 5;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Image = global::Prisoners_Management_System.Properties.Resources.circled_right;
            this.btnNext.ImageActive = null;
            this.btnNext.Location = new System.Drawing.Point(1022, 460);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(34, 30);
            this.btnNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNext.TabIndex = 101;
            this.btnNext.TabStop = false;
            this.btnNext.Zoom = 5;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Active = false;
            this.btnRefresh.Activecolor = System.Drawing.Color.Green;
            this.btnRefresh.BackColor = System.Drawing.Color.DarkGreen;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.ButtonText = "Refresh";
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.DisabledColor = System.Drawing.Color.Gray;
            this.btnRefresh.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRefresh.Iconimage = global::Prisoners_Management_System.Properties.Resources.refresh;
            this.btnRefresh.Iconimage_right = null;
            this.btnRefresh.Iconimage_right_Selected = null;
            this.btnRefresh.Iconimage_Selected = null;
            this.btnRefresh.IconMarginLeft = 15;
            this.btnRefresh.IconMarginRight = 0;
            this.btnRefresh.IconRightVisible = true;
            this.btnRefresh.IconRightZoom = 0D;
            this.btnRefresh.IconVisible = true;
            this.btnRefresh.IconZoom = 50D;
            this.btnRefresh.IsTab = true;
            this.btnRefresh.Location = new System.Drawing.Point(40, 74);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnRefresh.OnHovercolor = System.Drawing.Color.Green;
            this.btnRefresh.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRefresh.selected = false;
            this.btnRefresh.Size = new System.Drawing.Size(112, 45);
            this.btnRefresh.TabIndex = 130;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Textcolor = System.Drawing.Color.White;
            this.btnRefresh.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Active = false;
            this.btnSearch.Activecolor = System.Drawing.Color.Green;
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.BorderRadius = 5;
            this.btnSearch.ButtonText = "Search";
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.DisabledColor = System.Drawing.Color.Gray;
            this.btnSearch.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSearch.Iconimage = global::Prisoners_Management_System.Properties.Resources.search;
            this.btnSearch.Iconimage_right = null;
            this.btnSearch.Iconimage_right_Selected = null;
            this.btnSearch.Iconimage_Selected = null;
            this.btnSearch.IconMarginLeft = 5;
            this.btnSearch.IconMarginRight = 0;
            this.btnSearch.IconRightVisible = true;
            this.btnSearch.IconRightZoom = 0D;
            this.btnSearch.IconVisible = true;
            this.btnSearch.IconZoom = 50D;
            this.btnSearch.IsTab = true;
            this.btnSearch.Location = new System.Drawing.Point(961, 74);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnSearch.OnHovercolor = System.Drawing.Color.Green;
            this.btnSearch.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSearch.selected = false;
            this.btnSearch.Size = new System.Drawing.Size(93, 45);
            this.btnSearch.TabIndex = 132;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Textcolor = System.Drawing.Color.White;
            this.btnSearch.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AcceptsReturn = false;
            this.txtSearch.AcceptsTab = false;
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.AnimationSpeed = 200;
            this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.BackgroundImage")));
            this.txtSearch.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtSearch.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.txtSearch.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtSearch.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtSearch.BorderRadius = 1;
            this.txtSearch.BorderThickness = 1;
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultFont = new System.Drawing.Font("Segoe UI Semibold", 9.75F);
            this.txtSearch.DefaultText = "";
            this.txtSearch.FillColor = System.Drawing.Color.White;
            this.txtSearch.HideSelection = true;
            this.txtSearch.IconLeft = null;
            this.txtSearch.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.IconPadding = 10;
            this.txtSearch.IconRight = null;
            this.txtSearch.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.Lines = new string[0];
            this.txtSearch.Location = new System.Drawing.Point(678, 74);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtSearch.Modified = false;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtSearch.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.Empty;
            stateProperties6.FillColor = System.Drawing.Color.White;
            stateProperties6.ForeColor = System.Drawing.Color.Empty;
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtSearch.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtSearch.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtSearch.OnIdleState = stateProperties8;
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtSearch.PlaceholderText = "Search here...";
            this.txtSearch.ReadOnly = false;
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.ShortcutsEnabled = true;
            this.txtSearch.Size = new System.Drawing.Size(277, 45);
            this.txtSearch.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Material;
            this.txtSearch.TabIndex = 131;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearch.TextMarginBottom = 0;
            this.txtSearch.TextMarginLeft = 5;
            this.txtSearch.TextMarginTop = 0;
            this.txtSearch.TextPlaceholder = "Search here...";
            this.txtSearch.UseSystemPasswordChar = false;
            this.txtSearch.WordWrap = true;
            // 
            // visitors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblentries);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.VisitorflowLayoutPanel);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnAddNew);
            this.Name = "visitors";
            this.Size = new System.Drawing.Size(1100, 517);
            this.Load += new System.EventHandler(this.visitors_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Bunifu.Framework.UI.BunifuFlatButton btnAddNew;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.FlowLayoutPanel VisitorflowLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.Label lblInmate;
        public System.Windows.Forms.Label lblContact;
        public System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblentries;
        private System.Windows.Forms.Label lblPageNumber;
        private Bunifu.Framework.UI.BunifuImageButton btnPrevious;
        private Bunifu.Framework.UI.BunifuImageButton btnNext;
        public Bunifu.Framework.UI.BunifuFlatButton btnRefresh;
        public Bunifu.Framework.UI.BunifuFlatButton btnSearch;
        public Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtSearch;
    }
}
