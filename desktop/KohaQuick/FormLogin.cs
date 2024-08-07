﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KohaQuick {
    public partial class FormLogin : Form {
        public FormLogin() {
            InitializeComponent();
            this.textBoxUsername.Text = Program.FormMain.creds.KohaUsername;
            this.textBoxPassword.Text = Program.FormMain.creds.KohaPassword;
            this.Shown += FormLogin_Shown;
        }

        private void FormLogin_Shown(object sender, EventArgs e) {
            if (textBoxUsername.Text.Length > 0 && textBoxPassword.Text.Length > 0 && 
                Program.FormMain.InitialLogin) {
                buttonLogin_Click(sender, e);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e) {
            Program.FormMain.InitialLogin = false;
            this.labelLoginResult.Text = "Logging in...";
            string errmsg = "";
            bool bLoggedIn = Program.FormMain.session1.LoginStaff(Program.FormMain.settings.KohaUrlStaff,
                this.textBoxUsername.Text, this.textBoxPassword.Text, out errmsg);
            if (bLoggedIn) {
                Program.FormMain.creds.KohaUsername = this.textBoxUsername.Text;
                Program.FormMain.creds.KohaPassword = this.textBoxPassword.Text;
                labelLoginResult.Text = "Logged in successfully";
                this.Close();
            } else {
                labelLoginResult.Text = "Login failed. Please try again.\n" + errmsg;
            }

        }
    }
}
