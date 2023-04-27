using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.Relational;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Prisoners_Management_System.views.components.rows;
using System.IO;
using System.Threading;
using Prisoners_Management_System.config;
using static Prisoners_Management_System.classes.Crime;
using Prisoners_Management_System.views.components.inputs;
using inmate = Prisoners_Management_System.views.components.rows.inmate;

namespace Prisoners_Management_System.views.components
{
    public partial class inmates : UserControl
    {
        public views.dashboard dashboard;
        components.pardonedlist pardonedList;
        inputs.pardonedlist pardonedlist;
        public inmates(views.dashboard dashboard)
        {
            InitializeComponent();
            // initialize dashboard layout
            this.dashboard = dashboard;

            this.Controls.Add(panel);
            this.panel.Controls.Add(cpbLoader);
            panel.Location = new Point(0, 0);
            panel.Dock = DockStyle.Fill;
            panel.BringToFront();
            cpbLoader.Location = new Point((this.Size.Width / 2) - (cpbLoader.Size.Width / 2), (this.Size.Height / 2) - (cpbLoader.Size.Width / 2));
            cpbLoader.BringToFront();
        }
        // declaring globe variables
        public inmate row;
        public view.inmate viewinmate; 
        public inputs.inmate inmate;
        public int Id;
        DataTable dsInmates = new DataTable();
        DataSet dsCrimes = new DataSet();
        DataSet dsDormitories = new DataSet();
        Panel panel = new Panel();
        // user control loading
        public void inmates_Load(object sender, EventArgs e)
        {
            // initializing view inmate user control
            viewinmate = new view.inmate(dashboard, this);
            // getting dormitories
            dsInmates = dashboard.Prison.Dormitory.GetDormitories().Tables["result"];
            // checking if datatable is not null
            if (dsInmates != null)
            {
                dpnDormitory.Items.Clear();
                dpnDormitory.Items.Add("All Dormitories");
                foreach (DataRow dataRow in dsInmates.Rows)
                {
                    dpnDormitory.Items.Add(dataRow["name"].ToString());
                }
            }
            // setting dormitory dropdown menu text
            dpnDormitory.Text = "All Dormitories";
            // getting all inmates
            dsInmates = dashboard.Prison.Inmate.GetInmates().Tables["result"];
            // calling function to load inmates
            InmatesPageList(1);
        }

        public void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    panel.Visible = true;
                    this.Cursor = Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    panel.Visible = false;
                    this.Cursor = Cursors.Default;
                });
            }
        }
        // delete button click
        private void Delete_Click(object sender, EventArgs e)
        {
            // setting loader
            dashboard.SetLoading(true);
            // calling form load function to reload
            inmates_Load(sender, e);
            // closing loader
            dashboard.SetLoading(false);
        }
        // add new inmate button click
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // setting loader
            dashboard.SetLoading(true);
            inmate = new inputs.inmate(this);
            modal.popup popup = new modal.popup(inmate);
            popup.Size = inmate.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            inmates_Load(sender, e);
            // closing loader
            dashboard.SetLoading(false);
            /*
            dashboard.SetLoading(true);
            Sound.Click();
            inmate = new inputs.inmate(this); 
            dashboard.PathSeparator.Visible = true; 
            dashboard.lblAction.Visible = true;
            dashboard.lblAction.Text = "Add";
            this.Controls.Add(inmate);
            inmate.Dock = DockStyle.Fill;
            inmate.BringToFront();
            ColorScheme.LoadTheme(this.Controls);
            dashboard.SetLoading(false);*/
        }
        // search button click
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // getting all inmates 
            dsInmates = dashboard.Prison.Inmate.GetInmates().Tables["result"];
            // calling function to filter datatable
            dsInmates = FilterData.SearchInmate(dsInmates, txtSearch.Text); 
            // calling function to load inmates
            InmatesPageList(1);
        }
        // select dormitory from dropdown control
        private void dpnDormitory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // checking dormitory name
            if(dpnDormitory.Text == "All Dormitories")
                dsInmates = dashboard.Prison.Inmate.GetInmates().Tables["result"]; // getting all inmates
            else
                dsInmates = dashboard.Prison.Inmate.GetInmates(dpnDormitory.Text).Tables["result"]; // get all inmates from a dormitory
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
        // inmates near to be released button
        private void btnNear_Click(object sender, EventArgs e)
        {
            // getting all inmates 
            dsInmates = dashboard.Prison.Inmate.GetInmates().Tables["result"];
            // calling function to filter datatable
            dsInmates = FilterData.InmatesTable(dsInmates, DateTime.Now.Date, DateTime.Now.Date.AddMonths(6));
            // calling function to load inmates
            InmatesPageList(1);
        }
        // Pardoned List button
        private void btnPList_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            // getting all crimes committed
            dsCrimes = dashboard.Prison.Crimes_Committed.GetAll();
            // getting all inmates
            dsInmates = dashboard.Prison.Inmate.GetInmates(dsCrimes);
            pardonedlist = new inputs.pardonedlist(dashboard, dsInmates);
            modal.popup popup = new modal.popup(pardonedlist);
            popup.Size = pardonedlist.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }
        // loading inmates function with parameter page number
        private void InmatesPageList(int pageNumber)
        {
            // setting loader
            SetLoading(true);
            lblPageNumber.Text = pageNumber.ToString();
            int pageSize = 25;
            var query = dsInmates.AsEnumerable().Skip((pageNumber - 1) * pageSize).Take(pageSize);
            int number = 1;

            this.InmateflowLayoutPanel.Controls.Clear();

            foreach (var currentRow in query)
            {
                inmate row = new inmate(dashboard, this)
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
                row.lblSentence.Text = config.config.Calculate.Sentence(Start, End) + "\n" +
                    Convert.ToDateTime(currentRow["start_date"]).ToString("dd/MM/yyyy") + " to " +
                    Convert.ToDateTime(currentRow["end_date"]).ToString("dd/MM/yyyy");
                txtSearch.AutoCompleteCustomSource.Add(row.lblCode.Text);
                txtSearch.AutoCompleteCustomSource.Add(row.lblGender.Text);
                txtSearch.AutoCompleteCustomSource.Add(currentRow["first_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["middle_name"].ToString());
                txtSearch.AutoCompleteCustomSource.Add(currentRow["last_name"].ToString());
                
                row.btnDelete.Click += Delete_Click;
                if (File.Exists(config.config.UserRole))
                    if (File.ReadAllText(config.config.UserRole) != "Admin")
                    {
                        row.btnEdit.Visible = false;
                        row.btnDelete.Visible = false;
                    }
                this.InmateflowLayoutPanel.Controls.Add(row);
                number++;
            }

            if(dsInmates.Rows.Count > 25) 
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + ((pageNumber - 1) * pageSize + 26) + " of " + dsInmates.Rows.Count + " entries";
            else 
                lblentries.Text = ((pageNumber - 1) * pageSize + 1) + " - " + dsInmates.Rows.Count + " of " + dsInmates.Rows.Count + " entries";
            // setting theme to the ui
            ColorScheme.LoadTheme(this.InmateflowLayoutPanel.Controls);
            // closing loader
            SetLoading(false);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // getting all inmates
            dsInmates = dashboard.Prison.Inmate.GetInmates().Tables["result"];
            // calling function to load inmates
            InmatesPageList(1);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            dashboard.bar.Top = (this.dashboard.btnReports).Top;
            dashboard.lblModel.Text = "Pardorned";
            dashboard.Path(true);
            dashboard.Clear();
            pardonedList = new components.pardonedlist(dashboard);
            dashboard.pnlBody.Controls.Add(pardonedList);
            pardonedList.Dock = DockStyle.Fill;
            pardonedList.BringToFront();

            // Setting theme (Dark/Light)
            ColorScheme.LoadTheme(this.dashboard.Controls);
        }
    }
}
