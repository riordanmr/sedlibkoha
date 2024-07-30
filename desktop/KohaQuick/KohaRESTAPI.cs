using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KohaQuick {
    public class SetPasswordBody {
        public string password { get; set; }
        public string password_2 { get; set; } = string.Empty;
    }

    public class AddPatronResponse {
        public string address { get; set; }
        public string address2 { get; set; }
        public bool anonymized { get; set; }
        public bool autorenew_checkouts { get; set; }
        public string cardnumber { get; set; }
        public string category_id { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string date_enrolled { get; set; }
        public string date_of_birth { get; set; }
        public string email { get; set; }
        public string expiry_date { get; set; }
        public string firstname { get; set; }
        public bool incorrect_address { get; set; }
        public string last_seen { get; set; }
        public string library_id { get; set; }
        public string opac_notes { get; set; }
        public bool patron_card_lost { get; set; }
        public int patron_id { get; set; }
        public string phone { get; set; }
        public string postal_code { get; set; }
        public int privacy { get; set; }
        public bool privacy_guarantor_fines { get; set; }
        public bool restricted { get; set; }
        public string staff_notes { get; set; }
        public string state { get; set; }
        public string surname { get; set; }
        public string updated_on { get; set; }
        public string userid { get; set; }
    }

    public class KohaRESTAPI {

        RestClient restClient;

        void ShowMsg(string msg) {
            Program.FormMain.ShowMsg(msg);
        }

        Settings GetSettings() {
            return Program.FormMain.settings;
        }

        Creds GetCreds() {
            return Program.FormMain.creds;
        }

        string GetBasicAuthString() {
            return "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(
                GetCreds().KohaUsername + ":" + GetCreds().KohaPassword));
        }

        void AddBasicAuthHeader(RestRequest request) {
            request.AddHeader("Authorization", GetBasicAuthString());
        }

        string ExtractError(string json) {
            string errmsg = string.Empty;
            try {
                dynamic obj = JsonConvert.DeserializeObject(json);
                errmsg = obj.error;
            } catch (Exception ex) {
                errmsg = ex.Message;
            }
            return errmsg;
        }

        public bool SetPatronPassword(int patronId, string password, out string errmsg) {
            bool bOK = false;
            errmsg = string.Empty;
            restClient = new RestClient(GetSettings().KohaUrlStaff);
            RestRequest request = new RestRequest($"/api/v1/patrons/{patronId}/password", Method.Post);
            AddBasicAuthHeader(request);
            request.AddBody(new SetPasswordBody { password = password, password_2 = password });
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                bOK = true;
            } else {
                ShowMsg($"Failed to set patron password: {response.Content}");
                errmsg = ExtractError(response.Content);
            }
            return bOK;
        }

        public bool AddPatron(Patron patron, out string errmsg) {
            bool bOK = false;
            errmsg = string.Empty;
            string baseURL = GetSettings().KohaUrlStaff;
            restClient = new RestClient(baseURL);
            RestRequest request = new RestRequest("/api/v1/patrons", Method.Post);
            // Add basic authentication
            string authStr = GetCreds().KohaUsername + ":" + GetCreds().KohaPassword;
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(authStr)));
            string jsonBody = JsonConvert.SerializeObject(patron);
            request.AddJsonBody(jsonBody);
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created) {
                string respBodyJson = response.Content;
                AddPatronResponse addPatronResponse = JsonConvert.DeserializeObject<AddPatronResponse>(respBodyJson);
                bOK = SetPatronPassword(addPatronResponse.patron_id, patron.password, out errmsg);
            } else {
                ShowMsg($"Failed to add patron: {response.Content}");
                errmsg = ExtractError(response.Content);
            }
            return bOK;
        }
    }
}
