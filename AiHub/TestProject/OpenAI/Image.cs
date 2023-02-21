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
            API.OpenAI.Image model = new API.OpenAI.Image();
            var response = api.GenerateImage("a cat with glasses drinking milk");

            // var response = image.g
        }
    }
}
