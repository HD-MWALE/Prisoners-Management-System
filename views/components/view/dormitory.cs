using Prisoners_Management_System.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisoners_Management_System.views.components.view
{
    public partial class dormitory : UserControl
    {
        public dormitory(views.dashboard dashboard, dormitories dormitories)
        {
            InitializeComponent();
            // initializing objects
            this.dashboard = dashboard;
            this.dormitories = dormitories;
        }
        public int Id = 0;
        inmates inmates;
        DataSet dsDormitory = new DataSet();
        DataSet dsInmate = new DataSet();
        views.dashboard dashboard;
        dormitories dormitories;
        private void dormitory_Load(object sender, EventArgs e)
        {
            dsDormitory = dashboard.Prison.Dormitory.GetDormitoryDetails(Id);
            if (dsDormitory != null)
            {
                foreach (DataRow dataRow in dsDormitory.Tables["result"].Rows)
                {
                    Id = (int)dataRow["id"];
                    lblDormitoryName.Text = dataRow["name"].ToString();
                    lblDescription.Text = (string)dataRow["description"];
                    lblGenderType.Text = dataRow["gendertype"].ToString();
                    lblType.Text = (string)dataRow["type"];
                }
            }
            inmates = new inmates(dashboard);

            InmatesPageList(1);
            ColorScheme.LoadTheme(this.dormitories.Controls);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            dormitories.dashboard.lblAction.Text = "List";
            dormitories.Controls.Remove(this);
            dashboard.SetLoading(false);
        }
        
        private void InmatesPageList(int pageNumber) 
        {
            lblPageNumber.Text = pageNumber.ToString();
            dsInmate = dashboard.Prison.Inmate.GetInmates();
            var filteredRows =
              from row in dsInmate.Tables["result"].Rows.OfType<DataRow>()
              where (int)row["dormitory_id"] <= Id
              select row;

            var filteredTable = dsInmate.Tables["result"].Clone();

            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));

            int pageSize = 25;
            var query = filteredTable.AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.InmateflowLayoutPanel.Controls.Clear();

            foreach (var currentRow in query)
            {
                rows.inmate row = new rows.inmate(dashboard, this.inmates);
                row.Id = (int)currentRow["id"];
                row.lblNo.Text = number.ToString();
                row.lblCode.Text = currentRow["code"].ToString();
                row.lblFullname.Text = currentRow["last_name"].ToString() + ", " + currentRow["first_name"].ToString() + " " + currentRow["middle_name"].ToString();
                row.lblGender.Text = currentRow["gender"].ToString();
                row.lblDoB.Text = Convert.ToDateTime(currentRow["dob"]).ToString("dd/MM/yyyy");
                row.lblAddress.Text = currentRow["address"].ToString();
                DateTimePicker Start = new DateTimePicker();
                DateTimePicker End = new DateTimePicker();
                Start.Value = Convert.ToDateTime(currentRow["start_date"]);
                End.Value = Convert.ToDateTime(currentRow["end_date"]);
                row.lblSentence.Text = config.config.Calculate.Sentence(Start, End) + "\n" +
                    Convert.ToDateTime(currentRow["start_date"]).ToString("dd/MM/yyyy") + " to " +
                    Convert.ToDateTime(currentRow["end_date"]).ToString("dd/MM/yyyy");
                row.btnEdit.Visible = false;
                row.btnView.Visible = false;
                row.btnDelete.Visible = false;
                this.InmateflowLayoutPanel.Controls.Add(row);
                number++;
            }

            if (dsInmate.Tables["result"].Rows.Count > 25)
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + ((pageNumber - 1) * pageSize + 26) + " of " + filteredTable.Rows.Count + " entries";
            else
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + filteredTable.Rows.Count + " of " + filteredTable.Rows.Count + " entries";

            ColorScheme.LoadTheme(this.InmateflowLayoutPanel.Controls);
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
