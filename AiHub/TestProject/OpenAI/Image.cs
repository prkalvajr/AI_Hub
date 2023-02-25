using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;
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
            var response = api.GenerateImages("a cat with glasses drinking milk");
            Assert.IsTrue(IsJsonValid(response));
        }

        [TestMethod]
        public void TestGenerateVariation()
        {
            var api = new API.OpenAI.ImageAPI(new Config().getConfig());

        }

        public static bool IsJsonValid(this string txt)
        {
            try { return JsonDocument.Parse(txt) != null; } catch { }

            return false;
        }
        // TODO testar gerar variação.
    }
}
