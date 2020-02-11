using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Xuhui.Internetpro.WzHealthCardService
{
    public class TempeCardQuerySingleResponse
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
    }
}