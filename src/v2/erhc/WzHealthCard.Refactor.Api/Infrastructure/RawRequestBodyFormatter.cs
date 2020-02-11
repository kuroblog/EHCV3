using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace WzHealthCard.Refactor.Api.Infrastructure
{
    /// <summary>
    /// 实现content-type: text/plain 或者application/octet-stream请求
    /// </summary>
    public class RawRequestBodyFormatter:IInputFormatter
    {
        public bool CanRead(InputFormatterContext context)
        {
            if (context == null) throw new ArgumentNullException("argument is Null");
            var contentType = context.HttpContext.Request.ContentType;
            if (string.IsNullOrEmpty(contentType) || contentType == "text/plain" || contentType == "application/octet-stream")
                return true;
            return false;
        }

        public async Task<InputFormatterResult> ReadAsync(InputFormatterContext context)
        {
            var request = context.HttpContext.Request;
            var contentType = context.HttpContext.Request.ContentType;
            if (string.IsNullOrEmpty(contentType) || contentType.ToLower() == "text/plain")
            {
                using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8))
                {
                    var content = await reader.ReadToEndAsync();
                    return await InputFormatterResult.SuccessAsync(content);
                }
            }
            if (contentType == "application/octet-stream")
            {
                using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8))
                {
                    using (var ms = new MemoryStream())
                    {
                        await request.Body.CopyToAsync(ms);
                        var content = ms.ToArray();

                        return await InputFormatterResult.SuccessAsync(content);
                    }
                }
            }
            return await InputFormatterResult.FailureAsync();
        }
    }
}