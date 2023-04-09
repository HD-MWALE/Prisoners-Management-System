using Roll_Call_And_Management_System.classes;
using Roll_Call_And_Management_System.config;
using Roll_Call_And_Management_System.views.components.dashboard;
using Roll_Call_And_Management_System.views.components.rows;
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

namespace Roll_Call_And_Management_System.views.components.inputs
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
        ColorScheme scheme = new ColorScheme();

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
            ini.Sound.ClickSound();
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
                        ini.Alerts.Popup("New User Saved.", alert.enmType.Success);
                        btnCancel_Click(sender, e);
                    }
                    else
                        ini.Alerts.Popup("Something Went Wrong.", alert.enmType.Error);
                }
                else
                    ini.Alerts.Popup("Please Connect to the Internet.", alert.enmType.Warning);
            }
            else
            {
                if (dashboard.Prison.User.Update(Id))
                {
                    ini.Alerts.Popup("User Updated.", alert.enmType.Success);
                    btnCancel_Click(sender, e);
                }
                else
                    ini.Alerts.Popup("Something Went Wrong.", alert.enmType.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            ini.Sound.ClickSound();
            users.dashboard.lblAction.Text = "List";
            users.Controls.Remove(this);
            dashboard.SetLoading(false);
        }

        private void user_Load(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                btnSave.Text = "Update";
                dashboard.Prison.User.dataSet = dashboard.Prison.User.GetUsers().Item1;
                if (dashboard.Prison.User.dataSet != null)
                {
                    foreach (DataRow dataRow in dashboard.Prison.User.dataSet.Tables["result"].Rows)
                    {
                        if (Id == Convert.ToInt32(dataRow["id"]))
                        {
                            Id = Convert.ToInt32(dataRow["id"]);
                            txtEmail.Text = ini.AES.Decrypt(dataRow["email"].ToString(), Properties.Resources.PassPhrase);
                            txtUsername.Text = ini.AES.Decrypt(dataRow["user_name"].ToString(), Properties.Resources.PassPhrase);
                            txtFirstName.Text = ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase);
                            txtMiddleName.Text = ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                            txtLastName.Text = ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase);
                            dpnGender.Text = ini.AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                            dtpDateOfBirth.Value = Convert.ToDateTime(dataRow["dob"]);
                            dpnRole.Text = dataRow["role"].ToString();
                        }
                    }
                }
            }
            if (Convert.ToBoolean(File.ReadAllText(ini.ColorScheme.Path)))
            {
                scheme.LightTheme();
            }
            else
            {
                scheme.DarkTheme();
            }
            ini.ColorScheme.ChangeTheme(scheme, this.Controls);
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
            txtUsername.Text += ini.Generate.Random.Next(10, 99) + ini.Generate.Random.Next(100, 999);
        }
        TextBox Gettext = new TextBox();
        
        private void txtLastName_Validated(object sender, EventArgs e)
        {
            GenerateUsername();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (ini.Validate.IsEmail(txtEmail.Text))
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
            if (!ini.Validate.IsText(txtFirstName.Text))
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
            if (!ini.Validate.IsText(txtLastName.Text))
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
