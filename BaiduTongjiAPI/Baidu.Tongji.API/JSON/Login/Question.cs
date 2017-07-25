using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Login
{
    public class Question
    {
        /// <summary>
        /// 安全問題ID
        /// </summary>
        [JsonProperty("qid")]
        public int QuestionId { get; set; }

        /// <summary>
        /// 安全問題字面
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
