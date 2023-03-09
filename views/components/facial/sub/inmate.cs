using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views.components.facial.sub
{
    public partial class inmate : UserControl
    {
        scan scan;
        public inmate(scan scan)
        {
            InitializeComponent();
            this.scan = scan;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Config.RemoveSound(); 
            this.Cancel.Visible = false;
            this.btnCheck.Visible = true;
            this.Icon.Image = Properties.Resources.human_head;
            scan.flowLayoutPanelRemaining.Controls.Add(this);
            scan.lblRemaining.Text = (Convert.ToInt32(scan.lblRemaining.Text) + 1).ToString();
            scan.lblScanned.Text = (Convert.ToInt32(scan.lblScanned.Text) - 1).ToString();
        }

        public void btnCheck_Click(object sender, EventArgs e)
        {
            Config.CaptureSound();
            this.Cancel.Visible = true;
            this.btnCheck.Visible = false;
            this.Icon.Image = Properties.Resources.facial_recognition1;
            scan.flowLayoutPanelScanned.Controls.Add(this);
            scan.lblRemaining.Text = (Convert.ToInt32(scan.lblRemaining.Text) - 1).ToString();
            scan.lblScanned.Text = (Convert.ToInt32(scan.lblScanned.Text) + 1).ToString();
        }
    }
}
