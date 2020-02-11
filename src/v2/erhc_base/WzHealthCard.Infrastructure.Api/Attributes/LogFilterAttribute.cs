
namespace WzHealthCard.Infrastructure.Api.Attributes
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Serilog;
    using WzHealthCard.Infrastructure.Api.Extensions;

    public class LogFilterAttribute : ActionFilterAttribute
    {
        //private readonly ILogger<LogFilterAttribute> logger;

        //private (PathString url, IDictionary<string, object> args, IActionResult result) reqResult = (string.Empty, null, null);

        //public LogFilterAttribute(
        //    ILogger<LogFilterAttribute> logger)
        //{
        //    this.logger = logger;
        //}

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //using (LogContext.PushProperty("ThreadId", Thread.CurrentThread.ManagedThreadId))
            //{
            //    Log.Information("Dispatching message of type {MessageType}");
            //}

            //reqResult.url = context.HttpContext.Request.Path;
            //reqResult.args = context.ActionArguments;

            //Debug.WriteLine(new
            //{
            //    url = context.HttpContext.Request.Path,
            //    args = context.ActionArguments
            //}.GetJsonString(true));

            Log.Information("Request Args: {0}", new
            {
                requestId = context.HttpContext.GetFirstHeaderValue(),
                args = context.ActionArguments
            }.GetJsonString());
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //reqResult.result = context.Result;

            //Debug.WriteLine(new
            //{
            //    url = context.HttpContext.Request.Path,
            //    result = context.Result
            //}.GetJsonString(true));

            //Debug.WriteLine(reqResult.GetJsonString(true));

            Log.Information("Response Result: {0}", new
            {
                requestId = context.HttpContext.GetFirstHeaderValue(),
                result = context.Result
            }.GetJsonString());
        }
    }
}
