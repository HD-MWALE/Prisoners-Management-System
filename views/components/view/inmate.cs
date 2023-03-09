using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Google.Protobuf.WellKnownTypes;
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
        classes.Inmate Inmate = new classes.Inmate();
        classes.Crime Crime = new classes.Crime();
        classes.Crimes_Committed Committed = new classes.Crimes_Committed(); 
        classes.Dormitory Dormitory = new classes.Dormitory();
        classes.Inmate_History History = new classes.Inmate_History();
        inputs.history history;
        public void inmate_Load(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                Inmate.dataSet = Inmate.GetInmates();
                if (Inmate.dataSet != null)
                {
                    foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
                    {
                        if (Convert.ToInt32(dataRow["id"]) == Id)
                        {
                            Id = Convert.ToInt32(dataRow["id"].ToString());
                            lblCode.Text = AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                            lblDormitory.Text = AES.Decrypt(Dormitory.GetName(Convert.ToInt32(dataRow["dormitory_id"])), Properties.Resources.PassPhrase);
                            lblFullname.Text = AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                            lblGender.Text = AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                            lblDateOfBirth.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                            lblAddress.Text = AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                            lblMaritalStatus.Text = AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                            lblEyeColour.Text = AES.Decrypt(dataRow["eye_color"].ToString(), Properties.Resources.PassPhrase);
                            lblComplexion.Text = AES.Decrypt(dataRow["complexion"].ToString(), Properties.Resources.PassPhrase);
                            bool Isfirst = true;
                            Committed.dataSet = Committed.GetCrimes();
                            if(Committed.dataSet != null)
                                foreach (DataRow data in Committed.dataSet.Tables["result"].Rows) 
                                {
                                    if(Convert.ToInt32(dataRow["id"]) == Convert.ToInt32(data["inmate_id"]))
                                    {
                                        if (Isfirst)
                                        {
                                            lblCrimeCommitted.Text = AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase);
                                            Isfirst = false;
                                        }
                                        else
                                            lblCrimeCommitted.Text = lblCrimeCommitted.Text + ", " + AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase);
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
                            lblSentence.Text = Calculate.Sentence(Start, End);
                            lblName.Text = AES.Decrypt(dataRow["emergency_name"].ToString(), Properties.Resources.PassPhrase);
                            lblContact.Text = AES.Decrypt(dataRow["emergency_contact"].ToString(), Properties.Resources.PassPhrase);
                            lblRelation.Text = AES.Decrypt(dataRow["emergency_relation"].ToString(), Properties.Resources.PassPhrase);
                            ibxFace.ImageLocation = Config.startupPath + "\\Face\\" + AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase) + ".bmp";
                            if (Convert.ToInt32(dataRow["visiting_privilege"]) == 1)
                                IsAllowed = true;
                            else
                                IsAllowed = false;
                            if (IsAllowed)
                                VisitingPrivilege.Image = Properties.Resources.toggle_on;
                            else
                                VisitingPrivilege.Image = Properties.Resources.toggle_off;
                            History.dataSet = History.GetHistoriesByInmateId(Id);
                            int number = 1;
                            this.HistoryflowLayoutPanel.Controls.Clear();
                            if (History.dataSet != null)
                                foreach(DataRow data in History.dataSet.Tables["result"].Rows)
                                {
                                    rows.history history = new rows.history(dashboard, this);
                                    history.Id = Convert.ToInt32(data["id"]);
                                    history.lblNo.Text = number.ToString();
                                    history.lblAction.Text = AES.Decrypt(data["action"].ToString(), Properties.Resources.PassPhrase);
                                    history.lblDate.Text = Convert.ToDateTime(data["date"]).ToString("dd/MM/yyyy hh:mm:ss tt");
                                    txtSearch.AutoCompleteCustomSource.Add(history.lblAction.Text);
                                    if (File.Exists(Config.UserRole))
                                        if (File.ReadAllText(Config.UserRole) != "Admin")
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
            
            Config.LoadTheme(this.inmates.dashboard.Controls);
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
            Config.ClickSound();
            history = new inputs.history();
            history.InmateId = Id.ToString();
            modal.popup popup = new modal.popup(dashboard, history);
            popup.Size = history.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            inmate_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Config.ClickSound();

        }
        bool IsAllowed = false;
        private void VisitingPrivilege_Click(object sender, EventArgs e)
        {
            if (IsAllowed)
            {
                VisitingPrivilege.Image = Properties.Resources.toggle_off;
                IsAllowed = false;
            }
            else
            {
                VisitingPrivilege.Image = Properties.Resources.toggle_on;
                IsAllowed = true;
            }
        }
    }
}
