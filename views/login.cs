using Bunifu.Core;
using crypto;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Ocsp;
using Roll_Call_And_Management_System.classes;
using Roll_Call_And_Management_System.database;
using Roll_Call_And_Management_System.views.components.dashboard;
using Roll_Call_And_Management_System.views.components.modal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views
{
    public partial class login : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        dashboard dashboard;
        components.modal.dialog dialog;
        public login(dashboard dashboard, classes.User user)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.user = user;

            this.Controls.Add(panel);
            this.panel.Controls.Add(pictureBox);
            panel.Location = new Point(0, 0);
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            pictureBox.Image = Properties.Resources.Spinner;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Location = new Point((this.Size.Width / 2) - (pictureBox.Size.Width / 2), (this.Size.Height / 2) - (pictureBox.Size.Width / 2));
            pictureBox.BringToFront();

            Config.LoadTheme(this.Controls);
            this.Paint += login_Paint;
        }
        ErrorProvider errorProvider = new ErrorProvider();
        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        PictureBox pictureBox = new PictureBox();
        Panel panel = new Panel();
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
        Thread thread;
        private void login_Load(object sender, EventArgs e) 
        {
            try
            {
                thread = new Thread(Load1);
                thread.Start();
            }
            catch (Exception ex)
            {

            }
            
        }
        private void Load1()
        {
            SetLoading(true);
            Thread.Sleep(4000);
            //btnLogin.Enabled = false;
            SetLoading(false);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
            SetLoading(true);
            dialog = new dialog();
            dialog.Id = 0;
            dialog.Title = "Close Application";
            dialog.Message.Text = "Are you sure to close the application?";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Text = "Yes";
            dialog.SecondaryButton.Text = "No";
            dialog.PrimaryButton.Click += Yes_Click;
            popup popup = new popup(dashboard, dialog);
            popup.Size = dialog.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            SetLoading(false);
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        User user;
        private int attempts = 3;
        private int seconds = 10;
        ErrorProvider ErrorUsername = new ErrorProvider();
        ErrorProvider ErrorPassword = new ErrorProvider(); 
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
            btnLogin.Iconimage = Properties.Resources.loading;
            if (Validate.IsNull(txtUserName.Text))
            {
                ErrorUsername.SetError(txtUserName, "User Name can not be null.");
                txtUserName.BorderColorActive = Color.Firebrick;
            }
            else if (Validate.IsNull(txtPassword.Text))
            {
                ErrorPassword.SetError(txtPassword, "Password can not be null.");
                txtPassword.BorderColorActive = Color.Firebrick;
            }
            else
            {
                ErrorUsername.Clear();
                ErrorPassword.Clear();
                txtUserName.BorderColorActive = Color.FromArgb(26, 104, 200);
                txtPassword.BorderColorActive = Color.FromArgb(26, 104, 200);
                if (btnLogin.Text == "Login")
                {
                    user = new User(UserName, Password);
                    attempts--;
                    if (attempts >= 0)
                    {
                        this.BackColor = Color.FromArgb(42, 42, 40);
                        (ArrayList, string) responce = user.Login();
                        if (responce.Item2 != "server-error")
                        {
                            user.Auth = responce.Item1;
                            if (user.Auth != null)
                            {
                                if (user.Auth.Contains("regular"))
                                    GiveAccess();
                                else if (user.Auth.Contains("new"))
                                {
                                    btnLogin.Text = "Save";
                                    txtUserName.Text = (string)user.Auth[2];
                                    txtPassword.Text = string.Empty;
                                    txtUserName.Enabled = false;
                                    txtPassword.Focus();
                                }
                                else
                                {

                                }
                            }
                            else
                            {
                                ErrorMessage.ForeColor = Color.Firebrick;
                                ErrorMessage.Text = "Wrong Username or Password,\nYou have " + attempts + " attempt(s) left.";
                                txtUserName.BorderColorIdle = Color.Firebrick;
                                txtPassword.BorderColorIdle = Color.Firebrick;
                                txtUserName.Text = null;
                                txtPassword.Text = null;
                                txtUserName.Focus();
                                this.BackColor = Color.FromArgb(42, 42, 49);
                            }
                        }
                        else
                        {
                            attempts++;
                            ErrorMessage.Text = "Could not connect to the server";
                            ErrorMessage.ForeColor = Color.Firebrick;
                        }

                    }
                    else
                    {
                        AttenptsTimer.Start();
                    }
                }
                else if (btnLogin.Text == "Save")
                {
                    if (user.ChangePassword(user.Auth, txtPassword.Text))
                    {
                        GiveAccess();
                    }
                }
            }
        }
        private void GiveAccess()
        {
            Config.Alert("You Logged in Successfully.", alert.enmType.Success);
            if (File.Exists(Config.UserRole))
            {
                File.WriteAllText(Config.UserRole, string.Empty);
                File.WriteAllText(Config.UserRole, user.Auth[8].ToString());
            }
            dashboard = new dashboard(thread, user);
            dashboard.Show();
            this.Hide();
            ErrorMessage.Text = "Please enter your login details.";
            ErrorMessage.ForeColor = Color.White;
            attempts = 3;
            txtUserName.BorderColorIdle = Color.White;
            txtPassword.BorderColorIdle = Color.White;
            txtUserName.Focus();
            this.ShowInTaskbar = false;
        }
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text != "")
                txtUserName.BorderColorIdle = Color.DarkGreen;
            else
                txtUserName.BorderColorIdle = Color.Firebrick;
            //EnableLoginBtn();
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {

        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
                txtPassword.BorderColorIdle = Color.DarkGreen;
            else
                txtPassword.BorderColorIdle = Color.Firebrick;
            //EnableLoginBtn();
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {

        }
        new Validate Validate = new Validate();
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Validate.IsTextNumber(Password))
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '*';
            string error = "The password must be of length between 8-16 characters, and contain at least ONE 1 Lowercase and ONE 1 Uppercase letter.";
            if (btnLogin.Text == "Save")
            {
                if (!Validate.IsPassword(Password))
                {
                    errorProvider.SetError(txtPassword, error);
                    txtPassword.BorderColorActive = Color.Firebrick;
                    txtPassword.Focus();
                }
                else
                {
                    txtPassword.BorderColorActive = Color.FromArgb(26, 104, 200);
                    errorProvider.Clear();
                }
            }
        }
        
        private void EnableLoginBtn()
        {
            bool[] rep = new bool[2] { false, false };
            switch (txtUserName.Text)
            {
                case "":
                    rep[0] = false;
                    break;
                default:
                    rep[0] = true;
                    break;
            }
            switch (txtPassword.Text)
            {
                case "":
                    rep[1] = false;
                    break;
                default:
                    if(txtPassword.Text.Length > 7)
                        rep[1] = true;
                    break;
            }
            switch (rep[0])
            {
                case true:
                    switch (rep[1])
                    {
                        case true:
                            btnLogin.Enabled = rep[1];
                            break;
                        case false:
                            btnLogin.Enabled = rep[1];
                            break;
                    }
                    break;
                case false:
                    btnLogin.Enabled = rep[0];
                    break;
            }
            if (rep[0] == rep[1] && rep[0] == true)
            {
                btnLogin.Enabled = rep[0];
            }
        }

        public string ButtonText
        {
            get { return this.btnLogin.Text; }
            set { this.btnLogin.Text = value; }
        }

        public string UserName
        {
            get { return this.txtUserName.Text; }
            set { this.txtUserName.Text = value; }
        }

        public string Password
        {
            get { return this.txtPassword.Text; }
            set { this.txtPassword.Text = value; }
        }

        public bool UserNameEnabled
        {
            get { return this.txtPassword.Enabled; }
            set { this.txtPassword.Enabled = value; }
        }
        public string PasswordLabel
        {
            get { return this.lblPassword.Text; }
            set { this.lblPassword.Text = value; }
        }

        private void AttenptsTimer_Tick(object sender, EventArgs e)
        {
            seconds--;
            if (seconds == 0)
            {
                attempts = 3;
                AttenptsTimer.Stop();
            }
        }
        bool SettingsExpand = false; 
        settings settings;
        public popup popup;
        private void btnSettings_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
            SetLoading(true);
            settings = new settings(dashboard, this, false);
            popup = new popup(dashboard, settings);
            popup.Size = settings.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.Icon.Image = Properties.Resources.settings;
            popup.ShowDialog();
            SetLoading(false);
        }

        private Pen ActivePen
        {
            get
            {
                if (this.isCurrentlyActive)
                {
                    if (this.activeWindowFramePen == null)
                    {
                        this.activeWindowFramePen = new Pen(Color.FromArgb((int)(WindowFrameOpacity * 255), WindowFrameActiveColor), WindowFrameSize * 2);
                    }
                    return this.activeWindowFramePen;
                }
                else
                {
                    if (this.inactiveWindowFramePen == null)
                    {
                        this.inactiveWindowFramePen = new Pen(Color.FromArgb((int)(WindowFrameOpacity * 255), WindowFrameInactiveColor), WindowFrameSize * 2);
                    }
                    return this.inactiveWindowFramePen;
                }
            }
        }

        private Point[] RecalculateWindowFramePoints()
        {
            if ((this.framePoints != null)
                && (this.framePoints.Length != 5))
            {
                this.framePoints = null;
            }
            if ((this.framePoints != null)
                && (this.framePoints.Length != 2))
            {
                this.framePoints = null;
            }
            if (this.framePoints == null)
            {
                this.framePoints = new Point[5]
                    {
                    new Point(this.ClientRectangle.X, this.ClientRectangle.Y),
                    new Point(this.ClientRectangle.X + this.ClientRectangle.Width, this.ClientRectangle.Y),
                    new Point(this.ClientRectangle.X + this.ClientRectangle.Width, this.ClientRectangle.Y + this.ClientRectangle.Height),
                    new Point(this.ClientRectangle.X, this.ClientRectangle.Y + this.ClientRectangle.Height),
                    new Point(this.ClientRectangle.X, this.ClientRectangle.Y)
                    };
            }
            return this.framePoints;
        }
        private bool isCurrentlyActive = false;
        private Pen activeWindowFramePen, inactiveWindowFramePen;
        private Point[] framePoints;

        public static int WindowFrameSize = 2;
        public static Color WindowFrameActiveColor = Color.White;
        public static Color WindowFrameInactiveColor = SystemColors.ControlDark;
        public static double InactiveWindowOpacity = 1.0;
        public static double WindowFrameOpacity = 0.3;

        private void AddControlPaintHandler(Control ctrl)
        {
            ctrl.Paint += login_Paint;
            if (ctrl.Controls != null)
            {
                foreach (Control childControl in ctrl.Controls)
                {
                    AddControlPaintHandler(childControl);
                }
            }
        }

        private void login_Paint(object sender, PaintEventArgs e)
        {
            if ((this.framePoints == null) || (this.framePoints.Length == 0))
            {
                return;
            }
            Control ctrl = (Control)(sender);
            List<Point> pts = new List<Point>();
            foreach (var p in this.framePoints)
            {
                pts.Add(ctrl.PointToClient(this.PointToScreen(p)));
            }
            e.Graphics.DrawLines(ActivePen, pts.ToArray());
        }

        private void login_Activated(object sender, EventArgs e)
        {
        }

        private void login_Deactivate(object sender, EventArgs e)
        {
        }
        public forgot_password forgot_Password;
        private void llblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetLoading(true);
            forgot_Password = new forgot_password(this);
            forgot_Password.Location = new Point(149, 216);
            forgot_Password.llblGoToLogin.Click += BtnBack_Click;
            forgot_Password.BringToFront();
            SetLoading(false);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            SetLoading(true);
            panel2.Controls.Remove(forgot_Password);
            SetLoading(false);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            this.framePoints = null;
            RecalculateWindowFramePoints();
            this.Invalidate(true);
        }
    }
}
