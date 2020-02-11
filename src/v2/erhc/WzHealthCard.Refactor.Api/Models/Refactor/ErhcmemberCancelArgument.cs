
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberCancelArgument
    {
        /// <summary>
        /// 电子健康卡 ID
        /// </summary>
        /// <example>
        /// 26B5A1FE56681
        /// </example>
        /// <value>
        /// 不能为空.可存储64个字符.合理长度应不大于64.
        /// </value>
        [JsonProperty("erhcCardNO")]
        public string ErhcCardNO { get; set; }

        /// <summary>
        /// APP 申请方式
        /// </summary>
        /// <remarks>
        /// 参照【APP 申请方式】
        /// </remarks>
        /// <example>
        /// 1
        /// </example>
        /// <value>
        /// 不能为空.可存储2个字符.合理长度应不大于2.
        /// </value>
        [JsonProperty("appMode")]
        public string AppMode { get; set; }

        /// <summary>
        /// 终端类型
        /// </summary>
        /// <remarks>
        /// 参照【刷卡终端类型】
        /// </remarks>
        /// <example>
        /// 02
        /// </example>
        /// <value>
        /// 不能为空.可存储2个字符.合理长度应不大于2.
        /// </value>
        [JsonProperty("terminalType")]
        public string TerminalType { get; set; }


        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("idCardType")]
        public string IdCardType { get; set; }

        [JsonProperty("idCardValue")]
        public string IdCardValue { get; set; }

        [JsonProperty("tel")]
        public string Tel { get; set; }
    }
}