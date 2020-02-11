using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Xuhui.Internetpro.WzHealthCardService
{
    /// <summary>
    /// 临时电子健康卡验证参数
    /// </summary>
    [DataContract, JsonObject(MemberSerialization.OptIn)]
    public partial class TempeCardVerifyArgument
    {

        /// <summary>
        /// 电子健康卡二维码内容（密文）。
        /// </summary>
        [DataMember, JsonProperty("qrcode_info", NullValueHandling = NullValueHandling.Ignore)]
        public string QrCodeInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 就诊类型，参见数据字典【就诊类型】
        /// </summary>
        [DataMember, JsonProperty("med_type", NullValueHandling = NullValueHandling.Ignore)]
        public string MedType
        {
            get;
            set;
        }

        /// <summary>
        /// 科室类型，参见数据字典【科室类型】
        /// </summary>
        [DataMember, JsonProperty("dep_type", NullValueHandling = NullValueHandling.Ignore)]
        public string DepType
        {
            get;
            set;
        }

        /// <summary>
        /// 刷卡科室代码，参照【标准科室代码】
        /// </summary>
        [DataMember, JsonProperty("dep_code", NullValueHandling = NullValueHandling.Ignore)]
        public string DepCode
        {
            get;
            set;
        }

        /// <summary>
        /// 诊疗环节代码，参照【诊疗环节代码】
        /// </summary>
        [DataMember, JsonProperty("med_stepcode", NullValueHandling = NullValueHandling.Ignore)]
        public string MedStepCode
        {
            get;
            set;
        }

        /// <summary>
        /// APP 申请方式，参照【APP 申请方式】
        /// </summary>
        [DataMember, JsonProperty("appmode", NullValueHandling = NullValueHandling.Ignore)]
        public string AppMode
        {
            get;
            set;
        }

        /// <summary>
        /// 终端类型，参照【刷卡终端类型】
        /// </summary>
        [DataMember, JsonProperty("terminal_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TerminalType
        {
            get;
            set;
        }

    }
}