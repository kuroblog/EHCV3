using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WzHealthCard.Refactor.Api.Models.WSocial
{
    public class Do1413Arg
    {
        /// <summary>
        /// 医院编码
        /// </summary>
        [JsonProperty("hosid")]
        public string hosid { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        [JsonProperty("hosname")]
        public string hosname { get; set; }

        /// <summary>
        /// 终端编号
        /// </summary>
        [JsonProperty("termid")]
        public string termid { get; set; }

        /// <summary>
        /// 终端型号
        /// </summary>
        [JsonProperty("terminfo")]
        public string terminfo { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [JsonProperty("phone")]
        public string phone { get; set; }
    }

    public class Do1413Item
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [JsonProperty("name")]
        public string name { get; set; }

        private string _idCardType;

        /// <summary>
        /// 身份证件类型
        /// </summary>
        [JsonProperty("idCardType")]
        public string idCardType
        {
            set => _idCardType = value;
            get
            {
                switch (_idCardType)
                {
                    case "01": return _idCardType;
                    case "02": return _idCardType;
                    case "03": return "04";
                    case "04": return "03";
                    case "05": return "99";
                    case "06": return "99";
                    default: return _idCardType;
                }
            }
        }

        /// <summary>
        /// 证件号码
        /// </summary>
        [JsonProperty("idCardValue")]
        public string idCardValue { get; set; }
    }

    public class Do1413Result
    {
        [JsonProperty("items")]
        public Do1413Item[] items { get; set; }
    }

}