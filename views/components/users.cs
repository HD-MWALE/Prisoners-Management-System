using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
using Prisoners_Management_System.views.components.rows;
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

namespace Prisoners_Management_System.views.components
{
    public partial class users : UserControl
    {
        public views.dashboard dashboard;
        DataSet dsUsers = new DataSet();
        public users(views.dashboard dashboard)
        { 
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void users_Load(object sender, EventArgs e)
        {
            UsersPageList(1);
        }

        private void UsersPageList(int pageNumber) 
        {
            lblPageNumber.Text = pageNumber.ToString();
            dsUsers = dashboard.Prison.User.GetUsers().Item1;
            int pageSize = 25;
            var query = dsUsers.Tables["result"].AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.UsersflowLayoutPanel.Controls.Clear();

            foreach (var dataRow in query)
            {
                user row = new user(dashboard, this);
                row.Id = Convert.ToInt32(dataRow["id"]);
                row.lblNo.Text = number.ToString();
                row.lblEmail.Text = config.config.AES.Decrypt(dataRow["email"].ToString(), Properties.Resources.PassPhrase);
                row.lblUsername.Text = config.config.AES.Decrypt(dataRow["user_name"].ToString(), Properties.Resources.PassPhrase);
                row.lblFullname.Text = config.config.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + config.config.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + config.config.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                row.lblGender.Text = config.config.AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                row.lblRole.Text = dataRow["role"].ToString();
                //row.lblPrison.Text = AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                row.btnDelete.Click += BtnDelete_Click;
                if (File.Exists(config.config.UserRole))
                    if (File.ReadAllText(config.config.UserRole) != "Admin")
                    {
                        row.btnEdit.Visible = false;
                        row.btnDelete.Visible = false;
                    }
                this.UsersflowLayoutPanel.Controls.Add(row);
                number++;
            }

            lblentries.Text = (pageNumber - 1) * pageSize + " - " + ((pageNumber - 1) * pageSize + 25) + " of " + dsUsers.Tables["result"].Rows.Count + " entries";

            ColorScheme.LoadTheme(this.UsersflowLayoutPanel.Controls);
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
            Sound.Click();
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
            UsersPageList((Convert.ToInt32(lblPageNumber.Text) + 1));
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            UsersPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }
    }
}
