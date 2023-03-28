namespace Roll_Call_And_Management_System.views
{
    partial class dashboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashboard));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnReports = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnCrimes = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bar = new System.Windows.Forms.PictureBox();
            this.btnToggleMenu = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnDormitory = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnUsers = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRollCall = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnDashboard = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnInmate = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnVisitors = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBack = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblModel = new System.Windows.Forms.Label();
            this.PathSeparator = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblAlert = new System.Windows.Forms.Label();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btnNotification = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnProfile = new Bunifu.Framework.UI.BunifuImageButton();
            this.label1 = new System.Windows.Forms.Label();
            this.MenuTransition = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.pnlBody = new System.Windows.Forms.Panel();
            this.cpbLoader = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.menuTimer = new System.Windows.Forms.Timer(this.components);
            this.NotificationIconTimer = new System.Windows.Forms.Timer(this.components);
            this.SearchTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToggleMenu)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNotification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProfile)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.pnlMenu.Controls.Add(this.btnReports);
            this.pnlMenu.Controls.Add(this.btnCrimes);
            this.pnlMenu.Controls.Add(this.bar);
            this.pnlMenu.Controls.Add(this.btnToggleMenu);
            this.pnlMenu.Controls.Add(this.btnDormitory);
            this.pnlMenu.Controls.Add(this.btnUsers);
            this.pnlMenu.Controls.Add(this.btnRollCall);
            this.pnlMenu.Controls.Add(this.lblUsername);
            this.pnlMenu.Controls.Add(this.btnDashboard);
            this.pnlMenu.Controls.Add(this.btnInmate);
            this.pnlMenu.Controls.Add(this.btnVisitors);
            this.MenuTransition.SetDecoration(this.pnlMenu, BunifuAnimatorNS.DecorationType.None);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.MaximumSize = new System.Drawing.Size(170, 1000);
            this.pnlMenu.MinimumSize = new System.Drawing.Size(48, 1000);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(170, 1000);
            this.pnlMenu.TabIndex = 1;
            this.pnlMenu.MouseHover += new System.EventHandler(this.pnlMenu_MouseHover);
            // 
            // btnReports
            // 
            this.btnReports.Active = false;
            this.btnReports.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnReports.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReports.BorderRadius = 0;
            this.btnReports.ButtonText = "  Reports";
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTransition.SetDecoration(this.btnReports, BunifuAnimatorNS.DecorationType.None);
            this.btnReports.DisabledColor = System.Drawing.Color.Gray;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.Iconcolor = System.Drawing.Color.Transparent;
            this.btnReports.Iconimage = global::Roll_Call_And_Management_System.Properties.Resources.slice;
            this.btnReports.Iconimage_right = null;
            this.btnReports.Iconimage_right_Selected = null;
            this.btnReports.Iconimage_Selected = null;
            this.btnReports.IconMarginLeft = 13;
            this.btnReports.IconMarginRight = 0;
            this.btnReports.IconRightVisible = true;
            this.btnReports.IconRightZoom = 0D;
            this.btnReports.IconVisible = true;
            this.btnReports.IconZoom = 50D;
            this.btnReports.IsTab = true;
            this.btnReports.Location = new System.Drawing.Point(0, 297);
            this.btnReports.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnReports.Name = "btnReports";
            this.btnReports.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnReports.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.btnReports.OnHoverTextColor = System.Drawing.Color.White;
            this.btnReports.selected = false;
            this.btnReports.Size = new System.Drawing.Size(170, 30);
            this.btnReports.TabIndex = 13;
            this.btnReports.Text = "  Reports";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Textcolor = System.Drawing.Color.White;
            this.btnReports.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnCrimes
            // 
            this.btnCrimes.Active = false;
            this.btnCrimes.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnCrimes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnCrimes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrimes.BorderRadius = 0;
            this.btnCrimes.ButtonText = "  Crimes";
            this.btnCrimes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTransition.SetDecoration(this.btnCrimes, BunifuAnimatorNS.DecorationType.None);
            this.btnCrimes.DisabledColor = System.Drawing.Color.Gray;
            this.btnCrimes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrimes.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCrimes.Iconimage = global::Roll_Call_And_Management_System.Properties.Resources.handcuffs;
            this.btnCrimes.Iconimage_right = null;
            this.btnCrimes.Iconimage_right_Selected = null;
            this.btnCrimes.Iconimage_Selected = null;
            this.btnCrimes.IconMarginLeft = 13;
            this.btnCrimes.IconMarginRight = 0;
            this.btnCrimes.IconRightVisible = true;
            this.btnCrimes.IconRightZoom = 0D;
            this.btnCrimes.IconVisible = true;
            this.btnCrimes.IconZoom = 50D;
            this.btnCrimes.IsTab = true;
            this.btnCrimes.Location = new System.Drawing.Point(0, 261);
            this.btnCrimes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCrimes.Name = "btnCrimes";
            this.btnCrimes.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnCrimes.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.btnCrimes.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCrimes.selected = false;
            this.btnCrimes.Size = new System.Drawing.Size(170, 30);
            this.btnCrimes.TabIndex = 14;
            this.btnCrimes.Text = "  Crimes";
            this.btnCrimes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrimes.Textcolor = System.Drawing.Color.White;
            this.btnCrimes.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnCrimes.Click += new System.EventHandler(this.btnCrimes_Click);
            // 
            // bar
            // 
            this.bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.MenuTransition.SetDecoration(this.bar, BunifuAnimatorNS.DecorationType.None);
            this.bar.Location = new System.Drawing.Point(1, 45);
            this.bar.Name = "bar";
            this.bar.Size = new System.Drawing.Size(3, 28);
            this.bar.TabIndex = 15;
            this.bar.TabStop = false;
            // 
            // btnToggleMenu
            // 
            this.btnToggleMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnToggleMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTransition.SetDecoration(this.btnToggleMenu, BunifuAnimatorNS.DecorationType.None);
            this.btnToggleMenu.Image = global::Roll_Call_And_Management_System.Properties.Resources.back;
            this.btnToggleMenu.ImageActive = null;
            this.btnToggleMenu.Location = new System.Drawing.Point(18, 13);
            this.btnToggleMenu.Name = "btnToggleMenu";
            this.btnToggleMenu.Size = new System.Drawing.Size(24, 24);
            this.btnToggleMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnToggleMenu.TabIndex = 3;
            this.btnToggleMenu.TabStop = false;
            this.btnToggleMenu.Zoom = 10;
            this.btnToggleMenu.Click += new System.EventHandler(this.btnToggleMenu_Click);
            // 
            // btnDormitory
            // 
            this.btnDormitory.Active = false;
            this.btnDormitory.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnDormitory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnDormitory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDormitory.BorderRadius = 0;
            this.btnDormitory.ButtonText = "  Dormitory";
            this.btnDormitory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTransition.SetDecoration(this.btnDormitory, BunifuAnimatorNS.DecorationType.None);
            this.btnDormitory.DisabledColor = System.Drawing.Color.Gray;
            this.btnDormitory.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDormitory.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDormitory.Iconimage = global::Roll_Call_And_Management_System.Properties.Resources.prison_building;
            this.btnDormitory.Iconimage_right = null;
            this.btnDormitory.Iconimage_right_Selected = null;
            this.btnDormitory.Iconimage_Selected = null;
            this.btnDormitory.IconMarginLeft = 13;
            this.btnDormitory.IconMarginRight = 0;
            this.btnDormitory.IconRightVisible = true;
            this.btnDormitory.IconRightZoom = 0D;
            this.btnDormitory.IconVisible = true;
            this.btnDormitory.IconZoom = 50D;
            this.btnDormitory.IsTab = true;
            this.btnDormitory.Location = new System.Drawing.Point(0, 189);
            this.btnDormitory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDormitory.Name = "btnDormitory";
            this.btnDormitory.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnDormitory.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.btnDormitory.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDormitory.selected = false;
            this.btnDormitory.Size = new System.Drawing.Size(170, 30);
            this.btnDormitory.TabIndex = 10;
            this.btnDormitory.Text = "  Dormitory";
            this.btnDormitory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDormitory.Textcolor = System.Drawing.Color.White;
            this.btnDormitory.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnDormitory.Click += new System.EventHandler(this.btnDormitory_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Active = false;
            this.btnUsers.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsers.BorderRadius = 0;
            this.btnUsers.ButtonText = "  Users";
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTransition.SetDecoration(this.btnUsers, BunifuAnimatorNS.DecorationType.None);
            this.btnUsers.DisabledColor = System.Drawing.Color.Gray;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.Iconcolor = System.Drawing.Color.Transparent;
            this.btnUsers.Iconimage = global::Roll_Call_And_Management_System.Properties.Resources.users;
            this.btnUsers.Iconimage_right = null;
            this.btnUsers.Iconimage_right_Selected = null;
            this.btnUsers.Iconimage_Selected = null;
            this.btnUsers.IconMarginLeft = 13;
            this.btnUsers.IconMarginRight = 0;
            this.btnUsers.IconRightVisible = true;
            this.btnUsers.IconRightZoom = 0D;
            this.btnUsers.IconVisible = true;
            this.btnUsers.IconZoom = 50D;
            this.btnUsers.IsTab = true;
            this.btnUsers.Location = new System.Drawing.Point(0, 225);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnUsers.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.btnUsers.OnHoverTextColor = System.Drawing.Color.White;
            this.btnUsers.selected = false;
            this.btnUsers.Size = new System.Drawing.Size(170, 30);
            this.btnUsers.TabIndex = 13;
            this.btnUsers.Text = "  Users";
            this.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Textcolor = System.Drawing.Color.White;
            this.btnUsers.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnRollCall
            // 
            this.btnRollCall.Active = false;
            this.btnRollCall.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnRollCall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnRollCall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRollCall.BorderRadius = 0;
            this.btnRollCall.ButtonText = "  Roll Call";
            this.btnRollCall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTransition.SetDecoration(this.btnRollCall, BunifuAnimatorNS.DecorationType.None);
            this.btnRollCall.DisabledColor = System.Drawing.Color.Gray;
            this.btnRollCall.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRollCall.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRollCall.Iconimage = global::Roll_Call_And_Management_System.Properties.Resources.checked_user;
            this.btnRollCall.Iconimage_right = null;
            this.btnRollCall.Iconimage_right_Selected = null;
            this.btnRollCall.Iconimage_Selected = null;
            this.btnRollCall.IconMarginLeft = 13;
            this.btnRollCall.IconMarginRight = 0;
            this.btnRollCall.IconRightVisible = true;
            this.btnRollCall.IconRightZoom = 0D;
            this.btnRollCall.IconVisible = true;
            this.btnRollCall.IconZoom = 50D;
            this.btnRollCall.IsTab = true;
            this.btnRollCall.Location = new System.Drawing.Point(0, 153);
            this.btnRollCall.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRollCall.Name = "btnRollCall";
            this.btnRollCall.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnRollCall.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.btnRollCall.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRollCall.selected = false;
            this.btnRollCall.Size = new System.Drawing.Size(170, 30);
            this.btnRollCall.TabIndex = 9;
            this.btnRollCall.Text = "  Roll Call";
            this.btnRollCall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRollCall.Textcolor = System.Drawing.Color.White;
            this.btnRollCall.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnRollCall.Click += new System.EventHandler(this.btnRollCall_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.MenuTransition.SetDecoration(this.lblUsername, BunifuAnimatorNS.DecorationType.None);
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(51, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(103, 20);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Bright Mwale";
            // 
            // btnDashboard
            // 
            this.btnDashboard.Active = true;
            this.btnDashboard.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDashboard.BorderRadius = 5;
            this.btnDashboard.ButtonText = "  Dashboard";
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTransition.SetDecoration(this.btnDashboard, BunifuAnimatorNS.DecorationType.None);
            this.btnDashboard.DisabledColor = System.Drawing.Color.Gray;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDashboard.Iconimage = global::Roll_Call_And_Management_System.Properties.Resources.dashboard_layout;
            this.btnDashboard.Iconimage_right = null;
            this.btnDashboard.Iconimage_right_Selected = null;
            this.btnDashboard.Iconimage_Selected = null;
            this.btnDashboard.IconMarginLeft = 13;
            this.btnDashboard.IconMarginRight = 0;
            this.btnDashboard.IconRightVisible = true;
            this.btnDashboard.IconRightZoom = 0D;
            this.btnDashboard.IconVisible = true;
            this.btnDashboard.IconZoom = 50D;
            this.btnDashboard.IsTab = true;
            this.btnDashboard.Location = new System.Drawing.Point(0, 45);
            this.btnDashboard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnDashboard.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.btnDashboard.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDashboard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDashboard.selected = true;
            this.btnDashboard.Size = new System.Drawing.Size(170, 30);
            this.btnDashboard.TabIndex = 8;
            this.btnDashboard.Text = "  Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Textcolor = System.Drawing.Color.White;
            this.btnDashboard.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // btnInmate
            // 
            this.btnInmate.Active = false;
            this.btnInmate.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnInmate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnInmate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInmate.BorderRadius = 0;
            this.btnInmate.ButtonText = "  Inmates";
            this.btnInmate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTransition.SetDecoration(this.btnInmate, BunifuAnimatorNS.DecorationType.None);
            this.btnInmate.DisabledColor = System.Drawing.Color.Gray;
            this.btnInmate.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInmate.Iconcolor = System.Drawing.Color.Transparent;
            this.btnInmate.Iconimage = global::Roll_Call_And_Management_System.Properties.Resources.prisoner;
            this.btnInmate.Iconimage_right = null;
            this.btnInmate.Iconimage_right_Selected = null;
            this.btnInmate.Iconimage_Selected = null;
            this.btnInmate.IconMarginLeft = 13;
            this.btnInmate.IconMarginRight = 0;
            this.btnInmate.IconRightVisible = true;
            this.btnInmate.IconRightZoom = 0D;
            this.btnInmate.IconVisible = true;
            this.btnInmate.IconZoom = 50D;
            this.btnInmate.IsTab = true;
            this.btnInmate.Location = new System.Drawing.Point(0, 81);
            this.btnInmate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnInmate.Name = "btnInmate";
            this.btnInmate.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnInmate.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.btnInmate.OnHoverTextColor = System.Drawing.Color.White;
            this.btnInmate.selected = false;
            this.btnInmate.Size = new System.Drawing.Size(170, 30);
            this.btnInmate.TabIndex = 11;
            this.btnInmate.Text = "  Inmates";
            this.btnInmate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInmate.Textcolor = System.Drawing.Color.White;
            this.btnInmate.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnInmate.Click += new System.EventHandler(this.btnInmate_Click);
            // 
            // btnVisitors
            // 
            this.btnVisitors.Active = false;
            this.btnVisitors.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnVisitors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnVisitors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVisitors.BorderRadius = 0;
            this.btnVisitors.ButtonText = "  Visitors";
            this.btnVisitors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTransition.SetDecoration(this.btnVisitors, BunifuAnimatorNS.DecorationType.None);
            this.btnVisitors.DisabledColor = System.Drawing.Color.Gray;
            this.btnVisitors.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisitors.Iconcolor = System.Drawing.Color.Transparent;
            this.btnVisitors.Iconimage = global::Roll_Call_And_Management_System.Properties.Resources.waiting_room;
            this.btnVisitors.Iconimage_right = null;
            this.btnVisitors.Iconimage_right_Selected = null;
            this.btnVisitors.Iconimage_Selected = null;
            this.btnVisitors.IconMarginLeft = 13;
            this.btnVisitors.IconMarginRight = 0;
            this.btnVisitors.IconRightVisible = true;
            this.btnVisitors.IconRightZoom = 0D;
            this.btnVisitors.IconVisible = true;
            this.btnVisitors.IconZoom = 50D;
            this.btnVisitors.IsTab = true;
            this.btnVisitors.Location = new System.Drawing.Point(0, 117);
            this.btnVisitors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnVisitors.Name = "btnVisitors";
            this.btnVisitors.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.btnVisitors.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.btnVisitors.OnHoverTextColor = System.Drawing.Color.White;
            this.btnVisitors.selected = false;
            this.btnVisitors.Size = new System.Drawing.Size(170, 30);
            this.btnVisitors.TabIndex = 12;
            this.btnVisitors.Text = "  Visitors";
            this.btnVisitors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVisitors.Textcolor = System.Drawing.Color.White;
            this.btnVisitors.TextFont = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnVisitors.Click += new System.EventHandler(this.btnVisitors_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.pnlHeader.Controls.Add(this.bunifuSeparator1);
            this.pnlHeader.Controls.Add(this.flowLayoutPanel1);
            this.pnlHeader.Controls.Add(this.lblAlert);
            this.pnlHeader.Controls.Add(this.bunifuSeparator2);
            this.pnlHeader.Controls.Add(this.btnNotification);
            this.pnlHeader.Controls.Add(this.btnProfile);
            this.pnlHeader.Controls.Add(this.label1);
            this.MenuTransition.SetDecoration(this.pnlHeader, BunifuAnimatorNS.DecorationType.None);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.pnlHeader.Location = new System.Drawing.Point(170, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(629, 101);
            this.pnlHeader.TabIndex = 2;
            this.pnlHeader.MouseHover += new System.EventHandler(this.pnlHeader_MouseHover);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.MenuTransition.SetDecoration(this.bunifuSeparator1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(14, 93);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(603, 10);
            this.bunifuSeparator1.TabIndex = 0;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            this.bunifuSeparator1.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.flowLayoutPanel1.Controls.Add(this.btnBack);
            this.flowLayoutPanel1.Controls.Add(this.lblModel);
            this.flowLayoutPanel1.Controls.Add(this.PathSeparator);
            this.flowLayoutPanel1.Controls.Add(this.lblAction);
            this.MenuTransition.SetDecoration(this.flowLayoutPanel1, BunifuAnimatorNS.DecorationType.None);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 57);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(299, 35);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTransition.SetDecoration(this.btnBack, BunifuAnimatorNS.DecorationType.None);
            this.btnBack.Image = global::Roll_Call_And_Management_System.Properties.Resources.back;
            this.btnBack.ImageActive = null;
            this.btnBack.Location = new System.Drawing.Point(20, 7);
            this.btnBack.Margin = new System.Windows.Forms.Padding(20, 7, 3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(25, 25);
            this.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnBack.TabIndex = 8;
            this.btnBack.TabStop = false;
            this.btnBack.Zoom = 5;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.MenuTransition.SetDecoration(this.lblModel, BunifuAnimatorNS.DecorationType.None);
            this.lblModel.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.ForeColor = System.Drawing.Color.Silver;
            this.lblModel.Location = new System.Drawing.Point(56, 8);
            this.lblModel.Margin = new System.Windows.Forms.Padding(8, 8, 5, 5);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(97, 23);
            this.lblModel.TabIndex = 5;
            this.lblModel.Text = "Dashboard";
            this.lblModel.Click += new System.EventHandler(this.lblModel_Click);
            // 
            // PathSeparator
            // 
            this.PathSeparator.AutoSize = true;
            this.MenuTransition.SetDecoration(this.PathSeparator, BunifuAnimatorNS.DecorationType.None);
            this.PathSeparator.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.PathSeparator.ForeColor = System.Drawing.Color.Silver;
            this.PathSeparator.Location = new System.Drawing.Point(158, 5);
            this.PathSeparator.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.PathSeparator.Name = "PathSeparator";
            this.PathSeparator.Size = new System.Drawing.Size(22, 23);
            this.PathSeparator.TabIndex = 7;
            this.PathSeparator.Text = ">";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.MenuTransition.SetDecoration(this.lblAction, BunifuAnimatorNS.DecorationType.None);
            this.lblAction.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.lblAction.ForeColor = System.Drawing.Color.Silver;
            this.lblAction.Location = new System.Drawing.Point(185, 8);
            this.lblAction.Margin = new System.Windows.Forms.Padding(5, 8, 5, 5);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(73, 23);
            this.lblAction.TabIndex = 6;
            this.lblAction.Text = "Inmates";
            this.lblAction.Click += new System.EventHandler(this.lblAction_Click);
            // 
            // lblAlert
            // 
            this.lblAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlert.AutoSize = true;
            this.lblAlert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(18)))));
            this.MenuTransition.SetDecoration(this.lblAlert, BunifuAnimatorNS.DecorationType.None);
            this.lblAlert.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlert.ForeColor = System.Drawing.Color.Firebrick;
            this.lblAlert.Location = new System.Drawing.Point(568, 3);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(15, 17);
            this.lblAlert.TabIndex = 3;
            this.lblAlert.Text = "0";
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.MenuTransition.SetDecoration(this.bunifuSeparator2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(14, 48);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(603, 10);
            this.bunifuSeparator2.TabIndex = 6;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            this.bunifuSeparator2.Visible = false;
            // 
            // btnNotification
            // 
            this.btnNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTransition.SetDecoration(this.btnNotification, BunifuAnimatorNS.DecorationType.None);
            this.btnNotification.Image = global::Roll_Call_And_Management_System.Properties.Resources.notification;
            this.btnNotification.ImageActive = null;
            this.btnNotification.Location = new System.Drawing.Point(543, 12);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(34, 30);
            this.btnNotification.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnNotification.TabIndex = 2;
            this.btnNotification.TabStop = false;
            this.btnNotification.Zoom = 5;
            this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MenuTransition.SetDecoration(this.btnProfile, BunifuAnimatorNS.DecorationType.None);
            this.btnProfile.Image = global::Roll_Call_And_Management_System.Properties.Resources.user;
            this.btnProfile.ImageActive = null;
            this.btnProfile.Location = new System.Drawing.Point(583, 12);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(34, 30);
            this.btnProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnProfile.TabIndex = 1;
            this.btnProfile.TabStop = false;
            this.btnProfile.Zoom = 5;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            this.btnProfile.MouseLeave += new System.EventHandler(this.btnProfile_MouseLeave);
            this.btnProfile.MouseHover += new System.EventHandler(this.BtnClose_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.MenuTransition.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "MAULA PRISONERS MANAGEMENT SYSTEM";
            // 
            // MenuTransition
            // 
            this.MenuTransition.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.MenuTransition.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.MenuTransition.DefaultAnimation = animation1;
            this.MenuTransition.MaxAnimationTime = 3000;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.pnlBody.Controls.Add(this.cpbLoader);
            this.MenuTransition.SetDecoration(this.pnlBody, BunifuAnimatorNS.DecorationType.None);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(170, 101);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(629, 349);
            this.pnlBody.TabIndex = 3;
            this.pnlBody.MouseHover += new System.EventHandler(this.pnlBody_MouseHover);
            // 
            // cpbLoader
            // 
            this.cpbLoader.animated = true;
            this.cpbLoader.animationIterval = 5;
            this.cpbLoader.animationSpeed = 10;
            this.cpbLoader.BackColor = System.Drawing.Color.Transparent;
            this.cpbLoader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cpbLoader.BackgroundImage")));
            this.cpbLoader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MenuTransition.SetDecoration(this.cpbLoader, BunifuAnimatorNS.DecorationType.None);
            this.cpbLoader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.cpbLoader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.cpbLoader.LabelVisible = false;
            this.cpbLoader.LineProgressThickness = 8;
            this.cpbLoader.LineThickness = 5;
            this.cpbLoader.Location = new System.Drawing.Point(0, 3);
            this.cpbLoader.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.cpbLoader.MaxValue = 100;
            this.cpbLoader.Name = "cpbLoader";
            this.cpbLoader.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.cpbLoader.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
            this.cpbLoader.Size = new System.Drawing.Size(100, 100);
            this.cpbLoader.TabIndex = 17;
            this.cpbLoader.Value = 25;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // SidebarTimer
            // 
            this.SidebarTimer.Interval = 10;
            this.SidebarTimer.Tick += new System.EventHandler(this.SidebarTimer_Tick);
            // 
            // menuTimer
            // 
            this.menuTimer.Interval = 10;
            this.menuTimer.Tick += new System.EventHandler(this.menuTimer_Tick);
            // 
            // NotificationIconTimer
            // 
            this.NotificationIconTimer.Interval = 10;
            this.NotificationIconTimer.Tick += new System.EventHandler(this.NotificationIconTimer_Tick);
            // 
            // SearchTimer
            // 
            this.SearchTimer.Interval = 10;
            this.SearchTimer.Tick += new System.EventHandler(this.SearchTimer_Tick);
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 450);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlMenu);
            this.MenuTransition.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prison Roll Call System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.Shown += new System.EventHandler(this.Dashboard_Shown);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnToggleMenu)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNotification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProfile)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private Bunifu.Framework.UI.BunifuImageButton btnToggleMenu;
        public Bunifu.Framework.UI.BunifuFlatButton btnVisitors;
        public Bunifu.Framework.UI.BunifuFlatButton btnInmate;
        public Bunifu.Framework.UI.BunifuFlatButton btnDormitory;
        public Bunifu.Framework.UI.BunifuFlatButton btnRollCall;
        public Bunifu.Framework.UI.BunifuFlatButton btnDashboard;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAlert;
        private Bunifu.Framework.UI.BunifuImageButton btnNotification;
        private Bunifu.Framework.UI.BunifuImageButton btnProfile;
        private System.Windows.Forms.Label label1;
        private BunifuAnimatorNS.BunifuTransition MenuTransition;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer SidebarTimer;
        private System.Windows.Forms.Timer menuTimer;
        private System.Windows.Forms.Timer NotificationIconTimer;
        public Bunifu.Framework.UI.BunifuFlatButton btnReports;
        public Bunifu.Framework.UI.BunifuFlatButton btnUsers;
        public System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        public Bunifu.Framework.UI.BunifuFlatButton btnCrimes;
        public System.Windows.Forms.Label lblModel;
        public System.Windows.Forms.Label lblAction;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        public System.Windows.Forms.PictureBox bar;
        private System.Windows.Forms.Timer SearchTimer;
        public System.Windows.Forms.Label PathSeparator;
        private Bunifu.Framework.UI.BunifuImageButton btnBack;
        private Bunifu.Framework.UI.BunifuCircleProgressbar cpbLoader;
    }
}