using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Google.Protobuf.WellKnownTypes;
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

namespace Prisoners_Management_System.views.components.view
{
    public partial class inmate : UserControl
    {
        views.dashboard dashboard;
        inmates inmates;
        public inmate(views.dashboard dashboard, inmates inmates)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.inmates = inmates;
        }
        public int Id = 0;
        inputs.history history;
        DataSet dsInmate = new DataSet(); 
        DataSet dsCrimesCommitted = new DataSet(); 
        DataTable dsInmateHistory = new DataTable(); 
        public void inmate_Load(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                dsInmate = dashboard.Prison.Inmate.GetInmates();
                if (dsInmate != null)
                {
                    foreach (DataRow dataRow in dsInmate.Tables["result"].Rows)
                    {
                        if (Convert.ToInt32(dataRow["id"]) == Id)
                        {
                            Id = Convert.ToInt32(dataRow["id"].ToString());
                            lblCode.Text = dataRow["code"].ToString();
                            lblDormitory.Text = dashboard.Prison.Dormitory.GetName(Convert.ToInt32(dataRow["dormitory_id"]));
                            lblFullname.Text = dataRow["last_name"].ToString() + ", " + dataRow["first_name"].ToString() + " " + dataRow["middle_name"].ToString();
                            lblGender.Text = dataRow["gender"].ToString();
                            lblDateOfBirth.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                            lblAddress.Text = dataRow["address"].ToString();
                            lblMaritalStatus.Text = dataRow["marital_status"].ToString();
                            lblEyeColour.Text = dataRow["eye_color"].ToString();
                            lblComplexion.Text = dataRow["complexion"].ToString();
                            bool Isfirst = true;
                            dsCrimesCommitted = dashboard.Prison.Crimes_Committed.GetAll();
                            if(dsCrimesCommitted != null)
                                foreach (DataRow data in dsCrimesCommitted.Tables["result"].Rows) 
                                {
                                    if(Convert.ToInt32(dataRow["id"]) == Convert.ToInt32(data["inmate_id"]))
                                    {
                                        if (Isfirst)
                                        {
                                            lblCrimeCommitted.Text = data["name"].ToString();
                                            Isfirst = false;
                                        }
                                        else
                                            lblCrimeCommitted.Text = lblCrimeCommitted.Text + ", " + data["name"].ToString();
                                    }
                                }
                            lblTimeServedStart.Text = Convert.ToDateTime(dataRow["start_date"]).ToString("dd/MM/yyyy");
                            lblTimeServedEnd.Text = Convert.ToDateTime(dataRow["end_date"]).ToString("dd/MM/yyyy");
                            DateTimePicker Start = new DateTimePicker();
                            DateTimePicker End = new DateTimePicker();
                            Start.Value = Convert.ToDateTime(dataRow["start_date"]);
                            End.Value = Convert.ToDateTime(dataRow["end_date"]);
                            lblSentence.Text = config.config.Calculate.Sentence(Start, End);
                            lblName.Text = dataRow["emergency_name"].ToString();
                            lblContact.Text = dataRow["emergency_contact"].ToString();
                            lblRelation.Text = dataRow["emergency_relation"].ToString();
                            ibxFace.ImageLocation = config.config.Path + "\\Face\\" + dataRow["code"].ToString() + ".bmp";
                            if (Convert.ToInt32(dataRow["visiting_privilege"]) == 1)
                                IsAllowed = true;
                            else
                                IsAllowed = false;
                            if (IsAllowed)
                                VisitingPrivilege.Image = Properties.Resources.toggle_on;
                            else
                                VisitingPrivilege.Image = Properties.Resources.toggle_off;
                            break;
                        }
                    }
                }
            }
            dsInmateHistory = dashboard.Prison.Inmate_History.GetHistoriesByInmateId(Id).Tables["result"];
            InmatesPageList(1);
            ColorScheme.LoadTheme(this.dashboard.Controls);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            inmate_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            inmates.dashboard.lblAction.Text = "List";
            inmates.Controls.Remove(this);
            dashboard.SetLoading(false);
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            config.Sound.Click();
            history = new inputs.history(dashboard);
            history.InmateId = Id.ToString();
            modal.popup popup = new modal.popup(history);
            popup.Size = history.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            inmate_Load(sender, e);
            dashboard.SetLoading(false);
        }

        bool IsAllowed = false;
        private void VisitingPrivilege_Click(object sender, EventArgs e)
        {
            if (IsAllowed)
            {
                VisitingPrivilege.Image = Properties.Resources.toggle_off;
                dashboard.Prison.Inmate.SetVisitingPrivilege(Id, 0); 
                IsAllowed = false;
            }
            else
            {
                VisitingPrivilege.Image = Properties.Resources.toggle_on;
                dashboard.Prison.Inmate.SetVisitingPrivilege(Id, 1); 
                IsAllowed = true;
            }
        }

        private void InmatesPageList(int pageNumber)
        {
            lblPageNumber.Text = pageNumber.ToString();
            int pageSize = 25;
            var query = dsInmateHistory.AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.HistoryflowLayoutPanel.Controls.Clear();

            foreach (var data in query) 
            {
                rows.history history = new rows.history(dashboard, this);
                history.Id = Convert.ToInt32(data["id"]);
                history.lblNo.Text = number.ToString();
                history.lblAction.Text = data["action"].ToString();
                history.lblDate.Text = Convert.ToDateTime(data["date"]).ToString("dd/MM/yyyy hh:mm:ss tt");
                txtSearch.AutoCompleteCustomSource.Add(history.lblAction.Text);
                if (File.Exists(config.config.UserRole))
                    if (File.ReadAllText(config.config.UserRole) != "Admin")
                    {
                        history.btnEdit.Visible = false;
                        history.btnDelete.Visible = false;
                    }
                history.btnDelete.Click += BtnDelete_Click;
                this.HistoryflowLayoutPanel.Controls.Add(history);
                number++;
            }

            lblentries.Text = (pageNumber - 1) * pageSize + " - " + ((pageNumber - 1) * pageSize + 26) + " of " + dsInmateHistory.Rows.Count + " entries";

            ColorScheme.LoadTheme(this.HistoryflowLayoutPanel.Controls);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            InmatesPageList((Convert.ToInt32(lblPageNumber.Text) + 1));
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            InmatesPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // getting all inmate histories
            dsInmateHistory = dashboard.Prison.Inmate.GetInmates().Tables["result"];
            // calling function to filter datatable
            dsInmateHistory = FilterData.SearchInmate(dsInmateHistory, txtSearch.Text);
            // calling function to load inmate histories
            InmatesPageList(1);
        }
    }
}
