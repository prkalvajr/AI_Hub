using System;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace API.OpenAI
{
    public class Client
    {
        private readonly IConfiguration _config;
        private static HttpClient client = new HttpClient() { };

        public Client(string baseUrl, IConfiguration config) 
        {
            _config = config;

            if (client != null) { 
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["openAiApiKey"]);
            }
            
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
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, MediaTypeNames.Application.Json /* or "application/json" in older versions */),
            };

            var response = client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }

    }  
}
