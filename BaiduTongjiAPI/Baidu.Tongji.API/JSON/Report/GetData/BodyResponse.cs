using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report.GetData
{
    public class BodyResponse
    {
        [JsonProperty("data")]
        public DataResponse[] Data { set; get; }
    }
}
