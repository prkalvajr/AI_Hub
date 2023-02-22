using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Eventing.Reader;

namespace AI_HUB.Controllers
{
    public class ImageAiController : Controller
    {
        private readonly IConfiguration _config;

        public ImageAiController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult ImageAi()
        {
            return View();
        }

        public IActionResult GerarImagem(string inputPrompt)
        {
            if (string.IsNullOrEmpty(inputPrompt))
            {
                return Content("Por favor, preencha o campo de texto.");
            }
            else
            {
                var objApi = new API.OpenAI.ImageAPI(_config);
                string jsonRetorno = objApi.GenerateImages(inputPrompt);
                var lstImagens = new List<Models.ImageAi.Image>();

                var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonRetorno);
                JObject json = JObject.Parse(jsonRetorno);

                foreach (var item in jsonObject.data) 
                { 
                    lstImagens.Add( new Models.ImageAi.Image() { b64_json = item.b64_json.ToString(), created = (long)json["created"] });
                }

                ViewBag.ImagesId = json["created"].ToString();
                return View("ImageAi", lstImagens);
            }
        }

        public IActionResult GerarVariacao(long id)
        {
            return View("ImageAi");
        }
    }
}
    