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
        DataSet dsDormitories = new DataSet();
        // user control loading
        public void dormitories_Load(object sender, EventArgs e)
        {
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
            dashboard.SetLoading(true);
            this.DormitoryflowLayoutPanel.Controls.Clear();
            foreach (DataRow dataRow in dsDormitories.Tables["result"].Rows)
            {
                if (config.config.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    config.config.AES.Decrypt(dataRow["gendertype"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    config.config.AES.Decrypt(dataRow["type"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text)
                {
                    rows.dormitory row = new rows.dormitory(dashboard, this);
                    row.Id = Convert.ToInt32(dataRow["id"]);
                    row.lblName.Text = config.config.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                    row.lblDescription.Text = config.config.AES.Decrypt((string)dataRow["description"], Properties.Resources.PassPhrase);
                    row.lblGenderType.Text = config.config.AES.Decrypt((string)dataRow["gendertype"], Properties.Resources.PassPhrase);
                    row.lblType.Text = config.config.AES.Decrypt((string)dataRow["type"], Properties.Resources.PassPhrase);
                    if (File.Exists(config.config.UserRole))
                        if (File.ReadAllText(config.config.UserRole) != "Admin")
                        {
                            row.btnEdit.Visible = false;
                            row.btnDelete.Visible = false;
                        }
                    this.DormitoryflowLayoutPanel.Controls.Add(row);
                }
            }
            ColorScheme.LoadTheme(this.Controls);
            dashboard.SetLoading(false);
        }
        // on gender selected dropdown
        private void dpnGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // load dormitories in paged list
        private void DormitoriesPageList(int pageNumber) 
        {
            lblPageNumber.Text = pageNumber.ToString();
            dsDormitories = dashboard.Prison.Dormitory.GetDormitories();
            int pageSize = 25;
            var query = dsDormitories.Tables["result"].AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.DormitoryflowLayoutPanel.Controls.Clear();

            foreach (var dataRow in query)
            {
                rows.dormitory row = new rows.dormitory(dashboard, this);
                row.lblNo.Text = number.ToString();
                row.Id = Convert.ToInt32(dataRow["id"]);
                row.lblName.Text = config.config.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                txtSearch.AutoCompleteCustomSource.Add(row.lblName.Text);
                row.lblDescription.Text = config.config.AES.Decrypt((string)dataRow["description"], Properties.Resources.PassPhrase);
                row.lblDescription.MaximumSize = new Size(250, 16);
                row.lblDescription.AutoSize = true;
                row.lblGenderType.Text = config.config.AES.Decrypt((string)dataRow["gendertype"], Properties.Resources.PassPhrase);
                row.lblType.Text = config.config.AES.Decrypt((string)dataRow["type"], Properties.Resources.PassPhrase);
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

            lblentries.Text = (((pageNumber) * pageSize) +1) + " - " + (((pageNumber) * pageSize + 25) +1) + " of " + dsDormitories.Tables["result"].Rows.Count + " entries";

            ColorScheme.LoadTheme(this.DormitoryflowLayoutPanel.Controls);
        }
        // go to next page
        private void btnNext_Click(object sender, EventArgs e)
        {
            DormitoriesPageList((Convert.ToInt32(lblPageNumber.Text) + 1));
        }
        // go to previous page
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            DormitoriesPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }
    }
}
