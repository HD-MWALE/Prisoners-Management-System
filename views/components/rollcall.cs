using DocumentFormat.OpenXml.Spreadsheet;
using MySqlX.XDevAPI.Relational;
using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
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

namespace Prisoners_Management_System.views.components
{
    public partial class rollcall : UserControl
    {
        public views.dashboard dashboard;
        inputs.rollcall _rollcall;
        DataSet dsRoll_Call = new DataSet();
        public rollcall(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void rollcall_Load(object sender, EventArgs e)
        {
            RollCallPageList(1);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            _rollcall = new inputs.rollcall(dashboard);
            modal.popup popup = new modal.popup(_rollcall);
            popup.Size = _rollcall.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            rollcall_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void RollCallPageList(int pageNumber) 
        {
            lblPageNumber.Text = pageNumber.ToString();
            dsRoll_Call = dashboard.Prison.Roll_Call.GetRollCalls();
            int pageSize = 25;
            var query = dsRoll_Call.Tables["result"].AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.RollcallflowLayoutPanel.Controls.Clear();

            foreach (var dataRow in query)
            {
                rows.rollcall row = new rows.rollcall(dashboard, this);
                row.Id = (int)dataRow["id"];
                row.lblNo.Text = number.ToString();
                row.lblCode.Text = dataRow["code"].ToString();
                row.lblDate.Text = Convert.ToDateTime(dataRow["date_created"]).ToString("dd/MM/yyyy hh:mm:ss tt");
                row.lblDormitory.Text = config.config.AES.Decrypt(dashboard.Prison.Dormitory.GetName(Convert.ToInt32(dataRow["dormitory_id"])), Properties.Resources.PassPhrase);
                row.lblStatus.Text = dataRow["status"].ToString();
                row.lblTotalInmates.Text = dataRow["total_inmates"].ToString();
                row.lblScannedInmates.Text = dataRow["total_inmates"].ToString();
                txtSearch.AutoCompleteCustomSource.Add(row.lblCode.Text);
                txtSearch.AutoCompleteCustomSource.Add(row.lblDormitory.Text);
                txtSearch.AutoCompleteCustomSource.Add(row.lblStatus.Text);
                if (File.Exists(config.config.UserRole))
                    if (File.ReadAllText(config.config.UserRole) != "Admin")
                    {
                        row.btnDelete.Visible = false;
                    }
                this.RollcallflowLayoutPanel.Controls.Add(row);
                number++;
            }

            lblentries.Text = (pageNumber - 1) * pageSize + " - " + ((pageNumber - 1) * pageSize + 25) + " of " + dsRoll_Call.Tables["result"].Rows.Count + " entries";

            ColorScheme.LoadTheme(this.RollcallflowLayoutPanel.Controls);
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            RollCallPageList((Convert.ToInt32(lblPageNumber.Text) + 1));

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            RollCallPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }
    }
}
