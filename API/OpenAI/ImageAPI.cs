using Microsoft.Extensions.Configuration;

namespace API.OpenAI
{
    public class ImageAPI
    {
        // utilizar baseUrl; e baseUrl + "" nos metodos...
        const string modelsUrl = "https://api.openai.com/v1/models";
        const string baseUrl = "https://api.openai.com/v1/images";

        Client client;

        public ImageAPI(IConfiguration config) 
        {
            client = new Client(baseUrl, config);
        }

        public string GetModels()
        {
            return client.Get(modelsUrl);
        }

        public string GenerateImages(string prompt)
        {
            var response = client.Post(baseUrl + "/generations", 
                new ImageAPIModel { prompt = prompt, n = 6, size = "512x512", response_format = "url"  });
            return response;
        }

        public string GenerateVariation(string image)
        {
            var response = client.Post(baseUrl + "/variations", 
                new VariationModel { n = 6, size = "512x512", response_format = "url" }, image);
            return response;
        }

    }
}
