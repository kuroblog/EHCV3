using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Xuhui.Internetpro.WzHealthCardService
{
    /// <summary>
    /// 临时电子健康卡申请返回值
    /// </summary>
    [DataContract, JsonObject(MemberSerialization.OptIn)]
    public class TempeCardUpdateResponse
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
        /// 健康卡失效日期
        /// </summary>
        /// <example>
        /// 2099-12-31
        /// </example>
        [DataMember, JsonProperty("deadline", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Deadline
        {
            get;
            set;
        }
    }
}