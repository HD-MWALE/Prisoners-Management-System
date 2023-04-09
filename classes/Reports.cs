using LiveCharts.Wpf;
using LiveCharts.WinForms;
using LiveCharts;
using Roll_Call_And_Management_System.database;
using Roll_Call_And_Management_System.views;
using Roll_Call_And_Management_System.views.components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Windows.Media;
using Roll_Call_And_Management_System.config;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace Roll_Call_And_Management_System.classes
{
    public class Reports
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
                

                Dormitory.dataSet = Dormitory.GetDormitories();
                //dataSet = GetRollCall();
                IChartValues valuesInPrison = new ChartValues<double>(); 
                IChartValues valuesInDorms = new ChartValues<double>();
                IList<string> strings = new List<string>();

                reports.DormitoryPopulationBar.Series.Clear();
                reports.DormitoryPopulationBar.AxisX.Clear();
                reports.DormitoryPopulationBar.AxisY.Clear();

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

                reports.DormitoryPopulationBar.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Inmates",
                        DataLabels = true,
                        Values = valuesInPrison
                    },
                    new LineSeries
                    {
                        Title = "Inmates",
                        DataLabels = true,
                        Values = valuesInDorms
                    }
                };

                reports.DormitoryPopulationBar.AxisX.Add(new Axis
                {
                    Title = "Years",
                    FontSize = 18,
                    FontWeight = new System.Windows.FontWeight(),
                    Labels = strings,
                    IsMerged = true,
                    Separator = new Separator
                    {
                        StrokeThickness = 1,
                        StrokeDashArray = new DoubleCollection(2)
                    }
                }); 
                reports.DormitoryPopulationBar.AxisY.Add(new Axis
                {
                    Title = "Number of Inmates",
                    FontSize = 18,
                    MinValue = 0,
                    IsMerged = true,
                    Separator = new Separator
                    {
                        StrokeThickness = 1.5,
                        StrokeDashArray = new DoubleCollection(4)

                    }
                });

                Roll_Call.dataSet = GetRollCall(); 
                //dataSet = GetRollCall();
                IChartValues valuesInRollCall = new ChartValues<double>();
                IList<string> rollcallmonth = new List<string>(); 

                reports.cartesianChartrollcall.Series.Clear();
                reports.cartesianChartrollcall.AxisX.Clear();
                reports.cartesianChartrollcall.AxisY.Clear();

                foreach (DataRow data in Roll_Call.dataSet.Tables["result"].Rows)
                {
                    rollcallmonth.Add(data["month"].ToString());
                    valuesInRollCall.Add(Convert.ToDouble(data["total"]));
                }

                reports.cartesianChartrollcall.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Roll Call",
                        DataLabels = true,
                        Values = valuesInRollCall
                    }
                };

                reports.cartesianChartrollcall.AxisX.Add(new Axis
                {
                    Title = "AxisX",
                    Labels = rollcallmonth, 
                    IsMerged = true,
                    Separator = new Separator
                    {
                        StrokeThickness = 1,
                        StrokeDashArray = new DoubleCollection(2)
                    }
                });
                reports.cartesianChartrollcall.AxisY.Add(new Axis
                {
                    Title = "AxisY",
                    MinValue = 0,
                    IsMerged = true,
                    Separator = new Separator
                    {
                        StrokeThickness = 1.5,
                        StrokeDashArray = new DoubleCollection(4)

                    }
                });
            }
            else if (control is dashboardControl)
            {
                dashboardControl = (dashboardControl)control;
            }
        }

        public void Report(UserControl control)  
        {/*
            if (control is dashboardControl)
            {
                dashboardControl = (dashboardControl)control;
                DataSet dataSet = GetInmatesPopulation();

                IChartValues valuesPrison = new ChartValues<double>();
                IList<string> labelsPrison = new List<string>();

                dashboardControl.Population.Series.Clear();
                dashboardControl.Population.AxisX.Clear();
                dashboardControl.Population.AxisY.Clear();

                foreach (DataRow data in dataSet.Tables["result"].Rows)
                {
                    labelsPrison.Add(data["year"].ToString());
                    valuesPrison.Add(Convert.ToDouble(data["total"]));
                }

                dashboardControl.Population.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Inmates",
                        DataLabels = true,
                        Values = valuesPrison
                    }
                };

                dashboardControl.Population.AxisX.Add(new Axis
                {
                    Title = "Population of Inmates",
                    FontSize = 18,
                    FontWeight = new System.Windows.FontWeight(),
                    Labels = labelsPrison,
                    IsMerged = true,
                    Separator = new Separator { Step = 1 },
                    Foreground = Brushes.Black,
                });
                dashboardControl.Population.AxisY.Add(new Axis
                {
                    Title = "Number of Inmates",
                    FontSize = 18,
                    MinValue = 0,
                    IsMerged = true,
                    Foreground = Brushes.Black,
                });

                dataSet = GetDormsPopulation();
                Dormitory.dataSet = Dormitory.GetDormitories();

                IChartValues valuesDorms = new ChartValues<double>();
                IList<string> labelsDorms = new List<string>();

                foreach (DataRow data in Dormitory.dataSet.Tables["result"].Rows)
                {
                    labelsDorms.Add(ini.AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase));
                    dataSet = GetInmatesPopulation(Convert.ToInt32(data["id"]));
                    foreach (DataRow row in dataSet.Tables["result"].Rows)
                    {
                        valuesDorms.Add(Convert.ToDouble(row["total"]));
                        break;
                    }
                }

                dashboardControl.DormitoryPopulation.Series.Clear();
                dashboardControl.DormitoryPopulation.AxisX.Clear();
                dashboardControl.DormitoryPopulation.AxisY.Clear();

                dashboardControl.DormitoryPopulation.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Number of Inmates",
                        FontSize = 16,
                        Values = valuesDorms
                    }
                };

                //also adding values updates and animates the chart automatically
                //dashboardControl.DormitoryPopulation.Series[1].Values.Add(48d);

                dashboardControl.DormitoryPopulation.AxisX.Add(new Axis
                {
                    Title = "Dormitories",
                    Labels = labelsDorms,
                    ShowLabels= true,
                    Foreground = Brushes.Black,
                    FontSize = 16,
                    Separator = new Separator { Step = 1 },
                });

                dashboardControl.DormitoryPopulation.AxisY.Add(new Axis
                {
                    FontSize = 18,
                    Title = "Inmates",
                    MinValue = 0,
                    LabelFormatter = value => value.ToString("N")
                });
            }*/
        }

        public void DormitoryPopulation(UserControl control) 
        {
            if (control is dashboardControl)
            {/*
                dashboardControl = (dashboardControl)control;
                DataSet dataSet = GetDormsPopulation(); 
                Dormitory.dataSet = Dormitory.GetDormitories();

                IChartValues valuesDorms = new ChartValues<double>();
                IList<string> labelsDorms = new List<string>();

                foreach (DataRow data in Dormitory.dataSet.Tables["result"].Rows)
                {
                    labelsDorms.Add(ini.AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase));
                    dataSet = GetInmatesPopulation(Convert.ToInt32(data["id"]));
                    foreach (DataRow row in dataSet.Tables["result"].Rows)
                    {
                        valuesDorms.Add(Convert.ToDouble(row["total"]));
                        break;
                    }
                }

                dashboardControl.DormitoryPopulation.Series.Clear();
                dashboardControl.DormitoryPopulation.AxisX.Clear();
                dashboardControl.DormitoryPopulation.AxisY.Clear();

                dashboardControl.DormitoryPopulation.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Number of Inmates",
                        FontSize = 16,
                        Values = valuesDorms
                    }
                };

                //also adding values updates and animates the chart automatically
                //dashboardControl.DormitoryPopulation.Series[1].Values.Add(48d);

                dashboardControl.DormitoryPopulation.AxisX.Add(new Axis
                {
                    Title = "Dormitories",
                    Labels = labelsDorms,
                    ShowLabels = true,
                    Foreground = System.Windows.Media.Brushes.Black,
                    FontSize = 16,
                    Separator = new Separator { Step = 1 },
                });

                dashboardControl.DormitoryPopulation.AxisY.Add(new Axis
                {
                    FontSize = 18,
                    Title = "Inmates",
                    MinValue = 0,
                    LabelFormatter = value => value.ToString("N")
                });*/
            }
            else if (control is reports)
            {
                reports = (reports)control;
                DataSet dataSet = GetDormsPopulation();
                Dormitory.dataSet = Dormitory.GetDormitories();

                IChartValues valuesDorms = new ChartValues<double>();
                IList<string> labelsDorms = new List<string>();

                reports.DormitoryPopulationBar.Series.Clear();
                reports.DormitoryPopulationBar.AxisX.Clear();
                reports.DormitoryPopulationBar.AxisY.Clear();

                // Bar Graph
                reports.DormitoryPopulationBar.Series = new SeriesCollection();

                foreach (DataRow data in Dormitory.dataSet.Tables["result"].Rows)
                {
                    labelsDorms.Add(ini.AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase));
                    dataSet = GetInmatesPopulation(Convert.ToInt32(data["id"]));
                    foreach (DataRow row in dataSet.Tables["result"].Rows)
                    {
                        valuesDorms.Add(Convert.ToDouble(row["total"]));
                        
                        break;
                    }
                }

                reports.DormitoryPopulationBar.Series.Add(new ColumnSeries
                {
                    Title = "yyyy",
                    Values = valuesDorms
                });
                /*
                reports.DormitoryPopulationBar.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Number of Inmates",
                        FontSize = 16,
                        Values = valuesDorms
                    }
                };*/

                reports.DormitoryPopulationBar.AxisX.Add(new Axis
                {
                    Title = "Dormitories",
                    Labels = labelsDorms,
                    LabelsRotation = 70,
                    ShowLabels = true,
                    Foreground = Brushes.Black,
                    FontSize = 16,
                    Separator = new Separator { Step = 1 },
                });

                reports.DormitoryPopulationBar.AxisY.Add(new Axis
                {
                    FontSize = 18,
                    Title = "Inmates",
                    MinValue = 0,
                    LabelFormatter = value => value.ToString("N")
                });

                dataSet = GetDormitories("SELECT dormitory.`name`, COUNT(inmate.`id`) AS count FROM `dormitory`, `inmate` WHERE inmate.dormitory_id = dormitory.id GROUP BY dormitory.name ORDER BY dormitory.`id`");

                reports.DormitoryPopulationPie.Series.Clear();

                // Pie Chart
                // bind the chart to your dataset
                reports.DormitoryPopulationPie.Series = new SeriesCollection();
                reports.DormitoryPopulationPie.Text = "Number of Inmates In Dormitories";
                PieSeries myPieSeries;
                ChartValues<double> myChartValues;
                foreach (DataRow row in dataSet.Tables["result"].Rows)
                {
                    myPieSeries = new PieSeries();

                    myPieSeries.Foreground = System.Windows.Media.Brushes.Black;

                    myPieSeries.Title = ini.AES.Decrypt(row["name"].ToString(), Properties.Resources.PassPhrase);
                    reports.DormitoryPopulationPie.Series.Add(myPieSeries);

                    myChartValues = new ChartValues<double>
                    {
                        Convert.ToDouble(row["count"])
                    };

                    myPieSeries.Values = myChartValues;

                    // set the labels of the slices to the categories in the dataset
                    myPieSeries.LabelPoint = point => $"{point.Y} ({ini.AES.Decrypt(row["name"].ToString(), Properties.Resources.PassPhrase)})";

                    // define the location of the legend and set the data labels to display
                    reports.DormitoryPopulationPie.LegendLocation = LegendLocation.Right;
                    myPieSeries.DataLabels = true;
                }

                IChartValues valuesPrison = new ChartValues<double>();
                IList<string> labelsPrison = new List<string>();
                // Line Graph
                reports.DormitoryPopulationLine.Series.Clear(); 
                reports.DormitoryPopulationLine.AxisX.Clear();
                reports.DormitoryPopulationLine.AxisY.Clear();

                foreach (DataRow data in dataSet.Tables["result"].Rows)
                {
                    labelsPrison.Add(ini.AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase));
                    valuesPrison.Add(Convert.ToDouble(data["count"]));
                }

                reports.DormitoryPopulationLine.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Inmates",
                        DataLabels = true,
                        Values = valuesPrison
                    }
                };

                reports.DormitoryPopulationLine.AxisX.Add(new Axis
                {
                    Title = "Dormitories",
                    FontWeight = new System.Windows.FontWeight(),
                    Labels = labelsPrison,
                    IsMerged = true,
                    FontSize = 18,
                    Separator = new Separator { Step = 1 },
                    Foreground = Brushes.Black,
                });
                reports.DormitoryPopulationLine.AxisY.Add(new Axis
                {
                    Title = "Number of Inmates",
                    FontSize = 18,
                    MinValue = 0,
                    IsMerged = true,
                    Foreground = Brushes.Black,
                });
            }
        }

        public void PrisonPopulation(UserControl control)  
        {
            if (control is dashboardControl)
            {/*
                dashboardControl = (dashboardControl)control;
                DataSet dataSet = GetInmatesPopulation();

                IChartValues valuesPrison = new ChartValues<double>();
                IList<string> labelsPrison = new List<string>();

                dashboardControl.Population.Series.Clear();
                dashboardControl.Population.AxisX.Clear();
                dashboardControl.Population.AxisY.Clear();

                foreach (DataRow data in dataSet.Tables["result"].Rows)
                {
                    labelsPrison.Add(data["year"].ToString());
                    valuesPrison.Add(Convert.ToDouble(data["total"]));
                }

                dashboardControl.Population.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Inmates",
                        DataLabels = true,
                        Values = valuesPrison
                    }
                };

                dashboardControl.Population.AxisX.Add(new Axis
                {
                    Title = "Years",
                    FontSize = 18,
                    FontWeight = new System.Windows.FontWeight(),
                    Labels = labelsPrison,
                    ShowLabels = true,
                    IsMerged = true,
                    Separator = new Separator { Step = 1 },
                    Foreground = System.Windows.Media.Brushes.Black,
                });
                dashboardControl.Population.AxisY.Add(new Axis
                {
                    Title = "Number of Inmates",
                    FontSize = 18,
                    MinValue = 0,
                    IsMerged = true,
                    Foreground = Brushes.Black,
                });*/
            }
            else if (control is reports)
            {
                reports = (reports)control; 
                DataSet dataSet = GetInmatesPopulation();
                dataSet = GetInmatesPopulation();

                // Bar Graph
                reports.PopulationBar.Series.Clear();
                reports.PopulationBar.AxisX.Clear();
                reports.PopulationBar.AxisY.Clear();

                reports.PopulationBar.Series = new SeriesCollection();

                foreach (DataRow data in dataSet.Tables["result"].Rows)
                {
                    reports.PopulationBar.Series.Add(new ColumnSeries
                    {
                        Title = data["year"].ToString(),
                        Values = new ChartValues<double> { Convert.ToDouble(data["total"]) }
                    });
                }

                reports.PopulationBar.AxisX.Add(new Axis
                {
                    Title = "Inmates Population",
                    Labels = new[] { "Years" },
                    FontSize = 18,
                    Separator = new Separator { Step = 1 },
                    Foreground = System.Windows.Media.Brushes.Black,
                });

                reports.PopulationBar.AxisY.Add(new Axis
                {
                    Title = "Number of Inmates",
                    LabelFormatter = value => value.ToString("N"),
                    FontSize = 18,
                    Foreground = System.Windows.Media.Brushes.Black,
                });

                IChartValues valuesPrison = new ChartValues<double>();
                IList<string> labelsPrison = new List<string>();

                // Line Graph
                reports.PopulationLine.Series.Clear();
                reports.PopulationLine.AxisX.Clear();
                reports.PopulationLine.AxisY.Clear();

                foreach (DataRow data in dataSet.Tables["result"].Rows)
                {
                    labelsPrison.Add(data["year"].ToString());
                    valuesPrison.Add(Convert.ToDouble(data["total"]));
                }

                reports.PopulationLine.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Inmates",
                        DataLabels = true,
                        Values = valuesPrison
                    }
                };

                reports.PopulationLine.AxisX.Add(new Axis
                {
                    Title = "Years",
                    FontSize = 18,
                    FontWeight = new System.Windows.FontWeight(),
                    Labels = labelsPrison,
                    IsMerged = true,
                    Separator = new Separator { Step = 1 },
                    Foreground = System.Windows.Media.Brushes.Black,
                });
                reports.PopulationLine.AxisY.Add(new Axis
                {
                    Title = "Number of Inmates",
                    FontSize = 18,
                    MinValue = 0,
                    IsMerged = true,
                    Foreground = Brushes.Black,
                });
            }
        }

        public string DormitoryName(string cartesianName)  
        {
            switch(cartesianName)
            {
                case "CellBlock1Line": return "Cell Block 1";
                case "CellBlock2Line": return "Cell Block 2";
                case "CellBlock3Line": return "Cell Block 3";
                case "CellBlock4Line": return "Cell Block 4";
                case "CellBlock5Line": return "Cell Block 5";
                case "CellBlock6Line": return "Cell Block 6";
                case "CellBlock7Line": return "Cell Block 7";
                case "CellBlock8Line": return "Cell Block 8";
                case "CellBlock9Line": return "Cell Block 9";
                case "CellBlock10Line": return "Cell Block 10";
            }
            return null;
        }

        public void DormitoriesPopulation(CartesianChart cartesianChart)
        {
            DataSet dataSet = GetDormitoriesPopulation(DormitoryName(cartesianChart.Name)); 

            IChartValues valuesPrison = new ChartValues<double>();
            IList<string> labelsPrison = new List<string>();

            // Line Graph
            cartesianChart.Series.Clear();
            cartesianChart.AxisX.Clear();
            cartesianChart.AxisY.Clear();

            foreach (DataRow data in dataSet.Tables["result"].Rows)
            {
                labelsPrison.Add(data["year"].ToString());
                valuesPrison.Add(Convert.ToDouble(data["total"]));
            }

            cartesianChart.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Inmates",
                        DataLabels = true,
                        Values = valuesPrison
                    }
                };

            cartesianChart.AxisX.Add(new Axis
            {
                Title = "Years",
                FontSize = 18,
                FontWeight = new System.Windows.FontWeight(),
                Labels = labelsPrison,
                IsMerged = true,
                Separator = new Separator { Step = 1 },
                Foreground = Brushes.Black,
            });

            cartesianChart.AxisY.Add(new Axis
            {
                Title = "Number of Inmates",
                FontSize = 18,
                MinValue = 0,
                IsMerged = true,
                Foreground = Brushes.Black,
            });
        }

        public void CrimesCommitted(UserControl control) 
        {/*
            if (control is dashboardControl)
            {
                dashboardControl = (dashboardControl)control;
                DataSet dataSet = GetInmatesPopulation();

                IChartValues valuesPrison = new ChartValues<double>();
                IList<string> labelsPrison = new List<string>();

                dashboardControl.Population.Series.Clear();
                dashboardControl.Population.AxisX.Clear();
                dashboardControl.Population.AxisY.Clear();

                foreach (DataRow data in dataSet.Tables["result"].Rows)
                {
                    labelsPrison.Add(data["year"].ToString());
                    valuesPrison.Add(Convert.ToDouble(data["total"]));
                }

                dashboardControl.Population.Series = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "Inmates",
                        DataLabels = true,
                        Values = valuesPrison
                    }
                };

                dashboardControl.Population.AxisX.Add(new Axis
                {
                    Title = "Population of Inmates",
                    FontSize = 18,
                    FontWeight = new System.Windows.FontWeight(),
                    Labels = labelsPrison,
                    IsMerged = true,
                    Separator = new Separator { Step = 1 },
                    Foreground = System.Windows.Media.Brushes.Black,
                });
                dashboardControl.Population.AxisY.Add(new Axis
                {
                    Title = "Number of Inmates",
                    FontSize = 18,
                    MinValue = 0,
                    IsMerged = true,
                    Foreground = System.Windows.Media.Brushes.Black,
                });

                dataSet = GetDormsPopulation();
                Dormitory.dataSet = Dormitory.GetDormitories();

                IChartValues valuesDorms = new ChartValues<double>();
                IList<string> labelsDorms = new List<string>();

                foreach (DataRow data in Dormitory.dataSet.Tables["result"].Rows)
                {
                    labelsDorms.Add(ini.AES.Decrypt(data["name"].ToString(), Properties.Resources.PassPhrase));
                    dataSet = GetInmatesPopulation(Convert.ToInt32(data["id"]));
                    foreach (DataRow row in dataSet.Tables["result"].Rows)
                    {
                        valuesDorms.Add(Convert.ToDouble(row["total"]));
                        break;
                    }
                }

                dashboardControl.DormitoryPopulation.Series.Clear();
                dashboardControl.DormitoryPopulation.AxisX.Clear();
                dashboardControl.DormitoryPopulation.AxisY.Clear();

                dashboardControl.DormitoryPopulation.Series = new SeriesCollection
                {
                    new ColumnSeries
                    {
                        Title = "Number of Inmates",
                        FontSize = 16,
                        Values = valuesDorms
                    }
                };

                //also adding values updates and animates the chart automatically
                //dashboardControl.DormitoryPopulation.Series[1].Values.Add(48d);

                dashboardControl.DormitoryPopulation.AxisX.Add(new Axis
                {
                    Title = "Dormitories",
                    Labels = labelsDorms,
                    ShowLabels = true,
                    Foreground = System.Windows.Media.Brushes.Black,
                    FontSize = 16,
                    Separator = new Separator { Step = 1 },
                });

                dashboardControl.DormitoryPopulation.AxisY.Add(new Axis
                {
                    FontSize = 18,
                    Title = "Inmates",
                    MinValue = 0,
                    LabelFormatter = value => value.ToString("N")
                });
            }*/
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
        Roll_Call Roll_Call = new Roll_Call();
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
            string query = "SELECT dormitory_id, COUNT(*) AS total, YEAR(date_created) AS year, MONTH(date_created) AS month, DAY(date_created) AS day";
            query += " FROM `inmate`DormitoriesPopulation";
            query += " GROUP BY YEAR(date_created)";
            return Execute.ExecuteDataSet(query);
        }

        public DataSet GetDormitoriesPopulation(string name) 
        {
            string query = "SELECT dormitory.id, dormitory.name, COUNT(inmate.id) AS total, YEAR(inmate.date_created) AS year, MONTH(inmate.date_created) AS month, DAY(inmate.date_created) AS day";
            query += " FROM `inmate` INNER JOIN `dormitory` ON inmate.dormitory_id = dormitory.id";
            query += " WHERE dormitory.id = " + Dormitory.GetId(name);
            query += " GROUP BY YEAR(inmate.date_created)";
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
        public DataSet GetRollCall() 
        {
            string query = "SELECT COUNT(roll_calloninmate.id) AS total, YEAR(roll_call.date_created) AS year, MONTH(roll_call.date_created) AS month, DAY(roll_call.date_created) AS day";
            query += " FROM `roll_call`, `roll_calloninmate`";
            query += " WHERE roll_call.id = roll_calloninmate.roll_call_id";
            query += " GROUP BY MONTH(roll_call.date_created)";
            return Execute.ExecuteDataSet(query);
        }
    }
}
