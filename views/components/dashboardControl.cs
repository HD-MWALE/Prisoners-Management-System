using LiveCharts.Wpf;
using LiveCharts;
using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
using Prisoners_Management_System.views.components.dashboard;
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
using SeriesCollection = LiveCharts.SeriesCollection;
using Axis = LiveCharts.Wpf.Axis;

namespace Prisoners_Management_System.views.components
{
    public partial class dashboardControl : UserControl 
    { 
        public dashboardControl(views.dashboard dashboard) 
        {
            InitializeComponent();
            // initialize dashboard layout
            this.dashboard = dashboard;
            LoadDashboard();
        }
        // declaring globe variables
        views.dashboard dashboard;
        PrisonFactory Prison = new PrisonFactory();
        DataSet dsVisitors = new DataSet();
        DataSet dsUsers = new DataSet();
        DataSet dsInmates = new DataSet();
        DataSet dsDormitories = new DataSet();
        DataSet dsCrimes = new DataSet();
        card card = new card();
        // user control loading
        public void dashboardControl_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }
        public void LoadDashboard()
        {
            flowLayoutPanelTop.Controls.Clear();
            flowLayoutPanelRight.Controls.Clear();

            dsInmates = dashboard.Prison.Inmate.GetInmates();
            if (dsInmates != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Inmates";
                card.Icon.Image = Properties.Resources.prisoner;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in dsInmates.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Inmates";
            }

            dsDormitories = dashboard.Prison.Dormitory.GetDormitories();
            if (dsDormitories != null)
            {
                int j = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Dormitories";
                card.Icon.Image = Properties.Resources.prison_building;
                flowLayoutPanelRight.Controls.Add(card);
                
                card.lblTitle.Text = dsDormitories.Tables["result"].Rows.Count + " Dormitories";
                foreach (DataRow dataRow in dsDormitories.Tables["result"].Rows)
                {
                    j = 0;
                    foreach (DataRow row in dsInmates.Tables["result"].Rows)
                    {
                        if (dataRow["id"].ToString() == row["dormitory_id"].ToString())
                            j++;
                    }
                    card = new card();
                    card.lblSubTitle.Text = "Total number of Inmates in Dormitory";
                    card.Icon.Image = Properties.Resources.prisoner;
                    flowLayoutPanelRight.Controls.Add(card);
                    card.lblTitle.Text = j + " Inmates in " + dataRow["name"].ToString();
                }
            }
            
            dsCrimes = dashboard.Prison.Crime.GetCrimes();
            if (dsCrimes != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Crimes";
                card.Icon.Image = Properties.Resources.handcuffs;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in dsCrimes.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Crimes";
            }
            dsVisitors = dashboard.Prison.Visitor.GetVisitors();
            if (dsVisitors != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Visitors";
                card.Icon.Image = Properties.Resources.waiting_room;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in dsVisitors.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Visitors";
            }
            (DataSet, string) response = dashboard.Prison.User.GetUsers();
            dsUsers = response.Item1;
            if (dsUsers != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Wardens";
                card.Icon.Image = Properties.Resources.users;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in dsUsers.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Wardens";
            }
            Reports.PieCharts(dashboard, PopulationPie, DormitoryPopulationPie);
            Reports.Population(dashboard, PopulationLine);
            Reports.DormitoryPopulation(dashboard, DormitoryPopulationBar);
            Reports.CrimesCommitted(CrimesCommittedReport);
            ColorScheme.LoadTheme(this.Controls); 
        }
    }
}
