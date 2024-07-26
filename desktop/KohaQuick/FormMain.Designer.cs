﻿namespace KohaQuick
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControlHolds = new System.Windows.Forms.TabControl();
            this.tabPageTrapHolds = new System.Windows.Forms.TabPage();
            this.textBoxBarcodeMsg = new System.Windows.Forms.TextBox();
            this.textBoxTrapMsg = new System.Windows.Forms.TextBox();
            this.buttonTrapHold = new System.Windows.Forms.Button();
            this.textBoxItemBarcode = new System.Windows.Forms.TextBox();
            this.labelBarcode = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxTitleMsg = new System.Windows.Forms.TextBox();
            this.tabControlHolds.SuspendLayout();
            this.tabPageTrapHolds.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlHolds
            // 
            this.tabControlHolds.Controls.Add(this.tabPageTrapHolds);
            this.tabControlHolds.Location = new System.Drawing.Point(12, 58);
            this.tabControlHolds.Name = "tabControlHolds";
            this.tabControlHolds.SelectedIndex = 0;
            this.tabControlHolds.Size = new System.Drawing.Size(973, 562);
            this.tabControlHolds.TabIndex = 0;
            // 
            // tabPageTrapHolds
            // 
            this.tabPageTrapHolds.Controls.Add(this.textBoxTitleMsg);
            this.tabPageTrapHolds.Controls.Add(this.textBoxBarcodeMsg);
            this.tabPageTrapHolds.Controls.Add(this.textBoxTrapMsg);
            this.tabPageTrapHolds.Controls.Add(this.buttonTrapHold);
            this.tabPageTrapHolds.Controls.Add(this.textBoxItemBarcode);
            this.tabPageTrapHolds.Controls.Add(this.labelBarcode);
            this.tabPageTrapHolds.Location = new System.Drawing.Point(8, 39);
            this.tabPageTrapHolds.Name = "tabPageTrapHolds";
            this.tabPageTrapHolds.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTrapHolds.Size = new System.Drawing.Size(957, 515);
            this.tabPageTrapHolds.TabIndex = 0;
            this.tabPageTrapHolds.Text = "Trap Holds";
            this.tabPageTrapHolds.UseVisualStyleBackColor = true;
            // 
            // textBoxBarcodeMsg
            // 
            this.textBoxBarcodeMsg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxBarcodeMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBarcodeMsg.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBarcodeMsg.Location = new System.Drawing.Point(40, 103);
            this.textBoxBarcodeMsg.Multiline = true;
            this.textBoxBarcodeMsg.Name = "textBoxBarcodeMsg";
            this.textBoxBarcodeMsg.ReadOnly = true;
            this.textBoxBarcodeMsg.Size = new System.Drawing.Size(877, 37);
            this.textBoxBarcodeMsg.TabIndex = 4;
            // 
            // textBoxTrapMsg
            // 
            this.textBoxTrapMsg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxTrapMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTrapMsg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTrapMsg.Location = new System.Drawing.Point(40, 199);
            this.textBoxTrapMsg.Multiline = true;
            this.textBoxTrapMsg.Name = "textBoxTrapMsg";
            this.textBoxTrapMsg.ReadOnly = true;
            this.textBoxTrapMsg.Size = new System.Drawing.Size(877, 175);
            this.textBoxTrapMsg.TabIndex = 3;
            // 
            // buttonTrapHold
            // 
            this.buttonTrapHold.Location = new System.Drawing.Point(583, 31);
            this.buttonTrapHold.Name = "buttonTrapHold";
            this.buttonTrapHold.Size = new System.Drawing.Size(158, 45);
            this.buttonTrapHold.TabIndex = 2;
            this.buttonTrapHold.Text = "&Trap Hold";
            this.buttonTrapHold.UseVisualStyleBackColor = true;
            this.buttonTrapHold.Click += new System.EventHandler(this.buttonTrapHold_Click);
            // 
            // textBoxItemBarcode
            // 
            this.textBoxItemBarcode.Font = new System.Drawing.Font("Lucida Console", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxItemBarcode.Location = new System.Drawing.Point(180, 37);
            this.textBoxItemBarcode.Name = "textBoxItemBarcode";
            this.textBoxItemBarcode.Size = new System.Drawing.Size(346, 34);
            this.textBoxItemBarcode.TabIndex = 1;
            // 
            // labelBarcode
            // 
            this.labelBarcode.AutoSize = true;
            this.labelBarcode.Location = new System.Drawing.Point(65, 41);
            this.labelBarcode.Name = "labelBarcode";
            this.labelBarcode.Size = new System.Drawing.Size(98, 25);
            this.labelBarcode.TabIndex = 0;
            this.labelBarcode.Text = "Barcode:";
            // 
            // menuStrip2
            // 
            this.menuStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(986, 40);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printSampleToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 36);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // printSampleToolStripMenuItem
            // 
            this.printSampleToolStripMenuItem.Name = "printSampleToolStripMenuItem";
            this.printSampleToolStripMenuItem.Size = new System.Drawing.Size(282, 44);
            this.printSampleToolStripMenuItem.Text = "&Print Sample";
            this.printSampleToolStripMenuItem.Click += new System.EventHandler(this.printSampleToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(282, 44);
            this.settingsToolStripMenuItem.Text = "&Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(282, 44);
            this.loginToolStripMenuItem.Text = "&Login...";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(282, 44);
            this.logoutToolStripMenuItem.Text = "Log&out";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(282, 44);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // textBoxTitleMsg
            // 
            this.textBoxTitleMsg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxTitleMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitleMsg.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitleMsg.Location = new System.Drawing.Point(40, 146);
            this.textBoxTitleMsg.Multiline = true;
            this.textBoxTitleMsg.Name = "textBoxTitleMsg";
            this.textBoxTitleMsg.ReadOnly = true;
            this.textBoxTitleMsg.Size = new System.Drawing.Size(877, 48);
            this.textBoxTitleMsg.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 632);
            this.Controls.Add(this.tabControlHolds);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "KohaQuick";
            this.tabControlHolds.ResumeLayout(false);
            this.tabPageTrapHolds.ResumeLayout(false);
            this.tabPageTrapHolds.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlHolds;
        private System.Windows.Forms.TabPage tabPageTrapHolds;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSampleToolStripMenuItem;
        private System.Windows.Forms.Label labelBarcode;
        private System.Windows.Forms.Button buttonTrapHold;
        private System.Windows.Forms.TextBox textBoxItemBarcode;
        private System.Windows.Forms.TextBox textBoxTrapMsg;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxBarcodeMsg;
        private System.Windows.Forms.TextBox textBoxTitleMsg;
    }
}

