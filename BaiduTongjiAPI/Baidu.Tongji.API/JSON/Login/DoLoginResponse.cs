using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Login
{
    public class DoLoginResponse
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

        /// <summary>
        /// 用户 ucid
        /// </summary>
        [JsonProperty("ucid")]
        public long UCID { get; set; }

        /// <summary>
        /// 会话 ID
        /// </summary>
        [JsonProperty("st")]
        public string ST { get; set; }

        /// <summary>
        /// 是否是token登陆用户
        /// </summary>
        [JsonProperty("istoken")]
        public int IsToken { get; set; }

        /// <summary>
        /// 是否需要设置Pin码
        /// </summary>
        [JsonProperty("setpin")]
        public int SetPin { get; set; }

        /// <summary>
        /// 安全問題列表
        /// </summary>
        [JsonProperty("questions")]
        public Question[] Questions { get; set; }
    }
}
