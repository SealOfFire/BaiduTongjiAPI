using Newtonsoft.Json;
using System;

namespace Baidu.Tongji.API.JSON.Report.SiteList
{
    public class SiteInfo
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        [JsonProperty("site_id")]
        public uint SiteId { get; set; }

        /// <summary>
        /// 站定域名
        /// </summary>
        [JsonProperty("domain")]
        public string Domain { get; set; }

        /// <summary>
        /// 0：正常/1：暂停
        /// </summary>
        [JsonProperty("status")]
        public uint Status { get; set; }

        /// <summary>
        /// 日期时间格式，以北京时间表示
        /// </summary>
        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 子目录列表
        /// </summary>
        [JsonProperty("sub_dir_list")]
        public SubDirInfo[] SubDirList { get; set; }
    }
}
