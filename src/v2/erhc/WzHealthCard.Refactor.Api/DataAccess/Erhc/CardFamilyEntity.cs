
namespace WzHealthCard.Refactor.Api.DataAccess.Erhc
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("t_erhc_family")]
    public class CardFamilyEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Empi { get; set; }

        public string RelType { get; set; }

        public string IdCardType { get; set; }

        public string IdCardValue { get; set; }

        public string Name { get; set; }

        public bool? IsDeleted { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
