using System;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace API.OpenAI
{
    public class Client
    {
        private readonly IConfiguration _config;
        private static HttpClient client = new HttpClient() { };

        public Client(string baseUrl, IConfiguration config) 
        {
            _config = config;
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["openAiApiKey"]);
        }

        public string Get(string url)
        {
            using HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;
            return responseBody;
        }

        public string Post(string url, Image model)
        {
            var content = new StringContent(JsonSerializer.Serialize(model));
            var response = client.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
    }  
}
