namespace KohaQuick
{
    partial class SettingsDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFontPatron = new System.Windows.Forms.Button();
            this.labelUpperLeft = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonFontOther = new System.Windows.Forms.Button();
            this.buttonPrinter = new System.Windows.Forms.Button();
            this.checkBoxPrintToPDF = new System.Windows.Forms.CheckBox();
            this.labelPageWidth = new System.Windows.Forms.Label();
            this.textBoxPageWidth = new System.Windows.Forms.TextBox();
            this.labelFontInfoPatron = new System.Windows.Forms.Label();
            this.groupBoxFontPatron = new System.Windows.Forms.GroupBox();
            this.textBoxLineSpacingPatron = new System.Windows.Forms.TextBox();
            this.labelLineSpacingPatron = new System.Windows.Forms.Label();
            this.labelComma = new System.Windows.Forms.Label();
            this.groupBoxFontOther = new System.Windows.Forms.GroupBox();
            this.textBoxLineSpacingOther = new System.Windows.Forms.TextBox();
            this.labelLineSpacingOther = new System.Windows.Forms.Label();
            this.labelFontInfoOther = new System.Windows.Forms.Label();
            this.checkBoxPrintConfig = new System.Windows.Forms.CheckBox();
            this.labelPrinter = new System.Windows.Forms.Label();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageURLs = new System.Windows.Forms.TabPage();
            this.textBoxDefaultPickupLibrary = new System.Windows.Forms.TextBox();
            this.labelDefaultPickupLibrary = new System.Windows.Forms.Label();
            this.textBoxDefaultPatronType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxURLs = new System.Windows.Forms.GroupBox();
            this.textBoxPatronURL = new System.Windows.Forms.TextBox();
            this.textBoxStaffURL = new System.Windows.Forms.TextBox();
            this.labelPatronURL = new System.Windows.Forms.Label();
            this.labelStaffURL = new System.Windows.Forms.Label();
            this.tabPagePrint = new System.Windows.Forms.TabPage();
            this.tabPageBrowser = new System.Windows.Forms.TabPage();
            this.groupBoxInitialBrowserState = new System.Windows.Forms.GroupBox();
            this.radioButtonBrowserMinimized = new System.Windows.Forms.RadioButton();
            this.radioButtonBrowserHidden = new System.Windows.Forms.RadioButton();
            this.radioButtonBrowserNormal = new System.Windows.Forms.RadioButton();
            this.groupBoxBrowser = new System.Windows.Forms.GroupBox();
            this.textBoxBrowserX = new System.Windows.Forms.TextBox();
            this.textBoxBrowserHeight = new System.Windows.Forms.TextBox();
            this.textBoxBrowserWidth = new System.Windows.Forms.TextBox();
            this.labelBrowserHeight = new System.Windows.Forms.Label();
            this.labelBrowserX = new System.Windows.Forms.Label();
            this.labelBrowserWidth = new System.Windows.Forms.Label();
            this.tabPagePrintCheckouts = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCheckoutFieldDown = new System.Windows.Forms.Button();
            this.buttonCheckoutFieldUp = new System.Windows.Forms.Button();
            this.labelCheckoutConfigured = new System.Windows.Forms.Label();
            this.labelCheckoutAvailable = new System.Windows.Forms.Label();
            this.buttonCheckoutFieldRemove = new System.Windows.Forms.Button();
            this.buttonCheckoutFieldAdd = new System.Windows.Forms.Button();
            this.listBoxCheckoutFieldsActual = new System.Windows.Forms.ListBox();
            this.listBoxCheckoutFieldsAvailable = new System.Windows.Forms.ListBox();
            this.checkBoxBreakOnWords = new System.Windows.Forms.CheckBox();
            this.checkBoxIndentLineContinuations = new System.Windows.Forms.CheckBox();
            this.tabPageHoldSlips = new System.Windows.Forms.TabPage();
            this.groupBoxFields = new System.Windows.Forms.GroupBox();
            this.buttonFieldDown = new System.Windows.Forms.Button();
            this.buttonFieldUp = new System.Windows.Forms.Button();
            this.labelConfigured = new System.Windows.Forms.Label();
            this.labelAvailable = new System.Windows.Forms.Label();
            this.buttonFieldRemove = new System.Windows.Forms.Button();
            this.buttonFieldAdd = new System.Windows.Forms.Button();
            this.listBoxFieldsActual = new System.Windows.Forms.ListBox();
            this.listBoxFieldsAvailable = new System.Windows.Forms.ListBox();
            this.groupBoxFontPatron.SuspendLayout();
            this.groupBoxFontOther.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabPageURLs.SuspendLayout();
            this.groupBoxURLs.SuspendLayout();
            this.tabPagePrint.SuspendLayout();
            this.tabPageBrowser.SuspendLayout();
            this.groupBoxInitialBrowserState.SuspendLayout();
            this.groupBoxBrowser.SuspendLayout();
            this.tabPagePrintCheckouts.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageHoldSlips.SuspendLayout();
            this.groupBoxFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonFontPatron
            // 
            this.buttonFontPatron.Location = new System.Drawing.Point(20, 37);
            this.buttonFontPatron.Name = "buttonFontPatron";
            this.buttonFontPatron.Size = new System.Drawing.Size(113, 55);
            this.buttonFontPatron.TabIndex = 0;
            this.buttonFontPatron.Text = "Change";
            this.buttonFontPatron.UseVisualStyleBackColor = true;
            this.buttonFontPatron.Click += new System.EventHandler(this.buttonFontPatron_Click);
            // 
            // labelUpperLeft
            // 
            this.labelUpperLeft.AutoSize = true;
            this.labelUpperLeft.Location = new System.Drawing.Point(60, 147);
            this.labelUpperLeft.Name = "labelUpperLeft";
            this.labelUpperLeft.Size = new System.Drawing.Size(118, 25);
            this.labelUpperLeft.TabIndex = 3;
            this.labelUpperLeft.Text = "Upper Left:";
            this.labelUpperLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(194, 144);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(50, 31);
            this.textBoxX.TabIndex = 4;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(268, 144);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(50, 31);
            this.textBoxY.TabIndex = 6;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(412, 769);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 41);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonFontOther
            // 
            this.buttonFontOther.Location = new System.Drawing.Point(20, 39);
            this.buttonFontOther.Name = "buttonFontOther";
            this.buttonFontOther.Size = new System.Drawing.Size(113, 55);
            this.buttonFontOther.TabIndex = 0;
            this.buttonFontOther.Text = "Change";
            this.buttonFontOther.UseVisualStyleBackColor = true;
            this.buttonFontOther.Click += new System.EventHandler(this.buttonFontOther_Click);
            // 
            // buttonPrinter
            // 
            this.buttonPrinter.Location = new System.Drawing.Point(40, 40);
            this.buttonPrinter.Name = "buttonPrinter";
            this.buttonPrinter.Size = new System.Drawing.Size(113, 47);
            this.buttonPrinter.TabIndex = 0;
            this.buttonPrinter.Text = "Printer";
            this.buttonPrinter.UseVisualStyleBackColor = true;
            this.buttonPrinter.Click += new System.EventHandler(this.buttonPrinter_Click);
            // 
            // checkBoxPrintToPDF
            // 
            this.checkBoxPrintToPDF.AutoSize = true;
            this.checkBoxPrintToPDF.Location = new System.Drawing.Point(56, 105);
            this.checkBoxPrintToPDF.Name = "checkBoxPrintToPDF";
            this.checkBoxPrintToPDF.Size = new System.Drawing.Size(160, 29);
            this.checkBoxPrintToPDF.TabIndex = 2;
            this.checkBoxPrintToPDF.Text = "Print to PDF";
            this.checkBoxPrintToPDF.UseVisualStyleBackColor = true;
            // 
            // labelPageWidth
            // 
            this.labelPageWidth.AutoSize = true;
            this.labelPageWidth.Location = new System.Drawing.Point(51, 188);
            this.labelPageWidth.Name = "labelPageWidth";
            this.labelPageWidth.Size = new System.Drawing.Size(129, 25);
            this.labelPageWidth.TabIndex = 7;
            this.labelPageWidth.Text = "Page Width:";
            this.labelPageWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPageWidth
            // 
            this.textBoxPageWidth.Location = new System.Drawing.Point(194, 185);
            this.textBoxPageWidth.Name = "textBoxPageWidth";
            this.textBoxPageWidth.Size = new System.Drawing.Size(65, 31);
            this.textBoxPageWidth.TabIndex = 7;
            // 
            // labelFontInfoPatron
            // 
            this.labelFontInfoPatron.AutoSize = true;
            this.labelFontInfoPatron.Location = new System.Drawing.Point(154, 52);
            this.labelFontInfoPatron.Name = "labelFontInfoPatron";
            this.labelFontInfoPatron.Size = new System.Drawing.Size(229, 25);
            this.labelFontInfoPatron.TabIndex = 1;
            this.labelFontInfoPatron.Text = "Patron font information";
            // 
            // groupBoxFontPatron
            // 
            this.groupBoxFontPatron.Controls.Add(this.textBoxLineSpacingPatron);
            this.groupBoxFontPatron.Controls.Add(this.labelLineSpacingPatron);
            this.groupBoxFontPatron.Controls.Add(this.labelFontInfoPatron);
            this.groupBoxFontPatron.Controls.Add(this.buttonFontPatron);
            this.groupBoxFontPatron.Location = new System.Drawing.Point(20, 241);
            this.groupBoxFontPatron.Name = "groupBoxFontPatron";
            this.groupBoxFontPatron.Size = new System.Drawing.Size(440, 155);
            this.groupBoxFontPatron.TabIndex = 8;
            this.groupBoxFontPatron.TabStop = false;
            this.groupBoxFontPatron.Text = "Patron font";
            // 
            // textBoxLineSpacingPatron
            // 
            this.textBoxLineSpacingPatron.Location = new System.Drawing.Point(174, 101);
            this.textBoxLineSpacingPatron.Name = "textBoxLineSpacingPatron";
            this.textBoxLineSpacingPatron.Size = new System.Drawing.Size(65, 31);
            this.textBoxLineSpacingPatron.TabIndex = 3;
            // 
            // labelLineSpacingPatron
            // 
            this.labelLineSpacingPatron.AutoSize = true;
            this.labelLineSpacingPatron.Location = new System.Drawing.Point(21, 107);
            this.labelLineSpacingPatron.Name = "labelLineSpacingPatron";
            this.labelLineSpacingPatron.Size = new System.Drawing.Size(143, 25);
            this.labelLineSpacingPatron.TabIndex = 2;
            this.labelLineSpacingPatron.Text = "Line Spacing:";
            // 
            // labelComma
            // 
            this.labelComma.AutoSize = true;
            this.labelComma.Location = new System.Drawing.Point(247, 150);
            this.labelComma.Name = "labelComma";
            this.labelComma.Size = new System.Drawing.Size(18, 25);
            this.labelComma.TabIndex = 5;
            this.labelComma.Text = ",";
            // 
            // groupBoxFontOther
            // 
            this.groupBoxFontOther.Controls.Add(this.textBoxLineSpacingOther);
            this.groupBoxFontOther.Controls.Add(this.labelLineSpacingOther);
            this.groupBoxFontOther.Controls.Add(this.labelFontInfoOther);
            this.groupBoxFontOther.Controls.Add(this.buttonFontOther);
            this.groupBoxFontOther.Location = new System.Drawing.Point(20, 422);
            this.groupBoxFontOther.Name = "groupBoxFontOther";
            this.groupBoxFontOther.Size = new System.Drawing.Size(440, 155);
            this.groupBoxFontOther.TabIndex = 9;
            this.groupBoxFontOther.TabStop = false;
            this.groupBoxFontOther.Text = "Other font";
            // 
            // textBoxLineSpacingOther
            // 
            this.textBoxLineSpacingOther.Location = new System.Drawing.Point(174, 108);
            this.textBoxLineSpacingOther.Name = "textBoxLineSpacingOther";
            this.textBoxLineSpacingOther.Size = new System.Drawing.Size(65, 31);
            this.textBoxLineSpacingOther.TabIndex = 3;
            // 
            // labelLineSpacingOther
            // 
            this.labelLineSpacingOther.AutoSize = true;
            this.labelLineSpacingOther.Location = new System.Drawing.Point(21, 110);
            this.labelLineSpacingOther.Name = "labelLineSpacingOther";
            this.labelLineSpacingOther.Size = new System.Drawing.Size(143, 25);
            this.labelLineSpacingOther.TabIndex = 2;
            this.labelLineSpacingOther.Text = "Line Spacing:";
            // 
            // labelFontInfoOther
            // 
            this.labelFontInfoOther.AutoSize = true;
            this.labelFontInfoOther.Location = new System.Drawing.Point(154, 54);
            this.labelFontInfoOther.Name = "labelFontInfoOther";
            this.labelFontInfoOther.Size = new System.Drawing.Size(219, 25);
            this.labelFontInfoOther.TabIndex = 1;
            this.labelFontInfoOther.Text = "Other font information";
            // 
            // checkBoxPrintConfig
            // 
            this.checkBoxPrintConfig.AutoSize = true;
            this.checkBoxPrintConfig.Location = new System.Drawing.Point(28, 667);
            this.checkBoxPrintConfig.Name = "checkBoxPrintConfig";
            this.checkBoxPrintConfig.Size = new System.Drawing.Size(156, 29);
            this.checkBoxPrintConfig.TabIndex = 12;
            this.checkBoxPrintConfig.Text = "Print Config";
            this.checkBoxPrintConfig.UseVisualStyleBackColor = true;
            // 
            // labelPrinter
            // 
            this.labelPrinter.Location = new System.Drawing.Point(174, 51);
            this.labelPrinter.Name = "labelPrinter";
            this.labelPrinter.Size = new System.Drawing.Size(450, 25);
            this.labelPrinter.TabIndex = 1;
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabPageURLs);
            this.tabControlSettings.Controls.Add(this.tabPageBrowser);
            this.tabControlSettings.Controls.Add(this.tabPagePrint);
            this.tabControlSettings.Controls.Add(this.tabPageHoldSlips);
            this.tabControlSettings.Controls.Add(this.tabPagePrintCheckouts);
            this.tabControlSettings.Location = new System.Drawing.Point(12, 1);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(869, 754);
            this.tabControlSettings.TabIndex = 0;
            // 
            // tabPageURLs
            // 
            this.tabPageURLs.Controls.Add(this.textBoxDefaultPickupLibrary);
            this.tabPageURLs.Controls.Add(this.labelDefaultPickupLibrary);
            this.tabPageURLs.Controls.Add(this.textBoxDefaultPatronType);
            this.tabPageURLs.Controls.Add(this.label1);
            this.tabPageURLs.Controls.Add(this.groupBoxURLs);
            this.tabPageURLs.Location = new System.Drawing.Point(8, 39);
            this.tabPageURLs.Name = "tabPageURLs";
            this.tabPageURLs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageURLs.Size = new System.Drawing.Size(853, 707);
            this.tabPageURLs.TabIndex = 0;
            this.tabPageURLs.Text = "Koha";
            this.tabPageURLs.UseVisualStyleBackColor = true;
            // 
            // textBoxDefaultPickupLibrary
            // 
            this.textBoxDefaultPickupLibrary.Font = new System.Drawing.Font("Consolas", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDefaultPickupLibrary.Location = new System.Drawing.Point(279, 247);
            this.textBoxDefaultPickupLibrary.Name = "textBoxDefaultPickupLibrary";
            this.textBoxDefaultPickupLibrary.Size = new System.Drawing.Size(345, 32);
            this.textBoxDefaultPickupLibrary.TabIndex = 4;
            // 
            // labelDefaultPickupLibrary
            // 
            this.labelDefaultPickupLibrary.AutoSize = true;
            this.labelDefaultPickupLibrary.Location = new System.Drawing.Point(42, 247);
            this.labelDefaultPickupLibrary.Name = "labelDefaultPickupLibrary";
            this.labelDefaultPickupLibrary.Size = new System.Drawing.Size(220, 25);
            this.labelDefaultPickupLibrary.TabIndex = 3;
            this.labelDefaultPickupLibrary.Text = "Default pickup library:";
            this.labelDefaultPickupLibrary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxDefaultPatronType
            // 
            this.textBoxDefaultPatronType.Font = new System.Drawing.Font("Consolas", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDefaultPatronType.Location = new System.Drawing.Point(279, 196);
            this.textBoxDefaultPatronType.Name = "textBoxDefaultPatronType";
            this.textBoxDefaultPatronType.Size = new System.Drawing.Size(162, 32);
            this.textBoxDefaultPatronType.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Default patron type:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBoxURLs
            // 
            this.groupBoxURLs.Controls.Add(this.textBoxPatronURL);
            this.groupBoxURLs.Controls.Add(this.textBoxStaffURL);
            this.groupBoxURLs.Controls.Add(this.labelPatronURL);
            this.groupBoxURLs.Controls.Add(this.labelStaffURL);
            this.groupBoxURLs.Location = new System.Drawing.Point(17, 20);
            this.groupBoxURLs.Name = "groupBoxURLs";
            this.groupBoxURLs.Size = new System.Drawing.Size(806, 147);
            this.groupBoxURLs.TabIndex = 0;
            this.groupBoxURLs.TabStop = false;
            this.groupBoxURLs.Text = "Koha URLs";
            // 
            // textBoxPatronURL
            // 
            this.textBoxPatronURL.Location = new System.Drawing.Point(170, 87);
            this.textBoxPatronURL.Name = "textBoxPatronURL";
            this.textBoxPatronURL.Size = new System.Drawing.Size(610, 31);
            this.textBoxPatronURL.TabIndex = 3;
            // 
            // textBoxStaffURL
            // 
            this.textBoxStaffURL.Location = new System.Drawing.Point(170, 34);
            this.textBoxStaffURL.Name = "textBoxStaffURL";
            this.textBoxStaffURL.Size = new System.Drawing.Size(610, 31);
            this.textBoxStaffURL.TabIndex = 1;
            // 
            // labelPatronURL
            // 
            this.labelPatronURL.AutoSize = true;
            this.labelPatronURL.Location = new System.Drawing.Point(20, 87);
            this.labelPatronURL.Name = "labelPatronURL";
            this.labelPatronURL.Size = new System.Drawing.Size(129, 25);
            this.labelPatronURL.TabIndex = 2;
            this.labelPatronURL.Text = "Patron URL:";
            this.labelPatronURL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelStaffURL
            // 
            this.labelStaffURL.AutoSize = true;
            this.labelStaffURL.Location = new System.Drawing.Point(39, 37);
            this.labelStaffURL.Name = "labelStaffURL";
            this.labelStaffURL.Size = new System.Drawing.Size(110, 25);
            this.labelStaffURL.TabIndex = 0;
            this.labelStaffURL.Text = "Staff URL:";
            this.labelStaffURL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabPagePrint
            // 
            this.tabPagePrint.Controls.Add(this.checkBoxIndentLineContinuations);
            this.tabPagePrint.Controls.Add(this.checkBoxBreakOnWords);
            this.tabPagePrint.Controls.Add(this.labelPrinter);
            this.tabPagePrint.Controls.Add(this.groupBoxFontOther);
            this.tabPagePrint.Controls.Add(this.groupBoxFontPatron);
            this.tabPagePrint.Controls.Add(this.checkBoxPrintConfig);
            this.tabPagePrint.Controls.Add(this.labelUpperLeft);
            this.tabPagePrint.Controls.Add(this.labelComma);
            this.tabPagePrint.Controls.Add(this.textBoxX);
            this.tabPagePrint.Controls.Add(this.textBoxPageWidth);
            this.tabPagePrint.Controls.Add(this.textBoxY);
            this.tabPagePrint.Controls.Add(this.labelPageWidth);
            this.tabPagePrint.Controls.Add(this.buttonPrinter);
            this.tabPagePrint.Controls.Add(this.checkBoxPrintToPDF);
            this.tabPagePrint.Location = new System.Drawing.Point(8, 39);
            this.tabPagePrint.Name = "tabPagePrint";
            this.tabPagePrint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrint.Size = new System.Drawing.Size(853, 707);
            this.tabPagePrint.TabIndex = 1;
            this.tabPagePrint.Text = "Print";
            this.tabPagePrint.UseVisualStyleBackColor = true;
            // 
            // tabPageBrowser
            // 
            this.tabPageBrowser.Controls.Add(this.groupBoxInitialBrowserState);
            this.tabPageBrowser.Controls.Add(this.groupBoxBrowser);
            this.tabPageBrowser.Location = new System.Drawing.Point(8, 39);
            this.tabPageBrowser.Name = "tabPageBrowser";
            this.tabPageBrowser.Size = new System.Drawing.Size(853, 707);
            this.tabPageBrowser.TabIndex = 2;
            this.tabPageBrowser.Text = "Browser";
            this.tabPageBrowser.UseVisualStyleBackColor = true;
            // 
            // groupBoxInitialBrowserState
            // 
            this.groupBoxInitialBrowserState.Controls.Add(this.radioButtonBrowserMinimized);
            this.groupBoxInitialBrowserState.Controls.Add(this.radioButtonBrowserHidden);
            this.groupBoxInitialBrowserState.Controls.Add(this.radioButtonBrowserNormal);
            this.groupBoxInitialBrowserState.Location = new System.Drawing.Point(17, 211);
            this.groupBoxInitialBrowserState.Name = "groupBoxInitialBrowserState";
            this.groupBoxInitialBrowserState.Size = new System.Drawing.Size(806, 160);
            this.groupBoxInitialBrowserState.TabIndex = 1;
            this.groupBoxInitialBrowserState.TabStop = false;
            this.groupBoxInitialBrowserState.Text = "Initial Browser State";
            // 
            // radioButtonBrowserMinimized
            // 
            this.radioButtonBrowserMinimized.AutoSize = true;
            this.radioButtonBrowserMinimized.Location = new System.Drawing.Point(32, 76);
            this.radioButtonBrowserMinimized.Name = "radioButtonBrowserMinimized";
            this.radioButtonBrowserMinimized.Size = new System.Drawing.Size(457, 29);
            this.radioButtonBrowserMinimized.TabIndex = 1;
            this.radioButtonBrowserMinimized.TabStop = true;
            this.radioButtonBrowserMinimized.Text = "Minimized (do not use; under development)";
            this.radioButtonBrowserMinimized.UseVisualStyleBackColor = true;
            // 
            // radioButtonBrowserHidden
            // 
            this.radioButtonBrowserHidden.AutoSize = true;
            this.radioButtonBrowserHidden.Location = new System.Drawing.Point(32, 113);
            this.radioButtonBrowserHidden.Name = "radioButtonBrowserHidden";
            this.radioButtonBrowserHidden.Size = new System.Drawing.Size(111, 29);
            this.radioButtonBrowserHidden.TabIndex = 2;
            this.radioButtonBrowserHidden.TabStop = true;
            this.radioButtonBrowserHidden.Text = "Hidden";
            this.radioButtonBrowserHidden.UseVisualStyleBackColor = true;
            // 
            // radioButtonBrowserNormal
            // 
            this.radioButtonBrowserNormal.AutoSize = true;
            this.radioButtonBrowserNormal.Location = new System.Drawing.Point(32, 39);
            this.radioButtonBrowserNormal.Name = "radioButtonBrowserNormal";
            this.radioButtonBrowserNormal.Size = new System.Drawing.Size(111, 29);
            this.radioButtonBrowserNormal.TabIndex = 0;
            this.radioButtonBrowserNormal.TabStop = true;
            this.radioButtonBrowserNormal.Text = "Normal";
            this.radioButtonBrowserNormal.UseVisualStyleBackColor = true;
            // 
            // groupBoxBrowser
            // 
            this.groupBoxBrowser.Controls.Add(this.textBoxBrowserX);
            this.groupBoxBrowser.Controls.Add(this.textBoxBrowserHeight);
            this.groupBoxBrowser.Controls.Add(this.textBoxBrowserWidth);
            this.groupBoxBrowser.Controls.Add(this.labelBrowserHeight);
            this.groupBoxBrowser.Controls.Add(this.labelBrowserX);
            this.groupBoxBrowser.Controls.Add(this.labelBrowserWidth);
            this.groupBoxBrowser.Location = new System.Drawing.Point(17, 24);
            this.groupBoxBrowser.Name = "groupBoxBrowser";
            this.groupBoxBrowser.Size = new System.Drawing.Size(806, 163);
            this.groupBoxBrowser.TabIndex = 0;
            this.groupBoxBrowser.TabStop = false;
            this.groupBoxBrowser.Text = "Size and Position of Automated Browsers";
            // 
            // textBoxBrowserX
            // 
            this.textBoxBrowserX.Location = new System.Drawing.Point(146, 119);
            this.textBoxBrowserX.Name = "textBoxBrowserX";
            this.textBoxBrowserX.Size = new System.Drawing.Size(81, 31);
            this.textBoxBrowserX.TabIndex = 5;
            // 
            // textBoxBrowserHeight
            // 
            this.textBoxBrowserHeight.Location = new System.Drawing.Point(146, 79);
            this.textBoxBrowserHeight.Name = "textBoxBrowserHeight";
            this.textBoxBrowserHeight.Size = new System.Drawing.Size(81, 31);
            this.textBoxBrowserHeight.TabIndex = 3;
            // 
            // textBoxBrowserWidth
            // 
            this.textBoxBrowserWidth.Location = new System.Drawing.Point(146, 39);
            this.textBoxBrowserWidth.Name = "textBoxBrowserWidth";
            this.textBoxBrowserWidth.Size = new System.Drawing.Size(81, 31);
            this.textBoxBrowserWidth.TabIndex = 1;
            // 
            // labelBrowserHeight
            // 
            this.labelBrowserHeight.Location = new System.Drawing.Point(16, 82);
            this.labelBrowserHeight.Name = "labelBrowserHeight";
            this.labelBrowserHeight.Size = new System.Drawing.Size(115, 25);
            this.labelBrowserHeight.TabIndex = 2;
            this.labelBrowserHeight.Text = "Height:";
            this.labelBrowserHeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelBrowserX
            // 
            this.labelBrowserX.AutoSize = true;
            this.labelBrowserX.Location = new System.Drawing.Point(16, 122);
            this.labelBrowserX.Name = "labelBrowserX";
            this.labelBrowserX.Size = new System.Drawing.Size(115, 25);
            this.labelBrowserX.TabIndex = 4;
            this.labelBrowserX.Text = "X Position:";
            this.labelBrowserX.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelBrowserWidth
            // 
            this.labelBrowserWidth.Location = new System.Drawing.Point(27, 39);
            this.labelBrowserWidth.Name = "labelBrowserWidth";
            this.labelBrowserWidth.Size = new System.Drawing.Size(104, 31);
            this.labelBrowserWidth.TabIndex = 0;
            this.labelBrowserWidth.Text = "Width:";
            this.labelBrowserWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPagePrintCheckouts
            // 
            this.tabPagePrintCheckouts.Controls.Add(this.groupBox1);
            this.tabPagePrintCheckouts.Location = new System.Drawing.Point(8, 39);
            this.tabPagePrintCheckouts.Name = "tabPagePrintCheckouts";
            this.tabPagePrintCheckouts.Size = new System.Drawing.Size(853, 707);
            this.tabPagePrintCheckouts.TabIndex = 3;
            this.tabPagePrintCheckouts.Text = "Checkout Slips";
            this.tabPagePrintCheckouts.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCheckoutFieldDown);
            this.groupBox1.Controls.Add(this.buttonCheckoutFieldUp);
            this.groupBox1.Controls.Add(this.labelCheckoutConfigured);
            this.groupBox1.Controls.Add(this.labelCheckoutAvailable);
            this.groupBox1.Controls.Add(this.buttonCheckoutFieldRemove);
            this.groupBox1.Controls.Add(this.buttonCheckoutFieldAdd);
            this.groupBox1.Controls.Add(this.listBoxCheckoutFieldsActual);
            this.groupBox1.Controls.Add(this.listBoxCheckoutFieldsAvailable);
            this.groupBox1.Location = new System.Drawing.Point(31, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 471);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fields on Checkout Slips";
            // 
            // buttonCheckoutFieldDown
            // 
            this.buttonCheckoutFieldDown.Location = new System.Drawing.Point(580, 255);
            this.buttonCheckoutFieldDown.Name = "buttonCheckoutFieldDown";
            this.buttonCheckoutFieldDown.Size = new System.Drawing.Size(37, 48);
            this.buttonCheckoutFieldDown.TabIndex = 7;
            this.buttonCheckoutFieldDown.Text = "↓";
            this.buttonCheckoutFieldDown.UseVisualStyleBackColor = true;
            this.buttonCheckoutFieldDown.Click += new System.EventHandler(this.buttonCheckoutFieldDown_Click);
            // 
            // buttonCheckoutFieldUp
            // 
            this.buttonCheckoutFieldUp.Location = new System.Drawing.Point(580, 150);
            this.buttonCheckoutFieldUp.Name = "buttonCheckoutFieldUp";
            this.buttonCheckoutFieldUp.Size = new System.Drawing.Size(37, 48);
            this.buttonCheckoutFieldUp.TabIndex = 6;
            this.buttonCheckoutFieldUp.Text = "↑";
            this.buttonCheckoutFieldUp.UseVisualStyleBackColor = true;
            this.buttonCheckoutFieldUp.Click += new System.EventHandler(this.buttonCheckoutFieldUp_Click);
            // 
            // labelCheckoutConfigured
            // 
            this.labelCheckoutConfigured.AutoSize = true;
            this.labelCheckoutConfigured.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckoutConfigured.Location = new System.Drawing.Point(388, 34);
            this.labelCheckoutConfigured.Name = "labelCheckoutConfigured";
            this.labelCheckoutConfigured.Size = new System.Drawing.Size(127, 25);
            this.labelCheckoutConfigured.TabIndex = 4;
            this.labelCheckoutConfigured.Text = "Configured";
            // 
            // labelCheckoutAvailable
            // 
            this.labelCheckoutAvailable.AutoSize = true;
            this.labelCheckoutAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCheckoutAvailable.Location = new System.Drawing.Point(63, 34);
            this.labelCheckoutAvailable.Name = "labelCheckoutAvailable";
            this.labelCheckoutAvailable.Size = new System.Drawing.Size(109, 25);
            this.labelCheckoutAvailable.TabIndex = 0;
            this.labelCheckoutAvailable.Text = "Available";
            // 
            // buttonCheckoutFieldRemove
            // 
            this.buttonCheckoutFieldRemove.Location = new System.Drawing.Point(258, 255);
            this.buttonCheckoutFieldRemove.Name = "buttonCheckoutFieldRemove";
            this.buttonCheckoutFieldRemove.Size = new System.Drawing.Size(52, 37);
            this.buttonCheckoutFieldRemove.TabIndex = 3;
            this.buttonCheckoutFieldRemove.Text = "←";
            this.buttonCheckoutFieldRemove.UseVisualStyleBackColor = true;
            this.buttonCheckoutFieldRemove.Click += new System.EventHandler(this.buttonCheckoutFieldRemove_Click);
            // 
            // buttonCheckoutFieldAdd
            // 
            this.buttonCheckoutFieldAdd.Location = new System.Drawing.Point(256, 150);
            this.buttonCheckoutFieldAdd.Name = "buttonCheckoutFieldAdd";
            this.buttonCheckoutFieldAdd.Size = new System.Drawing.Size(52, 37);
            this.buttonCheckoutFieldAdd.TabIndex = 2;
            this.buttonCheckoutFieldAdd.Text = "→";
            this.buttonCheckoutFieldAdd.UseVisualStyleBackColor = true;
            this.buttonCheckoutFieldAdd.Click += new System.EventHandler(this.buttonCheckoutFieldAdd_Click);
            // 
            // listBoxCheckoutFieldsActual
            // 
            this.listBoxCheckoutFieldsActual.FormattingEnabled = true;
            this.listBoxCheckoutFieldsActual.ItemHeight = 25;
            this.listBoxCheckoutFieldsActual.Location = new System.Drawing.Point(332, 75);
            this.listBoxCheckoutFieldsActual.Name = "listBoxCheckoutFieldsActual";
            this.listBoxCheckoutFieldsActual.Size = new System.Drawing.Size(228, 329);
            this.listBoxCheckoutFieldsActual.TabIndex = 5;
            // 
            // listBoxCheckoutFieldsAvailable
            // 
            this.listBoxCheckoutFieldsAvailable.FormattingEnabled = true;
            this.listBoxCheckoutFieldsAvailable.ItemHeight = 25;
            this.listBoxCheckoutFieldsAvailable.Location = new System.Drawing.Point(6, 75);
            this.listBoxCheckoutFieldsAvailable.Name = "listBoxCheckoutFieldsAvailable";
            this.listBoxCheckoutFieldsAvailable.Size = new System.Drawing.Size(228, 329);
            this.listBoxCheckoutFieldsAvailable.TabIndex = 1;
            // 
            // checkBoxBreakOnWords
            // 
            this.checkBoxBreakOnWords.AutoSize = true;
            this.checkBoxBreakOnWords.Location = new System.Drawing.Point(28, 591);
            this.checkBoxBreakOnWords.Name = "checkBoxBreakOnWords";
            this.checkBoxBreakOnWords.Size = new System.Drawing.Size(393, 29);
            this.checkBoxBreakOnWords.TabIndex = 10;
            this.checkBoxBreakOnWords.Text = "Break long lines on word boundaries";
            this.checkBoxBreakOnWords.UseVisualStyleBackColor = true;
            // 
            // checkBoxIndentLineContinuations
            // 
            this.checkBoxIndentLineContinuations.AutoSize = true;
            this.checkBoxIndentLineContinuations.Location = new System.Drawing.Point(28, 629);
            this.checkBoxIndentLineContinuations.Name = "checkBoxIndentLineContinuations";
            this.checkBoxIndentLineContinuations.Size = new System.Drawing.Size(359, 29);
            this.checkBoxIndentLineContinuations.TabIndex = 11;
            this.checkBoxIndentLineContinuations.Text = "Indent continuations of long lines";
            this.checkBoxIndentLineContinuations.UseVisualStyleBackColor = true;
            // 
            // tabPageHoldSlips
            // 
            this.tabPageHoldSlips.Controls.Add(this.groupBoxFields);
            this.tabPageHoldSlips.Location = new System.Drawing.Point(8, 39);
            this.tabPageHoldSlips.Name = "tabPageHoldSlips";
            this.tabPageHoldSlips.Size = new System.Drawing.Size(853, 707);
            this.tabPageHoldSlips.TabIndex = 4;
            this.tabPageHoldSlips.Text = "Hold Slips";
            this.tabPageHoldSlips.UseVisualStyleBackColor = true;
            // 
            // groupBoxFields
            // 
            this.groupBoxFields.Controls.Add(this.buttonFieldDown);
            this.groupBoxFields.Controls.Add(this.buttonFieldUp);
            this.groupBoxFields.Controls.Add(this.labelConfigured);
            this.groupBoxFields.Controls.Add(this.labelAvailable);
            this.groupBoxFields.Controls.Add(this.buttonFieldRemove);
            this.groupBoxFields.Controls.Add(this.buttonFieldAdd);
            this.groupBoxFields.Controls.Add(this.listBoxFieldsActual);
            this.groupBoxFields.Controls.Add(this.listBoxFieldsAvailable);
            this.groupBoxFields.Location = new System.Drawing.Point(31, 26);
            this.groupBoxFields.Name = "groupBoxFields";
            this.groupBoxFields.Size = new System.Drawing.Size(623, 471);
            this.groupBoxFields.TabIndex = 14;
            this.groupBoxFields.TabStop = false;
            this.groupBoxFields.Text = "Fields on Hold Slips";
            // 
            // buttonFieldDown
            // 
            this.buttonFieldDown.Location = new System.Drawing.Point(580, 255);
            this.buttonFieldDown.Name = "buttonFieldDown";
            this.buttonFieldDown.Size = new System.Drawing.Size(37, 48);
            this.buttonFieldDown.TabIndex = 7;
            this.buttonFieldDown.Text = "↓";
            this.buttonFieldDown.UseVisualStyleBackColor = true;
            // 
            // buttonFieldUp
            // 
            this.buttonFieldUp.Location = new System.Drawing.Point(580, 150);
            this.buttonFieldUp.Name = "buttonFieldUp";
            this.buttonFieldUp.Size = new System.Drawing.Size(37, 48);
            this.buttonFieldUp.TabIndex = 6;
            this.buttonFieldUp.Text = "↑";
            this.buttonFieldUp.UseVisualStyleBackColor = true;
            // 
            // labelConfigured
            // 
            this.labelConfigured.AutoSize = true;
            this.labelConfigured.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfigured.Location = new System.Drawing.Point(388, 34);
            this.labelConfigured.Name = "labelConfigured";
            this.labelConfigured.Size = new System.Drawing.Size(127, 25);
            this.labelConfigured.TabIndex = 4;
            this.labelConfigured.Text = "Configured";
            // 
            // labelAvailable
            // 
            this.labelAvailable.AutoSize = true;
            this.labelAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAvailable.Location = new System.Drawing.Point(63, 34);
            this.labelAvailable.Name = "labelAvailable";
            this.labelAvailable.Size = new System.Drawing.Size(109, 25);
            this.labelAvailable.TabIndex = 0;
            this.labelAvailable.Text = "Available";
            // 
            // buttonFieldRemove
            // 
            this.buttonFieldRemove.Location = new System.Drawing.Point(258, 255);
            this.buttonFieldRemove.Name = "buttonFieldRemove";
            this.buttonFieldRemove.Size = new System.Drawing.Size(52, 37);
            this.buttonFieldRemove.TabIndex = 3;
            this.buttonFieldRemove.Text = "←";
            this.buttonFieldRemove.UseVisualStyleBackColor = true;
            // 
            // buttonFieldAdd
            // 
            this.buttonFieldAdd.Location = new System.Drawing.Point(256, 150);
            this.buttonFieldAdd.Name = "buttonFieldAdd";
            this.buttonFieldAdd.Size = new System.Drawing.Size(52, 37);
            this.buttonFieldAdd.TabIndex = 2;
            this.buttonFieldAdd.Text = "→";
            this.buttonFieldAdd.UseVisualStyleBackColor = true;
            // 
            // listBoxFieldsActual
            // 
            this.listBoxFieldsActual.FormattingEnabled = true;
            this.listBoxFieldsActual.ItemHeight = 25;
            this.listBoxFieldsActual.Location = new System.Drawing.Point(332, 75);
            this.listBoxFieldsActual.Name = "listBoxFieldsActual";
            this.listBoxFieldsActual.Size = new System.Drawing.Size(228, 329);
            this.listBoxFieldsActual.TabIndex = 5;
            // 
            // listBoxFieldsAvailable
            // 
            this.listBoxFieldsAvailable.FormattingEnabled = true;
            this.listBoxFieldsAvailable.ItemHeight = 25;
            this.listBoxFieldsAvailable.Location = new System.Drawing.Point(6, 75);
            this.listBoxFieldsAvailable.Name = "listBoxFieldsAvailable";
            this.listBoxFieldsAvailable.Size = new System.Drawing.Size(228, 329);
            this.listBoxFieldsAvailable.TabIndex = 1;
            // 
            // SettingsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 827);
            this.Controls.Add(this.tabControlSettings);
            this.Controls.Add(this.buttonOK);
            this.Name = "SettingsDlg";
            this.Text = "KohaQuick Settings";
            this.groupBoxFontPatron.ResumeLayout(false);
            this.groupBoxFontPatron.PerformLayout();
            this.groupBoxFontOther.ResumeLayout(false);
            this.groupBoxFontOther.PerformLayout();
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageURLs.ResumeLayout(false);
            this.tabPageURLs.PerformLayout();
            this.groupBoxURLs.ResumeLayout(false);
            this.groupBoxURLs.PerformLayout();
            this.tabPagePrint.ResumeLayout(false);
            this.tabPagePrint.PerformLayout();
            this.tabPageBrowser.ResumeLayout(false);
            this.groupBoxInitialBrowserState.ResumeLayout(false);
            this.groupBoxInitialBrowserState.PerformLayout();
            this.groupBoxBrowser.ResumeLayout(false);
            this.groupBoxBrowser.PerformLayout();
            this.tabPagePrintCheckouts.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageHoldSlips.ResumeLayout(false);
            this.groupBoxFields.ResumeLayout(false);
            this.groupBoxFields.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFontPatron;
        private System.Windows.Forms.Label labelUpperLeft;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonFontOther;
        private System.Windows.Forms.Button buttonPrinter;
        private System.Windows.Forms.CheckBox checkBoxPrintToPDF;
        private System.Windows.Forms.Label labelPageWidth;
        private System.Windows.Forms.TextBox textBoxPageWidth;
        private System.Windows.Forms.Label labelFontInfoPatron;
        private System.Windows.Forms.GroupBox groupBoxFontPatron;
        private System.Windows.Forms.TextBox textBoxLineSpacingPatron;
        private System.Windows.Forms.Label labelLineSpacingPatron;
        private System.Windows.Forms.Label labelComma;
        private System.Windows.Forms.GroupBox groupBoxFontOther;
        private System.Windows.Forms.Label labelLineSpacingOther;
        private System.Windows.Forms.Label labelFontInfoOther;
        private System.Windows.Forms.TextBox textBoxLineSpacingOther;
        private System.Windows.Forms.CheckBox checkBoxPrintConfig;
        private System.Windows.Forms.Label labelPrinter;
        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageURLs;
        private System.Windows.Forms.TabPage tabPagePrint;
        private System.Windows.Forms.GroupBox groupBoxURLs;
        private System.Windows.Forms.TextBox textBoxPatronURL;
        private System.Windows.Forms.TextBox textBoxStaffURL;
        private System.Windows.Forms.Label labelPatronURL;
        private System.Windows.Forms.Label labelStaffURL;
        private System.Windows.Forms.TabPage tabPageBrowser;
        private System.Windows.Forms.GroupBox groupBoxBrowser;
        private System.Windows.Forms.Label labelBrowserWidth;
        private System.Windows.Forms.TextBox textBoxBrowserX;
        private System.Windows.Forms.TextBox textBoxBrowserHeight;
        private System.Windows.Forms.TextBox textBoxBrowserWidth;
        private System.Windows.Forms.Label labelBrowserHeight;
        private System.Windows.Forms.Label labelBrowserX;
        private System.Windows.Forms.GroupBox groupBoxInitialBrowserState;
        private System.Windows.Forms.RadioButton radioButtonBrowserMinimized;
        private System.Windows.Forms.RadioButton radioButtonBrowserHidden;
        private System.Windows.Forms.RadioButton radioButtonBrowserNormal;
        private System.Windows.Forms.TabPage tabPagePrintCheckouts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCheckoutFieldDown;
        private System.Windows.Forms.Button buttonCheckoutFieldUp;
        private System.Windows.Forms.Label labelCheckoutConfigured;
        private System.Windows.Forms.Label labelCheckoutAvailable;
        private System.Windows.Forms.Button buttonCheckoutFieldRemove;
        private System.Windows.Forms.Button buttonCheckoutFieldAdd;
        private System.Windows.Forms.ListBox listBoxCheckoutFieldsActual;
        private System.Windows.Forms.ListBox listBoxCheckoutFieldsAvailable;
        private System.Windows.Forms.TextBox textBoxDefaultPatronType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDefaultPickupLibrary;
        private System.Windows.Forms.Label labelDefaultPickupLibrary;
        private System.Windows.Forms.CheckBox checkBoxBreakOnWords;
        private System.Windows.Forms.CheckBox checkBoxIndentLineContinuations;
        private System.Windows.Forms.TabPage tabPageHoldSlips;
        private System.Windows.Forms.GroupBox groupBoxFields;
        private System.Windows.Forms.Button buttonFieldDown;
        private System.Windows.Forms.Button buttonFieldUp;
        private System.Windows.Forms.Label labelConfigured;
        private System.Windows.Forms.Label labelAvailable;
        private System.Windows.Forms.Button buttonFieldRemove;
        private System.Windows.Forms.Button buttonFieldAdd;
        private System.Windows.Forms.ListBox listBoxFieldsActual;
        private System.Windows.Forms.ListBox listBoxFieldsAvailable;
    }
}