using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WzHealthCard.Refactor.Api.DataAccess.Erhc
{
    /// <summary>
    /// 临时电子健康卡
    /// </summary>
    [Table("tb_tempecard")]
    public class TempeCardEntity
    {
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 主索引
        /// </summary>
        public string Empi { get; set; }

        /// <summary>
        /// 电子健康卡 ID，电子健康卡账户的唯一识别号
        /// </summary>
        [Column("erhc_card_no")]
        public string ErhcCardNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [Column("id_card_no")]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [Column("id_card_type")]
        public string IdCardType { get; set; }

        /// <summary>
        /// 证件值
        /// </summary>
        [Column("id_card_value")]
        public string IdCardValue { get; set; }

        /// <summary>
        /// 国籍
        /// </summary>
        public string Citizenship { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 签发机构
        /// </summary>
        [Column("issuer_org_code")]
        public string IssuerOrgCode { get; set; }

        /// <summary>
        /// 签发机构名称
        /// </summary>
        [Column("issuer_org_name")]
        public string IssuerOrgName { get; set; }

        /// <summary>
        /// 健康卡失效日期，格式为：yyyy-mm-dd
        /// </summary>
        [Column("deadline")]
        public string Deadline { get; set; }

        /// <summary>
        /// 二维码类型
        /// </summary>
        [Column("qr_code_type")]
        public string QrCodeType { get; set; }

        /// <summary>
        /// 二维码内容
        /// </summary>

        [Column("qr_code_image_data")]
        public string QrCodeImageData { get; set; }

        /// <summary>
        /// 居民签约代扣标志。（0=未签约；1=已签约）
        /// </summary>

        [Column("user_sign")]
        public string UserSign { get; set; }

        /// <summary>
        /// 电子健康卡是否已申请（0=未申请；1=已申请）
        /// </summary>
        [Column("is_apply")]
        public string IsApply { get; set; }

        /// <summary>
        /// 是否注销
        /// </summary>
        [Column("is_closed")]
        public string IsClosed { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Token值
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 数据来源
        /// </summary>
        [Column("data_sources")]
        public string DataSources { get; set; }

        /// <summary>
        /// 接收地址
        /// </summary>
        [Column("request_id")]
        public string RequestId { get; set; }

        /// <summary>
        /// 申请方式
        /// </summary>
        [Column("app_mode")]
        public string AppMode { get; set; }

        /// <summary>
        /// 终端类型
        /// </summary>
        [Column("terminal_type")]
        public string TerminalType { get; set; }

        /// <summary>
        /// 出生地
        /// </summary>
        [Column("birth_place")]
        public string BirthPlace { get; set; }


        /// <summary>
        /// 户籍所在地
        /// </summary>
        public string Domicile { get; set; }
    }
}