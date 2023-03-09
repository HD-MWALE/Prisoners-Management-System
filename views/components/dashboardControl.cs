using Roll_Call_And_Management_System.classes;
using Roll_Call_And_Management_System.views.components.dashboard;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Roll_Call_And_Management_System.views.components
{
    public partial class dashboardControl : UserControl 
    {
        views.dashboard dashboard;
        public dashboardControl(views.dashboard dashboard) 
        {
            InitializeComponent();
            this.dashboard = dashboard;
            LoadDashboard();
        }

        Dormitory Dormitory = new Dormitory();
        Inmate Inmate = new Inmate();
        Crime Crime = new Crime(); 
        Visitor Visitor = new Visitor();
        Reports Reports = new Reports();
        User User = new User();
        card card = new card();
        public void dashboardControl_Load(object sender, EventArgs e)
        {
            Mouth();
        }
        void Mouth() 
        {
            switch (DateTime.Now.Month)
            {
                case 1:
                    dpnMonth.Text = "JANUARY";
                    break; 
                case 2:
                    dpnMonth.Text = "FEBRUARY";
                    break;
                case 3:
                    dpnMonth.Text = "MARCH";
                    break;
                case 4:
                    dpnMonth.Text = "APRIL";
                    break;
                case 5:
                    dpnMonth.Text = "MAY";
                    break;
                case 6:
                    dpnMonth.Text = "JUNE";
                    break;
                case 7:
                    dpnMonth.Text = "JULY";
                    break;
                case 8:
                    dpnMonth.Text = "AUGUST";
                    break;
                case 9:
                    dpnMonth.Text = "SEPTEMBER";
                    break;
                case 10: 
                    dpnMonth.Text = "OCTOBER";
                    break;
                case 11: 
                    dpnMonth.Text = "NOVEMBER";
                    break;
                case 12: 
                    dpnMonth.Text = "DECEMBER";
                    break;
            }
        }
        public void LoadDashboard()
        {
            flowLayoutPanelTop.Controls.Clear();
            Dormitory.dataSet = Dormitory.GetDormitories();
            if (Dormitory.dataSet != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of dormitories";
                card.Icon.Image = Properties.Resources.prison_building;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in Dormitory.dataSet.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Dormitories";
            }
            Inmate.dataSet = Inmate.GetInmates();
            if (Inmate.dataSet != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Inmates";
                card.Icon.Image = Properties.Resources.prisoner;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in Inmate.dataSet.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Inmates";
            }
            Crime.dataSet = Crime.GetCrimes();
            if (Crime.dataSet != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Crimes";
                card.Icon.Image = Properties.Resources.settings;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in Crime.dataSet.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Crimes";
            }
            Visitor.dataSet = Visitor.GetVisitors();
            if (Visitor.dataSet != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Visitors";
                card.Icon.Image = Properties.Resources.waiting_room;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in Visitor.dataSet.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Visitors";
            }
            (DataSet, string) response = User.GetUsers();
            User.dataSet = response.Item1;
            if (User.dataSet != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Wardens";
                card.Icon.Image = Properties.Resources.users;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in User.dataSet.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Wardens";
            }
            Reports.LoadReports(this);
            Config.LoadTheme(this.Controls);
        }

        private void dpnMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            LoadDashboard();
            dashboard.SetLoading(false);
        }
    }
}
