using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Login
{
    public class Header
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("functionName")]
        public string FunctionName { get; set; }

        [JsonProperty("uuid")]
        public string UUID { get; set; }

        [JsonProperty("request")]
        public Request Request { get; set; }
    }
}
