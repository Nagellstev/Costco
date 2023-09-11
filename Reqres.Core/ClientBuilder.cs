using Costco.Utilities.Logger;
using RestSharp;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.X86;

namespace Reqres.Core
{
    public class ClientBuilder
    {
        public RestClientOptions Options { get; set; } = new();
        public HttpRequestHeaders Headers { get; set; } = new HttpRequestMessage().Headers;

        public Client GetClient()
        { 
            return new Client(new RestClient(Options, Configure));
        }

        public void Configure(HttpRequestHeaders headers)
        {
            headers = Headers;
        }
    }
}