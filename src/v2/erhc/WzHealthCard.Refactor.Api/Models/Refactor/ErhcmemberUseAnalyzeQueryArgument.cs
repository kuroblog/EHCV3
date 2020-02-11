
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberUseAnalyzeQueryArgument : ApiArgumentDataValidation, IApiArgumentDataValidation
    {
        [JsonProperty("cardId")]
        public string cardId { get; set; }

        [JsonProperty("empi")]
        public string empi { get; set; }

        [JsonProperty("idCardNo")]
        public string idCardNo { get; set; }
    }
}
