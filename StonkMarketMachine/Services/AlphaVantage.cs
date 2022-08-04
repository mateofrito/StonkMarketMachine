using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace StonkMarketMachine
{
    public class AlphaVantage
    {
        private readonly string apiKeyName = "ALPHAVANTAGE_TOKEN";
        private readonly string QUERY_URL = "https://www.alphavantage.co/query?function=";
        public string apiKey { get; set; }

        public AlphaVantage()
        {
            apiKey = System.Environment.GetEnvironmentVariable(apiKeyName);
        }

        

        public string IntraDayQuote(string symbol, string interval)
        {
            string apiEndpoint = QUERY_URL + "TIME_SERIES_INTRADAY&symbol=" + symbol + "&interval=" + interval + "min&apikey=" + apiKey;
            string quote;
            Uri queryUri = new Uri(apiEndpoint);

            using (WebClient client = new WebClient())
            {
                dynamic jObject = JsonConvert.DeserializeObject(client.DownloadString(queryUri), typeof(object));
                string lastRefresh = (string)jObject["Meta Data"]["3. Last Refreshed"];
                quote = (string)jObject["Time Series (5min)"][lastRefresh]["1. open" ];
                

            }

            return quote;
        }

        
        
    }
}