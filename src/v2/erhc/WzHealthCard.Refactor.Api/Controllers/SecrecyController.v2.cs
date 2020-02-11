
using WzHealthCard.Refactor.Api.Common;

namespace WzHealthCard.Refactor.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using WzHealthCard.Refactor.Api.Extensions;
    using WzHealthCard.Refactor.Api.Models.Refactor;
    using WzHealthCard.Refactor.Api.Models.WSocial;
    using WzHealthCard.Refactor.Api.Services.Refactor;

    [Route("wzhealthcard/api/v2/secrecy")]
    [ApiController]
    public class SecrecyV2Controller : BaseApi
    {
        private readonly ResultCodeHandler rc;
        private readonly IHealthCardService hcSvc;
        private readonly ISocialCardServiceProxyHandler scsProxy;
        private readonly IErrorHandler error;

        public SecrecyV2Controller(ResultCodeHandler rc, IHealthCardService hcSvc, ISocialCardServiceProxyHandler scsProxy, IErrorHandler error)
        {
            this.rc = rc;
            this.hcSvc = hcSvc;
            this.scsProxy = scsProxy;
            this.error = error;
        }

        [Route("applybyface")]
        public string DoS0002V2(ApiArgument<DoS0002V2Arg> arg)
        {
            var result = rc.GetInstanceByUnknownCode<DoS0002V2Result>(arg);

            try
            {
                (bool state, string json) = arg.Verify();
                if (!state)
                {
                    return json;
                }

                var arg30005 = new ApiArgument<ErhcmemberApplyQueryArgument>
                {
                    Header = arg.Header,
                    Data = new ErhcmemberApplyQueryArgument
                    {
                        IdCardType = arg.Data.idCardType,
                        IdCardValue = arg.Data.idCardValue,
                        Name = arg.Data.name
                    }
                };

                arg30005.Header.TradeCode = "30005";

                var eaResult = hcSvc.ErhcmemberApplyQuery(arg30005);
                //if (eaResult.Code != 0)
                if (eaResult.Code != 0)
                {
                    return eaResult.GetJsonString();
                }
                if (eaResult.Data != null && eaResult.Data.IsApply == "0")
                {
                    //return eaResult.ToJsonString();

                    var arg2 = new ApiArgument<ErhcmemberApplyArgument>
                    {
                        Header = arg.Header,
                        Data = new ErhcmemberApplyArgument
                        {
                            Address = string.Empty,
                            AppMode = "3",
                            //Birthday = DateTime.Now,
                            // fix 20190826/birthday allow empty
                            Birthday = string.Empty,
                            BirthPlace = string.Empty,
                            Citizenship = "156",
                            Domicile = string.Empty,
                            IdCardType = arg.Data.idCardType,
                            IdCardValue = arg.Data.idCardValue,
                            Name = arg.Data.name,
                            Nationality = "01",
                            Sex = string.Empty,
                            Tel = arg.Data.tel,
                            TerminalType = "99"
                        }
                    };

                    if (arg.Data.idCardType == "01" && arg.Data.idCardValue.Length == 18)
                    {
                        //arg2.Data.Birthday = Convert.ToDateTime($"{arg.Data.idCardValue.Substring(6, 4)}-{arg.Data.idCardValue.Substring(10, 2)}-{arg.Data.idCardValue.Substring(12, 2)}");
                        // fix 20190826/birthday allow empty
                        arg2.Data.Birthday = $"{arg.Data.idCardValue.Substring(6, 4)}-{arg.Data.idCardValue.Substring(10, 2)}-{arg.Data.idCardValue.Substring(12, 2)}";
                        arg2.Data.Sex = int.Parse(arg.Data.idCardValue.Substring(14, 1)) % 2 == 0 ? "2" : "1";
                    }

                    arg2.Header.GuaranteeCode = "01";
                    arg2.Header.TradeCode = "30001";

                    var r2 = hcSvc.ErhcmemberApply(arg2);

                    if (r2.Code != 0)
                    {
                        return r2.GetJsonString();
                    }
                }

                //using (MonitorScope.CreateScope(MethodBase.GetCurrentMethod().Name))
                //{
                var ar = scsProxy.Do1106(arg.Data.hosid, arg.Data.hosname, arg.Data.termid, arg.Data.terminfo, arg.Data.ftokenurl);
                if (ar.Success)
                {
#if DEBUG
                    ar.Data = new WZSocialCardServiceResult1106Data
                    {
                        retcode = "00",
                        cardsign = "1",
                        qrcode = "999",
                        validseconds = "12000"
                    };
#endif
                    if (ar.Data.retcode == "00")
                    {
                        result.Succeed(
                            ar.Data.retcode,
                            ar.Data.retmsg,
                            new DoS0002V2Result
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
                //}
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return result.GetJsonString();
        }

        [Route("applybyid")]
        public string DoS0003V2(ApiArgument<DoS0003V2Arg> arg)
        {
            var result = rc.GetInstanceByUnknownCode<DoS0003V2Result>(arg);

            try
            {
                (bool state, string json) = arg.Verify();
                if (!state)
                {
                    return json;
                }

                var arg30005 = new ApiArgument<ErhcmemberApplyQueryArgument>
                {
                    Header = arg.Header,
                    Data = new ErhcmemberApplyQueryArgument
                    {
                        IdCardType = arg.Data.IdCardType,
                        IdCardValue = arg.Data.IdCardValue,
                        Name = arg.Data.Name
                    }
                };

                arg.Header.TradeCode = "30005";

                var eaResult = hcSvc.ErhcmemberApplyQuery(arg30005);
                if (eaResult.Code != 0)
                {
                    return eaResult.GetJsonString();
                }
                else if (eaResult.Data != null && eaResult.Data.IsApply == "0")
                {
                    //return eaResult.ToJsonString();

                    var arg2 = new ApiArgument<ErhcmemberApplyArgument>
                    {
                        Header = arg.Header,
                        Data = new ErhcmemberApplyArgument
                        {
                            Address = string.Empty,
                            AppMode = "3",
                            //Birthday = DateTime.Now,
                            // fix 20190826/birthday allow empty
                            Birthday = string.Empty,
                            BirthPlace = string.Empty,
                            Citizenship = "156",
                            Domicile = string.Empty,
                            IdCardType = arg.Data.IdCardType,
                            IdCardValue = arg.Data.IdCardValue,
                            Name = arg.Data.Name,
                            Nationality = "01",
                            Sex = string.Empty,
                            Tel = arg.Data.tel,
                            TerminalType = "99"
                        }
                    };

                    if (arg.Data.IdCardType == "01" && arg.Data.IdCardValue.Length == 18)
                    {
                        //arg2.Data.Birthday = Convert.ToDateTime($"{arg.Data.IdCardValue.Substring(6, 4)}-{arg.Data.IdCardValue.Substring(10, 2)}-{arg.Data.IdCardValue.Substring(12, 2)}");
                        // fix 20190826/birthday allow empty
                        arg2.Data.Birthday = $"{arg.Data.IdCardValue.Substring(6, 4)}-{arg.Data.IdCardValue.Substring(10, 2)}-{arg.Data.IdCardValue.Substring(12, 2)}";
                        arg2.Data.Sex = int.Parse(arg.Data.IdCardValue.Substring(14, 1)) % 2 == 0 ? "2" : "1";
                    }

                    arg2.Header.GuaranteeCode = "01";
                    arg2.Header.TradeCode = "30001";

                    var r2 = hcSvc.ErhcmemberApply(arg2);

                    if (r2.Code != 0)
                    {
                        return r2.GetJsonString();
                    }
                }

                //using (MonitorScope.CreateScope(MethodBase.GetCurrentMethod().Name))
                //{
                var ar = scsProxy.Do1105(eaResult.Data.ErhcCardNo, eaResult.Data.Empi, arg.Data.IdCardType, arg.Data.IdCardValue);

                if (ar.Success)
                {
#if DEBUG
                    ar.Data = new WZSocialCardServiceResult1105Data
                    {
                        retcode = "00",
                        cardsign = "1",
                        qrcode = "777",
                        validseconds = "11000"
                    };
#endif
                    if (ar.Data.retcode == "00")
                    {
                        string cardSign = CommonConvert.ConvertToSocialCardState(ar.Data.cardsign);
                        
                        result.Succeed(
                            ar.Data.retcode,
                            ar.Data.retmsg,
                            new DoS0003V2Result
                            {
                                eSocialSecurityCard_Sign = cardSign,
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
                //}
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return result.GetJsonString();
        }
    }
}
