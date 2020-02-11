
using WzHealthCard.Refactor.Api.Infrastructure.AspFilters;

namespace WzHealthCard.Refactor.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Serilog;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using WzHealthCard.Refactor.Api.Extensions;
    using WzHealthCard.Refactor.Api.Models;

    [AspectActionFilter]
    public abstract class BaseApi : ControllerBase
    {
        protected virtual ActionResult Execute(Func<ActionResult> method)
        {
            try { return method.Invoke(); }
            catch (Exception ex) { return ErrorHandler(ex); }
        }

        protected virtual async Task<ActionResult> ExecuteAsync(Func<Task<ActionResult>> method)
        {
            try { return await method(); }
            catch (Exception ex) { return ErrorHandler(ex); }
        }

        private ActionResult ErrorHandler(Exception error, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            Log.Error(error, "Request Id: {0}", HttpContext.GetFirstHeaderValue());

            return StatusCode((int)statusCode, new InternalErrorResponse(error.GetFullMessages()));
        }
    }
}
