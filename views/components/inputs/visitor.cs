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
        Inmate Inmate = new Inmate();
        private void btnSave_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
            Visitor = new Visitor(txtName.Text, txtRelation.Text, txtContact.Text, txtAddress.Text, new Inmate(dpnCode.Text));
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

        private void dpnCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Inmate.dataSet = Inmate.GetInmates();
            if (Inmate.dataSet != null) 
            {
                foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
                    if (AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase) == dpnCode.Text)
                        this.dpnFullname.Text = AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
            }
        }

        private void dpnFullname_SelectedIndexChanged(object sender, EventArgs e)
        {
            Inmate.dataSet = Inmate.GetInmates();
            if (Inmate.dataSet != null)
            {
                foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
                    if (AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase) == dpnFullname.Text)
                        this.dpnCode.Text = AES.Decrypt((string)dataRow["code"], Properties.Resources.PassPhrase);
            }
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
                this.dpnCode.Items.Clear();
                this.dpnFullname.Items.Clear();
                foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
                {
                    this.dpnCode.Items.Add(AES.Decrypt((string)dataRow["code"], Properties.Resources.PassPhrase));
                    this.dpnFullname.Items.Add(AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase));
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

        private void dpnCode_Validating(object sender, CancelEventArgs e)
        {
            if (dpnCode.Text == "Select")
            {
                errorcodeProvider.SetError(dpnCode, codeError);
                dpnCode.IndicatorColor = Color.Firebrick;
            }
            else
            {
                errorcodeProvider.Clear();
                dpnCode.IndicatorColor = Color.FromArgb(26, 104, 255);
            }
        }

        private void dpnFullname_Validating(object sender, CancelEventArgs e)
        {
            if (dpnFullname.Text == "Select")
            {
                errorfullNameProvider.SetError(dpnFullname, fullNameError);
                dpnFullname.IndicatorColor = Color.Firebrick;
            }
            else
            {
                errorfullNameProvider.Clear();
                dpnFullname.IndicatorColor = Color.FromArgb(26, 104, 255);
            }
        }
    }
}
