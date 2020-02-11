
namespace WzHealthCard.Infrastructure.Api.Extensions
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;
    using Serilog;
    using System;
    using System.Linq;

    public static class HttpContextExtensions
    {
        public static string GetFirstHeaderValue(this HttpContext context, string key = "RequestId")
        {
            try
            {
                StringValues requestId;
                var isGot = context.Request.Headers.TryGetValue(key, out requestId);

                return isGot ? requestId.FirstOrDefault() : "Unknown";
            }
            catch (Exception ex)
            {
                Log.Warning("Get Request Id: {0}", ex.GetErrorMessages());

                return "Error";
            }
        }
    }
}
