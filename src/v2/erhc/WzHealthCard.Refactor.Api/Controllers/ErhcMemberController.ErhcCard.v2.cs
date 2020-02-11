
namespace WzHealthCard.Refactor.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using WzHealthCard.Refactor.Api.Extensions;
    using WzHealthCard.Refactor.Api.Models.Refactor;
    using WzHealthCard.Refactor.Api.Services.Refactor;
    using WzHealthCard.Refactor.Api.Services.WRefactor;
    using Xuhui.Internetpro.WzHealthCardService;

    [Route("wzhealthcard/api/v2/erhcmember")]
    [ApiController]
    public partial class ErhcMemberV2Controller : BaseApi
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

        private readonly ResultCodeHandler rc;
        private readonly IHealthCardService healthCardService;
        private readonly ISocialCardServiceProxyHandler scsProxy;
        private readonly ITempHealthCardService tempService;

        public ErhcMemberV2Controller(ResultCodeHandler rc, IHealthCardService healthCardService, ISocialCardServiceProxyHandler scsProxy, ITempHealthCardService tempService)
        {
            this.rc = rc;
            this.healthCardService = healthCardService;
            this.scsProxy = scsProxy;
            this.tempService = tempService;
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

                    if (arr[0].Length == 64 && arr.Length > 1 && arr[1] != "9")
                    {
                        //var lg = IocHelper.Create<IHealthCardService>();
                        //return JsonConvert.SerializeObject(lg.ErhcmemberVerifyHospital(arg));

                        var result1 = healthCardService.ErhcmemberVerifyHospital(arg);

                        var result = new ApiResultEx<ErhcmemberVerifyResponseV2>(arg)
                        {
                            Code = result1.Code,
                            Data = result1.Data != null ? new ErhcmemberVerifyResponseV2
                            {
                                Address = result1.Data.Address,
                                Category = result1.Data.Category,
                                CertNo = "",
                                CitizenCardBalance = result1.Data.CitizenCardBalance,
                                CitizenCardStatus = result1.Data.CitizenCardStatus,
                                Citizenship = result1.Data.Citizenship,
                                Empi = result1.Data.Empi,
                                ErhcCardno = result1.Data.ErhcCardno,
                                ErhcEndDateTime = result1.Data.ErhcEndDateTime,
                                ESocialSecurityCardSign = result1.Data.ESocialSecurityCardSign,
                                IdcardNo = result1.Data.IdcardNo,
                                IdcardType = result1.Data.IdcardType,
                                IdcardValue = result1.Data.IdcardValue,
                                IssuerOrgcode = result1.Data.IssuerOrgcode,
                                IssuerOrgname = result1.Data.IssuerOrgname,
                                Name = result1.Data.Name,
                                Nationality = result1.Data.Nationality,
                                Sex = result1.Data.Sex,
                                SocialSecurityCard = result1.Data.SocialSecurityCard,
                                SocialSecurityCardCity = result1.Data.SocialSecurityCardCity,
                                Tel = result1.Data.Tel,
                                UserSign = result1.Data.UserSign,
                                validseconds = 0
                            } : new ErhcmemberVerifyResponseV2 { },
                            Msg = result1.Msg
                        };

                        if (result.Code == 0)
                        {
                            //IocHelper.Create<ISocialCardServiceProxyHandler>().Do1105(result);
                            scsProxy.Do1411V2(arg.Data.QrcodeInfo, result);
                        }

                        return Ok(result);
                    }
                    else if (arr[0].Length == 24)
                    {
                        //var lg = IocHelper.Create<ISocialCardServiceProxyHandler>();
                        //return JsonConvert.SerializeObject(lg.DoK001(arg));
                        return Ok(scsProxy.Do1411V2(arg));
                    }
                    else if (arr.Length >= 2 && arr[1] == "9")
                    {
                        //var newLg = IocHelper.Create<ITempHealthCardService>();
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
    }
}