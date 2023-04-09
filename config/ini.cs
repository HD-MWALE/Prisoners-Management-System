using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System.config
{
    internal class ini
    {
        public static string Path = Application.StartupPath; 
        public static string UserRole = Path + "\\auth\\role.txt";
        public static string Backup = Path + "\\backup\\backup.sql";
        public static Size AppSize;
        public static Point AppLocation;
        public static Size PopupSize;
        public static AES AES = new AES();
        public static Recognizer Recognizer = new Recognizer(); 
        public static Alerts Alerts = new Alerts(); 
        public static Calculate Calculate = new Calculate();
        public static ColorScheme ColorScheme = new ColorScheme(); 
        public static Generate Generate = new Generate();
        public static Internet Internet = new Internet();
        public static Orientation Orientation = new Orientation();
        public static Sound Sound = new Sound();
        public static Validate Validate = new Validate();
    }
}
