
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;

    public enum ResultCodes
    {
        #region base from ErrorCode
        [Description("拒绝访问")]
        DenyAccess = -13,
        [Description("客户端应重新请求")]
        ReTry = -12,
        [Description("客户端应中止请求")]
        Ignore = -11,
        [Description("系统未就绪")]
        NoReady = -10,
        [Description("网络错误")]
        NetworkError = -5,
        [Description("本地错误")]
        LocalError = -4,
        [Description("远端错误")]
        RemoteError = -3,
        [Description("逻辑错误")]
        LogicalError = -2,
        [Description("发生异常")]
        LocalException = -1,
        [Description("成功")]
        Succeed = 0,
        [Description("方法不存在")]
        NoFind = 404,
        [Description("服务不可用")]
        Unavailable = 503,
        [Description("未知的Token")]
        AuthUnknowToken = 40001,
        [Description("未知的用户")]
        AuthUserUnknow = 40421,
        [Description("未知的设备识别码")]
        AuthDeviceUnknow = 40022,
        [Description("令牌过期")]
        AuthAccessTokenTimeOut = 40036,
        [Description("未知的AccessToken")]
        AuthAccessTokenUnknow = 40081,
        [Description("未知的ServiceKey")]
        AuthServiceKeyUnknow = 40082,
        [Description("未知的RefreshToken")]
        AuthRefreshTokenUnknow = 40083,
        #endregion
        [Description("未定义的 Code")]
        UnknownCode = 1,
        [Description("用户不存在或已删除")]
        UnknownUser = 10001,
        [Description("用户已存在")]
        ExistedUser = 10002,
        [Description("参数不能为空")]
        ArgumentEmpty = 10003,
        [Description("参数错误")]
        ArgumentError = 10004,
        [Description("错误的AppId访问")]
        AccessServiceFailedViaAppId = 20001,
        [Description("未定义")]
        Unknown = 999
    }

    public static class ResponseCodesExtensions
    {
        public static (int key, string descOrName) GetInfo(this ResultCodes code)
        {
            var key = Convert.ToInt32(Enum.Parse(code.GetType(), code.ToString(), true));
            var name = code.ToString();

            var desc = code.GetType().GetMember(name).FirstOrDefault()?.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;

            return (key, desc == null ? name : desc.Description);
        }
    }
}
