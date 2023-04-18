using DocumentFormat.OpenXml.Spreadsheet;
using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
using Prisoners_Management_System.views.components.rows;
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
    public partial class visitors : UserControl
    {
        public views.dashboard dashboard;
        public visitor visitor;
        DataSet dsVisitor = new DataSet();
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
            dsVisitor = dashboard.Prison.Visitor.GetVisitors();
            int pageSize = 25;
            var query = dsVisitor.Tables["result"].AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.VisitorflowLayoutPanel.Controls.Clear();

            foreach (var dataRow in query) 
            {
                visitor row = new visitor(dashboard, this);
                row.Id = (int)dataRow["id"];
                row.lblNo.Text = number.ToString();
                row.lblName.Text = config.config.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                row.lblRelation.Text = config.config.AES.Decrypt(dataRow["relation"].ToString(), Properties.Resources.PassPhrase);
                row.lblContact.Text = config.config.AES.Decrypt(dataRow["contact"].ToString(), Properties.Resources.PassPhrase);
                row.lblAddress.Text = config.config.AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                row.lblInmate.Text = config.config.AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + config.config.AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + config.config.AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                row.lblDate.Text = Convert.ToDateTime(dataRow["date_created"]).ToString("dd/MM/yyyy");
                row.btnDelete.Click += BtnDelete_Click;
                if (File.Exists(config.config.UserRole))
                    if (File.ReadAllText(config.config.UserRole) != "Admin")
                    {
                        row.btnEdit.Visible = false;
                        row.btnDelete.Visible = false;
                    }
                this.VisitorflowLayoutPanel.Controls.Add(row);
                number++;
            }

            lblentries.Text = (pageNumber - 1) * pageSize + " - " + ((pageNumber - 1) * pageSize + 25) + " of " + dsVisitor.Tables["result"].Rows.Count + " entries";

            ColorScheme.LoadTheme(this.VisitorflowLayoutPanel.Controls);
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
            Sound.Click();
            input = new inputs.visitor(this);
            modal.popup popup = new modal.popup(input);
            popup.Size = input.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
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
