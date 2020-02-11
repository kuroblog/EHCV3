using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Xuhui.Internetpro.WzHealthCardService
{
    /// <summary>
    /// 查询人员标识信息
    /// </summary>
    public class PersonSymbolRequest
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage ="{0}必须填写")]
        [DisplayName("姓名")]
        [StringLength(255, ErrorMessage = "{0}长度超出范围")]
        public string Name { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [Required(ErrorMessage = "{0}必须填写")]
        [DisplayName("身份证号码")]
        [StringLength(255,ErrorMessage ="{0}长度超出范围")]
        public string IdCardNo { get; set; }

    }
}