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
            this.SuspendLayout();
            // 
            // buttonFontPatron
            // 
            this.buttonFontPatron.Location = new System.Drawing.Point(31, 73);
            this.buttonFontPatron.Name = "buttonFontPatron";
            this.buttonFontPatron.Size = new System.Drawing.Size(157, 55);
            this.buttonFontPatron.TabIndex = 2;
            this.buttonFontPatron.Text = "Font - Patron";
            this.buttonFontPatron.UseVisualStyleBackColor = true;
            this.buttonFontPatron.Click += new System.EventHandler(this.buttonFontPatron_Click);
            // 
            // labelUpperLeft
            // 
            this.labelUpperLeft.AutoSize = true;
            this.labelUpperLeft.Location = new System.Drawing.Point(35, 163);
            this.labelUpperLeft.Name = "labelUpperLeft";
            this.labelUpperLeft.Size = new System.Drawing.Size(118, 25);
            this.labelUpperLeft.TabIndex = 4;
            this.labelUpperLeft.Text = "Upper Left:";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(159, 160);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(50, 31);
            this.textBoxX.TabIndex = 5;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(231, 160);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(50, 31);
            this.textBoxY.TabIndex = 6;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(406, 324);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 41);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonFontOther
            // 
            this.buttonFontOther.Location = new System.Drawing.Point(231, 73);
            this.buttonFontOther.Name = "buttonFontOther";
            this.buttonFontOther.Size = new System.Drawing.Size(157, 55);
            this.buttonFontOther.TabIndex = 3;
            this.buttonFontOther.Text = "Font - Other";
            this.buttonFontOther.UseVisualStyleBackColor = true;
            this.buttonFontOther.Click += new System.EventHandler(this.buttonFontOther_Click);
            // 
            // buttonPrinter
            // 
            this.buttonPrinter.Location = new System.Drawing.Point(31, 12);
            this.buttonPrinter.Name = "buttonPrinter";
            this.buttonPrinter.Size = new System.Drawing.Size(157, 47);
            this.buttonPrinter.TabIndex = 0;
            this.buttonPrinter.Text = "Printer";
            this.buttonPrinter.UseVisualStyleBackColor = true;
            this.buttonPrinter.Click += new System.EventHandler(this.buttonPrinter_Click);
            // 
            // checkBoxPrintToPDF
            // 
            this.checkBoxPrintToPDF.AutoSize = true;
            this.checkBoxPrintToPDF.Location = new System.Drawing.Point(231, 22);
            this.checkBoxPrintToPDF.Name = "checkBoxPrintToPDF";
            this.checkBoxPrintToPDF.Size = new System.Drawing.Size(160, 29);
            this.checkBoxPrintToPDF.TabIndex = 1;
            this.checkBoxPrintToPDF.Text = "Print to PDF";
            this.checkBoxPrintToPDF.UseVisualStyleBackColor = true;
            // 
            // SettingsDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 394);
            this.Controls.Add(this.checkBoxPrintToPDF);
            this.Controls.Add(this.buttonPrinter);
            this.Controls.Add(this.buttonFontOther);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.labelUpperLeft);
            this.Controls.Add(this.buttonFontPatron);
            this.Name = "SettingsDlg";
            this.Text = "PrintHold Settings";
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
    }
}