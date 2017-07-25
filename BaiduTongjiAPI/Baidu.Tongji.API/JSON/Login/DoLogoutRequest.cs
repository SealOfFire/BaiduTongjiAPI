using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Login
{
    public class DoLogoutRequest : Request
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ucid")]
        public long UCID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("st")]
        public string ST { get; set; }
    }
}
