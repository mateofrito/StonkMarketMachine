// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace StonkMarketMachine.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\mattf\source\repos\StonkMarketMachine\StonkMarketMachine\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mattf\source\repos\StonkMarketMachine\StonkMarketMachine\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\mattf\source\repos\StonkMarketMachine\StonkMarketMachine\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\mattf\source\repos\StonkMarketMachine\StonkMarketMachine\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\mattf\source\repos\StonkMarketMachine\StonkMarketMachine\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\mattf\source\repos\StonkMarketMachine\StonkMarketMachine\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\mattf\source\repos\StonkMarketMachine\StonkMarketMachine\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\mattf\source\repos\StonkMarketMachine\StonkMarketMachine\_Imports.razor"
using StonkMarketMachine;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\mattf\source\repos\StonkMarketMachine\StonkMarketMachine\_Imports.razor"
using StonkMarketMachine.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mattf\source\repos\StonkMarketMachine\StonkMarketMachine\Pages\FetchData.razor"
using StonkMarketMachine.Quotes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\mattf\source\repos\StonkMarketMachine\StonkMarketMachine\Pages\FetchData.razor"
using Newtonsoft.Json.Linq;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 25 "C:\Users\mattf\source\repos\StonkMarketMachine\StonkMarketMachine\Pages\FetchData.razor"
      
    public string Quote { get; set; }
    public string LastRefreshed { get; set; }
    public string Error { get; set; }
    private JObject jObject { get; set; }


    private string GenerateIntraDayEndPoint()
    {
        //string _key = System.Environment.GetEnvironmentVariable("ALPHAVANTAGE_TOKEN");
        string _key = "EXGBU46FGX9CDJ24";
        string symbol = "IBM";
        string interval = "5";
        string _endpoint = "TIME_SERIES_INTRADAY&symbol=" + symbol + "&interval=" + interval + "min&apikey=" + _key + "&datatype=json&output_size=compact";
        return _endpoint;

    }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            string _endpoint = GenerateIntraDayEndPoint();
            jObject = await IntraDayQuote.GetData(_endpoint);
            GetQuote(jObject);
            //Quote = await IntraDayQuote.GetIntraDayQuote();
        }
        catch (Exception e)
        {
            Error = e.Message;
        }
    }

    private void GetQuote(JObject jObject)
    {
        LastRefreshed = (string)jObject["Meta Data"]["3. Last Refreshed"];
        Quote = (string)jObject["Time Series (5min)"][LastRefreshed]["1. open"];
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private I_IntraDayQuote IntraDayQuote { get; set; }
    }
}
#pragma warning restore 1591
