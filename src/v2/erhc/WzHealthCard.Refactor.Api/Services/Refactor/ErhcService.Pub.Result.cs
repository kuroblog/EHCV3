
namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    public class ErhcPubResultInParm<TResult> where TResult : class
    {
        public int code { get; set; }

        public string msg { get; set; }

        public string tradeCode { get; set; }

        public TResult data { get; set; }
    }

    public class ErhcPub30001ResultParm
    {
        public string erhcCardNo { get; set; }

        public string name { get; set; }

        public string sex { get; set; }

        public string idCardType { get; set; }

        public string idCardVaule { get; set; }

        public string qrCodeType { get; set; }

        public string qrCodeVaildDate { get; set; }

        public string qrCodeImageInfo { get; set; }

        public string qrContent { get; set; }

        public string tel { get; set; }

        public string nationality { get; set; }

        public string citizenship { get; set; }

        public string address { get; set; }

        public string issuerOrgCode { get; set; }

        public string issuerOrgName { get; set; }

        public long erhcEndDate { get; set; }

        public string birthPlace { get; set; }

        public string domicile { get; set; }

        public string birthday { get; set; }

        public string empi { get; set; }
    }

    public class ErhcPub30001Result : ErhcPubResultInParm<ErhcPub30001ResultParm> { }

    public class ErhcPub30002ResultParm
    {
        public string erhcCardNo { get; set; }

        public long erhcEndDate { get; set; }

        public string empi { get; set; }
    }

    public class ErhcPub30002Result : ErhcPubResultInParm<ErhcPub30002ResultParm> { }

    public class ErhcPub30003ResultParm
    {
        public string empi { get; set; }

        public string erhcCardNo { get; set; }

        public string name { get; set; }

        public string idCardType { get; set; }

        public string idCardVaule { get; set; }

        public string qrCodeType { get; set; }

        public string qrCodeContent { get; set; }

        public string qrCodeVaildDate { get; set; }
    }

    public class ErhcPub30003Result : ErhcPubResultInParm<ErhcPub30003ResultParm> { }

    public class ErhcPub30005ResultParm
    {
        public string empi { get; set; }

        public string erhcCardNo { get; set; }

        public string sex { get; set; }

        public string idCardNo { get; set; }

        public string tel { get; set; }

        public string isApply { get; set; }
    }

    public class ErhcPub30005Result : ErhcPubResultInParm<ErhcPub30005ResultParm> { }

    public class ErhcPub30004ResultParm
    {
        public string qrCodeVaildDate { get; set; }

        public string qrCodeImageInfo { get; set; }

        public string erhcCardNo { get; set; }

        public string empi { get; set; }
    }

    public class ErhcPub30004Result : ErhcPubResultInParm<ErhcPub30004ResultParm> { }
}