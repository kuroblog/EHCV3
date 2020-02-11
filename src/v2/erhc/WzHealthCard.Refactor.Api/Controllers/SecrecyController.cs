
namespace WzHealthCard.Refactor.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Reflection;
    using WzHealthCard.Refactor.Api.Attributes;
    using WzHealthCard.Refactor.Api.Common;
    using WzHealthCard.Refactor.Api.Infrastructure.AspFilters;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WzHealthCard.Refactor.Api.Models.Refactor;
    using WzHealthCard.Refactor.Api.Models.WSocial;
    using WzHealthCard.Refactor.Api.Services.Refactor;

    [Route("wzhealthcard/api/v1/[controller]")]
    [ApiController]
    public class SecrecyController : BaseApi
    {
        private readonly ISocialCardServiceProxyHandler _socialCardServiceProxy;
        private ResultCodeHandler rc;
        private readonly IHealthCardService _healthCardService;
        private readonly IMonitorModelScope _monitorScope;

        public SecrecyController(ISocialCardServiceProxyHandler socialCardServiceProxy, 
            ResultCodeHandler rc, 
            IHealthCardService healthCardService, IMonitorModelScope monitorScope)
        {
            _socialCardServiceProxy = socialCardServiceProxy;
            this.rc = rc;
            _healthCardService = healthCardService;
            _monitorScope = monitorScope;
        }

        [HttpGet]
        public async Task<ActionResult> Hello(string user = "")
        {
            return await Task.FromResult(Ok($"hello, {user}."));
        }

        /// <summary>
        /// S0001 获取证件列表信息
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [Route("socialsecurityuserinfo"),HttpPost,HttpGet]
        public async Task<ActionResult> DoS0001Async(ApiArgument<Do1413Arg> arg)
        {
            return await ExecuteAsync(async () =>
            {
                var result = rc.GetInstanceByUnknownCode<Do1413Result>(arg);
                var ar = await _socialCardServiceProxy.Do1413Async(arg.Data.hosid, arg.Data.hosname, arg.Data.termid, arg.Data.terminfo, arg.Data.phone);
                if (ar.Success)
                {

                    if (ar.Data.retcode == "00")
                    {
                        result.Succeed(
                            ar.Data.retcode,
                            ar.Data.retmsg,
                            new Do1413Result
                            {
                                items = ar.Data.certinfos?.Select(p => new Do1413Item
                                {
                                    name = p.name,
                                    idCardValue = p.certno,
                                    idCardType = p.certtype
                                })?.ToArray()
                            });
                    }
                    else
                    {
                        result.Failed(ar.Data.retcode, ar.Data.retmsg);
                    }
                }
                else
                {
                    result.Failed(ar.StatusCode, ar.Msg);
                }
                return Ok(result);
            });
        }

        /// <summary>
        /// S0002 刷脸获取电子健康卡（电子医保卡）动态二维码
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [Route("applybyface"),HttpGet,HttpPost]
        public async Task<ActionResult> DoS0002Async(ApiArgument<Do1106Arg> arg)
        {
            return await ExecuteAsync(async () =>
            {
                var result = rc.GetInstanceByUnknownCode<Do1106Result>(arg);
                var ar = await _socialCardServiceProxy.Do1106Async(arg.Data.hosid, arg.Data.hosname, arg.Data.termid, arg.Data.terminfo, arg.Data.ftokenurl);
                if (ar.Success)
                {
                    if (ar.Data.retcode == "00")
                    {
                        result.Succeed(
                            ar.Data.retcode,
                            ar.Data.retmsg,
                            new Do1106Result
                            {
                                eSocialSecurityCard_Sign = ar.Data.cardsign,
                                qrCode = ar.Data.qrcode,
                                validseconds = long.TryParse(ar.Data.validseconds, out long vseconds) ? vseconds : 0
                            });
                    }
                    else
                    {
                        result.Failed(ar.Data.retcode, ar.Data.retmsg);
                    }
                }
                else
                {
                    result.Failed(ar.StatusCode, ar.Msg);
                }
                return Ok(result);
            });
        }

        /// <summary>
        /// S0003 通过身份证获取电子健康卡
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [Route("applybyid"),HttpPost,HttpGet]
        public async Task<ActionResult> DoS0003Async(ApiArgument<ErhcmemberApplyQueryArgument> arg)
        {
            return await ExecuteAsync(async () =>
            {
                var result = rc.GetInstanceByUnknownCode<Do1105Result>(arg);

                arg.Header.TradeCode = "30005";
                var eaResult = _healthCardService.ErhcmemberApplyQuery(arg);
                if (eaResult.Code != 0||
                    eaResult.Msg.IndexOf("电子健康卡不存在![0]", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    result.Error(ErrorCode.LogicalError, "电子健康卡不存在，请在手机支付宝小程序中申请电子健康卡");
                    //eaResult.TradeCode = "S0003";
                    //eaResult.Msg = "电子健康卡不存在，请在手机支付宝小程序中申请电子健康卡";
                    return Ok(result);
                }

                var ar = await _socialCardServiceProxy.Do1105Async(eaResult.Data.ErhcCardNo, eaResult.Data.Empi, arg.Data.IdCardType, arg.Data.IdCardValue);
                
                

                if (ar.Success)
                {
                    //判断是否开卡失败，重新注册市民卡
                    if (ar.Data.retcode == "20")
                    {
                        await _socialCardServiceProxy.Do1005Async(("", eaResult.Data.Sex, "", ""), result, (eaResult.Data.ErhcCardNo, arg.Data.IdCardType, arg.Data.IdCardValue, arg.Data.Name, "", eaResult.Data.Empi, "", "", ""));
                        ar = await _socialCardServiceProxy.Do1105Async(eaResult.Data.ErhcCardNo, eaResult.Data.Empi, arg.Data.IdCardType, arg.Data.IdCardValue);
                    }
                    if (ar.Data.retcode == "00")
                    {
                        result.Succeed(
                            ar.Data.retcode,
                            ar.Data.retmsg,
                            new Do1105Result
                            {
                                eSocialSecurityCard_Sign = ar.Data.cardsign,
                                qrCode = ar.Data.qrcode,
                                validseconds = long.TryParse(ar.Data.validseconds, out long vseconds) ? vseconds : 0
                            });
                    }
                    else
                    {
                        result.Failed(ar.Data.retcode, ar.Data.retmsg);
                    }
                }
                else
                {
                    result.Failed(ar.StatusCode, ar.Msg);
                }
                result.TradeCode = "S0003";
                return Ok(result);
            });
        }
    }
}