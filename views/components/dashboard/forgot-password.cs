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

namespace Prisoners_Management_System.views.components.dashboard
{
    public partial class forgot_password : UserControl
    {
        login login;
        public forgot_password(login login)
        {
            InitializeComponent();
            this.login = login;
            login.panel2.Controls.Add(this);
            ColorScheme.LoadTheme(this.login.Controls);
        }
        classes.User User = new classes.User();
        private void btnSendCode_Click(object sender, EventArgs e)
        {
            login.SetLoading(true);
            User = new classes.User(txtUserName.Text);
            (bool, bool) IsSuccess = User.ForgotPassword();
            if (IsSuccess.Item2)
            {
                if (IsSuccess.Item1)
                {
                    login.panel2.Controls.Remove(this);
                    config.config.Alerts.Popup("Check your Email.", alert.enmType.Success);
                }
                else
                    config.config.Alerts.Popup("Something Went Wrong.", alert.enmType.Error);
            }
            else
                config.config.Alerts.Popup("Please Connect to the Internet.", alert.enmType.Warning);
            login.SetLoading(false);
        }

        private void llblGoToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
