using LiveCharts.Wpf;
using LiveCharts.WinForms;
using LiveCharts;
using Prisoners_Management_System.database;
using Prisoners_Management_System.views;
using Prisoners_Management_System.views.components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Windows.Media;
using Prisoners_Management_System.config;
using CartesianChart = LiveCharts.WinForms.CartesianChart;
using PieChart = LiveCharts.WinForms.PieChart;

namespace Prisoners_Management_System.classes
{
    public class Reports
    {
        // initializing object class
        public Reports() { }
        // declaring globe variables
        public static DataTable dataTable = new DataTable();
        // most committed crimes
        public static void CrimesCommitted(CartesianChart CrimesCommittedReport)
        {
            DataSet dataSet = Reports.GetCrimesCommitted();

            IChartValues values = new ChartValues<double>();
            IList<string> labels = new List<string>();

            // Line Graph
            CrimesCommittedReport.Series.Clear();
            CrimesCommittedReport.AxisX.Clear();
            CrimesCommittedReport.AxisY.Clear();

            foreach (DataRow data in dataSet.Tables["result"].Rows)
            {
                labels.Add(data["name"].ToString());
                values.Add(Convert.ToDouble(data["total"]));

                CrimesCommittedReport.Series.Add(new ColumnSeries
                {
                    Title = data["name"].ToString(),
                    DataLabels = false,
                    Values = new ChartValues<double> { Convert.ToDouble(data["total"]) },
                });
            }

            CrimesCommittedReport.AxisX.Add(new Axis
            {
                Title = "Crimes",
                Labels = labels,
                LabelsRotation = 45,
                ShowLabels = false,
                FontSize = 16,
                Separator = new Separator { Step = 1 },
                Foreground = System.Windows.Media.Brushes.Black,
            });

            CrimesCommittedReport.AxisY.Add(new Axis
            {
                FontSize = 18,
                Title = "Total Number",
                ShowLabels = true,
                MinValue = 0,
                Foreground = System.Windows.Media.Brushes.Black,
                LabelFormatter = value => value.ToString("N")
            });
        }
        // piechart report
        public static void PieCharts(dashboard dashboard, PieChart PopulationPie, PieChart DormitoryPopulationPie)
        {
            DataSet dsDormitories = Reports.GetDormitories("SELECT dormitory.`name`, COUNT(inmate.`id`) AS count FROM `dormitory`, `inmate` WHERE inmate.dormitory_id = dormitory.id GROUP BY dormitory.name ORDER BY dormitory.`id`");
            DataSet dsInmates = dashboard.Prison.Reports.GetInmatesPopulation();

            PopulationPie.Series.Clear();
            DormitoryPopulationPie.Series.Clear();

            // Define the label that will appear over the piece of the chart
            // in this case we'll show the given value and the percentage e.g 123 (8%)
            Func<ChartPoint, string> labelPointinmates = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
            Func<ChartPoint, string> labelPointdormitory = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            // Define the collection of Values to display in the Pie Chart
            DormitoryPopulationPie.Series = new SeriesCollection();
            PopulationPie.Series = new SeriesCollection();

            // declaring local variable
            PieSeries PieSeriesInmates;
            PieSeries PieSeriesDormitory;
            foreach (DataRow row in dsDormitories.Tables["result"].Rows)
            {
                PieSeriesInmates = new PieSeries()
                {
                    Title = row["name"].ToString(),
                    Values = new ChartValues<double> { Convert.ToDouble(row["count"]) },
                    DataLabels = true,
                    LabelPoint = labelPointinmates,
                    Foreground = Brushes.Black,
                };

                DormitoryPopulationPie.Series.Add(PieSeriesInmates);
                // define the location of the legend and set the data labels to display
                DormitoryPopulationPie.LegendLocation = LegendLocation.Right;
                PieSeriesInmates.DataLabels = true;
            }

            foreach (DataRow row in dsInmates.Tables["result"].Rows)
            {
                PieSeriesDormitory = new PieSeries() {

                    Title = row["year"].ToString(),
                    Values = new ChartValues<double> { Convert.ToDouble(row["total"]) },
                    DataLabels = true,
                    LabelPoint = labelPointdormitory,
                    Foreground = Brushes.Black,
                };

                PopulationPie.Series.Add(PieSeriesDormitory);
                // define the location of the legend and set the data labels to display
                PopulationPie.LegendLocation = LegendLocation.Right;
                PieSeriesDormitory.DataLabels = true;
            }
        }
        // prison population report
        public static void Population(dashboard dashboard, CartesianChart PopulationLine)
        {
            DataSet dataSet = dashboard.Prison.Reports.GetInmatesPopulation();

            IChartValues values = new ChartValues<double>();
            IList<string> labels = new List<string>();

            // Line Graph
            PopulationLine.Series.Clear();
            PopulationLine.AxisX.Clear();
            PopulationLine.AxisY.Clear();

            PopulationLine.Series = new SeriesCollection();

            foreach (DataRow data in dataSet.Tables["result"].Rows)
            {
                labels.Add(data["year"].ToString());
                values.Add(Convert.ToDouble(data["total"]));
            }
            
            PopulationLine.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Number of Inmates",
                        DataLabels = true,
                        Values = values,
                    }
                };

            PopulationLine.AxisX.Add(new Axis
            {
                Title = "Years",
                FontSize = 18,
                FontWeight = new System.Windows.FontWeight(),
                Labels = labels,
                IsMerged = true,
                Separator = new Separator { Step = 1 },
                Foreground = Brushes.Black,
            });
            PopulationLine.AxisY.Add(new Axis
            {
                Foreground = System.Windows.Media.Brushes.Black,
                Title = "Number of Inmates",
                FontSize = 18,
                MinValue = 0,
                IsMerged = true,
            });
            // dormitory population
        }
        // dormitory population report
        public static void DormitoryPopulation(dashboard dashboard, CartesianChart DormitoryPopulationBar)
        {
            DataSet dsDormitories = dashboard.Prison.Dormitory.GetDormitories();
            DataSet dataSet = dashboard.Prison.Reports.GetDormsPopulation();
            dsDormitories = dashboard.Prison.Dormitory.GetDormitories();

            IChartValues valuesDorms = new ChartValues<double>();
            IList<string> labelsDorms = new List<string>();

            DormitoryPopulationBar.Series.Clear();
            DormitoryPopulationBar.AxisX.Clear();
            DormitoryPopulationBar.AxisY.Clear();

            // Bar Graph
            DormitoryPopulationBar.Series = new SeriesCollection();

            foreach (DataRow data in dsDormitories.Tables["result"].Rows)
            {
                labelsDorms.Add(data["name"].ToString());
                dataSet = dashboard.Prison.Reports.GetInmatesPopulation(Convert.ToInt32(data["id"]));
                foreach (DataRow row in dataSet.Tables["result"].Rows)
                {
                    valuesDorms.Add(Convert.ToDouble(row["total"]));
                    DormitoryPopulationBar.Series.Add(new ColumnSeries
                    {
                        Title = data["name"].ToString(),
                        DataLabels = false,
                        Values = new ChartValues<double> { Convert.ToDouble(row["total"]) },
                    });
                    break;
                }
            }

            DormitoryPopulationBar.AxisX.Add(new Axis
            {
                Title = "Dormitories",
                Labels = labelsDorms,
                LabelsRotation = 45,
                ShowLabels = false,
                FontSize = 16,
                Separator = new Separator { Step = 1 },
                Foreground = System.Windows.Media.Brushes.Black,
            });

            DormitoryPopulationBar.AxisY.Add(new Axis
            {
                FontSize = 18,
                Title = "Total Number",
                MinValue = 0,
                Foreground = System.Windows.Media.Brushes.Black,
                LabelFormatter = value => value.ToString("N")
            });
        }
        public static DataSet GetDormitories(string query)
        {
            DataSet dataSet = Execute.ExecuteDataSet(query);
            if(dataSet != null)
            {
                foreach(DataRow row in dataSet.Tables["result"].Rows)
                {
                    row["name"] = config.config.AES.Decrypt(row["name"].ToString(), Properties.Resources.PassPhrase);
                }
            }
            return dataSet;
        }

        public DataSet GetInmatesPopulation()  
        {
            string query = "SELECT dormitory_id, COUNT(*) AS total, YEAR(date_created) AS year, MONTH(date_created) AS month, DAY(date_created) AS day";
            query += " FROM `inmate`";
            query += " GROUP BY YEAR(date_created)";
            return Execute.ExecuteDataSet(query);
        }

        public DataSet GetInmatesPopulation(int dormitory)
        {
            string query = "SELECT COUNT(*) AS total";
            query += " FROM `inmate`";
            query += " WHERE dormitory_id = " + dormitory;
            return Execute.ExecuteDataSet(query);
        }

        public DataSet GetDormsPopulation()  
        {
            string query = "SELECT dormitory.name, inmate.dormitory_id, COUNT(inmate.id) AS total, YEAR(inmate.date_created) AS year, MONTH(inmate.date_created) AS month, DAY(inmate.date_created) AS day";
            query += " FROM `inmate` INNER JOIN dormitory";
            query += " ON inmate.dormitory_id = dormitory.id";
            query += " GROUP BY YEAR(inmate.date_created)";
            return Execute.ExecuteDataSet(query);
        }

        public static DataSet GetCrimesCommitted() 
        {
            string query = "SELECT COUNT(crimes_committed.id) AS total, crime.name, crimes_committed.date_created " +
                "FROM crime INNER JOIN crimes_committed ON crime.id = crimes_committed.crime_id " +
                "GROUP BY crime.name;";
            DataSet dataSet = Execute.ExecuteDataSet(query);
            if(dataSet != null)
            {
                foreach(DataRow row in dataSet.Tables["result"].Rows)
                {
                    row["name"] = config.config.AES.Decrypt(row["name"].ToString(), Properties.Resources.PassPhrase);
                }
            }
            return dataSet;
        }
    }
}
