using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohaQuick {
    public class Creds {
        public const string CredsFilenameOnly = Settings.ApplicationName + "-creds.json";

        public static string CredsFilename {
            get {
                string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string configFilePath = Path.Combine(localAppDataPath, Settings.ApplicationName, CredsFilenameOnly);
                return configFilePath;
            }
        }

        public string KohaUsername { get; set; } = "";
        public string KohaPassword { get; set; } = "";

        // Deserializes a JSON string to an instance of Settings
        public static Creds FromJson(string json) {
            return JsonConvert.DeserializeObject<Creds>(json);
        }

        public static Creds Load() {
            try {
                string json = System.IO.File.ReadAllText(CredsFilename);
                return FromJson(json);
            } catch (System.IO.FileNotFoundException) {
                return new Creds();
            } catch (System.IO.DirectoryNotFoundException) {
                return new Creds();
            }
        }

        public void Save() {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            string directoryPath = Path.GetDirectoryName(CredsFilename);
            // Ensure the directory exists before writing the file.
            Directory.CreateDirectory(directoryPath);
            File.WriteAllText(CredsFilename, json);
        }
    }

}
