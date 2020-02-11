
namespace WzHealthCard.Infrastructure.Api.DataAccess.Erhc
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("t_erhc_card")]
    public class CardEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Empi { get; set; }

        public string ErhcCardNo { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public string IdCardNo { get; set; }

        public string IdCardType { get; set; }

        public string IdCardValue { get; set; }

        public string Citizenship { get; set; }

        public string Nationality { get; set; }

        public string Tel { get; set; }

        public string Address { get; set; }

        public string IssuerOrgCode { get; set; }

        public string IssuerOrgName { get; set; }

        public string ErhcEndDate { get; set; }

        public string QrCodeType { get; set; }

        public string QrCodeImageData { get; set; }

        public string UserSign { get; set; }

        public string IsApply { get; set; }

        public bool? IsClosed { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
