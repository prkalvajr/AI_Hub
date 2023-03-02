using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System;
using System.Net.Http;

namespace API.WriteSonic
{
    public class Client
    {
        private readonly IConfiguration _config;
        private static HttpClient client = new HttpClient() { };

        public Client(string baseUrl, IConfiguration config)
        {
            _config = config;

            if (client == null)
                client.BaseAddress = new Uri(baseUrl);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["writesonicKey"]);
        }
    }
}
