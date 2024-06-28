using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PrintHold
{
    public partial class SettingsDlg : Form
    {
        public SettingsDlg() {
            InitializeComponent();
            this.textBoxX.Text = Program.FormMain.printImpl.settings.UpperLeftX.ToString();
            this.textBoxY.Text = Program.FormMain.printImpl.settings.UpperLeftY.ToString();
            this.textBoxPageWidth.Text = Program.FormMain.printImpl.settings.PageWidth.ToString();
            this.checkBoxPrintToPDF.Checked = Program.FormMain.printImpl.settings.PrintToPDF;
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
            }
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            bool ok = true;
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
            if(ok && Int32.TryParse(this.textBoxPageWidth.Text, out int pageWidthValue)) {
                Program.FormMain.printImpl.settings.PageWidth = pageWidthValue;
            } else {
                MessageBox.Show("Invalid input. Please enter a valid integer for Page Width.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }

            if (ok) {
                Program.FormMain.printImpl.settings.Save();
                this.Close();
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
                //MessageBox.Show($"Selected Printer: {selectedPrinter}");
            }

        }

    }
}
