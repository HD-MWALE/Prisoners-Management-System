using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
using Prisoners_Management_System.views.components;
using Prisoners_Management_System.views.components.dashboard;
using Prisoners_Management_System.views.components.view;

namespace Prisoners_Management_System.views
{
    public partial class dashboard : Form 
    {
        public dashboard(User user) 
        {
            InitializeComponent();
            // Getting user class
            Prison.User = user;

            // initalizing UserControls
            menu = new menu(this);
            notifications = new notifications();

            this.Controls.Add(panel);
            this.panel.Controls.Add(cpbLoader);
            panel.Location = new Point(0, 0);
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            cpbLoader.Location = new Point((this.Size.Width / 2) - (cpbLoader.Size.Width / 2), (this.Size.Height / 2) - (cpbLoader.Size.Width / 2));
            cpbLoader.BringToFront();
            
            // Adding Controls to dashboard control collection
            this.Controls.Add(menu);
            this.Controls.Add(notifications);
            /*
            // Adding PictureBox to panel control collection
            panel.Controls.Add(cpbLoader);

            // Docking the panel to dasboard to fill
            panel.Dock = DockStyle.Fill;

            // Setting PictureBox location to be centered
            cpbLoader.Location = new Point((cpbLoader.Size.Width / 2) - (this.Size.Width / 2), (this.Size.Height / 2));

            this.pnlBody.Controls.Add(panel);*/

            // bring the panel to front of all other controls
            // panel.BringToFront();

            panel.Visible = true;

            // Setting theme (Dark/Light)
            ColorScheme.LoadTheme(this.Controls);

            // bring bar to front of all other controls
            bar.BringToFront();

            // Set backcolor 
            bar.BackColor = Color.FromArgb(26, 104, 255);

            // Set bar to be visible
            bar.Visible = true;

            // Set Alert label to 0
            lblAlert.Text = "0";

            // Set Alert label forecolor 
            lblAlert.ForeColor = Color.Firebrick;

            // Checking user role 
            if (Prison.User.Auth[8].ToString() != "Admin")
            {
                // Setting buttons to visible false
                btnUsers.Visible = false;
                btnCrimes.Visible = false;
                btnReports.Visible = false;
            }
        }
        // Declaring objects
        public PrisonFactory Prison = new PrisonFactory();   
        public inmates inmates;
        message message;
        visitors visitors;
        dashboardControl dashboardControl;
        users users;
        reports reports;
        crimes crimes;
        dormitories dormitories;
        components.rollcall rollcall;
        public menu menu;
        public notifications notifications;
        public search search;
        bool sidebar = true, ProfileExpand = false, NotificationExpand = false, SearchExpand = false;
        int inmateid = 0;
        Panel panel = new Panel();
        DataSet dsRoll_Call = new DataSet();

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(OnLoad);
                thread.Start();
            }
            catch (Exception ex)
            {
                config.config.Alerts.ServerMessage(ex.ToString());
            }
           
            // Start notifications timer
            timer.Start();

            // Setting Username to label 
            // lblUsername.Text = (string)Prison.User.Auth[2];

            btnDashboard_Click(new object(), new EventArgs());
        }

        private void OnLoad() 
        {
            // Set Loader
            SetLoading(true);

            // Suspend thread for one second
            Thread.Sleep(1000);
            SetLoading(false);
        }

        private void IsMouseHover(object sender, EventArgs e) 
        {
            MouseHoverleave();
        }
        // On profile click
        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Click sound
            Sound.Click();
            if (sidebar)
                menu.Location = new Point(btnProfile.Location.X + 34, btnProfile.Location.Y + 30);
            else
                menu.Location = new Point(btnProfile.Location.X - 90, btnProfile.Location.Y + 30);
            menuTimer.Start();
            if (NotificationExpand)
                NotificationIconTimer.Start();
            if (SearchExpand)
                SearchTimer.Start();
        }

        private void btnToggleMenu_Click(object sender, EventArgs e)
        {
            // Config.ClickSound();
            SidebarTimer.Start();
        }

        private void Clear()
        {
            pnlBody.Controls.Clear();
            rollcall = null;
            dormitories = null;
            inmates = null;
            visitors = null;
            dashboardControl = null;
            users = null;
            reports = null;
            crimes = null;
        }

        private void btnRollCall_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            bar.Top = (this.btnRollCall).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnRollCall.Text.Trim();
            Path(true);
            Clear();
            rollcall = new components.rollcall(this);
            pnlBody.Controls.Add(rollcall);
            // Set Mouse Hover on Button
            rollcall.MouseHover += IsMouseHover;
            rollcall.Dock = DockStyle.Fill;
            rollcall.BringToFront();
            // Setting theme (Dark/Light)
            ColorScheme.LoadTheme(this.Controls);

            SetLoading(false);
        }

        public void btnDormitory_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            bar.Top = (this.btnDormitory).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnDormitory.Text.Trim();
            Path(true);
            Clear();
            dormitories = new dormitories(this);
            pnlBody.Controls.Add(dormitories);
            // Set Mouse Hover on Button
            dormitories.MouseHover += IsMouseHover;
            dormitories.Dock = DockStyle.Fill;
            dormitories.BringToFront();

            // Setting theme (Dark/Light)
            ColorScheme.LoadTheme(this.Controls);

            SetLoading(false);
        }

        public void Notification(object sender, int id) 
        {
            inmateid = id;
            btnInmate_Click(sender, new EventArgs());
        }
        
        public void btnInmate_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            bar.Top = (this.btnInmate).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnInmate.Text.Trim();
            Path(true);/*
            if (pnlBody.Contains(inmates))
            {
                foreach (Control component in inmates.Controls)
                    if(component.Name == inmates.viewinmate.Name)
                        inmates.Controls.Remove(component);
                //inmates.Controls.Remove(inmates.row.viewinmate);
                inmates.Controls.Remove(inmates.inmate);
                if (inmateid != 0)
                {
                    viewinmate = new components.view.inmate(this, this.inmates);
                    viewinmate.Id = inmateid;
                    this.PathSeparator.Visible = true;
                    this.lblAction.Visible = true;
                    this.lblAction.Text = "View";
                    this.inmates.Controls.Add(viewinmate);
                    viewinmate.Dock = DockStyle.Fill;
                    viewinmate.AutoScroll = true;
                    viewinmate.BringToFront();
                }
                inmates.inmates_Load(sender, e);
                inmates.BringToFront();
            }*/
            Clear();
            inmates = new inmates(this);
            pnlBody.Controls.Add(inmates);
            // Set Mouse Hover on Button
            inmates.MouseHover += IsMouseHover;
            inmates.Dock = DockStyle.Fill;
            inmates.BringToFront();

            // Setting theme (Dark/Light)
            ColorScheme.LoadTheme(this.Controls);

            SetLoading(false);
        }
        
        private void btnVisitors_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            bar.Top = (this.btnVisitors).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnVisitors.Text.Trim();
            Path(true);
            Clear();
            visitors = new visitors(this);
            pnlBody.Controls.Add(visitors);
            // Set Mouse Hover on Button
            visitors.MouseHover += IsMouseHover;
            visitors.Dock = DockStyle.Fill;
            visitors.BringToFront();

            // Setting theme (Dark/Light)
            ColorScheme.LoadTheme(this.Controls);

            SetLoading(false);
        }

        public void Path(bool IsTrue)
        {
            lblAction.Text = "List";
            lblAction.Visible = IsTrue;
            PathSeparator.Visible = IsTrue;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            bar.Top = (this.btnDashboard).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnDashboard.Text.Trim();
            Path(false);
            Clear();
            dashboardControl = new dashboardControl(this);
            pnlBody.Controls.Add(dashboardControl);
            // Set Mouse Hover on Button
            dashboardControl.MouseHover += IsMouseHover;
            dashboardControl.Dock = DockStyle.Fill;
            dashboardControl.BringToFront();

            // Setting theme (Dark/Light)
            ColorScheme.LoadTheme(this.Controls);
            SetLoading(false);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            bar.Top = (this.btnUsers).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnUsers.Text.Trim();
            Path(true);
            Clear();
            users = new users(this);
            pnlBody.Controls.Add(users);
            // Set Mouse Hover on Button
            users.MouseHover += IsMouseHover;
            users.Dock = DockStyle.Fill;
            users.BringToFront();

            // Setting theme (Dark/Light)
            ColorScheme.LoadTheme(this.Controls);

            SetLoading(false);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            bar.Top = (this.btnReports).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnReports.Text.Trim();
            Path(true);
            Clear();
            reports = new reports(this);
            pnlBody.Controls.Add(reports);
            // Set Mouse Hover on Button
            reports.MouseHover += IsMouseHover;
            reports.Dock = DockStyle.Fill;
            reports.BringToFront();

            // Setting theme (Dark/Light)
            ColorScheme.LoadTheme(this.Controls);

            SetLoading(false);
        }

        private void btnCrimes_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            bar.Top = (this.btnCrimes).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnCrimes.Text.Trim();
            Path(true);
            Clear();
            crimes = new crimes(this);
            pnlBody.Controls.Add(crimes);
            // Set Mouse Hover on Button
            crimes.MouseHover += IsMouseHover;
            crimes.Dock = DockStyle.Fill;
            crimes.BringToFront();

            // Setting theme (Dark/Light)
            ColorScheme.LoadTheme(this.Controls);

            SetLoading(false);
        }

        private void BtnClose_MouseHover(object sender, EventArgs e)
        {
            //toolTip.Show("Close Application", btnProfile);

        }

        public void MouseHoverleave()
        {
            if(ProfileExpand)
                menuTimer.Start();
            if(NotificationExpand)
                NotificationIconTimer.Start();
            if(SearchExpand)
                SearchTimer.Start();
        }

        private void Dashboard_Shown(object sender, EventArgs e)
        {
            
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebar)
            {
                btnToggleMenu.Image = Properties.Resources.menu;
                pnlMenu.Width -= 10;
                if (pnlMenu.Width == pnlMenu.MinimumSize.Width)
                {
                    sidebar = false;
                    SidebarTimer.Stop();
                }
            }
            else
            {
                btnToggleMenu.Image = Properties.Resources.back;
                pnlMenu.Width += 10;
                if (pnlMenu.Width == pnlMenu.MaximumSize.Width)
                {
                    sidebar = true;
                    SidebarTimer.Stop();
                }
            }
        }

        private void menuTimer_Tick(object sender, EventArgs e) 
        {
            if (ProfileExpand)
            {
                menu.SendToBack();
                menu.Width += 10;
                if (menu.Width == menu.MaximumSize.Width)
                {
                    ProfileExpand = false;
                    menuTimer.Stop();
                }
            }
            else
            {
                menu.BringToFront();
                menu.Width -= 10;
                if (menu.Width == menu.MinimumSize.Width)
                {
                    ProfileExpand = true;
                    menuTimer.Stop();
                }
            }
        }

        private void btnProfile_MouseLeave(object sender, EventArgs e)
        {
            /*
            if (ProfileCollapse[1] == ProfileCollapse[2])
            {
                Mouseleave();
            }*/
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            // Config.ClickSound();
            timer.Start();
            if (dsRoll_Call != null)
            {
                this.notifications.NotificationflowLayoutPanel.Controls.Clear();
                foreach (DataRow data in dsRoll_Call.Tables["result"].Rows)
                {
                    if (data["status"].ToString() == "0")
                    {
                        message = new message(this, inmates);
                        message.Id = Convert.ToInt32(data["id"]);
                        message.lblTitle.Text = "Roll Call";
                        message.lblMessage.Text = config.config.AES.Decrypt(data["code"].ToString(), Properties.Resources.PassPhrase);
                        message.lblMessage.Text += " - " + config.config.AES.Decrypt(data["last_name"].ToString(), Properties.Resources.PassPhrase);
                        message.lblMessage.Text += ", " + config.config.AES.Decrypt(data["first_name"].ToString(), Properties.Resources.PassPhrase);
                        message.lblMessage.Text += " " + config.config.AES.Decrypt(data["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        message.Icon.Image = Properties.Resources.prisoner;
                        this.notifications.NotificationflowLayoutPanel.Controls.Add(message);
                    }
                }
                ColorScheme.LoadTheme(this.notifications.Controls);
                this.notifications.lblModel.BackColor = Color.White;  
                this.notifications.panel2.BackColor = Color.White;
                this.notifications.NotificationflowLayoutPanel.BackColor = Color.White;
            }
            if (sidebar)
                notifications.Location = new Point(btnNotification.Location.X - 100, btnNotification.Location.Y + 32);
            else
                notifications.Location = new Point(btnNotification.Location.X - 220, btnNotification.Location.Y + 32);
            NotificationIconTimer.Start();
            if (ProfileExpand)
                menuTimer.Start();
            if (SearchExpand)
                SearchTimer.Start();
        }
        private void NotificationIconTimer_Tick(object sender, EventArgs e)
        {
            if (NotificationExpand)
            {
                notifications.SendToBack();
                notifications.Width += 10;
                if (notifications.Width == notifications.MaximumSize.Width)
                {
                    NotificationExpand = false;
                    NotificationIconTimer.Stop();
                }
            }
            else
            {
                notifications.BringToFront();
                notifications.Width -= 10;
                if (notifications.Width == notifications.MinimumSize.Width)
                {
                    NotificationExpand = true;
                    NotificationIconTimer.Stop();
                }
            }
        }

        private void pnlBody_MouseHover(object sender, EventArgs e)
        {
            MouseHoverleave();
        }

        private void pnlMenu_MouseHover(object sender, EventArgs e)
        {
            MouseHoverleave();
        }

        private void pnlHeader_MouseHover(object sender, EventArgs e)
        {
            MouseHoverleave();
        }

        private void SearchTimer_Tick(object sender, EventArgs e)
        {
            if (SearchExpand)
            {
                search.SendToBack();
                search.Width += 10;
                if (search.Width == search.MaximumSize.Width)
                {
                    SearchExpand = false;
                    SearchTimer.Stop();
                }
            }
            else
            {
                search.BringToFront();
                search.Width -= 10;
                if (search.Width == search.MinimumSize.Width)
                {
                    SearchExpand = true;
                    SearchTimer.Stop();
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Prison.Roll_Call = new Roll_Call();
            dsRoll_Call = Prison.Roll_Call.GetFeedBack();
            if (dsRoll_Call != null)
            {
                int count = 0;
                foreach (DataRow data in dsRoll_Call.Tables["result"].Rows)
                    if (data["status"].ToString() == "0")
                        count++;
                lblAlert.Text = count.ToString();
                //timer.Stop();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Config.ClickSound();
            switch (lblModel.Text)
            {
                case "Crimes":
                    btnCrimes_Click(sender, e);
                    break;
                case "Dormitory":
                    btnDormitory_Click(sender, e);
                    break;
                case "Inmates":
                    btnInmate_Click(sender, e);
                    break;
                case "Sentences":
                    //btnCrimes_Click(sender, e);
                    break;
                case "Users":
                    btnUsers_Click(sender, e);
                    break;
                case "Visitors":
                    btnVisitors_Click(sender, e);
                    break;
                case "Roll Call":
                    btnRollCall_Click(sender, e);
                    break;
                case "Dashboard":
                    btnDashboard_Click(sender, e);
                    break;
                case "Reports":
                    btnReports_Click(sender, e);
                    break;
            }
        }

        private void lblModel_Click(object sender, EventArgs e)
        {
            // Config.ClickSound();
            switch (lblModel.Text)
            {
                case "Crimes":
                    btnCrimes_Click(sender, e);
                    break;
                case "Dormitory":
                    btnDormitory_Click(sender, e);
                    break;
                case "Inmates":
                    inmates.Controls.Remove(inmates.inmate);
                    btnInmate_Click(sender, e);
                    break;
                case "Sentences":
                    //btnCrimes_Click(sender, e);
                    break;
                case "Users":
                    btnUsers_Click(sender, e);
                    break;
                case "Visitors":
                    btnVisitors_Click(sender, e);
                    break;
                case "Roll Call":
                    btnRollCall_Click(sender, e);
                    break;
                case "Dashboard":
                    btnDashboard_Click(sender, e);
                    break;
                case "Reports":
                    btnReports_Click(sender, e);
                    break;
            }
        }

        private void lblAction_Click(object sender, EventArgs e)
        {
            
        }

        public delegate void Loading(bool IsLoading);
        public void IsLoading(bool IsLoading)   
        {
            if (IsLoading)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Bunifu.Framework.UI.BunifuCircleProgressbar cpbLoader = new Bunifu.Framework.UI.BunifuCircleProgressbar();

                    // 
                    // cpbLoader
                    // 
                    cpbLoader.animated = true;
                    cpbLoader.animationIterval = 5;
                    cpbLoader.animationSpeed = 10;
                    cpbLoader.BackColor = Color.Transparent;
                    // cpbLoader.BackgroundImage = ((Image)(resources.GetObject("cpbLoader.BackgroundImage")));
                    cpbLoader.BackgroundImageLayout = ImageLayout.Center;
                    MenuTransition.SetDecoration(cpbLoader, BunifuAnimatorNS.DecorationType.None);
                    cpbLoader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
                    cpbLoader.ForeColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
                    cpbLoader.LabelVisible = false;
                    cpbLoader.LineProgressThickness = 8;
                    cpbLoader.LineThickness = 5;
                    cpbLoader.Location = new Point(0, 0);
                    cpbLoader.Margin = new Padding(10, 9, 10, 9);
                    cpbLoader.MaxValue = 100;
                    cpbLoader.Name = "cpbLoader";
                    cpbLoader.ProgressBackColor = Color.Gainsboro;
                    cpbLoader.ProgressColor = Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(104)))), ((int)(((byte)(255)))));
                    cpbLoader.Size = new Size(100, 100);
                    cpbLoader.TabIndex = 17;
                    cpbLoader.Value = 25;

                    // Adding PictureBox to panel control collection
                    panel.Controls.Add(cpbLoader);

                    // Docking the panel to dasboard to fill
                    panel.Dock = DockStyle.Fill;

                    // Setting PictureBox location to be centered
                    cpbLoader.Location = new Point((cpbLoader.Size.Width / 2) - (this.pnlBody.Size.Width / 2), (this.pnlBody.Size.Height / 2));

                    this.pnlBody.Controls.Add(panel);

                    // bring the panel to front of all other controls
                    // panel.BringToFront();

                    panel.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Controls.Remove(panel);
                    this.Cursor = Cursors.Default;
                });
            }
        }
        public void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                Sound.Click();
                this.Invoke((MethodInvoker)delegate
                {
                    panel.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    panel.Visible = false;
                    this.Cursor = Cursors.Default;
                });
            }
        }
    }
}
