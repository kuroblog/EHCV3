
namespace WzHealthCard.Infrastructure.Api.DataAccess.ErhcManage
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tb_app_app_info")]
    public class AppInfoEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public long org_id { get; set; }

        public string short_name { get; set; }

        public string full_name { get; set; }

        public int Classify { get; set; }

        public string app_key { get; set; }

        public string memo { get; set; }

        public string manag_orgcode { get; set; }

        public string manag_orgname { get; set; }

        public string city_code { get; set; }

        public string district_code { get; set; }

        public string org_address { get; set; }

        public string law_personname { get; set; }

        public string law_persontel { get; set; }

        public string contact_name { get; set; }

        public string contact_tel { get; set; }

        public string super_orgcode { get; set; }

        public DateTime update_date { get; set; }

        public string update_userid { get; set; }

        public string update_username { get; set; }

        [Required]
        public int data_state { get; set; }

        [Required]
        public bool is_freeze { get; set; }

        public DateTime add_date { get; set; }

        public long last_reviser_id { get; set; }

        public DateTime last_modify_date { get; set; }

        [Required]
        public long author_id { get; set; }

        [Required]
        public string sapp_id { get; set; }

        public string token { get; set; }
    }
}
