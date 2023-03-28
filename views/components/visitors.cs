using DocumentFormat.OpenXml.Spreadsheet;
using Roll_Call_And_Management_System.classes;
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
        views.dashboard dashboard;
        Visitor Visitor = new Visitor();
        public visitor visitor;
        public visitors(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void visitors_Load(object sender, EventArgs e)
        {
            Visitor.dataSet = Visitor.GetVisitors();
            this.InmateflowLayoutPanel.Controls.Clear();
            if (Visitor.dataSet != null)
            {
                int number = 1;
                foreach (DataRow dataRow in Visitor.dataSet.Tables["result"].Rows)
                {
                    visitor row = new visitor(dashboard, this);
                    row.Id = (int)dataRow["id"];
                    row.lblNo.Text = number.ToString();
                    row.lblName.Text = AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase);
                    row.lblRelation.Text = AES.Decrypt(dataRow["relation"].ToString(), Properties.Resources.PassPhrase);
                    row.lblContact.Text = AES.Decrypt(dataRow["contact"].ToString(), Properties.Resources.PassPhrase);
                    row.lblAddress.Text = AES.Decrypt(dataRow["address"].ToString(), Properties.Resources.PassPhrase);
                    row.lblInmate.Text = AES.Decrypt(dataRow["last_name"].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(dataRow["first_name"].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(dataRow["middle_name"].ToString(), Properties.Resources.PassPhrase);
                    row.lblDate.Text = Convert.ToDateTime(dataRow["date_created"]).ToString("dd/MM/yyyy");
                    row.btnDelete.Click += BtnDelete_Click;
                    this.InmateflowLayoutPanel.Controls.Add(row);
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
                visitor row = new visitor(dashboard, this);
                row.Id = 0;
                row.lblNo.Text = "";
                row.lblName.Text = "";
                row.lblRelation.Text = "";
                row.lblContact.Text = "No Records Found";
                row.lblAddress.Text = "";
                row.lblInmate.Text = "";
                row.lblDate.Text = "";
                this.InmateflowLayoutPanel.Controls.Add(row);
                row.btnEdit.Visible = false;
                row.btnView.Visible = false;
                row.btnDelete.Visible = false;
            }
            Config.LoadTheme(this.Controls);
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
            Config.ClickSound();
            input = new inputs.visitor(this);
            modal.popup popup = new modal.popup(input);
            popup.Size = input.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            visitors_Load(sender, e);
            dashboard.SetLoading(false);
        }
    }
}
