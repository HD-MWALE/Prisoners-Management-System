﻿using DocumentFormat.OpenXml.Office2010.Excel;
using Roll_Call_And_Management_System.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views.components.dashboard
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
            Config.ClickSound();
            dashboard.SetLoading(true);
            //bar.Top = ((Bunifu.Framework.UI.BunifuFlatButton)sender).Top;
            settings = new settings(dashboard, login, true); 
            popup = new modal.popup(dashboard, settings);
            popup.Size = settings.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
            dashboard.SetLoading(true);
            profile = new profile(dashboard);
            popup = new modal.popup(dashboard, profile);
            popup.Size = profile.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void Help_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
            dashboard.SetLoading(true);
            help = new help(dashboard, login);
            popup = new modal.popup(dashboard, help);
            popup.Size = help.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void About_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
            dashboard.SetLoading(true);
            about = new about(dashboard, login);
            popup = new modal.popup(dashboard, about);
            popup.Size = about.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }
        modal.dialog dialog;
        private void Logout_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
            dashboard.SetLoading(true);
            dialog = new modal.dialog();
            dialog.Id = 0;
            dialog.Title = "Log out";
            dialog.Message.Text = "You are about to log out?";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Text = "Yes";
            dialog.SecondaryButton.Text = "No";
            dialog.PrimaryButton.Click += Yes_Click;
            modal.popup popup = new modal.popup(dashboard, dialog);
            popup.Size = dialog.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            dashboard.Hide();
            login  = new login(dashboard, user);
            login.Show();
        }

        private void Exit(object sender, EventArgs e) 
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e) 
        {
            Config.ClickSound();
            dashboard.SetLoading(true);
            dialog = new modal.dialog();
            dialog.Id = 0;
            dialog.Title = "Close Application";
            dialog.Message.Text = "Are you sure to close the application?";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Text = "Yes";
            dialog.SecondaryButton.Text = "No";
            dialog.PrimaryButton.Click += Exit; 
            modal.popup popup = new modal.popup(dashboard, dialog);
            popup.Size = dialog.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }
    }
}
