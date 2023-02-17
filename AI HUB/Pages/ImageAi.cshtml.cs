using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace AI_HUB.Pages
{
    public class ImageAiModel : PageModel
    {
        private readonly ILogger<ImageAiModel> _logger;
        private readonly IConfiguration _configuration;

        public ImageAiModel(ILogger<ImageAiModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string inputPrompt)
        {
             return new Controllers.ImageAiController(_configuration).GerarImagem(inputPrompt);
        }
    }
}