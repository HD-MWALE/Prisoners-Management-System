using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views.components.dashboard
{
    public partial class message : UserControl
    {
        views.dashboard dashboard;
        inmates inmates;
        public message(views.dashboard dashboard, inmates inmates)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.inmates = inmates;
        }

        public int Id = 0;

        private void message_Click(object sender, EventArgs e)
        {
            dashboard.Notification(sender, Id);
        }

        private void message_MouseHover(object sender, EventArgs e)
        {
            if (File.Exists(Config.theme))
                if (Convert.ToBoolean(File.ReadAllText(Config.theme)))
                {
                    this.BackColor = Color.FromArgb(42, 42, 49);
                    lblMessage.BackColor = Color.FromArgb(42, 42, 49);
                    lblMessage.ForeColor = Color.WhiteSmoke;
                    Icon.BackColor = Color.FromArgb(42, 42, 49);
                }
                else
                {
                    this.BackColor = Color.WhiteSmoke;
                    lblMessage.BackColor = Color.WhiteSmoke;
                    lblMessage.ForeColor = Color.FromArgb(42, 42, 49);
                    Icon.BackColor = Color.WhiteSmoke;
                }
        }

        private void message_MouseLeave(object sender, EventArgs e)
        {
            if (File.Exists(Config.theme))
                if (Convert.ToBoolean(File.ReadAllText(Config.theme)))
                {
                    this.BackColor = Color.WhiteSmoke;
                    lblMessage.BackColor = Color.WhiteSmoke;
                    lblMessage.ForeColor = Color.FromArgb(42, 42, 49);
                    Icon.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    this.BackColor = Color.FromArgb(42, 42, 49);
                    lblMessage.BackColor = Color.FromArgb(42, 42, 49);
                    lblMessage.ForeColor = Color.WhiteSmoke;
                    Icon.BackColor = Color.FromArgb(42, 42, 49);
                }
        }
    }
}
