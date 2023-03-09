using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Roll_Call_And_Management_System.classes.Crime;

namespace Roll_Call_And_Management_System.views.components.inputs
{
    public partial class crime : UserControl
    {
        classes.Crime Crime;
        public crime()
        {
            InitializeComponent(); 
        }

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
            Config.ClickSound();
            switch (dpnType.Text)
            {
                case "Minor":
                    Crime = new classes.Crime(txtName.Text, CrimeType.Minor, txtDescription.Text);
                    break;
                case "Major":
                    Crime = new classes.Crime(txtName.Text, CrimeType.Major, txtDescription.Text);
                    break;
            }
            if (btnSave.Text != "Update")
                if(!Crime.CheckCrime(txtName.Text))
                    if (Crime.Save())
                        Config.Alert("New Crime Saved.", dashboard.alert.enmType.Success);
                    else
                        Config.Alert("Something Went Wrong.", dashboard.alert.enmType.Error);
                else
                    Config.Alert("Crime Already Exist.", dashboard.alert.enmType.Warning);
            else
                if (Crime.Update(Id))
                    Config.Alert("Crime Updated.", dashboard.alert.enmType.Success);
                else
                    Config.Alert("Something Went Wrong.", dashboard.alert.enmType.Error);
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
