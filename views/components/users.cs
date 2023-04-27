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
        DataTable dsUsers = new DataTable();
        public users(views.dashboard dashboard)
        { 
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void users_Load(object sender, EventArgs e)
        {
            dsUsers = dashboard.Prison.User.GetUsers().Item1.Tables["result"];
            UsersPageList(1);
        }

        private void UsersPageList(int pageNumber) 
        {
            lblPageNumber.Text = pageNumber.ToString();
            int pageSize = 25;
            var query = dsUsers.AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.UsersflowLayoutPanel.Controls.Clear();

            foreach (var currentRow in query)
            {
                user row = new user(dashboard, this);
                row.Id = Convert.ToInt32(currentRow["id"]);
                row.lblNo.Text = number.ToString();
                txtSearch.AutoCompleteCustomSource.Add(currentRow["email"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["user_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["first_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["last_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["middle_name"].ToString());
                row.lblEmail.Text = currentRow["email"].ToString();
                row.lblUsername.Text = currentRow["user_name"].ToString();
                row.lblFullname.Text = currentRow["last_name"].ToString() + ", " + currentRow["first_name"].ToString() + " " + currentRow["middle_name"].ToString();
                row.lblGender.Text = currentRow["gender"].ToString();
                row.lblDoB.Text = Convert.ToDateTime(currentRow["dob"]).ToString("dd/MM/yyyy");
                row.lblRole.Text = currentRow["role"].ToString();
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

            if (dsUsers.Rows.Count > 25)
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + ((pageNumber - 1) * pageSize + 26) + " of " + dsUsers.Rows.Count + " entries";
            else
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + dsUsers.Rows.Count + " of " + dsUsers.Rows.Count + " entries";

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
        // go to next page button
        private void btnNext_Click(object sender, EventArgs e)
        {
            // calling function to load users next page
            UsersPageList((Convert.ToInt32(lblPageNumber.Text) + 1));
        }
        // go to previous page button
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // calling function to load users previous page
            UsersPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // getting all users 
            dsUsers = dashboard.Prison.User.GetUsers().Item1.Tables["result"];
            // calling function to filter datatable
            dsUsers = FilterData.SearchUser(dsUsers, txtSearch.Text);
            // calling function to load users
            UsersPageList(1);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            users_Load(sender, e);
        }
    }
}
