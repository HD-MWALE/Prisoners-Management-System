using DocumentFormat.OpenXml.Spreadsheet;
using Roll_Call_And_Management_System.classes;
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

namespace Roll_Call_And_Management_System.views.components
{
    public partial class visitors : UserControl
    {
        public views.dashboard dashboard;
        public visitor visitor;
        public visitors(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void visitors_Load(object sender, EventArgs e)
        {
            VisitorsPageList(1);
        }

        private void VisitorsPageList(int pageNumber) 
        {
            lblPageNumber.Text = pageNumber.ToString();
            dashboard.Prison.Visitor.dataSet = dashboard.Prison.Visitor.GetVisitors();
            int pageSize = 25;
            var query = dashboard.Prison.Visitor.dataSet.Tables["result"].AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.VisitorflowLayoutPanel.Controls.Clear();

            foreach (var dataRow in query) 
            {
                visitor row = new visitor(dashboard, this);
                row.Id = (int)dataRow["id"];
                row.lblNo.Text = number.ToString();
                row.lblName.Text = ini.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                row.lblRelation.Text = ini.AES.Decrypt(dataRow["relation"].ToString(), Properties.Resources.PassPhrase);
                row.lblContact.Text = ini.AES.Decrypt(dataRow["contact"].ToString(), Properties.Resources.PassPhrase);
                row.lblAddress.Text = ini.AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                row.lblInmate.Text = ini.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + ini.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + ini.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                row.lblDate.Text = Convert.ToDateTime(dataRow["date_created"]).ToString("dd/MM/yyyy");
                row.btnDelete.Click += BtnDelete_Click;
                if (File.Exists(ini.UserRole))
                    if (File.ReadAllText(ini.UserRole) != "Admin")
                    {
                        row.btnEdit.Visible = false;
                        row.btnDelete.Visible = false;
                    }
                this.VisitorflowLayoutPanel.Controls.Add(row);
                number++;
            }

            lblEntities.Text = (pageNumber - 1) * pageSize + " - " + ((pageNumber - 1) * pageSize + 25) + " of " + dashboard.Prison.Inmate.dataSet.Tables["result"].Rows.Count + " entities";

            ini.ColorScheme.LoadTheme(this.VisitorflowLayoutPanel.Controls);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            visitors_Load(sender, e);
            dashboard.SetLoading(false);
        }

        inputs.visitor input; 
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            ini.Sound.ClickSound();
            input = new inputs.visitor(this);
            modal.popup popup = new modal.popup(input);
            popup.Size = input.Size;
            popup.Location = ini.Orientation.GetLocation(ini.AppSize, popup.Size, ini.AppLocation);
            popup.ShowDialog();
            visitors_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            VisitorsPageList((Convert.ToInt32(lblPageNumber.Text) + 1)); 
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            VisitorsPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }
    }
}
