using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace PrintHold
{

    public partial class FormMain : Form
    {
        public PrintImpl printImpl = new PrintImpl();

        public FormMain() {
            InitializeComponent();
            this.Load += FormMain_Load;
        }

        // Event handler for Form.Load
        private void FormMain_Load(object sender, EventArgs e) {
            // Place your code here that you want to run after the GUI is fully initialized
            ShowMsg("GUI is fully initialized and ready.");
            Listener listener = new PrintHold.Listener();
            Thread clientThread = new Thread(new ThreadStart(listener.StartListening));
            clientThread.IsBackground = true;
            clientThread.Start();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e) {
            printImpl.Print();
        }

        public void ShowMsg(string msg) {
            textBoxMsgs.Text += msg + "\r\n";
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            SettingsDlg dlg = new SettingsDlg();
            dlg.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
