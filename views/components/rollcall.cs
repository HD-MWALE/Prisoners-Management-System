using DocumentFormat.OpenXml.Spreadsheet;
using MySqlX.XDevAPI.Relational;
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
    public partial class rollcall : UserControl
    {
        public views.dashboard dashboard;
        inputs.rollcall _rollcall;
        public rollcall(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }
        Roll_Call Roll_Call = new Roll_Call();
        Dormitory Dormitory = new Dormitory();
        public void rollcall_Load(object sender, EventArgs e)
        {
            Roll_Call.dataSet = Roll_Call.GetRollCalls();
            this.RollcallflowLayoutPanel.Controls.Clear();
            if (Roll_Call.dataSet != null)
            {
                int number = 1;
                foreach (DataRow dataRow in Roll_Call.dataSet.Tables["result"].Rows)
                {
                    rows.rollcall row = new rows.rollcall(dashboard, this);
                    row.Id = (int)dataRow["id"];
                    row.lblNo.Text = number.ToString();
                    row.lblCode.Text = dataRow["code"].ToString();
                    row.lblDate.Text = Convert.ToDateTime(dataRow["date_created"]).ToString("dd/MM/yyyy hh:mm:ss tt");
                    row.lblDormitory.Text = AES.Decrypt(Dormitory.GetName(Convert.ToInt32(dataRow["dormitory_id"])), Properties.Resources.PassPhrase);
                    row.lblStatus.Text = dataRow["status"].ToString();
                    row.lblTotalInmates.Text = dataRow["total_inmates"].ToString();
                    row.lblScannedInmates.Text = dataRow["total_inmates"].ToString();
                    txtSearch.AutoCompleteCustomSource.Add(row.lblCode.Text);
                    txtSearch.AutoCompleteCustomSource.Add(row.lblDormitory.Text);
                    txtSearch.AutoCompleteCustomSource.Add(row.lblStatus.Text);
                    this.RollcallflowLayoutPanel.Controls.Add(row);
                    if (File.Exists(Config.UserRole))
                        if (File.ReadAllText(Config.UserRole) != "Admin")
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
            Config.LoadTheme(this.Controls);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Config.ClickSound();
            _rollcall = new inputs.rollcall(dashboard);
            modal.popup popup = new modal.popup(dashboard, _rollcall);
            popup.Size = _rollcall.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            rollcall_Load(sender, e);
            dashboard.SetLoading(false);
        }
    }
}
