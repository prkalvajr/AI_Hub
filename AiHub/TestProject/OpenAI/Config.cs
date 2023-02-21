using Microsoft.Extensions.Configuration;
using System.IO;

namespace Test.OpenAI
{
    public class Config
    {
        public Config() { }

        public IConfiguration getConfig()
        {
            var config = new ConfigurationBuilder()
              .SetBasePath("/Users/Kalva/AppData/Roaming/Microsoft/UserSecrets/ed382a16-8a95-40b4-b033-13beece0bc7b")
              .AddJsonFile("secrets.json")
              .Build();
            return config;
        }
    }
}
