using DocumentFormat.OpenXml.Drawing;
using Roll_Call_And_Management_System.config;
using Roll_Call_And_Management_System.views.components.modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orientation = Roll_Call_And_Management_System.config.Orientation;

namespace Roll_Call_And_Management_System.views.components.dashboard
{
    public partial class settings : UserControl
    {
        views.dashboard dashboard;
        dialog dialog;
        login login;
        bool IsSound = false, IsTheme = false, IsLoggedIn;
        ColorScheme scheme = new ColorScheme();
        public settings(Form layout, bool isLoggedIn) 
        {
            InitializeComponent();
            if(layout.Name == "dashboard")
                this.dashboard = (views.dashboard)layout;
            else if(layout.Name == "login")
                this.login = (login)layout;
            this.IsLoggedIn = isLoggedIn;
        }
        
        private void settings_Load(object sender, EventArgs e)
        {
            if (File.Exists(scheme.Path))
            {
                IsTheme = Convert.ToBoolean(File.ReadAllText(scheme.Path));
                if (IsTheme)
                {
                    btnMode.Image = Properties.Resources.sun;
                    ChangeTheme.Image = Properties.Resources.toggle_on;
                    lblMode.Text = "Light Mode";
                    IsTheme = false;
                }
                else
                {
                    btnMode.Image = Properties.Resources.moon_and_stars;
                    ChangeTheme.Image = Properties.Resources.toggle_off;
                    lblMode.Text = "Dark Mode";
                    IsTheme = true;
                }
            }
            scheme.LoadTheme(this.Controls);
            if (File.Exists(scheme.Path))
            {
                IsSound = Convert.ToBoolean(File.ReadAllText(scheme.Path));
                if (IsSound)
                {
                    btnIsSound.Image = Properties.Resources.toggle_on;
                    btnSound.Image = Properties.Resources.sound;
                    IsSound = false;
                }
                else
                {
                    btnIsSound.Image = Properties.Resources.toggle_off;
                    btnSound.Image = Properties.Resources.mute;
                    IsSound = true;
                }
            }
        }

        private void Sound_Click(object sender, EventArgs e) 
        {
            ini.Sound.ClickSound(); 
            if (File.Exists(scheme.Path))
            {
                File.WriteAllText(Sound.sound, string.Empty);
                File.WriteAllText(Sound.sound, IsSound.ToString());
            }
            if (IsSound)
            {
                btnSound.Image = Properties.Resources.sound;
                btnIsSound.Image = Properties.Resources.toggle_on;
                IsSound = false;
            }
            else
            {
                btnSound.Image = Properties.Resources.mute;
                btnIsSound.Image = Properties.Resources.toggle_off;
                IsSound = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            database.Mysql.Restore();
            this.Cursor = Cursors.Default;
            ini.Sound.ClickSound();
            dialog = new dialog();
            dialog.Id = 0;
            dialog.Title = "Restart Application";
            dialog.Message.Text = "The system will restart...";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Visible = false;
            dialog.SecondaryButton.Text = "OK";
            dialog.SecondaryButton.Click += Restart_Click;
            popup popup = new popup(dialog);
            popup.Size = dialog.Size;
            popup.Location = ini.Orientation.GetLocation(ini.AppSize, popup.Size, ini.AppLocation);
            popup.ShowDialog();

        }

        private void Restart_Click(object sender, EventArgs e) 
        {
            Application.Restart();
        }

        private void ChangeTheme_Click(object sender, EventArgs e)
        {
            ini.Sound.ClickSound();
            if (File.Exists(scheme.Path))
            {
                File.WriteAllText(scheme.Path, string.Empty);
                File.WriteAllText(scheme.Path, IsTheme.ToString());
                if (IsLoggedIn)
                {
                    scheme.LoadTheme(this.dashboard.Controls);
                    scheme.LoadTheme(this.dashboard.menu.popup.Controls);
                }
                else
                {
                    scheme.LoadTheme(this.login.Controls);
                    scheme.LoadTheme(this.login.popup.Controls);
                }
            }
           
            if (IsTheme)
            {
                ChangeTheme.Image = Properties.Resources.toggle_on;
                btnMode.Image = Properties.Resources.sun;
                lblMode.Text = "Light Mode";
                IsTheme = false;
            }
            else
            {
                ChangeTheme.Image = Properties.Resources.toggle_off;
                btnMode.Image = Properties.Resources.moon_and_stars;
                lblMode.Text = "Dark Mode";
                IsTheme = true;
            }
        }
    }
}
