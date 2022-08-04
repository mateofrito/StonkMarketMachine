using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace StonkMarketMachine.Quotes
{
    public class IntraDayQuote : I_IntraDayQuote
    {
        private readonly HttpClient _httpClient;
        private readonly string apiKeyName = "ALPHAVANTAGE_TOKEN";
        const string _baseUrl = "https://www.alphavantage.co/query?function=";
        
        const string _host = "alphavantage.co";
        private string _key = "";
        private JsonSerializer _serializer = new JsonSerializer();
        
        public IntraDayQuote(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<JObject> GetData(string _endpoint)
        {
            _endpoint = _baseUrl + _endpoint;
            using var stream = await _httpClient.GetStreamAsync(_endpoint).ConfigureAwait(false);
            using var reader = new StreamReader(stream);
            using var json = new JsonTextReader(reader);
            JObject jObject = _serializer.Deserialize<JObject>(json);
            string derp = "derp";
            return jObject;

        }
        public async Task<string> GetIntraDayQuote()
        {
            _key = "EXGBU46FGX9CDJ24";
            string symbol = "IBM";
            string interval = "5";
            string _endpoint = _baseUrl + "TIME_SERIES_INTRADAY&symbol=" + symbol + "&interval=" + interval + "min&apikey=" + _key + "&datatype=json&output_size=compact";
            //ConfigureHttpClient();
            string quote;
            
            using var stream = await _httpClient.GetStreamAsync(_endpoint).ConfigureAwait(false);
            //response.EnsureSuccessStatusCode();

            //using var stream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);
            using var json = new JsonTextReader(reader);


            //dynamic dto = await Task.Run( () => JsonConvert.DeserializeObject(stream.ToString()));

            //dynamic dto = JsonConvert.DeserializeObject(json.ToString());
            JsonSerializer _serialize = new JsonSerializer();

            dynamic dto = _serialize.Deserialize<JObject>(json);

            string lastRefresh = (string)dto["Meta Data"]["3. Last Refreshed"];
            quote = (string)dto["Time Series (5min)"][lastRefresh]["1. open"];

            return quote;

        }
    
        
        private void ConfigureHttpClient()
        {
            _httpClient.BaseAddress = new Uri(_baseUrl);
            
            
        }

    }
}

