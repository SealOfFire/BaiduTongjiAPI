using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Login
{
    public class DoLogoutResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("retcode")]
        public int ReturnCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("retmsg")]
        public string ReturnMessage { get; set; }
    }
}
