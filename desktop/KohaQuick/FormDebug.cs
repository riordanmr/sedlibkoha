using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KohaQuick {
    public partial class FormDebug : Form {
        public FormDebug() {
            InitializeComponent();
        }

        // This override removes the close button from the form.
        protected override CreateParams CreateParams {
            get {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                return cp;
            }
        }

        private void FormDebug_Load(object sender, EventArgs e) {

        }

        public void AddDebugLine(string msg) {
            string stamp = DateTime.Now.ToString("HH:mm:ss.ff");
            textBoxMsgs.AppendText($"{stamp} {msg}\r\n");
            // Move the caret to the end of the text.
            textBoxMsgs.SelectionStart = textBoxMsgs.TextLength;
            // Ensure no text is selected; this prevents ugly selected text.
            textBoxMsgs.SelectionLength = 0;
        }
    }
}
