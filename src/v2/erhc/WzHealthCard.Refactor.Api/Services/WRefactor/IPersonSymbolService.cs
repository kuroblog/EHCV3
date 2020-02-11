using System.Threading.Tasks;
using WzHealthCard.Refactor.Api.Models.Refactor;
using Xuhui.Internetpro.WzHealthCardService;

namespace WzHealthCard.Refactor.Api.Services.WRefactor
{
    public interface IPersonSymbolService: IRegisterScopeServices
    {
        Task<ApiResultEx<PersonSymbolResponse>> PersonSymbolQueryAsync(ApiArgument<PersonSymbolRequest> request);
    }
}