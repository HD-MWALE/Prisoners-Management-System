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
using System.Xml.Linq;
using static Roll_Call_And_Management_System.classes.Dormitory;

namespace Roll_Call_And_Management_System.views.components.inputs
{
    public partial class dormitory : UserControl
    {
        Dormitory Dormitory; 
        public dormitory() 
        {
            InitializeComponent();
        }

        private void dormitory_Load(object sender, EventArgs e) 
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
            Dormitory = new Dormitory(txtName.Text, txtDescription.Text, dpnGenderType.Text, dpnType.Text);
            if (btnSave.Text != "Update")
            {
                if(!Dormitory.CheckDormitory(txtName.Text))
                    if (Dormitory.Save())
                        Config.Alert("New Dormitory Saved.", dashboard.alert.enmType.Success);
                    else
                        Config.Alert("Something Went Wrong.", dashboard.alert.enmType.Error);
                else
                    Config.Alert("Dormitory Already Exist.", dashboard.alert.enmType.Warning);
            }
            else
            {
                if (Dormitory.Update(Id))
                    Config.Alert("Dormitory Updated.", dashboard.alert.enmType.Success);
                else
                    Config.Alert("Something Went Wrong.", dashboard.alert.enmType.Error);
            }
        }
        ErrorProvider errornameProvider = new ErrorProvider(); 
        ErrorProvider errorcapacityProvider = new ErrorProvider(); 
        ErrorProvider errordescriptionProvider = new ErrorProvider();
        ErrorProvider errorgenderTypeProvider = new ErrorProvider(); 
        ErrorProvider errortypeProvider = new ErrorProvider(); 
        string nameError = "Please input Full Name e.g Bright Mwale";
        string descriptionError = "Please input dormitory description"; 
        string genderTypeError = "Please select gender type of the dormitory e.g Male or Female"; 
        string typeError = "Please select type of dormitory wheather for minor crimes or major crimes"; 
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

        private void dpnGenderType_Validating(object sender, CancelEventArgs e)
        {
            if (dpnGenderType.Text == "Select")
            {
                errorgenderTypeProvider.SetError(dpnGenderType, genderTypeError);
                dpnGenderType.IndicatorColor = Color.Firebrick;
            }
            else
            {
                errorgenderTypeProvider.Clear();
                dpnGenderType.IndicatorColor = Color.FromArgb(26, 104, 255);
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
