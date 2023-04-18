using Prisoners_Management_System.classes;
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
    public partial class visitor : UserControl
    {
        views.dashboard dashboard;
        public visitor(views.dashboard dashboard, visitors visitors)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.visitors = visitors;
            ColorScheme.LoadTheme(this.Controls);
        }
        public int Id = 0;
        public int ButtonCount = 0;
        visitors visitors;
        modal.dialog dialog;
        view.viewvisitor viewvisitor;
        private void visitor_Load(object sender, EventArgs e)
        {

        }

        private void Yes_Click(object sender, EventArgs e)
        {
            dashboard.Prison.Visitor.Delete(Id); 
            visitors.visitors_Load(sender, e);
            config.config.Alerts.Popup("Visitor Deleted Successfully.", views.components.dashboard.alert.enmType.Success);
        }

        private void btnEdit_Click(object sender, EventArgs e) 
        {
            Sound.Click();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Sound.Click();
            viewvisitor = new view.viewvisitor();
            viewvisitor.Id = Id;
            viewvisitor.lblFullname.Text = lblName.Text;
            viewvisitor.lblRelation.Text = lblRelation.Text;
            viewvisitor.lblAddress.Text = lblAddress.Text;
            viewvisitor.lblContact.Text = lblContact.Text;
            viewvisitor.lblVisited.Text = lblInmate.Text;
            viewvisitor.lblDate.Text = lblDate.Text;
            modal.popup popup = new modal.popup(viewvisitor);
            popup.Size = viewvisitor.Size;
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
            dialog.Title = "Delete Visitor";
            dialog.Message.Text = "You are about to delete a visitor?";
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
