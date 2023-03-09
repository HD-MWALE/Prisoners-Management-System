using DocumentFormat.OpenXml.Spreadsheet;
using Roll_Call_And_Management_System.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views.components.view
{
    public partial class rollcall : UserControl
    {
        public views.dashboard dashboard;
        components.rollcall Rollcall;
        Roll_Call Roll_Call = new Roll_Call();
        Dormitory Dormitory = new Dormitory();
        Inmate Inmate = new Inmate(); 
        public rollcall(views.dashboard dashboard, components.rollcall rollcall)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.Rollcall = rollcall;
        }
        public int Id = 0;

        private void btnBack_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            dashboard.lblAction.Text = "List";
            Rollcall.Controls.Remove(this);
            dashboard.SetLoading(false);
        }
        inmates inmates;
        private void rollcall_Load(object sender, EventArgs e)
        {
            inmates = new inmates(dashboard);
            if (Id != 0)
            {
                Roll_Call.dataSet = Roll_Call.GetRollCallDetails(Id);
                if (Roll_Call.dataSet != null)
                {
                    foreach (DataRow dataRow in Roll_Call.dataSet.Tables["result"].Rows)
                    {
                        Id = Convert.ToInt32(dataRow["id"].ToString());
                        lblCode.Text = dataRow["code"].ToString();
                        lblDormitoryName.Text = AES.Decrypt(Dormitory.GetName(Convert.ToInt32(dataRow["dormitory_id"])), Properties.Resources.PassPhrase);
                        DataSet dataSet = Roll_Call.GetDetails(lblCode.Text); 
                        int number = 1;
                        if (dataSet != null)
                        {
                            foreach (DataRow row in dataSet.Tables["result"].Rows)
                            {
                                rows.inmate inmate = new rows.inmate(dashboard, inmates);
                                Id = Convert.ToInt32(row["id"].ToString());
                                lblCode.Text = AES.Decrypt(row["code"].ToString(), Properties.Resources.PassPhrase);
                                lblDormitoryName.Text = AES.Decrypt(Dormitory.GetName(Convert.ToInt32(row["dormitory_id"])), Properties.Resources.PassPhrase);
                                inmate.Id = (int)row["id"];
                                inmate.lblNo.Text = number.ToString();
                                inmate.lblCode.Text = AES.Decrypt(row["code"].ToString(), Properties.Resources.PassPhrase);
                                inmate.lblFullname.Text = AES.Decrypt(row["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(row["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(row["middle_name"].ToString(), Properties.Resources.PassPhrase);
                                inmate.lblGender.Text = AES.Decrypt(row["gender"].ToString(), Properties.Resources.PassPhrase);
                                inmate.lblDoB.Text = Convert.ToDateTime(row["dob"]).ToString("dd/MM/yyyy");
                                inmate.lblAddress.Text = AES.Decrypt(row["address"].ToString(), Properties.Resources.PassPhrase);
                                inmate.lblMaritalStatus.Text = AES.Decrypt(row["marital_status"].ToString(), Properties.Resources.PassPhrase);
                                inmate.specifier = this.Name;
                                txtSearch.AutoCompleteCustomSource.Add(inmate.lblCode.Text);
                                txtSearch.AutoCompleteCustomSource.Add(inmate.lblFullname.Text);
                                txtSearch.AutoCompleteCustomSource.Add(AES.Decrypt(row["first_name"].ToString(), Properties.Resources.PassPhrase));
                                txtSearch.AutoCompleteCustomSource.Add(AES.Decrypt(row["middle_name"].ToString(), Properties.Resources.PassPhrase));
                                txtSearch.AutoCompleteCustomSource.Add(AES.Decrypt(row["last_name"].ToString(), Properties.Resources.PassPhrase));
                                txtSearch.AutoCompleteCustomSource.Add(inmate.lblMaritalStatus.Text);
                                InmateflowLayoutPanel.Controls.Add(inmate);
                                if (File.Exists(Config.UserRole))
                                    if (File.ReadAllText(Config.UserRole) != "Admin")
                                    {
                                        inmate.btnEdit.Visible = false;
                                        inmate.btnDelete.Visible = false;
                                    }
                                number++;
                            }
                        }
                    }
                }
            }

            Config.LoadTheme(this.Rollcall.dashboard.Controls);
        }
    }
}
