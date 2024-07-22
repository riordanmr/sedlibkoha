using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TestSelenium
{
    public class Patron
    {
        public string firstname { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public string postal_code { get; set; }
        public string Country { get; set; }
        public string library_id { get; set; } = "FRL";
        public string userid { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string cardnumber { get; set; }
        public string category_id { get; set; }
        public string date_of_birth { get; set; }

    }
}
