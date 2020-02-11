
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;
    using System;

    public class HostTimeResponse
    {
        /// <summary>
        /// 中心服务系统时间
        /// </summary>
        /// <example>
        /// 2019-01-01 08:00:00
        /// </example>
        [JsonProperty("server_time")]
        public DateTime ServerTime { get; set; }
    }
}