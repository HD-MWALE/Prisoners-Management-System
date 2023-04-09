using Roll_Call_And_Management_System.config;
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

namespace Roll_Call_And_Management_System.views.components.inputs.sub
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
            foreach (DataRow dataRow in inmate.inmates.dashboard.Prison.Crime.dataSet.Tables["result"].Rows)
                if (ini.AES.Decrypt((string)dataRow["name"], Properties.Resources.PassPhrase) == txtCrime.Text)
                    inmate.CrimeTypes.Remove((string)dataRow["type"]);
            inmate.Allocate();
        }

        private void crime_Load(object sender, EventArgs e)
        {
            ini.ColorScheme.LoadTheme(this.inmate.Controls);

        }
    }
}
