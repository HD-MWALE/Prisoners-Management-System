using Roll_Call_And_Management_System.classes;
using Roll_Call_And_Management_System.config;
using Roll_Call_And_Management_System.views.components.rows;
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

namespace Roll_Call_And_Management_System.views.components
{
    public partial class users : UserControl
    {
        public views.dashboard dashboard;
        public users(views.dashboard dashboard)
        { 
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void users_Load(object sender, EventArgs e)
        {
            dashboard.Prison.User.dataSet = dashboard.Prison.User.GetUsers().Item1; 
            this.InmateflowLayoutPanel.Controls.Clear();
            if (dashboard.Prison.User.dataSet != null)
            {
                int number = 1;
                foreach (DataRow dataRow in dashboard.Prison.User.dataSet.Tables["result"].Rows)
                {
                    user row = new user(dashboard, this);
                    row.Id = Convert.ToInt32(dataRow["id"]);
                    row.lblNo.Text = number.ToString();
                    row.lblEmail.Text = ini.AES.Decrypt(dataRow["email"].ToString(), Properties.Resources.PassPhrase);
                    row.lblUsername.Text = ini.AES.Decrypt(dataRow["user_name"].ToString(), Properties.Resources.PassPhrase);
                    row.lblFullname.Text = ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                    row.lblGender.Text = ini.AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                    row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                    row.lblRole.Text = dataRow["role"].ToString();
                    //row.lblPrison.Text = AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                    row.btnDelete.Click += BtnDelete_Click;
                    this.InmateflowLayoutPanel.Controls.Add(row);
                    if (File.Exists(ini.UserRole))
                        if (File.ReadAllText(ini.UserRole) != "Admin")
                        {
                            row.btnEdit.Visible = false;
                            row.btnDelete.Visible = false;
                        }
                    number++;
                }
            }
            else
            {
                user row = new user(dashboard, this);
                row.Id = 0;
                row.lblNo.Text = "";
                row.lblEmail.Text = "";
                row.lblUsername.Text = "";
                row.lblFullname.Text = "No Records Found";
                row.lblGender.Text = "";
                row.lblDoB.Text = "";
                row.lblRole.Text = "";
                //row.lblPrison.Text = "";
                this.InmateflowLayoutPanel.Controls.Add(row);
                row.btnEdit.Visible = false;
                row.btnView.Visible = false;
                row.btnDelete.Visible = false;
            }
            ini.ColorScheme.LoadTheme(this.Controls);
        }

        private void UsersPageList(int pageNumber) 
        {
            lblPageNumber.Text = pageNumber.ToString();
            dashboard.Prison.Visitor.dataSet = dashboard.Prison.Visitor.GetVisitors();
            int pageSize = 25;
            var query = dashboard.Prison.Visitor.dataSet.Tables["result"].AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.VisitorflowLayoutPanel.Controls.Clear();

            foreach (var dataRow in query)
            {
                visitor row = new visitor(dashboard, this);
                row.Id = (int)dataRow["id"];
                row.lblNo.Text = number.ToString();
                row.lblName.Text = ini.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                row.lblRelation.Text = ini.AES.Decrypt(dataRow["relation"].ToString(), Properties.Resources.PassPhrase);
                row.lblContact.Text = ini.AES.Decrypt(dataRow["contact"].ToString(), Properties.Resources.PassPhrase);
                row.lblAddress.Text = ini.AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                row.lblInmate.Text = ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                row.lblDate.Text = Convert.ToDateTime(dataRow["date_created"]).ToString("dd/MM/yyyy");
                row.btnDelete.Click += BtnDelete_Click;
                if (File.Exists(ini.UserRole))
                    if (File.ReadAllText(ini.UserRole) != "Admin")
                    {
                        row.btnEdit.Visible = false;
                        row.btnDelete.Visible = false;
                    }
                this.VisitorflowLayoutPanel.Controls.Add(row);
                number++;
            }

            lblEntities.Text = (pageNumber - 1) * pageSize + " - " + ((pageNumber - 1) * pageSize + 25) + " of " + dashboard.Prison.Inmate.dataSet.Tables["result"].Rows.Count + " entities";

            ini.ColorScheme.LoadTheme(this.VisitorflowLayoutPanel.Controls);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            users_Load(sender, e);
            dashboard.SetLoading(false);
        }

        public inputs.user input;
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            ini.Sound.ClickSound();
            input = new inputs.user(dashboard, this);
            dashboard.PathSeparator.Visible = true;
            dashboard.lblAction.Visible = true;
            dashboard.lblAction.Text = "Add";
            this.Controls.Add(input);
            input.Dock = DockStyle.Fill;
            input.BringToFront();
            users_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }
    }
}
