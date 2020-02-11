using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WzHealthCard.Refactor.Api.DataAccess.ErhcManage
{
    /// <summary>
    /// 白名单列表
    /// </summary>
    [Table("tb_whiteAppKeys")]
    public class WhiteAppKeys 
    {
        [StringLength(64)]
        public  string Id { get; set; }

        /// <summary>
        /// 白名单AppKey
        /// </summary>
        [StringLength(20)]
        public string AppKey { get; set; }

        /// <summary>
        /// 是否允许30004接口请求，默认不允许
        /// </summary>
        [Column(TypeName = "bit")]
        public bool Enable30004 { get; set; }

        /// <summary>
        /// 医疗机构AppKey名称
        /// </summary>
        public string AppName { get; set; }

        public DateTime CreateTime { get; set; }

        public WhiteAppKeys()
        {
            CreateTime = DateTime.Now;
        }
    }
}