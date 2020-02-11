
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WzHealthCard.Refactor.Api.Extensions;

    public class ApiArgumentHeader
    {
        /// <summary>
        /// 是
        /// </summary>
        /// <remarks>
        /// 发起交易的机构代码,按AppId申请时数据填写
        /// </remarks>
        /// <value>
        /// 不能为空.可存储64个字符.合理长度应不大于64.
        /// </value>
        [JsonProperty("organizationId")]
        public string OrganizationId { get; set; }

        /// <summary>
        /// 是
        /// </summary>
        /// <remarks>
        /// 接入App应用的编码,按AppId申请时数据填写
        /// </remarks>
        /// <value>
        /// 不能为空.可存储16个字符.合理长度应不大于16.
        /// </value>
        [JsonProperty("appId")]
        public string AppId { get; set; }

        /// <summary>
        /// 否
        /// </summary>
        /// <remarks>
        /// 数据来源,按AppId申请时数据填写
        /// </remarks>
        /// <value>
        /// 不能为空.可存储2个字符.合理长度应不大于2.
        /// </value>
        [JsonProperty("dataSources")]
        public string DataSources { get; set; }

        /// <summary>
        /// 是
        /// </summary>
        /// <remarks>
        /// 交易码,由各业务接口指定。
        /// </remarks>
        /// <value>
        /// 不能为空.可存储5个字符.合理长度应不大于5.
        /// </value>
        [JsonProperty("tradeCode")]
        public string TradeCode { get; set; }

        /// <summary>
        /// 是
        /// </summary>
        /// <remarks>
        /// 动态访问令牌,非特殊说明的接口,使用通过动态令牌接口取得的accessToken,否则按接口说明处理。
        /// </remarks>
        /// <value>
        /// 不能为空.可存储32个字符.合理长度应不大于32.
        /// </value>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// 是
        /// </summary>
        /// <remarks>
        /// 本机构内唯一的请求标识字符串,每次请求不相同,正式环境重复请求将会被限流处理,建议使用自动生成的GUID/UUID。
        /// </remarks>
        /// <value>
        /// 不能为空.可存储32个字符.合理长度应不大于32.
        /// </value>
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// 是
        /// </summary>
        /// <remarks>
        /// 请求时间
        /// </remarks>
        [JsonProperty("requestTime")]
        public DateTime RequestTime { get; set; }

        /// <summary>
        /// 否
        /// </summary>
        /// <remarks>
        /// 操作员工号(医院必填)
        /// </remarks>
        /// <value>
        /// 可存储20个字符.合理长度应不大于20.
        /// </value>
        [JsonProperty("operatorCode")]
        public string OperatorCode { get; set; }

        /// <summary>
        /// 否
        /// </summary>
        /// <remarks>
        /// 操作员姓名(医院必填)
        /// </remarks>
        /// <value>
        /// 可存储50个字符.合理长度应不大于50.
        /// </value>
        [JsonProperty("operatorName")]
        public string OperatorName { get; set; }

        /// <summary>
        /// 否
        /// </summary>
        /// <remarks>
        /// 请求终端的IPv4地址(医院必填),如:192.168.10.2
        /// </remarks>
        /// <value>
        /// 可存储15个字符.合理长度应不大于15.
        /// </value>
        [JsonProperty("clientIp")]
        public string ClientIp { get; set; }

        /// <summary>
        /// 否
        /// </summary>
        /// <remarks>
        /// 请求终端的MAC地址(大写) (医院必填)如：01-FE-23-49-28-D0
        /// </remarks>
        /// <value>
        /// 可存储17个字符.合理长度应不大于17.
        /// </value>
        [JsonProperty("clientMacAddress")]
        public string ClientMacAddress { get; set; }

        /// <summary>
        /// 否
        /// </summary>
        /// <remarks>
        /// 请求参数签名
        /// </remarks>
        /// <value>
        /// 不能为空.可存储344个字符.合理长度应不大于344.
        /// </value>
        [JsonProperty("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 否
        /// </summary>
        /// <remarks>
        /// 请求方自定义的透传参数（原样返回）,小于100字符,如有大于100字符,请内部做一个键值查询,内容内部保存,查询的Key作为透传参数。
        /// </remarks>
        /// <value>
        /// 可存储100个字符.合理长度应不大于100.
        /// </value>
        [JsonProperty("extend")]
        public string Extend { get; set; }

        /// <summary>
        /// 01 实名保证。非01就是不需要做实名保证
        /// </summary>
        [JsonProperty("guaranteeCode")]
        public string GuaranteeCode { get; set; }

        public string originAppId { get; set; }

        public string originalOrgName { get; set; }

        /// <summary>数据校验</summary>
        /// <param name="message">返回的消息</param>
        /// <returns>成功则返回真</returns>
        public bool Validate(out string message)
        {
            var result = Validate();
            //message = result.succeed ? null : result.Items?.Where(p => !p.succeed).Select(p => $"{p.Caption}:{ p.Message}").JoinCharset(";");
            message = result.succeed ? null : result.Items?.Where(p => !p.succeed).Select(p => p.Caption).JoinCharset(";");
            return string.IsNullOrEmpty(message);
        }

        //public virtual ValidateResult Validate() => new ValidateResult();
        public virtual ValidateResult Validate()
        {
            var result = new ValidateResult { Items = new List<ValidateItem>() };

            if (string.IsNullOrEmpty(OrganizationId))
            {
                result.Items.Add(new ValidateItem { Caption = nameof(OrganizationId), Message = "不能为空" });
            }

            if (string.IsNullOrEmpty(AppId))
            {
                result.Items.Add(new ValidateItem { Caption = nameof(AppId), Message = "不能为空" });
            }

            return result;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
