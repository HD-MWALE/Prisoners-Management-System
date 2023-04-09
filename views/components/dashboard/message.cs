using DocumentFormat.OpenXml.Presentation;
using Roll_Call_And_Management_System.config;
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
        ColorScheme scheme = new ColorScheme();
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
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 11.50F, System.Drawing.FontStyle.Bold);
            
            if (File.Exists(scheme.Path)) 
                if (Convert.ToBoolean(File.ReadAllText(scheme.Path)))
                {
                    this.BackColor = Color.FromArgb(26, 104, 255);
                    lblTitle.BackColor = Color.FromArgb(26, 104, 255);
                    lblTitle.ForeColor = Color.WhiteSmoke;
                    lblMessage.BackColor = Color.FromArgb(26, 104, 255);
                    lblMessage.ForeColor = Color.WhiteSmoke;
                    Icon.BackColor = Color.FromArgb(26, 104, 255);
                }
                else
                {
                    this.BackColor = Color.WhiteSmoke;
                    lblTitle.BackColor = Color.WhiteSmoke;
                    lblTitle.ForeColor = Color.FromArgb(26, 104, 255);
                    lblMessage.BackColor = Color.WhiteSmoke;
                    lblMessage.ForeColor = Color.FromArgb(26, 104, 255);
                    Icon.BackColor = Color.WhiteSmoke;
                }
        }

        private void message_MouseLeave(object sender, EventArgs e)
        {
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            
            if (File.Exists(scheme.Path))
                if (Convert.ToBoolean(File.ReadAllText(scheme.Path)))
                {
                    this.BackColor = Color.WhiteSmoke;
                    lblTitle.BackColor = Color.WhiteSmoke;
                    lblTitle.ForeColor = Color.FromArgb(42, 42, 49);
                    lblMessage.BackColor = Color.WhiteSmoke;
                    lblMessage.ForeColor = Color.FromArgb(42, 42, 49);
                    Icon.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    this.BackColor = Color.FromArgb(42, 42, 49);
                    lblTitle.BackColor = Color.FromArgb(42, 42, 49);
                    lblTitle.ForeColor = Color.WhiteSmoke;
                    lblMessage.BackColor = Color.FromArgb(42, 42, 49);
                    lblMessage.ForeColor = Color.WhiteSmoke;
                    Icon.BackColor = Color.FromArgb(42, 42, 49);
                }
        }

        private void message_Load(object sender, EventArgs e)
        {

        }
    }
}
