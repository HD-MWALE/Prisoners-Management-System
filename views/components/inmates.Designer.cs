namespace Prisoners_Management_System.views.components
{
    partial class inmates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inmates));
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            this.btnAddNew = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label17 = new System.Windows.Forms.Label();
            this.InmateflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnSearch = new Bunifu.Framework.UI.BunifuFlatButton();
            this.txtSearch = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.dpnDormitory = new Bunifu.UI.WinForms.BunifuDropdown();
            this.btnPList = new Bunifu.Framework.UI.BunifuFlatButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnPrevious = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.lblentries = new System.Windows.Forms.Label();
            this.btnNear = new Bunifu.Framework.UI.BunifuFlatButton();
            this.cpbLoader = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.btnRefresh = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnView = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrevious)).BeginInit();
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
            this.btnAddNew.ButtonText = "New Inmate";
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
            this.btnAddNew.Location = new System.Drawing.Point(729, 36);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnAddNew.OnHovercolor = System.Drawing.Color.Green;
            this.btnAddNew.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAddNew.selected = false;
            this.btnAddNew.Size = new System.Drawing.Size(153, 45);
            this.btnAddNew.TabIndex = 68;
            this.btnAddNew.Text = "New Inmate";
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNew.Textcolor = System.Drawing.Color.White;
            this.btnAddNew.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(35, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 25);
            this.label17.TabIndex = 4;
            this.label17.Text = "Inmates List";
            // 
            // InmateflowLayoutPanel
            // 
            this.InmateflowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InmateflowLayoutPanel.AutoScroll = true;
            this.InmateflowLayoutPanel.Location = new System.Drawing.Point(40, 223);
            this.InmateflowLayoutPanel.Name = "InmateflowLayoutPanel";
            this.InmateflowLayoutPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.InmateflowLayoutPanel.Size = new System.Drawing.Size(845, 187);
            this.InmateflowLayoutPanel.TabIndex = 70;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(431, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 21);
            this.label3.TabIndex = 74;
            this.label3.Text = "Address";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(40, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 21);
            this.label7.TabIndex = 78;
            this.label7.Text = "Code";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(319, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 21);
            this.label8.TabIndex = 76;
            this.label8.Text = "Date Of Birth";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(239, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 21);
            this.label6.TabIndex = 75;
            this.label6.Text = "Gender";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(40, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(845, 27);
            this.panel1.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(652, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 83;
            this.label2.Text = "Sentence";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 21);
            this.label4.TabIndex = 82;
            this.label4.Text = "No";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(40, 214);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(845, 10);
            this.bunifuSeparator1.TabIndex = 80;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
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
            this.btnSearch.Location = new System.Drawing.Point(789, 87);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnSearch.OnHovercolor = System.Drawing.Color.Green;
            this.btnSearch.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSearch.selected = false;
            this.btnSearch.Size = new System.Drawing.Size(93, 45);
            this.btnSearch.TabIndex = 91;
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
            this.txtSearch.Location = new System.Drawing.Point(511, 87);
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
            this.txtSearch.TabIndex = 90;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSearch.TextMarginBottom = 0;
            this.txtSearch.TextMarginLeft = 5;
            this.txtSearch.TextMarginTop = 0;
            this.txtSearch.TextPlaceholder = "Search here...";
            this.txtSearch.UseSystemPasswordChar = false;
            this.txtSearch.WordWrap = true;
            // 
            // dpnDormitory
            // 
            this.dpnDormitory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.dpnDormitory.BorderRadius = 1;
            this.dpnDormitory.Color = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.dpnDormitory.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.dpnDormitory.DisabledColor = System.Drawing.Color.Gray;
            this.dpnDormitory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.dpnDormitory.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.dpnDormitory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dpnDormitory.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.dpnDormitory.FillDropDown = false;
            this.dpnDormitory.FillIndicator = false;
            this.dpnDormitory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dpnDormitory.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.dpnDormitory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.dpnDormitory.FormattingEnabled = true;
            this.dpnDormitory.Icon = null;
            this.dpnDormitory.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.dpnDormitory.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.dpnDormitory.ItemBackColor = System.Drawing.Color.White;
            this.dpnDormitory.ItemBorderColor = System.Drawing.Color.White;
            this.dpnDormitory.ItemForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.dpnDormitory.ItemHeight = 26;
            this.dpnDormitory.ItemHighLightColor = System.Drawing.Color.Thistle;
            this.dpnDormitory.Items.AddRange(new object[] {
            "All Dormitories"});
            this.dpnDormitory.Location = new System.Drawing.Point(46, 93);
            this.dpnDormitory.Name = "dpnDormitory";
            this.dpnDormitory.Size = new System.Drawing.Size(223, 32);
            this.dpnDormitory.TabIndex = 92;
            this.dpnDormitory.Text = "Select";
            this.dpnDormitory.SelectedIndexChanged += new System.EventHandler(this.dpnDormitory_SelectedIndexChanged);
            // 
            // btnPList
            // 
            this.btnPList.Active = false;
            this.btnPList.Activecolor = System.Drawing.Color.Green;
            this.btnPList.BackColor = System.Drawing.Color.DarkGreen;
            this.btnPList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPList.BorderRadius = 5;
            this.btnPList.ButtonText = "Pardoned List";
            this.btnPList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPList.DisabledColor = System.Drawing.Color.Gray;
            this.btnPList.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPList.Iconimage = global::Prisoners_Management_System.Properties.Resources.users;
            this.btnPList.Iconimage_right = null;
            this.btnPList.Iconimage_right_Selected = null;
            this.btnPList.Iconimage_Selected = null;
            this.btnPList.IconMarginLeft = 20;
            this.btnPList.IconMarginRight = 0;
            this.btnPList.IconRightVisible = true;
            this.btnPList.IconRightZoom = 0D;
            this.btnPList.IconVisible = true;
            this.btnPList.IconZoom = 50D;
            this.btnPList.IsTab = true;
            this.btnPList.Location = new System.Drawing.Point(283, 87);
            this.btnPList.Name = "btnPList";
            this.btnPList.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnPList.OnHovercolor = System.Drawing.Color.Green;
            this.btnPList.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPList.selected = false;
            this.btnPList.Size = new System.Drawing.Size(162, 45);
            this.btnPList.TabIndex = 93;
            this.btnPList.Text = "Pardoned List";
            this.btnPList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPList.Textcolor = System.Drawing.Color.White;
            this.btnPList.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnPList.Click += new System.EventHandler(this.btnPList_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 95;
            this.label1.Text = "Dormitory";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Image = global::Prisoners_Management_System.Properties.Resources.circled_right;
            this.btnNext.ImageActive = null;
            this.btnNext.Location = new System.Drawing.Point(851, 416);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(34, 30);
            this.btnNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNext.TabIndex = 97;
            this.btnNext.TabStop = false;
            this.btnNext.Zoom = 5;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.Image = global::Prisoners_Management_System.Properties.Resources.go_back;
            this.btnPrevious.ImageActive = null;
            this.btnPrevious.Location = new System.Drawing.Point(772, 416);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(34, 30);
            this.btnPrevious.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPrevious.TabIndex = 98;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.Zoom = 5;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPageNumber.ForeColor = System.Drawing.Color.White;
            this.lblPageNumber.Location = new System.Drawing.Point(812, 420);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(37, 21);
            this.lblPageNumber.TabIndex = 83;
            this.lblPageNumber.Text = "100";
            // 
            // lblentries
            // 
            this.lblentries.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblentries.AutoSize = true;
            this.lblentries.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblentries.ForeColor = System.Drawing.Color.White;
            this.lblentries.Location = new System.Drawing.Point(46, 420);
            this.lblentries.Name = "lblentries";
            this.lblentries.Size = new System.Drawing.Size(135, 21);
            this.lblentries.TabIndex = 99;
            this.lblentries.Text = "25 of 100 entries";
            // 
            // btnNear
            // 
            this.btnNear.Active = false;
            this.btnNear.Activecolor = System.Drawing.Color.Green;
            this.btnNear.BackColor = System.Drawing.Color.DarkGreen;
            this.btnNear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNear.BorderRadius = 5;
            this.btnNear.ButtonText = "Inmates near to be released";
            this.btnNear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNear.DisabledColor = System.Drawing.Color.Gray;
            this.btnNear.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNear.Iconimage = global::Prisoners_Management_System.Properties.Resources.users;
            this.btnNear.Iconimage_right = null;
            this.btnNear.Iconimage_right_Selected = null;
            this.btnNear.Iconimage_Selected = null;
            this.btnNear.IconMarginLeft = 20;
            this.btnNear.IconMarginRight = 0;
            this.btnNear.IconRightVisible = true;
            this.btnNear.IconRightZoom = 0D;
            this.btnNear.IconVisible = true;
            this.btnNear.IconZoom = 50D;
            this.btnNear.IsTab = true;
            this.btnNear.Location = new System.Drawing.Point(451, 87);
            this.btnNear.Name = "btnNear";
            this.btnNear.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnNear.OnHovercolor = System.Drawing.Color.Green;
            this.btnNear.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNear.selected = false;
            this.btnNear.Size = new System.Drawing.Size(252, 45);
            this.btnNear.TabIndex = 100;
            this.btnNear.Text = "Inmates near to be released";
            this.btnNear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNear.Textcolor = System.Drawing.Color.White;
            this.btnNear.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnNear.Click += new System.EventHandler(this.btnNear_Click);
            // 
            // cpbLoader
            // 
            this.cpbLoader.animated = true;
            this.cpbLoader.animationIterval = 5;
            this.cpbLoader.animationSpeed = 10;
            this.cpbLoader.BackColor = System.Drawing.Color.Transparent;
            this.cpbLoader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cpbLoader.BackgroundImage")));
            this.cpbLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cpbLoader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.cpbLoader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.cpbLoader.LabelVisible = false;
            this.cpbLoader.LineProgressThickness = 8;
            this.cpbLoader.LineThickness = 5;
            this.cpbLoader.Location = new System.Drawing.Point(480, 0);
            this.cpbLoader.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.cpbLoader.MaxValue = 100;
            this.cpbLoader.Name = "cpbLoader";
            this.cpbLoader.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.cpbLoader.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.cpbLoader.Size = new System.Drawing.Size(100, 100);
            this.cpbLoader.TabIndex = 101;
            this.cpbLoader.Value = 25;
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
            this.btnRefresh.Location = new System.Drawing.Point(46, 131);
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
            // btnView
            // 
            this.btnView.Active = false;
            this.btnView.Activecolor = System.Drawing.Color.Green;
            this.btnView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnView.BackColor = System.Drawing.Color.DarkGreen;
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnView.BorderRadius = 5;
            this.btnView.ButtonText = "View Pardoned List";
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
            this.btnView.Location = new System.Drawing.Point(683, 138);
            this.btnView.Name = "btnView";
            this.btnView.Normalcolor = System.Drawing.Color.DarkGreen;
            this.btnView.OnHovercolor = System.Drawing.Color.Green;
            this.btnView.OnHoverTextColor = System.Drawing.Color.White;
            this.btnView.selected = false;
            this.btnView.Size = new System.Drawing.Size(199, 45);
            this.btnView.TabIndex = 143;
            this.btnView.Text = "View Pardoned List";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Textcolor = System.Drawing.Color.White;
            this.btnView.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // inmates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cpbLoader);
            this.Controls.Add(this.btnNear);
            this.Controls.Add(this.lblentries);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPList);
            this.Controls.Add(this.dpnDormitory);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.InmateflowLayoutPanel);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnAddNew);
            this.Name = "inmates";
            this.Size = new System.Drawing.Size(928, 461);
            this.Load += new System.EventHandler(this.inmates_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrevious)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Bunifu.Framework.UI.BunifuFlatButton btnAddNew;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.FlowLayoutPanel InmateflowLayoutPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private System.Windows.Forms.Label label4;
        public Bunifu.Framework.UI.BunifuFlatButton btnSearch;
        public Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox txtSearch;
        private Bunifu.UI.WinForms.BunifuDropdown dpnDormitory;
        public Bunifu.Framework.UI.BunifuFlatButton btnPList;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuImageButton btnNext;
        private Bunifu.Framework.UI.BunifuImageButton btnPrevious;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Label lblentries;
        public Bunifu.Framework.UI.BunifuFlatButton btnNear;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuCircleProgressbar cpbLoader;
        public Bunifu.Framework.UI.BunifuFlatButton btnRefresh;
        public Bunifu.Framework.UI.BunifuFlatButton btnView;
    }
}
