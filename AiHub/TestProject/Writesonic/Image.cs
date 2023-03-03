using Test.OpenAI;

namespace Test.Writesonic
{
    [TestClass]
    public class Image
    {

        [TestMethod]
        public void TestGenerateImage()
        {
            var api = new API.WriteSonic.Image(new Config().getConfig());
            var response = api.GenerateImages("a cat with glasses drinking milk");
            Assert.IsTrue(Ext.IsJsonValid(response));
        }

    }
}
