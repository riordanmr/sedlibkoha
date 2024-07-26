// PrintHold - program to print a library hold slip, for the Koha ILS.
// Mark Riordan  2024-06-26

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using Newtonsoft.Json;

namespace KohaQuick {
    public class HoldSlip {
        public string Patron { get; set; } = "";
        public string Currentdatetime { get; set; } = "";
        public string Library { get; set; } = "";
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string Barcode { get; set; } = "";
        public string Callnumber { get; set; } = "";
        public string Expdate { get; set; } = "";

        public void InitSample() {
            Patron = "BRUNGARIA, THEODORE REINHOLD";
            Currentdatetime = "06/26/2024 10:26";
            Library = "Sedona Public Library";
            Title = "The reign of George III, 1760-1815";
            Author = "Watson, Steven J.";
            Barcode = "12345678901234";
            Callnumber = "941.073";
            Expdate = "07/03/2024";
        }

    }

    public class PrintImpl {
        public Settings settings;

        public HoldSlip holdSlip;

        public PrintImpl(Settings parmSettings) {
            settings = parmSettings;
        }

        public const string FIELD_PATRON = "Patron";
        public const string FIELD_CURRENTDATETIME = "Current date/time";
        public const string FIELD_LIBRARY = "Library";
        public const string FIELD_TITLE = "Title";
        public const string FIELD_AUTHOR = "Author";
        public const string FIELD_BARCODE = "Barcode";
        public const string FIELD_CALLNUMBER = "Call number";
        public const string FIELD_EXPDATE = "Expdate";
        public const string FIELD_BLANKLINE = "Blank line";

        public string[] GetFieldsAvailable() {
            return new string[] { FIELD_EXPDATE, FIELD_PATRON, FIELD_CURRENTDATETIME,
            FIELD_LIBRARY, FIELD_TITLE, FIELD_AUTHOR, FIELD_BARCODE, FIELD_CALLNUMBER,
            FIELD_BLANKLINE};
        }

        public void ShowMsg(string msg) {
            Program.FormDebug.AddDebugLine(msg);
        }

        public string PrintSlip() {
            string reply = "";

            PrintDocument printDocument = new PrintDocument();

            // Set the printer name. Make sure the name matches exactly.
            string printerName = settings.Printer;
            printDocument.PrinterSettings.PrinterName = printerName;
            printDocument.PrinterSettings.PrintToFile = settings.PrintToPDF;
            string pdfOutputFileName = "KohaQuickOut.pdf";
            printDocument.PrinterSettings.PrintFileName = pdfOutputFileName;

            // Handle the PrintPage event to specify what to print.
            printDocument.PrintPage += new PrintPageEventHandler(PrintPageHandler);
            // Handle the EndPrint event to determine when the print job has completed.
            printDocument.EndPrint += new PrintEventHandler(PrintEndHandler);

            try {
                // Print the document.
                printDocument.Print();
                reply = $"Printed OK to {printerName}";
                if (settings.PrintToPDF) {
                    reply += $" on {pdfOutputFileName}";
                }
                ShowMsg(reply);
            } catch (Exception ex) {
                reply = "Error: " + ex.Message;
                ShowMsg(reply);
            }
            return reply;
        }

        public void PrintSample() {
            string filePath = "holdslip.json";
            ShowMsg("Printing sample slip. Looking for " + filePath);
            string jsonStr = null;
            bool fileRead = false;
            int itry = 0;
            while (!fileRead && itry++ < 5) {
                try {
                    jsonStr = File.ReadAllText(filePath);
                    fileRead = true; // If reading succeeds, set flag to true to exit the loop
                } catch (FileNotFoundException) {
                    filePath = "../" + filePath; // Prepend "../" to try the next path in the loop
                    ShowMsg($"File not found. Trying {filePath}");
                } catch (Exception ex) {
                    ShowMsg($"Error reading file: {ex.Message}");
                    break; // Exit the loop if an unexpected error occurs
                }
            }
            if (null != jsonStr && "" != jsonStr) {
                holdSlip = JsonConvert.DeserializeObject<HoldSlip>(jsonStr);
            } else {
                Program.FormDebug.AddDebugLine("Using default values for sample slip.");
                holdSlip = new HoldSlip();
                holdSlip.InitSample();
            }
            PrintSlip();
        }

        private void PrintLine(string msg, PrintPageEventArgs e, Font font, float lineSpacing, int x, ref int y) {
            int printableWidthInPixels;
            if (settings.PageWidth > 0) {
                // The user has specified a manual override for the page width.
                printableWidthInPixels = settings.PageWidth;
            } else {
                // Convert MarginBounds.Width from hundredths of an inch to pixels
                // Note: this doesn't work well with certain values of Graphics.PageUnit.
                float dpiX = e.Graphics.DpiX;
                printableWidthInPixels = (int)((e.MarginBounds.Width / 100.0f) * dpiX);
            }
            int maxPrintableWidth = printableWidthInPixels - x;
            //ShowMsg($"MarginBounds.Width={e.MarginBounds.Width} dpiX={dpiX} printableWidthInPixels={printableWidthInPixels} maxPrintableWidth={maxPrintableWidth}");
            //ShowMsg($"MeasureString={e.Graphics.MeasureString(msg, font).Width}");
            string thisLine = msg;
            bool bContinue;
            do {
                string thisPart = thisLine;
                bContinue = false;
                while ((int)e.Graphics.MeasureString(thisPart, font).Width > maxPrintableWidth) {
                    thisPart = thisPart.Substring(0, thisPart.Length - 1);
                    bContinue = true;
                }
                e.Graphics.DrawString(thisPart, font, Brushes.Black, x, y);
                y += (int)(lineSpacing * font.Height);
                thisLine = thisLine.Substring(thisPart.Length);
            } while (bContinue);
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e) {
            // Specify what to print. In this case, a simple text message.
            int x = settings.UpperLeftX;
            int y = settings.UpperLeftY;
            Font fontPatron = new Font(settings.FontFamilyPatron, settings.FontSizePatron, FontStyle.Bold);
            Font fontOther = new Font(settings.FontFamilyOther, settings.FontSizeOther);
            Font fontOtherBold = new Font(settings.FontFamilyOther, settings.FontSizeOther, FontStyle.Bold);

            string msg;
            bool bLastIsBlank = false;
            foreach (string field in settings.Fields) {
                bLastIsBlank = false;
                if (field == FIELD_BLANKLINE) {
                    bLastIsBlank = true;
                    y += fontOther.Height;
                    continue;
                } else if (field == FIELD_EXPDATE) {
                    msg = $"Pickup by: {holdSlip.Expdate}";
                    PrintLine(msg, e, fontOtherBold, settings.LineSpacingOther, x, ref y);
                } else if (field == FIELD_PATRON) {
                    PrintLine(holdSlip.Patron, e, fontPatron, settings.LineSpacingPatron, x, ref y);
                } else if (field == FIELD_CURRENTDATETIME) {
                    msg = $"Date: {holdSlip.Currentdatetime}";
                    PrintLine(msg, e, fontOther, settings.LineSpacingOther, x, ref y);
                } else if (field == FIELD_LIBRARY) {
                    msg = $"Hold at {holdSlip.Library}";
                    PrintLine(msg, e, fontOther, settings.LineSpacingOther, x, ref y);
                } else if (field == FIELD_TITLE) {
                    msg = "ITEM ON HOLD";
                    PrintLine(msg, e, fontOtherBold, settings.LineSpacingOther, x, ref y);
                    msg = $"{holdSlip.Title}";
                    PrintLine(msg, e, fontOtherBold, settings.LineSpacingOther, x, ref y);
                } else if (field == FIELD_AUTHOR) {
                    msg = $"{holdSlip.Author}";
                    PrintLine(msg, e, fontOther, settings.LineSpacingOther, x, ref y);
                } else if (field == FIELD_BARCODE) {
                    msg = $"{holdSlip.Barcode}";
                    PrintLine(msg, e, fontOther, settings.LineSpacingOther, x, ref y);
                } else if (field == FIELD_CALLNUMBER) {
                    msg = $"{holdSlip.Callnumber}";
                    PrintLine(msg, e, fontOther, settings.LineSpacingOther, x, ref y);
                }
            }

            msg = $"Config: ({settings.UpperLeftX},{settings.UpperLeftY});" +
                $" Width {settings.PageWidth};" +
                $" Patron font: {settings.FontFamilyPatron} {settings.FontSizePatron} {settings.LineSpacingPatron.ToString()};";
            msg += $" Other font: {settings.FontFamilyOther} {settings.FontSizeOther} {settings.LineSpacingOther.ToString()};";
            msg += $" Fields: ";
            string strFields = "";
            foreach (string field in settings.Fields) {
                if (strFields.Length > 0) {
                    strFields += ", ";
                }
                strFields += field;
            }
            msg += strFields;
            ShowMsg(msg);
            if (settings.PrintConfig) {
                PrintLine(msg, e, fontOther, settings.LineSpacingOther, x, ref y);
            }
            // The print driver seems to ignore blank lines unless we print 
            // something below them, so do so.  Note: printing with a white
            // brush doesn't work; the paper isn't advanced to this point.
            // So we print a black ".".
            if (bLastIsBlank) {
                PrintLine(".", e, fontOther, settings.LineSpacingOther, x, ref y);
            }
        }

        private void PrintEndHandler(object sender, PrintEventArgs e) {
            // This method is called when the print job has completed.
            ShowMsg("Print job completed.");
            Program.FormMain.OnPrintJobComplete();
        }

    }
}