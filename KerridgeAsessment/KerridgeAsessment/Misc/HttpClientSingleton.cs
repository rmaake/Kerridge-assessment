using KerridgeAsessment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KerridgeAsessment.Misc
{
    public static class HttpClientSingleton
    {
        private static HttpClient _httpClient;

        public static HttpClient Instance 
        {
            get
            {
                if (_httpClient == null)
                {
                    CreateInstance();
                }
                return _httpClient;
            }
        }

        private static void CreateInstance()
        {
            if (_httpClient != null)
            {
                return;
            }
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(App.BaseUrl);
            GetAccessToken();
            
        }

        private static async void GetAccessToken()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(App.AuthBaseUrl);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{App.ClientID}:{App.ClientSecret}")));
                FormUrlEncodedContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("scope", "eos.common.fullaccess"),
                });
                var response = await httpClient.PostAsync("connect/token", content);
                if (response.IsSuccessStatusCode)
                {
                    var tokenStr = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject<Token>(tokenStr);
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.Token_Type, token.Access_Token);
                }
            }
            
        }
    }
}
