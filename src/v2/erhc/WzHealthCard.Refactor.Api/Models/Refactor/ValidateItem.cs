
using Newtonsoft.Json;

namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    public class ValidateItem
    {
        //
        // 摘要:
        //     正确
        [JsonProperty("succeed", NullValueHandling = NullValueHandling.Ignore)]
        public bool succeed { get; set; }
        //
        // 摘要:
        //     1警告
        [JsonProperty("warning", NullValueHandling = NullValueHandling.Ignore)]
        public bool warning { get; set; }
        //
        // 摘要:
        //     字段名称
        [JsonProperty("field", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        //
        // 摘要:
        //     字段标题目
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Caption { get; set; }
        //
        // 摘要:
        //     消息
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
}
