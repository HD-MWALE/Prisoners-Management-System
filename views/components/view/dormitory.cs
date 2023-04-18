using Prisoners_Management_System.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisoners_Management_System.views.components.view
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
            dsDormitory = dashboard.Prison.Dormitory.GetDormitoryDetails(Id);
            if (dsDormitory != null)
            {
                foreach (DataRow dataRow in dsDormitory.Tables["result"].Rows)
                {
                    Id = (int)dataRow[0];
                    lblDormitoryName.Text = config.config.AES.Decrypt(dataRow[1].ToString(), Properties.Resources.PassPhrase);
                    lblCapacity.Text = dataRow[2].ToString();
                    rtxtDescrption.Text = config.config.AES.Decrypt((string)dataRow[3], Properties.Resources.PassPhrase);
                    lblPrison.Text = config.config.AES.Decrypt((string)dataRow[4], Properties.Resources.PassPhrase);
                }
            }
            inmates = new inmates(dashboard);

            InmatesPageList(1);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            dormitories.dashboard.lblAction.Text = "List";
            dormitories.Controls.Remove(this);
            dashboard.SetLoading(false);
        }

        private void InmatesPageList(int pageNumber) 
        {
            lblPageNumber.Text = pageNumber.ToString();
            dsInmate = dashboard.Prison.Inmate.GetInmates();
            int pageSize = 25;
            var query = dsInmate.Tables["result"].AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.InmateflowLayoutPanel.Controls.Clear();

            foreach (var dataRow in query)
            {
                rows.inmate row = new rows.inmate(dashboard, this.inmates);
                row.Id = (int)dataRow["id"];
                row.lblNo.Text = number.ToString();
                row.lblCode.Text = config.config.AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                row.lblFullname.Text = config.config.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + config.config.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + config.config.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                row.lblGender.Text = config.config.AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                row.lblAddress.Text = config.config.AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                row.lblMaritalStatus.Text = config.config.AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                row.btnEdit.Visible = false;
                row.btnView.Visible = false;
                row.btnDelete.Visible = false;
                this.InmateflowLayoutPanel.Controls.Add(row);
                number++;
            }

            lblentries.Text = (pageNumber - 1) * pageSize + " - " + ((pageNumber - 1) * pageSize + 25) + " of " + dsInmate.Tables["result"].Rows.Count + " entries";

            ColorScheme.LoadTheme(this.InmateflowLayoutPanel.Controls);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            InmatesPageList((Convert.ToInt32(lblPageNumber.Text) + 1));
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            InmatesPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }
    }
}
