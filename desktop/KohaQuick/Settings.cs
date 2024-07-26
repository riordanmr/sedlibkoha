using Newtonsoft.Json;
using System;
using System.IO;

namespace KohaQuick {
    public class Settings {
        public Settings() { }
        public const string ApplicationName = "KohaQuick";
        public const string SettingsFilenameOnly = ApplicationName + "-config.json";

        public static string SettingsFilename {
            get {
                string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string configFilePath = Path.Combine(localAppDataPath, ApplicationName, SettingsFilenameOnly);
                return configFilePath;
            }
        }

        public string KohaUrlStaff = "";
        public string KohaUrlPatron = "";

        public string Printer = "Epson TM-T88IV Receipt";

        public bool PrintToPDF = false;

        public string FontFamilyPatron { get; set; } = "Calibri";

        public float FontSizePatron { get; set; } = 18.0F;

        public float LineSpacingPatron { get; set; } = 0.97F;

        public string FontFamilyOther { get; set; } = "Arial";

        public float FontSizeOther { get; set; } = 12.0F;

        public float LineSpacingOther { get; set; } = 1.0F;

        public int UpperLeftX { get; set; } = 5;

        public int UpperLeftY { get; set; } = 5;

        public string[] Fields = new string[] { PrintImpl.FIELD_EXPDATE, PrintImpl.FIELD_PATRON,
            PrintImpl.FIELD_CURRENTDATETIME, PrintImpl.FIELD_LIBRARY, PrintImpl.FIELD_BLANKLINE,
            PrintImpl.FIELD_TITLE, PrintImpl.FIELD_BARCODE,
            PrintImpl.FIELD_CALLNUMBER, PrintImpl.FIELD_BLANKLINE, PrintImpl.FIELD_BLANKLINE
            };

        // Page width in pixels. On some printers, my calculation for page width
        // don't work, probably due to unit conversion problems.  So I allow this
        // manual override.  If 0, we use my calculations.
        public int PageWidth { get; set; } = 300;

        public bool PrintConfig { get; set; } = true;

        public int BrowserWidth { get; set; } = 600;
        public int BrowserHeight { get; set; } = 600;
        public int BrowserX { get; set; } = -1;

        // Serializes the current instance to a JSON string
        public string ToJson() {
            return JsonConvert.SerializeObject(this);
        }

        // Deserializes a JSON string to an instance of Settings
        public static Settings FromJson(string json) {
            return JsonConvert.DeserializeObject<Settings>(json);
        }

        public static Settings Load() {
            try {
                string json = System.IO.File.ReadAllText(SettingsFilename);
                return FromJson(json);
            } catch (System.IO.FileNotFoundException) {
                return new Settings();
            } catch (System.IO.DirectoryNotFoundException) {
                return new Settings();
            }
        }

        public void Save() {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            string directoryPath = Path.GetDirectoryName(SettingsFilename);
            // Ensure the directory exists before writing the file.
            Directory.CreateDirectory(directoryPath);
            File.WriteAllText(SettingsFilename, json);
        }
    }
}
