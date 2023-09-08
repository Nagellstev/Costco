using Costco.Utilities.Logger;
using RestSharp;
using System;

namespace Reqres.Core
{
    public class Client
    {
        private RestClient _client;

        internal Client(RestClient restClient) 
        {
            _client = restClient;
        }

        public RestResponse Get(string url)
        {
            return _client.Execute(FormRequest(url, Method.Get));
        }

        public RestResponse Post(string url, string body)
        {
            return _client.Execute(FormRequest(url, Method.Post, body));
        }

        public RestResponse Put(string url, string body)
        {
            return _client.Execute(FormRequest(url, Method.Put, body));
        }

        public RestResponse Patch(string url, string body)
        {
            return _client.Execute(FormRequest(url, Method.Patch, body));
        }

        public RestResponse Delete(string url, string body)
        {
            return _client.Execute(FormRequest(url, Method.Delete));
        }

        private RestRequest FormRequest(string url, Method method, string body = "")
        {
            RestRequest request = new(url);
            request.Method = method;
            request.AddBody(body);
            return request;
        }
    }
}
