
namespace WzHealthCard.Refactor.Api.DataAccess.Erhc
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("t_erhc_use_analyze")]
    public class UseAnalyzeEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Empi { get; set; }

        public string CardId { get; set; }

        public string OrgCode { get; set; }

        public string OrgName { get; set; }

        public string IdCardNo { get; set; }

        public string MsCode { get; set; }

        public string MedType { get; set; }

        public string DepType { get; set; }

        public string DepCode { get; set; }

        public string CityCode { get; set; }

        public string DistCde { get; set; }

        public string PayType { get; set; }

        public decimal Amount { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
