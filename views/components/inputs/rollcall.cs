 using Roll_Call_And_Management_System.classes;
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
        classes.Dormitory Dormitory = new classes.Dormitory();
        classes.Roll_Call Roll_Call = new classes.Roll_Call();
        private void rollcall_Load(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            Dormitory.dataSet = Dormitory.GetDormitories();
            if (Dormitory.dataSet != null)
            {
                this.dpnDormitory.Items.Clear();
                foreach (DataRow dataRow in Dormitory.dataSet.Tables["result"].Rows)
                    this.dpnDormitory.Items.Add(AES.Decrypt(Convert.ToString(dataRow["name"]), Properties.Resources.PassPhrase));
            }
        }
        public int DormitoryId = 0;
        private void dpnDormitory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Dormitory.dataSet != null)
                foreach (DataRow dataRow in Dormitory.dataSet.Tables["result"].Rows)
                    if (dpnDormitory.Text == AES.Decrypt(dataRow["name"].ToString(), Properties.Resources.PassPhrase))
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
            Config.ClickSound();
            Roll_Call = new Roll_Call("RC" + DormitoryId + "-" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), 1, DormitoryId);
            Roll_Call.dataSet = Roll_Call.Save();
            scan = new facial.scan(Roll_Call, this);
            modal.popup popup = new modal.popup(dashboard, scan);
            popup.Size = scan.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
        }
    }
}
