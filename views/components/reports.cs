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
            
            cartesianChart2.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            //adding series will update and animate the chart automatically
            cartesianChart2.Series.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            cartesianChart2.Series[1].Values.Add(48d);

            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "Sales Man",
                Labels = new[] { "Maria", "Susan", "Charles", "Frida" }
            });

            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "Sold Apps",
                LabelFormatter = value => value.ToString("N")
            });
        }

        public void reports_Load(object sender, EventArgs e)
        {
            Reports.LoadReports(this);
        }
    }
}
