using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WzHealthCard.Refactor.Api.Common;
using WzHealthCard.Refactor.Api.Extensions;
using WzHealthCard.Refactor.Api.Infrastructure.MiddleWare;
using WzHealthCard.Refactor.Api.Models.Refactor;

namespace WzHealthCard.Refactor.Api.Infrastructure.AspFilters
{
    public class AspectActionFilterAttribute : ActionFilterAttribute, IActionFilter
    {
        private Logger logger;
        public AspectActionFilterAttribute()
        {
            logger = LogManager.GetCurrentClassLogger();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = (ControllerActionDescriptor)context.ActionDescriptor;
            var monitor = (IMonitorModelScope)context.HttpContext.RequestServices.GetService(typeof(IMonitorModelScope));
            if (monitor != null)
            {
                var now = DateTime.Now;
                monitor.Monitor.StartTime = $"{now:yyyy-MM-dd HH:mm:ss fff}";
                monitor.Monitor.StartDate = now;
                monitor.Monitor.Parameters = context.ActionArguments.ToJson();
                monitor.Monitor.RouteUrl = context.HttpContext.Request.Path;
            }
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var monitor = (IMonitorModelScope)context.HttpContext.RequestServices.GetService(typeof(IMonitorModelScope));
            if (!context.ModelState.IsValid)
            {
                var values = context.ModelState.Values.Where(i => i.Errors.Count > 0);
                IList<string> list = new List<string>();
                string errorMsg = string.Empty;
                foreach (var v in values)
                {
                    foreach (var err in v.Errors)
                    {
                        list.Add(err.ErrorMessage);
                    }
                }
                if (list.Any())
                {
                    errorMsg = string.Join(",", list);
                }

                using(MemoryStream ms=new MemoryStream())
                {
                    Stream bs = context.HttpContext.Request.Body;
                    StreamReader sr = new StreamReader(bs);
                    try
                    {
                        if (bs.CanSeek)
                        {
                            bs.Seek(0, SeekOrigin.Begin);
                            string paramtersStr = sr.ReadToEnd();
                            JObject jobj = JObject.Parse(paramtersStr);
                            string tradeCode = string.Empty;
                            string requestId = string.Empty;
                            var props = jobj.Properties();
                            var header = props.FirstOrDefault(i => i.Name.Equals("header", StringComparison.OrdinalIgnoreCase));
                            try
                            {
                                if (header != null)
                                {
                                    var tradeCodeObj = header.Value.FirstOrDefault(i => ((JProperty)i).Name.Equals("tradecode", StringComparison.OrdinalIgnoreCase));
                                    if (tradeCodeObj != null)
                                    {
                                        tradeCode = ((JProperty)tradeCodeObj).Value.ToString();
                                    }
                                    var requestIdObj = header.Value.FirstOrDefault(i => ((JProperty)i).Name.Equals("requestid", StringComparison.OrdinalIgnoreCase));
                                    if (requestIdObj != null)
                                    {
                                        requestId = ((JProperty)requestIdObj).Value.ToString();
                                    }
                                    var result = new { data = "", tradeCode, requestId = requestId, extend = "", code = ResultCodes.LocalError, msg = errorMsg };
                                    context.Result = new JsonResult(result);
                                    monitor.Monitor.RequestId = requestId;
                                }
                            }
                            catch
                            {
                                //不处理
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        //返回参数设置
                        var noVaid = new NotOrErrorFoundApis
                        {
                            Rid = "",
                            Oid = $"{DateTime.Now:yyyyMMddHHmmssffff}",
                            Status = new NotOrErrorFoundStatus
                            {
                                Code = "400",
                                Describe = string.Join(",", list),
                                Guide = null,
                                Point = null,
                                Http = "200",
                                Msg = "*验证错误*"
                            },
                            Success = false

                        };
                        context.Result = new JsonResult(noVaid);
                    }
                    finally
                    {
                        sr.Close();
                        sr.Dispose();
                        bs.Close();
                        bs.Dispose();
                        ms.Close();
                        ms.Dispose();
                    }
                }

            }
            AddLogRecord(context);
        }

        private void AddLogRecord(ResultExecutingContext context)
        {
            var monitor = (IMonitorModelScope)context.HttpContext.RequestServices.GetService(typeof(IMonitorModelScope));

            var controller = (ControllerActionDescriptor)context.ActionDescriptor;
            if (controller == null|| monitor==null)
            {
                return;
            }
            monitor.Monitor.ControllerName = controller.ControllerName;
            monitor.Monitor.ActionName = controller.ActionName;
            monitor.Monitor.Url = $"{context.HttpContext.Request.Scheme}://{context.HttpContext.Request.Host}{context.HttpContext.Request.Path}";
            monitor.Monitor.Header = context.HttpContext.Request.Headers.ToJson();
            monitor.Monitor.RequestMethod = context.HttpContext.Request.Method;
            var end = DateTime.Now;
            monitor.Monitor.EndTime = $"{end:yyyy-MM-dd HH:mm:ss fff}";
            monitor.Monitor.EndDate = end;
            if (context.Result is OkObjectResult result)
            {
                monitor.Monitor.Result = result.Value.ToJson();
            }
            else if(context.Result is ObjectResult objResult)
            {
                if(objResult.Value is string objString)
                {
                    monitor.Monitor.Result = objString;
                }
                else
                {
                    monitor.Monitor.Result = objResult.ToJson();
                }
            }
            
        }
    }
}