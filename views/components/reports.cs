using Roll_Call_And_Management_System.classes;
using System;
using LiveCharts.Wpf;
using LiveCharts;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views.components
{
    public partial class reports : UserControl
    {
        views.dashboard dashboard;
        Reports Reports = new Reports();
        public reports(views.dashboard dashboard) 
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void reports_Load(object sender, EventArgs e)
        {
            //Reports.LoadReports(this);
            Reports.PrisonPopulation(this);
            Reports.DormitoryPopulation(this);
        }
    }
}
