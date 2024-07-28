using System;
using System.Windows.Forms;

namespace KohaQuick
{
    public partial class FormMain : Form
    {
        public Settings settings;
        public Creds creds;
        public KohaSession session1, session2;
        public bool InitialLogin { get; set; } = true;

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
            this.Activated += FormMain_Activated;
        }

        private void ShowLoginDialog() {
            FormLogin formLogin = new FormLogin();
            formLogin.Load += (s, e) => formLogin.Activate(); // Ensure the dialog is activated when loaded
            formLogin.FormClosed += LoginForm_FormClosed;
            formLogin.ShowDialog();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e) {
            // Bring focus back to FormMain when FormLogin closes
            this.Activate();
            this.BringToFront();
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

        private void FormMain_Activated(object sender, EventArgs e) {
            ShowMsg($"FormMain_Activated here. tabControlHolds.SelectedTab.Name={tabControlHolds.SelectedTab.Name}");
            // Check if tabControlHolds is the active tab
            if (tabControlHolds.SelectedTab != null && tabControlHolds.SelectedTab.Name == "tabPageTrapHolds") {
                // Set focus to textBoxItemBarcode
                this.BeginInvoke((Action)(() => {
                    textBoxItemBarcode.Focus();
                }));
            }
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
            textBoxTitleMsg.Text = string.Empty;
            if (barcode.Length == 0) {
                textBoxTrapMsg.Text = "You must enter a barcode";
            } else {
                textBoxTrapMsg.Text = $"Looking up {barcode}";
                string message = String.Empty;
                HoldSlip holdSlip = new HoldSlip();
                session1.TrapHold(barcode, ref holdSlip, out status, out message);
                textBoxTrapMsg.Text = status.ToString();

                if (status == TrapHoldItemStatus.HoldFoundLocal) {
                    textBoxTitleMsg.Text = holdSlip.Title;
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
                    textBoxTitleMsg.Text = holdSlip.Title;
                    string msg = $"Transfer to {holdSlip.Library}";
                    if (holdSlip.Library == "SPL in the Village") {
                        msg += " (DOWNWIND)";
                    } else {
                        msg += " (TRANSFER)";
                    }
                    textBoxTrapMsg.Text = msg;
                } else if (status == TrapHoldItemStatus.NoSuchItem) {
                    textBoxTrapMsg.Text = "No such item found.";
                } else if (status == TrapHoldItemStatus.NoHold) {
                    textBoxTitleMsg.Text = message;
                    textBoxTrapMsg.Text = "No holds found for " + message;
                } else {
                    textBoxTrapMsg.Text = "Error. See debug log or Chrome windows for more info.";
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
