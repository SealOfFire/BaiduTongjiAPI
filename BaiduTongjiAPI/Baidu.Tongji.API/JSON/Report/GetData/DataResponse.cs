using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report.GetData
{
    public class DataResponse
    {
        [JsonProperty("result")]
        public ReportData Result { get; set; }
    }
}
