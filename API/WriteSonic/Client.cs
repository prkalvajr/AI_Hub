using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System;
using System.Net.Http;
using API.OpenAI;
using System.Net.Mime;
using System.Text.Json;
using System.Text;
using RestSharp;

namespace API.WriteSonic
{
    public class Client
    {
        private readonly IConfiguration _config;
        private static HttpClient client = new HttpClient() { };

        public Client(string baseUrl, IConfiguration config)
        {
            _config = config;
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["writeSonicKey"]);
        }

        public string Post(string url, RequestModel model)
        {
            
            // var restClient = new RestClient(url);
            // restClient.AddDefaultHeader("Accept", "application/json");
            // restClient.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["writesonicKey"]);
            // var request = new RestRequest(url, Method.Post);
            // request.AddHeader("accept", "application/json");
            // request.AddHeader("content-type", "application/json");
            // request.AddParameter("application/json", JsonSerializer.Serialize(model), ParameterType.RequestBody);
            // RestResponse response = restClient.Execute(request);



             var request = new HttpRequestMessage
             {
                 Method = HttpMethod.Post,
                 RequestUri = new Uri(url),
                 Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, MediaTypeNames.Application.Json),
             };
            
             var response = client.SendAsync(request).Result;
             response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }


    }
}
