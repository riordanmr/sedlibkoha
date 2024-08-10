using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace KohaQuick {
    public class Util {
        public static string GetDownloadsPath() {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), 
                "Downloads");
        }

        public static bool FindRecentDownloadedFile(string fileMask, int msMaxAge, 
            out string foundFilePath) {
            bool bFound = false;
            foundFilePath = null;

            string downloadsPath = GetDownloadsPath();
            Program.FormMain.ShowMsg($"Looking for {fileMask} in {downloadsPath}");
            DirectoryInfo directoryInfo = new DirectoryInfo(downloadsPath);

            for (int itry=0; itry<8; itry++) {
                FileInfo mostRecentFile = directoryInfo.GetFiles(fileMask)
                    .OrderByDescending(f => f.LastWriteTime)
                    .FirstOrDefault();

                if (mostRecentFile != null) {
                    TimeSpan fileAge = DateTime.Now - mostRecentFile.LastWriteTime;
                    Program.FormMain.ShowMsg($"Examining {mostRecentFile.FullName} with age {fileAge.TotalMilliseconds} ms");
                    if (fileAge.TotalMilliseconds <= msMaxAge) {
                        foundFilePath = mostRecentFile.FullName;
                        bFound = true;
                        break;
                    } else {
                        Program.FormMain.ShowMsg($"Found {mostRecentFile.FullName} but it's too old at {fileAge.TotalMilliseconds} ms; retrying");
                    }
                } else {
                    Program.FormMain.ShowMsg($"Didn't find recent {fileMask}; retrying");
                }
                Thread.Sleep(500);
            }
            return bFound;
        }

        public static List<string[]> ParseCsv(string filePath) {
            List<string[]> records = new List<string[]>();

            using (TextFieldParser parser = new TextFieldParser(filePath)) {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData) {
                    // Read fields, handling fields surrounded by quotes
                    string[] fields = parser.ReadFields();
                    records.Add(fields);
                }
            }

            return records;
        }

        public static bool ParseCheckedOutCSV(string filename, ref CheckoutItemCol checkoutInfoCol,
            out string errmsg) {
            bool bOK = true;
            errmsg = "";
            List<string[]> records = ParseCsv(filename);
            if (records.Count > 0) {
                // Look at the header row, and remember the column numbers for each field.
                var headerRow = records[0];
                int icolDueDate = -1;
                int icolTitle = -1;
                int icolCheckedOutOn = -1;
                int icolCallNumber = -1;

                for(int icol=0; icol<headerRow.Length; icol++) {
                    string field = headerRow[icol];
                    if (field == "Due date") {
                        icolDueDate = icol;
                    } else if (field == "Title") {
                        icolTitle = icol;
                    } else if (field == "Checked out on") {
                        icolCheckedOutOn = icol;
                    } else if(field == "Call number") {
                        icolCallNumber = icol;
                    }
                }

                if(icolDueDate == -1 || icolTitle == -1 || icolCheckedOutOn == -1) {
                    bOK = false;
                } else {
                    for (int irow = 1; irow < records.Count; irow++) {
                        string[] fields = records[irow];
                        if (fields.Length < 6) {
                            bOK = false;
                            break;
                        }

                        string title = fields[icolTitle];
                        string dueDate = fields[icolDueDate];
                        string checkedOutOn = fields[icolCheckedOutOn];
                        string callNumber = fields[icolCallNumber];

                        // checkedOutOn should look like ""07/31/2024 21:34"
                        // and will be in UTC. Convert it to local time, then
                        // truncate to just the date.
                        if (DateTime.TryParse(checkedOutOn, out DateTime checkedOutOnDateTimeUtc)) {
                            DateTime checkedOutOnDateTimeLocal = checkedOutOnDateTimeUtc.ToLocalTime();
                            string checkedOutOnDate = checkedOutOnDateTimeLocal.ToString("MM/dd/yyyy");
                            checkoutInfoCol.AddCheckout(title, callNumber, checkedOutOnDate, dueDate);
                        } else {
                            bOK = false;
                            errmsg = "Unable to parse checked out date: " + checkedOutOn;
                            break;
                        }
                    }
                }
            }

            return bOK;
        }
    }
}
