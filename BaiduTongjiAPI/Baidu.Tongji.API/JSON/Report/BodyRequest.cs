using Baidu.Tongji.API.JSON.Report.DataStructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Baidu.Tongji.API.JSON.Report
{
    public class BodyRequest
    {
        private uint maxResults = 20;

        #region 基本参数

        /// <summary>
        /// 站点id
        /// </summary>
        [JsonProperty("site_id")]
        public uint SiteId { set; get; }

        /// <summary>
        /// 通常对应要查询的报告
        /// </summary>
        [JsonProperty("method")]
        public string Method { set; get; }

        /// <summary>
        /// 查询起始时间
        /// </summary>
        [JsonProperty("start_date")]
        [JsonConverter(typeof(DateFormatConverter), "yyyyMMdd")]
        public DateTime StartDate { set; get; }

        /// <summary>
        /// 查询结束时间
        /// </summary>
        [JsonProperty("end_date")]
        [JsonConverter(typeof(DateFormatConverter), "yyyyMMdd")]
        public DateTime EndDate { set; get; }

        /// <summary>
        /// 对比查询起始时间
        /// </summary>
        [JsonProperty("start_date2")]
        [JsonConverter(typeof(DateFormatConverter), "yyyyMMdd")]
        public DateTime StartDate2 { set; get; }

        /// <summary>
        /// 对比查询结束时间
        /// </summary>
        [JsonProperty("end_date2")]
        [JsonConverter(typeof(DateFormatConverter), "yyyyMMdd")]
        public DateTime EndDate2 { set; get; }

        /// <summary>
        /// 自定义指标选择，多个指标用逗号分隔
        /// </summary>
        [JsonProperty("metrics")]
        [JsonConverter(typeof(MetricsJsonConverter))]
        public SortedSet<Metrics> Metrics { get; set; }

        /// <summary>
        /// 时间粒度 day/hour/week/month
        /// </summary>
        [JsonProperty("gran")]
        [JsonConverter(typeof(EnumJsonConverter))]
        public Gran Gran { get; set; }

        /// <summary>
        /// 指标排序
        /// </summary>
        [JsonProperty("order")]
        [JsonConverter(typeof(MetricsJsonConverter))]
        public SortedSet<Metrics> Order { get; set; }

        /// <summary>
        /// 获取数据偏移,用于分页;默认0
        /// </summary>
        [JsonProperty("start_index")]
        public uint StartIndex { get; set; }

        /// <summary>
        /// 单词获取数据条数，用于分页；默认20；0表示获取所有数据。
        /// </summary>
        [JsonProperty("max_results")]
        public uint MaxResults { get { return this.maxResults; } set { this.maxResults = value; } }

        #endregion

        #region 筛选参数

        /// <summary>
        /// 访客过滤
        /// new：新访客
        /// old：老访客
        /// </summary>
        [JsonProperty("visitor")]
        [JsonConverter(typeof(EnumJsonConverter))]
        public Visitor? Visitor { set; get; }

        #endregion

        public BodyRequest()
        {
            this.Metrics = new SortedSet<Metrics>();
            this.Order = new SortedSet<Metrics>();
        }
    }
}
