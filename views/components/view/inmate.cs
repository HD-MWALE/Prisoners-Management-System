using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Google.Protobuf.WellKnownTypes;
using Roll_Call_And_Management_System.config;
using Roll_Call_And_Management_System.views.components.rows;
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

namespace Roll_Call_And_Management_System.views.components.view
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
        DataSet dsInmateHistory = new DataSet(); 
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
                            lblCode.Text = ini.AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                            lblDormitory.Text = ini.AES.Decrypt(dashboard.Prison.Dormitory.GetName(Convert.ToInt32(dataRow["dormitory_id"])), Properties.Resources.PassPhrase);
                            lblFullname.Text = ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                            lblGender.Text = ini.AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                            lblDateOfBirth.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                            lblAddress.Text = ini.AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                            lblMaritalStatus.Text = ini.AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                            lblEyeColour.Text = ini.AES.Decrypt(dataRow["eye_color"].ToString(), Properties.Resources.PassPhrase);
                            lblComplexion.Text = ini.AES.Decrypt(dataRow["complexion"].ToString(), Properties.Resources.PassPhrase);
                            bool Isfirst = true;
                            dsCrimesCommitted = dashboard.Prison.Crimes_Committed.GetAll();
                            if(dsCrimesCommitted != null)
                                foreach (DataRow data in dsCrimesCommitted.Tables["result"].Rows) 
                                {
                                    if(Convert.ToInt32(dataRow["id"]) == Convert.ToInt32(data["inmate_id"]))
                                    {
                                        if (Isfirst)
                                        {
                                            lblCrimeCommitted.Text = ini.AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase);
                                            Isfirst = false;
                                        }
                                        else
                                            lblCrimeCommitted.Text = lblCrimeCommitted.Text + ", " + ini.AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase);
                                    }
                                }
                            //lblSentence.Text = AES.Decrypt(dataRow["sentence"].ToString(), Properties.Resources.PassPhrase);
                            //lblTimeServedStart.Text = Convert.ToDateTime(dataRow["start_date"]).ToString("dd/MM/yyyy hh:mm:ss tt");
                            lblTimeServedStart.Text = Convert.ToDateTime(dataRow["start_date"]).ToString("dd/MM/yyyy");
                            lblTimeServedEnd.Text = Convert.ToDateTime(dataRow["end_date"]).ToString("dd/MM/yyyy");
                            DateTimePicker Start = new DateTimePicker();
                            DateTimePicker End = new DateTimePicker();
                            Start.Value = Convert.ToDateTime(dataRow["start_date"]);
                            End.Value = Convert.ToDateTime(dataRow["end_date"]);
                            lblSentence.Text = ini.Calculate.Sentence(Start, End);
                            lblName.Text = ini.AES.Decrypt(dataRow["emergency_name"].ToString(), Properties.Resources.PassPhrase);
                            lblContact.Text = ini.AES.Decrypt(dataRow["emergency_contact"].ToString(), Properties.Resources.PassPhrase);
                            lblRelation.Text = ini.AES.Decrypt(dataRow["emergency_relation"].ToString(), Properties.Resources.PassPhrase);
                            ibxFace.ImageLocation = ini.Path + "\\Face\\" + ini.AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase) + ".bmp";
                            if (Convert.ToInt32(dataRow["visiting_privilege"]) == 1)
                                IsAllowed = true;
                            else
                                IsAllowed = false;
                            if (IsAllowed)
                                VisitingPrivilege.Image = Properties.Resources.toggle_on;
                            else
                                VisitingPrivilege.Image = Properties.Resources.toggle_off;
                            dsInmateHistory = dashboard.Prison.Inmate_History.GetHistoriesByInmateId(Id);
                            int number = 1;
                            this.HistoryflowLayoutPanel.Controls.Clear();
                            if (dsInmateHistory != null)
                                foreach(DataRow data in dsInmateHistory.Tables["result"].Rows)
                                {
                                    rows.history history = new rows.history(dashboard, this);
                                    history.Id = Convert.ToInt32(data["id"]);
                                    history.lblNo.Text = number.ToString();
                                    history.lblAction.Text = ini.AES.Decrypt(data["action"].ToString(), Properties.Resources.PassPhrase);
                                    history.lblDate.Text = Convert.ToDateTime(data["date"]).ToString("dd/MM/yyyy hh:mm:ss tt");
                                    txtSearch.AutoCompleteCustomSource.Add(history.lblAction.Text);
                                    if (File.Exists(ini.UserRole))
                                        if (File.ReadAllText(ini.UserRole) != "Admin")
                                        {
                                            history.btnEdit.Visible = false;
                                            history.btnDelete.Visible = false;
                                        }
                                    history.btnDelete.Click += BtnDelete_Click;
                                    this.HistoryflowLayoutPanel.Controls.Add(history);
                                    number++;
                                }
                            break;
                        }
                    }
                }
            }

            ini.ColorScheme.LoadTheme(this.inmates.dashboard.Controls);
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
            ini.Sound.ClickSound();
            history = new inputs.history(dashboard);
            history.InmateId = Id.ToString();
            modal.popup popup = new modal.popup(history);
            popup.Size = history.Size;
            popup.Location = ini.Orientation.GetLocation(ini.AppSize, popup.Size, ini.AppLocation);
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
    }
}
