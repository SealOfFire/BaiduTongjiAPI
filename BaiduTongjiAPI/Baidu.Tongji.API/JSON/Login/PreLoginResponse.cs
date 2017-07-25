using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Login
{
    public class PreLoginResponse
    {
        [JsonProperty("needAuthCode")]
        public bool NeedAuthCode { get; set; }

        [JsonProperty("authCode")]
        public AuthCode AuthCode { get; set; }
    }
}
