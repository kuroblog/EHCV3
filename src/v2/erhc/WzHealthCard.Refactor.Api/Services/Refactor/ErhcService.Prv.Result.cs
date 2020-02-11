
namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    public class ErhcPrvResultInParm<TResult> where TResult : class
    {
        public TResult result { get; set; }
    }

    public class ErhcPrvResultInParm<TResult, TMSg> : ErhcPrvResultInParm<TResult> where TResult : class where TMSg : class
    {
        public TMSg msg { get; set; }
    }

    public class ErhcWseResultParameter
    {
        // [StringLength(5)]
        public string tradecode { get; set; }

        // [StringLength(5)]
        public string return_code { get; set; }

        // [StringLength(100)]
        public string return_info { get; set; }
    }

    public class ErhcPrv10001ResultParm
    {
        public string server_datetime { get; set; }
    }

    public class ErhcPrv10001Result
    {
        public ErhcPrvResultInParm<ErhcWseResultParameter, ErhcPrv10001ResultParm> body { get; set; }
    }

    public class ErhcPrv11001ResultParm
    {
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

        public string issuer_orgcode { get; set; }

        public string issuer_orgname { get; set; }

        public string erhc_enddate { get; set; }

        public string qrcode_type { get; set; }

        public string qrcode_imagedata { get; set; }
    }

    public class ErhcPrv11001Result
    {
        public ErhcPrvResultInParm<ErhcWseResultParameter, ErhcPrv11001ResultParm> body { get; set; }
    }

    public class ErhcPrv11002ResultParm
    {
        public string empi { get; set; }

        public string erhc_cardno { get; set; }

        public string erhc_enddate { get; set; }
    }

    public class ErhcPrv11002Result
    {
        public ErhcPrvResultInParm<ErhcWseResultParameter, ErhcPrv11002ResultParm> body { get; set; }
    }

    public class ErhcPrv11003Result
    {
        public ErhcPrvResultInParm<ErhcWseResultParameter> body { get; set; }
    }

    #region 静态二维码
    /// <summary>
    /// 静态二维码
    /// </summary>
    public class ErhcPrv11004ResultParm
    {
        /// <summary>
        /// 主索引 ID，个人唯一识别号
        /// </summary>
        public string empi { get; set; }
        /// <summary>
        /// 电子健康卡 ID，电子健康卡账户的唯一识别号
        /// </summary>
        public string erhc_cardno { get; set; }
        /// <summary>
        /// 电子健康卡二维码图片（PNG 格式，base64 编码）
        /// </summary>
        public string qrcode_imagedata { get; set; }
    }
    /// <summary>
    /// 静态二维码
    /// </summary>
    public class ErhcPrv11004Result
    {
        public ErhcPrvResultInParm<ErhcWseResultParameter, ErhcPrv11004ResultParm> body { get; set; }
    }
    #endregion

    #region 身份验证（医院）
    public class ErhcPrv12001ResultParm
    {
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

        public string issuer_orgcode { get; set; }

        public string issuer_orgname { get; set; }

        public string erhc_enddate { get; set; }

        public string user_sign { get; set; }
    }

    public class ErhcPrv12001Result
    {
        public ErhcPrvResultInParm<ErhcWseResultParameter, ErhcPrv12001ResultParm> body { get; set; }
    }
    #endregion

    #region 电子健康卡注册信息查询

    public class ErhcPrv12002ResultParm
    {
        public string is_apply { get; set; }

        public string idcard_no { get; set; }

        public string sex { get; set; }

        public string tel { get; set; }

        public string empi { get; set; }

        public string erhc_cardno { get; set; }
    }

    public class ErhcPrv12002Result
    {
        public ErhcPrvResultInParm<ErhcWseResultParameter, ErhcPrv12002ResultParm> body { get; set; }
    }

    #endregion
}