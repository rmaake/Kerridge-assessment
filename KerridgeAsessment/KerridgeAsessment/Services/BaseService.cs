using KerridgeAsessment.Misc;
using KerridgeAsessment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace KerridgeAsessment.Services
{
    public abstract class BaseService
    {
        private readonly HttpClient _httpClient;
        public BaseService()
        {
            _httpClient = HttpClientSingleton.Instance;
        }

        public async Task<ServerResponse<T>> Get<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var responseStr = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ServerResponse<T>>(responseStr);
            }
            return new ServerResponse<T>();
        }
    }
}
