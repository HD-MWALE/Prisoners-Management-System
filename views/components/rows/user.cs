using DocumentFormat.OpenXml.Office2010.Excel;
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
    public partial class user : UserControl
    {
        public user(views.dashboard dashboard, users users)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.users = users;
            ColorScheme.LoadTheme(this.Controls);
        }

        views.dashboard dashboard;
        public int Id = 0;
        modal.dialog dialog;
        users users;
        view.user viewuser;
       
        private void Yes_Click(object sender, EventArgs e)
        {
            dashboard.Prison.User.Delete(Id);
            users.users_Load(sender, e);
            config.config.Alerts.Popup("User Deleted Successfully.", views.components.dashboard.alert.enmType.Success);
        }
        inputs.user edit;
        private void btnEdit_Click(object sender, EventArgs e) 
        {
            dashboard.SetLoading(true);
            Sound.Click();
            edit = new inputs.user(dashboard, users);
            edit.Id = Id;
            dashboard.PathSeparator.Visible = true;
            dashboard.lblAction.Visible = true;
            dashboard.lblAction.Text = "Edit";
            this.users.Controls.Add(edit);
            edit.Dock = DockStyle.Fill;
            edit.BringToFront();
            ColorScheme.LoadTheme(this.users.Controls);
            dashboard.SetLoading(false);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            viewuser = new view.user();
            viewuser.Id = Id;
            viewuser.lblUsername.Text = lblUsername.Text;
            viewuser.lblEmail.Text = lblEmail.Text;
            viewuser.lblFullname.Text = lblFullname.Text;
            viewuser.lblGender.Text = lblGender.Text;
            viewuser.lblDoB.Text = lblDoB.Text;
            viewuser.lblRole.Text = lblRole.Text;
            //viewuser.lblPrison.Text = lblPrison.Text;
            modal.popup popup = new modal.popup(viewuser);
            popup.Size = viewuser.Size;
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
            dialog.Title = "Delete User";
            dialog.Message.Text = "You are about to delete a user?";
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
