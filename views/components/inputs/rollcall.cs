 using Roll_Call_And_Management_System.classes;
using Roll_Call_And_Management_System.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views.components.inputs
{
    public partial class rollcall : UserControl
    {
        public rollcall(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }
        views.dashboard dashboard;
        
        private void rollcall_Load(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            dashboard.Prison.Dormitory.dataSet = dashboard.Prison.Dormitory.GetDormitories();
            if (dashboard.Prison.Dormitory.dataSet != null)
            {
                this.dpnDormitory.Items.Clear();
                foreach (DataRow dataRow in dashboard.Prison.Dormitory.dataSet.Tables["result"].Rows)
                    this.dpnDormitory.Items.Add(ini.AES.Decrypt(Convert.ToString(dataRow["name"]), Properties.Resources.PassPhrase));
            }
        }
        public int DormitoryId = 0;
        private void dpnDormitory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dashboard.Prison.Dormitory.dataSet != null)
                foreach (DataRow dataRow in dashboard.Prison.Dormitory.dataSet.Tables["result"].Rows)
                    if (dpnDormitory.Text == ini.AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase))
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
            ini.Sound.ClickSound();
            dashboard.Prison.Roll_Call = new Roll_Call("RC" + DormitoryId + "-" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), 1, DormitoryId);
            dashboard.Prison.Roll_Call.dataSet = dashboard.Prison.Roll_Call.Save();
            scan = new facial.scan(dashboard, this);
            modal.popup popup = new modal.popup(scan);
            popup.Size = scan.Size;
            popup.Location = ini.Orientation.GetLocation(ini.AppSize, popup.Size, ini.AppLocation);
            popup.ShowDialog();
        }
    }
}
