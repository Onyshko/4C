using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace _4C.Model
{
    class DataFromApi
    {
        private HttpClient _client;
        private HttpResponseMessage _response;

        private DataFromApi(HttpClient client, HttpResponseMessage response)
        {
            _client = client;
            _response = response;
        }

        public static async Task<ObservableCollection<Asset>> CreateAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.coincap.io/v2/assets");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(json);
            return jObject["data"].ToObject<ObservableCollection<Asset>>();
        }
    }
}
