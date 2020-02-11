
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ErhcmemberFamilyReadArgument : ApiArgumentDataValidation, IApiArgumentDataValidation
    {
        [JsonProperty("empi")]
        public string Empi { get; set; }


        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public class ErhcmemberFamilyReadResponse
    {
        [JsonProperty("families")]
        public ErhcmemberFamilyItem[] Families { get; set; }
    }

    public class ErhcmemberFamilyItem : ErhcmemberFamilyBaseItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("EMPI")]
        public string Empi { get; set; }

        [JsonProperty("erhcCardNo")]
        public string ErhcCardNo { get; set; }

        //[JsonProperty("name")]
        //public string Name { get; set; }

        [JsonProperty("sex")]
        public string Sex { get; set; }

        [JsonProperty("idCardNo")]
        public string IdCardNo { get; set; }

        //[JsonProperty("idCardType")]
        //public string IdCardType { get; set; }

        //[JsonProperty("idCardValue")]
        //public string IdCardValue { get; set; }

        [JsonProperty("citizenship")]
        public string Citizenship { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("tel")]
        public string Tel { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("issuerOrgCode")]
        public string IssuerOrgCode { get; set; }

        [JsonProperty("issuerOrgName")]
        public string IssuerOrgName { get; set; }

        [JsonProperty("erhcEndDateTime")]
        public string ErhcEndDateTime { get; set; }

        [JsonProperty("qrCodeType")]
        public string QrCodeType { get; set; }

        [JsonProperty("qrCodeImageInfo")]
        public string QrCodeImageInfo { get; set; }
    }
}
