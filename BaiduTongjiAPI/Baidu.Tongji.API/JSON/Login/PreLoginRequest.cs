using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Login
{
    public class PreLoginRequest : Request
    {
        [JsonProperty("osVersion")]
        public string OSVersion { get; set; }

        [JsonProperty("deviceType")]
        public string DeviceType { get; set; }

        [JsonProperty("clientVersion")]
        public string ClientVersion { get; set; }

        public PreLoginRequest()
        {
            this.Initialize();
        }

        public void Initialize()
        {
            this.ClientVersion = "1.0";
            this.OSVersion = "windows";
            this.DeviceType = "pc";
        }
    }
}
