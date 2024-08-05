using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace KohaQuick {
    public partial class SettingsDlg : Form {
        public SettingsDlg() {
            InitializeComponent();
            this.textBoxStaffURL.Text = Program.FormMain.settings.KohaUrlStaff;
            this.textBoxPatronURL.Text = Program.FormMain.settings.KohaUrlPatron;

            this.labelPrinter.Text = Program.FormMain.printImpl.settings.Printer;
            this.textBoxX.Text = Program.FormMain.printImpl.settings.UpperLeftX.ToString();
            this.textBoxY.Text = Program.FormMain.printImpl.settings.UpperLeftY.ToString();
            this.textBoxPageWidth.Text = Program.FormMain.printImpl.settings.PageWidth.ToString();
            this.textBoxLineSpacingPatron.Text = Program.FormMain.printImpl.settings.LineSpacingPatron.ToString();
            this.textBoxLineSpacingOther.Text = Program.FormMain.printImpl.settings.LineSpacingOther.ToString();
            this.checkBoxPrintToPDF.Checked = Program.FormMain.printImpl.settings.PrintToPDF;
            this.labelFontInfoPatron.Text = Program.FormMain.printImpl.settings.FontFamilyPatron + " " +
                Program.FormMain.printImpl.settings.FontSizePatron.ToString();
            this.labelFontInfoOther.Text = Program.FormMain.printImpl.settings.FontFamilyOther + " " +
                Program.FormMain.printImpl.settings.FontSizeOther.ToString();
            this.checkBoxPrintConfig.Checked = Program.FormMain.printImpl.settings.PrintConfig;

            this.listBoxFieldsAvailable.Items.AddRange(Program.FormMain.printImpl.GetHoldsFieldsAvailable());
            this.listBoxFieldsActual.Items.AddRange(Program.FormMain.printImpl.settings.HoldFields);

            this.listBoxCheckoutFieldsAvailable.Items.AddRange(Program.FormMain.printImpl.GetCheckoutFieldsAvailable());
            this.listBoxCheckoutFieldsActual.Items.AddRange(Program.FormMain.printImpl.settings.CheckoutItemFields);

            this.textBoxBrowserWidth.Text = Program.FormMain.settings.BrowserWidth.ToString();
            this.textBoxBrowserHeight.Text = Program.FormMain.settings.BrowserHeight.ToString();
            this.textBoxBrowserX.Text = Program.FormMain.settings.BrowserX.ToString();

            this.radioButtonBrowserNormal.Checked = Program.FormMain.settings.BrowserWindowState == Settings.BROWSER_WINDOW_STATE_NORMAL;
            this.radioButtonBrowserMinimized.Checked = Program.FormMain.settings.BrowserWindowState == Settings.BROWSER_WINDOW_STATE_MINIMIZED;
            this.radioButtonBrowserHidden.Checked = Program.FormMain.settings.BrowserWindowState == Settings.BROWSER_WINDOW_STATE_HIDDEN;   
        }


        private void buttonPrinter_Click(object sender, EventArgs e) {
            PrintDialog printDialog = new PrintDialog();
            PrinterSettings printerSettings = new PrinterSettings();

            // Attempt to preselect the configured printer if it exists.
            try {
                printerSettings.PrinterName = Program.FormMain.printImpl.settings.Printer;
                if (printerSettings.IsValid) // Check if the printer name is valid
                {
                    printDialog.PrinterSettings = printerSettings;
                }
            } catch (Exception ex) {
                MessageBox.Show($"An error occurred while selecting the printer: {ex.Message}");
            }

            // Show the dialog. This will still allow the user to choose another printer if they wish.
            DialogResult result = printDialog.ShowDialog();
            if (result == DialogResult.OK) {
                // If the user clicks OK, you can access the selected printer like this:
                string selectedPrinter = printDialog.PrinterSettings.PrinterName;
                Program.FormMain.printImpl.settings.Printer = selectedPrinter;
                this.labelPrinter.Text = selectedPrinter;
                //MessageBox.Show($"Selected Printer: {selectedPrinter}");
            }
        }

        private void buttonFontPatron_Click(object sender, EventArgs e) {
            FontDialog dlg = new FontDialog();
            dlg.Font = new Font(Program.FormMain.printImpl.settings.FontFamilyPatron,
                Program.FormMain.printImpl.settings.FontSizePatron);
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK) {
                Font fontPatron = dlg.Font;
                Program.FormMain.printImpl.settings.FontFamilyPatron = fontPatron.FontFamily.Name;
                Program.FormMain.printImpl.settings.FontSizePatron = fontPatron.Size;
                this.labelFontInfoPatron.Text = Program.FormMain.printImpl.settings.FontFamilyPatron + " " +
                    Program.FormMain.printImpl.settings.FontSizePatron.ToString();
            }
        }

        private void buttonFontOther_Click(object sender, EventArgs e) {
            FontDialog dlg = new FontDialog();
            dlg.Font = new Font(Program.FormMain.printImpl.settings.FontFamilyOther,
                Program.FormMain.printImpl.settings.FontSizeOther);
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK) {
                Font fontPatron = dlg.Font;
                Program.FormMain.printImpl.settings.FontFamilyOther = fontPatron.FontFamily.Name;
                Program.FormMain.printImpl.settings.FontSizeOther = fontPatron.Size;
            }
            this.labelFontInfoOther.Text = Program.FormMain.printImpl.settings.FontFamilyOther + " " +
                Program.FormMain.printImpl.settings.FontSizeOther.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            bool ok = true;
            Program.FormMain.settings.KohaUrlStaff = this.textBoxStaffURL.Text;
            Program.FormMain.settings.KohaUrlPatron = this.textBoxPatronURL.Text;
            Program.FormMain.printImpl.settings.PrintToPDF = this.checkBoxPrintToPDF.Checked;
            if (Int32.TryParse(this.textBoxX.Text, out int xValue)) {
                // Parsing successful, xValue contains the converted integer.
                // You can now use xValue as needed, for example:
                Program.FormMain.printImpl.settings.UpperLeftX = xValue;
            } else {
                // Parsing failed, handle the error, for example, by showing a message to the user.
                MessageBox.Show("Invalid input. Please enter a valid integer for X.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }

            if (ok && Int32.TryParse(this.textBoxY.Text, out int yValue)) {
                // Parsing successful, xValue contains the converted integer.
                // You can now use xValue as needed, for example:
                Program.FormMain.printImpl.settings.UpperLeftY = yValue;
            } else {
                // Parsing failed, handle the error, for example, by showing a message to the user.
                MessageBox.Show("Invalid input. Please enter a valid integer for Y.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            if (ok && Int32.TryParse(this.textBoxPageWidth.Text, out int pageWidthValue)) {
                Program.FormMain.printImpl.settings.PageWidth = pageWidthValue;
            } else {
                MessageBox.Show("Invalid input. Please enter a valid integer for Page Width.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }

            if (ok && float.TryParse(this.textBoxLineSpacingPatron.Text, out float lineSpacingPatronValue)) {
                Program.FormMain.printImpl.settings.LineSpacingPatron = lineSpacingPatronValue;
            } else {
                MessageBox.Show("Invalid input. Please enter a valid number for Line Spacing Patron.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }

            // Add code for LineSpacingOther
            if (ok && float.TryParse(this.textBoxLineSpacingOther.Text, out float lineSpacingOtherValue)) {
                Program.FormMain.printImpl.settings.LineSpacingOther = lineSpacingOtherValue;
            } else {
                MessageBox.Show("Invalid input. Please enter a valid number for Line Spacing Other.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }

            if (ok && Int32.TryParse(this.textBoxBrowserWidth.Text, out int browserWidthValue)) {
                Program.FormMain.settings.BrowserWidth = browserWidthValue;
            } else {
                MessageBox.Show("Invalid input. Please enter a valid integer for Browser Width.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }

            if (ok && Int32.TryParse(this.textBoxBrowserHeight.Text, out int browserHeightValue)) {
                Program.FormMain.settings.BrowserHeight = browserHeightValue;
            } else {
                MessageBox.Show("Invalid input. Please enter a valid integer for Browser Height.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }

            if (ok && Int32.TryParse(this.textBoxBrowserX.Text, out int browserXValue)) {
                Program.FormMain.settings.BrowserX = browserXValue;
            } else {
                MessageBox.Show("Invalid input. Please enter a valid integer for Browser X.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }

            Program.FormMain.printImpl.settings.PrintConfig = this.checkBoxPrintConfig.Checked;

            if (this.radioButtonBrowserNormal.Checked) {
                Program.FormMain.settings.BrowserWindowState = Settings.BROWSER_WINDOW_STATE_NORMAL;
            } else if (this.radioButtonBrowserMinimized.Checked) {
                Program.FormMain.settings.BrowserWindowState = Settings.BROWSER_WINDOW_STATE_MINIMIZED;
            } else if (this.radioButtonBrowserHidden.Checked) {
                Program.FormMain.settings.BrowserWindowState = Settings.BROWSER_WINDOW_STATE_HIDDEN;
            }

            // Save the configured print hold slip fields.
            string[] fields = new string[this.listBoxFieldsActual.Items.Count];
            for (int i = 0; i < this.listBoxFieldsActual.Items.Count; i++) {
                fields[i] = this.listBoxFieldsActual.Items[i].ToString();
            }
            Program.FormMain.printImpl.settings.HoldFields = fields;

            // Save the configured print checkout fields.
            fields = new string[this.listBoxCheckoutFieldsActual.Items.Count];
            for (int i = 0; i < this.listBoxCheckoutFieldsActual.Items.Count; i++) {
                fields[i] = this.listBoxCheckoutFieldsActual.Items[i].ToString();
            }
            Program.FormMain.printImpl.settings.CheckoutItemFields = fields;

            if (ok) {
                Program.FormMain.printImpl.settings.Save();
                this.Close();
            }
        }

        private void buttonFieldAdd_Click(object sender, EventArgs e) {
            // Add the selected item from the Available list to the Actual list.
            if (this.listBoxFieldsAvailable.SelectedItem != null) {
                object itemToAdd = this.listBoxFieldsAvailable.SelectedItem;
                int insertIndex = this.listBoxFieldsActual.SelectedIndex;

                // Check if there is a selected item in listBoxFieldsActual to insert after
                if (insertIndex != -1) {
                    // Insert right after the selected item
                    this.listBoxFieldsActual.Items.Insert(insertIndex + 1, itemToAdd);
                } else {
                    // No selection, add to the end of the list
                    this.listBoxFieldsActual.Items.Add(itemToAdd);
                }
            }
        }

        private void buttonFieldRemove_Click(object sender, EventArgs e) {
            // Remove the selected item from the Actual list.
            if (this.listBoxFieldsActual.SelectedIndex != -1) { // Check if an item is actually selected
                this.listBoxFieldsActual.Items.RemoveAt(this.listBoxFieldsActual.SelectedIndex);
            }
        }

        private void buttonFieldUp_Click(object sender, EventArgs e) {
            // Move the selected field up in the list.
            if (this.listBoxFieldsActual.SelectedIndex > 0) {
                int index = this.listBoxFieldsActual.SelectedIndex;
                object item = this.listBoxFieldsActual.SelectedItem;
                this.listBoxFieldsActual.Items.RemoveAt(index);
                this.listBoxFieldsActual.Items.Insert(index - 1, item);
                this.listBoxFieldsActual.SelectedIndex = index - 1;
            }
        }

        private void buttonFieldDown_Click(object sender, EventArgs e) {
            // Move the selected field down in the list.
            if (this.listBoxFieldsActual.SelectedIndex != -1 &&
                this.listBoxFieldsActual.SelectedIndex < this.listBoxFieldsActual.Items.Count - 1) {
                int index = this.listBoxFieldsActual.SelectedIndex;
                object item = this.listBoxFieldsActual.SelectedItem;
                this.listBoxFieldsActual.Items.RemoveAt(index);
                this.listBoxFieldsActual.Items.Insert(index + 1, item);
                this.listBoxFieldsActual.SelectedIndex = index + 1;
            }
        }

        private void buttonCheckoutFieldAdd_Click(object sender, EventArgs e) {
            // Add the selected item from the Available list to the Actual list.
            if (this.listBoxCheckoutFieldsAvailable.SelectedItem != null) {
                object itemToAdd = this.listBoxCheckoutFieldsAvailable.SelectedItem;
                int insertIndex = this.listBoxCheckoutFieldsActual.SelectedIndex;

                // Check if there is a selected item in listBoxFieldsActual to insert after
                if (insertIndex != -1) {
                    // Insert right after the selected item
                    this.listBoxCheckoutFieldsActual.Items.Insert(insertIndex + 1, itemToAdd);
                } else {
                    // No selection, add to the end of the list
                    this.listBoxCheckoutFieldsActual.Items.Add(itemToAdd);
                }
            }

        }

        private void buttonCheckoutFieldRemove_Click(object sender, EventArgs e) {
            // Remove the selected item from the Actual list.
            if (this.listBoxCheckoutFieldsActual.SelectedIndex != -1) { // Check if an item is actually selected
                this.listBoxCheckoutFieldsActual.Items.RemoveAt(this.listBoxCheckoutFieldsActual.SelectedIndex);
            }
        }

        private void buttonCheckoutFieldUp_Click(object sender, EventArgs e) {
            if (this.listBoxCheckoutFieldsActual.SelectedIndex > 0) {
                int index = this.listBoxCheckoutFieldsActual.SelectedIndex;
                object item = this.listBoxCheckoutFieldsActual.SelectedItem;
                this.listBoxCheckoutFieldsActual.Items.RemoveAt(index);
                this.listBoxCheckoutFieldsActual.Items.Insert(index - 1, item);
                this.listBoxCheckoutFieldsActual.SelectedIndex = index - 1;
            }
        }

        private void buttonCheckoutFieldDown_Click(object sender, EventArgs e) {
            // Move the selected field down in the list.
            if (this.listBoxCheckoutFieldsActual.SelectedIndex != -1 &&
                this.listBoxCheckoutFieldsActual.SelectedIndex < this.listBoxCheckoutFieldsActual.Items.Count - 1) {
                int index = this.listBoxCheckoutFieldsActual.SelectedIndex;
                object item = this.listBoxCheckoutFieldsActual.SelectedItem;
                this.listBoxCheckoutFieldsActual.Items.RemoveAt(index);
                this.listBoxCheckoutFieldsActual.Items.Insert(index + 1, item);
                this.listBoxCheckoutFieldsActual.SelectedIndex = index + 1;
            }
        }
    }
}
