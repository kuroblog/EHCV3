
namespace WzHealthCard.Refactor.Api.Models
{
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
