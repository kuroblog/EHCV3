
namespace WzHealthCard.Refactor.Api.Models.Refactor
{
    using Newtonsoft.Json;

    public class ApiArgument
    {
        [JsonProperty("header")]
        public ApiArgumentHeader Header { get; set; }

        public virtual bool Validate(out string message)
        {
            if (Header == null)
                Header = new ApiArgumentHeader();

            return Header.Validate(out message);

            //var result = Header.Validate();
            //message = result.succeed ? null : "参数错误";
            //return true;//result.succeed;
        }
    }

    public class ApiArgument<TData> : ApiArgument
    {
        [JsonProperty("data")]
        public TData Data { get; set; }
    }
}
