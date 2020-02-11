
namespace WzHealthCard.Infrastructure.Api.Extensions
{
    using Newtonsoft.Json;
    using Serilog;
    using System;

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
    }
}
