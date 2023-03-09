using Roll_Call_And_Management_System.views.components.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views.components.rows
{
    public partial class history : UserControl
    {
        views.dashboard dashboard;
        view.inmate inmate;
        modal.dialog dialog;
        inputs.history GetHistory;
        view.history ViewHistory;
        classes.Inmate_History History = new classes.Inmate_History();  
        public history(views.dashboard dashboard, view.inmate inmate)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.inmate = inmate;
        }

        public int Id = 0;

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Config.ClickSound();
            GetHistory = new inputs.history();
            GetHistory.Id = Id;
            modal.popup popup = new modal.popup(dashboard, GetHistory);
            popup.Size = GetHistory.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            inmate.inmate_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Config.ClickSound();
            ViewHistory = new view.history(dashboard, this);
            ViewHistory.Id = Id;
            ViewHistory.InmateId = inmate.Id;
            modal.popup popup = new modal.popup(dashboard, ViewHistory);
            popup.Size = ViewHistory.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Config.ClickSound();
            dialog = new modal.dialog();
            dialog.Id = Id;
            dialog.Title = "Delete Inmate History";
            dialog.Message.Text = "You are about to delete a inmate history?";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Text = "Yes";
            dialog.SecondaryButton.Text = "No";
            dialog.PrimaryButton.Click += Yes_Click;
            modal.popup popup = new modal.popup(dashboard, dialog);
            popup.Size = dialog.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            inmate.inmate_Load(sender, e);
            dashboard.SetLoading(false);
        }
        private void Yes_Click(object sender, EventArgs e)
        {
            History.Delete(Id);
            inmate.inmate_Load(sender, e);
            Config.Alert("Inmate History Deleted Successfully.", views.components.dashboard.alert.enmType.Success);
        }
    }
}
