using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KohaQuick
{
    public partial class FormMain : Form
    {
        public Settings settings;

        public PrintImpl printImpl;

        public FormMain() {
            InitializeComponent();
            settings = Settings.Load();
            printImpl = new PrintImpl(settings);
        }

        public void ShowMsg(string msg) {
            string stamp = DateTime.Now.ToString("HH:mm:ss");
            //Program.FormMain.ShowMsg($"{stamp} {msg}");
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
