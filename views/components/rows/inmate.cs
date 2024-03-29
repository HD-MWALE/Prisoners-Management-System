﻿using Prisoners_Management_System.config;
using System;
using System.Collections;
using System.Windows.Forms;

namespace Prisoners_Management_System.views.components.rows
{
    public partial class inmate : UserControl
    {
        public inmate(views.dashboard dashboard, inmates inmates)
        {
            InitializeComponent();
            // initializing objects
            this.dashboard = dashboard;
            this.inmates = inmates;
            Id = ActionId.Item2;
            // setting theme
            ColorScheme.LoadTheme(this.Controls);
        }
        // declaring and initializing objects
        public int Id = 0;
        public (string, int) ActionId = ("-", 0); 
        public int status = 1;
        private views.dashboard dashboard;
        private inmates inmates;
        inputs.inmate _inmate;
        public string specifier = "";
        modal.dialog dialog;
        // user control on loading
        private void inmate_Load(object sender, EventArgs e) 
        {
            if(ActionId.Item2 != 0)
            {
                if (ActionId.Item1 == "Edit")
                    btnEdit_Click(sender, e); // go to editing section
                else if(ActionId.Item1 == "View")
                    btnView_Click(sender, e); // go to viewing section
                ActionId.Item2 = 0;
                ActionId.Item1 = "-";
                specifier = "-";
            }
        }
        // user control on mouse hover
        private void inmate_MouseHover(object sender, EventArgs e) 
        {
            RowHover();
        }
        // user control on mouse leave
        private void inmate_MouseLeave(object sender, EventArgs e) 
        {
            RowLeave();
        }
        private void RowHover()
        {
        }
        private void RowLeave()
        {
        }
        // user control on click
        private void inmate_Click(object sender, EventArgs e) 
        {
            View_Inmate();
        }
        private void View_Inmate()
        {/*
            Dashboard.Blur(false);
            Popup popup = new Popup();
            //MessageBox.Show("This is the id = " + lblId.Text);
            Popup.size = new int[2] { 261, 420 };
            Popup.load = 3;
            Popup.title = "View Inmate";
            Views.Controls.Inmates.View.id = lblId.Text;
            Views.Controls.Inmates.View.inmatecode = lblInmateCode.Text;
            Views.Controls.Inmates.View.firstname = lblFirstname.Text;
            Views.Controls.Inmates.View.middlename = lblMiddlename.Text;
            Views.Controls.Inmates.View.familyname = lblFamilyname.Text;
            Views.Controls.Inmates.View.gender = lblGender.Text;
            Views.Controls.Inmates.View.dob = lblDoB.Text;
            popup.ShowDialog();
            Dashboard.Blur(true);*/
        }
        // go to editing section
        private void btnEdit_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            inputs.inmate inmate = new inputs.inmate(this.inmates);
            modal.popup popup = new modal.popup(inmate);
            popup.Size = inmate.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            inmates.inmates_Load(sender, e);
            dashboard.SetLoading(false);
            /*
            dashboard.SetLoading(true);
            Sound.Click();
            _inmate = new inputs.inmate(inmates);
            _inmate.Id = Id;
            dashboard.PathSeparator.Visible = true;
            dashboard.lblAction.Visible = true;
            dashboard.lblAction.Text = "Edit";
            this.inmates.Controls.Add(_inmate);
            _inmate.Dock = DockStyle.Fill;
            _inmate.BringToFront();
            ColorScheme.LoadTheme(this.inmates.Controls);
            dashboard.SetLoading(false);*/
        }
        // go to viewing section
        private void btnView_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            inmates.viewinmate.Id = Id;
            dashboard.PathSeparator.Visible = true;
            dashboard.lblAction.Visible = true;
            dashboard.lblAction.Text = "View";
            this.inmates.Controls.Add(inmates.viewinmate);
            inmates.viewinmate.Dock = DockStyle.Fill;
            inmates.viewinmate.AutoScroll = true;
            inmates.viewinmate.BringToFront();
            dashboard.SetLoading(false);
        }
        // delete an inmate
        private void btnDelete_Click(object sender, EventArgs e) 
        {
            dashboard.SetLoading(true);
            dialog = new modal.dialog();
            dialog.Id = Id;
            dialog.Title = "Delete Inmate";
            dialog.Message.Text = "You are about to delete a Inmate?";
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
        // confirm deleting an inmate
        private void Yes_Click(object sender, EventArgs e)
        {
            dashboard.Prison.Inmate.Delete(Id);
            inmates.inmates_Load(sender, e);
            config.config.Alerts.Popup("Inmate Deleted Successfully.", views.components.dashboard.alert.enmType.Success);
        }
    }
}
