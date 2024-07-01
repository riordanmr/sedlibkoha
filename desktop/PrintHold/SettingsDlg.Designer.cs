namespace PrintHold
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
            this.labelFontInfoOther = new System.Windows.Forms.Label();
            this.labelLineSpacingOther = new System.Windows.Forms.Label();
            this.textBoxLineSpacingOther = new System.Windows.Forms.TextBox();
            this.groupBoxFontPatron.SuspendLayout();
            this.groupBoxFontOther.SuspendLayout();
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
            this.labelUpperLeft.Location = new System.Drawing.Point(71, 73);
            this.labelUpperLeft.Name = "labelUpperLeft";
            this.labelUpperLeft.Size = new System.Drawing.Size(118, 25);
            this.labelUpperLeft.TabIndex = 5;
            this.labelUpperLeft.Text = "Upper Left:";
            this.labelUpperLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(205, 70);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(50, 31);
            this.textBoxX.TabIndex = 2;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(279, 70);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(50, 31);
            this.textBoxY.TabIndex = 4;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(329, 532);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 41);
            this.buttonOK.TabIndex = 9;
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
            this.buttonPrinter.Location = new System.Drawing.Point(51, 12);
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
            this.checkBoxPrintToPDF.Location = new System.Drawing.Point(208, 22);
            this.checkBoxPrintToPDF.Name = "checkBoxPrintToPDF";
            this.checkBoxPrintToPDF.Size = new System.Drawing.Size(160, 29);
            this.checkBoxPrintToPDF.TabIndex = 1;
            this.checkBoxPrintToPDF.Text = "Print to PDF";
            this.checkBoxPrintToPDF.UseVisualStyleBackColor = true;
            // 
            // labelPageWidth
            // 
            this.labelPageWidth.AutoSize = true;
            this.labelPageWidth.Location = new System.Drawing.Point(62, 114);
            this.labelPageWidth.Name = "labelPageWidth";
            this.labelPageWidth.Size = new System.Drawing.Size(129, 25);
            this.labelPageWidth.TabIndex = 5;
            this.labelPageWidth.Text = "Page Width:";
            this.labelPageWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxPageWidth
            // 
            this.textBoxPageWidth.Location = new System.Drawing.Point(205, 111);
            this.textBoxPageWidth.Name = "textBoxPageWidth";
            this.textBoxPageWidth.Size = new System.Drawing.Size(65, 31);
            this.textBoxPageWidth.TabIndex = 6;
            // 
            // labelFontPatron
            // 
            this.labelFontInfoPatron.AutoSize = true;
            this.labelFontInfoPatron.Location = new System.Drawing.Point(154, 52);
            this.labelFontInfoPatron.Name = "labelFontPatron";
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
            this.groupBoxFontPatron.Location = new System.Drawing.Point(31, 171);
            this.groupBoxFontPatron.Name = "groupBoxFontPatron";
            this.groupBoxFontPatron.Size = new System.Drawing.Size(630, 155);
            this.groupBoxFontPatron.TabIndex = 7;
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
            this.labelComma.Location = new System.Drawing.Point(258, 76);
            this.labelComma.Name = "labelComma";
            this.labelComma.Size = new System.Drawing.Size(18, 25);
            this.labelComma.TabIndex = 3;
            this.labelComma.Text = ",";
            // 
            // groupBoxFontOther
            // 
            this.groupBoxFontOther.Controls.Add(this.textBoxLineSpacingOther);
            this.groupBoxFontOther.Controls.Add(this.labelLineSpacingOther);
            this.groupBoxFontOther.Controls.Add(this.labelFontInfoOther);
            this.groupBoxFontOther.Controls.Add(this.buttonFontOther);
            this.groupBoxFontOther.Location = new System.Drawing.Point(31, 358);
            this.groupBoxFontOther.Name = "groupBoxFontOther";
            this.groupBoxFontOther.Size = new System.Drawing.Size(630, 155);
            this.groupBoxFontOther.TabIndex = 8;
            this.groupBoxFontOther.TabStop = false;
            this.groupBoxFontOther.Text = "Other font";
            // 
            // labelOtherFontInfo
            // 
            this.labelFontInfoOther.AutoSize = true;
            this.labelFontInfoOther.Location = new System.Drawing.Point(154, 54);
            this.labelFontInfoOther.Name = "labelOtherFontInfo";
            this.labelFontInfoOther.Size = new System.Drawing.Size(219, 25);
            this.labelFontInfoOther.TabIndex = 1;
            this.labelFontInfoOther.Text = "Other font information";
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
            // textBoxLineSpacingOther
            // 
            this.textBoxLineSpacingOther.Location = new System.Drawing.Point(174, 108);
            this.textBoxLineSpacingOther.Name = "textBoxLineSpacingOther";
            this.textBoxLineSpacingOther.Size = new System.Drawing.Size(65, 31);
            this.textBoxLineSpacingOther.TabIndex = 3;
            // 
            // SettingsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 592);
            this.Controls.Add(this.labelComma);
            this.Controls.Add(this.textBoxPageWidth);
            this.Controls.Add(this.labelPageWidth);
            this.Controls.Add(this.checkBoxPrintToPDF);
            this.Controls.Add(this.buttonPrinter);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.labelUpperLeft);
            this.Controls.Add(this.groupBoxFontPatron);
            this.Controls.Add(this.groupBoxFontOther);
            this.Name = "SettingsDlg";
            this.Text = "PrintHold Settings";
            this.groupBoxFontPatron.ResumeLayout(false);
            this.groupBoxFontPatron.PerformLayout();
            this.groupBoxFontOther.ResumeLayout(false);
            this.groupBoxFontOther.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}