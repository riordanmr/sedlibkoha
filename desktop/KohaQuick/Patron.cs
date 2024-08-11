using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohaQuick {
    public class Patron {
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string main_contact_method { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string library_id { get; set; } = "FRL";
        public string userid { get; set; }
        public string main_library { get; set; }
        [JsonIgnore]
        public string password { get; set; }
        public string cardnumber { get; set; }
        public string category_id { get; set; }
        public string date_of_birth { get; set; }
        public string circ_notes { get; set; }
    }
}
