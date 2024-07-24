using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KohaQuick
{
    internal static class Program
    {
        static FormMain formMain;

        public static FormMain FormMain
        {
            get { return formMain; }
        }

        static FormDebug formDebug;
        public static FormDebug FormDebug
        {
            get { return formDebug; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formDebug = new FormDebug();
            formMain = new FormMain();
            Application.Run(formMain);
        }
    }
}
