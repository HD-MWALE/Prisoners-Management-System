using BunifuVSIX.forms;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Roll_Call_And_Management_System.classes;
using Roll_Call_And_Management_System.views.components;
using Roll_Call_And_Management_System.views.components.dashboard;
using Roll_Call_And_Management_System.views.components.modal;
using Roll_Call_And_Management_System.views.components.view;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Control = System.Windows.Forms.Control;

namespace Roll_Call_And_Management_System.views
{
    public partial class dashboard : Form 
    {
        public dashboard(User user) 
        {
            InitializeComponent();
            // Getting user class
            this.user = user;

            this.Controls.Add(panel);

            // Adding PictureBox to panel control collection
            panel.Controls.Add(cpbLoader);

            // Docking the panel to dasboard to fill
            panel.Dock = DockStyle.Fill;

            // Setting PictureBox location to be centered
            cpbLoader.Location = new Point((this.Size.Width / 2) + (cpbLoader.Size.Width / 2), (this.Size.Height / 2));

            // bring the panel to front of all other controls
            panel.BringToFront();

            panel.Visible = true;

            // initalizing UserControls
            menu = new menu(this);
            notifications = new notifications();

            // Adding Controls to dashboard control collection
            this.Controls.Add(menu);
            this.Controls.Add(notifications);

            // Setting theme (Dark/Light)
            Config.LoadTheme(this.Controls);

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
        }
        // Declaring objects
        public User user = new User();
        public inmates inmates;
        message message;
        Roll_Call roll_Call = new Roll_Call();
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
        //inmate viewinmate;

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(OnLoad);
            thread.Start();

            // Set Loader
            SetLoading(true);

            // Suspend thread for one second
            Thread.Sleep(1000);
            /*
            // Set Mouse Hover on Buttons
            dashboardControl.MouseHover += IsMouseHover;
            crimes.MouseHover += IsMouseHover;
            reports.MouseHover += IsMouseHover;
            users.MouseHover += IsMouseHover;
            rollcall.MouseHover += IsMouseHover;
            dormitories.MouseHover += IsMouseHover;
            inmates.MouseHover += IsMouseHover;
            visitors.MouseHover += IsMouseHover;*/

            // Start notifications timer
            timer.Start();

            // Setting Username to label 
            lblUsername.Text = (string)user.Auth[2];

            // Checking user role 
            if (user.Auth[8].ToString() != "Admin")
            {
                // Setting buttons to visible false
                btnUsers.Visible = false;
                btnCrimes.Visible = false;
                btnReports.Visible = false;
            }
            
            btnDashboard_Click(new object(), new EventArgs());
        }

        private void OnLoad() 
        {
            
        }

        private void IsMouseHover(object sender, EventArgs e) 
        {
            MouseHoverleave();
        }
        // On profile click
        private void btnProfile_Click(object sender, EventArgs e)
        {
            // Click sound
            Config.ClickSound();
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

        private void btnRollCall_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            // Config.ClickSound();
            bar.Top = (this.btnRollCall).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnRollCall.Text.Trim();
            Path(true);
            pnlBody.Controls.Clear();
            rollcall = new components.rollcall(this);
            pnlBody.Controls.Add(rollcall);
            rollcall.Dock = DockStyle.Fill;
            rollcall.BringToFront();

            // Setting theme (Dark/Light)
            Config.LoadTheme(this.Controls);

            SetLoading(false);
        }

        public void btnDormitory_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            bar.Top = (this.btnDormitory).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnDormitory.Text.Trim();
            Path(true);
            pnlBody.Controls.Clear();
            dormitories = new dormitories(this);
            pnlBody.Controls.Add(dormitories);
            dormitories.Dock = DockStyle.Fill;
            dormitories.BringToFront();

            // Setting theme (Dark/Light)
            Config.LoadTheme(this.Controls);

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
            pnlBody.Controls.Clear();
            inmates = new inmates(this);
            pnlBody.Controls.Add(inmates);
            inmates.Dock = DockStyle.Fill;
            inmates.BringToFront();

            // Setting theme (Dark/Light)
            Config.LoadTheme(this.Controls);

            SetLoading(false);
        }
        
        private void btnVisitors_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            bar.Top = (this.btnVisitors).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnVisitors.Text.Trim();
            Path(true);
            pnlBody.Controls.Clear();
            visitors = new visitors(this);
            pnlBody.Controls.Add(visitors);
            visitors.Dock = DockStyle.Fill;
            visitors.BringToFront();

            // Setting theme (Dark/Light)
            Config.LoadTheme(this.Controls);

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
            pnlBody.Controls.Clear();
            dashboardControl = new dashboardControl(this);
            pnlBody.Controls.Add(dashboardControl);
            dashboardControl.Dock = DockStyle.Fill;
            dashboardControl.BringToFront();

            // Setting theme (Dark/Light)
            Config.LoadTheme(this.Controls);
            SetLoading(false);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            // Config.ClickSound();
            bar.Top = (this.btnUsers).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnUsers.Text.Trim();
            Path(true);
            pnlBody.Controls.Clear();
            users = new users(this);
            pnlBody.Controls.Add(users);
            users.Dock = DockStyle.Fill;
            users.BringToFront();

            // Setting theme (Dark/Light)
            Config.LoadTheme(this.Controls);

            SetLoading(false);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            // Config.ClickSound();
            bar.Top = (this.btnReports).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnReports.Text.Trim();
            Path(true);
            pnlBody.Controls.Clear();
            reports = new reports(this);
            pnlBody.Controls.Add(reports);
            reports.Dock = DockStyle.Fill;
            reports.BringToFront();

            // Setting theme (Dark/Light)
            Config.LoadTheme(this.Controls);

            SetLoading(false);
        }

        private void btnCrimes_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            // Config.ClickSound();
            bar.Top = (this.btnCrimes).Top;
            bar.BackColor = Color.FromArgb(26, 104, 255);
            lblModel.Text = btnCrimes.Text.Trim();
            Path(true);
            pnlBody.Controls.Clear();
            crimes = new crimes(this);
            pnlBody.Controls.Add(crimes);
            crimes.Dock = DockStyle.Fill;
            crimes.BringToFront();

            // Setting theme (Dark/Light)
            Config.LoadTheme(this.Controls);

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
            if (roll_Call.dataSet != null)
            {
                this.notifications.NotificationflowLayoutPanel.Controls.Clear();
                foreach (DataRow data in roll_Call.dataSet.Tables["result"].Rows)
                {
                    if (data["status"].ToString() == "0")
                    {
                        message = new message(this, inmates);
                        message.Id = Convert.ToInt32(data["id"]);
                        message.lblTitle.Text = "Roll Call";
                        message.lblMessage.Text = AES.Decrypt(data["code"].ToString(), Properties.Resources.PassPhrase);
                        message.lblMessage.Text += " - " + AES.Decrypt(data["last_name"].ToString(), Properties.Resources.PassPhrase);
                        message.lblMessage.Text += ", " + AES.Decrypt(data["first_name"].ToString(), Properties.Resources.PassPhrase);
                        message.lblMessage.Text += " " + AES.Decrypt(data["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        message.Icon.Image = Properties.Resources.prisoner;
                        this.notifications.NotificationflowLayoutPanel.Controls.Add(message);
                    }
                }
                Config.LoadTheme(this.notifications.Controls);
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
            roll_Call = new Roll_Call();
            roll_Call.dataSet = roll_Call.GetFeedBack();
            if (roll_Call.dataSet != null)
            {
                int count = 0;
                foreach (DataRow data in roll_Call.dataSet.Tables["result"].Rows)
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

        public void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
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
