using DocumentFormat.OpenXml.Office2010.Excel;
using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
using Prisoners_Management_System.views.components.facial;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using UserControl = System.Windows.Forms.UserControl;

namespace Prisoners_Management_System.views.components.inputs
{
    public partial class pardonedlist : UserControl
    {
        public pardonedlist(views.dashboard dashboard, DataTable dsInmates)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.dsInmates = dsInmates;
        }
        views.dashboard dashboard;
        components.pardonedlist pardonedList;
        DataTable dsInmates;
        private void btnComeUpWithList_Click(object sender, EventArgs e)
        {
            Sound.Click();
            // calling function to filter datatable
            dsInmates = FilterData.InmatesTable(dsInmates);
            // calling function
            ComeUpWithList();
            btnView_Click(sender, e);
        }
        // loading inmates function with parameter page number
        private void ComeUpWithList()  
        {
            string fields = "`inmate_id`, `reason`";
            bool IsFirst = true;
            string data = "";
            if (dsInmates != null)
            {
                foreach (DataRow currentRow in dsInmates.Rows)
                {
                    if (IsFirst)
                    {
                        data = "(" + Convert.ToInt32(currentRow["id"]) + ",'" + txtReason.Text + "')";
                        IsFirst = false;
                    }
                    else
                    {
                        data += ",(" + Convert.ToInt32(currentRow["id"]) + ",'" + txtReason.Text + "')";
                    }
                }
                database.Execute.InsertMore("pardoned", fields, data);
                dsInmates = null;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            dashboard.bar.Top = (this.dashboard.btnReports).Top;
            dashboard.lblModel.Text = "Pardorned";
            dashboard.Path(true);
            dashboard.Clear();
            pardonedList = new components.pardonedlist(dashboard);
            dashboard.pnlBody.Controls.Add(pardonedList);
            pardonedList.Dock = DockStyle.Fill;
            pardonedList.BringToFront();

            // Setting theme (Dark/Light)
            ColorScheme.LoadTheme(this.dashboard.Controls);
            
        }
    }
}
