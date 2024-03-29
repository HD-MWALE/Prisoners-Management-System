﻿using Prisoners_Management_System.config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisoners_Management_System.views.components.view
{
    public partial class history : UserControl
    {
        views.dashboard dashboard;
        rows.history rowhistory;
        public history(views.dashboard dashboard, rows.history rowhistory)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.rowhistory = rowhistory;
        }

        public int Id = 0;
        public int InmateId = 0; 
        ArrayList arrHistory = new ArrayList();

        private void history_Load(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                arrHistory = dashboard.Prison.Inmate_History.GetHistory(Id);
                if (arrHistory != null)
                {
                    Id = Convert.ToInt32(arrHistory[0]);
                    lblAction.Text = arrHistory[1].ToString();
                    lblStatus.Text = arrHistory[2].ToString();
                    lblDate.Text = arrHistory[3].ToString();
                    lblRemarks.Text = arrHistory[4].ToString();
                    dashboard.Prison.Inmate.arrayList = dashboard.Prison.Inmate.GetInmate(Convert.ToInt32(arrHistory[5]));
                    lblInmate.Text = dashboard.Prison.Inmate.arrayList[0].ToString() + " - " +
                        dashboard.Prison.Inmate.arrayList[1].ToString() + ", " +
                        dashboard.Prison.Inmate.arrayList[2].ToString() + " " +
                        dashboard.Prison.Inmate.arrayList[3].ToString(); 
                    arrHistory[5].ToString();
                }
            }
        }
    }
}
