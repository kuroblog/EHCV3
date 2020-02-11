
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberQueryByPhoneArgument
    {
        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public class ErhcmemberQueryByPhoneResponse
    {
        [JsonProperty("cards")]
        public ErhcmemberQrCodeStaticResponse[] Cards { get; set; }
    }
}
