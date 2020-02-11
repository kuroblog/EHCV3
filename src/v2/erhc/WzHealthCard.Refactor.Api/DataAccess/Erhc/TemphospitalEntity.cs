
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WzHealthCard.Refactor.Api.DataAccess.Erhc
{

    [Table("tb_temphospital")]
    public class TempHospitalEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public string qrcode_info { get; set; }

        public string med_type { get; set; }

        public string dep_type { get; set; }

        public string dep_code { get; set; }

        public string med_stepcode { get; set; }

        public string appmode { get; set; }

        public string terminal_type { get; set; }

        public DateTime? create_date { get; set; }

        public string empi { get; set; }

        public string erhc_cardno { get; set; }

        public string name { get; set; }

        public string sex { get; set; }

        public string idcard_no { get; set; }

        public string idcard_type { get; set; }

        public string idcard_value { get; set; }

        public string citizenship { get; set; }

        public string nationality { get; set; }

        public string tel { get; set; }

        public string address { get; set; }

        public DateTime? erhc_end_date_time { get; set; }

        public string issuer_orgcode { get; set; }

        public string issuer_orgname { get; set; }

        public string user_sign { get; set; }
    }
}
