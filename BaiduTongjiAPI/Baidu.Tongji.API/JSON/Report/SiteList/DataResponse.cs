using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report.SiteList
{
    public class DataResponse
    {
        [JsonProperty("list")]
        public SiteInfo[] List { get; set; }
    }
}
