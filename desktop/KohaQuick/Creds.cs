using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohaQuick {
    public class Creds {
        public static string ComputeCredsFilename() {
            string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = Settings.ApplicationName + "-creds";
            if (Program.programArgs.profile.Length > 0) {
                filename += "-";
            }
            filename += Program.programArgs.profile;
            filename += ".json";
            string filePath = Path.Combine(localAppDataPath, Settings.ApplicationName, filename);
            return filePath;
        }

        public string KohaUsername { get; set; } = "";
        public string KohaPassword { get; set; } = "";

        // Deserializes a JSON string to an instance of Settings
        public static Creds FromJson(string json) {
            return JsonConvert.DeserializeObject<Creds>(json);
        }

        public static Creds Load() {
            try {
                string json = System.IO.File.ReadAllText(ComputeCredsFilename());
                return FromJson(json);
            } catch (System.IO.FileNotFoundException) {
                return new Creds();
            } catch (System.IO.DirectoryNotFoundException) {
                return new Creds();
            }
        }

        public void Save() {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            string directoryPath = Path.GetDirectoryName(ComputeCredsFilename());
            // Ensure the directory exists before writing the file.
            Directory.CreateDirectory(directoryPath);
            File.WriteAllText(ComputeCredsFilename(), json);
        }
    }

}
