using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report
{
    public class ReportResponse
    {
        [JsonProperty("header")]
        public HeaderResponse Header { get; set; }

        [JsonProperty("body")]
        public BodyResponse Body { get; set; }
    }
}
