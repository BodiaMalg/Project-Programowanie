using System;
using System.Windows.Forms;

namespace Snake
{       /// <summary>
        /// The main entry point for the application.
        /// </summary>
       
    static class Program
    {
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartMenu());
        }
    }
}
