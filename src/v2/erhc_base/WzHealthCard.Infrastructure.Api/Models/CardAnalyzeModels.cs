
namespace WzHealthCard.Infrastructure.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

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

    public class CardUseAnalyzeCreateRequest
    {
        [Required]
        public string empi { get; set; }

        public string cardId { get; set; }

        public string orgCode { get; set; }

        public string orgName { get; set; }

        public string idCardNo { get; set; }

        public string msCode { get; set; }

        public string medType { get; set; }

        public string depType { get; set; }

        public string depCode { get; set; }

        [Required]
        public string appId { get; set; }

        [Required]
        public int appSource { get; set; }
    }

    public class CardUseAnalyzeCreateResponse
    {
        public long id { get; set; }
    }

    public class CardApplyAnalyzeCreateRequest
    {
        [Required]
        public string empi { get; set; }

        public string cardId { get; set; }

        public string appMode { get; set; }

        [Required]
        public string appId { get; set; }

        [Required]
        public int appSource { get; set; }
    }

    public class CardApplyAnalyzeCreateResponse
    {
        public long id { get; set; }
    }
}
