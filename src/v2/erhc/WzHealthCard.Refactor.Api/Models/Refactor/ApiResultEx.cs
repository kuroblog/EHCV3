
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ApiResultEx
    {
        /// <summary>
        /// 交易码
        /// </summary>
        /// <remarks>
        /// 与请求相同
        /// </remarks>
        /// <value>
        /// 不能为空.可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("tradeCode")]
        public string TradeCode { get; set; }

        /// <summary>
        /// 请求唯一标识符
        /// </summary>
        /// <remarks>
        /// 与请求相同
        /// </remarks>
        /// <value>
        /// 不能为空.可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// 透传参数
        /// </summary>
        /// <remarks>
        /// 与请求相同,请求不为空则返回,请求为空则不返回
        /// </remarks>
        /// <value>
        /// 不能为空.可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("extend")]
        public string Extend { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        /// <remarks>
        /// 0表示成功,其它表示失败。参见标准错误码与各接口的特定错误码
        /// </remarks>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 状态消息
        /// </summary>
        /// <remarks>
        /// 否
        /// </remarks>
        /// <value>
        /// 不能为空.可存储200个字符.合理长度应不大于200.
        /// </value>
        [JsonProperty("msg")]
        public string Msg { get; set; }

        public ApiResultEx(ApiArgument argument)
        {
            if (argument?.Header == null)
                return;
            RequestId = argument.Header.RequestId;
            TradeCode = argument.Header.TradeCode;
            Extend = argument.Header.Extend;
        }

        /// <summary>
        /// 出错
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ApiResultEx Error(int code, string msg)
        {
            Code = code;
            Msg = msg;
            return this;
        }
    }

    public class ApiResultEx<TData> : ApiResultEx
    //where TData : class, new()
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="argument"></param>
        public ApiResultEx(ApiArgument argument) : base(argument)
        {
            if (argument?.Header == null)
                return;
            RequestId = argument.Header.RequestId;
            TradeCode = argument.Header.TradeCode;
            Extend = argument.Header.Extend;
        }

        /// <summary>
        /// 扩展参数
        /// </summary>
        [JsonProperty("data")]
        public TData Data { get; set; }

        public new ApiResultEx<TData> Error(int code, string msg)
        {
            Code = code;
            Msg = msg;
            return this;
        }
    }
}
