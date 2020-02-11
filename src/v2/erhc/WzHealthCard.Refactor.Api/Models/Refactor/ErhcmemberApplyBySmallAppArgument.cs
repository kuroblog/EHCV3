
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberApplyBySmallAppArgument : ErhcmemberApplyArgument
    {
        [JsonProperty("exAddr")]
        public string[] ExAddr { get; set; }

        [JsonProperty("exRegAddr")]
        public string[] ExRegAddr { get; set; }

    }

    public class ErhcmemberApplyBySmallAppResponse : ErhcmemberApplyResponse { }
}
