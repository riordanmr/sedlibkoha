namespace KohaQuick {
    partial class FormDebug {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDebug));
            this.textBoxMsgs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxMsgs
            // 
            this.textBoxMsgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMsgs.Location = new System.Drawing.Point(0, 0);
            this.textBoxMsgs.MaxLength = 65535;
            this.textBoxMsgs.Multiline = true;
            this.textBoxMsgs.Name = "textBoxMsgs";
            this.textBoxMsgs.ReadOnly = true;
            this.textBoxMsgs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMsgs.Size = new System.Drawing.Size(1130, 684);
            this.textBoxMsgs.TabIndex = 0;
            // 
            // FormDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 684);
            this.Controls.Add(this.textBoxMsgs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDebug";
            this.Text = "Debug Log";
            this.Load += new System.EventHandler(this.FormDebug_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMsgs;
    }
}