using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using WzHealthCard.Refactor.Api.Models.Refactor;

namespace WzHealthCard.Refactor.Api.Common
{
    public class ValidateResultEx
    {
        /// <summary>节点</summary>
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<ValidateItem> Items = new List<ValidateItem>();
        /// <summary>消息</summary>
        [JsonProperty("messages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Messages = new List<string>();

        /// <summary>主键</summary>
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>类型: 0没错 1警告 2错误</summary>
        [JsonProperty("succeed", NullValueHandling = NullValueHandling.Ignore)]
        public bool succeed
        {
            get
            {
                if (this.Items.Count != 0)
                    return this.Items.All<ValidateItem>((Func<ValidateItem, bool>)(p => p.succeed));
                return true;
            }
        }


        /// <summary>加入消息</summary>
        /// <param name="message"></param>
        public void Add(string message)
        {
            this.Messages.Add(message);
        }

        /// <summary>加入校验不能为空的消息</summary>
        /// <param name="caption"></param>
        /// <param name="field"></param>
        public void AddNoEmpty(string caption, string field)
        {
            this.Items.Add(new ValidateItem()
            {
                succeed = false,
                Name = field,
                Caption = caption,
                Message = "不能为空"
            });
        }

        /// <summary>加入消息</summary>
        /// <param name="caption"></param>
        /// <param name="field"></param>
        /// <param name="message"></param>
        public void Add(string caption, string field, string message)
        {
            this.Items.Add(new ValidateItem()
            {
                succeed = false,
                Name = field,
                Caption = caption,
                Message = message
            });
        }

        /// <summary>加入警告</summary>
        /// <param name="caption"></param>
        /// <param name="field"></param>
        /// <param name="message"></param>
        public void AddWarning(string caption, string field, string message)
        {
            this.Items.Add(new ValidateItem()
            {
                warning = true,
                Name = field,
                Caption = caption,
                Message = message
            });
        }
    }
}