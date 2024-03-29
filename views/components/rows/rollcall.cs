﻿using Prisoners_Management_System.classes;
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

namespace Prisoners_Management_System.views.components.rows
{
    public partial class rollcall : UserControl
    {
        public rollcall(views.dashboard dashboard, components.rollcall roll)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.roll = roll;
            ColorScheme.LoadTheme(this.Controls);
        }
        public int Id = 0;
        views.dashboard dashboard;
        components.rollcall roll;
        modal.dialog dialog;
        view.rollcall Rollcall;
        private void btnView_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            Rollcall = new view.rollcall(dashboard, this.roll);
            Rollcall.Id = Id;
            dashboard.PathSeparator.Visible = true;
            dashboard.lblAction.Visible = true;
            dashboard.lblAction.Text = "View";
            this.roll.Controls.Add(Rollcall);
            Rollcall.Dock = DockStyle.Fill;
            Rollcall.AutoScroll = true;
            Rollcall.BringToFront();
            dashboard.SetLoading(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            dialog = new modal.dialog();
            dialog.Id = Id;
            dialog.Title = "Delete Crime";
            dialog.Message.Text = "You are about to delete a crime?";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Text = "Yes";
            dialog.SecondaryButton.Text = "No";
            dialog.PrimaryButton.Click += Yes_Click;
            modal.popup popup = new modal.popup(dialog);
            popup.Size = dialog.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            dashboard.Prison.Roll_Call.Delete(Id);
            roll.rollcall_Load(sender, e);
            config.config.Alerts.Popup("Roll Call Deleted Successfully.", views.components.dashboard.alert.enmType.Success);
        }
    }
}
