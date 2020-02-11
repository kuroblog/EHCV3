
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberFamilyDeleteArgument : ApiArgumentDataValidation, IApiArgumentDataValidation
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("empi")]
        public string Empi { get; set; }
    }
}
