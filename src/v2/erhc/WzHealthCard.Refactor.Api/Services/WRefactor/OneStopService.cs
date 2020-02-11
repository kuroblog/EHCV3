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
    public class OneStopService:IOneStopService
    {
        private readonly OneStopRepository _repository;
        private readonly ErhcUnitOfWork _unitOfWork;
        private readonly ResultCodeHandler _rc;
        private readonly ConfigManager _config;

        public OneStopService(OneStopRepository repository, ErhcUnitOfWork unitOfWork, ResultCodeHandler rc, ConfigManager config)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _rc = rc;
            _config = config;
        }

        /// <summary>
        /// 查询一站式UserId
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public async Task<ApiResultEx<OneStopResponse>> QueryAsync(ApiArgument<OneStopRequest> arg)
        {
            var result = _rc.GetInstanceByUnknownCode<OneStopResponse>(arg);
            //验证是否是小程序访问
            if (!arg.Header.AppId.Equals(_config.GetAppSetting("SmallAppKey")))
            {
                result.Error(ErrorCode.LocalError, "接口未授权");
                return result;
            }
            result.Data = new OneStopResponse();
            var entity=await _repository.View.FirstOrDefaultAsync(i => i.Name == arg.Data.Name 
                                                 && i.IdCardNo.Equals(arg.Data.IdCardNo, StringComparison.OrdinalIgnoreCase));
            if (entity != null)
            {
                result.Data.UserId = entity.UserId;
            }
            result.Code = 0;
            result.Msg = "成功[00]";
            
            return result;
        }
        /// <summary>
        /// 插入UserId
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public async Task<ApiResultEx<OneStopResponse>> InsertAsync(ApiArgument<CreateOneStopRequest> arg)
        {
            var result = _rc.GetInstanceByUnknownCode<OneStopResponse>(arg);
            //验证是否是小程序访问
            if (!arg.Header.AppId.Equals(_config.GetAppSetting("SmallAppKey")))
            {
                result.Error(ErrorCode.LocalError, "接口未授权");
                return result;
            }
            var entity = await _repository.View.FirstOrDefaultAsync(i => i.Name == arg.Data.Name
                                                                         && i.IdCardNo.Equals(arg.Data.IdCardNo, StringComparison.OrdinalIgnoreCase));
            if (entity == null)
            {
                entity = new DataAccess.Erhc.OneStopEntity
                {
                    IdCardNo = arg.Data.IdCardNo,
                    Name = arg.Data.Name,
                    UserId = arg.Data.UserId
                };
                _repository.Insert(entity);
                await _unitOfWork.CommitAsync();
            }
            result.Code = 0;
            result.Msg = "成功[00]";
            return result;
        }

    }
}