
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ValidateResult
    {
        //
        // 摘要:
        //     节点
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<ValidateItem> Items;

        //
        // 摘要:
        //     消息
        [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Messages;

        //
        // 摘要:
        //     主键
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        //
        // 摘要:
        //     类型: 0没错 1警告 2错误
        [JsonProperty("succeed", NullValueHandling = NullValueHandling.Ignore)]
        public bool succeed { get; }
    }
}
