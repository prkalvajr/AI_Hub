using API.OpenAI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Security.Policy;

namespace AI_HUB.Controllers
{
    public class ImageAiController : Controller
    {
        private readonly IConfiguration _config;
        API.OpenAI.ImageAPI objApi;

        public ImageAiController(IConfiguration config)
        {
            _config = config;
            objApi = new API.OpenAI.ImageAPI(config);
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
                string jsonRetorno = objApi.GenerateImages(inputPrompt);
                var lstImagens = new List<Models.ImageAi.Image>();

                var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonRetorno);
                JObject json = JObject.Parse(jsonRetorno);

                foreach (var item in jsonObject.data)
                {
                    lstImagens.Add(new Models.ImageAi.Image() { url = item.url.ToString(), created = (long)json["created"] });
                }

                ViewBag.ImagesId = json["created"].ToString();
                return View("ImageAi", lstImagens);
            }
        }

        public IActionResult Variation(string url)
        {
            ViewBag.Imagem = url;
            return View("Variation", new List<Models.ImageAi.Image>());
        }

        public IActionResult GerarVariacao(string url)
        {
            ViewBag.Imagem = url;
            string decodedUrl = Uri.UnescapeDataString(url);
            var jsonRetorno = objApi.GenerateVariation(url);

            var jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonRetorno);
            var lstVariacao = new List<Models.ImageAi.Image>();

            foreach (var item in jsonObject.data)
                lstVariacao.Add(new Models.ImageAi.Image() { url = item.url.ToString() });

            return View("Variation", lstVariacao);
        }

        public IActionResult Download(string url)
        {
            byte[] byteArray = new HttpClient().GetByteArrayAsync(url).Result;
            return File(byteArray, "image/jpeg", "image.jpg");
        }
    }
}
