
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ErhcmemberQrCodeDynamicArgument : ApiArgumentDataValidation, IApiArgumentDataValidation
    {
        /// <summary>
        /// 电子健康卡 ID
        /// </summary>
        /// <example>
        /// 26B5A1FE56681
        /// </example>
        /// <value>
        /// 不能为空.可存储64个字符.合理长度应不大于64.
        /// </value>
        [JsonProperty("erhcCardNo")]
        public string ErhcCardNo { get; set; }

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
        [JsonProperty("appMode")]
        public string AppMode { get; set; }

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
        [JsonProperty("terminalType")]
        public string TerminalType { get; set; }

        [JsonProperty("qrCodeType")]
        public string QrCodeType { get; set; } = "2";

        //public string lng { get; set; }

        //public string lat { get; set; }

        [JsonProperty("EMPI")]
        public string EMPI { get; set; }

        [JsonProperty("idCardType")]
        public string IdCardType { get; set; }

        [JsonProperty("idCardValue")]
        public string IdCardValue { get; set; }

        public override (bool isSuccessful, List<string> propertyKeys) Validation()
        {
            var (isSuccessful, propertyKeys) = base.Validation();

            if (string.IsNullOrEmpty(IdCardType))
            {
                propertyKeys.Add("idCardType");
            }

            if (string.IsNullOrEmpty(QrCodeType))
            {
                propertyKeys.Add("qrCodeType");
            }

            if (string.IsNullOrEmpty(TerminalType))
            {
                propertyKeys.Add("terminalType");
            }

            if (string.IsNullOrEmpty(AppMode))
            {
                propertyKeys.Add("appMode");
            }

            if (string.IsNullOrEmpty(IdCardValue))
            {
                propertyKeys.Add("idCardValue");
            }

            return (propertyKeys.Count == 0, propertyKeys);
        }
    }
}