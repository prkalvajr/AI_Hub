using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace Test.OpenAI
{
    [TestClass]
    public class Image
    {

        [TestMethod]
        public void GetListModels()
        {
            var api = new API.OpenAI.ImageAPI(new Config().getConfig());
            api.GetModels();
        }

        [TestMethod]
        public void TestGenerateImage()
        {
            var api = new API.OpenAI.ImageAPI(new Config().getConfig());
            API.OpenAI.ImageAPIModel model = new API.OpenAI.ImageAPIModel();
            var response = api.GenerateImages("a cat with glasses drinking milk");

            // TODO Terminar teste
        }

        // TODO testar gerar variação.
    }
}
