using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class visitors : UserControl
    {
        public views.dashboard dashboard;
        public visitor visitor;
        DataTable dsVisitor = new DataTable();
        public visitors(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void visitors_Load(object sender, EventArgs e)
        {
            dsVisitor = dashboard.Prison.Visitor.GetVisitors().Tables["result"];
            VisitorsPageList(1);
        }

        private void VisitorsPageList(int pageNumber) 
        {
            lblPageNumber.Text = pageNumber.ToString();
            int pageSize = 25;
            var query = dsVisitor.AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.VisitorflowLayoutPanel.Controls.Clear();

            foreach (var currentRow in query) 
            {
                visitor row = new visitor(dashboard, this);
                row.Id = (int)currentRow["id"];
                row.lblNo.Text = number.ToString();
                txtSearch.AutoCompleteCustomSource.Add(currentRow["name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["relation"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["contact"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["address"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["first_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["middle_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["last_name"].ToString());
                row.lblName.Text = currentRow["name"].ToString();
                row.lblRelation.Text = currentRow["relation"].ToString();
                row.lblContact.Text = currentRow["contact"].ToString();
                row.lblAddress.Text = currentRow["address"].ToString();
                row.lblInmate.Text = currentRow["last_name"].ToString() + ", " + currentRow["first_name"].ToString() + " " + currentRow["middle_name"].ToString();
                row.lblDate.Text = Convert.ToDateTime(currentRow["date_created"]).ToString("dd/MM/yyyy");
                row.btnDelete.Click += BtnDelete_Click;
                if (File.Exists(config.config.UserRole))
                    if (File.ReadAllText(config.config.UserRole) != "Admin")
                    {
                        row.btnEdit.Visible = false;
                        row.btnDelete.Visible = false;
                    }
                this.VisitorflowLayoutPanel.Controls.Add(row);
                number++;
            }

            if (dsVisitor.Rows.Count > 25)
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + ((pageNumber - 1) * pageSize + 26) + " of " + dsVisitor.Rows.Count + " entries";
            else
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + dsVisitor.Rows.Count + " of " + dsVisitor.Rows.Count + " entries";

            ColorScheme.LoadTheme(this.VisitorflowLayoutPanel.Controls);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            visitors_Load(sender, e);
            dashboard.SetLoading(false);
        }

        inputs.visitor input; 
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            input = new inputs.visitor(this);
            modal.popup popup = new modal.popup(input);
            popup.Size = input.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            visitors_Load(sender, e);
            dashboard.SetLoading(false);
        }
        // go to next page button
        private void btnNext_Click(object sender, EventArgs e)
        {
            // calling function to load visitors next page
            VisitorsPageList((Convert.ToInt32(lblPageNumber.Text) + 1));
        }
        // go to previous page button
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // calling function to load visitors previous page
            VisitorsPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // getting all visitors 
            dsVisitor = dashboard.Prison.Visitor.GetVisitors().Tables["result"];
            // calling function to filter datatable
            dsVisitor = FilterData.SearchVisitor(dsVisitor, txtSearch.Text);
            // calling function to load visitors
            VisitorsPageList(1);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            visitors_Load(sender, e);
        }
    }
}
