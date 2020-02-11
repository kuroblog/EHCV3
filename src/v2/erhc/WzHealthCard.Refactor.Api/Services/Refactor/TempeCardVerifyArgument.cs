
namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using Newtonsoft.Json;
    using WzHealthCard.Refactor.Api.Models.Refactor;

    public class TempeCardVerifyArgument
    {
        /// <summary>
        /// 电子健康卡二维码内容（密文）。
        /// </summary>
        [JsonProperty("qrcode_info")]
        public string QrCodeInfo { get; set; }

        /// <summary>
        /// 就诊类型，参见数据字典【就诊类型】
        /// </summary>
        [JsonProperty("med_type")]
        public string MedType { get; set; }

        /// <summary>
        /// 科室类型，参见数据字典【科室类型】
        /// </summary>
        [JsonProperty("dep_type")]
        public string DepType { get; set; }

        /// <summary>
        /// 刷卡科室代码，参照【标准科室代码】
        /// </summary>
        [JsonProperty("dep_code")]
        public string DepCode { get; set; }

        /// <summary>
        /// 诊疗环节代码，参照【诊疗环节代码】
        /// </summary>
        [JsonProperty("med_stepcode")]
        public string MedStepCode { get; set; }

        /// <summary>
        /// APP 申请方式，参照【APP 申请方式】
        /// </summary>
        [JsonProperty("appmode")]
        public string AppMode { get; set; }

        /// <summary>
        /// 终端类型，参照【刷卡终端类型】
        /// </summary>
        [JsonProperty("terminal_type")]
        public string TerminalType { get; set; }

        #region 参数转化
        /// <summary>
        /// 转换参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ApiArgument<TempeCardVerifyArgument> Converter(
            ApiArgument<ErhcmemberVerifyHospitalArgument> model)
        {
            ApiArgument<TempeCardVerifyArgument> argument = new ApiArgument<TempeCardVerifyArgument>
            {
                Header = model.Header,
                Data = new TempeCardVerifyArgument
                {
                    AppMode = model.Data.Appmode,
                    DepCode = model.Data.DepCode,
                    DepType = model.Data.DepType,
                    MedStepCode = model.Data.MedStepcode,
                    MedType = model.Data.MedType,
                    QrCodeInfo = model.Data.QrcodeInfo,
                    TerminalType = model.Data.TerminalType
                }
            };
            return argument;
        }
        #endregion
    }
}