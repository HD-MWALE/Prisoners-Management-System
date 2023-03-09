using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll_Call_And_Management_System
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
            try
            {
                thread = new Thread(Me);
                thread.Start();
            }
            catch (Exception ex)
            {

            }
            views.dashboard dashboard = new views.dashboard(thread, user);
            Application.Run(new views.login(dashboard, user));
        }
        static classes.User user = new classes.User();
        static Thread thread;
        static void Me()
        {
           
        }
    }
}
