using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSelenium
{
    public class PatronProc
    {
        RestClient restClient;

        public bool AddPatron(Patron patron) {
            bool bOK = false;
            restClient = new RestClient("https://sedkoha1-intra.csproject.org");
            RestRequest request = new RestRequest("/api/v1/patrons", Method.Post);
            // Add basic authentication
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes("lhg:mizjem-jisce7-dachIm")));

            request.AddJsonBody(patron);
            var response = restClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created) {
                bOK = true;
            }
            MessageBox.Show(response.Content);

            return bOK;
        }

    }

}
