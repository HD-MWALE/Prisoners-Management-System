using Prisoners_Management_System.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Prisoners_Management_System.views.components.inputs.sub
{
    public partial class crime : UserControl
    {
        inmate inmate;
        public crime(inmate inmate)
        {
            InitializeComponent();
            this.inmate = inmate;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            inmate.Crimes.Remove(txtCrime.Text);
            inmate.pnlCrimeCommitted.Controls.Remove(this);
            foreach (DataRow dataRow in inmate.dsCrimes.Tables["result"].Rows)
                if ((string)dataRow["name"] == txtCrime.Text)
                    inmate.CrimeTypes.Remove((string)dataRow["type"]);
            inmate.Allocate();
        }

        private void crime_Load(object sender, EventArgs e)
        {
            ColorScheme.LoadTheme(this.inmate.Controls);

        }
    }
}
