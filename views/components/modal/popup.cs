using Google.Protobuf.WellKnownTypes;
using Microsoft.SqlServer.TransactSql.ScriptDom;
using Prisoners_Management_System.classes;
using Prisoners_Management_System.views.components.facial;
using Prisoners_Management_System.views.components.inputs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisoners_Management_System.views.components.modal
{
    public partial class popup : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public popup(UserControl control) 
        {
            InitializeComponent();
            this.control = control;
        }
        private UserControl control;
        private inmate inmate;  
        private crime crime;
        private view.user user;
        private history history;
        private view.history viewhistory;  
        private view.viewcrime viewcrime; 
        private view.viewvisitor viewvisitor;
        private dormitory dormitory; 
        private visitor visitor; 
        private dialog dialog; 
        private capture capture; 
        private scan scan; 
        private inputs.rollcall rollcall;
        private inputs.pardonedlist pardonedlist;  
        private dashboard.settings settings; 
        private dashboard.profile profile; 
        private dashboard.about about; 
        private dashboard.help help; 
        public int Id;

        string startupPath = Environment.CurrentDirectory;
        private void popup_Load(object sender, EventArgs e) 
        {
            if (control != null)
            {
                switch (control.Name)
                {
                    case "inmate":
                        Inmate_Load();
                        break;
                    case "profile":
                        Profile_Load();
                        break;
                    case "user":
                        User_Load();
                        break;
                    case "history":
                        History_Load(); 
                        break;
                    case "viewcrime":
                        viewCrime_Load();
                        break;
                    case "viewvisitor":
                        viewVisitor_Load();
                        break;
                    case "crime":
                        Crime_Load(); 
                        break;
                    case "dormitory":
                        Dormitory_Load();
                        break;
                    case "visitor":
                        Visitor_Load(); 
                        break; 
                    case "rollcall":
                        Rollcall_Load();  
                        break;
                    case "pardonedlist":
                        Pardoned_Load();
                        break;
                    case "scan":
                        Scan_Load(); 
                        break;
                    case "capture":
                        Capture_Load();
                        break;
                    case "dialog":
                        Dialog_Load();
                        break;
                    case "settings":
                        Settings_Load();
                        break;
                    case "about":
                        About_Load(); 
                        break;
                    case "help":
                        Help_Load();
                        break;
                    default : break;
                }
            }
            if (Convert.ToBoolean(File.ReadAllText(config.ColorScheme.Path)))
            {
                Header.BackColor = Color.WhiteSmoke;
                Body.BackColor = Color.White;
                Body.ForeColor = Color.FromArgb(42, 42, 49);
                Title.BackColor = Color.FromArgb(26, 104, 255);
                Title.ForeColor = Color.White;
            }
            if (Convert.ToBoolean(File.ReadAllText(config.ColorScheme.Path)))
                config.ColorScheme.LightTheme();
            else
                config.ColorScheme.DarkTheme();
            config.ColorScheme.ChangeTheme(this.Controls);
            if (Convert.ToBoolean(File.ReadAllText(config.ColorScheme.Path)))
            {
                Header.BackColor = Color.FromArgb(26, 104, 255);
                Title.ForeColor = Color.White;
                Title.BackColor = Color.FromArgb(26, 104, 255);
                WindowFrameActiveColor = Color.FromArgb(26, 104, 255);
                btnClose.BackColor = Color.FromArgb(26, 104, 255);
                IconMenu.BackColor = Color.FromArgb(26, 104, 255);

            }
            if (Convert.ToBoolean(File.ReadAllText(config.ColorScheme.Path)))
            {
                if (this.dialog == control)
                {
                    dialog.BackColor = Color.WhiteSmoke;
                    dialog.ForeColor = Color.FromArgb(42, 42, 49);
                }
                if (this.dormitory == control)
                {
                    dormitory.BackColor = Color.WhiteSmoke;
                    dormitory.ForeColor = Color.FromArgb(42, 42, 49);
                }
                if (this.crime == control)
                {
                    crime.BackColor = Color.WhiteSmoke;
                    crime.ForeColor = Color.FromArgb(42, 42, 49);
                }
            }
            this.Paint += Popup_Paint;
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
        private bool childControlsAreHandled = false;
        private Pen activeWindowFramePen, inactiveWindowFramePen;
        private Point[] framePoints;

        public static int WindowFrameSize = 2;
        public static Color WindowFrameActiveColor = Color.White;
        public static Color WindowFrameInactiveColor = SystemColors.ControlDark;
        public static double InactiveWindowOpacity = 1.0;
        public static double WindowFrameOpacity = 0.3;


        private void AddControlPaintHandler(Control ctrl)
        {
            ctrl.Paint += Popup_Paint;
            if (ctrl.Controls != null)
            {
                foreach (Control childControl in ctrl.Controls)
                {
                    AddControlPaintHandler(childControl);
                }
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if ((this.childControlsAreHandled == false)
                && (this.MdiParent == null))
            {
                RecalculateWindowFramePoints();
                AddControlPaintHandler(this);
                this.childControlsAreHandled = true;
            }

            this.isCurrentlyActive = true;
            if (InactiveWindowOpacity < 1)
            {
                base.Opacity = 1;
            }
            base.Invalidate(true);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.isCurrentlyActive = false;
            if (InactiveWindowOpacity < 1)
            {
                base.Opacity = InactiveWindowOpacity;
            }
            base.Invalidate(true);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            this.framePoints = null;
            RecalculateWindowFramePoints();
            this.Invalidate(true);
        }
        private void Popup_Paint(object sender, PaintEventArgs e)
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender, e);
        }

        private void Inmate_Load() 
        {
            if (control != null)
            {
                this.inmate = (inputs.inmate)control;
                this.inmate.Dock = DockStyle.Fill;
                this.inmate.BackColor = Color.FromArgb(42, 42, 49);
                if (inmate.Id == 0)
                    Title.Text = "Add Inmate";
                else
                    Title.Text = "Edit Inmate";
                this.Body.Controls.Add(inmate);
                this.inmate.btnSave.Click += BtnSave_Click;
            }
        }

        private void Crime_Load() 
        {
            if (control != null)
            {
                this.crime = (inputs.crime)control;
                this.crime.Dock = DockStyle.Fill;
                this.crime.BackColor = Color.FromArgb(42, 42, 49);
                if (crime.Id == 0)
                    Title.Text = "Add Crime";
                else
                    Title.Text = "Edit Crime";
                this.Body.Controls.Add(crime);
                this.crime.btnSave.Click += BtnSave_Click;
            }
        }
        private void Dormitory_Load() 
        {
            if (control != null)
            {
                this.dormitory = (inputs.dormitory)control;
                this.dormitory.Dock = DockStyle.Fill;
                this.dormitory.BackColor = Color.FromArgb(42, 42, 49);
                if (dormitory.Id == 0)
                    Title.Text = "Add Dormitory";
                else
                    Title.Text = "Edit Dormitory";
                this.Body.Controls.Add(dormitory);
                this.dormitory.btnSave.Click += BtnSave_Click;
            }
        }
        private void Visitor_Load() 
        {
            if (control != null)
            {
                this.visitor = (inputs.visitor)control;
                this.visitor.Dock = DockStyle.Fill;
                this.visitor.BackColor = Color.FromArgb(42, 42, 49);
                if (visitor.Id == 0)
                    Title.Text = "Add Visitor";
                else
                    Title.Text = "Edit Visitor";
                this.Body.Controls.Add(visitor);
                this.visitor.btnSave.Click += BtnSave_Click;
            }
        }

        private void Capture_Load()  
        {
            if (control != null)
            {
                this.capture = (facial.capture)control;
                this.capture.Dock = DockStyle.Fill;
                this.capture.BackColor = Color.FromArgb(42, 42, 49);
                this.Title.Text = "Facial Characteristics";
                this.Body.Controls.Add(capture);
            }
        }
        private void Scan_Load() 
        {
            if (control != null)
            {
                this.scan = (facial.scan)control;
                this.scan.btnCapture.Click += BtnCapture_Click;
                this.scan.Dock = DockStyle.Fill;
                this.scan.BackColor = Color.FromArgb(42, 42, 49);
                this.Title.Text = "Face Detection";
                this.Body.Controls.Add(scan);
            }
        }

        private void BtnCapture_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender, e);
        }

        private void Pardoned_Load() 
        {
            if (control != null)
            {
                this.pardonedlist = (inputs.pardonedlist)control;
                this.pardonedlist.btnComeUpWithList.Click += btnClose_Click;
                this.pardonedlist.btnView.Click += btnClose_Click;
                this.pardonedlist.Dock = DockStyle.Fill;
                this.pardonedlist.BackColor = Color.FromArgb(42, 42, 49);
                this.Title.Text = "Pardon Inmate";
                this.Body.Controls.Add(pardonedlist);
            }
        }

        private void Rollcall_Load() 
        {
            if (control != null)
            {
                this.rollcall = (inputs.rollcall)control;
                this.rollcall.btnStart.Click += btnClose_Click;
                this.rollcall.Dock = DockStyle.Fill;
                this.rollcall.BackColor = Color.FromArgb(42, 42, 49);
                this.Title.Text = "Roll Call";
                this.Body.Controls.Add(rollcall);
            }
        }
        private void Dialog_Load()
        {
            if (control != null)
            {
                this.dialog = (modal.dialog)control;
                this.dialog.PrimaryButton.Click += btnClose_Click;
                this.dialog.SecondaryButton.Click += btnClose_Click;
                this.dialog.Dock = DockStyle.Fill;
                this.dialog.BackColor = Color.FromArgb(42, 42, 49);
                this.Title.Text = dialog.Title;
                this.Body.Controls.Add(dialog);
            }
        }

        private void Settings_Load()
        {
            if (control != null)
            {
                this.settings = (dashboard.settings)control;
                this.settings.BackColor = Color.FromArgb(42, 42, 49);
                this.Title.Text = "Settings";
                this.Body.Controls.Add(settings);
            }
        }

        private void About_Load()  
        {
            if (control != null)
            {
                this.about = (dashboard.about)control;
                this.about.BackColor = Color.FromArgb(42, 42, 49);
                this.Title.Text = "About";
                this.Body.Controls.Add(about);
            }
        }

        private void Help_Load() 
        {
            if (control != null)
            {
                this.help = (dashboard.help)control;
                this.help.BackColor = Color.FromArgb(42, 42, 49);
                this.Title.Text = "Help";
                this.Body.Controls.Add(help);
            }
        }

        private void viewCrime_Load()
        {
            if (control != null)
            {
                this.viewcrime = (view.viewcrime)control;
                this.viewcrime.Dock = DockStyle.Fill;
                this.viewcrime.BackColor = Color.FromArgb(42, 42, 49);
                this.Title.Text = "Crime Details";
                this.Body.Controls.Add(viewcrime);
            }
        }
        private void viewVisitor_Load()
        {
            if (control != null)
            {
                this.viewvisitor = (view.viewvisitor)control;
                this.viewvisitor.Dock = DockStyle.Fill;
                this.viewvisitor.BackColor = Color.FromArgb(42, 42, 49);
                this.Title.Text = "Visitor Visitor";
                this.Body.Controls.Add(viewvisitor);
            }
        }

        private void Profile_Load() 
        {
            if (control != null)
            {
                this.profile = (dashboard.profile)control; 
                this.profile.Dock = DockStyle.Fill;
                this.profile.BackColor = Color.FromArgb(42, 42, 49);
                this.Title.Text = "Profile";
                this.Body.Controls.Add(profile);
            }
        }

        private void User_Load()
        {
            if (control != null)
            {
                this.user = (view.user)control;
                this.user.Dock = DockStyle.Fill;
                this.user.BackColor = Color.FromArgb(42, 42, 49);
                this.Title.Text = "User Details";
                this.Body.Controls.Add(user);
            }
        }

        private void History_Load() 
        {
            if (control != null)
            {
                if (control is history)
                {
                    this.history = (history)control;
                    this.history.Dock = DockStyle.Fill;
                    this.history.BackColor = Color.FromArgb(42, 42, 49);
                    if (history.Id == 0)
                        Title.Text = "Add Inmate History";
                    else
                        Title.Text = "Edit Inmate History";
                    this.Body.Controls.Add(history);
                    this.history.btnSave.Click += BtnSave_Click;
                }
                else if (control is view.history)
                {
                    this.viewhistory = (view.history)control;
                    this.viewhistory.Dock = DockStyle.Fill;
                    this.viewhistory.BackColor = Color.FromArgb(42, 42, 49);
                    this.Title.Text = "Inmate History";
                    this.Body.Controls.Add(viewhistory); 
                }
            }
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void btnClose_Click(object sender, EventArgs e)
        {
            config.Sound.Click();
            this.Close();
        }
    }
}
