using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prisoners_Management_System;
using Prisoners_Management_System.config;

namespace Prisoners_Management_System.views.components.inputs
{
    public partial class history : UserControl
    {
        public history(views.dashboard dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;
        }
        public views.dashboard dashboard;

        public int Id = 0;
        ErrorProvider erroractionProvider = new ErrorProvider();
        ErrorProvider errorremarksProvider = new ErrorProvider();
        ErrorProvider errorstatusProvider = new ErrorProvider();
        string actionError = "Please input Action e.g Sick";
        string remarksError = "Please input action remarks";
        string statusError = "Please select action status e.g ";
        private string Date;
        public string InmateId;

        private void history_Load(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                btnSave.Text = "Update";
                dashboard.Prison.Inmate_History.History = dashboard.Prison.Inmate_History.GetHistory(Id);
                if (dashboard.Prison.Inmate_History.History != null)
                {
                    Id = Convert.ToInt32(dashboard.Prison.Inmate_History.History[0]);
                    txtAction.Text = dashboard.Prison.Inmate_History.History[1].ToString();
                    //dpnStatus.Text = dashboard.Prison.Inmate_History.History[2].ToString();
                    Date = dashboard.Prison.Inmate_History.History[3].ToString();
                    txtRemarks.Text = dashboard.Prison.Inmate_History.History[4].ToString();
                    InmateId = dashboard.Prison.Inmate_History.History[5].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(config.config.Validate.IsText(txtAction.Text) && config.config.Validate.IsText(txtRemarks.Text))
            {
                dashboard.Prison.Inmate_History = new classes.Inmate_History(txtAction.Text, 0, DateTime.Now, txtRemarks.Text, Convert.ToInt32(InmateId));
                if (btnSave.Text != "Update")
                {
                    dashboard.Prison.Inmate_History.Save();
                }
                else
                {
                    dashboard.Prison.Inmate_History.Update(Id); 
                }
            }
        }

        private void txtAction_Validating(object sender, CancelEventArgs e)
        {
            if (!config.config.Validate.IsText(txtAction.Text))
            {
                erroractionProvider.SetError(txtAction, actionError);
                txtAction.BorderColorActive = Color.Firebrick;
            }
            else
            {
                erroractionProvider.Clear();
                txtAction.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }

        private void txtRemarks_Validating(object sender, CancelEventArgs e)
        {
            if (!config.config.Validate.IsNull(txtRemarks.Text))
            {
                errorremarksProvider.SetError(txtRemarks, remarksError);
                txtRemarks.BorderColorActive = Color.Firebrick;
            }
            else
            {
                errorremarksProvider.Clear();
                txtRemarks.BorderColorActive = Color.FromArgb(26, 104, 200);
            }
        }
    }
}
