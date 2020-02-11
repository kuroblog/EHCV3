using System.Threading.Tasks;
using WzHealthCard.Refactor.Api.Models.Refactor;
using Xuhui.Internetpro.WzHealthCardService;

namespace WzHealthCard.Refactor.Api.Services.WRefactor
{
    public interface IOneStopService : IRegisterScopeServices
    {
        Task<ApiResultEx<OneStopResponse>> QueryAsync(ApiArgument<OneStopRequest> arg);

        Task<ApiResultEx<OneStopResponse>> InsertAsync(ApiArgument<CreateOneStopRequest> arg);
    }
}