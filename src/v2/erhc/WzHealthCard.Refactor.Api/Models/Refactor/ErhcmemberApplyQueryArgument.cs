
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberApplyQueryArgument : ApiArgumentDataValidation, IApiArgumentDataValidation
    {
        /// <summary>
        /// 身份证件类型
        /// </summary>
        /// <remarks>
        /// 参照【身份证件类型】
        /// </remarks>
        /// <example>
        /// 01
        /// </example>
        /// <value>
        /// 不能为空.可存储2个字符.合理长度应不大于2.
        /// </value>
        [JsonProperty("idCardType")]
        public string IdCardType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        /// <remarks>
        /// 根据证件类型传入相应的证件号码,暂时仅支持“居民身份证号码”
        /// </remarks>
        /// <example>
        /// 350424200101011100
        /// </example>
        /// <value>
        /// 不能为空.可存储32个字符.合理长度应不大于32.
        /// </value>
        [JsonProperty("idCardValue")]
        public string IdCardValue { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        /// <example>
        /// 张三
        /// </example>
        /// <value>
        /// 不能为空.可存储50个字符.合理长度应不大于50.
        /// </value>
        [JsonProperty("name")]
        public string Name
        {
            get;
            set;
        }
    }
}