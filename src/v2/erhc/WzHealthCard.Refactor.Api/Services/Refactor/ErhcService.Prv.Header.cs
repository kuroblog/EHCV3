
using WzHealthCard.Refactor.Api.Models.Refactor;

namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    public class ErhcPrvHeaderInParm<THeader> where THeader : class
    {
        public THeader header { get; set; }
    }

    public class ErhcPrvHeaderParameter
    {
        // [Required, StringLength(64)]
        public string organization_id { get; set; }

        // [Required, StringLength(32)]
        public string token { get; set; }

        // [Required, StringLength(5)]
        public string tradecode { get; set; }

        // [Required, StringLength(19, MinimumLength = 19)]
        public string request_time { get; set; }

        // [Required, StringLength(10)]
        public string operator_code { get; set; }

        // [Required, StringLength(20)]
        public string operator_name { get; set; }

        // [Required, StringLength(20)]
        public string client_ip { get; set; }

        // [Required, StringLength(20)]
        public string client_macaddress { get; set; }

        public string guarantee_code { get; set; }
    }

    public class ErhcPrvHeader : ErhcPrvHeaderInParm<ErhcPrvHeaderParameter>
    {
        public ErhcPrvHeader(ApiArgumentHeader arg)
        {
            header = new ErhcPrvHeaderParameter
            {
                organization_id = arg.OrganizationId,
                token = arg.Token,
                request_time = arg.RequestTime.ToString("yyyy-MM-dd HH:mm:ss"),
                operator_code = arg.OperatorCode,
                operator_name = arg.OperatorName,
                client_ip = arg.ClientIp,
                client_macaddress = arg.ClientMacAddress,
                tradecode = arg.TradeCode,
                guarantee_code = arg.GuaranteeCode
            };
        }

        //private Func<string, string> tradeCodeHandler = code =>
        //{
        //    switch (code)
        //    {
        //        case "10001": return "10001";
        //        case "30001": return "11001";
        //        case "30002": return "11002";
        //        case "30003": return "11003";
        //        case "11004": return "11004";
        //        case "12001": return "12001";
        //        case "30005": return "12002";
        //        default: return string.Empty;
        //    }
        //};
    }
}