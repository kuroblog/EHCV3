
using System.Linq;
using System.Net.Http;
using WzHealthCard.Refactor.Api.DataAccess;

namespace WzHealthCard.Refactor.Api.Controllers
{
    using WzHealthCard.Refactor.Api.Extensions;
    using WzHealthCard.Refactor.Api.Models.Refactor;
    using WzHealthCard.Refactor.Api.Services.Refactor;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using WzHealthCard.Refactor.Api.Services.WRefactor;
    using Xuhui.Internetpro.WzHealthCardService;
    using ErhcmemberVerifyHospitalArgument = Models.Refactor.ErhcmemberVerifyHospitalArgument;
    using WzHealthCard.Refactor.Api.Common;

    [Route("wzhealthcard/api/v1/[controller]")]
    [ApiController]
    public partial class ErhcMemberController : BaseApi
    {
        [HttpGet]
        public async Task<ActionResult> Hello(string user = "")
        {
            return await Task.FromResult(Ok($"hello, {user}."));
        }

        [HttpGet, Route("test1")]
        public async Task<ActionResult> Test1(string user = "")
        {
            return await Task.FromResult(Ok($"{nameof(Test1)} on SmallApp, {user}."));
        }

        private readonly ConfigManager config;
        private readonly ResultCodeHandler rc;
        private readonly IErrorHandler error;
        private readonly IHealthCardService healthCardService;
        private readonly ISocialCardServiceProxyHandler scsProxy;
        private readonly ITempHealthCardService tempService;
        private readonly IMonitorModelScope monitorScope;
        
        private readonly IHttpClientFactory _httpClientFactory;

        public ErhcMemberController(ConfigManager config, ResultCodeHandler rc, IErrorHandler error,IHealthCardService healthCardService, ISocialCardServiceProxyHandler scsProxy, ITempHealthCardService tempService, IMonitorModelScope monitorScope, IHttpClientFactory httpClientFactory)
        {
            this.config = config;
            this.rc = rc;
            this.error = error;
            this.healthCardService = healthCardService;
            this.scsProxy = scsProxy;
            this.tempService = tempService;
            this.monitorScope = monitorScope;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost, Route("apply")]
        public ActionResult Apply(ApiArgument<ErhcmemberApplyArgument> arg)
        {
            return Execute(() =>
            {
                if (!string.IsNullOrEmpty(arg.Header?.AppId)&&arg.Header.AppId.Equals("20190626202"))
                {
                    arg.Header.GuaranteeCode = "01";
                }
                var result = healthCardService.ErhcmemberApply(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("erhcapplyquery")]
        public ActionResult Query(ApiArgument<ErhcmemberApplyQueryArgument> arg)
        {
            return Execute(() =>
            {
                var result = healthCardService.ErhcmemberApplyQuery(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("erhccancel")]
        public ActionResult Cancel(ApiArgument<ErhcmemberCancelArgument> arg)
        {
            return Execute(() =>
            {
                var result = healthCardService.ErhcmemberCancel(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("modify")]
        public ActionResult Modify(ApiArgument<ErhcmemberModifyArgument> arg)
        {
            return Execute(() =>
            {
                var result = healthCardService.ErhcmemberModify(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("getqrcode/dynamic")]
        public ActionResult DynamicQrCode(ApiArgument<ErhcmemberQrCodeDynamicArgument> arg)
        {
            return Execute(() =>
            {
                (bool state, string json) = arg.Verify();
                if (!state)
                {
                    return Ok(json);
                }
                //1)判断是非小程序AppKey并且是是请求市民卡二维码
                //2)判断数据库中是否已添加白名单,不存在返回无权限
                //3)判断白名单数据是否允许状态，不存在返回无权限
                if (!arg.Header.AppId.Equals(config.GetAppSetting("SmallAppKey"), StringComparison.OrdinalIgnoreCase)
                &&arg.Data.QrCodeType=="1")
                {
                    var noAllowResult = rc.GetInstanceByUnknownCode<ErhcmemberQrCodeDynamicResponse>(arg);
                    noAllowResult.Error(ErrorCode.LocalError, "接口权限不足");
                    var db = (ErhcManageContext)HttpContext.RequestServices.GetService(typeof(ErhcManageContext));
                    if (db == null)
                    {
                        return Ok(noAllowResult);
                    }
                    var allow = db.WhiteAppKeys.FirstOrDefault(i => i.AppKey.Equals(arg.Header.AppId));
                    if (allow == null)
                    {
                        return Ok(noAllowResult);
                    }
                    if (!allow.Enable30004)
                    {
                        return Ok(noAllowResult);
                    }
                }
                rc.GetInstanceByUnknownCode<ErhcmemberQrCodeDynamicResponse>(arg);

                var result = healthCardService.ErhcmemberQrCodeDynamic(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("getqrcode/static")]
        public ActionResult StaticQrCode(ApiArgument<ErhcmemberQrCodeStaticArgument> arg)
        {
            return Execute(() =>
            {
                var result = healthCardService.ErhcmemberQrCodeStatic(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("verify/hospital")]
        public ActionResult VerifyHospital(ApiArgument<ErhcmemberVerifyHospitalArgument> arg)
        {
            return Execute(() =>
            {
                (bool state, string json) = arg.Verify();
                if (!state)
                {
                    return Ok(json);
                }

                string[] arr = new string[] { };

                if (!string.IsNullOrEmpty(arg.Data.QrcodeInfo))
                {
                    arr = arg.Data.QrcodeInfo.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    if (arr[0].Length == 64&&arr.Length>1 && arr[1] != "9")
                    {
                        var result = healthCardService.ErhcmemberVerifyHospital(arg);

                        if (result.Code == 0)
                        {
                            //IocHelper.Create<ISocialCardServiceProxyHandler>().Do1105(result);
                            scsProxy.Do1411(arg.Data.QrcodeInfo, result);
                        }

                        return Ok(result);
                    }
                    else if (arr[0].Length == 24)
                    {
                        //var lg = IocHelper.Create<ISocialCardServiceProxyHandler>();
                        //return JsonConvert.SerializeObject(lg.DoK001(arg));
                        return Ok(scsProxy.Do1411(arg));
                    }
                    else if (arr.Length >= 2 && arr[1] == "9")
                    {
                        var newArg = TempeCardVerifyArgument.Converter(arg);
                        return Ok(tempService.TempeCardVerify(newArg).Result);
                    }
                    else
                    {
                        var result = rc.GetInstanceByUnknownCode<TempeCardVerifyReponse>(arg);
                        return Ok(result.Error(ErrorCode.LogicalError, "二维码内容错误"));
                    }
                }

                return Ok(rc.GetInstanceByUnknownCode<TempeCardVerifyReponse>(arg));
            });
        }

        [HttpPost, Route("hosttime")]
        public ActionResult ServerTime(ApiArgument arg)
        {
            return Execute(() =>
            {
                var result = healthCardService.HostTime(arg);
                return Ok(result);
            });
        }
    }
}