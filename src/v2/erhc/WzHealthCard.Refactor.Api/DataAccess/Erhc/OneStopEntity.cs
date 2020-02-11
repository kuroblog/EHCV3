using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WzHealthCard.Refactor.Api.DataAccess.Erhc
{
    /// <summary>
    /// 温州一站式登录
    /// </summary>
    [Table("t_wz_one_stop")]
    public class OneStopEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 绑定UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdCardNo { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public OneStopEntity()
        {
            CreateTime = DateTime.Now;
        }
    }
}