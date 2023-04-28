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

namespace Prisoners_Management_System.views.components
{
    public partial class pardonedlist : UserControl
    {
        public pardonedlist(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }
        views.dashboard dashboard;
        inputs.pardonedlist pardonedList;
        DataTable dsInmates = new DataTable();
        DataSet dsCrimes = new DataSet();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // getting all inmates 
            dsInmates = dashboard.Prison.Inmate.GetPardornedInmates().Tables["result"];
            // calling function to filter datatable
            dsInmates = FilterData.SearchInmate(dsInmates, txtSearch.Text);
            // calling function to load inmates
            InmatesPageList(1);
        }

        // go to next page button
        private void btnNext_Click(object sender, EventArgs e)
        {
            // calling function to load inmates next page
            InmatesPageList((Convert.ToInt32(lblPageNumber.Text) + 1));
        }
        // go to previous page button
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            // calling function to load inmates previous page
            InmatesPageList((Convert.ToInt32(lblPageNumber.Text) - 1));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            pardonedlist_Load(sender, e);
        }

        private void pardonedlist_Load(object sender, EventArgs e)
        {
            // getting all inmates
            dsInmates = dashboard.Prison.Inmate.GetPardornedInmates().Tables["result"];
            // calling function to load inmates
            InmatesPageList(1);
        }7
        // loading inmates function with parameter page number
        private void InmatesPageList(int pageNumber)
        {
            // setting loader
            dashboard.SetLoading(true);
            lblPageNumber.Text = pageNumber.ToString();
            int pageSize = 25;
            var query = dsInmates.AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.InmateflowLayoutPanel.Controls.Clear();

            foreach (var currentRow in query)
            {
                rows.inmate row = new rows.inmate(dashboard, this.dashboard.inmates)
                {
                    Id = Convert.ToInt32(currentRow["id"])
                };
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
                row.lblSentence.Text = currentRow["reason"].ToString();
                txtSearch.AutoCompleteCustomSource.Add(row.lblCode.Text);
                txtSearch.AutoCompleteCustomSource.Add(row.lblGender.Text);
                txtSearch.AutoCompleteCustomSource.Add(currentRow["first_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["middle_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["last_name"].ToString());

                row.btnEdit.Visible = false;
                row.btnView.Visible = false;
                row.btnDelete.Visible = false;
                this.InmateflowLayoutPanel.Controls.Add(row);
                number++;
            }

            if (dsInmates.Rows.Count > 25)
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + ((pageNumber - 1) * pageSize + 26) + " of " + dsInmates.Rows.Count + " entries";
            else
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + dsInmates.Rows.Count + " of " + dsInmates.Rows.Count + " entries";
            // setting theme to the ui
            ColorScheme.LoadTheme(this.InmateflowLayoutPanel.Controls);
            // closing loader
            dashboard.SetLoading(false);
        }

        private void btnPList_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            // getting all crimes committed
            dsCrimes = dashboard.Prison.Crimes_Committed.GetAll();
            // getting all inmates
            dsInmates = dashboard.Prison.Inmate.GetInmates(dsCrimes);
            pardonedList = new inputs.pardonedlist(dashboard, dsInmates);
            modal.popup popup = new modal.popup(pardonedList);
            popup.Size = pardonedList.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }
    }
}
