
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;
    using System;

    public class ErhcmemberModifyArgument
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
        [JsonProperty("erhcCardNo")]
        public string ErhcCardNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        /// <remarks>
        /// 不允许更新
        /// </remarks>
        /// <example>
        /// 张三
        /// </example>
        /// <value>
        /// 不能为空.可存储50个字符.合理长度应不大于50.
        /// </value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 身份证件类型
        /// </summary>
        /// <remarks>
        /// 参照【身份证件类型】,不允许更新
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
        /// 根据证件类型传入相应的证件号码,不允许更新
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
        /// 国籍
        /// </summary>
        /// <remarks>
        /// 参照【国籍】,允许更新
        /// </remarks>
        /// <example>
        /// 156
        /// </example>
        /// <value>
        /// 可存储3个字符.合理长度应不大于3.
        /// </value>
        [JsonProperty("citizenship")]
        public string Citizenship { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        /// <remarks>
        /// 参照【民族】,允许更新
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
        /// 手机号码
        /// </summary>
        /// <remarks>
        /// 允许更新
        /// </remarks>
        /// <example>
        /// 15121001136
        /// </example>
        /// <value>
        /// 可存储16个字符.合理长度应不大于16.
        /// </value>
        [JsonProperty("tel")]
        public string Tel { get; set; }

        /// <summary>
        /// 联系地址
        /// </summary>
        /// <remarks>
        /// 允许更新
        /// </remarks>
        /// <example>
        /// 北京市朝阳区霄云路50号
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        /// <remarks>
        /// 参照【性别】,允许更新
        /// </remarks>
        /// <example>
        /// 1
        /// </example>
        /// <value>
        /// 不能为空.可存储2个字符.合理长度应不大于2.
        /// </value>
        [JsonProperty("sex")]
        public string Sex { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        /// <remarks>
        /// 允许更新
        /// </remarks>
        /// <example>
        /// 2001-1-1
        /// </example>
        [JsonProperty("birthday")]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 出生地
        /// </summary>
        /// <remarks>
        /// 允许更新
        /// </remarks>
        /// <example>
        /// 北京
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("birthPlace")]
        public string BirthPlace { get; set; }

        /// <summary>
        /// 户籍所在地址
        /// </summary>
        /// <remarks>
        /// 允许更新
        /// </remarks>
        /// <example>
        /// 北京
        /// </example>
        /// <value>
        /// 可存储250个字符.合理长度应不大于250.
        /// </value>
        [JsonProperty("domicile")]
        public string Domicile { get; set; }

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


        [JsonProperty("qrCodeInfo")]
        public string QRCodeInfo { get; set; }

        [JsonProperty("exAddr")]
        public string[] ExAddr { get; set; }

        [JsonProperty("exRegAddr")]
        public string[] ExRegAddr { get; set; }

        [JsonProperty("id")]
        public long CardRefId { get; set; }
    }
}