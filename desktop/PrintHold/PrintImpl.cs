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

        private void PrintPageHandler(object sender, PrintPageEventArgs e) {
            // Specify what to print. In this case, a simple text message.
            int x = settings.UpperLeftX;
            int y = settings.UpperLeftY;
            Font fontPatron = new Font(settings.FontFamilyPatron, settings.FontSizePatron, FontStyle.Bold);
            e.Graphics.DrawString(holdSlip.Patron, fontPatron, Brushes.Black, 
                x, y);
            y += fontPatron.Height;
            Font fontOther = new Font(settings.FontFamilyOther, settings.FontSizeOther);
            Font fontOtherBold = new Font(settings.FontFamilyOther, settings.FontSizeOther, FontStyle.Bold);
            string msg = $"Date: {holdSlip.Currentdatetime}";
            e.Graphics.DrawString(msg, fontOther, Brushes.Black, x, y);
            y += fontOther.Height;
            msg = $"Hold at {holdSlip.Library}";
            e.Graphics.DrawString(msg, fontOther, Brushes.Black, x, y);
            y += 2*fontOther.Height;

            msg = "ITEM ON HOLD";
            e.Graphics.DrawString(msg, fontOtherBold, Brushes.Black, x, y);
            y += fontOtherBold.Height;
            msg = $"{holdSlip.Title}";
            e.Graphics.DrawString(msg, fontOtherBold, Brushes.Black, x, y);
            y += fontOtherBold.Height;
            msg = $"{holdSlip.Author}";
            e.Graphics.DrawString(msg, fontOther, Brushes.Black, x, y);
            y += fontOther.Height;
            msg = $"{holdSlip.Barcode}";
            e.Graphics.DrawString(msg, fontOther, Brushes.Black, x, y);
            y += fontOther.Height;
            msg = $"{holdSlip.Callnumber}";
            e.Graphics.DrawString(msg, fontOther, Brushes.Black, x, y);
            y += fontOther.Height;
            msg = $"Expires: {holdSlip.Expdate}";
            e.Graphics.DrawString(msg, fontOther, Brushes.Black, x, y);
            y += 2*fontOther.Height;

            msg = $"Config: ({settings.UpperLeftX},{settings.UpperLeftY}) {settings.FontFamilyPatron} {settings.FontSizePatron}; ";
            msg += $"{settings.FontFamilyOther} {settings.FontSizeOther}";
            ShowMsg(msg);
            e.Graphics.DrawString(msg, fontOther, Brushes.Black, x, y);
            y += fontOther.Height;
        }

    }
}