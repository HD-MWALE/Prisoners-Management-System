using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roll_Call_And_Management_System.classes;
using Roll_Call_And_Management_System.views.components.rows;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Roll_Call_And_Management_System.views.components
{
    public partial class inmates : UserControl
    {
        public views.dashboard dashboard;
        public inmates(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }
        Inmate Inmate = new Inmate();
        Dormitory Dormitory = new Dormitory();
        public int Id;
        public void inmates_Load(object sender, EventArgs e)
        {
            Dormitory.dataSet = Dormitory.GetDormitories();
            if(Dormitory.dataSet != null)
            {
                dpnDormitory.Items.Clear();
                dpnDormitory.Items.Add("All Dormitories");
                dpnDormitory.Items.Add("Near To Be Released");
                foreach (DataRow dataRow in Dormitory.dataSet.Tables["result"].Rows)
                {
                    dpnDormitory.Items.Add(AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase));
                }
            }
            Inmate.dataSet = Inmate.GetInmates();
            this.InmateflowLayoutPanel.Controls.Clear();
            if (Inmate.dataSet != null)
            {
                int number = 1;
                foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
                {
                    inmate row = new inmate(dashboard, this);
                    row.Id = Convert.ToInt32(dataRow["id"]);
                    row.lblNo.Text = number.ToString();
                    row.lblCode.Text = AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                    row.lblFullname.Text = AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                    row.lblGender.Text = AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                    row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                    row.lblAddress.Text = AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                    row.lblMaritalStatus.Text = AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                    txtSearch.AutoCompleteCustomSource.Add(row.lblCode.Text);
                    txtSearch.AutoCompleteCustomSource.Add(row.lblFullname.Text);
                    txtSearch.AutoCompleteCustomSource.Add(AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase));
                    txtSearch.AutoCompleteCustomSource.Add(AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase));
                    txtSearch.AutoCompleteCustomSource.Add(AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase));
                    txtSearch.AutoCompleteCustomSource.Add(row.lblMaritalStatus.Text);
                    this.InmateflowLayoutPanel.Controls.Add(row);
                    row.btnEdit.Click += Edit_Click;
                    row.btnView.Click += View_Click;
                    row.btnDelete.Click += Delete_Click;
                    row.Click += View_Click;
                    if (File.Exists(Config.UserRole))
                        if (File.ReadAllText(Config.UserRole) != "Admin")
                        {
                            row.btnEdit.Visible = false;
                            row.btnDelete.Visible = false;
                        }
                    number++;
                }
            }
            else
            {
                inmate row = new inmate(dashboard, this);
                row.Id = 0;
                row.lblNo.Text = "";
                row.lblCode.Text = "";
                row.lblFullname.Text = "";
                row.lblGender.Text = "No Records Found";
                row.lblDoB.Text = "";
                row.lblAddress.Text = "";
                row.lblMaritalStatus.Text = "";
                this.InmateflowLayoutPanel.Controls.Add(row);
                row.btnEdit.Visible = false;
                row.btnView.Visible = false;
                row.btnDelete.Visible = false;
            }
            Config.LoadTheme(this.Controls);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            inmates_Load(sender, e);
            dashboard.SetLoading(false);

        }

        private void View_Click(object sender, EventArgs e)
        {
            
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public inputs.inmate inmate;
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Config.ClickSound();
            inmate = new inputs.inmate(this); 
            dashboard.PathSeparator.Visible = true; 
            dashboard.lblAction.Visible = true;
            dashboard.lblAction.Text = "Add";
            this.Controls.Add(inmate);
            inmate.Dock = DockStyle.Fill;
            inmate.BringToFront();
            Config.LoadTheme(this.Controls);
            dashboard.SetLoading(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            dpnDormitory.Text = "Search Results";
            this.InmateflowLayoutPanel.Controls.Clear();
            int number = 1;
            foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
            {
                if (AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text)
                {
                    inmate row = new inmate(dashboard, this);
                    row.Id = (int)dataRow["id"];
                    row.lblNo.Text = number.ToString();
                    row.lblCode.Text = AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                    row.lblFullname.Text = AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                    row.lblGender.Text = AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                    row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                    row.lblAddress.Text = AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                    row.lblMaritalStatus.Text = AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                    this.InmateflowLayoutPanel.Controls.Add(row);
                    row.btnEdit.Click += Edit_Click;
                    row.btnView.Click += View_Click;
                    row.btnDelete.Click += Delete_Click;
                    row.Click += View_Click;
                    if (File.Exists(Config.UserRole))
                        if (File.ReadAllText(Config.UserRole) != "Admin")
                        {
                            row.btnEdit.Visible = false;
                            row.btnDelete.Visible = false;
                        }
                    number++;
                }
            }
            Config.LoadTheme(this.Controls);
            dashboard.SetLoading(false);
        }

        private void dpnDormitory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int number = 1;
            dashboard.SetLoading(true);
            foreach (DataRow data in Dormitory.dataSet.Tables["result"].Rows)
            {
                this.InmateflowLayoutPanel.Controls.Clear();
                //dpnDormitory.Items.Clear();
                //dpnDormitory.Items.Add(AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase));
                if (dpnDormitory.Text == "Search Results")
                    break;
                if (AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase) == dpnDormitory.Text)
                {
                    foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
                    {
                        if (dpnDormitory.Text == "Near To Be Released")
                        {
                            if (Convert.ToDateTime(dataRow["end_date"]) > DateTime.Now &&
                               Convert.ToDateTime(dataRow["end_date"]) < DateTime.Now.Date.AddMonths(4))
                            {
                                inmate row = new inmate(dashboard, this);
                                row.Id = (int)dataRow["id"];
                                row.lblNo.Text = number.ToString();
                                row.lblCode.Text = AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                                row.lblFullname.Text = AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                                row.lblGender.Text = AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                                row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                                row.lblAddress.Text = AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                                row.lblMaritalStatus.Text = AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                                this.InmateflowLayoutPanel.Controls.Add(row);
                                row.btnEdit.Click += Edit_Click;
                                row.btnView.Click += View_Click;
                                row.btnDelete.Click += Delete_Click;
                                row.Click += View_Click;
                                if (File.Exists(Config.UserRole))
                                    if (File.ReadAllText(Config.UserRole) != "Admin")
                                    {
                                        row.btnEdit.Visible = false;
                                        row.btnDelete.Visible = false;
                                    }
                                number++;
                            }
                        }
                        else
                        {
                            if (dataRow["dormitory_id"].ToString() == data["id"].ToString())
                            {
                                inmate row = new inmate(dashboard, this);
                                row.Id = (int)dataRow["id"];
                                row.lblNo.Text = number.ToString();
                                row.lblCode.Text = AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                                row.lblFullname.Text = AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                                row.lblGender.Text = AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                                row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                                row.lblAddress.Text = AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                                row.lblMaritalStatus.Text = AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                                this.InmateflowLayoutPanel.Controls.Add(row);
                                row.btnEdit.Click += Edit_Click;
                                row.btnView.Click += View_Click;
                                row.btnDelete.Click += Delete_Click;
                                row.Click += View_Click;
                                if (File.Exists(Config.UserRole))
                                    if (File.ReadAllText(Config.UserRole) != "Admin")
                                    {
                                        row.btnEdit.Visible = false;
                                        row.btnDelete.Visible = false;
                                    }
                                number++;
                            }
                        }
                    }
                    Config.LoadTheme(this.Controls);
                    break;
                }
                else if(dpnDormitory.Text == "Near To Be Released")
                {
                    foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
                    {
                        if (Convert.ToDateTime(dataRow["end_date"]) > DateTime.Now &&
                            Convert.ToDateTime(dataRow["end_date"]) < DateTime.Now.Date.AddMonths(6))
                        {
                            inmate row = new inmate(dashboard, this);
                            row.Id = (int)dataRow["id"];
                            row.lblNo.Text = number.ToString();
                            row.lblCode.Text = AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                            row.lblFullname.Text = AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                            row.lblGender.Text = AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                            row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                            row.lblAddress.Text = AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                            row.lblMaritalStatus.Text = AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                            this.InmateflowLayoutPanel.Controls.Add(row);
                            row.btnEdit.Click += Edit_Click;
                            row.btnView.Click += View_Click;
                            row.btnDelete.Click += Delete_Click;
                            row.Click += View_Click;
                            if (File.Exists(Config.UserRole))
                                if (File.ReadAllText(Config.UserRole) != "Admin")
                                {
                                    row.btnEdit.Visible = false;
                                    row.btnDelete.Visible = false;
                                }
                            number++;
                        }
                    }
                    Config.LoadTheme(this.Controls);
                    break;
                }
            }
            if(!InmateflowLayoutPanel.HasChildren) 
            {
                inmates_Load(sender, e);
            }
            dashboard.SetLoading(false);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog(this.InmateflowLayoutPanel);
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
        }
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }
    }
}
