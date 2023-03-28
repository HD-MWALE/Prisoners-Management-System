using Roll_Call_And_Management_System.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Roll_Call_And_Management_System.classes.Visitor;

namespace Roll_Call_And_Management_System.views.components.inputs
{
    public partial class visitor : UserControl
    {
        Visitor Visitor;
        visitors visitors;
        public visitor(visitors visitors)
        {
            InitializeComponent();
            this.visitors = visitors; 
        }
        public int Id = 0;
        public int InmateId = 0; 
        public string Code = ""; 
        Inmate Inmate = new Inmate();
        private void btnSave_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
            Visitor = new Visitor(txtName.Text, txtRelation.Text, txtContact.Text, txtAddress.Text, new Inmate(Code));
            if (btnSave.Text != "Update")
                if (Visitor.Save())
                    Config.Alert("New Visitor Saved.", dashboard.alert.enmType.Success);
                else
                    Config.Alert("Something Went Wrong.", dashboard.alert.enmType.Error);
            else
                if (Visitor.Update(Id))
                    Config.Alert("Visitor Updated.", dashboard.alert.enmType.Success);
                else
                    Config.Alert("Something Went Wrong.", dashboard.alert.enmType.Error);
        }

        private void visitor_Load(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                btnSave.Text = "Update";
            }
            Inmate.dataSet = Inmate.GetInmates();
            if (Inmate.dataSet != null)
            {
                foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
                {
                    txtinmate.AutoCompleteCustomSource.Add(AES.Decrypt((string)dataRow["code"], Properties.Resources.PassPhrase));
                    txtinmate.AutoCompleteCustomSource.Add(AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase));
                    txtinmate.AutoCompleteCustomSource.Add(AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase));
                    txtinmate.AutoCompleteCustomSource.Add(AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase));
                    txtinmate.AutoCompleteCustomSource.Add(AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase));
                    //this.dpnCode.Items.Add(AES.Decrypt((string)dataRow["code"], Properties.Resources.PassPhrase));
                    //this.dpnFullname.Items.Add(AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase));
                }
            }
        }

        ErrorProvider errornameProvider = new ErrorProvider();
        ErrorProvider errorrelationProvider = new ErrorProvider();
        ErrorProvider errorcontactProvider = new ErrorProvider();
        ErrorProvider erroraddressProvider = new ErrorProvider();
        ErrorProvider errorcodeProvider = new ErrorProvider(); 
        ErrorProvider errorfullNameProvider = new ErrorProvider();
        string nameError = "Please input Full Name e.g Bright Mwale";
        string relationError = "Please input Relation e.g Father"; 
        string contactError = "Please input Contant e.g 0993979170";
        string addressError = "Please input Address e.g Chichiri, Blantyre";
        string codeError = "Please select inmate code."; 
        string fullNameError = "Please select inmate Full Name."; 
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

        private void txtRelation_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtRelation.Text))
            {
                errorrelationProvider.SetError(txtRelation, relationError); 
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
            if (string.IsNullOrEmpty(txtRelation.Text))
            {
                errorrelationProvider.SetError(txtRelation, contactError);
                txtRelation.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errorrelationProvider.Clear();
                txtRelation.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                erroraddressProvider.SetError(txtAddress, addressError);
                txtAddress.BorderColorActive = Color.Firebrick;
            }
            else
            {
                erroraddressProvider.Clear();
                txtAddress.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void txtinmate_Validating(object sender, CancelEventArgs e) 
        {/*
            if (txtinmate.Text == "Select") 
            {
                errorcodeProvider.SetError(txtinmate, codeError);
                txtinmate.IndicatorColor = Color.Firebrick;
            }
            else
            {
                errorcodeProvider.Clear();
                txtinmate.IndicatorColor = Color.FromArgb(26, 104, 255);
            }*/
        }

        private void txtinmate_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void lblInmate_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (Inmate.dataSet != null)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
                {
                    if (AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase) == txtinmate.Text ||
                        AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) == txtinmate.Text ||
                        AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase) == txtinmate.Text ||
                        AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) == txtinmate.Text ||
                        AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase)
                        + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase)
                        + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase) == txtinmate.Text)
                    {
                        Code = AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                        lblFullName.Text = "Inmate Details";
                        lblFullName.Text += "\nCode : " + AES.Decrypt((string)dataRow["code"], Properties.Resources.PassPhrase);
                        lblFullName.Text += "\nName : " + AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        if (dataRow["visiting_privilege"].ToString() == "0")
                        {
                            lblFullName.Text += "\nVisiting Privilege : Not Allowed";
                            lblFullName.ForeColor = Color.Firebrick;
                            btnSave.Enabled = false;
                        }
                        else
                        {
                            lblFullName.Text += "\nVisiting Privilege : Allowed";
                            lblFullName.ForeColor = Color.FromArgb(17, 17, 18);
                            btnSave.Enabled = true;
                        }
                        break;
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }
    }
}
