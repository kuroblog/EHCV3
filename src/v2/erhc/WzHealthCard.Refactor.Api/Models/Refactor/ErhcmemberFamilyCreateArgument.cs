
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberFamilyBaseItem : ApiArgumentDataValidation, IApiArgumentDataValidation
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("relType")]
        public string RelType { get; set; }

        [JsonProperty("idCardType")]
        public string IdCardType { get; set; }

        [JsonProperty("idCardValue")]
        public string IdCardValue { get; set; }
    }

    public class ErhcmemberFamilyCreateArgument : ErhcmemberFamilyBaseItem
    {
        [JsonProperty("empi")]
        public string Empi { get; set; }
    }

    public class ErhcmemberFamilyResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
