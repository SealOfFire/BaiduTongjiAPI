using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report
{
    public class SiteListResponse
    {
        [JsonProperty("data")]
        public DataResponse[] Data { set; get; }
    }
}
