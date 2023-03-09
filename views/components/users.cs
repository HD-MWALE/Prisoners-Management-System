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
        public user user; 
        classes.User User = new classes.User();
        public users(views.dashboard dashboard)
        { 
            InitializeComponent();
            this.dashboard = dashboard;
        }
        public void users_Load(object sender, EventArgs e)
        {
            User.dataSet = User.GetUsers().Item1; 
            this.InmateflowLayoutPanel.Controls.Clear();
            if (User.dataSet != null)
            {
                int number = 1;
                foreach (DataRow dataRow in User.dataSet.Tables["result"].Rows)
                {
                    user row = new user(dashboard, this);
                    row.Id = Convert.ToInt32(dataRow["id"]);
                    row.lblNo.Text = number.ToString();
                    row.lblEmail.Text = AES.Decrypt(dataRow["email"].ToString(), Properties.Resources.PassPhrase);
                    row.lblUsername.Text = AES.Decrypt(dataRow["user_name"].ToString(), Properties.Resources.PassPhrase);
                    row.lblFullname.Text = AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                    row.lblGender.Text = AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                    row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                    row.lblRole.Text = dataRow["role"].ToString();
                    //row.lblPrison.Text = AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                    row.btnDelete.Click += BtnDelete_Click;
                    this.InmateflowLayoutPanel.Controls.Add(row);
                    if (File.Exists(Config.UserRole))
                        if (File.ReadAllText(Config.UserRole) != "Admin")
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
            Config.LoadTheme(this.Controls);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            users_Load(sender, e);
            dashboard.SetLoading(false);
        }

        inputs.user input;
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Config.ClickSound();
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
    }
}
