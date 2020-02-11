
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    /// <summary>
    /// 应用归类类型
    /// </summary>
    /// <remark>
    /// 应用归类类型
    /// </remark>
    public enum ClassifyType
    {
        /// <summary>
        /// 无权限
        /// </summary>
        None = 0x0,
        /// <summary>
        /// 医院
        /// </summary>
        Hospital = 0x1,
        /// <summary>
        /// App应用
        /// </summary>
        App = 0x2,
    }

    public static class EnumHelper
    {
        /// <summary>
        ///     应用归类类型名称转换
        /// </summary>
        public static string ToCaption(this ClassifyType value)
        {
            switch (value)
            {
                case ClassifyType.None:
                    return "无权限";
                case ClassifyType.Hospital:
                    return "医院";
                case ClassifyType.App:
                    return "App应用";
                default:
                    return "应用归类类型(错误)";
            }
        }
    }
}