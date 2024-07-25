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
        public Creds creds;
        public KohaSession session1;

        public PrintImpl printImpl;

        public FormMain() {
            InitializeComponent();
            settings = Settings.Load();
            creds = Creds.Load();
            printImpl = new PrintImpl(settings);
            this.Shown += FormMain_Shown;
            this.FormClosing += FormMain_FormClosing;
            // Subscribe to the KeyDown event of the TextBox
            textBoxItemBarcode.KeyDown += TextBoxItemBarcode_KeyDown;
        }

        private void FormMain_Shown(object sender, EventArgs e) {
            session1 = new KohaSession();
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
            Program.FormDebug.WindowState = FormWindowState.Minimized;
            Program.FormDebug.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
            session1.Close();
        }

        public void ShowMsg(string msg) {
            Program.FormDebug.AddDebugLine(msg);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            SettingsDlg dlg = new SettingsDlg();
            dlg.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void printSampleToolStripMenuItem_Click(object sender, EventArgs e) {
            printImpl.PrintSample();
        }

        // Event handler for KeyDown event of the TextBox
        private void TextBoxItemBarcode_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                // Enter key was pressed, trigger the button click event
                buttonTrapHold_Click(sender, e);
                // Optionally, suppress the default beep sound
                e.SuppressKeyPress = true;
            }
        }

        private void buttonTrapHold_Click(object sender, EventArgs e) {
            textBoxTrapMsg.Text = "";
            TrapHoldItemStatus status = TrapHoldItemStatus.Error;
            string barcode = textBoxItemBarcode.Text.Trim();
            textBoxItemBarcode.Text = string.Empty;
            if (barcode.Length == 0) {
                textBoxTrapMsg.Text = "You must enter a barcode";
            } else {
                textBoxTrapMsg.Text = $"Looking up {barcode}";
                string message;
                session1.TrapHold(barcode, out status, out message);
                textBoxTrapMsg.Text = status.ToString();
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e) {
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) {
            session1.Logout();
        }
    }
}
