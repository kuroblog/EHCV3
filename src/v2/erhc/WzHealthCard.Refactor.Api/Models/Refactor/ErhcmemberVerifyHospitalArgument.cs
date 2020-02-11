
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ErhcmemberVerifyHospitalArgument : ApiArgumentDataValidation, IApiArgumentDataValidation
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
        [JsonProperty("qrcode_info")]
        public string QrcodeInfo { get; set; }

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
        [JsonProperty("med_type")]
        public string MedType { get; set; }

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
        [JsonProperty("dep_type")]
        public string DepType { get; set; }

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
        [JsonProperty("dep_code")]
        public string DepCode { get; set; }

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
        [JsonProperty("med_stepcode")]
        public string MedStepcode { get; set; }

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
        [JsonProperty("appmode")]
        public string Appmode { get; set; }

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
        [JsonProperty("terminal_type")]
        public string TerminalType { get; set; }

        public override (bool isSuccessful, List<string> propertyKeys) Validation()
        {
            var (isSuccessful, propertyKeys) = base.Validation();

            if (string.IsNullOrEmpty(QrcodeInfo))
            {
                propertyKeys.Add("qrcode_info");
            }

            if (string.IsNullOrEmpty(MedType))
            {
                propertyKeys.Add("med_type");
            }

            if (string.IsNullOrEmpty(DepType))
            {
                propertyKeys.Add("dep_type");
            }

            if (string.IsNullOrEmpty(DepCode))
            {
                propertyKeys.Add("dep_code");
            }

            if (string.IsNullOrEmpty(MedStepcode))
            {
                propertyKeys.Add("med_stepcode");
            }

            if (string.IsNullOrEmpty(Appmode))
            {
                propertyKeys.Add("appmode");
            }

            if (string.IsNullOrEmpty(TerminalType))
            {
                propertyKeys.Add("terminal_type");
            }

            return (propertyKeys.Count == 0, propertyKeys);
        }
    }
}