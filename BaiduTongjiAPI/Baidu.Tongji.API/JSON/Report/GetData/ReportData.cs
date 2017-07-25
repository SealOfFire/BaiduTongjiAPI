using Baidu.Tongji.API.JSON.Report.DataStructure;
using Newtonsoft.Json;

namespace Baidu.Tongji.API.JSON.Report.GetData
{
    public class ReportData
    {
        /// <summary>
        /// 指标列表
        /// </summary>
        [JsonProperty("fields")]
        public string[] Fields { get; set; }

        /// <summary>
        /// 总计数据
        /// </summary>
        [JsonProperty("sum")]
        public string[,] Sum { get; set; }

        /// <summary>
        /// 指标数据，有4部分组成
        /// 0：维度数据
        /// 1：指标数据
        /// 2：对比时间数据
        /// 3：变化率数据
        /// </summary>
        [JsonProperty("items")]
        [JsonConverter(typeof(ReportItemJsonConverter))]
        public ReportItem Items { get; set; }

        /// <summary>
        /// 总计条目
        /// </summary>
        [JsonProperty("total")]
        public uint Total { get; set; }

        [JsonProperty("timeSpan")]
        public string[] TimeSpan { get; set; }
    }
}
