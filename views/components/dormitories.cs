using DocumentFormat.OpenXml.Spreadsheet;
using Roll_Call_And_Management_System.classes;
using Roll_Call_And_Management_System.config;
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
    public partial class dormitories : UserControl
    {
        public views.dashboard dashboard;
        public inputs.dormitory dormitory;
        public view.dormitory _dormitory;

        public dormitories(views.dashboard dashboard) 
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void dormitories_Load(object sender, EventArgs e)
        {
            dashboard.Prison.Dormitory.dataSet = dashboard.Prison.Dormitory.GetDormitories();
            this.DormitoryflowLayoutPanel.Controls.Clear();
            if (dashboard.Prison.Dormitory.dataSet != null)
            {
                int number = 1;
                foreach (DataRow dataRow in dashboard.Prison.Dormitory.dataSet.Tables["result"].Rows)
                {
                    if (number == 26)
                    {
                        break;
                    }
                    else
                    {
                        rows.dormitory row = new rows.dormitory(dashboard, this);
                        row.lblNo.Text = number.ToString();
                        row.Id = Convert.ToInt32(dataRow["id"]);
                        row.lblName.Text = ini.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                        txtSearch.AutoCompleteCustomSource.Add(row.lblName.Text);
                        row.lblDescription.Text = ini.AES.Decrypt((string)dataRow["description"], Properties.Resources.PassPhrase);
                        row.lblDescription.MaximumSize = new Size(250, 16);
                        row.lblDescription.AutoSize = true;
                        row.lblGenderType.Text = ini.AES.Decrypt((string)dataRow["gendertype"], Properties.Resources.PassPhrase);
                        row.lblType.Text = ini.AES.Decrypt((string)dataRow["type"], Properties.Resources.PassPhrase);
                        txtSearch.AutoCompleteCustomSource.Add(row.lblGenderType.Text);
                        txtSearch.AutoCompleteCustomSource.Add(row.lblType.Text);
                        if (File.Exists(ini.UserRole))
                            if (File.ReadAllText(ini.UserRole) != "Admin")
                            {
                                row.btnEdit.Visible = false;
                                row.btnDelete.Visible = false;
                            }
                        row.btnDelete.Click += BtnDelete_Click;
                        this.DormitoryflowLayoutPanel.Controls.Add(row);
                        number++;
                    }
                }
            }
            else
            {
                rows.dormitory row = new rows.dormitory(dashboard, this);
                row.Id = 0;
                row.lblName.Text = "No Records Found";
                this.DormitoryflowLayoutPanel.Controls.Add(row);
                row.btnEdit.Visible = false;
                row.btnView.Visible = false;
                row.btnDelete.Visible = false;
            }
            ini.ColorScheme.LoadTheme(this.Controls);
        } 

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            dormitories_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            ini.Sound.ClickSound();
            dormitory = new inputs.dormitory(dashboard);
            modal.popup popup = new modal.popup(dormitory);
            popup.Size = dormitory.Size;
            popup.Location = ini.Orientation.GetLocation(ini.AppSize, popup.Size, ini.AppLocation);
            popup.ShowDialog();
            dormitories_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            this.DormitoryflowLayoutPanel.Controls.Clear();
            foreach (DataRow dataRow in dashboard.Prison.Dormitory.dataSet.Tables["result"].Rows)
            {
                if (ini.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    ini.AES.Decrypt(dataRow["gendertype"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    ini.AES.Decrypt(dataRow["type"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text)
                {
                    rows.dormitory row = new rows.dormitory(dashboard, this);
                    row.Id = Convert.ToInt32(dataRow["id"]);
                    row.lblName.Text = ini.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                    row.lblDescription.Text = ini.AES.Decrypt((string)dataRow["description"], Properties.Resources.PassPhrase);
                    row.lblGenderType.Text = ini.AES.Decrypt((string)dataRow["gendertype"], Properties.Resources.PassPhrase);
                    row.lblType.Text = ini.AES.Decrypt((string)dataRow["type"], Properties.Resources.PassPhrase);
                    if (File.Exists(ini.UserRole))
                        if (File.ReadAllText(ini.UserRole) != "Admin")
                        {
                            row.btnEdit.Visible = false;
                            row.btnDelete.Visible = false;
                        }
                    this.DormitoryflowLayoutPanel.Controls.Add(row);
                }
            }
            ini.ColorScheme.LoadTheme(this.Controls);
            dashboard.SetLoading(false);
        }

        private void dpnGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
