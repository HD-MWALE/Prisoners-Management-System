using DocumentFormat.OpenXml.Drawing;
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

namespace Roll_Call_And_Management_System.views.components.dashboard
{
    public partial class settings : UserControl
    {
        views.dashboard dashboard;
        login login;
        bool IsLoggedIn;
        public settings(views.dashboard dashboard, login login, bool isLoggedIn)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.login = login;
            this.IsLoggedIn = isLoggedIn;
        }
        
        private void settings_Load(object sender, EventArgs e)
        {
            if (File.Exists(Config.theme))
            {
                IsTheme = Convert.ToBoolean(File.ReadAllText(Config.theme));
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
            Config.LoadTheme(this.Controls);
            if (File.Exists(Config.sound))
            {
                IsSound = Convert.ToBoolean(File.ReadAllText(Config.sound));
                if (IsSound)
                {
                    Sound.Image = Properties.Resources.toggle_on;
                    btnSound.Image = Properties.Resources.sound;
                    IsSound = false;
                }
                else
                {
                    Sound.Image = Properties.Resources.toggle_off;
                    btnSound.Image = Properties.Resources.mute;
                    IsSound = true;
                }
            }
        }

        bool IsSound = false, IsTheme = false;  
        private void Sound_Click(object sender, EventArgs e) 
        {
            Config.ClickSound();
            if (File.Exists(Config.sound))
            {
                File.WriteAllText(Config.sound, string.Empty);
                File.WriteAllText(Config.sound, IsSound.ToString());
            }
            if (IsSound)
            {
                btnSound.Image = Properties.Resources.sound;
                Sound.Image = Properties.Resources.toggle_on;
                IsSound = false;
            }
            else
            {
                btnSound.Image = Properties.Resources.mute;
                Sound.Image = Properties.Resources.toggle_off;
                IsSound = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            database.Mysql.Restore();
            this.Cursor = Cursors.Default;
            Config.ClickSound();
            dialog = new components.modal.dialog();
            dialog.Id = 0;
            dialog.Title = "Restart Application";
            dialog.Message.Text = "The system will restart...";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Visible = false;
            dialog.SecondaryButton.Text = "OK";
            dialog.SecondaryButton.Click += Restart_Click;
            components.modal.popup popup = new components.modal.popup(dashboard, dialog);
            popup.Size = dialog.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
        }
        dialog dialog;
        private void btnShutdown_Click(object sender, EventArgs e)
        {
        }
        private void Yes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Restart_Click(object sender, EventArgs e) 
        {
            Application.Restart();
        }

        private void ChangeTheme_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
            if (File.Exists(Config.theme))
            {
                File.WriteAllText(Config.theme, string.Empty);
                File.WriteAllText(Config.theme, IsTheme.ToString());
            }
            if (IsLoggedIn) 
            {
                Config.LoadTheme(this.dashboard.Controls);
                Config.LoadTheme(this.dashboard.menu.popup.Controls);
            }
            else
            {
                Config.LoadTheme(this.login.Controls);
                Config.LoadTheme(this.login.popup.Controls);
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
