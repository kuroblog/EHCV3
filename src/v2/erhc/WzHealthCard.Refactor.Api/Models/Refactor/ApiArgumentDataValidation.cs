
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using System.Collections.Generic;
    using WzHealthCard.Refactor.Api.Extensions;

    public interface IApiArgumentDataValidation
    {
        (bool isSuccessful, List<string> propertyKeys) Validation();
    }

    public abstract class ApiArgumentDataValidation : IApiArgumentDataValidation
    {
        public virtual (bool isSuccessful, List<string> propertyKeys) Validation() => (true, new List<string>());
    }

    public static class GenericExtensions
    {
        public static (bool IsSuccessful, string JsonResult) Verify<TArgument>(this ApiArgument<TArgument> arg, bool isVerifyHeader = true)
            where TArgument : IApiArgumentDataValidation
        {
            var apiResult = new ApiResultEx(arg);

            //if (arg == null || arg.Data == null || arg.Header == null)
            //{
            //    var (key, descOrName) = ResultCodes.ArgumentError.GetInfo();
            //    apiResult.Code = key;
            //    var codeKey = arg == null ? "body" : arg.Header == null ? nameof(arg.Header) : nameof(arg.Data);
            //    apiResult.Msg = $"{descOrName}({codeKey})";
            //    return (false, apiResult.GetJsonString());
            //}

            if (arg == null)
            {
                var (key, descOrName) = ResultCodes.ArgumentError.GetInfo();
                apiResult.Code = key;
                apiResult.Msg = $"{descOrName}(body)";
                return (false, apiResult.GetJsonString());
            }

            if (isVerifyHeader && arg.Header == null)
            {
                var (key, descOrName) = ResultCodes.ArgumentError.GetInfo();
                apiResult.Code = key;
                apiResult.Msg = $"{descOrName}({nameof(arg.Header)})";
                return (false, apiResult.GetJsonString());
            }

            if (isVerifyHeader && arg.Header.Validate(out string errMessage) == false)
            {
                var (key, descOrName) = ResultCodes.ArgumentError.GetInfo();
                apiResult.Code = key;
                apiResult.Msg = $"{descOrName}({errMessage})";
                return (false, apiResult.GetJsonString());
            }

            if (arg.Data == null)
            {
                var (key, descOrName) = ResultCodes.ArgumentError.GetInfo();
                apiResult.Code = key;
                apiResult.Msg = $"{descOrName}({nameof(arg.Data)})";
                return (false, apiResult.GetJsonString());
            }

            var (isSuccessful, propertyKeys) = arg.Data.Validation();
            if (isSuccessful == false)
            {
                var (key, descOrName) = ResultCodes.ArgumentError.GetInfo();
                apiResult.Code = key;
                apiResult.Msg = $"{descOrName}({propertyKeys?.JoinCharset(";")})";

                return (false, apiResult.GetJsonString());
            }

            return (true, string.Empty);
        }
    }
}
