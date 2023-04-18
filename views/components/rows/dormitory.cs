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
    public partial class dormitory : UserControl
    {
        public dormitory(views.dashboard dashboard, dormitories dormitories)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.dormitories = dormitories;
            ColorScheme.LoadTheme(this.Controls);
        }
        public int Id = 0;
        public views.dashboard dashboard;
        dormitories dormitories;
        modal.dialog dialog;
        inputs.dormitory Dormitory;
        
        private void Yes_Click(object sender, EventArgs e)
        {
            dashboard.Prison.Dormitory.Delete(Id);
            dormitories.dormitories_Load(sender, e);
            config.config.Alerts.Popup("Dormitory Deleted Successfully.", views.components.dashboard.alert.enmType.Success);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            Dormitory = new inputs.dormitory(dashboard);
            Dormitory.Id = Id;
            Dormitory.txtName.Text = lblName.Text;
            Dormitory.txtDescription.Text = lblDescription.Text;
            Dormitory.dpnGenderType.Text = lblGenderType.Text;
            Dormitory.dpnType.Text = lblType.Text;
            modal.popup popup = new modal.popup(Dormitory);
            popup.Size = Dormitory.Size;
            popup.Location = config.config.Orientation.GetLocation(config.config.AppSize, popup.Size, config.config.AppLocation);
            popup.ShowDialog();
            dormitories.dormitories_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            dormitories._dormitory = new view.dormitory(this.dashboard, dormitories);
            dormitories._dormitory.Id = Id;
            dashboard.PathSeparator.Visible = true;
            dashboard.lblAction.Visible = true;
            dashboard.lblAction.Text = "View";
            this.dormitories.Controls.Add(dormitories._dormitory);
            dormitories._dormitory.Dock = DockStyle.Fill;
            dormitories._dormitory.AutoScroll = true;
            dormitories._dormitory.BringToFront();
            dashboard.SetLoading(false);
        }

        private void btnDelete_Click(object sender, EventArgs e) 
        {
            dashboard.SetLoading(true);
            Sound.Click();
            dialog = new modal.dialog();
            dialog.Id = Id;
            dialog.Title = "Delete Dormitory";
            dialog.Message.Text = "You are about to delete a dormitory?";
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
    }
}
