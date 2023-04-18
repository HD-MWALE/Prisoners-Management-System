using DocumentFormat.OpenXml.Spreadsheet;
using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisoners_Management_System.views.components.view
{
    public partial class rollcall : UserControl
    {
        public views.dashboard dashboard;
        components.rollcall Rollcall;
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
        DataSet dsRoll_Call = new DataSet();
        private void rollcall_Load(object sender, EventArgs e)
        {
            inmates = new inmates(dashboard);
            if (Id != 0)
            {
                dsRoll_Call = dashboard.Prison.Roll_Call.GetRollCallDetails(Id);
                if (dsRoll_Call != null)
                {
                    foreach (DataRow dataRow in dsRoll_Call.Tables["result"].Rows)
                    {
                        Id = Convert.ToInt32(dataRow["id"].ToString());
                        lblCode.Text = dataRow["code"].ToString();
                        lblDormitoryName.Text = config.config.AES.Decrypt(dashboard.Prison.Dormitory.GetName(Convert.ToInt32(dataRow["dormitory_id"])), Properties.Resources.PassPhrase);
                        DataSet dataSet = dashboard.Prison.Roll_Call.GetDetails(lblCode.Text); 
                        int number = 1;
                        if (dataSet != null)
                        {
                            foreach (DataRow row in dataSet.Tables["result"].Rows)
                            {
                                rows.inmate inmate = new rows.inmate(dashboard, inmates);
                                Id = Convert.ToInt32(row["id"].ToString());
                                lblCode.Text = config.config.AES.Decrypt(row["code"].ToString(), Properties.Resources.PassPhrase);
                                lblDormitoryName.Text = config.config.AES.Decrypt(dashboard.Prison.Dormitory.GetName(Convert.ToInt32(row["dormitory_id"])), Properties.Resources.PassPhrase);
                                inmate.Id = (int)row["id"];
                                inmate.lblNo.Text = number.ToString();
                                inmate.lblCode.Text = config.config.AES.Decrypt(row["code"].ToString(), Properties.Resources.PassPhrase);
                                inmate.lblFullname.Text = config.config.AES.Decrypt(row["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + config.config.AES.Decrypt(row["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + config.config.AES.Decrypt(row["middle_name"].ToString(), Properties.Resources.PassPhrase);
                                inmate.lblGender.Text = config.config.AES.Decrypt(row["gender"].ToString(), Properties.Resources.PassPhrase);
                                inmate.lblDoB.Text = Convert.ToDateTime(row["dob"]).ToString("dd/MM/yyyy");
                                inmate.lblAddress.Text = config.config.AES.Decrypt(row["address"].ToString(), Properties.Resources.PassPhrase);
                                inmate.lblMaritalStatus.Text = config.config.AES.Decrypt(row["marital_status"].ToString(), Properties.Resources.PassPhrase);
                                inmate.specifier = this.Name;
                                txtSearch.AutoCompleteCustomSource.Add(inmate.lblCode.Text);
                                txtSearch.AutoCompleteCustomSource.Add(inmate.lblFullname.Text);
                                txtSearch.AutoCompleteCustomSource.Add(config.config.AES.Decrypt(row["first_name"].ToString(), Properties.Resources.PassPhrase));
                                txtSearch.AutoCompleteCustomSource.Add(config.config.AES.Decrypt(row["middle_name"].ToString(), Properties.Resources.PassPhrase));
                                txtSearch.AutoCompleteCustomSource.Add(config.config.AES.Decrypt(row["last_name"].ToString(), Properties.Resources.PassPhrase));
                                txtSearch.AutoCompleteCustomSource.Add(inmate.lblMaritalStatus.Text);
                                InmateflowLayoutPanel.Controls.Add(inmate);
                                if (File.Exists(config.config.UserRole))
                                    if (File.ReadAllText(config.config.UserRole) != "Admin")
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

            ColorScheme.LoadTheme(this.Rollcall.dashboard.Controls);
        }
    }
}
