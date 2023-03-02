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
            // var response = 
            // return response
        }
    }
}
