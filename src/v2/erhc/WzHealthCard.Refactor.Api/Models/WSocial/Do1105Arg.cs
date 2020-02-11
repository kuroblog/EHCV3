using Newtonsoft.Json;

namespace WzHealthCard.Refactor.Api.Models.WSocial
{
    public class Do1105Arg: Do1106Result
    {
        
    }

    public class Do1105Result: Do1106Result
    {
        private string _eSocialSecurityCard_Sign;

        /// <summary>
        /// 电子社保卡是否签发标志（0=未签发；1=已签发,其他非1或0 的情况表明未知，建议按是否等于1来判断）
        /// </summary>
        [JsonProperty("eSocialSecurityCard_Sign")]
        public new string eSocialSecurityCard_Sign
        {
            set => _eSocialSecurityCard_Sign = value;
            get
            {
                switch (_eSocialSecurityCard_Sign)
                {
                    case "2": return "1";
                    case "0": return "1";
                    case "1": return "0";
                    default: return _eSocialSecurityCard_Sign;
                }
            }
        }
    }


}