using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.views.components.modal
{
    public partial class dialog : UserControl
    {
        public dialog()
        {
            InitializeComponent();
        }
        public int Id = 0;
        public string Title = ""; 
        private void SecondaryButton_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
        }

        private void PrimaryButton_Click(object sender, EventArgs e)
        {
            Config.ClickSound();
        }
    }
}
