
namespace WzHealthCard.Refactor.Api.DataAccess.Erhc
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("t_erhc_apply_analyze")]
    public class ApplyAnalyzeEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Empi { get; set; }

        public string CardId { get; set; }

        public string AppMode { get; set; }

        public string AppId { get; set; }

        public string CityCode { get; set; }

        public string DistCode { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
