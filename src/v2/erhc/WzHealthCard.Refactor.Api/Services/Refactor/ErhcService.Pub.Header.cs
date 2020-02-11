
namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using System.Security.Cryptography;
    using System.Text;
    using WzHealthCard.Refactor.Api.Models.Refactor;

    public class ErhcPubHeader
    {
        public string token { get; set; }

        public string organizationId { get; set; }

        public string appId { get; set; }

        public string tradeCode { get; set; }

        public string requestTime { get; set; }

        public string guaranteeCode { get; set; }

        public string sign
        {
            get
            {
                var key = $"{organizationId}{appId}{token}{dataSources}{tradeCode}{requestTime}";

                using (var md5 = MD5.Create())
                {
                    var data = md5.ComputeHash(Encoding.UTF8.GetBytes(key));
                    var md5Value = new StringBuilder();
                    for (var i = 0; i < data.Length; i++)
                    {
                        md5Value.Append(data[i].ToString("X2"));
                    }

                    return md5Value.ToString();
                }
            }
        }

        public string dataSources { get; set; }

        public ErhcPubHeader(ApiArgumentHeader arg)
        {
            token = arg.Token;
            organizationId = arg.OrganizationId;
            appId = arg.AppId;
            tradeCode = arg.TradeCode;
            requestTime = arg.RequestTime.ToString("yyyy-MM-dd HH:mm:ss");
            dataSources = arg.DataSources;
            guaranteeCode = arg.GuaranteeCode;
        }
    }
}