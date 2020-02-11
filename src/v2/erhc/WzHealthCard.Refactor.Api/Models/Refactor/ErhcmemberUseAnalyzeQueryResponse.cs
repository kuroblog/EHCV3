
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;
    using System;

    public class CardUseAnalyzeQueryResponse
    {
        public string cardId { get; set; }

        public string empi { get; set; }

        public string orgName { get; set; }

        public DateTime payTime { get; set; }

        public decimal amount { get; set; }

        public string payType { get; set; }

        public string cityCode { get; set; }

        public string msCode { get; set; }

        public string medType { get; set; }

        public string depType { get; set; }

        public string depCode { get; set; }
    }

    public class ErhcmemberUseAnalyzeQueryResponse
    {
        [JsonProperty("items")]
        public CardUseAnalyzeQueryResponse[] datas { get; set; }
    }
}
