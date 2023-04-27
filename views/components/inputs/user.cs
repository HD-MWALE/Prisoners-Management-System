using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
using Prisoners_Management_System.views.components.dashboard;
using Prisoners_Management_System.views.components.rows;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisoners_Management_System.views.components.inputs
{
    public partial class user : UserControl
    {
        public user(views.dashboard dashboard, users users) 
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.users = users;
        }
        public int Id = 0;
        public int ButtonCount = 0;
        views.dashboard dashboard;
        users users;
        DataSet dsUsers = new DataSet();

        User.UserRole Role;
        private void btnBack_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }

        private void dpnPrison_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Sound.Click();
            dashboard.Prison.User = new User(txtEmail.Text,
                            txtUsername.Text,
                            txtFirstName.Text,
                            txtMiddleName.Text,
                            txtLastName.Text,
                            dpnGender.Text,
                            dtpDateOfBirth.Value.Date,
                            Role);
            if (btnSave.Text != "Update")
            {
                (bool, bool) IsSave = dashboard.Prison.User.Save();
                if (IsSave.Item2)
                {
                    if (IsSave.Item1)
                    {
                        config.config.Alerts.Popup("New User Saved.", alert.enmType.Success);
                        btnCancel_Click(sender, e);
                    }
                    else
                        config.config.Alerts.Popup("Something Went Wrong.", alert.enmType.Error);
                }
                else
                    config.config.Alerts.Popup("Please Connect to the Internet.", alert.enmType.Warning);
            }
            else
            {
                if (dashboard.Prison.User.Update(Id))
                {
                    config.config.Alerts.Popup("User Updated.", alert.enmType.Success);
                    btnCancel_Click(sender, e);
                }
                else
                    config.config.Alerts.Popup("Something Went Wrong.", alert.enmType.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            users.dashboard.lblAction.Text = "List";
            users.Controls.Remove(this);
            dashboard.SetLoading(false);
        }

        private void user_Load(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                btnSave.Text = "Update";
                dsUsers = dashboard.Prison.User.GetUsers().Item1;
                if (dsUsers != null)
                {
                    foreach (DataRow dataRow in dsUsers.Tables["result"].Rows)
                    {
                        if (Id == Convert.ToInt32(dataRow["id"]))
                        {
                            Id = Convert.ToInt32(dataRow["id"]);
                            txtEmail.Text = dataRow["email"].ToString();
                            txtUsername.Text = dataRow["user_name"].ToString();
                            txtFirstName.Text = dataRow["first_name"].ToString();
                            txtMiddleName.Text = dataRow["middle_name"].ToString();
                            txtLastName.Text = dataRow["last_name"].ToString();
                            dpnGender.Text = dataRow["gender"].ToString();
                            dtpDateOfBirth.Value = Convert.ToDateTime(dataRow["dob"]);
                            dpnRole.Text = dataRow["role"].ToString();
                        }
                    }
                }
            }
            if (Convert.ToBoolean(File.ReadAllText(ColorScheme.Path)))
            {
                ColorScheme.LightTheme();
            }
            else
            {
                ColorScheme.DarkTheme();
            }
            ColorScheme.ChangeTheme(this.Controls);
        }

        private void dpnRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpnRole.Text == "Admin")
                Role = User.UserRole.Admin;
            else
                Role = User.UserRole.Guard;
        }

        ErrorProvider erroremailProvider = new ErrorProvider();
        ErrorProvider errorfirstnameProvider = new ErrorProvider();
        ErrorProvider errorlastnameProvider = new ErrorProvider();
        ErrorProvider errordateofBirthProvider = new ErrorProvider();
        ErrorProvider errorgenderProvider = new ErrorProvider();
        ErrorProvider errorroleProvider = new ErrorProvider();
        string emailError = "Please input valid Email Address e.g example@gmail.com";
        string firstnameError = "Please input First Name, enter only characters.";
        string lastnameError = "Please input First Name, enter only characters.";
        string dateofBirthError = "Please select a valid Date of Birth.";
        string genderError = "Please select gender e.g. Male or Female";
        string roleError = "Please select role e.g. Admin or Guard";
        void ValidateInputs(object sender, CancelEventArgs e) 
        {
            txtEmail_Validating(sender, e);
            txtFirstName_Validating(sender, e);
            txtLastName_Validating(sender, e);
            dtpDateOfBirth_Validating(sender, e);
            dpnGender_Validating(sender, e);
            dpnRole_Validating(sender, e);
            if(erroremailProvider.GetError(txtEmail) == "")
            {
                e.Cancel = true;
            }
        }
        void GenerateUsername()
        {
            txtUsername.Text = txtFirstName.Text.Trim().ToLower();
            txtUsername.Text += txtLastName.Text.Trim().ToLower();
            txtUsername.Text += config.config.Generate.Random.Next(10, 99) + config.config.Generate.Random.Next(100, 999);
        }
        TextBox Gettext = new TextBox();
        
        private void txtLastName_Validated(object sender, EventArgs e)
        {
            GenerateUsername();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (config.config.Validate.IsEmail(txtEmail.Text))
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
            if (!config.config.Validate.IsText(txtFirstName.Text))
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
            
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (!config.config.Validate.IsText(txtLastName.Text))
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

        private void dpnRole_Validating(object sender, CancelEventArgs e)
        {
            if (dpnRole.Text == "Select")
            {
                errorroleProvider.SetError(dpnRole, roleError);
                dpnRole.ItemBorderColor = Color.Firebrick;
            }
            else
            {
                errorroleProvider.Clear();
                dpnRole.ItemBorderColor = Color.FromArgb(26, 104, 200);
            }
        }

        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
