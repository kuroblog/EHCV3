using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WzHealthCard.Refactor.Api.Models.Refactor;
using WzHealthCard.Refactor.Api.Repositories.Erhc;
using WzHealthCard.Refactor.Api.Services.Refactor;
using WzHealthCard.Refactor.Api.UnitOfWorks;
using Xuhui.Internetpro.WzHealthCardService;

namespace WzHealthCard.Refactor.Api.Services.WRefactor
{
    public class PersonSymbolService:IPersonSymbolService
    {
        private readonly PersonSymbolRepository _repository;
        private readonly ErhcUnitOfWork _unitOfWork;
        private readonly ResultCodeHandler _rc;
        private readonly ConfigManager _config;

        public PersonSymbolService(PersonSymbolRepository repository, ErhcUnitOfWork unitOfWork, ResultCodeHandler rc, ConfigManager config)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _rc = rc;
            _config = config;
        }

        /// <summary>
        /// 查询人员标识信息列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResultEx<PersonSymbolResponse>> PersonSymbolQueryAsync(ApiArgument<PersonSymbolRequest> arg)
        {
            var result = _rc.GetInstanceByUnknownCode<PersonSymbolResponse>(arg);
            //验证是否是小程序访问
            if (!arg.Header.AppId.Equals(_config.GetAppSetting("SmallAppKey")))
            {
                result.Error(ErrorCode.LocalError, "接口未授权");
                return result;
            }
            result.Data = new PersonSymbolResponse(){PersonSymbolTypes=new string[]{} };
            var symbol=await _repository.View.Where(i => i.IdCardNo.Equals(arg.Data.IdCardNo, StringComparison.OrdinalIgnoreCase)
                                    && i.Name.Equals(arg.Data.Name, StringComparison.OrdinalIgnoreCase)
                                    &&!i.IsDelete).Distinct().ToListAsync();
            result.Succeed((int)ErrorCode.Success, "成功[00]");
            if (symbol.Any())
            {
                result.Data.PersonSymbolTypes = symbol.DefaultIfEmpty().Select(i => i.SymbolType).ToArray();
            }
            return result;
        }
    }
}