using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Xuhui.Internetpro.WzHealthCardService
{
    /// <summary>
    /// 临时电子健康卡申请请求参数
    /// </summary>
    [DataContract, JsonObject(MemberSerialization.OptIn)]
    public partial class TempeCardApplyArgument
    {


        /// <summary>
        /// 姓名
        /// </summary>
        /// <example>
        /// 张三
        /// </example>
        /// <value>
        /// 不能为空.可存储50个字符.合理长度应不大于50.
        /// </value>
        [DataMember, JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name
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
        /// 不能为空.可存储2个字符.合理长度应不大于2.
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
        /// 根据证件类型传入相应的证件号码,暂时仅支持“居民身份证号码”
        /// </remarks>
        /// <example>
        /// 350424200101011100
        /// </example>
        /// <value>
        /// 不能为空.可存储32个字符.合理长度应不大于32.
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
        /// 不能为空.可存储16个字符.合理长度应不大于16.
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
        /// 性别
        /// </summary>
        /// <remarks>
        /// 参照【性别】
        /// </remarks>
        /// <example>
        /// 1
        /// </example>
        /// <value>
        /// 不能为空.可存储2个字符.合理长度应不大于2.
        /// </value>
        [DataMember, JsonProperty("sex", NullValueHandling = NullValueHandling.Ignore)]
        public string Sex
        {
            get;
            set;
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        /// <example>
        /// 2001-1-1
        /// </example>
        [DataMember, JsonProperty("birthday", NullValueHandling = NullValueHandling.Ignore)]
        public string Birthday
        {
            get;
            set;
        }
        /// <summary>
        /// 出生地
        /// </summary>
        /// <example>
        /// 北京
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember, JsonProperty("birthPlace", NullValueHandling = NullValueHandling.Ignore)]
        public string BirthPlace
        {
            get;
            set;
        }
        /// <summary>
        /// 户籍所在地址
        /// </summary>
        /// <example>
        /// 北京市朝阳区霄云路50号
        /// </example>
        /// <value>
        /// 可存储250个字符.合理长度应不大于250.
        /// </value>
        [DataMember, JsonProperty("domicile", NullValueHandling = NullValueHandling.Ignore)]
        public string Domicile
        {
            get;
            set;
        }
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
        [DataMember, JsonProperty("appMode", NullValueHandling = NullValueHandling.Ignore)]
        public string AppMode
        {
            get;
            set;
        }
        /// <summary>
        /// 终端类型
        /// </summary>
        /// <remarks>
        /// 参照【刷卡终端类型】
        /// </remarks>
        /// <example>
        /// 99
        /// </example>
        /// <value>
        /// 不能为空.可存储2个字符.合理长度应不大于2.
        /// </value>
        [DataMember, JsonProperty("terminalType", NullValueHandling = NullValueHandling.Ignore)]
        public string TerminalType
        {
            get;
            set;
        }

        /// <summary>
        /// 有效日期截止,失效日期
        /// </summary>
        [DataMember, JsonProperty("deadline", NullValueHandling = NullValueHandling.Ignore)]
        public string Deadline
        {
            get;set;
        }
    }
}