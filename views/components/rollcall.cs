using DocumentFormat.OpenXml.Spreadsheet;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class rollcall : UserControl
    {
        public rollcall(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }
        public views.dashboard dashboard;
        feedbacks feedbacks;
        inputs.rollcall _rollcall;
        DataTable dsRoll_Call = new DataTable();

        public void rollcall_Load(object sender, EventArgs e)
        {
            dsRoll_Call = dashboard.Prison.Roll_Call.GetRollCalls().Tables["result"];
            RollCallPageList(1);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            _rollcall = new inputs.rollcall(dashboard);
            modal.popup popup = new modal.popup(_rollcall);
            popup.Size = _rollcall.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            rollcall_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void RollCallPageList(int pageNumber) 
        {
            dashboard.SetLoading(true);
            lblPageNumber.Text = pageNumber.ToString();
            int pageSize = 25;
            var query = dsRoll_Call.AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.RollcallflowLayoutPanel.Controls.Clear();

            foreach (var currentRow in query)
            {
                rows.rollcall row = new rows.rollcall(dashboard, this);
                row.Id = (int)currentRow["id"];
                row.lblNo.Text = number.ToString();
                row.lblCode.Text = currentRow["code"].ToString();
                row.lblDate.Text = Convert.ToDateTime(currentRow["date_created"]).ToString("dd/MM/yyyy hh:mm:ss tt");
                row.lblDormitory.Text = config.config.AES.Decrypt(currentRow["name"].ToString(), Properties.Resources.PassPhrase);
                row.lblStatus.Text = currentRow["status"].ToString();
                row.lblTotalInmates.Text = currentRow["total_inmates"].ToString();
                row.lblScannedInmates.Text = currentRow["total_inmates"].ToString();
                txtSearch.AutoCompleteCustomSource.Add(row.lblCode.Text);
                txtSearch.AutoCompleteCustomSource.Add(row.lblDormitory.Text);
                if (File.Exists(config.config.UserRole))
                    if (File.ReadAllText(config.config.UserRole) != "Admin")
                    {
                        row.btnDelete.Visible = false;
                    }
                this.RollcallflowLayoutPanel.Controls.Add(row);
                number++;
            }

            if (dsRoll_Call.Rows.Count > 25)
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + ((pageNumber - 1) * pageSize + 26) + " of " + dsRoll_Call.Rows.Count + " entries";
            else
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + dsRoll_Call.Rows.Count + " of " + dsRoll_Call.Rows.Count + " entries";

            ColorScheme.LoadTheme(this.RollcallflowLayoutPanel.Controls);
            dashboard.SetLoading(false);
        }
        // go to next page button
        private void btnNext_Click(object sender, EventArgs e)
        {
            // calling function to load roll call next page
            RollCallPageList((Convert.ToInt32(lblPageNumber.Text) + 1));
        }
        // go to previous page button
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // calling function to load roll call previous page
            RollCallPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // getting all roll call 
            dsRoll_Call = dashboard.Prison.Roll_Call.GetRollCalls().Tables["result"];
            // calling function to filter datatable
            dsRoll_Call = FilterData.SearchRollCall(dsRoll_Call, txtSearch.Text);
            // calling function to load visitors
            RollCallPageList(1);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            rollcall_Load(sender, e);
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            dashboard.bar.Top = (this.dashboard.btnReports).Top;
            dashboard.lblModel.Text = dashboard.btnReports.Text.Trim();
            dashboard.Path(true);
            dashboard.lblAction.Text = "Statistical Reports";
            dashboard.Clear();
            feedbacks = new components.feedbacks(dashboard);
            dashboard.pnlBody.Controls.Add(feedbacks);
            feedbacks.Dock = DockStyle.Fill;
            feedbacks.BringToFront();

            // Setting theme (Dark/Light)
            ColorScheme.LoadTheme(this.dashboard.Controls);
        }
    }
}
