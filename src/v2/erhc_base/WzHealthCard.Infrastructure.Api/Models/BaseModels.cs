
namespace WzHealthCard.Infrastructure.Api.Models
{
    //public interface IArgModel
    //{
    //    string RequestId { get; }
    //}

    //public class RequestArg : IArgModel
    //{
    //    [Required]
    //    public virtual string reqId { get; set; }
    //}

    //public abstract class BaseRequestModel<TArgs> : /*RequestArg,*/ IArgModel
    //{
    //    [Required]
    //    public virtual string RequestId { get; set; }

    //    public virtual TArgs Args { get; set; }

    //    public virtual string JsonString { get; }
    //}

    //public class RequestArgs : IArgModel
    //{
    //    public string RequestId { get; }

    //    public RequestArgs(string requestId)
    //    {
    //        RequestId = requestId;
    //    }
    //}

    public abstract class BaseErrorResponse<TError>
    {
        public virtual int errCode { get; set; }

        public virtual TError errors { get; set; }
    }

    public class InternalErrorResponse : BaseErrorResponse<string[]>
    {
        public InternalErrorResponse(string[] errors, int errorId = -999)
        {
            this.errors = errors;
            errCode = errorId;
        }
    }
}
