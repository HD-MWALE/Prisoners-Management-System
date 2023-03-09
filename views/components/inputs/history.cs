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
using Roll_Call_And_Management_System;

namespace Roll_Call_And_Management_System.views.components.inputs
{
    public partial class history : UserControl
    {
        public history()
        {
            InitializeComponent();
        }

        public int Id = 0;
        classes.Inmate_History History = new classes.Inmate_History();
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
                History.History = History.GetHistory(Id);
                if (History.History != null)
                {
                    Id = Convert.ToInt32(History.History[0]);
                    txtAction.Text = History.History[1].ToString();
                    dpnStatus.Text = History.History[2].ToString();
                    Date = History.History[3].ToString();
                    txtRemarks.Text = History.History[4].ToString();
                    InmateId = History.History[5].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Validate.IsText(txtAction.Text) && Validate.IsText(txtRemarks.Text))
            {
                History = new classes.Inmate_History(txtAction.Text, 0, DateTime.Now, txtRemarks.Text, Convert.ToInt32(InmateId));
                if (btnSave.Text != "Update")
                {
                    History.Save();
                }
                else
                {
                    History.Update(Id); 
                }
            }
        }
        new Validate Validate = new Validate();
        private void txtAction_Validating(object sender, CancelEventArgs e)
        {
            if (!Validate.IsText(txtAction.Text))
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
            if (!Validate.IsNull(txtRemarks.Text))
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

        private void dpnStatus_Validating(object sender, CancelEventArgs e)
        {
            if (dpnStatus.Text == "Select")
            {
                errorstatusProvider.SetError(dpnStatus, statusError);
                dpnStatus.IndicatorColor = Color.Firebrick;
            }
            else
            {
                errorstatusProvider.Clear();
                dpnStatus.IndicatorColor = Color.FromArgb(26, 104, 255);
            }
        }
    }
}
