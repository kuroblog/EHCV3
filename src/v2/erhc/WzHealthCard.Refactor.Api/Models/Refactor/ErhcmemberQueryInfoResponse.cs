
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberQueryInfoResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// 主索引 ID
        /// </summary>
        /// <remarks>
        /// 个人唯一识别号
        /// </remarks>
        /// <example>
        /// 26B5A1FE56681
        /// </example>
        /// <value>
        /// 可存储64个字符.合理长度应不大于64.
        /// </value>
        [JsonProperty("EMPI")]
        public string EMPI { get; set; }

        /// <summary>
        /// 电子健康卡 ID
        /// </summary>
        /// <remarks>
        /// 电子健康卡账户的唯一识别号
        /// </remarks>
        /// <example>
        /// 26B5A1FE56681
        /// </example>
        /// <value>
        /// 可存储64个字符.合理长度应不大于64.
        /// </value>
        [JsonProperty("erhcCardNo")]
        public string ErhcCardNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        /// <example>
        /// 张三
        /// </example>
        /// <value>
        /// 可存储50个字符.合理长度应不大于50.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        /// <remarks>
        /// 参照【性别】
        /// </remarks>
        /// <example>
        /// 1
        /// </example>
        /// <value>
        /// 可存储1个字符.合理长度应不大于1.
        /// </value>
        [JsonProperty("sex")]
        public string Sex { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        /// <example>
        /// 350424200101011100
        /// </example>
        /// <value>
        /// 可存储18个字符.合理长度应不大于18.
        /// </value>
        [JsonProperty("idCardNo")]
        public string IdCardNo { get; set; }

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
        /// 可存储2个字符.合理长度应不大于2.
        /// </value>
        [JsonProperty("idCardType")]
        public string IdCardType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        /// <remarks>
        /// 根据证件类型返回相应的证件号码
        /// </remarks>
        /// <example>
        /// 350424200101011100
        /// </example>
        /// <value>
        /// 可存储32个字符.合理长度应不大于32.
        /// </value>
        [JsonProperty("idCardValue")]
        public string IdCardValue { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        /// <remarks>
        /// 参照【民族】
        /// </remarks>
        /// <example>
        /// 01
        /// </example>
        /// <value>
        /// 可存储2个字符.合理长度应不大于2.
        /// </value>
        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        /// <example>
        /// 北京市朝阳区霄云路50号
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("exAddr")]
        public string[] ExAddr { get; set; }

        [JsonProperty("exRegAddr")]
        public string[] ExRegAddr { get; set; }

        [JsonProperty("tel")]
        public string Tel { get; set; }
    }
}