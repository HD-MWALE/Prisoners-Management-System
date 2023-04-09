using DocumentFormat.OpenXml.Spreadsheet;
using MySqlX.XDevAPI.Relational;
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
    public partial class rollcall : UserControl
    {
        public views.dashboard dashboard;
        inputs.rollcall _rollcall;
        public rollcall(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void rollcall_Load(object sender, EventArgs e)
        {
            dashboard.Prison.Roll_Call.dataSet = dashboard.Prison.Roll_Call.GetRollCalls();
            this.RollcallflowLayoutPanel.Controls.Clear();
            if (dashboard.Prison.Roll_Call.dataSet != null)
            {
                int number = 1;
                foreach (DataRow dataRow in dashboard.Prison.Roll_Call.dataSet.Tables["result"].Rows)
                {
                    rows.rollcall row = new rows.rollcall(dashboard, this);
                    row.Id = (int)dataRow["id"];
                    row.lblNo.Text = number.ToString();
                    row.lblCode.Text = dataRow["code"].ToString();
                    row.lblDate.Text = Convert.ToDateTime(dataRow["date_created"]).ToString("dd/MM/yyyy hh:mm:ss tt");
                    row.lblDormitory.Text = ini.AES.Decrypt(dashboard.Prison.Dormitory.GetName(Convert.ToInt32(dataRow["dormitory_id"])), Properties.Resources.PassPhrase);
                    row.lblStatus.Text = dataRow["status"].ToString();
                    row.lblTotalInmates.Text = dataRow["total_inmates"].ToString();
                    row.lblScannedInmates.Text = dataRow["total_inmates"].ToString();
                    txtSearch.AutoCompleteCustomSource.Add(row.lblCode.Text);
                    txtSearch.AutoCompleteCustomSource.Add(row.lblDormitory.Text);
                    txtSearch.AutoCompleteCustomSource.Add(row.lblStatus.Text);
                    this.RollcallflowLayoutPanel.Controls.Add(row);
                    if (File.Exists(ini.UserRole))
                        if (File.ReadAllText(ini.UserRole) != "Admin")
                        {
                            row.btnDelete.Visible = false;
                        }
                    number++;
                }
            }
            else
            {
                rows.rollcall row = new rows.rollcall(dashboard, this);
                row.Id = 0;
                row.lblNo.Text = "";
                row.lblCode.Text = "";
                row.lblDate.Text = "";
                row.lblDormitory.Text = "No Records Found";
                row.lblStatus.Text = "";
                row.lblTotalInmates.Text = "";
                row.lblScannedInmates.Text = "";
                this.RollcallflowLayoutPanel.Controls.Add(row);
                row.btnView.Visible = false;
                row.btnDelete.Visible = false;
            }
            ini.ColorScheme.LoadTheme(this.Controls);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            ini.Sound.ClickSound();
            _rollcall = new inputs.rollcall(dashboard);
            modal.popup popup = new modal.popup(_rollcall);
            popup.Size = _rollcall.Size;
            popup.Location = ini.Orientation.GetLocation(ini.AppSize, popup.Size, ini.AppLocation);
            popup.ShowDialog();
            rollcall_Load(sender, e);
            dashboard.SetLoading(false);
        }
    }
}
