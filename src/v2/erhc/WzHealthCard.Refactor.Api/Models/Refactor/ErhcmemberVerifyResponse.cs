
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;
    using System;

    public class ErhcmemberVerifyResponse
    {
        private string empi;

        /// <summary>
        /// 主索引 ID
        /// </summary>
        /// <remarks>
        /// 个人唯一识别号
        /// </remarks>
        /// <example>
        /// 26B5A1FE56681
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("empi")]
        public string Empi
        {
            set => empi = value;
            get => string.IsNullOrEmpty(empi) ? string.Empty : empi;
        }

        private string erhcCardNo;

        /// <summary>
        /// 电子健康卡 ID
        /// </summary>
        /// <remarks>
        /// 电子健康卡账户的唯一识别号
        /// </remarks>
        /// <example>
        /// 26B5A1FE56681
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("erhc_cardno")]
        public string ErhcCardno
        {
            set => erhcCardNo = value;
            get => string.IsNullOrEmpty(erhcCardNo) ? string.Empty : erhcCardNo;
        }

        private string name;

        /// <summary>
        /// 姓名
        /// </summary>
        /// <example>
        /// 张三
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("name")]
        public string Name
        {
            set => name = value;
            get => string.IsNullOrEmpty(name) ? string.Empty : name;
        }

        private string sex;

        /// <summary>
        /// 性别
        /// </summary>
        /// <remarks>
        /// 参照【性别】
        /// </remarks>
        /// <example>
        /// 1
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("sex")]
        public string Sex
        {
            set => sex = value;
            get => string.IsNullOrEmpty(sex) ? string.Empty : sex;
        }

        private string idCardNo;

        /// <summary>
        /// 身份证号码
        /// </summary>
        /// <example>
        /// 350424200101011100
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("idcard_no")]
        public string IdcardNo
        {
            set => idCardNo = value;
            get => string.IsNullOrEmpty(idCardNo) ? string.Empty : idCardNo;
        }

        private string idCardType;

        /// <summary>
        /// 身份证件类型
        /// </summary>
        /// <remarks>
        /// 参照【身份证件类型】
        /// </remarks>
        /// <example>
        /// 01
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("idcard_type")]
        public string IdcardType
        {
            set => idCardType = value;
            get => string.IsNullOrEmpty(idCardType) ? string.Empty : idCardType;
        }

        private string idCardValue;

        /// <summary>
        /// 证件号码
        /// </summary>
        /// <remarks>
        /// 根据证件类型返回相应的证件号码
        /// </remarks>
        /// <example>
        /// 350424200101011100
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("idcard_value")]
        public string IdcardValue
        {
            set => idCardValue = value;
            get => string.IsNullOrEmpty(idCardValue) ? string.Empty : idCardValue;
        }

        private string citizenShip;

        /// <summary>
        /// 国籍
        /// </summary>
        /// <remarks>
        /// 参照【国籍】
        /// </remarks>
        /// <example>
        /// 156
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("citizenship")]
        public string Citizenship
        {
            set => citizenShip = value;
            get => string.IsNullOrEmpty(citizenShip) ? string.Empty : citizenShip;
        }

        private string nationality;

        /// <summary>
        /// 民族
        /// </summary>
        /// <remarks>
        /// 参照【民族】
        /// </remarks>
        /// <example>
        /// 01
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("nationality")]
        public string Nationality
        {
            set => nationality = value;
            get => string.IsNullOrEmpty(nationality) ? string.Empty : nationality;
        }

        private string tel;

        /// <summary>
        /// 手机号码
        /// </summary>
        /// <example>
        /// 15121001136
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("tel")]
        public string Tel
        {
            set => tel = value;
            get => string.IsNullOrEmpty(tel) ? string.Empty : tel;
        }

        private string address;

        /// <summary>
        /// 联系地址
        /// </summary>
        /// <example>
        /// 北京市朝阳区霄云路50号
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("address")]
        public string Address
        {
            set => address = value;
            get => string.IsNullOrEmpty(address) ? string.Empty : address;
        }

        private string issuerOrgCode;

        /// <summary>
        /// 健康卡签发机构代码
        /// </summary>
        /// <example>
        /// 0001
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("issuer_orgcode")]
        public string IssuerOrgcode
        {
            set => issuerOrgCode = value;
            get => string.IsNullOrEmpty(issuerOrgCode) ? string.Empty : issuerOrgCode;
        }

        private string issuerOrgName;

        /// <summary>
        /// 健康卡签发机构名称
        /// </summary>
        /// <example>
        /// 浙江省温州市卫健委
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("issuer_orgname", DefaultValueHandling = DefaultValueHandling.Include)]
        public string IssuerOrgname
        {
            set => issuerOrgName = value;
            get => string.IsNullOrEmpty(issuerOrgName) ? string.Empty : issuerOrgName;
        }

        /// <summary>
        /// 健康卡失效日期
        /// </summary>
        /// <example>
        /// 2099-12-31
        /// </example>
        [JsonProperty("erhc_endDateTime")]
        public DateTime ErhcEndDateTime { get; set; } = DateTime.Now;

        private string userSign;

        /// <summary>
        /// 居民签约代扣标志
        /// </summary>
        /// <remarks>
        /// （0=未签约；1=已签约）【签约过程由居民通过 App 自主完成操作。】
        /// </remarks>
        /// <example>
        /// 1
        /// </example>
        /// <value>
        /// 可存储200个字符.合理长度应不大于200.
        /// </value>
        //[DataMember , JsonProperty("user_sign")]
        [JsonProperty("user_sign")]
        public string UserSign
        {
            set => userSign = value;
            get => string.IsNullOrEmpty(userSign) ? string.Empty : userSign;
        }

        private string socialSecurityCard;

        /// <summary>
        /// 社会保障卡卡号
        /// </summary>
        [JsonProperty("socialsecuritycard")]
        public string SocialSecurityCard
        {
            set => socialSecurityCard = value;
            get => string.IsNullOrEmpty(socialSecurityCard) ? string.Empty : socialSecurityCard;
        }

        private string citizenCardStatus;

        /// <summary>
        /// 市民卡状态卡状态(0未启用1正常2挂失7作废8预挂失9注销)
        /// </summary>
        [JsonProperty("citizencard_status")]
        public string CitizenCardStatus
        {
            set => citizenCardStatus = value;
            get => string.IsNullOrEmpty(citizenCardStatus) ? string.Empty : citizenCardStatus;
        }

        private string citizenCardBalance;

        /// <summary>
        /// 市民卡账户余额
        /// </summary>
        [JsonProperty("citizencard_balance")]
        public string CitizenCardBalance
        {
            set => citizenCardBalance = value;
            get => string.IsNullOrEmpty(citizenCardBalance) ? string.Empty : citizenCardBalance;
        }

        private string socialSecurityCardCity;

        /// <summary>
        /// 发卡地区行政区划代码
        /// </summary>
        [JsonProperty("socialsecuritycard_city")]
        public string SocialSecurityCardCity
        {
            set => socialSecurityCardCity = value;
            get => string.IsNullOrEmpty(socialSecurityCardCity) ? string.Empty : socialSecurityCardCity;
        }

        private string category;

        /// <summary>
        /// 卫健人员类别
        /// </summary>
        [JsonProperty("category")]
        public string Category
        {
            set => category = value;
            get => string.IsNullOrEmpty(category) ? string.Empty : category;
        }

        //[JsonProperty("qrcodecontent")]
        //public string qrcodecontent { get; set; }

        //[JsonProperty("validseconds")]
        //public int validseconds { get; set; }

        private string eSocialSecurityCardSign;

        [JsonProperty("eSocialSecurityCard_Sign")]
        public string ESocialSecurityCardSign
        {
            set => eSocialSecurityCardSign = value;
            get
            {
                switch (eSocialSecurityCardSign)
                {
                    case "2": return "1";
                    case "0": return "1";
                    case "1": return "0";
                    default: return eSocialSecurityCardSign;
                }
            }
        }
    }

    public class ErhcmemberVerifyResponseV2 : ErhcmemberVerifyResponse
    {
        /// <summary>
        /// 有效时间，单位毫秒
        /// </summary>
        [JsonProperty("validseconds")]
        public long validseconds { get; set; } = 0;

        private string certNo;

        /// <summary>
        /// 市民卡卡号
        /// </summary>
        [JsonProperty("certno")]
        public string CertNo
        {
            set => certNo = value;
            get => string.IsNullOrEmpty(certNo) ? string.Empty : certNo;
        }
    }
}