using Microsoft.Extensions.Configuration;

namespace API.WriteSonic
{
    public class Image
    {
        const string baseUrl = "https://api.writesonic.com/v1/business/photosonic/generate-image";

        Client client;

        public Image(IConfiguration config)
        {
            client = new Client(baseUrl, config);
        }

        public string GenerateImages(string prompt)
        {
            return client.Post(baseUrl, new RequestModel() { prompt = prompt, image_height = 512, image_width = 512, num_images = 6 });
        }
    }
}
