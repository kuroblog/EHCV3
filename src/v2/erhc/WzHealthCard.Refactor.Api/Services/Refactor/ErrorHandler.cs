
namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using Serilog;
    using System;
    using WzHealthCard.Refactor.Api.Models.Refactor;

    public interface IErrorHandler
    {
        void ErrorLog(Exception ex);

        void Execute(Exception ex, ApiResultEx arg, ResultCodes code);

        void Execute<TResult>(Exception ex, ApiResultEx<TResult> arg, ResultCodes code); //where TResult : class, new();
    }

    public class ErrorHandler : IErrorHandler
    {
        private readonly ILogger logger;

        public ErrorHandler(ILogger logger)
        {
            this.logger = logger;
        }

        public void ErrorLog(Exception ex)
        {
            //LogRecorder.Exception(ex);
            logger.Error(ex);
        }

        public void Execute(Exception ex, ApiResultEx arg, ResultCodes code)
        {
            arg.Initialization(code, null, GetMessage(ex));

            ErrorLog(ex);
        }

        public void Execute<TResult>(Exception ex, ApiResultEx<TResult> arg, ResultCodes code) //where TResult : class, new()
        {
            arg.Initialization(code, null, GetMessage(ex));

            ErrorLog(ex);
        }

        private string GetMessage(Exception ex)
        {
            var errorMsg = ex.Message;
            while (ex.InnerException != null)
            {
                errorMsg += Environment.NewLine + ex.InnerException.Message;
                ex = ex.InnerException;
            }

            return errorMsg;
        }
    }
}
