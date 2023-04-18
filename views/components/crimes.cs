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
    public partial class crimes : UserControl
    {
        public crimes(views.dashboard dashboard)
        {
            InitializeComponent();
            // initialize dashboard layout
            this.dashboard = dashboard;
        }
        // declaring globe variables
        views.dashboard dashboard;
        inputs.crime crime;
        DataSet dsCrimes = new DataSet();
        // user control loading
        public void crimes_Load(object sender, EventArgs e)
        {
            CrimesPageList(1);
        }
        // delete buttun click
        private void Delete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            crimes_Load(sender, e); 
            dashboard.SetLoading(false);
        }

        private void View_Click(object sender, EventArgs e)
        {
            
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            
        }
        // Add new crimes
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Sound.Click();
            dashboard.SetLoading(true);
            crime = new inputs.crime(dashboard);
            modal.popup popup = new modal.popup(crime);
            popup.Size = crime.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);  
            popup.ShowDialog();
            crimes_Load(sender, e);
            dashboard.SetLoading(false);
        }
        // search button click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.CrimeflowLayoutPanel.Controls.Clear();
            foreach (DataRow dataRow in dsCrimes.Tables["result"].Rows)
            {
                if (config.config.AES.Decrypt(dataRow[1].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    dataRow[2].ToString() == txtSearch.Text)
                {
                    rows.crime row = new rows.crime(dashboard, this);
                    row.Id = (int)dataRow[0];
                    row.lblName.Text = config.config.AES.Decrypt(dataRow[1].ToString(), Properties.Resources.PassPhrase);
                    row.lblType.Text = dataRow[2].ToString();
                    txtSearch.AutoCompleteCustomSource.Add(row.lblName.Text);
                    txtSearch.AutoCompleteCustomSource.Add(dataRow[2].ToString());
                    row.lblDescription.Text = config.config.AES.Decrypt((string)dataRow[3], Properties.Resources.PassPhrase);
                    row.lblDescription.MaximumSize = new Size(340, 16);
                    row.lblDescription.AutoSize = true;
                    this.CrimeflowLayoutPanel.Controls.Add(row);
                    if (File.Exists(config.config.UserRole))
                        if (File.ReadAllText(config.config.UserRole) != "Admin")
                        {
                            row.btnEdit.Visible = false;
                            row.btnDelete.Visible = false;
                        }
                    row.btnEdit.Click += Edit_Click;
                    row.btnView.Click += View_Click;
                    row.btnDelete.Click += Delete_Click;
                    row.Click += View_Click;
                }
            }
            ColorScheme.LoadTheme(this.Controls);
        }
        // load crimes in paged list
        private void CrimesPageList(int pageNumber) 
        {
            lblPageNumber.Text = pageNumber.ToString();
            dsCrimes = dashboard.Prison.Crime.GetCrimes();
            int pageSize = 25;
            var query = dsCrimes.Tables["result"].AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.CrimeflowLayoutPanel.Controls.Clear();

            foreach (var dataRow in query)
            {
                rows.crime row = new rows.crime(dashboard, this);
                row.Id = Convert.ToInt32(dataRow[0]);
                row.lblName.Text = config.config.AES.Decrypt(dataRow[1].ToString(), Properties.Resources.PassPhrase);
                row.lblType.Text = dataRow[2].ToString();
                txtSearch.AutoCompleteCustomSource.Add(row.lblName.Text);
                txtSearch.AutoCompleteCustomSource.Add(dataRow[2].ToString());
                row.lblDescription.Text = config.config.AES.Decrypt((string)dataRow[3], Properties.Resources.PassPhrase);
                row.lblDescription.MaximumSize = new Size(340, 16);
                row.lblDescription.AutoSize = true;
                if (File.Exists(config.config.UserRole))
                    if (File.ReadAllText(config.config.UserRole) != "Admin")
                    {
                        row.btnEdit.Visible = false;
                        row.btnDelete.Visible = false;
                    }
                row.btnEdit.Click += Edit_Click;
                row.btnView.Click += View_Click;
                row.btnDelete.Click += Delete_Click;
                row.Click += View_Click;
                this.CrimeflowLayoutPanel.Controls.Add(row);
                number++;
            }

            lblentries.Text = (((pageNumber - 1) * pageSize) + 1) + " - " + (((pageNumber - 1) * pageSize + 25) + 1) + " of " + dsCrimes.Tables["result"].Rows.Count + " entries";

            ColorScheme.LoadTheme(this.CrimeflowLayoutPanel.Controls);
        }
        // go to next page
        private void btnNext_Click(object sender, EventArgs e)
        {
            CrimesPageList((Convert.ToInt32(lblPageNumber.Text) + 1));
        }
        // go to previous page
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            CrimesPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }
    }
}
