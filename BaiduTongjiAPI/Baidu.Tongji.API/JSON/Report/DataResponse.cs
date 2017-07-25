using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report
{
    public class DataResponse
    {
        [JsonProperty("list")]
        public SiteInfo[] List { get; set; }
    }
}
