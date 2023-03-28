using DocumentFormat.OpenXml.Spreadsheet;
using Roll_Call_And_Management_System.classes;
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
        classes.Dormitory Dormitory = new classes.Dormitory();
        public dormitories(views.dashboard dashboard) 
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void dormitories_Load(object sender, EventArgs e)
        {
            Dormitory.dataSet = Dormitory.GetDormitories();
            this.DormitoryflowLayoutPanel.Controls.Clear();
            if (Dormitory.dataSet != null)
            {
                int number = 1;
                foreach (DataRow dataRow in Dormitory.dataSet.Tables["result"].Rows)
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
                        row.lblName.Text = AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                        txtSearch.AutoCompleteCustomSource.Add(row.lblName.Text);
                        row.lblDescription.Text = AES.Decrypt((string)dataRow["description"], Properties.Resources.PassPhrase);
                        row.lblDescription.MaximumSize = new Size(250, 16);
                        row.lblDescription.AutoSize = true;
                        row.lblGenderType.Text = AES.Decrypt((string)dataRow["gendertype"], Properties.Resources.PassPhrase);
                        row.lblType.Text = AES.Decrypt((string)dataRow["type"], Properties.Resources.PassPhrase);
                        txtSearch.AutoCompleteCustomSource.Add(row.lblGenderType.Text);
                        txtSearch.AutoCompleteCustomSource.Add(row.lblType.Text);
                        if (File.Exists(Config.UserRole))
                            if (File.ReadAllText(Config.UserRole) != "Admin")
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
            Config.LoadTheme(this.Controls);
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
            Config.ClickSound();
            dormitory = new inputs.dormitory();
            modal.popup popup = new modal.popup(dormitory);
            popup.Size = dormitory.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            dormitories_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            this.DormitoryflowLayoutPanel.Controls.Clear();
            foreach (DataRow dataRow in Dormitory.dataSet.Tables["result"].Rows)
            {
                if (AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    AES.Decrypt(dataRow["gendertype"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text ||
                    AES.Decrypt(dataRow["type"].ToString(), Properties.Resources.PassPhrase) == txtSearch.Text)
                {
                    rows.dormitory row = new rows.dormitory(dashboard, this);
                    row.Id = Convert.ToInt32(dataRow["id"]);
                    row.lblName.Text = AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                    row.lblDescription.Text = AES.Decrypt((string)dataRow["description"], Properties.Resources.PassPhrase);
                    row.lblGenderType.Text = AES.Decrypt((string)dataRow["gendertype"], Properties.Resources.PassPhrase);
                    row.lblType.Text = AES.Decrypt((string)dataRow["type"], Properties.Resources.PassPhrase);
                    if (File.Exists(Config.UserRole))
                        if (File.ReadAllText(Config.UserRole) != "Admin")
                        {
                            row.btnEdit.Visible = false;
                            row.btnDelete.Visible = false;
                        }
                    this.DormitoryflowLayoutPanel.Controls.Add(row);
                }
            }
            Config.LoadTheme(this.Controls);
            dashboard.SetLoading(false);
        }

        private void dpnGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
