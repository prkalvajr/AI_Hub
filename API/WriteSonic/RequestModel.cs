namespace API.WriteSonic
{
    public class RequestModel
    {
        public string prompt { get; set; }
        public int num_images { get; set; }
        public int image_width { get; set; }
        public int image_height { get; set; }
    }
}
