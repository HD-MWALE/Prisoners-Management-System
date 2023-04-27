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
using System.Windows.Media;

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
            Reports.PieCharts(dashboard, PopulationPie, DormitoryPopulationPie);
            Reports.Population(dashboard, PopulationLine);
            Reports.DormitoryPopulation(dashboard, DormitoryPopulationBar);
            Reports.CrimesCommitted(CrimesCommittedReport);
            config.ColorScheme.LoadTheme(this.Controls);
        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
