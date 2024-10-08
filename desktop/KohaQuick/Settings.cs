﻿using Newtonsoft.Json;
using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;

namespace KohaQuick {
    public class Settings {
        public Settings() { }
        public const string ApplicationName = "KohaQuick";
        public const string SettingsFilenameOnly = ApplicationName + "-config";
        public const string SettingsFilenameExt = ".json";
        public const string BROWSER_WINDOW_STATE_NORMAL = "Normal";
        public const string BROWSER_WINDOW_STATE_MINIMIZED = "Minimized";
        public const string BROWSER_WINDOW_STATE_HIDDEN = "Hidden";

        public static string ComputeSettingsFilename() {
            string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string configFilename = SettingsFilenameOnly;
            if (Program.programArgs.profile.Length > 0) {
                configFilename += "-";
            }
            configFilename += Program.programArgs.profile;
            configFilename += SettingsFilenameExt;
            string configFilePath = Path.Combine(localAppDataPath, ApplicationName, configFilename);
            return configFilePath;
        }

        public string KohaUrlStaff = "https://staff-yavapaiaz.bywatersolutions.com";
        public string KohaUrlPatron = "https://yavapaiaz.bywatersolutions.com/";

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

        // Configured list of fields we actually want to print on a hold slip.
        // This is the default value, which can be overridden via the Settings dialog.
        public string[] HoldFields = new string[] { PrintImpl.FIELD_EXPDATE, PrintImpl.FIELD_PATRON,
            PrintImpl.FIELD_CURRENTDATETIME, PrintImpl.FIELD_LIBRARY, PrintImpl.FIELD_BLANKLINE,
            PrintImpl.FIELD_TITLE, PrintImpl.FIELD_BARCODE,
            PrintImpl.FIELD_CALLNUMBER, PrintImpl.FIELD_BLANKLINE, PrintImpl.FIELD_BLANKLINE,
            PrintImpl.FIELD_BLANKLINE, PrintImpl.FIELD_BLANKLINE
        };

        public string[] CheckoutItemFields = new string[] { PrintImpl.FIELD_TITLE,
            PrintImpl.FIELD_DUEDATE, PrintImpl.FIELD_CALLNUMBER, PrintImpl.FIELD_BLANKLINE
        };

        // Page width in pixels. On some printers, my calculation for page width
        // don't work, probably due to unit conversion problems.  So I allow this
        // manual override.  If 0, we use my calculations.
        public int PageWidth { get; set; } = 300;
        public bool IndentLineContinuations { get; set; } = true;
        public bool BreakLinesOnWords { get; set; } = false;

        public bool PrintConfig { get; set; } = true;

        public int BrowserWidth { get; set; } = 600;
        public int BrowserHeight { get; set; } = 600;
        public int BrowserX { get; set; } = -1;

        public string BrowserWindowState { get; set; } = BROWSER_WINDOW_STATE_HIDDEN;

        public bool CleanupSeleniumProcessesAtStartup { get; set; } = true;

        public string DefaultPatronCategory { get; set; } = "PATRON";

        public string LocalLibraries { get; set; } = "Sedona Public Library,SPL in the Village";

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
                string json = System.IO.File.ReadAllText(ComputeSettingsFilename());
                return FromJson(json);
            } catch (System.IO.FileNotFoundException) {
                return new Settings();
            } catch (System.IO.DirectoryNotFoundException) {
                return new Settings();
            }
        }

        public void Save() {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            string directoryPath = Path.GetDirectoryName(ComputeSettingsFilename());
            // Ensure the directory exists before writing the file.
            Directory.CreateDirectory(directoryPath);
            File.WriteAllText(ComputeSettingsFilename(), json);
        }
    }
}
