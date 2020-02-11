using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using WzHealthCard.Refactor.Api.Common;
using WzHealthCard.Refactor.Api.Extensions;
using WzHealthCard.Refactor.Api.Models.Refactor;

namespace WzHealthCard.Refactor.Api.Infrastructure.MiddleWare
{
    public class RequestUrlMiddleWare
    {
        private readonly RequestDelegate _next;
        private ILogger _logger;
        public RequestUrlMiddleWare(RequestDelegate next)
        {
            _next = next;
            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            using (MemoryStream responseBodyStream = new MemoryStream())
            {
                Stream originalResponseBody = context.Response.Body;
                try
                {
                    var monitor = (IMonitorModelScope)context.RequestServices.GetService(typeof(IMonitorModelScope));

                    await _next(context);


                    if (context.Response.StatusCode != (int)HttpStatusCode.OK&& !context.Response.HasStarted)
                    {
                        ApiResultEx<object> result = new ApiResultEx<object>(null);
                        var now = DateTime.Now;
                        monitor.Monitor.StartTime = $"{now:yyyy-MM-dd HH:mm:ss fff}";
                        monitor.Monitor.StartDate = now;
                        monitor.Monitor.Url = $"{context.Request.Scheme}://{GetRemoteIp(context)}{context.Request.Path}";
                        monitor.Monitor.RouteUrl = context.Request.Path;
                        monitor.Monitor.RequestMethod = context.Request.Method;
                        monitor.Monitor.Header = context.Request.Headers.ToJson();
                        string bodyStr = string.Empty;
                        //{"rid":"-Ri35AX","oid":"2251799813685557","status":{"guide":null,"describe":null,"point":"ubuntu-virtual-machine:WzHealthCard:U5Q1","code":404,"http":"200","msg":"*页面不存在*"},"success":false}
                        if (context.Response.StatusCode == (int)HttpStatusCode.NotFound)
                        {
                            context.Response.Clear();
                            bodyStr = new NotOrErrorFoundApis
                            {
                                Rid = "",
                                Oid = $"{DateTime.Now:yyyyMMddHHmmssffff}",
                                Status = new NotOrErrorFoundStatus
                                {
                                    Code = "404",
                                    Describe = null,
                                    Guide = null,
                                    Point = null,
                                    Http = "200",
                                    Msg = "*页面不存在*"
                                },
                                Success = false

                            }.ToJson(true);
                            monitor.Monitor.Result = bodyStr;
                        }
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(bodyStr);
                        responseBodyStream.Write(bytes, 0, bytes.Length);
                        responseBodyStream.Seek(0, SeekOrigin.Begin);
                        await responseBodyStream.CopyToAsync(originalResponseBody);
                        context.Response.ContentLength = bytes.Length;
                        _logger.MonitorWarn(monitor);
                    }
                    else
                    {
                        _logger.Monitor(monitor);
                    }
                }
                catch (Exception ex)
                {
                    if (!context.Response.HasStarted)
                    {
                        var err = new NotOrErrorFoundApis
                        {
                            Rid = "",
                            Oid = $"{DateTime.Now:yyyyMMddHHmmssffff}",
                            Status = new NotOrErrorFoundStatus
                            {
                                Code = "500",
                                Describe = null,
                                Guide = null,
                                Point = null,
                                Http = "200",
                                Msg = "*内部错误*"
                            },
                            Success = false

                        }.ToJson(true);
                        byte[] data = System.Text.Encoding.UTF8.GetBytes(err);
                        responseBodyStream.Write(data, 0, data.Length);
                        responseBodyStream.Seek(0, SeekOrigin.Begin);
                        await responseBodyStream.CopyToAsync(originalResponseBody);
                        context.Response.ContentLength = data.Length;
                    }
                    else
                    {
                        _logger.Error(ex);
                    }
                }
                finally
                {
                    context.Response.Body = originalResponseBody;
                    originalResponseBody.Close();
                    responseBodyStream.Close();
                    originalResponseBody.Dispose();
                    responseBodyStream.Dispose();
                }
            }
        }

        /// <summary>
        /// 获取客户端请求IP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static string GetRemoteIp(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("x-forwarded-for", out var h))
            {
                return h;
            }
            return context.Request.Host.ToString();
        }
    }
    public static class RequestUrlMiddleWareExtension
    {
        public static IApplicationBuilder UseRequestCulture(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestUrlMiddleWare>();
        }
    }

    public class NotOrErrorFoundApis
    {
        public string Rid { get; set; }

        public string Oid { get; set; }
        public object Status { get; set; }

        public bool Success { get; set; }
    }

    public class NotOrErrorFoundStatus
    {
        public string Guide { get; set; }

        public string Describe { get; set; }

        public string Point { get; set; }

        public string Code { get; set; }
        public string Http { get; set; }

        public string Msg { get; set; }
    }

}