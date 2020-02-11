using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Xuhui.Internetpro.WzHealthCardService
{
    /// <summary>
    /// 临时电子健康卡验证记录返回信息
    /// </summary>
    [DataContract, JsonObject(MemberSerialization.OptIn)]
    public partial class TempeCardVerifyReponse
    {
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
        [DataMember, JsonProperty("EMPI", NullValueHandling = NullValueHandling.Ignore)]
        public string EMPI
        {
            get;
            set;
        }
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
        [DataMember, JsonProperty("erhcCardNo", NullValueHandling = NullValueHandling.Ignore)]
        public string ErhcCardNo
        {
            get;
            set;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <example>
        /// 张三
        /// </example>
        /// <value>
        /// 可存储50个字符.合理长度应不大于50.
        /// </value>
        [DataMember, JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name
        {
            get;
            set;
        }
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
        [DataMember, JsonProperty("sex", NullValueHandling = NullValueHandling.Ignore)]
        public string Sex
        {
            get;
            set;
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        /// <example>
        /// 350424200101011100
        /// </example>
        /// <value>
        /// 可存储18个字符.合理长度应不大于18.
        /// </value>
        [DataMember, JsonProperty("idCardNo", NullValueHandling = NullValueHandling.Ignore)]
        public string IdCardNo
        {
            get;
            set;
        }
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
        [DataMember, JsonProperty("idCardType", NullValueHandling = NullValueHandling.Ignore)]
        public string IdCardType
        {
            get;
            set;
        }
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
        [DataMember, JsonProperty("idCardValue", NullValueHandling = NullValueHandling.Ignore)]
        public string IdCardValue
        {
            get;
            set;
        }
        /// <summary>
        /// 国籍
        /// </summary>
        /// <remarks>
        /// 参照【国籍】
        /// </remarks>
        /// <example>
        /// 156
        /// </example>
        /// <value>
        /// 可存储3个字符.合理长度应不大于3.
        /// </value>
        [DataMember, JsonProperty("citizenship", NullValueHandling = NullValueHandling.Ignore)]
        public string Citizenship
        {
            get;
            set;
        }
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
        [DataMember, JsonProperty("nationality", NullValueHandling = NullValueHandling.Ignore)]
        public string Nationality
        {
            get;
            set;
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        /// <example>
        /// 13812345678
        /// </example>
        /// <value>
        /// 可存储16个字符.合理长度应不大于16.
        /// </value>
        [DataMember, JsonProperty("tel", NullValueHandling = NullValueHandling.Ignore)]
        public string Tel
        {
            get;
            set;
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        /// <example>
        /// 北京市朝阳区霄云路50号
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember, JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address
        {
            get;
            set;
        }
        /// <summary>
        /// 健康卡签发机构代码
        /// </summary>
        /// <example>
        /// 0001
        /// </example>
        /// <value>
        /// 可存储10个字符.合理长度应不大于10.
        /// </value>
        [DataMember, JsonProperty("issuerOrgCode", NullValueHandling = NullValueHandling.Ignore)]
        public string IssuerOrgCode
        {
            get;
            set;
        }
        /// <summary>
        /// 健康卡签发机构名称
        /// </summary>
        /// <example>
        /// 浙江省温州市卫健委
        /// </example>
        /// <value>
        /// 可存储64个字符.合理长度应不大于64.
        /// </value>
        [DataMember, JsonProperty("issuerOrgName", NullValueHandling = NullValueHandling.Ignore)]
        public string IssuerOrgName
        {
            get;
            set;
        }
        /// <summary>
        /// 健康卡失效日期
        /// </summary>
        /// <example>
        /// 2099-12-31
        /// </example>
        [DataMember, JsonProperty("erhc_endDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? Deadline
        {
            get;
            set;
        }

        /// <summary>
        /// 居民签约代扣标志。（0=未签约；1=已签约）
        /// </summary>
        [DataMember, JsonProperty("user_sign", NullValueHandling = NullValueHandling.Ignore)]
        public string UserSign
        {
            get;set;
        }
    }
}