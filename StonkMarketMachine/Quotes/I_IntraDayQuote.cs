using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace StonkMarketMachine.Quotes
{
    public interface I_IntraDayQuote
    {
        Task<string> GetIntraDayQuote();
        Task<JObject> GetData(string _endpoint);
    }
}
