using DocumentFormat.OpenXml.Spreadsheet;
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

namespace Roll_Call_And_Management_System.views.components
{
    public partial class crimes : UserControl
    {
        views.dashboard dashboard;
        inputs.crime crime;
        classes.Crime Crime = new classes.Crime();
        public crimes(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void crimes_Load(object sender, EventArgs e)
        {
            Crime.dataSet = Crime.GetCrimes();
            this.CrimeflowLayoutPanel.Controls.Clear();
            if (Crime.dataSet != null)
            {
                txtSearch.AutoCompleteCustomSource.Clear();
                int number = 1;
                foreach (DataRow dataRow in Crime.dataSet.Tables["result"].Rows)
                {
                    if (number == 26)
                    {
                        break;
                    }
                    else
                    {
                        rows.crime row = new rows.crime(dashboard, this);
                        row.Id = Convert.ToInt32(dataRow[0]);
                        row.lblName.Text = AES.Decrypt(dataRow[1].ToString(), Properties.Resources.PassPhrase);
                        row.lblType.Text = dataRow[2].ToString();
                        txtSearch.AutoCompleteCustomSource.Add(row.lblName.Text);
                        txtSearch.AutoCompleteCustomSource.Add(dataRow[2].ToString());
                        row.lblDescription.Text = AES.Decrypt((string)dataRow[3], Properties.Resources.PassPhrase);
                        row.lblDescription.MaximumSize = new Size(340, 16);
                        row.lblDescription.AutoSize = true;
                        this.CrimeflowLayoutPanel.Controls.Add(row);
                        if (File.Exists(Config.UserRole))
                            if (File.ReadAllText(Config.UserRole) != "Admin")
                            {
                                row.btnEdit.Visible = false;
                                row.btnDelete.Visible = false;
                            }
                        row.btnEdit.Click += Edit_Click;
                        row.btnView.Click += View_Click;
                        row.btnDelete.Click += Delete_Click;
                        row.Click += View_Click;
                        number++;
                    }
                }
            }
            else
            {
                rows.crime row = new rows.crime(dashboard, this);
                row.Id = 0;
                row.lblName.Text = "No Records Found";
                row.lblType.Text = "No Records Found";
                row.lblDescription.Text = "";
                this.CrimeflowLayoutPanel.Controls.Add(row);
                row.btnEdit.Visible = false;
                row.btnView.Visible = false;
                row.btnDelete.Visible = false;
            }
            Config.LoadTheme(this.Controls);
        }

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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
            dashboard.SetLoading(true);
            crime = new inputs.crime();
            modal.popup popup = new modal.popup(crime);
            popup.Size = crime.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation); 
            popup.ShowDialog();
            crimes_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.CrimeflowLayoutPanel.Controls.Clear();
            foreach (DataRow dataRow in Crime.dataSet.Tables["result"].Rows)
            {
                if (AES.Decrypt(dataRow[1].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    dataRow[2].ToString() == txtSearch.Text)
                {
                    rows.crime row = new rows.crime(dashboard, this);
                    row.Id = (int)dataRow[0];
                    row.lblName.Text = AES.Decrypt(dataRow[1].ToString(), Properties.Resources.PassPhrase);
                    row.lblType.Text = dataRow[2].ToString();
                    txtSearch.AutoCompleteCustomSource.Add(row.lblName.Text);
                    txtSearch.AutoCompleteCustomSource.Add(dataRow[2].ToString());
                    row.lblDescription.Text = AES.Decrypt((string)dataRow[3], Properties.Resources.PassPhrase);
                    row.lblDescription.MaximumSize = new Size(340, 16);
                    row.lblDescription.AutoSize = true;
                    this.CrimeflowLayoutPanel.Controls.Add(row);
                    if (File.Exists(Config.UserRole))
                        if (File.ReadAllText(Config.UserRole) != "Admin")
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
            Config.LoadTheme(this.Controls);
        }
    }
}
