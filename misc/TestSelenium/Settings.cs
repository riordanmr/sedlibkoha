using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSelenium
{
    public class Settings
    {
        public string KohaStaffWebUrl { get; set; }
        public string KohaUsername { get; set; }
        public string KohaPassword { get; set; }

        public static string SettingsFilename { get; set; } = "TestSelenium-settings.json";

        public static Settings Load()
        {
            // Check if the file exists
            if (!File.Exists(SettingsFilename)) {
                return new Settings();
            }

            // Read the file and deserialize the JSON content into a Settings object
            string jsonContent = File.ReadAllText(SettingsFilename);
            return JsonConvert.DeserializeObject<Settings>(jsonContent);
        }

        public void Save()
        {
            // Serialize the current Settings object to a JSON string
            string jsonContent = JsonConvert.SerializeObject(this, Formatting.Indented);

            // Write the JSON content to the file specified by SettingsFilename
            File.WriteAllText(SettingsFilename, jsonContent);
        }
    }
}
