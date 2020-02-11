
namespace WzHealthCard.Infrastructure.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;
    using Serilog;
    using System;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using WzHealthCard.Infrastructure.Api.Extensions;
    using WzHealthCard.Infrastructure.Api.Models;

    public abstract class BaseApi : ControllerBase
    {
        protected virtual ActionResult Execute(Func<ActionResult> method)
        {
            try
            {
                // if (ModelState.ValidationState == ModelValidationState.Invalid)
                // {
                //     return BadRequest(new BadRequestResponse(ModelState));
                // }

                return method.Invoke();
            }
            catch (Exception ex)
            {
                return ErrorHandler(ex);
            }
        }

        protected virtual async Task<ActionResult> ExecuteAsync(Func<Task<ActionResult>> method)
        {
            try
            {
                // if (ModelState.ValidationState == ModelValidationState.Invalid)
                // {
                //     return BadRequest(new BadRequestResponse(ModelState));
                // }

                return await method();
            }
            catch (Exception ex)
            {
                return ErrorHandler(ex);
            }
        }

        private ActionResult ErrorHandler(Exception error, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            Log.Error(error, "Request Id: {0}", HttpContext.GetFirstHeaderValue());

            return StatusCode((int)statusCode, new InternalErrorResponse(error.GetErrorMessages()));
        }

        //protected virtual string RequestId
        //{
        //    get
        //    {
        //        try
        //        {
        //            StringValues requestId;
        //            var isGot = HttpContext.Request.Headers.TryGetValue(nameof(requestId), out requestId);

        //            return isGot ? requestId.FirstOrDefault() : "Unknown";
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.Warning("Get Request Id: {0}", ex.GetErrorMessages());

        //            return "Error";
        //        }
        //    }
        //}
    }
}
