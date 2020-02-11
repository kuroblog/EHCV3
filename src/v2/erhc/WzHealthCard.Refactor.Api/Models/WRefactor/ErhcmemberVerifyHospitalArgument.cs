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
    /// 电子健康卡身份验证（医院）请求参数
    /// </summary>
    [DataContract,JsonObject(MemberSerialization.OptIn)]
    public partial class ErhcmemberVerifyHospitalArgument
    {
        
        /// <summary>
        /// 电子健康卡二维码内容
        /// </summary>
        /// <example>
        /// 54B952784EA1A695277A0177C53A49DD
        /// </example>
        /// <value>
        /// 不能为空.可存储130个字符.合理长度应不大于130.
        /// </value>
        [DataMember , JsonProperty("qrcode_info", NullValueHandling = NullValueHandling.Ignore)]
        public string QrcodeInfo
        {
            get;
            set;
        }
        /// <summary>
        /// 就诊类型
        /// </summary>
        /// <remarks>
        /// 参见数据字典【就诊类型】
        /// </remarks>
        /// <example>
        /// 0
        /// </example>
        /// <value>
        /// 不能为空.可存储2个字符.合理长度应不大于2.
        /// </value>
        [DataMember , JsonProperty("med_type", NullValueHandling = NullValueHandling.Ignore)]
        public string MedType
        {
            get;
            set;
        }
        /// <summary>
        /// 科室类型
        /// </summary>
        /// <remarks>
        /// 参见数据字典【科室类型】
        /// </remarks>
        /// <example>
        /// 1
        /// </example>
        /// <value>
        /// 不能为空.可存储2个字符.合理长度应不大于2.
        /// </value>
        [DataMember , JsonProperty("dep_type", NullValueHandling = NullValueHandling.Ignore)]
        public string DepType
        {
            get;
            set;
        }
        /// <summary>
        /// 刷卡科室代码
        /// </summary>
        /// <remarks>
        /// 参照【标准科室代码】
        /// </remarks>
        /// <example>
        /// 0100
        /// </example>
        /// <value>
        /// 不能为空.可存储4个字符.合理长度应不大于4.
        /// </value>
        [DataMember , JsonProperty("dep_code", NullValueHandling = NullValueHandling.Ignore)]
        public string DepCode
        {
            get;
            set;
        }
        /// <summary>
        /// 诊疗环节代码
        /// </summary>
        /// <remarks>
        /// 参照【诊疗环节代码】
        /// </remarks>
        /// <example>
        /// 010101
        /// </example>
        /// <value>
        /// 不能为空.可存储4个字符.合理长度应不大于4.
        /// </value>
        [DataMember , JsonProperty("med_stepcode", NullValueHandling = NullValueHandling.Ignore)]
        public string MedStepcode
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
        [DataMember , JsonProperty("appmode", NullValueHandling = NullValueHandling.Ignore)]
        public string Appmode
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
        /// 02
        /// </example>
        /// <value>
        /// 不能为空.可存储2个字符.合理长度应不大于2.
        /// </value>
        [DataMember , JsonProperty("terminal_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TerminalType
        {
            get;
            set;
        }
    }
}