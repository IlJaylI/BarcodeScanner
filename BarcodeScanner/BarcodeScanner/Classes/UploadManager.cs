using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner.Classes
{
    class UploadManager
    {
        HttpClient client;
        public string response { get; set; }

        public UploadManager()
        {
            //changes need to be made when the method is implemneted
            var authData = string.Format("{0}:{1}", "scan2xadmin", "@vaPassword1!");
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
        }

        public async Task Save(ToUpload data, bool isnew = true)
        {
            //changes need to be made when the method is implemneted    
            String Url = "";
            var uri = new Uri(string.Format(Url, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(data);
                json = "{\"extConn\":" + json + "}";
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    string resp = await response.Content.ReadAsStringAsync();

                    var jr = JsonConvert.DeserializeObject<JsonResponse>(resp);

                    string connectionID = jr.d;
                    Debug.WriteLine(@"TodoItem successfully saved. Connection Id: " + connectionID);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}" + ex.Message);
            }
        }

        public Task SaveTask(ToUpload data, bool isnew = true)
        {
            return this.Save(data, isnew);
        }

    }
}
