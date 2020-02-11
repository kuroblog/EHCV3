using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Xuhui.Internetpro.WzHealthCardService
{
    public partial class TempeCardQuerySingleArgument
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
    }
}