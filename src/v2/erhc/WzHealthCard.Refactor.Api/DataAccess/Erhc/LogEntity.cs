
namespace WzHealthCard.Refactor.Api.DataAccess.Erhc
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("t_log")]
    public class LogEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string RequestId { get; set; }

        public string DataType { get; set; }

        public string DataContent { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
