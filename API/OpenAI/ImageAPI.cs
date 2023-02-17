using Microsoft.Extensions.Configuration;

namespace API.OpenAI
{
    public class ImageAPI
    {
        // utilizar baseUrl; e baseUrl + "" nos metodos...
        const string modelsUrl = "https://api.openai.com/v1/models";
        const string imagesUrl = "https://api.openai.com/v1/images/generations";

        Client client;

        public ImageAPI(IConfiguration config) 
        {
            client = new Client(imagesUrl, config);
        }

        public string GetModels()
        {
            return client.Get(modelsUrl);
        }

        public string GenerateImage(string prompt)
        {
            var response = client.Post(imagesUrl, new Image { prompt = prompt, n = 1, size = "1024x1024", response_format = "b64_json" });
            return response;
        }

    }
}
