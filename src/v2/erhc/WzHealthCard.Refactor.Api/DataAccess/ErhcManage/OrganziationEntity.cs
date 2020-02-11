using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyBackground.Core.Entity
{
    [Table("tb_org_organization")]
    public class OrganziationEntity 
    {
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// 机构类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 机构编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 全称
        /// </summary>
        public string Full_Name { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string Short_Name { get; set; }

        /// <summary>
        /// 树形名称
        /// </summary>
        public string Tree_Name { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public int Org_Level { get; set; }

        /// <summary>
        /// 层级序号
        /// </summary>
        public int Level_Index { get; set; }

        /// <summary>
        /// 上级标识
        /// </summary>
        public long Parent_Id { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 所属机构标识
        /// </summary>
        public long Boundary_Id { get; set; }

        /// <summary>
        /// 所在集团标识
        /// </summary>
        //public long Group_Id { get; set; }

        /// <summary>
        /// 是否冻结
        /// </summary>
        //public bool Is_Freeze { get; set; }

        /// <summary>
        /// 数据状态
        /// </summary>
        public int Data_State { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime add_date { get; set; }
        /// <summary>
        /// 所在市级编码
        /// </summary>
        public string City_Code { get; set; }
        /// <summary>
        /// 所在区县编码
        /// </summary>
        public string District_Code { get; set; }
        /// <summary>
        /// 机构详细地址
        /// </summary>
        public string Org_Address { get; set; }
        /// <summary>
        /// 机构负责人
        /// </summary>
        public string Law_Personname { get; set; }
        /// <summary>
        /// 机构负责人电话
        /// </summary>
        public string Law_Persontel { get; set; }
        /// <summary>
        /// 机构联系人
        /// </summary>
        public string Contact_Name { get; set; }

        /// <summary>
        /// 机构联系人电话
        /// </summary>
        public string Contact_Tel { get; set; }

        /// <summary>
        /// 上级机构代码
        /// </summary>
        public string Super_Orgcode { get; set; }

        /// <summary>
        /// 注册管理机构代码
        /// </summary>
        public string Manag_Orgcode { get; set; }

        /// <summary>
        /// 注册管理机构名称
        /// </summary>
        public string Manag_Orgname { get; set; }

        /// <summary>
        /// 行政区域外键
        /// </summary>
        public long Area_Id { get; set; }

        public OrganziationEntity()
        {
            add_date = DateTime.Now;
        }
    }
}