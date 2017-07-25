using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Login
{
    public class AuthCode
    {
        [JsonProperty("imgtype")]
        public string ImageType { get; set; }

        [JsonProperty("imgdata")]
        public string ImageData { get; set; }

        [JsonProperty("imgssid")]
        public string ImageServiceSetIdentifier { get; set; }
    }
}
