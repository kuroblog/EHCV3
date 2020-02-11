
namespace WzHealthCard.Refactor.Api.DataAccess.Erhc
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tb_tempecard")]
    public class TempCardEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public string empi { get; set; }

        public string erhc_card_no { get; set; }

        public string name { get; set; }

        public string sex { get; set; }

        public string id_card_no { get; set; }

        public string id_card_type { get; set; }

        public string id_card_value { get; set; }

        public string citizenship { get; set; }

        public string nationality { get; set; }

        public string tel { get; set; }

        public string address { get; set; }

        public string issuer_org_code { get; set; }

        public string issuer_org_name { get; set; }

        public string deadline { get; set; }

        public string qr_code_type { get; set; }

        public string qr_code_image_data { get; set; }

        public string user_sign { get; set; }

        public string is_apply { get; set; }

        public string is_closed { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }

        public string token { get; set; }

        public string data_sources { get; set; }

        public string request_id { get; set; }

        public string app_mode { get; set; }

        public string terminal_type { get; set; }

        public string birth_place { get; set; }

        public string domicile { get; set; }
    }
}
