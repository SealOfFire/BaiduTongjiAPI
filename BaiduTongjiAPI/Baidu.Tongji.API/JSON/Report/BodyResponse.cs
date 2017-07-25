using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report
{
    public class BodyResponse
    {
        [JsonProperty("data")]
        public DataResponse[] Data { set; get; }
    }
}
