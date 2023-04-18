using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prisoners_Management_System.views.components.dashboard;
using static Prisoners_Management_System.views.components.dashboard.alert;

namespace Prisoners_Management_System.config
{
    internal class Alerts
    {
        // function to open popup alert
        public void Popup(string msg, enmType type)
        {
            alert alert = new alert();
            alert.TopMost = true;
            alert.showAlert(msg, type);
        }
        // function to show server error in message box
        public void ServerMessage(string message)
        {
            MessageBox.Show("Server Error : " + message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
    }
}
