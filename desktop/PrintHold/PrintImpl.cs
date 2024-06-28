// PrintHold - program to print a library hold slip, for the Koha ILS.
// Mark Riordan  2024-06-26

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using Newtonsoft.Json;

namespace PrintHold
{
    public class HoldSlip
    {
        public string Patron { get; set; }
        public string Currentdatetime { get; set; }
        public string Library { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Barcode { get; set; }
        public string Callnumber { get; set; }
        public string Expdate { get; set; }
    }

    public class PrintImpl
    {
        public Settings settings;

        public HoldSlip holdSlip;

        public PrintImpl() {
            settings = Settings.Load();
        }

        void ShowMsg(string msg) {
            string stamp = DateTime.Now.ToString("HH:mm:ss");
            Program.FormMain.ShowMsg($"{stamp} {msg}");
        }

        public void Print() {
            string filePath = "holdslip.json";
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
            holdSlip = JsonConvert.DeserializeObject<HoldSlip>(jsonStr);

            PrintDocument printDocument = new PrintDocument();

            // Set the printer name. Make sure the name matches exactly.
            string printerName = settings.Printer;
            printDocument.PrinterSettings.PrinterName = printerName;
            printDocument.PrinterSettings.PrintToFile = settings.PrintToPDF;
            string pdfOutputFileName = "PrintHoldOut.pdf";
            printDocument.PrinterSettings.PrintFileName = pdfOutputFileName;

            // Handle the PrintPage event to specify what to print.
            printDocument.PrintPage += new PrintPageEventHandler(PrintPageHandler);

            try {
                // Print the document.
                printDocument.Print();
                ShowMsg($"Printed OK to {printerName}");
            } catch (Exception ex) {
                ShowMsg("Error: " + ex.Message);
            }
        }

        private void PrintLine(string msg, PrintPageEventArgs e, Font font, int x, ref int y) {
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
                y += font.Height;
                thisLine = thisLine.Substring(thisPart.Length);
            } while (bContinue) ;
        }   

        private void PrintPageHandler(object sender, PrintPageEventArgs e) {
            // Specify what to print. In this case, a simple text message.
            int x = settings.UpperLeftX;
            int y = settings.UpperLeftY;
            Font fontPatron = new Font(settings.FontFamilyPatron, settings.FontSizePatron, FontStyle.Bold);
            PrintLine(holdSlip.Patron, e, fontPatron, x, ref y);
            Font fontOther = new Font(settings.FontFamilyOther, settings.FontSizeOther);
            Font fontOtherBold = new Font(settings.FontFamilyOther, settings.FontSizeOther, FontStyle.Bold);
            string msg = $"Date: {holdSlip.Currentdatetime}";
            PrintLine(msg, e, fontOther, x, ref y);
            msg = $"Hold at {holdSlip.Library}";
            PrintLine(msg, e, fontOther, x, ref y);
            // Add a blank line.
            y += fontOther.Height;

            msg = "ITEM ON HOLD";
            PrintLine(msg, e, fontOtherBold, x, ref y);
            msg = $"{holdSlip.Title}";
            PrintLine(msg, e, fontOtherBold, x, ref y);
            msg = $"{holdSlip.Author}";
            PrintLine(msg, e, fontOther, x, ref y);
            msg = $"{holdSlip.Barcode}";
            PrintLine(msg, e, fontOther, x, ref y);
            msg = $"{holdSlip.Callnumber}";
            PrintLine(msg, e, fontOther, x, ref y);
            msg = $"Expires: {holdSlip.Expdate}";
            PrintLine(msg, e, fontOther, x, ref y);
            y += fontOther.Height;

            msg = $"Config: ({settings.UpperLeftX},{settings.UpperLeftY}); Width {settings.PageWidth}; {settings.FontFamilyPatron} {settings.FontSizePatron}; ";
            msg += $"{settings.FontFamilyOther} {settings.FontSizeOther}";
            ShowMsg(msg);
            PrintLine(msg, e, fontOther, x, ref y);
        }

    }
}