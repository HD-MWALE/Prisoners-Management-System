using Prisoners_Management_System.classes;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Prisoners_Management_System.views.components.dashboard;
using Prisoners_Management_System.config;

namespace Prisoners_Management_System.views.components.inputs
{
    public partial class inmate : UserControl
    {
        public inmates inmates;
        DataSet dsDormitories = new DataSet();
        public DataSet dsCrimes = new DataSet(); 
        DataSet dsInmates = new DataSet();
        public ArrayList Crimes = new ArrayList();
        public ArrayList CrimeTypes = new ArrayList();

        public inmate(inmates inmates) 
        {
            InitializeComponent();
            this.inmates = inmates;

            dsDormitories = inmates.dashboard.Prison.Dormitory.GetDormitories();

            dsCrimes = inmates.dashboard.Prison.Crime.GetCrimes();
            if (dsCrimes != null)
            {
                this.dpnCrimes.Items.Clear();
                foreach (DataRow dataRow in dsCrimes.Tables["result"].Rows)
                    this.dpnCrimes.Items.Add((string)dataRow["name"]);
            }
           ColorScheme.LoadTheme(this.inmates.Controls);
        }
        public int Id = 0;
        public int ButtonCount = 0;
        modal.dialog dialog;

        public void inmate_Load(object sender, EventArgs e) 
        {
            dsInmates = inmates.dashboard.Prison.Inmate.GetInmates();
            txtCode.Text = "Inmate" + (dsInmates.Tables["result"].Rows.Count + 1);
            dtpDateOfBirth.MaxDate = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + (DateTime.Now.Year - 18));
            dtpTimeServedStart.MaxDate = DateTime.Now;
            if (Id != 0)
            {
                btnSave.Text = "Update";
                if (dsInmates != null)
                    foreach (DataRow dataRow in dsInmates.Tables["result"].Rows)
                    {
                        if ((int)dataRow["id"] == Id)
                        {
                            dpnDormitory.Text = inmates.dashboard.Prison.Dormitory.GetName(Convert.ToInt32(dataRow["dormitory_id"]));
                            txtCode.Text = dataRow["code"].ToString();
                            txtFirstName.Text = dataRow["first_name"].ToString();
                            txtMiddleName.Text = dataRow["middle_name"].ToString();
                            txtLastName.Text = dataRow["last_name"].ToString();
                            dpnGender.Text = dataRow["gender"].ToString();
                            dtpDateOfBirth.MaxDate = Convert.ToDateTime(dataRow["dob"]);
                            dtpDateOfBirth.Value = Convert.ToDateTime(dataRow["dob"]);
                            txtEyeColour.Text = (string)dataRow["eye_color"];
                            txtComplexion.Text = (string)dataRow["complexion"];
                            txtAddress.Text = dataRow["address"].ToString();
                            dpnMaritalStatus.Text = dataRow["marital_status"].ToString();
                            dtpTimeServedStart.Value = Convert.ToDateTime((DateTime)dataRow["start_date"]);
                            dtpTimeServedEnd.Value = Convert.ToDateTime(Convert.ToDateTime(dataRow["end_date"]).ToString("yyyy/MM/dd hh:mm:ss tt"));
                            txtName.Text = dataRow["emergency_name"].ToString();
                            txtRelation.Text = dataRow["emergency_relation"].ToString();
                            txtContact.Text = dataRow["emergency_contact"].ToString();
                            break;
                        }
                    }
            }
            else
            {
                dtpTimeServedEnd.MinDate = DateTime.Now;
            }
        }

        private bool Validate_Inputs()
        {
            // Checking errors from the inputs
            var errorfirstname = errorfirstnameProvider.GetError(txtFirstName);
            if(errorfirstname != null) { return false; }

            var errormiddlename = errormiddlenameProvider.GetError(txtMiddleName);
            if(errormiddlename != null) { return false; }

            var errordateofBirth = errordateofBirthProvider.GetError(dtpDateOfBirth);
            if(errordateofBirth != null) { return false; }

            var errorgender = errorgenderProvider.GetError(dpnGender);
            if(errorgender != null) { return false; }

            var erroraddress = erroraddressProvider.GetError(txtAddress);
            if(erroraddress != null) { return false; }

            var errormaritalstatus = errormaritalstatusProvider.GetError(dpnMaritalStatus);
            if(errormaritalstatus != null) { return false; }

            var errorcomplexion = errorcomplexionProvider.GetError(txtComplexion);
            if(errorcomplexion != null) { return false; }

            var erroreyeColour = erroreyeColourProvider.GetError(txtEyeColour);
            if(erroreyeColour != null) { return false; }

            var errorcrimes = errorcrimesProvider.GetError(dpnCrimes);
            if(errorcrimes != null) { return false; }

            var errortimeServedStart = errortimeServedStartProvider.GetError(dtpTimeServedStart);
            if(errortimeServedStart != null) { return false; }

            var errortimeServedEnd = errortimeServedEndProvider.GetError(dtpTimeServedEnd);
            if(errortimeServedEnd != null) { return false; }

            var errordormitory = errordormitoryProvider.GetError(dpnDormitory);
            if(errordormitory != null) { return false; }

            var errorname = errornameProvider.GetError(txtName);
            if(errorname != null) { return false; }

            var errorrelation = errorrelationProvider.GetError(txtRelation);
            if(errorrelation != null) { return false; }

            var errorcontact = errorcontactProvider.GetError(txtContact);
            if (errorcontact != null) { return false; }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Sound.Click();
            if (Validate_Inputs())
            {
                inmates.dashboard.Prison.Inmate = new Inmate(Id, txtCode.Text,
                                    txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, dpnGender.Text, dtpDateOfBirth.Value.Date,
                                    txtAddress.Text, dpnMaritalStatus.Text, txtEyeColour.Text, txtComplexion.Text,
                                    new Crimes_Committed(Crimes), txtName.Text, txtContact.Text,
                                    txtRelation.Text, 1, new Sentence(dtpTimeServedStart.Value.Date, dtpTimeServedEnd.Value.Date, 1), new Dormitory(dpnDormitory.Text));
                if (btnSave.Text != "Update")
                {
                    if (inmates.dashboard.Prison.Inmate.Save())
                    {
                        config.config.Alerts.Popup("New Inmate Saved.", dashboard.alert.enmType.Success);
                        btnCancel_Click(sender, e);
                    }
                    else
                        config.config.Alerts.Popup("Something Went Wrong.", dashboard.alert.enmType.Error);
                }
                else
                {
                    if (inmates.dashboard.Prison.Inmate.Update(Id))
                    {
                        config.config.Alerts.Popup("Inmate Updated.", dashboard.alert.enmType.Success);
                        btnCancel_Click(sender, e);
                    }
                    else
                        config.config.Alerts.Popup("Something Went Wrong.", dashboard.alert.enmType.Error);
                }
            }
            else
            {
                inmates.dashboard.SetLoading(true);
                dialog = new modal.dialog();
                dialog.Id = Id;
                dialog.Title = "Error";
                dialog.Message.Text = "Please fill in all field.";
                dialog.Icon.Image = Properties.Resources.error;
                dialog.PrimaryButton.Visible = false;
                dialog.SecondaryButton.Text = "OK";
                modal.popup popup = new modal.popup(dialog);
                popup.Size = dialog.Size;
                popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
                popup.ShowDialog();
                inmates.dashboard.SetLoading(false);
            }
        }

        private void dpnGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dpnGender.Text != "Select")
            {
                dsDormitories = inmates.dashboard.Prison.Dormitory.GetDormitories();
                if (dsDormitories != null)
                {
                    this.dpnDormitory.Items.Clear();
                    foreach (DataRow dataRow in dsDormitories.Tables["result"].Rows)
                        if(Convert.ToString(dataRow["gendertype"]) == dpnGender.Text)
                            this.dpnDormitory.Items.Add(Convert.ToString(dataRow["name"]));
                }
            }
        }
        private void dpnCrimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool IsAdded = false;
            foreach(string name in Crimes)  
            {
                if (name == dpnCrimes.Text)
                {
                    config.config.Alerts.Popup("Crime Already Added.", alert.enmType.Warning);
                    IsAdded = true;
                    break;
                }
            }
            if (!IsAdded)
            {
                sub.crime crime = new sub.crime(this);
                crime.txtCrime.Text = dpnCrimes.Text;
                crime.Name = dpnCrimes.Text;
                Crimes.Add(dpnCrimes.Text);
                pnlCrimeCommitted.Controls.Add(crime);
                if (dsCrimes != null)
                {
                    foreach (DataRow dataRow in dsCrimes.Tables["result"].Rows)
                        if ((string)dataRow["name"] == dpnCrimes.Text)
                            CrimeTypes.Add(dataRow["type"]);
                }
            }
            Allocate();
        }

        public void Allocate()
        {
            if (dsDormitories != null)
            {
                this.dpnDormitory.Items.Clear();
                if (CrimeTypes.Contains("Major"))
                {
                    foreach (DataRow dataRow in dsDormitories.Tables["result"].Rows)
                        if (Convert.ToString(dataRow["type"]) == "Major Crimes" &&
                            Convert.ToString(dataRow["gendertype"]) == dpnGender.Text)
                                this.dpnDormitory.Items.Add(Convert.ToString(dataRow["name"]));
                }
                else
                {
                    foreach (DataRow dataRow in dsDormitories.Tables["result"].Rows)
                        if (Convert.ToString(dataRow["type"]) == "Minor Crimes" &&
                            Convert.ToString(dataRow["gendertype"]) == dpnGender.Text)
                                this.dpnDormitory.Items.Add(Convert.ToString(dataRow["name"]));
                }
            }
        }

        public void Sentence()
        {
            txtSentence.Text = config.config.Calculate.Sentence(dtpTimeServedStart, dtpTimeServedEnd);
        }

        private void ibxFace_Validating(object sender, CancelEventArgs e)
        {

        }
        int DormitoryId = 0;
        private void dpnDormitory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dsDormitories != null)
                foreach (DataRow dataRow in dsDormitories.Tables["result"].Rows)
                    if (dpnDormitory.Text == dataRow["name"].ToString())
                    {
                        DormitoryId = Convert.ToInt32(dataRow["id"].ToString());
                        break;
                    }
        }

        private void btnCancel_Click(object sender, EventArgs e)  
        {
            Sound.Click();
            inmates.dashboard.lblAction.Text = "List";
            inmates.Controls.Remove(this);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }
        facial.capture GetCapture;
        public modal.popup popup;
        private void btnCapture_Click(object sender, EventArgs e)
        {
            Sound.Click();
            GetCapture = new facial.capture(this);
            popup = new modal.popup(GetCapture);
            popup.Size = GetCapture.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
        }

        ErrorProvider errorfirstnameProvider = new ErrorProvider();
        ErrorProvider errormiddlenameProvider = new ErrorProvider(); 
        ErrorProvider errorlastnameProvider = new ErrorProvider();
        ErrorProvider errordateofBirthProvider = new ErrorProvider();
        ErrorProvider errorgenderProvider = new ErrorProvider();
        ErrorProvider erroraddressProvider = new ErrorProvider(); 
        ErrorProvider errormaritalstatusProvider = new ErrorProvider();
        ErrorProvider errorcomplexionProvider = new ErrorProvider();
        ErrorProvider erroreyeColourProvider = new ErrorProvider(); 
        ErrorProvider errorcrimesProvider = new ErrorProvider(); 
        ErrorProvider errortimeServedStartProvider = new ErrorProvider(); 
        ErrorProvider errortimeServedEndProvider = new ErrorProvider(); 
        ErrorProvider errordormitoryProvider = new ErrorProvider(); 
        ErrorProvider errornameProvider = new ErrorProvider();
        ErrorProvider errorrelationProvider = new ErrorProvider(); 
        ErrorProvider errorcontactProvider = new ErrorProvider();
        string firstnameError = "Please input First Name, enter only characters.";
        string middlenameError = "Please input Middle Name, enter only characters."; 
        string lastnameError = "Please input Last Name, enter only characters.";
        string dateofBirthError = "Please select a valid Date of Birth.";
        string genderError = "Please select gender e.g. Male or Female";
        string addressError = "Please input Address e.g Chichiri, Blantyre"; 
        string maritalstatusError = "Please select Marital Status e.g. Single, Married, Widower or Widow"; 
        string complexionError = "Please input inmate complexion e.g fair";
        string eyeColourError = "Please input inmate eye colour e.g Brown"; 
        string crimesError = "Please select crimes committed by inmate e.g Murder"; 
        string timeServedStartError = "Please set valid date inmate start serving the sentence"; 
        string timeServedEndError = "Please set valid date inmate will end serving the sentence";
        string dormitoryError = "Please select Dormitory e.g Cell Block 1"; 
        string nameError = "Please input Full Name of Emergency Contact";
        string relationError = "Please input Relation of Emergency Contact";
        string contactError = "Please input Contact of Emergency Contact"; 
        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (!config.config.Validate.IsText(txtFirstName.Text))
            {
                errorfirstnameProvider.SetError(txtFirstName, firstnameError);
                errorfirstnameProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
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
            if (!config.config.Validate.IsText(txtMiddleName.Text))
            {
                errormiddlenameProvider.SetError(txtMiddleName, middlenameError);
                errormiddlenameProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
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
            if (!config.config.Validate.IsText(txtLastName.Text))
            {
                errorlastnameProvider.SetError(txtLastName, lastnameError);
                errorlastnameProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                txtLastName.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errorlastnameProvider.Clear();
                txtLastName.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void dtpDoB_Validating(object sender, CancelEventArgs e)
        {
            if (dtpDateOfBirth.Value.Date > DateTime.Now.Date)
            {
                errordateofBirthProvider.SetError(dtpDateOfBirth, dateofBirthError);
                errordateofBirthProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
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
                errorgenderProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                dpnGender.IndicatorColor = Color.Firebrick;
            }
            else
            {
                errorgenderProvider.Clear();
                dpnGender.IndicatorColor = Color.FromArgb(26, 104, 255);
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e) 
        {
            if (!config.config.Validate.IsText(txtAddress.Text))
            {
                erroraddressProvider.SetError(txtAddress, addressError);
                erroraddressProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                txtAddress.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errorlastnameProvider.Clear();
                txtAddress.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void dpnMaritalStatus_Validating(object sender, CancelEventArgs e)
        {
            if (dpnMaritalStatus.Text == "Select")
            {
                errormaritalstatusProvider.SetError(dpnMaritalStatus, maritalstatusError);
                errormaritalstatusProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                dpnMaritalStatus.ItemBorderColor = Color.Firebrick;
            }
            else
            {
                errormaritalstatusProvider.Clear();
                dpnMaritalStatus.ItemBorderColor = Color.FromArgb(26, 104, 200);
            }
        }

        private void txtComplexion_Validating(object sender, CancelEventArgs e)
        {
            if (!config.config.Validate.IsText(txtComplexion.Text))
            {
                errorcomplexionProvider.SetError(txtComplexion, complexionError);
                errorcomplexionProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                txtComplexion.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errorcomplexionProvider.Clear();
                txtComplexion.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void txtEyeColour_Validating(object sender, CancelEventArgs e)
        {
            if (!config.config.Validate.IsText(txtEyeColour.Text))
            {
                erroreyeColourProvider.SetError(txtEyeColour, eyeColourError);
                erroreyeColourProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                txtEyeColour.BorderColorActive = Color.Firebrick;
            }
            else
            {
                erroreyeColourProvider.Clear();
                txtEyeColour.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void dpnCrimes_Validating(object sender, CancelEventArgs e)
        {
            if (dpnCrimes.Text == "Select")
            {
                errorcrimesProvider.SetError(dpnCrimes, crimesError);
                errorcrimesProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                dpnCrimes.ItemBorderColor = Color.Firebrick;
            }
            else
            {
                errorcrimesProvider.Clear();
                dpnCrimes.ItemBorderColor = Color.FromArgb(26, 104, 200);
            }
        }

        private void dtptimeServedStart_Validating(object sender, CancelEventArgs e)
        {
            if (dtpTimeServedStart.Value.Date == DateTime.Now.Date)
            {
                errortimeServedStartProvider.SetError(dtpTimeServedStart, timeServedStartError);
                errortimeServedStartProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                dtpTimeServedStart.ForeColor = Color.Firebrick;
            }
            else
            {
                errordateofBirthProvider.Clear();
                dtpTimeServedStart.ForeColor = Color.FromArgb(17, 17, 18);
            }
        }

        private void dtptimeServedEnd_Validating(object sender, CancelEventArgs e)
        {
            if (dtpTimeServedEnd.Value.Date == DateTime.Now.Date)
            {
                errortimeServedEndProvider.SetError(dtpTimeServedEnd, timeServedEndError);
                errortimeServedEndProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                dtpTimeServedEnd.ForeColor = Color.Firebrick;
            }
            else
            {
                errortimeServedEndProvider.Clear(); 
                dtpTimeServedEnd.ForeColor = Color.FromArgb(17, 17, 18);
            }
        }

        private void dpnDormitory_Validating(object sender, CancelEventArgs e)
        {
            if (dpnDormitory.Text == "Select")
            {
                errordormitoryProvider.SetError(dpnDormitory, dormitoryError);
                errordormitoryProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                dpnDormitory.ItemBorderColor = Color.Firebrick;
            }
            else
            {
                errordormitoryProvider.Clear(); 
                dpnCrimes.ItemBorderColor = Color.FromArgb(26, 104, 200);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (!config.config.Validate.IsText(txtName.Text))
            {
                errornameProvider.SetError(txtName, nameError);
                errornameProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                txtName.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errornameProvider.Clear();
                txtName.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void txtRelation_Validating(object sender, CancelEventArgs e)
        {
            if (!config.config.Validate.IsText(txtRelation.Text))
            {
                errorrelationProvider.SetError(txtRelation, relationError);
                errorrelationProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                txtRelation.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errorrelationProvider.Clear();
                txtRelation.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void txtContact_Validating(object sender, CancelEventArgs e)
        {
            if (!config.config.Validate.IsPhoneNumber(txtContact.Text))
            {
                errorcontactProvider.SetError(txtContact, contactError);
                errorcontactProvider.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                txtContact.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errorcontactProvider.Clear();
                txtContact.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void dtpTimeServedStart_ValueChanged(object sender, EventArgs e)
        {
            Sentence();
        }

        private void dtpTimeServedEnd_ValueChanged(object sender, EventArgs e)
        {
            Sentence();
        }

        private void dpnMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
