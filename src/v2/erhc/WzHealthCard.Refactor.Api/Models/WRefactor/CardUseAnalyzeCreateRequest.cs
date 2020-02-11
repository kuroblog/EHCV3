using System.ComponentModel.DataAnnotations;

namespace Xuhui.Internetpro.WzHealthCardService
{

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
}