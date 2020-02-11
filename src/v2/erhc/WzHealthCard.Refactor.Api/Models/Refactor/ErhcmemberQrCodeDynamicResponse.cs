
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberQrCodeDynamicResponse
    {
        /// <summary>
        /// 主索引 ID
        /// </summary>
        /// <remarks>
        /// 个人唯一识别号
        /// </remarks>
        /// <value>
        /// 可存储64个字符.合理长度应不大于64.
        /// </value>
        [JsonProperty("EMPI")]
        public string EMPI { get; set; }

        /// <summary>
        /// 电子健康卡 ID
        /// </summary>
        /// <remarks>
        /// 电子健康卡账户的唯一识别号
        /// </remarks>
        /// <value>
        /// 可存储64个字符.合理长度应不大于64.
        /// </value>
        [JsonProperty("erhcCardNo")]
        public string ErhcCardNo { get; set; }

        /// <summary>
        /// 电子健康卡二维码图片
        /// </summary>
        /// <remarks>
        /// PNG 格式,base64 编码）
        /// </remarks>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("qrCodeImageInfo")]
        public string QrCodeImageInfo
        {
            set { qrCodeInfo = value; }
            get { return qrCodeInfo.Replace("\n", string.Empty); }
        }

        private string qrCodeInfo;
        /// <summary>
        /// 二维码有效时间
        /// </summary>
        /// <remarks>
        /// 单位为分钟。
        /// </remarks>
        [JsonProperty("qrCodeVaildDateTime")]
        public int QrCodeVaildDateTime { get; set; }

        private string _eSocialSecurityCard_Sign;

        [JsonProperty("eSocialSecurityCard_Sign")]
        public string eSocialSecurityCard_Sign
        {
            set => _eSocialSecurityCard_Sign = value;
            get
            {
                switch (_eSocialSecurityCard_Sign)
                {
                    case "2": return "1";
                    case "0": return "1";
                    case "1": return "0";
                    default: return _eSocialSecurityCard_Sign;
                }
            }
        }
    }
}