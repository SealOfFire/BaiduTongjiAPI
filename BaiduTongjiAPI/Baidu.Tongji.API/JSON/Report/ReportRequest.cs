using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report
{
    public class ReportRequest
    {
        [JsonProperty("header")]
        public HeaderRequest Header { get; set; }

        [JsonProperty("body")]
        public BodyRequest Body { get; set; }

        public ReportRequest()
        {
            this.Header = new HeaderRequest();
            this.Body = null;
        }
    }
}
