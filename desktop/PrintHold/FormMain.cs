using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintHold
{

    public partial class FormMain : Form
    {
        public PrintImpl printImpl = new PrintImpl();

        public FormMain() {
            InitializeComponent();
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
    }
}
