﻿using System.Drawing;
using System.Windows.Forms;

namespace KohaQuick
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControlHolds = new System.Windows.Forms.TabControl();
            this.tabPageTrapHolds = new System.Windows.Forms.TabPage();
            this.textBoxTitleMsg = new System.Windows.Forms.TextBox();
            this.textBoxBarcodeMsg = new System.Windows.Forms.TextBox();
            this.textBoxTrapMsg = new System.Windows.Forms.TextBox();
            this.buttonTrapHold = new System.Windows.Forms.Button();
            this.textBoxItemBarcode = new System.Windows.Forms.TextBox();
            this.labelBarcode = new System.Windows.Forms.Label();
            this.tabPageCheckPIN = new System.Windows.Forms.TabPage();
            this.textBoxPatronPINMsg = new System.Windows.Forms.TextBox();
            this.buttonCheckPatronPIN = new System.Windows.Forms.Button();
            this.textBoxPatronPIN = new System.Windows.Forms.TextBox();
            this.labelPatronPIN = new System.Windows.Forms.Label();
            this.textBoxPatronBarcode = new System.Windows.Forms.TextBox();
            this.labelPatronBarcode = new System.Windows.Forms.Label();
            this.tabPageAddPatron = new System.Windows.Forms.TabPage();
            this.textBoxAddPatronMsg = new System.Windows.Forms.TextBox();
            this.buttonClearInfo = new System.Windows.Forms.Button();
            this.buttonGenerateRandom = new System.Windows.Forms.Button();
            this.buttonAddPatron = new System.Windows.Forms.Button();
            this.groupBoxLibraryCard = new System.Windows.Forms.GroupBox();
            this.comboBoxLibraryForAddPatron = new System.Windows.Forms.ComboBox();
            this.labelLibraryForAddPatron = new System.Windows.Forms.Label();
            this.textBoxCircNotes = new System.Windows.Forms.TextBox();
            this.labelCircNotes = new System.Windows.Forms.Label();
            this.textBoxPIN2 = new System.Windows.Forms.TextBox();
            this.textBoxPIN = new System.Windows.Forms.TextBox();
            this.labelPIN2 = new System.Windows.Forms.Label();
            this.textBoxLibraryCardBarcode = new System.Windows.Forms.TextBox();
            this.labelLibraryCardBarcode = new System.Windows.Forms.Label();
            this.labelPIN = new System.Windows.Forms.Label();
            this.groupBoxIdentity = new System.Windows.Forms.GroupBox();
            this.labelMiddleName = new System.Windows.Forms.Label();
            this.labelLastName = new System.Windows.Forms.Label();
            this.textBoxMiddleName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.labelDateOfBirth = new System.Windows.Forms.Label();
            this.textBoxDateOfBirth = new System.Windows.Forms.TextBox();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.groupBoxAddress = new System.Windows.Forms.GroupBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textBoxAddress1 = new System.Windows.Forms.TextBox();
            this.labelAddress2 = new System.Windows.Forms.Label();
            this.textBoxAddress2 = new System.Windows.Forms.TextBox();
            this.textBoxZipcode = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.labelZipcode = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.groupBoxContactInfo = new System.Windows.Forms.GroupBox();
            this.comboBoxMainContactMethod = new System.Windows.Forms.ComboBox();
            this.labelMainContactMethod = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.tabPagePrintCheckouts = new System.Windows.Forms.TabPage();
            this.checkBoxPrintOnlyItemsCheckedOutToday = new System.Windows.Forms.CheckBox();
            this.textBoxPrintCheckoutMsg = new System.Windows.Forms.TextBox();
            this.buttonPrintItemsCheckedOut = new System.Windows.Forms.Button();
            this.textBoxPatronBarcodeForReceipt = new System.Windows.Forms.TextBox();
            this.labelPatronBarcodeForReceipt = new System.Windows.Forms.Label();
            this.labelPrintReceiptHeader = new System.Windows.Forms.Label();
            this.tabPagePlaceHold = new System.Windows.Forms.TabPage();
            this.buttonPlaceHoldsClearInfo = new System.Windows.Forms.Button();
            this.textBoxPlaceHoldMsg = new System.Windows.Forms.TextBox();
            this.buttonPlaceHoldOnCheckedItems = new System.Windows.Forms.Button();
            this.dataGridViewPlaceHold = new System.Windows.Forms.DataGridView();
            this.Hold = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BibID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonPlaceHoldSearch = new System.Windows.Forms.Button();
            this.textBoxPlaceHoldItemSearch = new System.Windows.Forms.TextBox();
            this.labelPlaceHoldItemSearch = new System.Windows.Forms.Label();
            this.textBoxPlaceHoldPatronBarcode = new System.Windows.Forms.TextBox();
            this.labelPlaceHoldPatronBarcode = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSampleCheckoutSlipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlHolds.SuspendLayout();
            this.tabPageTrapHolds.SuspendLayout();
            this.tabPageCheckPIN.SuspendLayout();
            this.tabPageAddPatron.SuspendLayout();
            this.groupBoxLibraryCard.SuspendLayout();
            this.groupBoxIdentity.SuspendLayout();
            this.groupBoxAddress.SuspendLayout();
            this.groupBoxContactInfo.SuspendLayout();
            this.tabPagePrintCheckouts.SuspendLayout();
            this.tabPagePlaceHold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlaceHold)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlHolds
            // 
            this.tabControlHolds.Controls.Add(this.tabPageTrapHolds);
            this.tabControlHolds.Controls.Add(this.tabPageCheckPIN);
            this.tabControlHolds.Controls.Add(this.tabPageAddPatron);
            this.tabControlHolds.Controls.Add(this.tabPagePrintCheckouts);
            this.tabControlHolds.Controls.Add(this.tabPagePlaceHold);
            this.tabControlHolds.Location = new System.Drawing.Point(12, 58);
            this.tabControlHolds.Name = "tabControlHolds";
            this.tabControlHolds.SelectedIndex = 0;
            this.tabControlHolds.Size = new System.Drawing.Size(1101, 948);
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
            this.tabPageTrapHolds.Size = new System.Drawing.Size(1085, 901);
            this.tabPageTrapHolds.TabIndex = 0;
            this.tabPageTrapHolds.Text = "Trap Holds";
            this.tabPageTrapHolds.UseVisualStyleBackColor = true;
            // 
            // textBoxTitleMsg
            // 
            this.textBoxTitleMsg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxTitleMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitleMsg.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitleMsg.Location = new System.Drawing.Point(40, 149);
            this.textBoxTitleMsg.Multiline = true;
            this.textBoxTitleMsg.Name = "textBoxTitleMsg";
            this.textBoxTitleMsg.ReadOnly = true;
            this.textBoxTitleMsg.Size = new System.Drawing.Size(877, 61);
            this.textBoxTitleMsg.TabIndex = 5;
            // 
            // textBoxBarcodeMsg
            // 
            this.textBoxBarcodeMsg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxBarcodeMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxBarcodeMsg.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBarcodeMsg.Location = new System.Drawing.Point(40, 96);
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
            this.textBoxTrapMsg.Location = new System.Drawing.Point(40, 233);
            this.textBoxTrapMsg.Multiline = true;
            this.textBoxTrapMsg.Name = "textBoxTrapMsg";
            this.textBoxTrapMsg.ReadOnly = true;
            this.textBoxTrapMsg.Size = new System.Drawing.Size(877, 181);
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
            // tabPageCheckPIN
            // 
            this.tabPageCheckPIN.Controls.Add(this.textBoxPatronPINMsg);
            this.tabPageCheckPIN.Controls.Add(this.buttonCheckPatronPIN);
            this.tabPageCheckPIN.Controls.Add(this.textBoxPatronPIN);
            this.tabPageCheckPIN.Controls.Add(this.labelPatronPIN);
            this.tabPageCheckPIN.Controls.Add(this.textBoxPatronBarcode);
            this.tabPageCheckPIN.Controls.Add(this.labelPatronBarcode);
            this.tabPageCheckPIN.Location = new System.Drawing.Point(8, 39);
            this.tabPageCheckPIN.Name = "tabPageCheckPIN";
            this.tabPageCheckPIN.Size = new System.Drawing.Size(1085, 901);
            this.tabPageCheckPIN.TabIndex = 1;
            this.tabPageCheckPIN.Text = "Check PIN";
            this.tabPageCheckPIN.UseVisualStyleBackColor = true;
            // 
            // textBoxPatronPINMsg
            // 
            this.textBoxPatronPINMsg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxPatronPINMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPatronPINMsg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPatronPINMsg.Location = new System.Drawing.Point(37, 227);
            this.textBoxPatronPINMsg.Multiline = true;
            this.textBoxPatronPINMsg.Name = "textBoxPatronPINMsg";
            this.textBoxPatronPINMsg.ReadOnly = true;
            this.textBoxPatronPINMsg.Size = new System.Drawing.Size(877, 175);
            this.textBoxPatronPINMsg.TabIndex = 7;
            // 
            // buttonCheckPatronPIN
            // 
            this.buttonCheckPatronPIN.Location = new System.Drawing.Point(249, 150);
            this.buttonCheckPatronPIN.Name = "buttonCheckPatronPIN";
            this.buttonCheckPatronPIN.Size = new System.Drawing.Size(136, 46);
            this.buttonCheckPatronPIN.TabIndex = 6;
            this.buttonCheckPatronPIN.Text = "Check PIN";
            this.buttonCheckPatronPIN.UseVisualStyleBackColor = true;
            this.buttonCheckPatronPIN.Click += new System.EventHandler(this.buttonCheckPatronPIN_Click);
            // 
            // textBoxPatronPIN
            // 
            this.textBoxPatronPIN.Font = new System.Drawing.Font("Lucida Console", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPatronPIN.Location = new System.Drawing.Point(249, 88);
            this.textBoxPatronPIN.Name = "textBoxPatronPIN";
            this.textBoxPatronPIN.PasswordChar = '*';
            this.textBoxPatronPIN.Size = new System.Drawing.Size(104, 34);
            this.textBoxPatronPIN.TabIndex = 5;
            // 
            // labelPatronPIN
            // 
            this.labelPatronPIN.AutoSize = true;
            this.labelPatronPIN.Location = new System.Drawing.Point(116, 91);
            this.labelPatronPIN.Name = "labelPatronPIN";
            this.labelPatronPIN.Size = new System.Drawing.Size(121, 25);
            this.labelPatronPIN.TabIndex = 4;
            this.labelPatronPIN.Text = "Patron PIN:";
            // 
            // textBoxPatronBarcode
            // 
            this.textBoxPatronBarcode.Font = new System.Drawing.Font("Lucida Console", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPatronBarcode.Location = new System.Drawing.Point(249, 42);
            this.textBoxPatronBarcode.Name = "textBoxPatronBarcode";
            this.textBoxPatronBarcode.Size = new System.Drawing.Size(346, 34);
            this.textBoxPatronBarcode.TabIndex = 3;
            // 
            // labelPatronBarcode
            // 
            this.labelPatronBarcode.AutoSize = true;
            this.labelPatronBarcode.Location = new System.Drawing.Point(70, 46);
            this.labelPatronBarcode.Name = "labelPatronBarcode";
            this.labelPatronBarcode.Size = new System.Drawing.Size(167, 25);
            this.labelPatronBarcode.TabIndex = 2;
            this.labelPatronBarcode.Text = "Patron Barcode:";
            // 
            // tabPageAddPatron
            // 
            this.tabPageAddPatron.Controls.Add(this.textBoxAddPatronMsg);
            this.tabPageAddPatron.Controls.Add(this.buttonClearInfo);
            this.tabPageAddPatron.Controls.Add(this.buttonGenerateRandom);
            this.tabPageAddPatron.Controls.Add(this.buttonAddPatron);
            this.tabPageAddPatron.Controls.Add(this.groupBoxLibraryCard);
            this.tabPageAddPatron.Controls.Add(this.groupBoxIdentity);
            this.tabPageAddPatron.Controls.Add(this.groupBoxAddress);
            this.tabPageAddPatron.Controls.Add(this.groupBoxContactInfo);
            this.tabPageAddPatron.Location = new System.Drawing.Point(8, 39);
            this.tabPageAddPatron.Name = "tabPageAddPatron";
            this.tabPageAddPatron.Size = new System.Drawing.Size(1085, 901);
            this.tabPageAddPatron.TabIndex = 2;
            this.tabPageAddPatron.Text = "Add Patron";
            this.tabPageAddPatron.UseVisualStyleBackColor = true;
            // 
            // textBoxAddPatronMsg
            // 
            this.textBoxAddPatronMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAddPatronMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddPatronMsg.Location = new System.Drawing.Point(22, 797);
            this.textBoxAddPatronMsg.Multiline = true;
            this.textBoxAddPatronMsg.Name = "textBoxAddPatronMsg";
            this.textBoxAddPatronMsg.Size = new System.Drawing.Size(1030, 98);
            this.textBoxAddPatronMsg.TabIndex = 7;
            // 
            // buttonClearInfo
            // 
            this.buttonClearInfo.Location = new System.Drawing.Point(765, 737);
            this.buttonClearInfo.Name = "buttonClearInfo";
            this.buttonClearInfo.Size = new System.Drawing.Size(200, 44);
            this.buttonClearInfo.TabIndex = 6;
            this.buttonClearInfo.Text = "Clear Info";
            this.buttonClearInfo.UseVisualStyleBackColor = true;
            this.buttonClearInfo.Click += new System.EventHandler(this.buttonClearInfo_Click);
            // 
            // buttonGenerateRandom
            // 
            this.buttonGenerateRandom.Location = new System.Drawing.Point(117, 737);
            this.buttonGenerateRandom.Name = "buttonGenerateRandom";
            this.buttonGenerateRandom.Size = new System.Drawing.Size(200, 44);
            this.buttonGenerateRandom.TabIndex = 4;
            this.buttonGenerateRandom.Text = "Generate Random";
            this.buttonGenerateRandom.UseVisualStyleBackColor = true;
            this.buttonGenerateRandom.Click += new System.EventHandler(this.buttonGenerateRandom_Click);
            // 
            // buttonAddPatron
            // 
            this.buttonAddPatron.Location = new System.Drawing.Point(437, 737);
            this.buttonAddPatron.Name = "buttonAddPatron";
            this.buttonAddPatron.Size = new System.Drawing.Size(200, 44);
            this.buttonAddPatron.TabIndex = 5;
            this.buttonAddPatron.Text = "Add Patron";
            this.buttonAddPatron.UseVisualStyleBackColor = true;
            this.buttonAddPatron.Click += new System.EventHandler(this.buttonAddPatron_Click);
            // 
            // groupBoxLibraryCard
            // 
            this.groupBoxLibraryCard.Controls.Add(this.comboBoxLibraryForAddPatron);
            this.groupBoxLibraryCard.Controls.Add(this.labelLibraryForAddPatron);
            this.groupBoxLibraryCard.Controls.Add(this.textBoxCircNotes);
            this.groupBoxLibraryCard.Controls.Add(this.labelCircNotes);
            this.groupBoxLibraryCard.Controls.Add(this.textBoxPIN2);
            this.groupBoxLibraryCard.Controls.Add(this.textBoxPIN);
            this.groupBoxLibraryCard.Controls.Add(this.labelPIN2);
            this.groupBoxLibraryCard.Controls.Add(this.textBoxLibraryCardBarcode);
            this.groupBoxLibraryCard.Controls.Add(this.labelLibraryCardBarcode);
            this.groupBoxLibraryCard.Controls.Add(this.labelPIN);
            this.groupBoxLibraryCard.Location = new System.Drawing.Point(17, 441);
            this.groupBoxLibraryCard.Name = "groupBoxLibraryCard";
            this.groupBoxLibraryCard.Size = new System.Drawing.Size(1041, 268);
            this.groupBoxLibraryCard.TabIndex = 3;
            this.groupBoxLibraryCard.TabStop = false;
            this.groupBoxLibraryCard.Text = "Library card";
            // 
            // comboBoxLibraryForAddPatron
            // 
            this.comboBoxLibraryForAddPatron.FormattingEnabled = true;
            this.comboBoxLibraryForAddPatron.Location = new System.Drawing.Point(156, 120);
            this.comboBoxLibraryForAddPatron.Name = "comboBoxLibraryForAddPatron";
            this.comboBoxLibraryForAddPatron.Size = new System.Drawing.Size(280, 33);
            this.comboBoxLibraryForAddPatron.TabIndex = 7;
            // 
            // labelLibraryForAddPatron
            // 
            this.labelLibraryForAddPatron.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLibraryForAddPatron.AutoSize = true;
            this.labelLibraryForAddPatron.Location = new System.Drawing.Point(57, 120);
            this.labelLibraryForAddPatron.Name = "labelLibraryForAddPatron";
            this.labelLibraryForAddPatron.Size = new System.Drawing.Size(84, 25);
            this.labelLibraryForAddPatron.TabIndex = 6;
            this.labelLibraryForAddPatron.Text = "Library:";
            this.labelLibraryForAddPatron.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCircNotes
            // 
            this.textBoxCircNotes.Location = new System.Drawing.Point(156, 167);
            this.textBoxCircNotes.Multiline = true;
            this.textBoxCircNotes.Name = "textBoxCircNotes";
            this.textBoxCircNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCircNotes.Size = new System.Drawing.Size(857, 82);
            this.textBoxCircNotes.TabIndex = 9;
            // 
            // labelCircNotes
            // 
            this.labelCircNotes.AutoSize = true;
            this.labelCircNotes.Location = new System.Drawing.Point(31, 167);
            this.labelCircNotes.Name = "labelCircNotes";
            this.labelCircNotes.Size = new System.Drawing.Size(115, 25);
            this.labelCircNotes.TabIndex = 8;
            this.labelCircNotes.Text = "Circ notes:";
            // 
            // textBoxPIN2
            // 
            this.textBoxPIN2.Location = new System.Drawing.Point(372, 74);
            this.textBoxPIN2.Name = "textBoxPIN2";
            this.textBoxPIN2.PasswordChar = '*';
            this.textBoxPIN2.Size = new System.Drawing.Size(124, 31);
            this.textBoxPIN2.TabIndex = 5;
            // 
            // textBoxPIN
            // 
            this.textBoxPIN.Location = new System.Drawing.Point(156, 74);
            this.textBoxPIN.Name = "textBoxPIN";
            this.textBoxPIN.PasswordChar = '*';
            this.textBoxPIN.Size = new System.Drawing.Size(124, 31);
            this.textBoxPIN.TabIndex = 3;
            // 
            // labelPIN2
            // 
            this.labelPIN2.AutoSize = true;
            this.labelPIN2.Location = new System.Drawing.Point(293, 77);
            this.labelPIN2.Name = "labelPIN2";
            this.labelPIN2.Size = new System.Drawing.Size(73, 25);
            this.labelPIN2.TabIndex = 4;
            this.labelPIN2.Text = "Again:";
            this.labelPIN2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxLibraryCardBarcode
            // 
            this.textBoxLibraryCardBarcode.Location = new System.Drawing.Point(156, 32);
            this.textBoxLibraryCardBarcode.Name = "textBoxLibraryCardBarcode";
            this.textBoxLibraryCardBarcode.Size = new System.Drawing.Size(293, 31);
            this.textBoxLibraryCardBarcode.TabIndex = 1;
            // 
            // labelLibraryCardBarcode
            // 
            this.labelLibraryCardBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLibraryCardBarcode.AutoSize = true;
            this.labelLibraryCardBarcode.Location = new System.Drawing.Point(49, 32);
            this.labelLibraryCardBarcode.Name = "labelLibraryCardBarcode";
            this.labelLibraryCardBarcode.Size = new System.Drawing.Size(98, 25);
            this.labelLibraryCardBarcode.TabIndex = 0;
            this.labelLibraryCardBarcode.Text = "Barcode:";
            this.labelLibraryCardBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPIN
            // 
            this.labelPIN.AutoSize = true;
            this.labelPIN.Location = new System.Drawing.Point(95, 74);
            this.labelPIN.Name = "labelPIN";
            this.labelPIN.Size = new System.Drawing.Size(52, 25);
            this.labelPIN.TabIndex = 2;
            this.labelPIN.Text = "PIN:";
            this.labelPIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxIdentity
            // 
            this.groupBoxIdentity.Controls.Add(this.labelMiddleName);
            this.groupBoxIdentity.Controls.Add(this.labelLastName);
            this.groupBoxIdentity.Controls.Add(this.textBoxMiddleName);
            this.groupBoxIdentity.Controls.Add(this.textBoxLastName);
            this.groupBoxIdentity.Controls.Add(this.labelDateOfBirth);
            this.groupBoxIdentity.Controls.Add(this.textBoxDateOfBirth);
            this.groupBoxIdentity.Controls.Add(this.labelFirstName);
            this.groupBoxIdentity.Controls.Add(this.textBoxFirstName);
            this.groupBoxIdentity.Location = new System.Drawing.Point(17, 9);
            this.groupBoxIdentity.Name = "groupBoxIdentity";
            this.groupBoxIdentity.Size = new System.Drawing.Size(1041, 139);
            this.groupBoxIdentity.TabIndex = 0;
            this.groupBoxIdentity.TabStop = false;
            this.groupBoxIdentity.Text = "Identity";
            // 
            // labelMiddleName
            // 
            this.labelMiddleName.AutoSize = true;
            this.labelMiddleName.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelMiddleName.Location = new System.Drawing.Point(359, 44);
            this.labelMiddleName.Name = "labelMiddleName";
            this.labelMiddleName.Size = new System.Drawing.Size(82, 25);
            this.labelMiddleName.TabIndex = 2;
            this.labelMiddleName.Text = "Middle:";
            // 
            // labelLastName
            // 
            this.labelLastName.AutoSize = true;
            this.labelLastName.Location = new System.Drawing.Point(623, 44);
            this.labelLastName.Name = "labelLastName";
            this.labelLastName.Size = new System.Drawing.Size(59, 25);
            this.labelLastName.TabIndex = 4;
            this.labelLastName.Text = "Last:";
            // 
            // textBoxMiddleName
            // 
            this.textBoxMiddleName.Location = new System.Drawing.Point(447, 44);
            this.textBoxMiddleName.Name = "textBoxMiddleName";
            this.textBoxMiddleName.Size = new System.Drawing.Size(162, 31);
            this.textBoxMiddleName.TabIndex = 3;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(703, 44);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(267, 31);
            this.textBoxLastName.TabIndex = 5;
            // 
            // labelDateOfBirth
            // 
            this.labelDateOfBirth.AutoSize = true;
            this.labelDateOfBirth.Location = new System.Drawing.Point(17, 96);
            this.labelDateOfBirth.Name = "labelDateOfBirth";
            this.labelDateOfBirth.Size = new System.Drawing.Size(275, 25);
            this.labelDateOfBirth.TabIndex = 6;
            this.labelDateOfBirth.Text = "Date of birth: (mm/dd/yyyy):";
            // 
            // textBoxDateOfBirth
            // 
            this.textBoxDateOfBirth.Location = new System.Drawing.Point(312, 93);
            this.textBoxDateOfBirth.Name = "textBoxDateOfBirth";
            this.textBoxDateOfBirth.Size = new System.Drawing.Size(162, 31);
            this.textBoxDateOfBirth.TabIndex = 7;
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.Location = new System.Drawing.Point(22, 43);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(119, 25);
            this.labelFirstName.TabIndex = 0;
            this.labelFirstName.Text = "First name:";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(147, 43);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(201, 31);
            this.textBoxFirstName.TabIndex = 1;
            // 
            // groupBoxAddress
            // 
            this.groupBoxAddress.Controls.Add(this.labelAddress);
            this.groupBoxAddress.Controls.Add(this.textBoxAddress1);
            this.groupBoxAddress.Controls.Add(this.labelAddress2);
            this.groupBoxAddress.Controls.Add(this.textBoxAddress2);
            this.groupBoxAddress.Controls.Add(this.textBoxZipcode);
            this.groupBoxAddress.Controls.Add(this.textBoxCity);
            this.groupBoxAddress.Controls.Add(this.labelZipcode);
            this.groupBoxAddress.Controls.Add(this.labelCity);
            this.groupBoxAddress.Controls.Add(this.labelState);
            this.groupBoxAddress.Controls.Add(this.comboBoxState);
            this.groupBoxAddress.Location = new System.Drawing.Point(17, 158);
            this.groupBoxAddress.Name = "groupBoxAddress";
            this.groupBoxAddress.Size = new System.Drawing.Size(1041, 129);
            this.groupBoxAddress.TabIndex = 1;
            this.groupBoxAddress.TabStop = false;
            this.groupBoxAddress.Text = "Address";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(25, 34);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(97, 25);
            this.labelAddress.TabIndex = 0;
            this.labelAddress.Text = "Address:";
            // 
            // textBoxAddress1
            // 
            this.textBoxAddress1.Location = new System.Drawing.Point(133, 31);
            this.textBoxAddress1.Name = "textBoxAddress1";
            this.textBoxAddress1.Size = new System.Drawing.Size(360, 31);
            this.textBoxAddress1.TabIndex = 1;
            // 
            // labelAddress2
            // 
            this.labelAddress2.AutoSize = true;
            this.labelAddress2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.labelAddress2.Location = new System.Drawing.Point(535, 34);
            this.labelAddress2.Name = "labelAddress2";
            this.labelAddress2.Size = new System.Drawing.Size(109, 25);
            this.labelAddress2.TabIndex = 2;
            this.labelAddress2.Text = "Address2:";
            this.labelAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxAddress2
            // 
            this.textBoxAddress2.Location = new System.Drawing.Point(663, 30);
            this.textBoxAddress2.Name = "textBoxAddress2";
            this.textBoxAddress2.Size = new System.Drawing.Size(350, 31);
            this.textBoxAddress2.TabIndex = 3;
            // 
            // textBoxZipcode
            // 
            this.textBoxZipcode.Location = new System.Drawing.Point(666, 78);
            this.textBoxZipcode.Name = "textBoxZipcode";
            this.textBoxZipcode.Size = new System.Drawing.Size(162, 31);
            this.textBoxZipcode.TabIndex = 9;
            // 
            // textBoxCity
            // 
            this.textBoxCity.Location = new System.Drawing.Point(133, 78);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(162, 31);
            this.textBoxCity.TabIndex = 5;
            // 
            // labelZipcode
            // 
            this.labelZipcode.AutoSize = true;
            this.labelZipcode.Location = new System.Drawing.Point(549, 81);
            this.labelZipcode.Name = "labelZipcode";
            this.labelZipcode.Size = new System.Drawing.Size(95, 25);
            this.labelZipcode.TabIndex = 8;
            this.labelZipcode.Text = "Zipcode:";
            this.labelZipcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(67, 78);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(55, 25);
            this.labelCity.TabIndex = 4;
            this.labelCity.Text = "City:";
            this.labelCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(328, 78);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(68, 25);
            this.labelState.TabIndex = 6;
            this.labelState.Text = "State:";
            this.labelState.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxState
            // 
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Items.AddRange(new object[] {
            "AL",
            "AK",
            "AZ",
            "AR",
            "CA",
            "CO",
            "CT",
            "DE",
            "FL",
            "GA",
            "HI",
            "ID",
            "IL",
            "IN",
            "IA",
            "KS",
            "KY",
            "LA",
            "ME",
            "MD",
            "MA",
            "MI",
            "MN",
            "MS",
            "MO",
            "MT",
            "NE",
            "NV",
            "NH",
            "NJ",
            "NM",
            "NY",
            "NC",
            "ND",
            "OH",
            "OK",
            "OR",
            "PA",
            "RI",
            "SC",
            "SD",
            "TN",
            "TX",
            "UT",
            "VT",
            "VA",
            "WA",
            "WV",
            "WI",
            "WY"});
            this.comboBoxState.Location = new System.Drawing.Point(402, 75);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(126, 33);
            this.comboBoxState.TabIndex = 7;
            this.comboBoxState.SelectedIndexChanged += new System.EventHandler(this.comboBoxState_SelectedIndexChanged);
            // 
            // groupBoxContactInfo
            // 
            this.groupBoxContactInfo.Controls.Add(this.comboBoxMainContactMethod);
            this.groupBoxContactInfo.Controls.Add(this.labelMainContactMethod);
            this.groupBoxContactInfo.Controls.Add(this.textBoxEmail);
            this.groupBoxContactInfo.Controls.Add(this.textBoxPhone);
            this.groupBoxContactInfo.Controls.Add(this.labelPhone);
            this.groupBoxContactInfo.Controls.Add(this.labelEmail);
            this.groupBoxContactInfo.Location = new System.Drawing.Point(17, 295);
            this.groupBoxContactInfo.Name = "groupBoxContactInfo";
            this.groupBoxContactInfo.Size = new System.Drawing.Size(1041, 135);
            this.groupBoxContactInfo.TabIndex = 2;
            this.groupBoxContactInfo.TabStop = false;
            this.groupBoxContactInfo.Text = "Contact info";
            // 
            // comboBoxMainContactMethod
            // 
            this.comboBoxMainContactMethod.FormattingEnabled = true;
            this.comboBoxMainContactMethod.Items.AddRange(new object[] {
            "Email",
            "Phone"});
            this.comboBoxMainContactMethod.Location = new System.Drawing.Point(243, 78);
            this.comboBoxMainContactMethod.Name = "comboBoxMainContactMethod";
            this.comboBoxMainContactMethod.Size = new System.Drawing.Size(121, 33);
            this.comboBoxMainContactMethod.TabIndex = 5;
            // 
            // labelMainContactMethod
            // 
            this.labelMainContactMethod.AutoSize = true;
            this.labelMainContactMethod.Location = new System.Drawing.Point(10, 81);
            this.labelMainContactMethod.Name = "labelMainContactMethod";
            this.labelMainContactMethod.Size = new System.Drawing.Size(218, 25);
            this.labelMainContactMethod.TabIndex = 4;
            this.labelMainContactMethod.Text = "Main contact method:";
            this.labelMainContactMethod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(433, 34);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(580, 31);
            this.textBoxEmail.TabIndex = 3;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(115, 34);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(217, 31);
            this.textBoxPhone.TabIndex = 1;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(11, 36);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(98, 25);
            this.labelPhone.TabIndex = 0;
            this.labelPhone.Text = "Phone #:";
            this.labelPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(356, 36);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(71, 25);
            this.labelEmail.TabIndex = 2;
            this.labelEmail.Text = "Email:";
            this.labelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPagePrintCheckouts
            // 
            this.tabPagePrintCheckouts.Controls.Add(this.checkBoxPrintOnlyItemsCheckedOutToday);
            this.tabPagePrintCheckouts.Controls.Add(this.textBoxPrintCheckoutMsg);
            this.tabPagePrintCheckouts.Controls.Add(this.buttonPrintItemsCheckedOut);
            this.tabPagePrintCheckouts.Controls.Add(this.textBoxPatronBarcodeForReceipt);
            this.tabPagePrintCheckouts.Controls.Add(this.labelPatronBarcodeForReceipt);
            this.tabPagePrintCheckouts.Controls.Add(this.labelPrintReceiptHeader);
            this.tabPagePrintCheckouts.Location = new System.Drawing.Point(8, 39);
            this.tabPagePrintCheckouts.Name = "tabPagePrintCheckouts";
            this.tabPagePrintCheckouts.Size = new System.Drawing.Size(1085, 901);
            this.tabPagePrintCheckouts.TabIndex = 3;
            this.tabPagePrintCheckouts.Text = "Print Checkouts";
            this.tabPagePrintCheckouts.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrintOnlyItemsCheckedOutToday
            // 
            this.checkBoxPrintOnlyItemsCheckedOutToday.AutoSize = true;
            this.checkBoxPrintOnlyItemsCheckedOutToday.Checked = true;
            this.checkBoxPrintOnlyItemsCheckedOutToday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrintOnlyItemsCheckedOutToday.Location = new System.Drawing.Point(390, 135);
            this.checkBoxPrintOnlyItemsCheckedOutToday.Name = "checkBoxPrintOnlyItemsCheckedOutToday";
            this.checkBoxPrintOnlyItemsCheckedOutToday.Size = new System.Drawing.Size(375, 29);
            this.checkBoxPrintOnlyItemsCheckedOutToday.TabIndex = 3;
            this.checkBoxPrintOnlyItemsCheckedOutToday.Text = "Only print items checked out today";
            this.checkBoxPrintOnlyItemsCheckedOutToday.UseVisualStyleBackColor = true;
            // 
            // textBoxPrintCheckoutMsg
            // 
            this.textBoxPrintCheckoutMsg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxPrintCheckoutMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPrintCheckoutMsg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrintCheckoutMsg.Location = new System.Drawing.Point(89, 263);
            this.textBoxPrintCheckoutMsg.Multiline = true;
            this.textBoxPrintCheckoutMsg.Name = "textBoxPrintCheckoutMsg";
            this.textBoxPrintCheckoutMsg.ReadOnly = true;
            this.textBoxPrintCheckoutMsg.Size = new System.Drawing.Size(877, 175);
            this.textBoxPrintCheckoutMsg.TabIndex = 5;
            // 
            // buttonPrintItemsCheckedOut
            // 
            this.buttonPrintItemsCheckedOut.Location = new System.Drawing.Point(436, 185);
            this.buttonPrintItemsCheckedOut.Name = "buttonPrintItemsCheckedOut";
            this.buttonPrintItemsCheckedOut.Size = new System.Drawing.Size(229, 53);
            this.buttonPrintItemsCheckedOut.TabIndex = 4;
            this.buttonPrintItemsCheckedOut.Text = "Print Receipt";
            this.buttonPrintItemsCheckedOut.UseVisualStyleBackColor = true;
            this.buttonPrintItemsCheckedOut.Click += new System.EventHandler(this.buttonPrintItemsCheckedOut_Click);
            // 
            // textBoxPatronBarcodeForReceipt
            // 
            this.textBoxPatronBarcodeForReceipt.Font = new System.Drawing.Font("Lucida Console", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPatronBarcodeForReceipt.Location = new System.Drawing.Point(390, 81);
            this.textBoxPatronBarcodeForReceipt.Name = "textBoxPatronBarcodeForReceipt";
            this.textBoxPatronBarcodeForReceipt.Size = new System.Drawing.Size(346, 34);
            this.textBoxPatronBarcodeForReceipt.TabIndex = 2;
            // 
            // labelPatronBarcodeForReceipt
            // 
            this.labelPatronBarcodeForReceipt.AutoSize = true;
            this.labelPatronBarcodeForReceipt.Location = new System.Drawing.Point(209, 85);
            this.labelPatronBarcodeForReceipt.Name = "labelPatronBarcodeForReceipt";
            this.labelPatronBarcodeForReceipt.Size = new System.Drawing.Size(165, 25);
            this.labelPatronBarcodeForReceipt.TabIndex = 1;
            this.labelPatronBarcodeForReceipt.Text = "Patron barcode:";
            this.labelPatronBarcodeForReceipt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelPrintReceiptHeader
            // 
            this.labelPrintReceiptHeader.AutoSize = true;
            this.labelPrintReceiptHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrintReceiptHeader.Location = new System.Drawing.Point(192, 20);
            this.labelPrintReceiptHeader.Name = "labelPrintReceiptHeader";
            this.labelPrintReceiptHeader.Size = new System.Drawing.Size(634, 31);
            this.labelPrintReceiptHeader.TabIndex = 0;
            this.labelPrintReceiptHeader.Text = "Print receipt of items checked out by this patron";
            // 
            // tabPagePlaceHold
            // 
            this.tabPagePlaceHold.Controls.Add(this.buttonPlaceHoldsClearInfo);
            this.tabPagePlaceHold.Controls.Add(this.textBoxPlaceHoldMsg);
            this.tabPagePlaceHold.Controls.Add(this.buttonPlaceHoldOnCheckedItems);
            this.tabPagePlaceHold.Controls.Add(this.dataGridViewPlaceHold);
            this.tabPagePlaceHold.Controls.Add(this.buttonPlaceHoldSearch);
            this.tabPagePlaceHold.Controls.Add(this.textBoxPlaceHoldItemSearch);
            this.tabPagePlaceHold.Controls.Add(this.labelPlaceHoldItemSearch);
            this.tabPagePlaceHold.Controls.Add(this.textBoxPlaceHoldPatronBarcode);
            this.tabPagePlaceHold.Controls.Add(this.labelPlaceHoldPatronBarcode);
            this.tabPagePlaceHold.Location = new System.Drawing.Point(8, 39);
            this.tabPagePlaceHold.Name = "tabPagePlaceHold";
            this.tabPagePlaceHold.Size = new System.Drawing.Size(1085, 901);
            this.tabPagePlaceHold.TabIndex = 4;
            this.tabPagePlaceHold.Text = "Place Hold";
            this.tabPagePlaceHold.UseVisualStyleBackColor = true;
            // 
            // buttonPlaceHoldsClearInfo
            // 
            this.buttonPlaceHoldsClearInfo.Location = new System.Drawing.Point(824, 653);
            this.buttonPlaceHoldsClearInfo.Name = "buttonPlaceHoldsClearInfo";
            this.buttonPlaceHoldsClearInfo.Size = new System.Drawing.Size(200, 44);
            this.buttonPlaceHoldsClearInfo.TabIndex = 9;
            this.buttonPlaceHoldsClearInfo.Text = "Clear Info";
            this.buttonPlaceHoldsClearInfo.UseVisualStyleBackColor = true;
            this.buttonPlaceHoldsClearInfo.Click += new System.EventHandler(this.buttonPlaceHoldsClearInfo_Click);
            // 
            // textBoxPlaceHoldMsg
            // 
            this.textBoxPlaceHoldMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPlaceHoldMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlaceHoldMsg.Location = new System.Drawing.Point(23, 715);
            this.textBoxPlaceHoldMsg.Multiline = true;
            this.textBoxPlaceHoldMsg.Name = "textBoxPlaceHoldMsg";
            this.textBoxPlaceHoldMsg.Size = new System.Drawing.Size(1040, 110);
            this.textBoxPlaceHoldMsg.TabIndex = 8;
            // 
            // buttonPlaceHoldOnCheckedItems
            // 
            this.buttonPlaceHoldOnCheckedItems.Location = new System.Drawing.Point(370, 651);
            this.buttonPlaceHoldOnCheckedItems.Name = "buttonPlaceHoldOnCheckedItems";
            this.buttonPlaceHoldOnCheckedItems.Size = new System.Drawing.Size(328, 46);
            this.buttonPlaceHoldOnCheckedItems.TabIndex = 6;
            this.buttonPlaceHoldOnCheckedItems.Text = "Place Holds on Checked Items";
            this.buttonPlaceHoldOnCheckedItems.UseVisualStyleBackColor = true;
            this.buttonPlaceHoldOnCheckedItems.Click += new System.EventHandler(this.buttonPlaceHoldOnCheckedItems_Click);
            // 
            // dataGridViewPlaceHold
            // 
            this.dataGridViewPlaceHold.AllowUserToAddRows = false;
            this.dataGridViewPlaceHold.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPlaceHold.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPlaceHold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPlaceHold.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hold,
            this.Title,
            this.Author,
            this.BibID});
            this.dataGridViewPlaceHold.Location = new System.Drawing.Point(6, 109);
            this.dataGridViewPlaceHold.Name = "dataGridViewPlaceHold";
            this.dataGridViewPlaceHold.RowHeadersVisible = false;
            this.dataGridViewPlaceHold.RowHeadersWidth = 82;
            this.dataGridViewPlaceHold.RowTemplate.Height = 33;
            this.dataGridViewPlaceHold.Size = new System.Drawing.Size(1082, 536);
            this.dataGridViewPlaceHold.TabIndex = 5;
            // 
            // Hold
            // 
            this.Hold.HeaderText = "Hold?";
            this.Hold.MinimumWidth = 10;
            this.Hold.Name = "Hold";
            this.Hold.Width = 75;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.MinimumWidth = 10;
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 670;
            // 
            // Author
            // 
            this.Author.HeaderText = "Author";
            this.Author.MinimumWidth = 10;
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            this.Author.Width = 295;
            // 
            // BibID
            // 
            this.BibID.HeaderText = "BibID";
            this.BibID.MinimumWidth = 10;
            this.BibID.Name = "BibID";
            this.BibID.ReadOnly = true;
            this.BibID.Visible = false;
            this.BibID.Width = 200;
            // 
            // buttonPlaceHoldSearch
            // 
            this.buttonPlaceHoldSearch.Location = new System.Drawing.Point(805, 56);
            this.buttonPlaceHoldSearch.Name = "buttonPlaceHoldSearch";
            this.buttonPlaceHoldSearch.Size = new System.Drawing.Size(204, 38);
            this.buttonPlaceHoldSearch.TabIndex = 4;
            this.buttonPlaceHoldSearch.Text = "Search for items";
            this.buttonPlaceHoldSearch.UseVisualStyleBackColor = true;
            this.buttonPlaceHoldSearch.Click += new System.EventHandler(this.buttonPlaceHoldSearch_Click);
            // 
            // textBoxPlaceHoldItemSearch
            // 
            this.textBoxPlaceHoldItemSearch.Font = new System.Drawing.Font("Lucida Console", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlaceHoldItemSearch.Location = new System.Drawing.Point(346, 60);
            this.textBoxPlaceHoldItemSearch.Name = "textBoxPlaceHoldItemSearch";
            this.textBoxPlaceHoldItemSearch.Size = new System.Drawing.Size(426, 34);
            this.textBoxPlaceHoldItemSearch.TabIndex = 3;
            // 
            // labelPlaceHoldItemSearch
            // 
            this.labelPlaceHoldItemSearch.AutoSize = true;
            this.labelPlaceHoldItemSearch.Location = new System.Drawing.Point(201, 64);
            this.labelPlaceHoldItemSearch.Name = "labelPlaceHoldItemSearch";
            this.labelPlaceHoldItemSearch.Size = new System.Drawing.Size(129, 25);
            this.labelPlaceHoldItemSearch.TabIndex = 2;
            this.labelPlaceHoldItemSearch.Text = "Item search:";
            this.labelPlaceHoldItemSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPlaceHoldPatronBarcode
            // 
            this.textBoxPlaceHoldPatronBarcode.Font = new System.Drawing.Font("Lucida Console", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPlaceHoldPatronBarcode.Location = new System.Drawing.Point(346, 20);
            this.textBoxPlaceHoldPatronBarcode.Name = "textBoxPlaceHoldPatronBarcode";
            this.textBoxPlaceHoldPatronBarcode.Size = new System.Drawing.Size(426, 34);
            this.textBoxPlaceHoldPatronBarcode.TabIndex = 1;
            // 
            // labelPlaceHoldPatronBarcode
            // 
            this.labelPlaceHoldPatronBarcode.AutoSize = true;
            this.labelPlaceHoldPatronBarcode.Location = new System.Drawing.Point(165, 24);
            this.labelPlaceHoldPatronBarcode.Name = "labelPlaceHoldPatronBarcode";
            this.labelPlaceHoldPatronBarcode.Size = new System.Drawing.Size(165, 25);
            this.labelPlaceHoldPatronBarcode.TabIndex = 0;
            this.labelPlaceHoldPatronBarcode.Text = "Patron barcode:";
            this.labelPlaceHoldPatronBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip2
            // 
            this.menuStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1120, 40);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printSampleToolStripMenuItem,
            this.printSampleCheckoutSlipToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(71, 36);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // printSampleToolStripMenuItem
            // 
            this.printSampleToolStripMenuItem.Name = "printSampleToolStripMenuItem";
            this.printSampleToolStripMenuItem.Size = new System.Drawing.Size(436, 44);
            this.printSampleToolStripMenuItem.Text = "&Print Sample Hold Slip";
            this.printSampleToolStripMenuItem.Click += new System.EventHandler(this.printSampleToolStripMenuItem_Click);
            // 
            // printSampleCheckoutSlipToolStripMenuItem
            // 
            this.printSampleCheckoutSlipToolStripMenuItem.Name = "printSampleCheckoutSlipToolStripMenuItem";
            this.printSampleCheckoutSlipToolStripMenuItem.Size = new System.Drawing.Size(436, 44);
            this.printSampleCheckoutSlipToolStripMenuItem.Text = "Print Sample Checkout Slip";
            this.printSampleCheckoutSlipToolStripMenuItem.Click += new System.EventHandler(this.printSampleCheckoutSlipToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(436, 44);
            this.settingsToolStripMenuItem.Text = "&Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(436, 44);
            this.loginToolStripMenuItem.Text = "&Login...";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(436, 44);
            this.logoutToolStripMenuItem.Text = "Log&out";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(436, 44);
            this.restartToolStripMenuItem.Text = "&Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(436, 44);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 1003);
            this.Controls.Add(this.tabControlHolds);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "KohaQuick";
            this.tabControlHolds.ResumeLayout(false);
            this.tabPageTrapHolds.ResumeLayout(false);
            this.tabPageTrapHolds.PerformLayout();
            this.tabPageCheckPIN.ResumeLayout(false);
            this.tabPageCheckPIN.PerformLayout();
            this.tabPageAddPatron.ResumeLayout(false);
            this.tabPageAddPatron.PerformLayout();
            this.groupBoxLibraryCard.ResumeLayout(false);
            this.groupBoxLibraryCard.PerformLayout();
            this.groupBoxIdentity.ResumeLayout(false);
            this.groupBoxIdentity.PerformLayout();
            this.groupBoxAddress.ResumeLayout(false);
            this.groupBoxAddress.PerformLayout();
            this.groupBoxContactInfo.ResumeLayout(false);
            this.groupBoxContactInfo.PerformLayout();
            this.tabPagePrintCheckouts.ResumeLayout(false);
            this.tabPagePrintCheckouts.PerformLayout();
            this.tabPagePlaceHold.ResumeLayout(false);
            this.tabPagePlaceHold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPlaceHold)).EndInit();
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
        private System.Windows.Forms.TabPage tabPageCheckPIN;
        private System.Windows.Forms.Label labelPatronPIN;
        private System.Windows.Forms.TextBox textBoxPatronBarcode;
        private System.Windows.Forms.Label labelPatronBarcode;
        private System.Windows.Forms.Button buttonCheckPatronPIN;
        private System.Windows.Forms.TextBox textBoxPatronPIN;
        private System.Windows.Forms.TextBox textBoxPatronPINMsg;
        private System.Windows.Forms.TabPage tabPageAddPatron;
        private System.Windows.Forms.Button buttonGenerateRandom;
        private System.Windows.Forms.Button buttonAddPatron;
        private System.Windows.Forms.GroupBox groupBoxLibraryCard;
        private System.Windows.Forms.TextBox textBoxPIN2;
        private System.Windows.Forms.TextBox textBoxPIN;
        private System.Windows.Forms.Label labelPIN2;
        private System.Windows.Forms.TextBox textBoxLibraryCardBarcode;
        private System.Windows.Forms.Label labelLibraryCardBarcode;
        private System.Windows.Forms.Label labelPIN;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxDateOfBirth;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.Label labelZipcode;
        private System.Windows.Forms.Label labelDateOfBirth;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.TextBox textBoxMiddleName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Label labelLastName;
        private System.Windows.Forms.Label labelMiddleName;
        private System.Windows.Forms.GroupBox groupBoxIdentity;
        private System.Windows.Forms.GroupBox groupBoxAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textBoxAddress1;
        private System.Windows.Forms.Label labelAddress2;
        private System.Windows.Forms.TextBox textBoxAddress2;
        private System.Windows.Forms.TextBox textBoxZipcode;
        private System.Windows.Forms.GroupBox groupBoxContactInfo;
        private System.Windows.Forms.TextBox textBoxAddPatronMsg;
        private System.Windows.Forms.Button buttonClearInfo;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPagePrintCheckouts;
        private System.Windows.Forms.Label labelPrintReceiptHeader;
        private System.Windows.Forms.Button buttonPrintItemsCheckedOut;
        private System.Windows.Forms.TextBox textBoxPatronBarcodeForReceipt;
        private System.Windows.Forms.Label labelPatronBarcodeForReceipt;
        private System.Windows.Forms.TextBox textBoxPrintCheckoutMsg;
        private System.Windows.Forms.CheckBox checkBoxPrintOnlyItemsCheckedOutToday;
        private System.Windows.Forms.TabPage tabPagePlaceHold;
        private System.Windows.Forms.TextBox textBoxPlaceHoldItemSearch;
        private System.Windows.Forms.Label labelPlaceHoldItemSearch;
        private System.Windows.Forms.TextBox textBoxPlaceHoldPatronBarcode;
        private System.Windows.Forms.Label labelPlaceHoldPatronBarcode;
        private System.Windows.Forms.DataGridView dataGridViewPlaceHold;
        private System.Windows.Forms.Button buttonPlaceHoldSearch;
        private System.Windows.Forms.TextBox textBoxPlaceHoldMsg;
        private System.Windows.Forms.Button buttonPlaceHoldOnCheckedItems;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Hold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn BibID;
        private Button buttonPlaceHoldsClearInfo;
        private ToolStripMenuItem printSampleCheckoutSlipToolStripMenuItem;
        private ComboBox comboBoxMainContactMethod;
        private Label labelMainContactMethod;
        private TextBox textBoxCircNotes;
        private Label labelCircNotes;
        private Label labelLibraryForAddPatron;
        private ComboBox comboBoxLibraryForAddPatron;
    }
}

