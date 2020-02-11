
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberAddressBySmallAppArgument : ApiArgumentDataValidation, IApiArgumentDataValidation
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("exAddr")]
        public string[] ExAddr { get; set; }

        [JsonProperty("exRegAddr")]
        public string[] ExRegAddr { get; set; }
    }
}
