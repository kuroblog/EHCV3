
namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using WzHealthCard.Refactor.Api.Models.Refactor;

    public static class ResponseCodesExtensions
    {
        //public static (int key, string descOrName) GetInfo(this ResultCodes code)
        //{
        //    var key = Convert.ToInt32(Enum.Parse(code.GetType(), code.ToString(), true));
        //    var name = code.ToString();

        //    var desc = code.GetType().GetMember(name).FirstOrDefault()?.GetCustomAttribute(typeof(DescriptionAttribute), false) as DescriptionAttribute;

        //    return (key, desc == null ? name : desc.Description);
        //}

        //public static void Initialization<TData>(this ApiResultEx<TData> res, ResponseCodes code) where TData : class, new()
        //{
        //    res.Initialization(code, null, string.Empty, null);
        //}

        //public static void Initialization<TData>(this ApiResultEx<TData> res, ResponseCodes code, string message) where TData : class, new()
        //{
        //    res.Initialization(code, null, message, null);
        //}

        private static string GetMessage(int? retCode, string retMsg, string descOrName)
        {
            if (retCode == null)
            {
                return string.IsNullOrEmpty(retMsg) ? descOrName : $"{retMsg}[{retCode}]";
            }
            else
            {
                return string.IsNullOrEmpty(retMsg) ? $"{descOrName}[{retCode}]" : $"{retMsg}[{retCode}]";
            }
        }

        private static string GetMessage(string retCode, string retMsg, string descOrName)
        {
            if (string.IsNullOrEmpty(retCode))
            {
                return string.IsNullOrEmpty(retMsg) ? descOrName : $"{retMsg}[{retCode}]";
            }
            else
            {
                return string.IsNullOrEmpty(retMsg) ? $"{descOrName}[{retCode}]" : $"{retMsg}[{retCode}]";
            }
        }

        public static void Initialization<TData>(this ApiResultEx<TData> result, ResultCodes code, string retCode, string retMsg, TData retData) //where TData : class, new()
        {
            var (key, descOrName) = code.GetInfo();

            result.Code = key;
            result.Msg = GetMessage(retCode, retMsg, descOrName);

            if (retData != null)
            {
                result.Data = retData;
            }
        }

        public static void Initialization(this ApiResultEx result, ResultCodes code, int? retCode, string retMsg)
        {
            var (key, descOrName) = code.GetInfo();

            result.Code = key;
            result.Msg = GetMessage(retCode, retMsg, descOrName);
        }

        public static void InitByErrorCode(this ApiResultEx result, string argKey = "", ResultCodes code = ResultCodes.UnknownCode)
        {
            var (key, descOrName) = code.GetInfo();
            result.Code = key;
            result.Msg = string.IsNullOrEmpty(argKey) ? descOrName : $"{descOrName}({argKey})";
        }

        public static void Succeed<TData>(this ApiResultEx<TData> result, int retCode, string retMsg, TData retData) //where TData : class, new()
        {
            result.Initialization(ResultCodes.Succeed, retCode.ToString(), retMsg, retData);
        }

        public static void Succeed<TData>(this ApiResultEx<TData> result, string retCode, string retMsg, TData retData) //where TData : class, new()
        {
            result.Initialization(ResultCodes.Succeed, retCode, retMsg, retData);
        }

        public static void Succeed<TData>(this ApiResultEx<TData> result, string retMsg, TData retData) where TData : class, new()
        {
            result.Initialization(ResultCodes.Succeed, null, retMsg, retData);
        }

        public static void Succeed(this ApiResultEx result, int retCode, string retMsg)
        {
            result.Initialization(ResultCodes.Succeed, retCode, retMsg);
        }

        public static void Failed<TData>(this ApiResultEx<TData> result, int retCode, string retMsg) where TData : class, new()
        {
            result.Initialization(ResultCodes.RemoteError, retCode.ToString(), retMsg, null);
        }

        public static void Failed<TData>(this ApiResultEx<TData> result, string retCode, string retMsg) where TData : class, new()
        {
            result.Initialization(ResultCodes.RemoteError, retCode.ToString(), retMsg, null);
        }

        public static void Failed(this ApiResultEx result, int retCode, string retMsg)
        {
            result.Initialization(ResultCodes.RemoteError, retCode, retMsg);
        }

        public static void ExistedUser<TData>(this ApiResultEx<TData> result, string retMsg) where TData : class, new()
        {
            result.Initialization(ResultCodes.ExistedUser, null, retMsg, null);
        }

        public static void AccessServiceFailedViaAppId<TData>(this ApiResultEx<TData> result, string retMsg) where TData : class, new()
        {
            result.Initialization(ResultCodes.AccessServiceFailedViaAppId, null, retMsg, null);
        }

        public static void AccessServiceFailedViaAppId(this ApiResultEx result, string retMsg)
        {
            result.Initialization(ResultCodes.AccessServiceFailedViaAppId, null, retMsg);
        }

        public static void UnknownUser<TData>(this ApiResultEx<TData> result, string retMsg) where TData : class, new()
        {
            result.Initialization(ResultCodes.UnknownUser, null, retMsg, null);
        }

        public static void UnknownUser(this ApiResultEx result, string retMsg)
        {
            result.Initialization(ResultCodes.UnknownUser, null, retMsg);
        }

        public static void UnknownCode<TData>(this ApiResultEx<TData> result) where TData : class, new()
        {
            result.Initialization(ResultCodes.UnknownCode, null, string.Empty, null);
        }

        public static void UnknownCode(this ApiResultEx result)
        {
            result.Initialization(ResultCodes.UnknownCode, null, string.Empty);
        }
    }
}
