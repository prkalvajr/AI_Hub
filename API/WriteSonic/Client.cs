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
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("X-API-KEY", _config["writeSonicKey"]);
        }

        public string Post(string url, RequestModel model)
        {

            var client = new RestClient("https://api.writesonic.com/v1/business/photosonic/generate-image");
            var request = new RestRequest(url, Method.Post);
            request.AddHeader("accept", "application/json");
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-API-KEY", "bb447162-7360-454f-abd8-5295295fb57d");
            request.AddParameter("application/json", "{\"num_images\":2,\"image_width\":512,\"image_height\":512,\"prompt\":\"Test\"}", ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}
