
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberQrCodeStaticResponse
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
        [JsonProperty("empi")]
        public string Empi { get; set; }

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
        [JsonProperty("erhc_cardno")]
        public string ErhcCardno { get; set; }

        /// <summary>
        /// 电子健康卡二维码图片
        /// </summary>
        /// <remarks>
        /// PNG 格式,base64 编码
        /// </remarks>
        /// <example>
        /// Base64;png;ADFED====
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("qrcode_imagedata")]
        public string QrcodeImagedata
        {
            set { qrCodeInfo = value; }
            get { return qrCodeInfo.Replace("\n", string.Empty); }
        }

        private string qrCodeInfo;
    }
}