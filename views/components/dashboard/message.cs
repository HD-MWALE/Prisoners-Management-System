using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Presentation;
using Org.BouncyCastle.Asn1.Cmp;
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

namespace Prisoners_Management_System.views.components.dashboard
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
        public int RollCall_Id = 0; 
        public int RollCallInmate_Id = 0;
        feedbacks feedbacks;
        private void message_Click(object sender, EventArgs e)
        {
            dashboard.Prison.Roll_Call.SaveFeedback(Id, RollCall_Id, RollCallInmate_Id);
            dashboard.lblModel.Text = "Roll Call";
            dashboard.lblAction.Text = "Feedback";
            dashboard.Clear();
            feedbacks = new components.feedbacks(dashboard);
            dashboard.pnlBody.Controls.Add(feedbacks);
            feedbacks.Dock = DockStyle.Fill;
            feedbacks.BringToFront();
        }

        private void message_MouseHover(object sender, EventArgs e)
        {
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 11.50F, System.Drawing.FontStyle.Bold);
            
            if (File.Exists(config.ColorScheme.Path)) 
                if (Convert.ToBoolean(File.ReadAllText(config.ColorScheme.Path)))
                {
                    this.BackColor = Color.FromArgb(26, 104, 255);
                    lblTitle.BackColor = Color.FromArgb(26, 104, 255);
                    lblTitle.ForeColor = Color.WhiteSmoke;
                    lblMessage.BackColor = Color.FromArgb(26, 104, 255);
                    lblMessage.ForeColor = Color.WhiteSmoke;
                    lblDate.BackColor = Color.FromArgb(26, 104, 255);
                    lblDate.ForeColor = Color.WhiteSmoke;
                    Icon.BackColor = Color.FromArgb(26, 104, 255);
                }
                else
                {
                    this.BackColor = Color.WhiteSmoke;
                    lblTitle.BackColor = Color.WhiteSmoke;
                    lblTitle.ForeColor = Color.FromArgb(26, 104, 255);
                    lblMessage.BackColor = Color.WhiteSmoke;
                    lblMessage.ForeColor = Color.FromArgb(26, 104, 255);
                    lblDate.BackColor = Color.WhiteSmoke;
                    lblDate.ForeColor = Color.FromArgb(26, 104, 255);
                    Icon.BackColor = Color.WhiteSmoke;
                }
        }

        private void message_MouseLeave(object sender, EventArgs e)
        {
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            
            if (File.Exists(config.ColorScheme.Path))
                if (Convert.ToBoolean(File.ReadAllText(config.ColorScheme.Path)))
                {
                    this.BackColor = Color.WhiteSmoke;
                    lblTitle.BackColor = Color.WhiteSmoke;
                    lblTitle.ForeColor = Color.FromArgb(42, 42, 49);
                    lblMessage.BackColor = Color.WhiteSmoke;
                    lblMessage.ForeColor = Color.FromArgb(42, 42, 49);
                    lblDate.BackColor = Color.WhiteSmoke;
                    lblDate.ForeColor = Color.FromArgb(42, 42, 49);
                    Icon.BackColor = Color.WhiteSmoke;
                }
                else
                {
                    this.BackColor = Color.FromArgb(42, 42, 49);
                    lblTitle.BackColor = Color.FromArgb(42, 42, 49);
                    lblTitle.ForeColor = Color.WhiteSmoke;
                    lblMessage.BackColor = Color.FromArgb(42, 42, 49);
                    lblMessage.ForeColor = Color.WhiteSmoke;
                    lblDate.BackColor = Color.FromArgb(42, 42, 49);
                    lblDate.ForeColor = Color.WhiteSmoke;
                    Icon.BackColor = Color.FromArgb(42, 42, 49);
                }
        }

        private void message_Load(object sender, EventArgs e)
        {

        }
    }
}
