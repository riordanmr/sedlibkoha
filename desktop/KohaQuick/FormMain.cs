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
        public KohaSession session1, session2;

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

        private void ShowLoginDialog() {
            FormLogin formLogin = new FormLogin();
            formLogin.Load += (s, e) => formLogin.Activate(); // Ensure the dialog is activated when loaded
            formLogin.ShowDialog();
        }

        private void FormMain_Shown(object sender, EventArgs e) {
            session1 = new KohaSession(1);
            session2 = new KohaSession(2);
            Program.FormDebug.WindowState = FormWindowState.Minimized;
            Program.FormDebug.Show();
            ShowLoginDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
            session1.Close();
            session2.Close();
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
            textBoxBarcodeMsg.Text = $"Barcode scanned: {barcode}";
            textBoxItemBarcode.Text = string.Empty;
            if (barcode.Length == 0) {
                textBoxTrapMsg.Text = "You must enter a barcode";
            } else {
                textBoxTrapMsg.Text = $"Looking up {barcode}";
                string message;
                HoldSlip holdSlip = new HoldSlip();
                session1.TrapHold(barcode, ref holdSlip, out status, out message);
                textBoxTrapMsg.Text = status.ToString();

                if (status == TrapHoldItemStatus.HoldFoundLocal) {
                    textBoxTrapMsg.Text = "Local hold found; gathering info for hold slip";
                    holdSlip.Barcode = barcode;
                    if (session2.GetInfoOnTrappedItem(barcode, ref holdSlip)) {
                        textBoxTrapMsg.Text = "Printing hold slip";
                        printImpl.holdSlip = holdSlip;
                        printImpl.PrintSlip();
                    } else {
                        textBoxTrapMsg.Text = "Error getting hold slip info";
                    }
                } else if (status == TrapHoldItemStatus.HoldFoundTransfer) {
                    string msg = $"Transfer to {holdSlip.Library}";
                    if(holdSlip.Library == "SPL in the Village") {
                        msg += " (DOWNWIND)";
                    } else {
                        msg += " (TRANSFER)";
                    }
                    textBoxTrapMsg.Text = msg;
                }
            }
        }

        public void OnPrintJobComplete() {
            textBoxTrapMsg.Text = "Hold slip printed.";
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowLoginDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) {
            session1.Logout();
            session2.Logout();
        }
    }
}
