using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KohaQuick
{
    public class ProgramArgs {
        public string profile = "";
    };

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

        public static ProgramArgs programArgs;

        static ProgramArgs ParseCmdLine() {
            ProgramArgs programArgs = new ProgramArgs();

            bool bFirst = true;
            foreach (string arg in Environment.GetCommandLineArgs()) {
                if (bFirst) {
                    bFirst = false;
                    continue;
                }
                if (arg.StartsWith("--profile=")) {
                    programArgs.profile = arg.Substring("--profile=".Length);
                } else {
                    MessageBox.Show($"Unrecognized argument: {arg}", "Command line error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            return programArgs;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formDebug = new FormDebug();
            programArgs = ParseCmdLine();
            formMain = new FormMain();
            Application.Run(formMain);
        }
    }
}
