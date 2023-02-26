using System.Text.Json.Serialization;

namespace API.OpenAI
{
    // https://platform.openai.com/docs/api-reference/images/create
    public class ImageAPIModel
    {
        public string prompt { get; set; }
        public int n { get; set; }
        public string size { get; set; }
        public string response_format { get; set; }
        // public string user { get; set; }
    }
}
