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

namespace Roll_Call_And_Management_System.views
{
    public partial class dashboard : Form 
    {
        public User user;
        PictureBox pictureBox = new PictureBox();
        Panel panel = new Panel();
        Thread thread;
        public dashboard(Thread thread, User user) 
        {
            InitializeComponent();
            this.thread = thread;
            this.user = user;
            Declare();
            this.Controls.Add(panel);
            this.panel.Controls.Add(pictureBox);
            panel.Location = new Point(0, 0);
            panel.Dock = DockStyle.Fill;
            pictureBox.Image = Properties.Resources.Spinner;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Location = new Point((this.Size.Width/2) + 50, (this.Size.Height/2));
            panel.BringToFront();
            Config.LoadTheme(this.Controls);
        }
        System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();
        //View.Component.Dashboard.NotifocationIcon notifocation = new Component.Dashboard.NotifocationIcon();
        public void Language()
        {
            //btnInmate.Text = Properties.en_local.inmates;
            //btnInmate.Text = Properties.chichewa_local.inmates;
        }
        public inmates inmates;
        public (string, int) RollCallInmateId = ("-", 0);
        message message;
        Roll_Call roll_Call;
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

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                thread = new Thread(LoadData);
                thread.Start();
            }
            catch (Exception ex)
            {

            }
            lblFullName.Text = (string)user.Auth[3] + " " + (string)user.Auth[4];
            btnDashboard_Click(sender, e);
            timer.Start();
        }
        void Declare()
        {
            menu = new menu(this);
            notifications = new notifications();
            search = new search();

            this.Controls.Add(menu);
            this.Controls.Add(notifications);
            this.Controls.Add(search);

            dashboardControl = new dashboardControl(this);
            crimes = new crimes(this);
            reports = new reports(this);
            users = new users(this);
            rollcall = new components.rollcall(this);
            dormitories = new dormitories(this);
            inmates = new inmates(this);
            visitors = new visitors(this);

            bar.BringToFront();
            bar.BackColor = Color.FromArgb(26, 104, 255);

            pnlBody.Controls.Add(dashboardControl);
            pnlBody.Controls.Add(crimes);
            pnlBody.Controls.Add(reports);
            pnlBody.Controls.Add(users);
            pnlBody.Controls.Add(rollcall);
            pnlBody.Controls.Add(dormitories);
            pnlBody.Controls.Add(inmates);
            pnlBody.Controls.Add(visitors);

            dashboardControl.Dock = DockStyle.Fill;
            crimes.Dock = DockStyle.Fill;
            reports.Dock = DockStyle.Fill;
            users.Dock = DockStyle.Fill;
            rollcall.Dock = DockStyle.Fill;
            dormitories.Dock = DockStyle.Fill;
            inmates.Dock = DockStyle.Fill;
            visitors.Dock = DockStyle.Fill;

            bar.Visible = false;

            Config.LoadTheme(this.Controls);
        }
        private void LoadData()
        {
            SetLoading(true);

            // Added to see the indicator (not required)
            Thread.Sleep(1000);

            //Security.App.AppSize = this.Size;
            

            menu.Profile.Click += Profile_Click;
            menu.Settings.Click += Settings_Click;
            menu.Help.Click += Help_Click;
            menu.About.Click += About_Click;
            menu.Logout.Click += Logout_Click;
            //this.Controls.Add(notifocation);
            lblAlert.Text = "0";

            dashboardControl.MouseHover += IsMouseHover;
            crimes.MouseHover += IsMouseHover;
            reports.MouseHover += IsMouseHover;
            users.MouseHover += IsMouseHover;
            rollcall.MouseHover += IsMouseHover;
            dormitories.MouseHover += IsMouseHover;
            inmates.MouseHover += IsMouseHover;
            visitors.MouseHover += IsMouseHover;

            if (File.Exists(Config.UserRole))
                if (File.ReadAllText(Config.UserRole) != "Admin")
                {
                    btnProfile.Visible = false;
                    btnCrimes.Visible = false;
                    btnReports.Visible = false;
                }

            SetLoading(false);
        }

        private void IsMouseHover(object sender, EventArgs e) 
        {
            MouseHoverleave();
        }

        private void About_Click(object sender, EventArgs e)
        {
        }

        private void Help_Click(object sender, EventArgs e)
        {
        }

        private void Settings_Click(object sender, EventArgs e)
        {
        }

        private void Profile_Click(object sender, EventArgs e)
        {
        }

        private void Logout_Click(object sender, EventArgs e)
        {
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
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
            Config.ClickSound();
            SidebarTimer.Start();
        }

        private void btnRollCall_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            Config.ClickSound();
            bar.Top = (this.btnRollCall).Top;
            lblModel.Text = btnRollCall.Text;
            Path(true);
            if (pnlBody.Contains(rollcall))
            {
                rollcall.rollcall_Load(sender, e);
                rollcall.BringToFront();
            }
            SetLoading(false);
        }

        public void btnDormitory_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            Config.ClickSound();
            bar.Top = (this.btnDormitory).Top;
            lblModel.Text = btnDormitory.Text;
            Path(true);
            if (pnlBody.Contains(dormitories))
            {
                if (dormitories._dormitory != null)
                    dormitories.Controls.Remove(dormitories._dormitory);
                dormitories.dormitories_Load(sender, e);
                dormitories.BringToFront();
            }
            SetLoading(false);
        }

        public void Notification(object sender, int id) 
        {
            inmateid = id;
            btnInmate_Click(sender, new EventArgs());
        }
        int inmateid = 0;
        components.view.inmate viewinmate;
        public void btnInmate_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            Config.ClickSound();
            bar.Top = (this.btnInmate).Top;
            lblModel.Text = btnInmate.Text;
            Path(true);
            if (pnlBody.Contains(inmates))
            {
                inmates.Controls.Remove(inmates.row.viewinmate);
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
            }
            SetLoading(false);
        }
        
        private void btnVisitors_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            Config.ClickSound();
            bar.Top = (this.btnVisitors).Top;
            lblModel.Text = btnVisitors.Text;
            Path(true);
            if (pnlBody.Contains(visitors))
            {
                if (visitors.visitor != null)
                    visitors.Controls.Remove(visitors.visitor);
                visitors.visitors_Load(sender, e);
                visitors.BringToFront();
            }
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
            Config.ClickSound();
            bar.Top = (this.btnDashboard).Top;
            lblModel.Text = btnDashboard.Text;
            Path(false);
            if (pnlBody.Contains(dashboardControl))
            {
                dashboardControl.dashboardControl_Load(sender, e);
                dashboardControl.LoadDashboard();
                dashboardControl.BringToFront();
            }
            SetLoading(false);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            Config.ClickSound();
            bar.Top = (this.btnUsers).Top;
            lblModel.Text = btnUsers.Text;
            Path(true);
            if (pnlBody.Contains(users))
            {
                users.Controls.Remove(new components.inputs.user(this, users));
                users.users_Load(sender, e);
                users.BringToFront();
            }
            SetLoading(false);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            Config.ClickSound();
            bar.Top = (this.btnReports).Top;
            lblModel.Text = btnReports.Text;
            Path(true);
            if (pnlBody.Contains(reports))
            {
                reports.reports_Load(sender, e);
                reports.BringToFront();
            }
            SetLoading(false);
        }

        private void btnCrimes_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            Config.ClickSound();
            bar.Top = (this.btnCrimes).Top;
            lblModel.Text = btnCrimes.Text;
            Path(true);
            if (pnlBody.Contains(crimes))
            {
                crimes.crimes_Load(sender, e);
                crimes.BringToFront();
            }
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
            Config.ClickSound();
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            pictureBox.Visible = true;
            Thread.Sleep(1000);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox.Visible = false;
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
            Config.ClickSound();
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
            Config.ClickSound();
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
