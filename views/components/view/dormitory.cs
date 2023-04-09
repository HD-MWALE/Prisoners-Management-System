using Roll_Call_And_Management_System.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views.components.view
{
    public partial class dormitory : UserControl
    {
        public dormitory(views.dashboard dashboard, dormitories dormitories)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.dormitories = dormitories;
        }
        public int Id = 0;
        inmates inmates;
        DataSet dsDormitory = new DataSet();
        DataSet dsInmate = new DataSet();
        views.dashboard dashboard;
        dormitories dormitories;
        private void dormitory_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {
            dsDormitory = dashboard.Prison.Dormitory.GetDormitoryDetails(Id);
            if (dsDormitory != null)
            {
                foreach (DataRow dataRow in dsDormitory.Tables["result"].Rows)
                {
                    Id = (int)dataRow[0];
                    lblDormitoryName.Text = ini.AES.Decrypt(dataRow[1].ToString(), Properties.Resources.PassPhrase);
                    lblCapacity.Text = dataRow[2].ToString();
                    rtxtDescrption.Text = ini.AES.Decrypt((string)dataRow[3], Properties.Resources.PassPhrase);
                    lblPrison.Text = ini.AES.Decrypt((string)dataRow[4], Properties.Resources.PassPhrase);
                }
            }
            inmates = new inmates(dashboard);
            dsInmate = dashboard.Prison.Inmate.GetInmates();
            this.InmateflowLayoutPanel.Controls.Clear();
            if (dsInmate != null)
            {
                int number = 1;
                foreach (DataRow dataRow in dsInmate.Tables["result"].Rows)
                {
                    if ((int)dataRow["dormitory_id"] == Id)
                    {
                        rows.inmate row = new rows.inmate(dashboard, this.inmates);
                        row.Id = (int)dataRow["id"];
                        row.lblNo.Text = number.ToString();
                        row.lblCode.Text = ini.AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                        row.lblFullname.Text = ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        row.lblGender.Text = ini.AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                        row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                        row.lblAddress.Text = ini.AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                        row.lblMaritalStatus.Text = ini.AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                        this.InmateflowLayoutPanel.Controls.Add(row);
                        row.btnEdit.Visible = false;
                        row.btnView.Visible = false;
                        row.btnDelete.Visible = false;
                        number++;
                    }
                }
            
            }
            else
            {
                rows.inmate row = new rows.inmate(dashboard, this.inmates);
                row.Id = 0;
                row.lblNo.Text = "";
                row.lblCode.Text = "";
                row.lblFullname.Text = "";
                row.lblGender.Text = "No Records Found";
                row.lblDoB.Text = "";
                row.lblAddress.Text = "";
                row.lblMaritalStatus.Text = "";
                this.InmateflowLayoutPanel.Controls.Add(row);
                row.btnEdit.Visible = false;
                row.btnView.Visible = false;
                row.btnDelete.Visible = false;
            }
            ini.ColorScheme.LoadTheme(this.dormitories.Controls);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            dormitories.dashboard.lblAction.Text = "List";
            dormitories.Controls.Remove(this);
            dashboard.SetLoading(false);
        }
    }
}
