using DocumentFormat.OpenXml.Spreadsheet;
using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
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
    public partial class dormitories : UserControl
    {
        public dormitories(views.dashboard dashboard) 
        {
            InitializeComponent();
            // initialize dashboard layout
            this.dashboard = dashboard;
        }
        // declaring globe variables
        public views.dashboard dashboard;
        public inputs.dormitory dormitory;
        public view.dormitory _dormitory;
        DataTable dsDormitories = new DataTable();
        // user control loading
        public void dormitories_Load(object sender, EventArgs e)
        {
            dsDormitories = dashboard.Prison.Dormitory.GetDormitories().Tables["result"];
            DormitoriesPageList(1);
        } 
        // delete button click
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            dormitories_Load(sender, e);
            dashboard.SetLoading(false);
        }
        // add new dormitory button click
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            dormitory = new inputs.dormitory(dashboard);
            modal.popup popup = new modal.popup(dormitory);
            popup.Size = dormitory.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dormitories_Load(sender, e);
            dashboard.SetLoading(false);
        }
        // search button click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // getting all dormitories 
            dsDormitories = dashboard.Prison.User.GetUsers().Item1.Tables["result"];
            // calling function to filter datatable
            dsDormitories = FilterData.SearchDormitory(dsDormitories, txtSearch.Text);
            // calling function to load dormitories
            DormitoriesPageList(1);
        }
        // load dormitories in paged list
        private void DormitoriesPageList(int pageNumber) 
        {
            lblPageNumber.Text = pageNumber.ToString();
            int pageSize = 25;
            var query = dsDormitories.AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.DormitoryflowLayoutPanel.Controls.Clear();

            foreach (var currentRow in query)
            {
                rows.dormitory row = new rows.dormitory(dashboard, this);
                row.lblNo.Text = number.ToString();
                row.Id = Convert.ToInt32(currentRow["id"]);
                row.lblName.Text = currentRow["name"].ToString();
                txtSearch.AutoCompleteCustomSource.Add(row.lblName.Text);
                txtSearch.AutoCompleteCustomSource.Add((string)currentRow["gendertype"]);
                txtSearch.AutoCompleteCustomSource.Add((string)currentRow["type"]);
                row.lblDescription.Text = (string)currentRow["description"];
                row.lblDescription.MaximumSize = new Size(250, 16);
                row.lblDescription.AutoSize = true;
                row.lblGenderType.Text = (string)currentRow["gendertype"];
                row.lblType.Text = (string)currentRow["type"];
                txtSearch.AutoCompleteCustomSource.Add(row.lblGenderType.Text);
                txtSearch.AutoCompleteCustomSource.Add(row.lblType.Text);
                if (File.Exists(config.config.UserRole))
                    if (File.ReadAllText(config.config.UserRole) != "Admin")
                    {
                        row.btnEdit.Visible = false;
                        row.btnDelete.Visible = false;
                    }
                row.btnDelete.Click += BtnDelete_Click;
                this.DormitoryflowLayoutPanel.Controls.Add(row);
                number++;
            }

            if (dsDormitories.Rows.Count > 25)
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + ((pageNumber - 1) * pageSize + 26) + " of " + dsDormitories.Rows.Count + " entries";
            else
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + dsDormitories.Rows.Count + " of " + dsDormitories.Rows.Count + " entries";

            ColorScheme.LoadTheme(this.DormitoryflowLayoutPanel.Controls);
        }
        // go to next page
        private void btnNext_Click(object sender, EventArgs e)
        {
            // calling function to load dormitory next page
            DormitoriesPageList((Convert.ToInt32(lblPageNumber.Text) + 1));
        }
        // go to previous page
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // calling function to load dormitory previous page
            DormitoriesPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dormitories_Load(sender, e);
        }
    }
}
