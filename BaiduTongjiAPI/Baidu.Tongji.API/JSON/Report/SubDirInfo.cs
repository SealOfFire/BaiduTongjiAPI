using Newtonsoft.Json;
using System;

namespace Baidu.Tongji.API.JSON.Report
{
    public class SubDirInfo
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        [JsonProperty("sub_dir_id")]
        public uint SubSiteId { get; set; }

        /// <summary>
        /// 站定域名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

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
