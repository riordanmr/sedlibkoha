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
        }

        private void buttonLogin_Click(object sender, EventArgs e) {
            this.labelLoginResult.Text = "Logging in...";
            bool bLoggedIn = Program.FormMain.session1.Login(Program.FormMain.settings.KohaUrlStaff,
                this.textBoxUsername.Text, this.textBoxPassword.Text);
            if (bLoggedIn) {
                labelLoginResult.Text = "Login successful!";
                this.Close();
            } else {
                labelLoginResult.Text = "Login failed. Please try again.";
            }
        }
    }
}