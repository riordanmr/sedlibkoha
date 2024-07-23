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
            this.groupBoxFields = new System.Windows.Forms.GroupBox();
            this.buttonFieldDown = new System.Windows.Forms.Button();
            this.buttonFieldUp = new System.Windows.Forms.Button();
            this.labelConfigured = new System.Windows.Forms.Label();
            this.labelAvailable = new System.Windows.Forms.Label();
            this.buttonFieldRemove = new System.Windows.Forms.Button();
            this.buttonFieldAdd = new System.Windows.Forms.Button();
            this.listBoxFieldsActual = new System.Windows.Forms.ListBox();
            this.listBoxFieldsAvailable = new System.Windows.Forms.ListBox();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageURLs = new System.Windows.Forms.TabPage();
            this.tabPagePrint = new System.Windows.Forms.TabPage();
            this.groupBoxURLs = new System.Windows.Forms.GroupBox();
            this.labelStaffURL = new System.Windows.Forms.Label();
            this.labelPatronURL = new System.Windows.Forms.Label();
            this.textBoxStaffURL = new System.Windows.Forms.TextBox();
            this.textBoxPatronURL = new System.Windows.Forms.TextBox();
            this.groupBoxFontPatron.SuspendLayout();
            this.groupBoxFontOther.SuspendLayout();
            this.groupBoxFields.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabPageURLs.SuspendLayout();
            this.tabPagePrint.SuspendLayout();
            this.groupBoxURLs.SuspendLayout();
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
            this.buttonOK.Location = new System.Drawing.Point(569, 771);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 41);
            this.buttonOK.TabIndex = 0;
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
            this.textBoxPageWidth.TabIndex = 8;
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
            this.groupBoxFontPatron.Location = new System.Drawing.Point(20, 245);
            this.groupBoxFontPatron.Name = "groupBoxFontPatron";
            this.groupBoxFontPatron.Size = new System.Drawing.Size(440, 155);
            this.groupBoxFontPatron.TabIndex = 9;
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
            this.groupBoxFontOther.Location = new System.Drawing.Point(20, 432);
            this.groupBoxFontOther.Name = "groupBoxFontOther";
            this.groupBoxFontOther.Size = new System.Drawing.Size(440, 155);
            this.groupBoxFontOther.TabIndex = 10;
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
            this.checkBoxPrintConfig.Location = new System.Drawing.Point(28, 606);
            this.checkBoxPrintConfig.Name = "checkBoxPrintConfig";
            this.checkBoxPrintConfig.Size = new System.Drawing.Size(156, 29);
            this.checkBoxPrintConfig.TabIndex = 11;
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
            this.groupBoxFields.Location = new System.Drawing.Point(506, 116);
            this.groupBoxFields.Name = "groupBoxFields";
            this.groupBoxFields.Size = new System.Drawing.Size(623, 471);
            this.groupBoxFields.TabIndex = 12;
            this.groupBoxFields.TabStop = false;
            this.groupBoxFields.Text = "Fields";
            // 
            // buttonFieldDown
            // 
            this.buttonFieldDown.Location = new System.Drawing.Point(580, 255);
            this.buttonFieldDown.Name = "buttonFieldDown";
            this.buttonFieldDown.Size = new System.Drawing.Size(37, 48);
            this.buttonFieldDown.TabIndex = 7;
            this.buttonFieldDown.Text = "↓";
            this.buttonFieldDown.UseVisualStyleBackColor = true;
            this.buttonFieldDown.Click += new System.EventHandler(this.buttonFieldDown_Click);
            // 
            // buttonFieldUp
            // 
            this.buttonFieldUp.Location = new System.Drawing.Point(580, 150);
            this.buttonFieldUp.Name = "buttonFieldUp";
            this.buttonFieldUp.Size = new System.Drawing.Size(37, 48);
            this.buttonFieldUp.TabIndex = 6;
            this.buttonFieldUp.Text = "↑";
            this.buttonFieldUp.UseVisualStyleBackColor = true;
            this.buttonFieldUp.Click += new System.EventHandler(this.buttonFieldUp_Click);
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
            this.buttonFieldRemove.Click += new System.EventHandler(this.buttonFieldRemove_Click);
            // 
            // buttonFieldAdd
            // 
            this.buttonFieldAdd.Location = new System.Drawing.Point(256, 150);
            this.buttonFieldAdd.Name = "buttonFieldAdd";
            this.buttonFieldAdd.Size = new System.Drawing.Size(52, 37);
            this.buttonFieldAdd.TabIndex = 2;
            this.buttonFieldAdd.Text = "→";
            this.buttonFieldAdd.UseVisualStyleBackColor = true;
            this.buttonFieldAdd.Click += new System.EventHandler(this.buttonFieldAdd_Click);
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
            // tabControlSettings
            // 
            this.tabControlSettings.Controls.Add(this.tabPageURLs);
            this.tabControlSettings.Controls.Add(this.tabPagePrint);
            this.tabControlSettings.Location = new System.Drawing.Point(12, 1);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(1210, 754);
            this.tabControlSettings.TabIndex = 14;
            // 
            // tabPageURLs
            // 
            this.tabPageURLs.Controls.Add(this.groupBoxURLs);
            this.tabPageURLs.Location = new System.Drawing.Point(8, 39);
            this.tabPageURLs.Name = "tabPageURLs";
            this.tabPageURLs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageURLs.Size = new System.Drawing.Size(1194, 707);
            this.tabPageURLs.TabIndex = 0;
            this.tabPageURLs.Text = "URLs";
            this.tabPageURLs.UseVisualStyleBackColor = true;
            // 
            // tabPagePrint
            // 
            this.tabPagePrint.Controls.Add(this.labelPrinter);
            this.tabPagePrint.Controls.Add(this.groupBoxFields);
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
            this.tabPagePrint.Size = new System.Drawing.Size(1194, 707);
            this.tabPagePrint.TabIndex = 1;
            this.tabPagePrint.Text = "Print";
            this.tabPagePrint.UseVisualStyleBackColor = true;
            // 
            // groupBoxURLs
            // 
            this.groupBoxURLs.Controls.Add(this.textBoxPatronURL);
            this.groupBoxURLs.Controls.Add(this.textBoxStaffURL);
            this.groupBoxURLs.Controls.Add(this.labelPatronURL);
            this.groupBoxURLs.Controls.Add(this.labelStaffURL);
            this.groupBoxURLs.Location = new System.Drawing.Point(17, 20);
            this.groupBoxURLs.Name = "groupBoxURLs";
            this.groupBoxURLs.Size = new System.Drawing.Size(1157, 169);
            this.groupBoxURLs.TabIndex = 0;
            this.groupBoxURLs.TabStop = false;
            this.groupBoxURLs.Text = "Koha URLs";
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
            // textBoxStaffURL
            // 
            this.textBoxStaffURL.Location = new System.Drawing.Point(170, 34);
            this.textBoxStaffURL.Name = "textBoxStaffURL";
            this.textBoxStaffURL.Size = new System.Drawing.Size(710, 31);
            this.textBoxStaffURL.TabIndex = 1;
            // 
            // textBoxPatronURL
            // 
            this.textBoxPatronURL.Location = new System.Drawing.Point(170, 87);
            this.textBoxPatronURL.Name = "textBoxPatronURL";
            this.textBoxPatronURL.Size = new System.Drawing.Size(710, 31);
            this.textBoxPatronURL.TabIndex = 3;
            // 
            // SettingsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 827);
            this.Controls.Add(this.tabControlSettings);
            this.Controls.Add(this.buttonOK);
            this.Name = "SettingsDlg";
            this.Text = "KohaQuick Settings";
            this.groupBoxFontPatron.ResumeLayout(false);
            this.groupBoxFontPatron.PerformLayout();
            this.groupBoxFontOther.ResumeLayout(false);
            this.groupBoxFontOther.PerformLayout();
            this.groupBoxFields.ResumeLayout(false);
            this.groupBoxFields.PerformLayout();
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageURLs.ResumeLayout(false);
            this.tabPagePrint.ResumeLayout(false);
            this.tabPagePrint.PerformLayout();
            this.groupBoxURLs.ResumeLayout(false);
            this.groupBoxURLs.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBoxFields;
        private System.Windows.Forms.ListBox listBoxFieldsActual;
        private System.Windows.Forms.ListBox listBoxFieldsAvailable;
        private System.Windows.Forms.Button buttonFieldAdd;
        private System.Windows.Forms.Button buttonFieldRemove;
        private System.Windows.Forms.Label labelConfigured;
        private System.Windows.Forms.Label labelAvailable;
        private System.Windows.Forms.Button buttonFieldUp;
        private System.Windows.Forms.Button buttonFieldDown;
        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageURLs;
        private System.Windows.Forms.TabPage tabPagePrint;
        private System.Windows.Forms.GroupBox groupBoxURLs;
        private System.Windows.Forms.TextBox textBoxPatronURL;
        private System.Windows.Forms.TextBox textBoxStaffURL;
        private System.Windows.Forms.Label labelPatronURL;
        private System.Windows.Forms.Label labelStaffURL;
    }
}