/*此标记表明此文件可被设计器更新,如果不允许此操作,请删除此行代码.design by:agebull designer date:2019/1/30 14:33:40*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace Xuhui.Internetpro.WzHealthCardService
{
    /// <summary>
    /// 电子健康卡身份验证（医院）返回值
    /// </summary>
    [DataContract,JsonObject(MemberSerialization.OptIn)]
    public partial class ErhcmemberVerifyHospitalResponse
    {
        
        /// <summary>
        /// 主索引 ID
        /// </summary>
        /// <remarks>
        /// 个人唯一识别号
        /// </remarks>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("empi", NullValueHandling = NullValueHandling.Ignore)]
        public string Empi
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
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("erhc_cardno", NullValueHandling = NullValueHandling.Ignore)]
        public string ErhcCardno
        {
            get;
            set;
        }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
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
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("sex", NullValueHandling = NullValueHandling.Ignore)]
        public string Sex
        {
            get;
            set;
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("idcard_no", NullValueHandling = NullValueHandling.Ignore)]
        public string IdcardNo
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
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("idcard_type", NullValueHandling = NullValueHandling.Ignore)]
        public string IdcardType
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
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("idcard_value", NullValueHandling = NullValueHandling.Ignore)]
        public string IdcardValue
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
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("citizenship", NullValueHandling = NullValueHandling.Ignore)]
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
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("nationality", NullValueHandling = NullValueHandling.Ignore)]
        public string Nationality
        {
            get;
            set;
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("tel", NullValueHandling = NullValueHandling.Ignore)]
        public string Tel
        {
            get;
            set;
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address
        {
            get;
            set;
        }
        /// <summary>
        /// 健康卡签发机构代码
        /// </summary>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("issuer_orgcode", NullValueHandling = NullValueHandling.Ignore)]
        public string IssuerOrgcode
        {
            get;
            set;
        }
        /// <summary>
        /// 健康卡签发机构名称
        /// </summary>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("issuer_orgname", NullValueHandling = NullValueHandling.Ignore)]
        public string IssuerOrgname
        {
            get;
            set;
        }
        /// <summary>
        /// 健康卡失效日期
        /// </summary>
        [DataMember , JsonProperty("erhc_endDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ErhcEndDateTime
        {
            get;
            set;
        }
        /// <summary>
        /// 居民签约代扣标志
        /// </summary>
        /// <remarks>
        /// 0=未签约；1=已签约【签约过程由居民通过 App 自主完成操作。】
        /// </remarks>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [DataMember , JsonProperty("user_sign", NullValueHandling = NullValueHandling.Ignore)]
        public string UserSign
        {
            get;
            set;
        }
    }
}