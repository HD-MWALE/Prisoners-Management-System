using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
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
using static Prisoners_Management_System.classes.Visitor;

namespace Prisoners_Management_System.views.components.inputs
{
    public partial class visitor : UserControl
    {
        public visitor(visitors visitors)
        {
            InitializeComponent();
            this.visitors = visitors; 
        }
        public int Id = 0;
        public int InmateId = 0; 
        public string Code = ""; 
        visitors visitors;
        DataSet dsVisitor = new DataSet();

        private void btnSave_Click(object sender, EventArgs e)
        {
            Sound.Click();
            visitors.dashboard.Prison.Visitor = new Visitor(txtName.Text, txtRelation.Text, txtContact.Text, txtAddress.Text, new Inmate(Code));
            if (btnSave.Text != "Update")
                if (visitors.dashboard.Prison.Visitor.Save())
                    config.config.Alerts.Popup("New Visitor Saved.", dashboard.alert.enmType.Success);
                else
                    config.config.Alerts.Popup("Something Went Wrong.", dashboard.alert.enmType.Error);
            else
                if (visitors.dashboard.Prison.Visitor.Update(Id))
                config.config.Alerts.Popup("Visitor Updated.", dashboard.alert.enmType.Success);
                else
                config.config.Alerts.Popup("Something Went Wrong.", dashboard.alert.enmType.Error);
        }

        private void visitor_Load(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                btnSave.Text = "Update";
            }
            dsVisitor = visitors.dashboard.Prison.Inmate.GetInmates();
            if (dsVisitor != null)
            {
                foreach (DataRow dataRow in dsVisitor.Tables["result"].Rows)
                {
                    txtinmate.AutoCompleteCustomSource.Add((string)dataRow["code"]);
                    txtinmate.AutoCompleteCustomSource.Add(dataRow["last_name"].ToString() + ", " + dataRow["first_name"].ToString()  + " " + dataRow["middle_name"].ToString());
                    txtinmate.AutoCompleteCustomSource.Add(dataRow["first_name"].ToString());
                    txtinmate.AutoCompleteCustomSource.Add(dataRow["middle_name"].ToString());
                    txtinmate.AutoCompleteCustomSource.Add(dataRow["last_name"].ToString());
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
            if (dsVisitor != null)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (DataRow dataRow in dsVisitor.Tables["result"].Rows)
                {
                    if (dataRow["code"].ToString() == txtinmate.Text ||
                        dataRow["first_name"].ToString() == txtinmate.Text ||
                        dataRow["middle_name"].ToString() == txtinmate.Text ||
                        dataRow["last_name"].ToString() == txtinmate.Text ||
                        dataRow["last_name"].ToString()
                        + ", " + dataRow["first_name"].ToString()
                        + " " + dataRow["middle_name"].ToString() == txtinmate.Text)
                    {
                        Code = dataRow["code"].ToString();
                        lblFullName.Text = "Inmate Details";
                        lblFullName.Text += "\nCode : " + (string)dataRow["code"];
                        lblFullName.Text += "\nName : " + dataRow["last_name"].ToString() + ", " + dataRow["first_name"].ToString() + " " + dataRow["middle_name"].ToString();
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
