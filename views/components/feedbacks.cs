using DocumentFormat.OpenXml.Office2010.Excel;
using PagedList;
using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
using Prisoners_Management_System.views.components.dashboard;
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
    public partial class feedbacks : UserControl
    {
        public feedbacks(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }
        views.dashboard dashboard;
        DataTable dsInmates = new DataTable();
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // calling function to load inmates
            feedbacks_Load(sender, e);
        }

        private void feedbacks_Load(object sender, EventArgs e)
        {
            // getting all inmates (who were/are missing)
            dsInmates = dashboard.Prison.Roll_Call.GetFeedBacks().Tables["result"];
            // calling function to load inmates
            InmatesPageList(1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // getting all inmates (who were/are missing)
            dsInmates = dashboard.Prison.Roll_Call.GetFeedBacks().Tables["result"];
            // calling function to filter datatable
            dsInmates = FilterData.SearchInmate(dsInmates, txtSearch.Text);
            // calling function to load inmates
            InmatesPageList(1);
        }

        // go to next page button
        private void btnNext_Click(object sender, EventArgs e)
        {
            // calling function to load inmates next page
            InmatesPageList((Convert.ToInt32(lblPageNumber.Text) + 1));
        }
        // go to previous page button
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // calling function to load inmates previous page
            InmatesPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }
        // loading inmates function with parameter page number
        private void InmatesPageList(int pageNumber)
        {
            // setting loader
            dashboard.SetLoading(true);
            lblPageNumber.Text = pageNumber.ToString();
            int pageSize = 25;
            var query = dsInmates.AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.InmateflowLayoutPanel.Controls.Clear();

            foreach (var currentRow in query)
            {
                inmate row = new inmate(dashboard, this.dashboard.inmates)
                {
                    Id = Convert.ToInt32(currentRow["id"])
                };
                row.lblNo.Text = number.ToString();
                row.lblCode.Text = currentRow["code"].ToString();
                row.lblFullname.Text = currentRow["last_name"].ToString() + ", " + currentRow["first_name"].ToString() + " " + currentRow["middle_name"].ToString();
                row.lblGender.Text = currentRow["gender"].ToString();
                row.lblDoB.Text = Convert.ToDateTime(currentRow["dob"]).ToString("dd/MM/yyyy");
                row.lblAddress.Text = currentRow["address"].ToString();
                row.lblSentence.Text = currentRow["date_created"].ToString() + "\n";

                txtSearch.AutoCompleteCustomSource.Add(row.lblCode.Text);
                txtSearch.AutoCompleteCustomSource.Add(row.lblGender.Text);
                txtSearch.AutoCompleteCustomSource.Add(currentRow["first_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["middle_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["last_name"].ToString());
                row.Name = currentRow["code"].ToString();
                row.Click += (sender, e) =>
                {
                    dashboard.SetLoading(true);
                    view.inmate inmate = new view.inmate(dashboard, dashboard.inmates);
                    inmate.Id = row.Id;
                    dashboard.lblAction.Text = "Viewing Missing Inmate";
                    this.Controls.Add(inmate);
                    inmate.Dock = DockStyle.Fill;
                    inmate.AutoScroll = true;
                    inmate.BringToFront();
                    dashboard.SetLoading(false);
                };

                row.btnView.Location = row.btnEdit.Location;
                row.btnView.Visible = false;
                row.btnEdit.Visible = false;
                row.btnDelete.Visible = false;
                this.InmateflowLayoutPanel.Controls.Add(row);
                number++;
            }

            if (dsInmates.Rows.Count > 25)
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + ((pageNumber - 1) * pageSize + 26) + " of " + dsInmates.Rows.Count + " entries";
            else
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + dsInmates.Rows.Count + " of " + dsInmates.Rows.Count + " entries";
            // setting theme to the ui
            ColorScheme.LoadTheme(this.dashboard.Controls);
            // closing loader
            dashboard.SetLoading(false);
        }
    }
}
