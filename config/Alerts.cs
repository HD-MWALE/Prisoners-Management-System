using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roll_Call_And_Management_System.views.components.dashboard;
using static Roll_Call_And_Management_System.views.components.dashboard.alert;

namespace Roll_Call_And_Management_System.config
{
    internal class Alerts
    {
        public void Popup(string msg, enmType type)
        {
            alert alert = new alert();
            alert.TopMost = true;
            alert.showAlert(msg, type);
        }

        public void ServerMessage(string message)
        {
            MessageBox.Show("Server Error : " + message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
    }
}
