﻿using Prisoners_Management_System.config;
using Prisoners_Management_System.views.components.view;
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
    public partial class history : UserControl
    {
        views.dashboard dashboard;
        view.inmate inmate;
        modal.dialog dialog;
        inputs.history GetHistory;
        view.history ViewHistory; 
        public history(views.dashboard dashboard, view.inmate inmate)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.inmate = inmate;
        }

        public int Id = 0;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            GetHistory = new inputs.history(dashboard);
            GetHistory.Id = Id;
            modal.popup popup = new modal.popup( GetHistory);
            popup.Size = GetHistory.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            inmate.inmate_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            ViewHistory = new view.history(dashboard, this);
            ViewHistory.Id = Id;
            ViewHistory.InmateId = inmate.Id;
            modal.popup popup = new modal.popup( ViewHistory);
            popup.Size = ViewHistory.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            dialog = new modal.dialog();
            dialog.Id = Id;
            dialog.Title = "Delete Inmate History";
            dialog.Message.Text = "You are about to delete a inmate history?";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Text = "Yes";
            dialog.SecondaryButton.Text = "No";
            dialog.PrimaryButton.Click += Yes_Click;
            modal.popup popup = new modal.popup( dialog);
            popup.Size = dialog.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            inmate.inmate_Load(sender, e);
            dashboard.SetLoading(false);
        }
        private void Yes_Click(object sender, EventArgs e)
        {
            dashboard.Prison.Inmate_History.Delete(Id);
            inmate.inmate_Load(sender, e);
            config.config.Alerts.Popup("Inmate History Deleted Successfully.", views.components.dashboard.alert.enmType.Success);
        }
    }
}
