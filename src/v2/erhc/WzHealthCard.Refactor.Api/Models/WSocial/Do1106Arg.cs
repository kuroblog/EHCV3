using System.Runtime.Serialization;
using Newtonsoft.Json;
using WzHealthCard.Refactor.Api.Models.Refactor;

namespace WzHealthCard.Refactor.Api.Models.WSocial
{
    /// <summary>
    /// 二维码申请
    /// </summary>
    public class Do1106Arg : ApiArgumentDataValidation, IApiArgumentDataValidation
    {
        /// <summary>
        /// 医院编码
        /// </summary>
        [JsonProperty("hosid")]
        public string hosid { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        [JsonProperty("hosname")]
        public string hosname { get; set; }

        /// <summary>
        /// 终端编号
        /// </summary>
        [JsonProperty("termid")]
        public string termid { get; set; }

        /// <summary>
        /// 终端型号
        /// </summary>
        [JsonProperty("terminfo")]
        public string terminfo { get; set; }

        /// <summary>
        /// 令牌请求内容
        /// </summary>
        [JsonProperty("ftokenurl")]
        public string ftokenurl { get; set; }
    }

    public class Do1106Result
    {
        /// <summary>
        /// 电子健康卡(电子社/医保卡)二维码
        /// </summary>
        [JsonProperty("qrCode")]
        public string qrCode { get; set; }

        /// <summary>
        /// 有效时间，单位秒
        /// </summary>
        [JsonProperty("validseconds")]
        public long validseconds { get; set; }

        /// <summary>
        /// 电子社保卡是否签发标志（0=未签发；1=已签发,其他非1或0 的情况表明未知，建议按是否等于1来判断）
        /// </summary>
        [JsonProperty("eSocialSecurityCard_Sign")]
        public string eSocialSecurityCard_Sign { get; set; }
    }
}