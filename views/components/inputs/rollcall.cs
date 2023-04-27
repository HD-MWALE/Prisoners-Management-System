 using Prisoners_Management_System.classes;
using Prisoners_Management_System.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisoners_Management_System.views.components.inputs
{
    public partial class rollcall : UserControl
    {
        public rollcall(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }
        views.dashboard dashboard;
        DataSet dsDormitories = new DataSet();
        public DataSet dsRoll_Call = new DataSet();


        private void rollcall_Load(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            dsDormitories = dashboard.Prison.Dormitory.GetDormitories();
            if (dsDormitories != null)
            {
                this.dpnDormitory.Items.Clear();
                foreach (DataRow dataRow in dsDormitories.Tables["result"].Rows)
                    this.dpnDormitory.Items.Add(Convert.ToString(dataRow["name"]));
            }
        }
        public int DormitoryId = 0;
        private void dpnDormitory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dsDormitories != null)
                foreach (DataRow dataRow in dsDormitories.Tables["result"].Rows)
                    if (dpnDormitory.Text == dataRow["name"].ToString())
                    {
                        DormitoryId = Convert.ToInt32(dataRow["id"].ToString());
                        break;
                    }
            if(DormitoryId != 0)
            {
                btnStart.Enabled = true;
            }
        }
        facial.scan scan;
        private void btnStart_Click(object sender, EventArgs e)
        {
            Sound.Click();
            dashboard.Prison.Roll_Call = new Roll_Call("RC" + DormitoryId + "-" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), 1, DormitoryId);
            dsRoll_Call = dashboard.Prison.Roll_Call.Save();
            scan = new facial.scan(dashboard, this);
            modal.popup popup = new modal.popup(scan);
            popup.Size = scan.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
        }
    }
}
