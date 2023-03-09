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
    public partial class dormitory : UserControl
    {
        public dormitory(views.dashboard dashboard, dormitories dormitories)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.dormitories = dormitories;
            Config.LoadTheme(this.Controls);
        }
        public int Id = 0;
        public views.dashboard dashboard;
        dormitories dormitories;
        modal.dialog dialog;
        inputs.dormitory Dormitory;
        classes.Dormitory _Dormitory = new classes.Dormitory();
        
        private void Yes_Click(object sender, EventArgs e)
        {
            _Dormitory.Delete(Id);
            dormitories.dormitories_Load(sender, e);
            Config.Alert("Dormitory Deleted Successfully.", views.components.dashboard.alert.enmType.Success);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Config.ClickSound();
            Dormitory = new inputs.dormitory();
            Dormitory.Id = Id;
            Dormitory.txtName.Text = lblName.Text;
            Dormitory.txtDescription.Text = lblDescription.Text;
            Dormitory.dpnGenderType.Text = lblGenderType.Text;
            Dormitory.dpnType.Text = lblType.Text;
            modal.popup popup = new modal.popup(dashboard, Dormitory);
            popup.Size = Dormitory.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            dormitories.dormitories_Load(sender, e);
            dashboard.SetLoading(false);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Config.ClickSound();
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
            Config.ClickSound();
            dialog = new modal.dialog();
            dialog.Id = Id;
            dialog.Title = "Delete Dormitory";
            dialog.Message.Text = "You are about to delete a dormitory?";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Text = "Yes";
            dialog.SecondaryButton.Text = "No";
            dialog.PrimaryButton.Click += Yes_Click;
            modal.popup popup = new modal.popup(dashboard, dialog);
            popup.Size = dialog.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }
    }
}
