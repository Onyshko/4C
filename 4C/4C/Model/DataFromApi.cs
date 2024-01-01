using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace _4C.Model
{
    class DataFromApi
    {
        public static async Task<ObservableCollection<Asset>> GetTopListCurrencies()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.coincap.io/v2/assets");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(json);
            return jObject["data"].ToObject<ObservableCollection<Asset>>();
        }

        public static async Task<ObservableCollection<Market>> GetMarketsByCurrency(string currency)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.coincap.io/v2/assets/{currency}/markets");
            var content = new StringContent("", null, "text/plain");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(json);
            return jObject["data"].ToObject<ObservableCollection<Market>>();
        }

        public static async Task<ObservableCollection<History>> GetHistoryOfCurrency(string currency)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"https://api.coincap.io/v2/assets/{currency}/history?interval=d1");
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(json);

                return jObject["data"].ToObject<ObservableCollection<History>>();
            }
        }
    }
}
