
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    public class ErrorCode
    {        //
        // 摘要:
        //     正确
        public const int Success = 0;

        //
        // 摘要:
        //     令牌过期
        public const int Auth_AccessToken_TimeOut = 40036;

        //
        // 摘要:
        //     未知的设备识别码
        public const int Auth_Device_Unknow = 40022;

        //
        // 摘要:
        //     未知的用户
        public const int Auth_User_Unknow = 40421;

        //
        // 摘要:
        //     未知的AccessToken
        public const int Auth_AccessToken_Unknow = 40081;

        //
        // 摘要:
        //     未知的ServiceKey
        public const int Auth_ServiceKey_Unknow = 40082;

        //
        // 摘要:
        //     未知的RefreshToken
        public const int Auth_RefreshToken_Unknow = 40083;

        //
        // 摘要:
        //     未知的Token
        public const int Auth_UnknowToken = 40001;

        //
        // 摘要:
        //     服务不可用
        public const int Unavailable = 503;

        //
        // 摘要:
        //     方法不存在
        public const int NoFind = 404;

        //
        // 摘要:
        //     客户端应重新请求
        public const int ReTry = -12;

        //
        // 摘要:
        //     客户端应中止请求
        public const int Ignore = -11;

        //
        // 摘要:
        //     系统未就绪
        public const int NoReady = -10;

        //
        // 摘要:
        //     网络错误
        public const int NetworkError = -5;

        //
        // 摘要:
        //     本地错误
        public const int LocalError = -4;

        //
        // 摘要:
        //     远端错误
        public const int RemoteError = -3;

        //
        // 摘要:
        //     逻辑错误
        public const int LogicalError = -2;

        //
        // 摘要:
        //     发生异常
        public const int LocalException = -1;

        //
        // 摘要:
        //     拒绝访问
        public const int DenyAccess = -13;
    }
}
