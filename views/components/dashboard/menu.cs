using DocumentFormat.OpenXml.Office2010.Excel;
using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orientation = Prisoners_Management_System.config.Orientation;

namespace Prisoners_Management_System.views.components.dashboard
{
    public partial class menu : UserControl
    {
        views.dashboard dashboard;
        profile profile; 
        settings settings;
        help help; 
        about about;
        User user = new User();
        login login;
        public menu(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        private void Profile_MouseHover(object sender, EventArgs e)
        {
            Profile.BackColor = System.Drawing.Color.White;
        }

        private void Settings_MouseHover(object sender, EventArgs e)
        {

        }

        private void Help_MouseHover(object sender, EventArgs e)
        {

        }

        private void About_MouseHover(object sender, EventArgs e)
        {
            //bar.Top = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Top;
        }
        public modal.popup popup;
        private void Settings_Click(object sender, EventArgs e)
        {
            Sound.Click();
            dashboard.SetLoading(true);
            //bar.Top = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Top;
            settings = new settings(dashboard, true); 
            popup = new modal.popup(settings);
            popup.Size = settings.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            Sound.Click(); 
            dashboard.SetLoading(true);
            profile = new profile(dashboard);
            popup = new modal.popup( profile);
            popup.Size = profile.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void Help_Click(object sender, EventArgs e)
        {
            Sound.Click();
            dashboard.SetLoading(true);
            help = new help(dashboard, login);
            popup = new modal.popup( help);
            popup.Size = help.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void About_Click(object sender, EventArgs e)
        {
            Sound.Click();
            dashboard.SetLoading(true);
            about = new about(dashboard, login);
            popup = new modal.popup( about);
            popup.Size = about.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }
        modal.dialog dialog;
        private void Logout_Click(object sender, EventArgs e)
        {
            Sound.Click();
            dashboard.SetLoading(true);
            dialog = new modal.dialog();
            dialog.Id = 0;
            dialog.Title = "Log out";
            dialog.Message.Text = "You are about to log out?";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Text = "Yes";
            dialog.SecondaryButton.Text = "No";
            dialog.PrimaryButton.Click += Yes_Click;
            modal.popup popup = new modal.popup( dialog);
            popup.Size = dialog.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            dashboard.Hide();
            login  = new login( user);
            login.Show();
        }

        private void Exit(object sender, EventArgs e) 
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e) 
        {
            Sound.Click();
            dashboard.SetLoading(true);
            dialog = new modal.dialog();
            dialog.Id = 0;
            dialog.Title = "Close Application";
            dialog.Message.Text = "Are you sure to close the application?";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Text = "Yes";
            dialog.SecondaryButton.Text = "No";
            dialog.PrimaryButton.Click += Exit; 
            modal.popup popup = new modal.popup( dialog);
            popup.Size = dialog.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }
    }
}
