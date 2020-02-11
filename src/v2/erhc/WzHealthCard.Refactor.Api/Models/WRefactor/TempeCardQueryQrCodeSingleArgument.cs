using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Xuhui.Internetpro.WzHealthCardService
{
    public partial class TempeCardQueryQrCodeSingleArgument
    {
        /// <summary>
        /// 二维码内容
        /// </summary>
        [DataMember, JsonProperty("qrCodeInfo", NullValueHandling = NullValueHandling.Ignore)]
        public string QrCodeInfo
        {
            get;
            set;
        }

        #region 数据校验
        
        #endregion
    }
}