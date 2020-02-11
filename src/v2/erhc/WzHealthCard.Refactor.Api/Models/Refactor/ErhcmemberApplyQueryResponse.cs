
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ErhcmemberApplyQueryResponse
    {
        /// <summary>
        /// 电子健康卡是否已申请
        /// </summary>
        /// <remarks>
        /// （0= 未申请； 1= 已申请）
        /// </remarks>
        /// <example>
        /// 1
        /// </example>
        /// <value>
        /// 可存储2个字符.合理长度应不大于2.
        /// </value>
        //[DataMember , JsonProperty("isApply")]
        [JsonProperty("isApply")]
        public string IsApply { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        /// <remarks>
        /// （ 账户登录名）,【已申请时返回】
        /// </remarks>
        /// <example>
        /// 350424200101011100
        /// </example>
        /// <value>
        /// 可存储18个字符.合理长度应不大于18.
        /// </value>
        [JsonProperty("idCardNo")]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        /// <remarks>
        /// 参照【性别】,【已申请时返回】
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
        /// 手机号码
        /// </summary>
        /// <remarks>
        /// 【已申请时返回】
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
        /// 主索引ID
        /// </summary>
        /// <remarks>
        /// 个人唯一识别号。【已申请时返回】
        /// </remarks>
        /// <example>
        /// 26B5A1FE56681
        /// </example>
        /// <value>
        /// 可存储64个字符.合理长度应不大于64.
        /// </value>
        [JsonProperty("empi")]
        public string Empi { get; set; }

        /// <summary>
        /// 电子健康卡ID
        /// </summary>
        /// <remarks>
        /// 电子健康卡账户的唯一识别号。【已申请时返回】
        /// </remarks>
        /// <example>
        /// 26B5A1FE56681
        /// </example>
        /// <value>
        /// 可存储64个字符.合理长度应不大于64.
        /// </value>
        [JsonProperty("erhcCardNo")]
        public string ErhcCardNo { get; set; }
    }
}