using Prisoners_Management_System.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisoners_Management_System.views.components.rows
{
    public partial class crime : UserControl
    {
        public crime(views.dashboard dashboard, crimes crimes)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.crimes = crimes;
            ColorScheme.LoadTheme(this.Controls);
        }
        public int Id = 0;
        views.dashboard dashboard;
        modal.dialog dialog;
        crimes crimes;
        inputs.crime Crime;
        view.viewcrime viewCrime = new view.viewcrime();
       
        private void crime_Load(object sender, EventArgs e)
        {
            Crime = new inputs.crime(dashboard);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            viewCrime = new view.viewcrime();
            viewCrime.Id = Id;
            viewCrime.lblName.Text = lblName.Text;
            viewCrime.lblType.Text = lblType.Text;
            viewCrime.txtDescription.Text = lblDescription.Text;
            modal.popup popup = new modal.popup(viewCrime);
            popup.Size = viewCrime.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            dialog = new modal.dialog();
            dialog.Id = Id;
            dialog.Title = "Delete Crime";
            dialog.Message.Text = "You are about to delete a crime?";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Text = "Yes";
            dialog.SecondaryButton.Text = "No";
            dialog.PrimaryButton.Click += Yes_Click;
            modal.popup popup = new modal.popup(dialog);
            popup.Size = dialog.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }
        private void Yes_Click(object sender, EventArgs e)
        {
            dashboard.Prison.Crime.Delete(Id);
            crimes.crimes_Load(sender, e);
            config.config.Alerts.Popup("Crime Deleted Successfully.", views.components.dashboard.alert.enmType.Success);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            Crime = new inputs.crime(dashboard);
            Crime.Id = Id;
            Crime.txtName.Text = lblName.Text;
            Crime.dpnType.Text = lblType.Text;
            Crime.txtDescription.Text = lblDescription.Text;
            modal.popup popup = new modal.popup(Crime);
            popup.Size = Crime.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            crimes.crimes_Load(sender, e);
            dashboard.SetLoading(false);
        }
    }
}
