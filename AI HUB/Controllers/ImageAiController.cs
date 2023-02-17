using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AI_HUB.Controllers
{
    public class ImageAiController : Controller
    {
        private readonly IConfiguration _config;

        public ImageAiController()
        {

        }

        public ImageAiController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult GerarImagem(string inputPrompt)
        {
            if (string.IsNullOrEmpty(inputPrompt))
            {
                // campo vazio - retorna uma mensagem de erro
                return Content("Por favor, preencha o campo de texto.");
            }
            else
            {
                var objApi = new API.OpenAI.ImageAPI(_config);
                string jsonRetorno = objApi.GenerateImage(inputPrompt);
                JObject json = JObject.Parse(jsonRetorno);
                var b64 = json["data"][0]["b64_json"]; // Retornar e renderizar

                byte[] imageBytes = Convert.FromBase64String(b64.ToString());
                MemoryStream stream = new MemoryStream(imageBytes);
                string mimeType = "image/png"; // substitua pelo tipo MIME apropriado da imagem
                return File(stream, mimeType);
            }
        }
    }

    public class ImageResponse
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public string b64_json { get; set; }
    }
}
    