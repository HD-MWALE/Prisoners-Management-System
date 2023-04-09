using System;
using System.Threading;
using System.Windows.Forms;
using Roll_Call_And_Management_System.classes;
using Roll_Call_And_Management_System.views;

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

            //Thread thread = new Thread(Dummy.RollCallOnInmate);
            //thread.Start();
            //Dummy.RollCall();
            //Dummy.Get();
            //Dummy.SetYear();
            //Dummy.Sentence(); 

            Application.Run(new login(new User()));
        }
    }
}
