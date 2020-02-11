
using WzHealthCard.Refactor.Api.Common;

namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using WzHealthCard.Refactor.Api.Models.Refactor;

    public class ResultCodeHandler : ErrorCode
    {
        private readonly IMonitorModelScope _monitor;

        public ResultCodeHandler(IMonitorModelScope monitor)
        {
            _monitor = monitor;
        }

        private ApiResultEx<TData> GetInstance<TData>(ApiArgument data, ResultCodes code) //where TData : class, new()
        {
            var res = new ApiResultEx<TData>(data);
            //res.TradeCode = data?.Header?.TradeCode;
            _monitor.Monitor.RequestId = data?.Header?.RequestId;
            var (key, descOrName) = code.GetInfo();
            res.Code = key;
            res.Msg = descOrName;

            return res;
        }

        public ApiResultEx<TData> GetInstanceByUnknownCode<TData>(ApiArgument data) //where TData : class, new()
        {
            _monitor.Monitor.RequestId = data?.Header?.RequestId;
            return GetInstance<TData>(data, ResultCodes.UnknownCode);
        }

        public ApiResultEx<TData> GetInstanceByErrorCode<TData>(ApiArgument data, string argKey = "", ResultCodes code = ResultCodes.UnknownCode) //where TData : class, new()
        {
            var res = new ApiResultEx<TData>(data);
            //res.TradeCode = data?.Header?.TradeCode;

            var (key, descOrName) = code.GetInfo();
            res.Code = key;
            res.Msg = string.IsNullOrEmpty(argKey) ? descOrName : $"{descOrName}({argKey})";

            return res;
        }

        private ApiResultEx GetInstance(ApiArgument data, ResultCodes code)
        {
            _monitor.Monitor.RequestId = data?.Header?.RequestId;
            var res = new ApiResultEx(data);
            //res.TradeCode = data?.Header?.TradeCode;

            var (key, descOrName) = code.GetInfo();
            res.Code = key;
            res.Msg = descOrName;

            return res;
        }

        public ApiResultEx GetInstanceByUnknownCode(ApiArgument data)
        {
            _monitor.Monitor.RequestId = data?.Header?.RequestId;
            return GetInstance(data, ResultCodes.UnknownCode);
        }

        //private ApiResultEx GetInstance(ApiArgument data, ResponseCodes code)
        //{
        //    var res = new ApiResultEx(data);
        //    res.TradeCode = data?.Header?.TradeCode;

        //    var info = code.GetInfo();
        //    res.Code = info.key;
        //    res.Msg = info.descOrName;

        //    return res;
        //}

        //public ApiResultEx<TData> GetInstanceByUnknownCode<TData>(ApiArgument data) where TData : class, new()
        //{
        //    return GetInstance<TData>(data, ResponseCodes.UnknownCode);
        //}
    }
}
