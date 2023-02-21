using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                string jsonRetorno = objApi.GenerateImage(inputPrompt);

                JObject json = JObject.Parse(jsonRetorno);
                ViewBag.ImageId = json["created"];
                ViewBag.ImageBase64 = json["data"][0]["b64_json"].ToString();
                return View("ImageAi");
            }
        }

        public IActionResult Download(string b64)
        {
            byte[] bytes = Convert.FromBase64String(ViewBag.ImageBase64);
            string nomeArquivo = "ImageAi_" + ViewBag.ImageId + ".png";
            return File(bytes, "image/png", nomeArquivo);
        }

        // byte[] imageBytes = Convert.FromBase64String(b64.ToString());
        // MemoryStream stream = new MemoryStream(imageBytes);
        // string mimeType = "image/png"; // substitua pelo tipo MIME apropriado da imagem
        //return File(stream, mimeType);
    }
}
    