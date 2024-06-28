using System;
using System.Windows.Forms;

namespace PrintHold
{
    public static class Program
    {
        static FormMain formMain;

        public static FormMain FormMain {
            get { return formMain; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formMain = new FormMain();
            Application.Run(formMain);
        }
    }
}
