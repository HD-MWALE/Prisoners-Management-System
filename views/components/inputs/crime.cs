﻿using Prisoners_Management_System.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Prisoners_Management_System.classes.Crime;

namespace Prisoners_Management_System.views.components.inputs
{
    public partial class crime : UserControl
    {
        public crime(views.dashboard dashboard)
        {
            InitializeComponent(); 
            this.dashboard = dashboard;
        }
        views.dashboard dashboard;

        private void crime_Load(object sender, EventArgs e) 
        {
            if (Id != 0)
            {
                btnSave.Text = "Update";
            }
        }

        public int Id = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            Sound.Click();
            bool IsMinor = false;
            switch (dpnType.Text)
            {
                case "Minor":
                    IsMinor = true;
                    break;
                case "Major":
                    IsMinor = false;
                    break;
            }

            if (IsMinor) 
                dashboard.Prison.Crime = new classes.Crime(txtName.Text, CrimeType.Minor, txtDescription.Text);
            else
                dashboard.Prison.Crime = new classes.Crime(txtName.Text, CrimeType.Major, txtDescription.Text);

            if (btnSave.Text != "Update")
                if (!dashboard.Prison.Crime.CheckCrime(txtName.Text))
                    if (dashboard.Prison.Crime.Save())
                        config.config.Alerts.Popup("New Crime Saved.", views.components.dashboard.alert.enmType.Success);
                    else
                        config.config.Alerts.Popup("Something Went Wrong.", views.components.dashboard.alert.enmType.Error);
                else
                    config.config.Alerts.Popup("Crime Already Exist.", views.components.dashboard.alert.enmType.Warning);
            else
                if (dashboard.Prison.Crime.Update(Id))
                config.config.Alerts.Popup("Crime Updated.", views.components.dashboard.alert.enmType.Success);
                else
                config.config.Alerts.Popup("Something Went Wrong.", views.components.dashboard.alert.enmType.Error);
        }
        ErrorProvider errornameProvider = new ErrorProvider();
        ErrorProvider errordescriptionProvider = new ErrorProvider();
        ErrorProvider errortypeProvider = new ErrorProvider();
        string nameError = "Please input First Name e.g Bright Mwale";
        string descriptionError = "Please input crime description";
        string typeError = "Please select crime type e.g Major crime or Minor crime";
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errornameProvider.SetError(txtName, nameError);
                txtName.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errornameProvider.Clear();
                txtName.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errordescriptionProvider.SetError(txtDescription, descriptionError);
                txtDescription.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errordescriptionProvider.Clear();
                txtDescription.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void dpnType_Validating(object sender, CancelEventArgs e)
        {
            if (dpnType.Text == "Select")
            {
                errortypeProvider.SetError(dpnType, typeError);
                dpnType.IndicatorColor = Color.Firebrick;
            }
            else
            {
                errortypeProvider.Clear();
                dpnType.IndicatorColor = Color.FromArgb(26, 104, 255);
            }
        }
    }
}
