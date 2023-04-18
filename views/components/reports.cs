using Prisoners_Management_System.classes;
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

namespace Prisoners_Management_System.views.components
{
    public partial class reports : UserControl
    {
        views.dashboard dashboard;
        public reports(views.dashboard dashboard) 
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }

        public void reports_Load(object sender, EventArgs e)
        {
            //Reports.LoadReports(this);
            dashboard.Prison.Reports.PrisonPopulation(this);
            dashboard.Prison.Reports.DormitoryPopulation(this);

            //this.CellBlock1Line = Reports.DormitoriesPopulation(CellBlock1Line);
            dashboard.Prison.Reports.DormitoriesPopulation(CellBlock2Line);
            dashboard.Prison.Reports.DormitoriesPopulation(CellBlock3Line);
            dashboard.Prison.Reports.DormitoriesPopulation(CellBlock4Line);
            dashboard.Prison.Reports.DormitoriesPopulation(CellBlock5Line);
            dashboard.Prison.Reports.DormitoriesPopulation(CellBlock6Line);
            dashboard.Prison.Reports.DormitoriesPopulation(CellBlock7Line);
            dashboard.Prison.Reports.DormitoriesPopulation(CellBlock8Line);
            dashboard.Prison.Reports.DormitoriesPopulation(CellBlock9Line);
            dashboard.Prison.Reports.DormitoriesPopulation(CellBlock10Line);
        }
    }
}
