namespace Baidu.Tongji.API.JSON.Report.GetData
{
    public class ReportItem
    {
        /// <summary>
        /// 维度数据
        /// </summary>
        public string[] Dimension { get; set; }

        /// <summary>
        /// 指标数据
        /// </summary>
        public string[,] Metric { get; set; }

        /// <summary>
        /// 对比时间数据
        /// </summary>
        public string[,] ComparisonMetric { get; set; }

        /// <summary>
        /// 变化率数据
        /// </summary>
        public string[,] ChangeRate { get; set; }
    }
}
