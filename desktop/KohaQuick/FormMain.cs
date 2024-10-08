﻿using System;
using System.Linq;
using System.Windows.Forms;

namespace KohaQuick {
    public partial class FormMain : Form {
        public Settings settings;
        public Creds creds;
        public KohaSession session1, session2, sessionPIN;
        public bool InitialLogin { get; set; } = true;
        private readonly Random random = new Random();

        public PrintImpl printImpl;
        public KohaRESTAPI kohaRESTAPI;

        public FormMain() {
            InitializeComponent();
            settings = Settings.Load();
            creds = Creds.Load();
            printImpl = new PrintImpl(settings);
            this.Shown += FormMain_Shown;
            this.FormClosing += FormMain_FormClosing;
            // Subscribe to the KeyDown event of the TextBox
            textBoxItemBarcode.KeyDown += TextBoxItemBarcode_KeyDown;
            textBoxPatronBarcodeForReceipt.KeyDown += TextBoxPatronBarcodeForReceipt_KeyDown;
            textBoxPlaceHoldItemSearch.KeyDown += TextBoxPlaceHoldSearch_KeyDown;
            this.Activated += FormMain_Activated;
            this.Load += new EventHandler(FormMain_Load);
            this.tabControlHolds.SelectedIndexChanged += new System.EventHandler(this.tabControlHolds_SelectedIndexChanged);
        }

        private void FormMain_Load(object sender, EventArgs e) {
            // Code to execute when the form is loading
            PopulateLibraryComboBox();
            comboBoxMainContactMethod.SelectedIndex = 0;
        }

        private void PopulateLibraryComboBox() {
            // Assuming settings.LocalLibraries is a comma-separated string of library names
            string localLibraries = settings.LocalLibraries;
            if (!string.IsNullOrEmpty(localLibraries)) {
                string[] libraries = localLibraries.Split(',');
                comboBoxLibraryForAddPatron.Items.AddRange(libraries);
            }
            // Select the first entry in the ComboBox
            if (comboBoxLibraryForAddPatron.Items.Count > 0) {
                comboBoxLibraryForAddPatron.SelectedIndex = 0;
            }
        }

        private void tabControlHolds_SelectedIndexChanged(object sender, EventArgs e) {
            // Check if the selected tab is the one containing textBoxFirstName
            if (tabControlHolds.SelectedTab == tabPageAddPatron) {
                textBoxFirstName.Focus();
            }
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
            ShowMsg($"Running with config file {Settings.ComputeSettingsFilename()}.");
            Program.FormDebug.WindowState = FormWindowState.Minimized;
            Program.FormDebug.Show();
            if (settings.CleanupSeleniumProcessesAtStartup) {
                Util.CleanUpSeleniumChromeProcesses();
            }
            session1 = new KohaSession(1);
            ShowLoginDialog();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
            session1.Close();
            if (null != session2) {
                session2.Close();
            }
            if (null != sessionPIN) {
                sessionPIN.Close();
            }
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
            printImpl.PrintHoldSample();
        }

        private void printSampleCheckoutSlipToolStripMenuItem_Click(object sender, EventArgs e) {
            printImpl.PrintCheckoutSlipSample();
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

        private void TextBoxPatronBarcodeForReceipt_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                // Enter key was pressed, trigger the button click event
                buttonPrintItemsCheckedOut_Click(sender, e);
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
            do {
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
                        if (null == session2) {
                            session2 = new KohaSession(2);
                            string errmsg = "";
                            if (!Program.FormMain.session2.LoginStaff(Program.FormMain.settings.KohaUrlStaff,
                                Program.FormMain.creds.KohaUsername,
                                Program.FormMain.creds.KohaPassword, out errmsg)) {
                                textBoxTrapMsg.Text = "Error logging in to staff session 2";
                                break;
                            }
                        }
                        if (session2.GetInfoOnTrappedItem(barcode, ref holdSlip)) {
                            textBoxTrapMsg.Text = "Printing hold slip";
                            printImpl.holdSlip = holdSlip;
                            printImpl.PrintHoldSlip();
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
            } while (false);
        }

        public void OnHoldSlipPrintJobComplete() {
            textBoxTrapMsg.Text = "Hold slip printed.";
        }

        public void OnCheckoutSlipPrintJobComplete() {
            textBoxPrintCheckoutMsg.Text = "Checkout slip printed.";
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e) {
            ShowLoginDialog();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void comboBoxState_SelectedIndexChanged(object sender, EventArgs e) {

        }

        public string GetRandomString(int length) {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string GetRandomDigits(int length) {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void buttonGenerateRandom_Click(object sender, EventArgs e) {
            this.textBoxAddPatronMsg.Text = ""; 
            string PIN = GetRandomDigits(4);
            this.textBoxFirstName.Text = $"Xerxes";
            this.textBoxLastName.Text = $"Smith{GetRandomString(3)}";
            this.textBoxDateOfBirth.Text = $"07/21/2000";
            this.textBoxEmail.Text = $"xerxes.smith{GetRandomString(5)}@gmail.com";
            this.textBoxPhone.Text = $"555-555-{GetRandomDigits(4)}";
            this.textBoxAddress1.Text = $"{PIN} Main St";
            this.textBoxAddress2.Text = $"Apt {GetRandomString(3)}";
            this.textBoxCity.Text = $"Springfield";
            this.comboBoxState.Text = $"IL";
            this.textBoxZipcode.Text = $"{GetRandomDigits(5)}";
            this.textBoxLibraryCardBarcode.Text = $"432{GetRandomDigits(11)}";
            this.textBoxPIN.Text = PIN;
            this.textBoxPIN2.Text = this.textBoxPIN.Text;
            this.textBoxCircNotes.Text = $"Random patron generated on {DateTime.Now}";
        }

        private void buttonAddPatron_Click(object sender, EventArgs e) {
            textBoxAddPatronMsg.Text = "";
            Patron patron = new Patron();
            patron.firstname = this.textBoxFirstName.Text;
            patron.middlename = this.textBoxMiddleName.Text;
            patron.surname = this.textBoxLastName.Text;
            patron.email = this.textBoxEmail.Text;
            patron.phone = this.textBoxPhone.Text;
            patron.main_contact_method = this.comboBoxMainContactMethod.Text;
            patron.address = this.textBoxAddress1.Text;
            patron.address2 = this.textBoxAddress2.Text;
            patron.city = this.textBoxCity.Text;
            patron.state = this.comboBoxState.Text;
            patron.postal_code = this.textBoxZipcode.Text;
            patron.country = "US";
            patron.userid = this.textBoxLibraryCardBarcode.Text;
            patron.cardnumber = this.textBoxLibraryCardBarcode.Text;
            patron.date_of_birth = this.textBoxDateOfBirth.Text;
            patron.password = this.textBoxPIN.Text;
            patron.category_id = settings.DefaultPatronCategory;
            patron.circ_notes = this.textBoxCircNotes.Text;
            patron.main_library = this.comboBoxLibraryForAddPatron.Text;

            // Check if any property of patron is an empty string
            bool hasEmptyRequiredProperty = patron.GetType().GetProperties()
                .Any(prop => prop.GetValue(patron)?.ToString() == string.Empty &&
                    prop.Name != "middlename" && prop.Name != "address2");
            if(hasEmptyRequiredProperty) {
                textBoxAddPatronMsg.Text = "Please fill in all required fields.";
                return;
            }

            if (textBoxPIN.Text != textBoxPIN2.Text) {
                MessageBox.Show("PINs do not match!");
                return;
            }
            textBoxAddPatronMsg.Text = "Adding patron...";
            string errmsg = "";
            bool bOK = session1.AddPatron(patron, out errmsg);
            if (bOK) {
                textBoxAddPatronMsg.Text = errmsg;
            } else {
                textBoxAddPatronMsg.Text = "Error adding patron:\r\n" + errmsg;
            }
        }

        private void buttonClearInfo_Click(object sender, EventArgs e) {
            this.textBoxFirstName.Text = "";
            this.textBoxMiddleName.Text = "";
            this.textBoxLastName.Text = "";
            this.textBoxDateOfBirth.Text = "";
            this.textBoxEmail.Text = "";
            this.textBoxPhone.Text = "";
            this.comboBoxMainContactMethod.SelectedIndex = 0;
            this.textBoxAddress1.Text = "";
            this.textBoxAddress2.Text = "";
            this.textBoxCity.Text = "";
            this.comboBoxState.Text = "";
            this.textBoxZipcode.Text = "";
            this.textBoxLibraryCardBarcode.Text = "";
            this.textBoxPIN.Text = "";
            this.textBoxPIN2.Text = "";
            this.comboBoxLibraryForAddPatron.SelectedIndex = 0;
            this.textBoxAddPatronMsg.Text = "";
            this.textBoxCircNotes.Text = "";
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Restart();
            Application.Exit();
        }

        private void buttonPrintItemsCheckedOut_Click(object sender, EventArgs e) {
            string errmsg = "";
            string cardnumber = this.textBoxPatronBarcodeForReceipt.Text.Trim();
            if (cardnumber.Length == 0) {
                textBoxPrintCheckoutMsg.Text = "You must enter a patron library code barcode number";
            } else {
                textBoxPrintCheckoutMsg.Text = $"Searching for patron with barcode {cardnumber}";
                this.textBoxPatronBarcodeForReceipt.Text = "";
                CheckoutItemCol checkoutItemCol = new CheckoutItemCol();
                string url = settings.KohaUrlStaff + "/cgi-bin/koha/circ/circulation-home.pl";
                bool bOK = session1.GetItemsCheckedOutForPatron(url, cardnumber,
                    ref checkoutItemCol, out errmsg);
                ShowMsg($"GetItemsCheckedOutForPatron ret {bOK}: {checkoutItemCol}");
                if (bOK) {
                    if(this.checkBoxPrintOnlyItemsCheckedOutToday.Checked) {
                        checkoutItemCol.RemoveCheckoutsNotToday();
                    }
                    if(checkoutItemCol.items.Count == 0) {
                        textBoxPrintCheckoutMsg.Text = $"No items checked out today for {cardnumber}";
                        return;
                    }
                    textBoxPrintCheckoutMsg.Text = $"Printing items checked out today for {cardnumber}";
                    printImpl.PrintCheckoutSlip(checkoutItemCol);
                } else {
                    textBoxPrintCheckoutMsg.Text = errmsg;
                }
            }
        }

        private void buttonPlaceHoldSearch_Click(object sender, EventArgs e) {
            ItemSearchResultsCol itemSearchResultsCol;
            string errmsg = "";
            this.dataGridViewPlaceHold.Rows.Clear();
            string searchTerms = this.textBoxPlaceHoldItemSearch.Text.Trim();
            if (searchTerms.Length == 0) {
                this.textBoxPlaceHoldMsg.Text = "You must enter search terms";
                return;
            }
            this.textBoxPlaceHoldMsg.Text = $"Searching for {searchTerms}...";
            bool bThereAreMore;
            bool bOK = session1.SearchForItems(searchTerms, out itemSearchResultsCol, 
                out bThereAreMore, out errmsg);
            if(bOK) {
                string msg = $"Found {itemSearchResultsCol.Count} items.";
                if (bThereAreMore) {
                    msg += " (There are more items not shown here).";
                }
                msg += " Check the ones to hold.";
                this.textBoxPlaceHoldMsg.Text = msg;
                foreach(ItemSearchResult result in itemSearchResultsCol.ResultList) {
                    this.dataGridViewPlaceHold.Rows.Add(false, result.Title, result.Author, result.BiblioID);
                }
                this.buttonPlaceHoldOnCheckedItems.Enabled = true;
            } else {
                this.textBoxPlaceHoldMsg.Text = errmsg;
            }
        }

        private void TextBoxPlaceHoldSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                // Enter key was pressed, trigger the button click event
                buttonPlaceHoldSearch_Click(sender, e);
                // Optionally, suppress the default beep sound
                e.SuppressKeyPress = true;
            }
        }

        private void buttonPlaceHoldOnCheckedItems_Click(object sender, EventArgs e) {
            this.textBoxPlaceHoldMsg.Text = "";
            string cardnumber = this.textBoxPlaceHoldPatronBarcode.Text.Trim();
            if (cardnumber.Length == 0) {
                this.textBoxPlaceHoldMsg.Text = "You must enter a patron library code barcode number";
                return;
            }

            // Create a list of items to hold, based on the checked items in the DataGridView.
            ItemSearchResultsCol itemsToHold = new ItemSearchResultsCol();
            // Note that OnlyOneResult is set to true if there was only one search
            // result, not if the patron only wanted 1 of those items.
            itemsToHold.OnlyOneResult = this.dataGridViewPlaceHold.Rows.Count == 1;
            foreach (DataGridViewRow row in dataGridViewPlaceHold.Rows) {
                // Assuming the checkbox column is the first column (index 0)
                DataGridViewCheckBoxCell checkBoxCell = row.Cells[0] as DataGridViewCheckBoxCell;

                if (checkBoxCell != null && (bool)checkBoxCell.Value) {
                    // The checkbox is checked
                    string title = row.Cells["Title"].Value.ToString();
                    string author = row.Cells["Author"].Value.ToString();
                    string biblioID = row.Cells["BibID"].Value.ToString();
                    itemsToHold.ResultList.Add(new ItemSearchResult {
                        Title = title,
                        Author = author,
                        BiblioID = biblioID
                    });
                }
            }

            if (itemsToHold.Count == 0) {
                this.textBoxPlaceHoldMsg.Text = "You must select at least one item to place a hold on";
                return;
            }

            string msg = $"Placing {itemsToHold.Count} ";
            if (itemsToHold.Count == 1) {
                msg += "hold";
            } else {
                msg += "holds";
            }
            this.textBoxPlaceHoldMsg.Text = $"{msg} for patron {cardnumber}...";

            this.buttonPlaceHoldOnCheckedItems.Enabled = false;
            string errmsg;
            bool bOK = session1.PlaceHoldsForPatron(cardnumber, itemsToHold, out errmsg);
            if(!bOK) {
                this.textBoxPlaceHoldMsg.Text = errmsg;
            } else {
                this.textBoxPlaceHoldMsg.Text = "Holds placed successfully.";
            }
        }

        private void buttonPlaceHoldsClearInfo_Click(object sender, EventArgs e) {
            textBoxPlaceHoldItemSearch.Text = "";
            textBoxPlaceHoldMsg.Text = "";
            textBoxPlaceHoldPatronBarcode.Text = "";
            dataGridViewPlaceHold.Rows.Clear();
            buttonPlaceHoldOnCheckedItems.Enabled = true;
        }

        private void buttonCheckPatronPIN_Click(object sender, EventArgs e) {
            textBoxPatronPINMsg.Text = "Checking PIN...";
            if (null == sessionPIN) {
                sessionPIN = new KohaSession(3);
            } else {
                sessionPIN.LogoutStaff();
            }
            string errmsg = "";
            LoginStatus loginStatus = sessionPIN.LoginPatron(settings.KohaUrlPatron, textBoxPatronBarcode.Text,
                textBoxPatronPIN.Text, out errmsg);
            if (loginStatus == LoginStatus.Success) {
                textBoxPatronPINMsg.Text = "PIN is correct.";
            } else if (loginStatus == LoginStatus.Failure) {
                textBoxPatronPINMsg.Text = "Incorrect PIN!\r\n" + errmsg;
            } else if (loginStatus == LoginStatus.Unknown) {
                textBoxPatronPINMsg.Text = "Unknown error logging in!\r\n" + errmsg;
            } else {
                textBoxPatronPINMsg.Text = "Internal error logging in!\r\n" + errmsg;
            }
            sessionPIN.LogoutPatron();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) {
            session1.LogoutStaff();
            if (null != session2) {
                session2.LogoutStaff();
            }
            if (null != sessionPIN) {
                sessionPIN.LogoutPatron();
            }
        }
    }
}
