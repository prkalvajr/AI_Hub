using System;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace API.OpenAI
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

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config["openAiApiKey"]);
        }

        public string Get(string url)
        {
            using HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;
            return responseBody;
        }

        public string Post(string url, ImageAPIModel model)
        {
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

        public string Post(string url, ImageAPIModel model, string imageUrl)
        {
            HttpResponseMessage imageResponse = new HttpClient().GetAsync(imageUrl).Result;
            Stream imageStream = imageResponse.Content.ReadAsStreamAsync().Result;
            MultipartFormDataContent form = new MultipartFormDataContent();
             
            form.Add(new StreamContent(imageStream), "image", "@otter.png");
            form.Add(new StringContent(model.n.ToString()), "n");
            form.Add(new StringContent(model.size), "size");

            HttpResponseMessage response = client.PostAsync(url, form).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
    }  
}
