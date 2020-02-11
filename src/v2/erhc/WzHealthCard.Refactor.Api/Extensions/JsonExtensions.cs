
namespace WzHealthCard.Refactor.Api.Extensions
{
    using Newtonsoft.Json;
    using Serilog;
    using System;
    using System.Collections.Generic;

    public static class JsonExtensions
    {
        public static string GetJsonString<TArg>(this TArg arg, bool isFormat = false)
        {
            try
            {
                return JsonConvert.SerializeObject(arg, isFormat ? Formatting.Indented : Formatting.None);
            }
            catch (Exception error)
            {
                Log.Error(error, "TArg Type: {0}", typeof(TArg));

                return string.Empty;
            }
        }

        public static TObj ToJsonObject<TObj>(this string jsonContext)
        {
            try
            {
                return JsonConvert.DeserializeObject<TObj>(jsonContext);
            }
            catch (Exception error)
            {
                Log.Error(error, "TArg Type: {0}", typeof(TObj));

                return default(TObj);
            }
        }

        public static string JoinCharset(this IEnumerable<string> strings, string charset)
        {
            return strings == null ? string.Empty : string.Join(charset, strings);
        }
    }
}
