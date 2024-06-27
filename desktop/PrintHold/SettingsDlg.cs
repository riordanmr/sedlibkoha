using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintHold
{
    public partial class SettingsDlg : Form
    {
        public SettingsDlg() {
            InitializeComponent();
        }

        private void buttonFontPatron_Click(object sender, EventArgs e) {
            FontDialog dlg = new FontDialog();
            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK) {
                Font fontPatron = dlg.Font;
                Program.FormMain.printImpl.settings.FontFamily = fontPatron.FontFamily.Name;
                Program.FormMain.printImpl.settings.FontSize = fontPatron.Size;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            bool ok = true;
            if (Int32.TryParse(this.textBoxX.Text, out int xValue)) {
                // Parsing successful, xValue contains the converted integer.
                // You can now use xValue as needed, for example:
                Program.FormMain.printImpl.settings.UpperLeftX = xValue;
            } else {
                // Parsing failed, handle the error, for example, by showing a message to the user.
                MessageBox.Show("Invalid input. Please enter a valid integer for X.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }

            if (Int32.TryParse(this.textBoxY.Text, out int yValue)) {
                // Parsing successful, xValue contains the converted integer.
                // You can now use xValue as needed, for example:
                Program.FormMain.printImpl.settings.UpperLeftY = yValue;
            } else {
                // Parsing failed, handle the error, for example, by showing a message to the user.
                MessageBox.Show("Invalid input. Please enter a valid integer for Y.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            if (ok) {
                this.Close();
            }
        }
    }
}
