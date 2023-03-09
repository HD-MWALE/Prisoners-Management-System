using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views.components.dashboard
{
    public partial class help : UserControl
    {
        views.dashboard dashboard;
        login login;
        public help(views.dashboard dashboard, login login) 
        {
            InitializeComponent();
            this.dashboard = dashboard;
            this.login = login;
        }
    }
}
