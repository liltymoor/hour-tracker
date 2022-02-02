using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace HourCounter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*             formLoad = new Loading();
            formLoad.Owner = this;
            formLoad.Show();*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HourCounter main = new HourCounter();
            Loading loader = new Loading();
            //loader.Owner = main;
            Application.Run(main);
            //Application.Run(loader);
        }
    }
}
