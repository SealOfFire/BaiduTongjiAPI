using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report.SiteList
{
    public class BodyResponse
    {
        [JsonProperty("data")]
        public DataResponse[] Data { set; get; }
    }
}
