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
        views.dashboard dashboard;
        dormitories dormitories;
        public dormitory(views.dashboard dashboard, dormitories dormitories)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.dormitories = dormitories;
        }
        public int Id = 0;
        classes.Dormitory Dormitory = new classes.Dormitory();
        classes.Inmate Inmate = new classes.Inmate();
        inmates inmates;
        private void dormitory_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {
            Dormitory.dataSet = Dormitory.GetDormitoryDetails(Id);
            if (Dormitory.dataSet != null)
            {
                foreach (DataRow dataRow in Dormitory.dataSet.Tables["result"].Rows)
                {
                    Id = (int)dataRow[0];
                    lblDormitoryName.Text = AES.Decrypt(dataRow[1].ToString(), Properties.Resources.PassPhrase);
                    lblCapacity.Text = dataRow[2].ToString();
                    rtxtDescrption.Text = AES.Decrypt((string)dataRow[3], Properties.Resources.PassPhrase);
                    lblPrison.Text = AES.Decrypt((string)dataRow[4], Properties.Resources.PassPhrase);
                }
            }
            inmates = new inmates(dashboard);
            Inmate.dataSet = Inmate.GetInmates();
            this.InmateflowLayoutPanel.Controls.Clear();
            if (Inmate.dataSet != null)
            {
                int number = 1;
                foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
                {
                    if ((int)dataRow["dormitory_id"] == Id)
                    {
                        rows.inmate row = new rows.inmate(dashboard, this.inmates);
                        row.Id = (int)dataRow["id"];
                        row.lblNo.Text = number.ToString();
                        row.lblCode.Text = AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                        row.lblFullname.Text = AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        row.lblGender.Text = AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                        row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                        row.lblAddress.Text = AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                        row.lblMaritalStatus.Text = AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
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
            Config.LoadTheme(this.dormitories.Controls);
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
