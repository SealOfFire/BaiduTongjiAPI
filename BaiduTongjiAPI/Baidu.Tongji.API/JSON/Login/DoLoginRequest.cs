using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Login
{
    public class DoLoginRequest : Request
    {
        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
