using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisoners_Management_System.views.components.view
{
    public partial class rollcall : UserControl
    {
        public views.dashboard dashboard;
        components.rollcall Rollcall;
        public rollcall(views.dashboard dashboard, components.rollcall rollcall)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.Rollcall = rollcall;
        }
        public int Id = 0;

        private void btnBack_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            dashboard.lblAction.Text = "List";
            Rollcall.Controls.Remove(this);
            dashboard.SetLoading(false);
        }
        inmates inmates;
        DataSet dsRoll_Call = new DataSet();
        DataTable dsInmates = new DataTable();
        DataSet dsDormitory = new DataSet(); 
        private void rollcall_Load(object sender, EventArgs e)
        {
            inmates = new inmates(dashboard);
            if (Id != 0)
            {
                dsRoll_Call = dashboard.Prison.Roll_Call.GetRollCallDetails(Id);
                if (dsRoll_Call != null)
                {
                    foreach (DataRow dataRow in dsRoll_Call.Tables["result"].Rows)
                    {
                        Id = Convert.ToInt32(dataRow["id"].ToString());
                        lblCode.Text = dataRow["code"].ToString();
                        // getting dormitory details
                        dsDormitory = dashboard.Prison.Dormitory.GetDormitoryDetails(Convert.ToInt32(dataRow["dormitory_id"]));
                        if(dsDormitory != null)
                        {
                            foreach (DataRow row in dsDormitory.Tables["result"].Rows)
                            {
                                lblDormitoryName.Text = row["name"].ToString();
                            }
                        }
                        // getting all inmates from a roll call
                        dsInmates = dashboard.Prison.Roll_Call.GetDetails(lblCode.Text).Tables["result"];
                        // calling load inmates function
                        InmatesPageList(1);
                    }
                }
            }

            ColorScheme.LoadTheme(this.Rollcall.dashboard.Controls);
        }
        // load inmates page list function
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
                rows.inmate inmate = new rows.inmate(dashboard, inmates);
                Id = Convert.ToInt32(currentRow["id"].ToString());
                lblDormitoryName.Text = dashboard.Prison.Dormitory.GetName(Convert.ToInt32(currentRow["dormitory_id"]));
                inmate.Id = (int)currentRow["id"];
                inmate.lblNo.Text = number.ToString();
                inmate.lblCode.Text = currentRow["code"].ToString();
                inmate.lblFullname.Text = currentRow["last_name"].ToString() + ", " + currentRow["first_name"].ToString() + " " + currentRow["middle_name"].ToString();
                inmate.lblGender.Text = currentRow["gender"].ToString();
                inmate.lblDoB.Text = Convert.ToDateTime(currentRow["dob"]).ToString("dd/MM/yyyy");
                DateTimePicker Start = new DateTimePicker();
                DateTimePicker End = new DateTimePicker();
                Start.Value = Convert.ToDateTime(currentRow["start_date"]);
                End.Value = Convert.ToDateTime(currentRow["end_date"]);
                inmate.lblSentence.Text = config.config.Calculate.Sentence(Start, End) + "\n" +
                    Convert.ToDateTime(currentRow["start_date"]).ToString("dd/MM/yyyy") + " to " +
                    Convert.ToDateTime(currentRow["end_date"]).ToString("dd/MM/yyyy");
                inmate.lblAddress.Text = currentRow["address"].ToString();
                inmate.specifier = this.Name;
                txtSearch.AutoCompleteCustomSource.Add(inmate.lblCode.Text);
                txtSearch.AutoCompleteCustomSource.Add(inmate.lblFullname.Text);
                txtSearch.AutoCompleteCustomSource.Add(currentRow["first_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["middle_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["last_name"].ToString());
                InmateflowLayoutPanel.Controls.Add(inmate);
                if (File.Exists(config.config.UserRole))
                    if (File.ReadAllText(config.config.UserRole) != "Admin")
                    {
                        inmate.btnEdit.Visible = false;
                        inmate.btnDelete.Visible = false;
                    }
                number++;
            }

            if (dsInmates.Rows.Count > 25)
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + ((pageNumber - 1) * pageSize + 26) + " of " + dsInmates.Rows.Count + " entries";
            else
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + dsInmates.Rows.Count + " of " + dsInmates.Rows.Count + " entries";
            // setting theme to the ui
            ColorScheme.LoadTheme(this.InmateflowLayoutPanel.Controls);
            // closing loader
            dashboard.SetLoading(false);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // getting all inmates from a roll call
            dsInmates = dashboard.Prison.Roll_Call.GetDetails(lblCode.Text).Tables["result"];
            // calling function to filter datatable
            dsInmates = FilterData.SearchInmate(dsInmates, txtSearch.Text);
            // calling function to load inmates
            InmatesPageList(1);
        }
        // refresh button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // getting all inmates from a roll call
            dsInmates = dashboard.Prison.Roll_Call.GetDetails(lblCode.Text).Tables["result"];
            // calling load inmates function
            InmatesPageList(1);
        }
    }
}
