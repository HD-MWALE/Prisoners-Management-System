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
    public partial class card : UserControl
    {
        public card()
        {
            InitializeComponent();
            config.ColorScheme.LoadTheme(this.Controls);
        }
    }
}
