using System;
using System.Threading;
using System.Windows.Forms;
using Prisoners_Management_System.classes;
using Prisoners_Management_System.views;

namespace Prisoners_Management_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // starting application
            Application.Run(new login(new User()));
        }
    }
}
