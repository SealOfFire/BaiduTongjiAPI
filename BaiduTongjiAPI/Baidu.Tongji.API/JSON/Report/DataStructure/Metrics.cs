namespace Baidu.Tongji.API.JSON.Report.DataStructure
{
    public enum Metrics
    {
        /// <summary>
        /// pv_count(浏览量(PV)),
        /// </summary>
        PageViewCount,

        /// <summary>
        ///  visitor_count(访客数(UV)),
        /// </summary>
        VisitorCount,

        /// <summary>
        /// ip_count(IP数),
        /// </summary>
        IPCount,

        /// <summary>
        /// bounce_ratio(跳出率，%),
        /// </summary>
        BounceRatio,

        /// <summary>
        /// avg_visit_time(平均访问时长，秒),
        /// </summary>
        AVGVisitTime,

        /// <summary>
        /// trans_count(转化次数),
        /// </summary>
        TransCount,

        /// <summary>
        ///  contri_pv(百度推荐贡献浏览量),
        /// </summary>
        ContriPageView
    }
}
