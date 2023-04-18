using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prisoners_Management_System.views.components.dashboard
{
    public partial class about : UserControl
    {
        views.dashboard dashboard;
        login login;
        public about(views.dashboard dashboard, login login)
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.login = login;
        }
    }
}
