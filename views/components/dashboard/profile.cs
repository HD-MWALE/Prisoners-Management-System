using Bunifu.Core;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.SqlServer.Dac.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Roll_Call_And_Management_System.classes.User;
using Color = System.Drawing.Color;

namespace Roll_Call_And_Management_System.views.components.dashboard
{
    public partial class profile : UserControl
    {
        views.dashboard dashboard;
        classes.User User = new classes.User();
        int Id = 0;
        public profile(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            User.dataSet = User.GetUserDetails(Convert.ToInt32(dashboard.user.Auth[0]));
            if(User.dataSet != null)
                foreach(DataRow row in User.dataSet.Tables["result"].Rows) 
                {
                    Id = Convert.ToInt32(row["id"]);
                    lblUsername.Text = AES.Decrypt(row["user_name"].ToString(), Properties.Resources.PassPhrase);
                    txtEmail.Text = AES.Decrypt(row["email"].ToString(), Properties.Resources.PassPhrase);
                    txtFirstName.Text = AES.Decrypt(row["first_name"].ToString(), Properties.Resources.PassPhrase);
                    txtMiddleName.Text = AES.Decrypt(row["middle_name"].ToString(), Properties.Resources.PassPhrase);
                    txtLastName.Text = AES.Decrypt(row["last_name"].ToString(), Properties.Resources.PassPhrase);
                    dtpDateOfBirth.Value = Convert.ToDateTime(row["dob"]); ;
                    dpnGender.Text = AES.Decrypt(row["gender"].ToString(), Properties.Resources.PassPhrase);
                    lblRole.Text = row["role"].ToString();
                }
        }
        private void profile_Load(object sender, EventArgs e)
        {
        }
        new Validate Validate = new Validate();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            User = new classes.User(Id, txtEmail.Text, lblUsername.Text, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, dpnGender.Text, dtpDateOfBirth.Value);
            if (User.Update(Id))
            {
                if (!Validate.IsNull(txtPassword.Text))
                    User.ChangePassword(dashboard.user.Auth, txtPassword.Text);
                Config.Alert("Profile Updated Successfully.", alert.enmType.Success);
            }
            else
                Config.Alert("Something Went Wrong.", alert.enmType.Error);
        }

        ErrorProvider erroremailProvider = new ErrorProvider();
        ErrorProvider errorfirstnameProvider = new ErrorProvider();
        ErrorProvider errormiddlenameProvider = new ErrorProvider();
        ErrorProvider errorlastnameProvider = new ErrorProvider();
        ErrorProvider errordateofBirthProvider = new ErrorProvider();
        ErrorProvider errorgenderProvider = new ErrorProvider();
        ErrorProvider errorroleProvider = new ErrorProvider();
        ErrorProvider errorpasswordProvider = new ErrorProvider(); 
        string emailError = "Please input valid Email Address e.g example@gmail.com";
        string firstnameError = "Please input First Name, enter only characters.";
        string middlenameError = "Please input Middle Name, enter only characters.";
        string lastnameError = "Please input Last Name, enter only characters.";
        string dateofBirthError = "Please select a valid Date of Birth.";
        string genderError = "Please select gender e.g. Male or Female";
        string roleError = "Please select role e.g. Admin or Guard";

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (Validate.IsEmail(txtEmail.Text))
            {
                erroremailProvider.Clear();
                txtEmail.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
            else
            {
                erroremailProvider.SetError(txtEmail, emailError);
                txtEmail.BorderColorActive = Color.Firebrick;
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (!Validate.IsText(txtFirstName.Text))
            {
                errorfirstnameProvider.SetError(txtFirstName, firstnameError);
                txtFirstName.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errorfirstnameProvider.Clear();
                txtFirstName.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void txtMiddleName_Validating(object sender, CancelEventArgs e)
        {
            if (!Validate.IsText(txtMiddleName.Text))
            {
                errormiddlenameProvider.SetError(txtMiddleName, middlenameError);
                txtMiddleName.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errormiddlenameProvider.Clear();
                txtMiddleName.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (!Validate.IsText(txtLastName.Text))
            {
                errorlastnameProvider.SetError(txtLastName, lastnameError);
                txtLastName.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errorlastnameProvider.Clear();
                txtLastName.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void dtpDateOfBirth_Validating(object sender, CancelEventArgs e)
        {
            if (dtpDateOfBirth.Value.Date == DateTime.Now.Date)
            {
                errordateofBirthProvider.SetError(dtpDateOfBirth, dateofBirthError);
                dtpDateOfBirth.ForeColor = Color.Firebrick;
            }
            else
            {
                errordateofBirthProvider.Clear();
                dtpDateOfBirth.ForeColor = Color.FromArgb(17, 17, 18);
            }
        }

        private void dpnGender_Validating(object sender, CancelEventArgs e)
        {
            if (dpnGender.Text == "Select")
            {
                errorgenderProvider.SetError(dpnGender, genderError);
                dpnGender.ItemBorderColor = Color.Firebrick;
            }
            else
            {
                errorgenderProvider.Clear();
                dpnGender.ItemBorderColor = Color.FromArgb(26, 104, 200);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Validate.IsTextNumber(txtPassword.Text))
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '*';
            string error = "The password must be of length between 8-16 characters, and contain at least ONE 1 Lowercase and ONE 1 Uppercase letter.";
           
            if (!Validate.IsPassword(txtPassword.Text))
            {
                errorpasswordProvider.SetError(txtPassword, error);
                txtPassword.BorderColorActive = Color.Firebrick;
                txtPassword.Focus();
            }
            else
            {
                txtPassword.BorderColorActive = Color.FromArgb(26, 104, 200);
                errorpasswordProvider.Clear();
            }
        }
    }
}
