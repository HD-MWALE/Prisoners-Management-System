using Google.Protobuf.WellKnownTypes;
using Roll_Call_And_Management_System.classes;
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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using Roll_Call_And_Management_System.views.components.dashboard;
using System.IO;
using DocumentFormat.OpenXml.Bibliography;

namespace Roll_Call_And_Management_System.views.components.inputs
{
    public partial class inmate : UserControl
    {
        inmates inmates;
        int count = 0;
        public inmate(inmates inmates) 
        {
            InitializeComponent();
            this.inmates = inmates;

            Dormitory.dataSet = Dormitory.GetDormitories();

            Crime.dataSet = Crime.GetCrimes();
            if (Crime.dataSet != null)
            {
                this.dpnCrimes.Items.Clear();
                foreach (DataRow dataRow in Crime.dataSet.Tables["result"].Rows)
                    this.dpnCrimes.Items.Add(AES.Decrypt((string)dataRow["name"], Properties.Resources.PassPhrase));
            }
            Config.LoadTheme(this.inmates.Controls);
        }
        public int Id = 0;
        public int ButtonCount = 0;
        public Inmate _inmate = new Inmate(); 
        public Dormitory Dormitory = new Dormitory();
        public Crime Crime = new Crime();
        modal.dialog dialog;
        public Crimes_Committed CrimesCommitted = new Crimes_Committed(); 
        ColorScheme scheme = new ColorScheme(); 
        public void inmate_Load(object sender, EventArgs e) 
        {
            _inmate.dataSet = _inmate.GetInmates();
            if (_inmate.dataSet != null)
            {
                foreach (DataRow dataRow in _inmate.dataSet.Tables["result"].Rows)
                    count++;
            }
            txtCode.Text = "Inmate" + (count + 1);
            dtpDateOfBirth.MaxDate = Convert.ToDateTime(DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + (DateTime.Now.Year - 18));
            dtpTimeServedStart.MaxDate = DateTime.Now;
            if (Id != 0)
            {
                btnSave.Text = "Update";
                _inmate.dataSet = _inmate.GetInmates();
                if (_inmate.dataSet != null)
                    foreach (DataRow dataRow in _inmate.dataSet.Tables["result"].Rows)
                    {
                        if ((int)dataRow["id"] == Id)
                        {
                            dpnDormitory.Text = AES.Decrypt(Dormitory.GetName(Convert.ToInt32(dataRow["dormitory_id"])), Properties.Resources.PassPhrase);
                            txtCode.Text = AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                            txtFirstName.Text = AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase);
                            txtMiddleName.Text = AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                            txtLastName.Text = AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase);
                            dpnGender.Text = AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                            dtpDateOfBirth.MaxDate = Convert.ToDateTime(dataRow["dob"]);
                            dtpDateOfBirth.Value = Convert.ToDateTime(dataRow["dob"]);
                            txtEyeColour.Text = AES.Decrypt((string)dataRow["eye_color"], Properties.Resources.PassPhrase);
                            txtComplexion.Text = AES.Decrypt((string)dataRow["complexion"], Properties.Resources.PassPhrase);
                            txtAddress.Text = AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                            dpnMaritalStatus.Text = AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                            dtpTimeServedStart.Value = Convert.ToDateTime((DateTime)dataRow["start_date"]);
                            dtpTimeServedEnd.Value = Convert.ToDateTime(Convert.ToDateTime(dataRow["end_date"]).ToString("yyyy/MM/dd hh:mm:ss tt"));
                            txtName.Text = AES.Decrypt(dataRow["emergency_name"].ToString(), Properties.Resources.PassPhrase);
                            txtRelation.Text = AES.Decrypt(dataRow["emergency_relation"].ToString(), Properties.Resources.PassPhrase);
                            txtContact.Text = AES.Decrypt(dataRow["emergency_contact"].ToString(), Properties.Resources.PassPhrase);
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
            Config.ClickSound();
            if (Validate_Inputs())
            {
                _inmate = new Inmate(Id, txtCode.Text,
                                    txtFirstName.Text,
                                    txtMiddleName.Text,
                                    txtLastName.Text,
                                    dpnGender.Text,
                                    dtpDateOfBirth.Value.Date,
                                    txtAddress.Text,
                                    dpnMaritalStatus.Text,
                                    txtEyeColour.Text,
                                    txtComplexion.Text,
                                    new Crimes_Committed(Crimes),
                                    txtName.Text,
                                    txtContact.Text,
                                    txtRelation.Text,
                                    1, new Sentence(dtpTimeServedStart.Value.Date, dtpTimeServedEnd.Value.Date, 1),
                                    new Dormitory(dpnDormitory.Text));
                if (btnSave.Text != "Update")
                {
                    if (_inmate.Save())
                    {
                        Config.Alert("New Inmate Saved.", dashboard.alert.enmType.Success);
                        btnCancel_Click(sender, e);
                    }
                    else
                        Config.Alert("Something Went Wrong.", dashboard.alert.enmType.Error);
                }
                else
                {
                    if (_inmate.Update(Id))
                    {
                        Config.Alert("Inmate Updated.", dashboard.alert.enmType.Success);
                        btnCancel_Click(sender, e);
                    }
                    else
                        Config.Alert("Something Went Wrong.", dashboard.alert.enmType.Error);
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
                popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
                popup.ShowDialog();
                inmates.dashboard.SetLoading(false);
            }
        }

        private void dpnGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(dpnGender.Text != "Select")
            {
                Dormitory.dataSet = Dormitory.GetDormitories();
                if (Dormitory.dataSet != null)
                {
                    this.dpnDormitory.Items.Clear();
                    foreach (DataRow dataRow in Dormitory.dataSet.Tables["result"].Rows)
                        if(AES.Decrypt(Convert.ToString(dataRow["gendertype"]), Properties.Resources.PassPhrase) == dpnGender.Text)
                            this.dpnDormitory.Items.Add(AES.Decrypt(Convert.ToString(dataRow["name"]), Properties.Resources.PassPhrase));
                }
            }
        }
        public ArrayList Crimes = new ArrayList();
        public ArrayList CrimeTypes = new ArrayList(); 

        private void dpnCrimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool IsAdded = false;
            foreach(string name in Crimes)  
            {
                if (name == dpnCrimes.Text)
                {
                    Config.Alert("Crime Already Added.", alert.enmType.Warning);
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
                if (Crime.dataSet != null)
                {
                    foreach (DataRow dataRow in Crime.dataSet.Tables["result"].Rows)
                        if (AES.Decrypt((string)dataRow["name"], Properties.Resources.PassPhrase) == dpnCrimes.Text)
                            CrimeTypes.Add(dataRow["type"]);
                }
            }
            Allocate();
        }

        public void Allocate()
        {
            if (Dormitory.dataSet != null)
            {
                this.dpnDormitory.Items.Clear();
                if (CrimeTypes.Contains("Major"))
                {
                    foreach (DataRow dataRow in Dormitory.dataSet.Tables["result"].Rows)
                        if (AES.Decrypt(Convert.ToString(dataRow["type"]), Properties.Resources.PassPhrase) == "Major Crimes" &&
                            AES.Decrypt(Convert.ToString(dataRow["gendertype"]), Properties.Resources.PassPhrase) == dpnGender.Text)
                                this.dpnDormitory.Items.Add(AES.Decrypt(Convert.ToString(dataRow["name"]), Properties.Resources.PassPhrase));
                }
                else
                {
                    foreach (DataRow dataRow in Dormitory.dataSet.Tables["result"].Rows)
                        if (AES.Decrypt(Convert.ToString(dataRow["type"]), Properties.Resources.PassPhrase) == "Minor Crimes" &&
                            AES.Decrypt(Convert.ToString(dataRow["gendertype"]), Properties.Resources.PassPhrase) == dpnGender.Text)
                                this.dpnDormitory.Items.Add(AES.Decrypt(Convert.ToString(dataRow["name"]), Properties.Resources.PassPhrase));
                }
            }
        }

        public void Sentence()
        {
            txtSentence.Text = Calculate.Sentence(dtpTimeServedStart, dtpTimeServedEnd);
        }

        private void ibxFace_Validating(object sender, CancelEventArgs e)
        {

        }
        int DormitoryId = 0;
        private void dpnDormitory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Dormitory.dataSet != null)
                foreach (DataRow dataRow in Dormitory.dataSet.Tables["result"].Rows)
                    if (dpnDormitory.Text == AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase))
                    {
                        DormitoryId = Convert.ToInt32(dataRow["id"].ToString());
                        break;
                    }
        }

        private void btnCancel_Click(object sender, EventArgs e)  
        {
            Config.ClickSound();
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
            Config.ClickSound();
            GetCapture = new facial.capture(this);
            popup = new modal.popup(GetCapture);
            popup.Size = GetCapture.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
        }

        private void pnlInput_Paint(object sender, PaintEventArgs e)
        {

        }
        new Validate Validate = new Validate();
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
            if (!Validate.IsText(txtFirstName.Text))
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
            if (!Validate.IsText(txtMiddleName.Text))
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
            if (!Validate.IsText(txtLastName.Text))
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
            if (!Validate.IsText(txtAddress.Text))
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
            if (!Validate.IsText(txtComplexion.Text))
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
            if (!Validate.IsText(txtEyeColour.Text))
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
            if (!Validate.IsText(txtName.Text))
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
            if (!Validate.IsText(txtRelation.Text))
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
            if (!Validate.IsPhoneNumber(txtContact.Text))
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
