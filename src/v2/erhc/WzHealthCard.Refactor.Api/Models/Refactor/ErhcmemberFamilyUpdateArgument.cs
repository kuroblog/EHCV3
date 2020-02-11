
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberFamilyUpdateArgument : ErhcmemberFamilyItem
    {
        [JsonProperty("empi")]
        public new string Empi { get; set; }
    }
}
