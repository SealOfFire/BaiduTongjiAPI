using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report
{
    public class HeaderRequest
    {
        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("account_type")]
        public string AccountType { get; set; }
    }
}
