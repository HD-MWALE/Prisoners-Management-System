using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views.components.view
{
    public partial class history : UserControl
    {
        views.dashboard dashboard;
        rows.history rowhistory;
        classes.Inmate_History History = new classes.Inmate_History();
        classes.Inmate Inmate = new classes.Inmate();
        public history(views.dashboard dashboard, rows.history rowhistory)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.rowhistory = rowhistory;
        }

        public int Id = 0;
        public int InmateId = 0; 

        private void history_Load(object sender, EventArgs e)
        {
            if (Id != 0)
            {
                History.History = History.GetHistory(Id);
                if (History.History != null)
                {
                    Id = Convert.ToInt32(History.History[0]);
                    lblAction.Text = AES.Decrypt(History.History[1].ToString(), Properties.Resources.PassPhrase);
                    lblStatus.Text = History.History[2].ToString();
                    lblDate.Text = History.History[3].ToString();
                    lblRemarks.Text = AES.Decrypt(History.History[4].ToString(), Properties.Resources.PassPhrase);
                    Inmate.arrayList = Inmate.GetInmate(Convert.ToInt32(History.History[5]));
                    lblInmate.Text = AES.Decrypt(Inmate.arrayList[0].ToString(), Properties.Resources.PassPhrase) + " - " + AES.Decrypt(Inmate.arrayList[1].ToString(), Properties.Resources.PassPhrase) + ", " + AES.Decrypt(Inmate.arrayList[2].ToString(), Properties.Resources.PassPhrase) + " " + AES.Decrypt(Inmate.arrayList[3].ToString(), Properties.Resources.PassPhrase); History.History[5].ToString();
                }
            }
        }
    }
}
