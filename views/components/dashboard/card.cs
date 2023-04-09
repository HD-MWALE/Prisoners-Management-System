using Roll_Call_And_Management_System.config;
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
    public partial class card : UserControl
    {
        public card()
        {
            InitializeComponent();
            ini.ColorScheme.LoadTheme(this.Controls);
        }
    }
}
