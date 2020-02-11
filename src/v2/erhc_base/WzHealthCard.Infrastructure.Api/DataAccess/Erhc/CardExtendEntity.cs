
namespace WzHealthCard.Infrastructure.Api.DataAccess.Erhc
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("t_erhc_card_extend")]
    public class CardExtendEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string AddrLv0 { get; set; }

        public string AddrLv1 { get; set; }

        public string AddrLv2 { get; set; }

        public string AddrLv3 { get; set; }

        public string AddrLv4 { get; set; }

        public string AddrLv5 { get; set; }

        public string DAddrLv0 { get; set; }

        public string DAddrLv1 { get; set; }

        public string DAddrLv2 { get; set; }

        public string DAddrLv3 { get; set; }

        public string DAddrLv4 { get; set; }

        public string DAddrLv5 { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public long ErhcCardId { get; set; }

        public string StaticQrCode { get; set; }
    }
}
