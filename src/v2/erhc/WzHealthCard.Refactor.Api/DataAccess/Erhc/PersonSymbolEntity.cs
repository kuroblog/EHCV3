using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WzHealthCard.Refactor.Api.DataAccess.Erhc
{
    [Table("tb_PersonSymbol")]
    public class PersonSymbolEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// 人员标记类型
        /// </summary>
        [StringLength(2)]
        public string SymbolType { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [StringLength(2)]
        public string CardType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [StringLength(255)]
        public string CardNo { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [StringLength(255)]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 是否存在
        /// </summary>
        [Column(TypeName ="bit")]
        public bool IsDelete { get; set; } 

        /// <summary>
        /// 创建人员
        /// </summary>
        [StringLength(255)]
        public string CreateUserName { get; set; }

        /// <summary>
        /// 删除操作人员
        /// </summary>
        [StringLength(255)]
        public string DeleteUserName { get; set; }

        /// <summary>
        /// 更新人员
        /// </summary>
        [StringLength(255)]
        public string UpdateUserName { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 删除日期
        /// </summary>
        public DateTime? DeleteTime { get; set; }
    }

    public static class SymbolType
    {
        public static readonly string 献血志愿者 = "01";

        public static readonly string 器官捐献者 = "02";
    }
}