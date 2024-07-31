using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KohaQuick {
    public class CheckoutItemInfo {
        public string barcode { get; set; }
        public string biblio_id { get; set; }
        public string due_date { get; set; }
        public string item_id { get; set; }
        public string title { get; set; }
        public string callnumber { get; set; }
        public string author { get; set; }

        public override string ToString() {
            return $"{{Barcode: {barcode}, Due Date: {due_date}, Item ID: {item_id}, Title: {title}, Call Number: {callnumber}, Author: {author}}}";
        }
    }

    public class CheckoutInfo {
        public string patronFirstName { get; set; }
        public string patronLastName { get; set; }
        public CheckoutItemInfo[] items { get; set; } = new CheckoutItemInfo[0];

        public override string ToString() {
            var itemsInfo = string.Join(", ", items.Select(item => item.ToString()));
            return $"Patron: {patronFirstName} {patronLastName}, Items: [{itemsInfo}]";
        }
    }

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

        public KohaRESTAPI() {
            restClient = new RestClient(GetSettings().KohaUrlStaff);            
        }

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

        public bool GetPatronInfo(string cardnumber, out Object patron, out string errmsg) {
            bool bOK = false;
            errmsg = string.Empty;
            patron = null;
            try {
                RestRequest request = new RestRequest(
                    $"/api/v1/patrons?q={{\"cardnumber\":\"{cardnumber}\"}}", Method.Get);
                AddBasicAuthHeader(request);
                var response = restClient.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                    string respBodyJson = response.Content;
                    JArray jsonArray = JArray.Parse(respBodyJson);
                    Object[] aryPatrons = jsonArray.ToObject<object[]>();
                    if (aryPatrons.Length > 0) {
                        patron = aryPatrons[0];
                        bOK = true;
                    } else {
                        ShowMsg($"API returned no patrons with card number {cardnumber}");
                        errmsg = "No patron found with that card number";
                    }
                } else {
                    ShowMsg($"Failed to get patron info: {response.Content}");
                    errmsg = ExtractError(response.Content);
                }
            } catch (Exception ex) {
                ShowMsg($"GetPatronInfo exception: {ex.Message}");
                errmsg = ex.Message;
            }
            ShowMsg($"GetPatronInfo ret {bOK}; errmsg={errmsg}");
            return bOK;
        }

        public bool GetCheckedOutItemsForPatron(int patronId, out Object[] aryItems, out string errmsg) {
            bool bOK = false;
            errmsg = string.Empty;
            aryItems = null;
            try {
                //ToDo: Add pagination support
                RestRequest request = new RestRequest(
                    $"/api/v1/checkouts?q={{\"patron_id\":{patronId}}}", Method.Get);
                AddBasicAuthHeader(request);
                var response = restClient.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                    string respBodyJson = response.Content;
                    JArray jsonArray = JArray.Parse(respBodyJson);
                    aryItems = jsonArray.ToObject<object[]>();
                    ShowMsg($"GetCheckedOutItemsForPatron: {aryItems.Length} items");
                    bOK = true;
                } else {
                    ShowMsg($"Failed to get checked out items: {response.Content}");
                    errmsg = ExtractError(response.Content);
                }
            } catch (Exception ex) {
                ShowMsg($"GetCheckedOutItemsForPatron exception: {ex.Message}");
                errmsg = ex.Message;
            }
            return bOK;
        }

        public bool MergeItemInfo(ref CheckoutInfo checkInfo, out string errmsg) {
            bool bOk = false;
            errmsg = string.Empty;
            try {

                // Construct a comma-separated list of item IDs, so we can
                // fetch all items in one request.
                string strItemIds = "";
                foreach (var item in checkInfo.items) {
                    if (strItemIds.Length > 0) {
                        strItemIds += ",";
                    }
                    strItemIds += item.item_id.ToString();
                }

                //ToDo: Add pagination support
                string relUrl = $"/api/v1/items?q={{\"item_id\":{{\"=\":[{strItemIds}]}}}}";
                //ShowMsg($"MergeItemInfo: accessing {relUrl}");
                RestRequest request = new RestRequest(relUrl, Method.Get);
                AddBasicAuthHeader(request);
                var response = restClient.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                    string respBodyJson = response.Content;
                    JArray jsonArray = JArray.Parse(respBodyJson);
                    Object[] aryItems = jsonArray.ToObject<object[]>();
                    foreach (var item in aryItems) {
                        string itemId = ((dynamic)item).item_id;
                        CheckoutItemInfo checkoutItemInfo = checkInfo.items.FirstOrDefault(
                            i => i.item_id == itemId);
                        if (checkoutItemInfo != null) {
                            checkoutItemInfo.barcode = ((dynamic)item).external_id;
                            checkoutItemInfo.biblio_id = ((dynamic)item).biblio_id;
                            checkoutItemInfo.callnumber = ((dynamic)item).callnumber;
                        }
                    }
                    bOk = true;
                    ShowMsg($"MergeItemInfo: checkInfo={checkInfo}");
                } else {
                    ShowMsg($"Failed to get item info: {response.Content}");
                    errmsg = ExtractError(response.Content);
                }
            } catch (Exception ex) {
                bOk = false;
                ShowMsg($"MergeItemInfo exception: {ex.Message}");
                errmsg = ex.Message;
            }

            return bOk;
        }

        public bool GetItemsCheckedOutTodayForPatron(string cardnumber, 
            ref CheckoutInfo checkoutInfo, out string errmsg) {
            bool bOK = false;
            errmsg = string.Empty;
            Object[] aryItems = null;
            try {
                bOK = GetPatronInfo(cardnumber, out Object patron, out errmsg);
                if (bOK) {
                    int patronId = ((dynamic)patron).patron_id;
                    ShowMsg($"GetItemsCheckedOutTodayForPatron: patron_id={patronId}");
                    bOK = GetCheckedOutItemsForPatron(patronId, out aryItems, out errmsg);
                }
                if (bOK) {
                    if (aryItems.Length > 0) {
                        List<CheckoutItemInfo> lstItems = new List<CheckoutItemInfo>();
                        foreach (dynamic item in aryItems) {
                            string dueDate = item.due_date;
                            DateTimeOffset dtDueDateOffset = DateTimeOffset.Parse(dueDate);
                            DateTime dtDueDateLocal = dtDueDateOffset.ToLocalTime().DateTime;
                            string dueDateDisplay = dtDueDateLocal.ToString("MM/dd/yyyy");
                            string checkoutDate = item.checkout_date;
                            DateTimeOffset dtCheckoutDateOffset = DateTimeOffset.Parse(checkoutDate);
                            DateTime dtCheckoutDateLocal = dtCheckoutDateOffset.ToLocalTime().DateTime;
                            if (dtCheckoutDateLocal.Date == DateTime.Today) {
                                CheckoutItemInfo checkoutItemInfo = new CheckoutItemInfo {
                                    due_date = dueDateDisplay,
                                    item_id = item.item_id
                                };
                                lstItems.Add(checkoutItemInfo);
                            }
                            checkoutInfo.patronFirstName = ((dynamic)patron).firstname;
                            checkoutInfo.patronLastName = ((dynamic)patron).surname;
                            checkoutInfo.items = lstItems.ToArray();
                        }
                    } else {
                        ShowMsg("No items checked out today");
                        errmsg = "No items were checked out today by this patron";
                        bOK = false;
                    }
                }
                if (bOK) {
                    ShowMsg($"GetItemsCheckedOutTodayForPatron: {checkoutInfo}");
                    bOK = MergeItemInfo(ref checkoutInfo, out errmsg);
                }
                if (bOK) {
                    // The next step would be to a listBiblios request like:
                    // api/v1/biblios?q={"biblio_id":{"=":[182,412]}}
                    // to obtain titles, and them merge them into checkoutInfo.
                    // However, as I was writing this code, I got word that I
                    // would not be getting REST API access to Koha on YLN.
                    // So, I will cease development of code that uses the Koha REST API.
                    // MRR  2024-07-30
                }
            } catch (Exception ex) {
                bOK = false;
                ShowMsg($"GetItemsCheckedOutTodayForPatron exception: {ex.Message}");
                errmsg = ex.Message;
            }

            return bOK;
        }
    }
}
