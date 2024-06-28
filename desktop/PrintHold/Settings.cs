using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintHold
{
    public class Settings
    {
        public Settings() { }
        public const string SettingsFilename = "PrintHold.json";

        public string Printer = "Epson TM-T88IV Receipt";

        public bool PrintToPDF = false;

        public string FontFamilyPatron { get; set; } = "Georgia";

        public float FontSizePatron { get; set; } = 18.0F;

        public string FontFamilyOther { get; set; } = "Arial";

        public float FontSizeOther { get; set; } = 12.0F;

        public int UpperLeftX { get; set; } = 15;

        public int UpperLeftY { get; set; } = 15;

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
            }
        }

        public void Save() {
            string json = this.ToJson();
            System.IO.File.WriteAllText(SettingsFilename, json);
        }
    }
}
