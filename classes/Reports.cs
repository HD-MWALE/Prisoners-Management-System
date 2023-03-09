using LiveCharts.Wpf;
using LiveCharts;
using Roll_Call_And_Management_System.database;
using Roll_Call_And_Management_System.views;
using Roll_Call_And_Management_System.views.components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows.Media;
using Microsoft.Data.Analysis;

namespace Roll_Call_And_Management_System.classes
{
    internal class Reports
    {
        public static DataTable dataTable = new DataTable();
        public Reports() { }
        reports reports;
        dashboardControl dashboardControl;

        public void LoadReports(UserControl control)  
        {
            DataTable dt = GetDormitoriesData();
           
            if (control is reports) 
            {
                reports = (reports)control;

                //DataSet dataSet = GetDormitories();
                DataSet dataSet = new DataSet();
                dataSet = GetDormitories("SELECT dormitory.`name`, COUNT(inmate.`id`) AS count FROM `dormitory`, `inmate` WHERE inmate.dormitory_id = dormitory.id GROUP BY dormitory.name ORDER BY dormitory.`id`");

                reports.pieChart1.Series.Clear();

                // bind the chart to your dataset
                reports.pieChart1.Series = new SeriesCollection();
                reports.pieChart1.Text = "Number of Inmates In Dormitories";
                PieSeries myPieSeries;
                ChartValues<double> myChartValues;
                bool t = true;
                foreach (DataRow row in dataSet.Tables["result"].Rows)
                {
                    myPieSeries = new PieSeries();

                    myPieSeries.Foreground = System.Windows.Media.Brushes.Black;

                    myPieSeries.Title = AES.Decrypt(row["name"].ToString(), Properties.Resources.PassPhrase);
                    reports.pieChart1.Series.Add(myPieSeries);


                    myChartValues = new ChartValues<double>
                    {
                        Convert.ToDouble(row["count"])
                    };

                    myPieSeries.Values = myChartValues;

                    // set the labels of the slices to the categories in the dataset
                    myPieSeries.LabelPoint = point => $"{point.Y} ({AES.Decrypt(row["name"].ToString(), Properties.Resources.PassPhrase)})";

                    // define the location of the legend and set the data labels to display
                    reports.pieChart1.LegendLocation = LegendLocation.Right;
                    myPieSeries.DataLabels = true;

                    /*
                    reports.cartesianChart1.Series.Clear();

                    reports.cartesianChart1.Series = new SeriesCollection
                    {
                        new LineSeries
                        {
                            Title = "Series 1",
                            Values = new ChartValues<double> {4, 6, 5, 2, 7}
                        },
                        new LineSeries
                        {
                            Title = "Series 2",
                            Values = new ChartValues<double> {6, 7, 3, 4, 6},
                            PointGeometry = null
                        },
                        new LineSeries
                        {
                            Title = "Series 2",
                            Values = new ChartValues<double> {5, 2, 8, 3 },
                            PointGeometry = DefaultGeometries.Square,
                            PointGeometrySize = 15
                        }
                    };

                    reports.cartesianChart1.AxisX.Add(new Axis
                    {
                        Title = "Month",
                        Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" }
                    });

                    reports.cartesianChart1.AxisY.Add(new Axis
                    {
                        Title = "Sales",
                        LabelFormatter = value => value.ToString("C")
                    });

                    reports.cartesianChart1.LegendLocation = LegendLocation.Right;

                    //modifying the series collection will animate and update the chart
                    reports.cartesianChart1.Series.Add(new LineSeries
                    {
                        Values = new ChartValues<double> { 5, 3, 2, 4, 5 },
                        LineSmoothness = 0, //straight lines, 1 really smooth lines
                        PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                        PointGeometrySize = 50,
                        PointForeground = Brushes.Gray
                    });

                    //modifying any series values will also animate and update the chart
                    reports.cartesianChart1.Series[2].Values.Add(5d);


                    reports.cartesianChart1.DataClick += CartesianChart1_DataClick;*/
                    
                }

                dataSet = GetInmatesPopulation();

                reports.cartesianChart1.Series.Clear();
                reports.cartesianChart1.AxisX.Clear();
                reports.cartesianChart1.AxisY.Clear();

                reports.cartesianChart1.Series = new SeriesCollection();

                foreach (DataRow data in dataSet.Tables["result"].Rows)
                {
                    reports.cartesianChart1.Series.Add(new ColumnSeries
                    {
                        Title = data["year"].ToString(),
                        Values = new ChartValues<double> { Convert.ToDouble(data["total"]) }
                    });
                }

                reports.cartesianChart1.AxisX.Add(new Axis
                {
                    Title = "Inmates Population",
                    Labels = new[] { "Years" }
                });

                reports.cartesianChart1.AxisY.Add(new Axis
                {
                    Title = "Number of Inmates",
                    LabelFormatter = value => value.ToString("N"),
                });

                Dormitory.dataSet = Dormitory.GetDormitories();
                //dataSet = GetRollCall();
                IChartValues valuesInPrison = new ChartValues<double>(); 
                IChartValues valuesInDorms = new ChartValues<double>();
                IList<string> strings = new List<string>();

                reports.cartesianChart3.Series.Clear();
                reports.cartesianChart3.AxisX.Clear();
                reports.cartesianChart3.AxisY.Clear();

                foreach (DataRow data in dataSet.Tables["result"].Rows)
                {
                    strings.Add(data["year"].ToString());
                    valuesInPrison.Add(Convert.ToDouble(data["total"]) + 2);
                    valuesInDorms.Add(Convert.ToDouble(data["total"]));
                    /*
                    foreach (DataRow row in Dormitory.dataSet.Tables["result"].Rows) 
                    {
                        if (Convert.ToInt32(data["dormitory_id"]) == Convert.ToInt32(row["id"]))
                        {
                            valuesInDorms.Add(Convert.ToDouble(data["total"]));
                        }
                    }*/
                }

                reports.cartesianChart3.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Number of Inmates",
                        Values = valuesInPrison
                    },
                    new LineSeries
                    {
                        Title = "Number of Inmates",
                        Values = valuesInDorms
                    }
                };

                reports.cartesianChart3.AxisX.Add(new Axis
                {
                    Labels = strings,
                    IsMerged = true,
                    Separator = new Separator
                    {
                        StrokeThickness = 1,
                        StrokeDashArray = new DoubleCollection(2)
                    }
                });
                reports.cartesianChart3.AxisY.Add(new Axis
                {
                    MinValue = 0,
                    IsMerged = true,
                    Separator = new Separator
                    {
                        StrokeThickness = 1.5,
                        StrokeDashArray = new DoubleCollection(4)

                    }
                });
                /*
                reports.cartesianChart3.Series.Clear();
                reports.cartesianChart3.AxisX.Clear();
                reports.cartesianChart3.AxisY.Clear();
                
                reports.cartesianChart3.Series.Add(new LineSeries
                {
                    Values = new ChartValues<double> { 3, 4, 6, 3, 2, 6 }
                }
                );


                reports.cartesianChart3.Series.Add(new LineSeries
                {
                    Values = new ChartValues<double> { 5, 3, 5, 7, 3, 9 }
                });


                reports.cartesianChart3.Series.Add(new LineSeries
                {
                    Values = new ChartValues<double> { 6, 2, 4, 3, 7, 9 },
                });



                //reports.cartesianChart3.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(55, 32, 49));
                reports.cartesianChart3.AxisX.Add(new Axis
                {
                    IsMerged = true,
                    Separator = new Separator
                    {
                        StrokeThickness = 1,
                        StrokeDashArray = new DoubleCollection(2)
                    }
                });
                reports.cartesianChart3.AxisY.Add(new Axis
                {
                    IsMerged = true,
                    Separator = new Separator
                    {
                        StrokeThickness = 1.5,
                        StrokeDashArray = new DoubleCollection(4)

                    }
                });*/

            }
            else if (control is dashboardControl)
            {
                dashboardControl = (dashboardControl)control;
            }
        }

        private void CartesianChart1_DataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show("You clicked (" + chartPoint.X + "," + chartPoint.Y + ")");
        }

        public static DataSet GetDormitories(string query)
        {
            return Execute.ExecuteDataSet(query);
        }

        Dormitory Dormitory = new Dormitory();
        public DataSet GetDormitories() 
        {
            return Dormitory.GetDormitories();
        }
        public static DataTable GetDormitoriesData()
        {
            string query = "SELECT dormitory.name, COUNT(inmate.id) AS total";
            query += " FROM dormitory dormitory, inmate inmate";
            query += " WHERE inmate.dormitory_id = dormitory.id";
            query += " GROUP BY dormitory.name";
            return Execute.ExecuteDataTable(query);
        }
        public DataSet GetCommittedCrimesData() 
        {
            string query = "SELECT crime.name, crimes_committed.date_created, COUNT(crimes_committed.id) AS total";
            query += " FROM crime, crimes_committed";
            query += " WHERE crimes_committed.crime_id = crime.id";
            query += " GROUP BY crime.name";
            return Execute.ExecuteDataSet(query);
        }
        public DataSet GetInmatesPopulation()  
        {
            string query = "SELECT COUNT(*) AS total, YEAR(date_created) AS year, MONTH(date_created) AS month, DAY(date_created) AS day";
            query += " FROM `inmate`";
            query += " GROUP BY YEAR(date_created)";
            return Execute.ExecuteDataSet(query);
        }
        public DataSet GetDormsPopulation()  
        {
            string query = "SELECT COUNT(*) AS total, YEAR(date_created) AS year, MONTH(date_created) AS month, DAY(date_created) AS day";
            query += " FROM `inmate`";
            query += " GROUP BY YEAR(date_created)";
            return Execute.ExecuteDataSet(query);
        }
        public DataSet GetRollCall() 
        {
            string query = "SELECT COUNT(roll_calloninmate.id) AS total, YEAR(roll_call.date_created) AS year, MONTH(roll_call.date_created) AS month, DAY(roll_call.date_created) AS day";
            query += " FROM `roll_call`, `roll_calloninmate`";
            query += " WHERE roll_call.id = roll_calloninmate.roll_call_id";
            query += " GROUP BY YEAR(roll_call.date_created)";
            return Execute.ExecuteDataSet(query);
        }
    }
}
