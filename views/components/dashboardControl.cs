﻿using Roll_Call_And_Management_System.classes;
using Roll_Call_And_Management_System.config;
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

        card card = new card();
        public void dashboardControl_Load(object sender, EventArgs e)
        {
            Mouth();
            //Reports.Report(this);
        }
        void Mouth() 
        {/*
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
            }*/
        }
        public void LoadDashboard()
        {
            flowLayoutPanelTop.Controls.Clear();
            flowLayoutPanelRight.Controls.Clear();
            
            dashboard.Prison.Inmate.dataSet = dashboard.Prison.Inmate.GetInmates();
            if (dashboard.Prison.Inmate.dataSet != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Inmates";
                card.Icon.Image = Properties.Resources.prisoner;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in dashboard.Prison.Inmate.dataSet.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Inmates";
            }

            dashboard.Prison.Dormitory.dataSet = dashboard.Prison.Dormitory.GetDormitories();
            if (dashboard.Prison.Dormitory.dataSet != null)
            {
                int i = 0, j = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Dormitories";
                card.Icon.Image = Properties.Resources.prison_building;
                flowLayoutPanelRight.Controls.Add(card);
                foreach (DataRow dataRow in dashboard.Prison.Dormitory.dataSet.Tables["result"].Rows)
                {
                    i++;
                }
                card.lblTitle.Text = i + " Dormitories";
                foreach (DataRow dataRow in dashboard.Prison.Dormitory.dataSet.Tables["result"].Rows)
                {
                    j = 0;
                    foreach (DataRow row in dashboard.Prison.Inmate.dataSet.Tables["result"].Rows)
                    {
                        if (dataRow["id"].ToString() == row["dormitory_id"].ToString())
                            j++;
                    }
                    card = new card();
                    card.lblSubTitle.Text = "Total number of Inmates in Dormitory";
                    card.Icon.Image = Properties.Resources.prisoner;
                    flowLayoutPanelRight.Controls.Add(card);
                    card.lblTitle.Text = j + " Inmates in " + ini.AES.Decrypt(dataRow["name"].ToString(),Properties.Resources.PassPhrase);
                }
            }

            dashboard.Prison.Crime.dataSet = dashboard.Prison.Crime.GetCrimes();
            if (dashboard.Prison.Crime.dataSet != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Crimes";
                card.Icon.Image = Properties.Resources.settings;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in dashboard.Prison.Crime.dataSet.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Crimes";
            }
            dashboard.Prison.Visitor.dataSet = dashboard.Prison.Visitor.GetVisitors();
            if (dashboard.Prison.Visitor.dataSet != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Visitors";
                card.Icon.Image = Properties.Resources.waiting_room;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in dashboard.Prison.Visitor.dataSet.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Visitors";
            }
            (DataSet, string) response = dashboard.Prison.User.GetUsers();
            dashboard.Prison.User.dataSet = response.Item1;
            if (dashboard.Prison.User.dataSet != null)
            {
                int i = 0;
                card = new card();
                card.lblSubTitle.Text = "Total number of Wardens";
                card.Icon.Image = Properties.Resources.users;
                flowLayoutPanelTop.Controls.Add(card);
                foreach (DataRow dataRow in dashboard.Prison.User.dataSet.Tables["result"].Rows)
                    i++;
                card.lblTitle.Text = i + " Wardens";
            }
            //Reports.LoadReports(this);
            dashboard.Prison.Reports.PrisonPopulation(this);
            dashboard.Prison.Reports.DormitoryPopulation(this);
            ini.ColorScheme.LoadTheme(this.Controls); 
        }

        private void dpnMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            LoadDashboard();
            dashboard.SetLoading(false);
        }
    }
}
