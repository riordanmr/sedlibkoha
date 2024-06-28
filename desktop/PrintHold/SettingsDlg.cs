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
            this.textBoxX.Text = Program.FormMain.printImpl.settings.UpperLeftX.ToString();
            this.textBoxY.Text = Program.FormMain.printImpl.settings.UpperLeftY.ToString();
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
    }
}
