using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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
            Assert.IsTrue(Ext.IsJsonValid(response));
        }

        [TestMethod]
        public string TestGenerateOneImage()
        {
            var api = new API.OpenAI.ImageAPI(new Config().getConfig());
            var response = api.GenerateImage(new API.OpenAI.ImageAPIModel
            {
                prompt = "A test",
                n = 1,
                size = "512x512",
                response_format = "url"
            });

            Assert.IsTrue(Ext.IsJsonValid(response));
            return response;
        }

        [TestMethod]
        public void TestGenerateVariation()
        {
            var api = new API.OpenAI.ImageAPI(new Config().getConfig());
            var response = TestGenerateOneImage();

            var jsonObject = JsonConvert.DeserializeObject<dynamic>(response);
            response = api.GenerateVariation(jsonObject.data[0].url.ToString());

            Assert.IsTrue(Ext.IsJsonValid(response));
        }
    }
}
