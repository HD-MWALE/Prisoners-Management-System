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
using System.Collections.Concurrent;
using System.Threading;
using Roll_Call_And_Management_System.config;
using DocumentFormat.OpenXml.Wordprocessing;

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
        
        public inmate row;
        public view.inmate viewinmate; 
        public int Id;
        public void inmates_Load(object sender, EventArgs e)
        {
            viewinmate = new view.inmate(dashboard, this);
            dashboard.Prison.Dormitory.dataSet = dashboard.Prison.Dormitory.GetDormitories();
            if (dashboard.Prison.Dormitory.dataSet != null)
            {
                dpnDormitory.Items.Clear();
                dpnDormitory.Items.Add("All Dormitories");
                dpnDormitory.Items.Add("Near To Be Released");
                foreach (DataRow dataRow in dashboard.Prison.Dormitory.dataSet.Tables["result"].Rows)
                {
                    dpnDormitory.Items.Add(ini.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase));
                }
            }
            InmatesPageList(1);
            /*
            Thread t = new Thread(new ThreadStart(loadInmates));
            t.IsBackground = true;
            t.Start();*/
        }
        public delegate void UpdateRandomNumbers(DataTable dataTable);

        private void loadInmates() 
        {
            dashboard.Prison.Inmate.dataSet = dashboard.Prison.Inmate.GetInmates();
            
            if (dashboard.Prison.Inmate.dataSet != null)
            {
                DataTable dataTable = dashboard.Prison.Inmate.dataSet.Tables["result"];
                Invoke(new UpdateRandomNumbers(Inmates), new object[] { dataTable });
                Thread.Sleep(500);
                /*
                foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
                {
                    if (number == 26) 
                    {
                        break;
                    }
                    else
                    {
                        
                        row = new inmate(dashboard, this);
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
                    }
                }*/
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
            ini.ColorScheme.LoadTheme(this.Controls);
        }

        private void Inmates(DataTable dataTable)
        {
            int number = 1;
            lblTotalInmates.Text = "There are " + dataTable.Rows.Count + " Inmates";
            this.InmateflowLayoutPanel.Controls.Clear();/*
            Parallel.ForEach(dataTable.AsEnumerable(), currentRow =>
            {
                
            });*/

            var options = new ParallelOptions { MaxDegreeOfParallelism = 8 };
            Parallel.ForEach(dataTable.AsEnumerable(), options, currentRow => 
            {
                
            });
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
            ini.Sound.ClickSound();
            inmate = new inputs.inmate(this); 
            dashboard.PathSeparator.Visible = true; 
            dashboard.lblAction.Visible = true;
            dashboard.lblAction.Text = "Add";
            this.Controls.Add(inmate);
            inmate.Dock = DockStyle.Fill;
            inmate.BringToFront();
            ini.ColorScheme.LoadTheme(this.Controls);
            dashboard.SetLoading(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            dpnDormitory.Text = "Search Results";
            this.InmateflowLayoutPanel.Controls.Clear();
            int number = 1;
            foreach (DataRow dataRow in dashboard.Prison.Inmate.dataSet.Tables["result"].Rows)
            {
                if (ini.AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    ini.AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    ini.AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text)
                {
                    if (number == 26)
                    {
                        break;
                    }
                    else
                    {
                        inmate row = new inmate(dashboard, this);
                        row.Id = (int)dataRow["id"];
                        row.lblNo.Text = number.ToString();
                        row.lblCode.Text = ini.AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                        row.lblFullname.Text = ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        row.lblGender.Text = ini.AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                        row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                        row.lblAddress.Text = ini.AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                        row.lblMaritalStatus.Text = ini.AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                        this.InmateflowLayoutPanel.Controls.Add(row);
                        row.btnEdit.Click += Edit_Click;
                        row.btnView.Click += View_Click;
                        row.btnDelete.Click += Delete_Click;
                        row.Click += View_Click;
                        if (File.Exists(ini.UserRole))
                            if (File.ReadAllText(ini.UserRole) != "Admin")
                            {
                                row.btnEdit.Visible = false;
                                row.btnDelete.Visible = false;
                            }
                        number++;
                    }
                }
            }
            ini.ColorScheme.LoadTheme(this.Controls);
            dashboard.SetLoading(false);
        }

        private void dpnDormitory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int number = 1;
            dashboard.SetLoading(true);
            foreach (DataRow data in dashboard.Prison.Dormitory.dataSet.Tables["result"].Rows)
            {
                this.InmateflowLayoutPanel.Controls.Clear();
                //dpnDormitory.Items.Clear();
                //dpnDormitory.Items.Add(AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase));
                if (dpnDormitory.Text == "Search Results")
                    break;
                if (ini.AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase) == dpnDormitory.Text)
                {
                    foreach (DataRow dataRow in dashboard.Prison.Inmate.dataSet.Tables["result"].Rows)
                    {
                        if (dpnDormitory.Text == "Near To Be Released")
                        {
                            if (Convert.ToDateTime(dataRow["end_date"]) > DateTime.Now &&
                               Convert.ToDateTime(dataRow["end_date"]) < DateTime.Now.Date.AddMonths(4))
                            {
                                if (number == 26)
                                {
                                    break;
                                }
                                else
                                {
                                    inmate row = new inmate(dashboard, this);
                                    row.Id = (int)dataRow["id"];
                                    row.lblNo.Text = number.ToString();
                                    row.lblCode.Text = ini.AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                                    row.lblFullname.Text = ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                                    row.lblGender.Text = ini.AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                                    row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                                    row.lblAddress.Text = ini.AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                                    row.lblMaritalStatus.Text = ini.AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                                    this.InmateflowLayoutPanel.Controls.Add(row);
                                    row.btnEdit.Click += Edit_Click;
                                    row.btnView.Click += View_Click;
                                    row.btnDelete.Click += Delete_Click;
                                    row.Click += View_Click;
                                    if (File.Exists(ini.UserRole))
                                        if (File.ReadAllText(ini.UserRole) != "Admin")
                                        {
                                            row.btnEdit.Visible = false;
                                            row.btnDelete.Visible = false;
                                        }
                                    number++;
                                }
                            }
                        }
                        else
                        {
                            if (dataRow["dormitory_id"].ToString() == data["id"].ToString())
                            {
                                if (number == 26)
                                {
                                    break;
                                }
                                else
                                {
                                    inmate row = new inmate(dashboard, this);
                                    row.Id = (int)dataRow["id"];
                                    row.lblNo.Text = number.ToString();
                                    row.lblCode.Text = ini.AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                                    row.lblFullname.Text = ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                                    row.lblGender.Text = ini.AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                                    row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                                    row.lblAddress.Text = ini.AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                                    row.lblMaritalStatus.Text = ini.AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                                    this.InmateflowLayoutPanel.Controls.Add(row);
                                    row.btnEdit.Click += Edit_Click;
                                    row.btnView.Click += View_Click;
                                    row.btnDelete.Click += Delete_Click;
                                    row.Click += View_Click;
                                    if (File.Exists(ini.UserRole))
                                        if (File.ReadAllText(ini.UserRole) != "Admin")
                                        {
                                            row.btnEdit.Visible = false;
                                            row.btnDelete.Visible = false;
                                        }
                                    number++;
                                }
                            }
                        }
                    }
                    ini.ColorScheme.LoadTheme(this.Controls);
                    break;
                }
                else if(dpnDormitory.Text == "Near To Be Released")
                {
                    foreach (DataRow dataRow in dashboard.Prison.Inmate.dataSet.Tables["result"].Rows)
                    {
                        if (Convert.ToDateTime(dataRow["end_date"]) > DateTime.Now &&
                            Convert.ToDateTime(dataRow["end_date"]) < DateTime.Now.Date.AddMonths(6))
                        {
                            if (number == 26)
                            {
                                break;
                            }
                            else
                            {
                                inmate row = new inmate(dashboard, this);
                                row.Id = (int)dataRow["id"];
                                row.lblNo.Text = number.ToString();
                                row.lblCode.Text = ini.AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                                row.lblFullname.Text = ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                                row.lblGender.Text = ini.AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                                row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                                row.lblAddress.Text = ini.AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                                row.lblMaritalStatus.Text = ini.AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                                this.InmateflowLayoutPanel.Controls.Add(row);
                                row.btnEdit.Click += Edit_Click;
                                row.btnView.Click += View_Click;
                                row.btnDelete.Click += Delete_Click;
                                row.Click += View_Click;
                                if (File.Exists(ini.UserRole))
                                    if (File.ReadAllText(ini.UserRole) != "Admin")
                                    {
                                        row.btnEdit.Visible = false;
                                        row.btnDelete.Visible = false;
                                    }
                                number++;
                            }
                        }
                    }
                    ini.ColorScheme.LoadTheme(this.Controls);
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

        private void btnPList_Click(object sender, EventArgs e)
        {
            dpnDormitory.Text = btnPList.Text;
            this.InmateflowLayoutPanel.Controls.Clear();
            int number = 1;
            foreach (DataRow dataRow in dashboard.Prison.Inmate.dataSet.Tables["result"].Rows)
            {
                if (Convert.ToDateTime(dataRow["end_date"]) > DateTime.Now &&
                    Convert.ToDateTime(dataRow["end_date"]) < DateTime.Now.Date.AddMonths(6))
                {
                    if (number == 26)
                    {
                        break;
                    }
                    else
                    {
                        inmate row = new inmate(dashboard, this);
                        row.Id = (int)dataRow["id"];
                        row.lblNo.Text = number.ToString();
                        row.lblCode.Text = ini.AES.Decrypt(dataRow["code"].ToString(), Properties.Resources.PassPhrase);
                        row.lblFullname.Text = ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                        row.lblGender.Text = ini.AES.Decrypt(dataRow["gender"].ToString(), Properties.Resources.PassPhrase);
                        row.lblDoB.Text = Convert.ToDateTime(dataRow["dob"]).ToString("dd/MM/yyyy");
                        row.lblAddress.Text = ini.AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                        row.lblMaritalStatus.Text = ini.AES.Decrypt(dataRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                        this.InmateflowLayoutPanel.Controls.Add(row);
                        row.btnEdit.Click += Edit_Click;
                        row.btnView.Click += View_Click;
                        row.btnDelete.Click += Delete_Click;
                        row.Click += View_Click;
                        if (File.Exists(ini.UserRole))
                            if (File.ReadAllText(ini.UserRole) != "Admin")
                            {
                                row.btnEdit.Visible = false;
                                row.btnDelete.Visible = false;
                            }
                        number++;
                    }
                }
            }
            ini.ColorScheme.LoadTheme(this.Controls);
        }

        private void InmatesPageList(int pageNumber)
        {
            lblPageNumber.Text = pageNumber.ToString();
            dashboard.Prison.Inmate.dataSet = dashboard.Prison.Inmate.GetInmates();
            int pageSize = 25;
            var query = dashboard.Prison.Inmate.dataSet.Tables["result"].AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.InmateflowLayoutPanel.Controls.Clear();

            foreach (var currentRow in query)
            {
                inmate row = new inmate(dashboard, this);
                row.Id = Convert.ToInt32(currentRow["id"]);
                row.lblNo.Text = number.ToString();
                row.lblCode.Text = ini.AES.Decrypt(currentRow["code"].ToString(), Properties.Resources.PassPhrase);
                row.lblFullname.Text = ini.AES.Decrypt(currentRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + ini.AES.Decrypt(currentRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + ini.AES.Decrypt(currentRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                row.lblGender.Text = ini.AES.Decrypt(currentRow["gender"].ToString(), Properties.Resources.PassPhrase);
                row.lblDoB.Text = Convert.ToDateTime(currentRow["dob"]).ToString("dd/MM/yyyy");
                row.lblAddress.Text = ini.AES.Decrypt(currentRow["address"].ToString(), Properties.Resources.PassPhrase);
                row.lblMaritalStatus.Text = ini.AES.Decrypt(currentRow["marital_status"].ToString(), Properties.Resources.PassPhrase);
                /*txtSearch.AutoCompleteCustomSource.Add(row.lblCode.Text);
                txtSearch.AutoCompleteCustomSource.Add(row.lblFullname.Text);
                txtSearch.AutoCompleteCustomSource.Add(AES.Decrypt(currentRow["first_name"].ToString(), Properties.Resources.PassPhrase));
                txtSearch.AutoCompleteCustomSource.Add(AES.Decrypt(currentRow["middle_name"].ToString(), Properties.Resources.PassPhrase));
                txtSearch.AutoCompleteCustomSource.Add(AES.Decrypt(currentRow["last_name"].ToString(), Properties.Resources.PassPhrase));
                txtSearch.AutoCompleteCustomSource.Add(row.lblMaritalStatus.Text);
                */
                row.btnEdit.Click += Edit_Click;
                row.btnView.Click += View_Click;
                row.btnDelete.Click += Delete_Click;
                row.Click += View_Click;
                if (File.Exists(ini.UserRole))
                    if (File.ReadAllText(ini.UserRole) != "Admin")
                    {
                        row.btnEdit.Visible = false;
                        row.btnDelete.Visible = false;
                    }
                this.InmateflowLayoutPanel.Controls.Add(row);
                number++;
            }

            lblEntities.Text = (pageNumber - 1) * pageSize + " - " + ((pageNumber - 1) * pageSize + 25) + " of " + dashboard.Prison.Inmate.dataSet.Tables["result"].Rows.Count + " entities";

            ini.ColorScheme.LoadTheme(this.InmateflowLayoutPanel.Controls);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            InmatesPageList((Convert.ToInt32(lblPageNumber.Text) + 1));
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            InmatesPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }
    }
}
