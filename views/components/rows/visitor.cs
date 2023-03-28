using Roll_Call_And_Management_System.classes;
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
    public partial class visitor : UserControl
    {
        views.dashboard dashboard;
        public visitor(views.dashboard dashboard, visitors visitors)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.visitors = visitors;
            Config.LoadTheme(this.Controls);
        }
        public int Id = 0;
        public int ButtonCount = 0;
        public Visitor Visitor = new Visitor();
        visitors visitors;
        modal.dialog dialog;
        view.viewvisitor viewvisitor;
        ColorScheme scheme = new ColorScheme();
        private void visitor_Load(object sender, EventArgs e)
        {

        }

        private void Yes_Click(object sender, EventArgs e)
        {
            Visitor.Delete(Id); 
            visitors.visitors_Load(sender, e);
            Config.Alert("Visitor Deleted Successfully.", views.components.dashboard.alert.enmType.Success);
        }

        private void btnEdit_Click(object sender, EventArgs e) 
        {
            Config.ClickSound();

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            dashboard.SetLoading(true);
            Config.ClickSound();
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
            dialog.Title = "Delete Visitor";
            dialog.Message.Text = "You are about to delete a visitor?";
            dialog.Icon.Image = Properties.Resources.important;
            dialog.PrimaryButton.Text = "Yes";
            dialog.SecondaryButton.Text = "No";
            dialog.PrimaryButton.Click += Yes_Click;
            modal.popup popup = new modal.popup(dialog);
            popup.Size = dialog.Size;
            popup.Location = Config.GetLocation(Config.AppSize, popup.Size, Config.AppLocation);
            popup.ShowDialog();
            dashboard.SetLoading(false);
        }
    }
}
