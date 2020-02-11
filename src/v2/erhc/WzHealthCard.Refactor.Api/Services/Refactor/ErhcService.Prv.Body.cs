
namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using WzHealthCard.Refactor.Api.Models.Refactor;

    public class ErhcPrvBodyInParm<TBody> where TBody : class
    {
        public TBody body { get; set; }
    }

    public class ErhcPrvBodyParameter
    {
        // [Required, StringLength(50)]
        public string name { get; set; }

        // [Required, StringLength(2)]
        public string idcard_type { get; set; }

        // [Required, StringLength(32)]
        public string idcard_value { get; set; }
    }

    public class ErhcPrv11001BodyParm : ErhcPrvBodyParameter
    {
        // [Required]
        // [StringLength(16)]
        public string tel { get; set; }

        // [Required]
        // [StringLength(2)]
        public string sex { get; set; }

        // [Required]
        // [StringLength(2)]
        public string appmode { get; set; }

        // [Required]
        // [StringLength(2)]
        public string terminal_type { get; set; }

        // [StringLength(3)]
        public string citizenship { get; set; }

        // [StringLength(2)]
        public string nationality { get; set; }

        // [StringLength(200)]
        public string address { get; set; }

        // [StringLength(19)]
        //[RegularExpression(@"^(((20[0-3][0-9]-(0[13578]|1[02])-(0[1-9]|[12][0-9]|3[01]))|(20[0-3][0-9]-(0[2469]|11)-(0[1-9]|[12][0-9]|30))) (20|21|22|23|[0-1][0-9]):[0-5][0-9]:[0-5][0-9])$")]
        public string birthday { get; set; }

        // [StringLength(200)]
        public string birthPlace { get; set; }

        // [StringLength(250)]
        public string domicile { get; set; }
    }

    public class ErhcPrv11001Body : ErhcPrvBodyInParm<ErhcPrv11001BodyParm>
    {
        public ErhcPrv11001Body(ErhcmemberApplyArgument arg)
        {
            body = new ErhcPrv11001BodyParm
            {
                name = arg.Name,
                idcard_type = arg.IdCardType,
                idcard_value = arg.IdCardValue,
                tel = arg.Tel,
                sex = arg.Sex,
                appmode = arg.AppMode,
                terminal_type = arg.TerminalType,
                citizenship = arg.Citizenship,
                nationality = arg.Nationality,
                address = arg.Address,
                //birthday = arg.Birthday.ToString("yyyy-MM-dd"),
                // fix 20190826/birthday allow empty
                birthday = arg.Birthday,
                birthPlace = arg.BirthPlace,
                domicile = arg.Domicile
            };
        }
    }

    public class ErhcPrv11002BodyParm : ErhcPrvBodyParameter
    {
        // [Required]
        // [StringLength(130)]
        public string qrcode_info { get; set; }

        // [Required]
        // [StringLength(2)]
        public string sex { get; set; }

        // [Required]
        // [StringLength(2)]
        public string appmode { get; set; }

        // [Required]
        // [StringLength(2)]
        public string terminal_type { get; set; }

        // [StringLength(3)]
        public string citizenship { get; set; }

        // [StringLength(2)]
        public string nationality { get; set; }

        // [StringLength(16)]
        public string tel { get; set; }

        // [StringLength(200)]
        public string address { get; set; }

        // [StringLength(19)]
        public string birthday { get; set; }

        // [StringLength(200)]
        public string birthPlace { get; set; }

        // [StringLength(250)]
        public string domicile { get; set; }
    }

    public class ErhcPrv11002Body : ErhcPrvBodyInParm<ErhcPrv11002BodyParm>
    {
        public ErhcPrv11002Body(ErhcmemberModifyArgument arg)
        {
            body = new ErhcPrv11002BodyParm
            {
                name = arg.Name,
                idcard_type = arg.IdCardType,
                idcard_value = arg.IdCardValue,
                tel = arg.Tel,
                sex = arg.Sex,
                appmode = arg.AppMode,
                terminal_type = arg.TerminalType,
                citizenship = arg.Citizenship,
                nationality = arg.Nationality,
                address = arg.Address,
                birthday = arg.Birthday.ToString("yyyy-MM-dd"),
                birthPlace = arg.BirthPlace,
                domicile = arg.Domicile,
                // TODO: no qrcode_info mapping
                //qrcode_info = "6EEBA13B5B65D775DC090D61FD11E40B9F7BFDF8FDACF29B5AF40841D7FACC7E"
                qrcode_info = arg.QRCodeInfo
            };
        }
    }

    public class ErhcPrv11003BodyParm : ErhcPrvBodyParameter
    {
        // [Required]
        // [StringLength(2)]
        public string appmode { get; set; }

        // [Required]
        // [StringLength(2)]
        public string terminal_type { get; set; }

        // [StringLength(16)]
        public string tel { get; set; }
    }

    public class ErhcPrv11003Body : ErhcPrvBodyInParm<ErhcPrv11003BodyParm>
    {
        public ErhcPrv11003Body(ErhcmemberCancelArgument arg)
        {
            body = new ErhcPrv11003BodyParm
            {
                appmode = arg.AppMode,
                terminal_type = arg.TerminalType,
                // TODO: no qrcode_info mapping
                //name = "戚泸锋",
                //idcard_type = "01",
                //idcard_value = "330324197907212091",
                //tel = "18958813531"
                name = arg.Name,
                idcard_type = arg.IdCardType,
                idcard_value = arg.IdCardValue,
                tel = arg.Tel
            };
        }
    }

    public class ErhcPrv11004BodyParm : ErhcPrvBodyParameter { }

    public class ErhcPrv11004Body : ErhcPrvBodyInParm<ErhcPrv11004BodyParm>
    {
        public ErhcPrv11004Body(ErhcmemberQrCodeStaticArgument arg)
        {
            body = new ErhcPrv11004BodyParm
            {
                idcard_type = arg.IdcardType,
                idcard_value = arg.IdcardValue,
                name = arg.Name
            };
        }
    }

    public class ErhcPrv12001BodyParm
    {
        //[Required]
        //[StringLength(130)]
        public string qrcode_info { get; set; }

        //[Required]
        //[StringLength(2)]
        public string med_type { get; set; }

        //[Required]
        //[StringLength(2)]
        public string dep_type { get; set; }

        //[Required]
        //[StringLength(4)]
        public string dep_code { get; set; }

        //[Required]
        //[StringLength(4)]
        public string med_stepcode { get; set; }

        //[Required]
        //[StringLength(2)]
        public string appmode { get; set; }

        //[Required]
        //[StringLength(2)]
        public string terminal_type { get; set; }
    }

    public class ErhcPrv12001Body : ErhcPrvBodyInParm<ErhcPrv12001BodyParm>
    {
        public ErhcPrv12001Body(ErhcmemberVerifyHospitalArgument arg)
        {
            body = new ErhcPrv12001BodyParm
            {
                appmode = arg.Appmode,
                dep_code = arg.DepCode,
                dep_type = arg.DepType,
                med_stepcode = arg.MedStepcode,
                med_type = arg.MedType,
                qrcode_info = arg.QrcodeInfo,
                terminal_type = arg.TerminalType
            };
        }
    }

    public class ErhcPrv12002BodyParm : ErhcPrvBodyParameter { }

    public class ErhcPrv12002Body : ErhcPrvBodyInParm<ErhcPrv12002BodyParm>
    {
        public ErhcPrv12002Body(ErhcmemberApplyQueryArgument arg)
        {
            body = new ErhcPrv12002BodyParm
            {
                name = arg.Name,
                idcard_type = arg.IdCardType,
                idcard_value = arg.IdCardValue
            };
        }
    }
}