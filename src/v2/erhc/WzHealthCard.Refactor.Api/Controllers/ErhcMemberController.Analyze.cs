
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using WzHealthCard.Refactor.Api.Models;
using WzHealthCard.Refactor.Api.Models.Refactor;
using WzHealthCard.Refactor.Api.Services.Refactor;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WzHealthCard.Refactor.Api.Common;
using WzHealthCard.Refactor.Api.Infrastructure.AspFilters;

namespace WzHealthCard.Refactor.Api.Controllers
{
    //[Route("wzhealthcard/api/v1/ErhcMember")]
    //[ApiController]
    //public  class ErhcMember_AnalyzeController:BaseApi
    public partial class ErhcMemberController
    {


        [HttpGet, Route("test2")]
        public async Task<ActionResult> Test2(string user = "")
        {
            return await Task.FromResult(Ok($"{nameof(Test2)} on SmallApp, {user}."));
        }

        //private readonly ResultCodeHandler rc;
        //private readonly ConfigManager config;
        //private readonly IErrorHandler error;
        //private readonly IMonitorModelScope _monitorScope;

        //public ErhcMember_AnalyzeController(ResultCodeHandler rch, ConfigManager config, IErrorHandler error, IMonitorModelScope monitorScope)
        //{
        //    rc = rch;
        //    this.config = config;
        //    this.error = error;
        //    _monitorScope = monitorScope;
        //}

        [Route("useanalyze/month")]
        [HttpPost,HttpGet]
        public async Task<string> MonthUse(ApiArgument<MonthUseArg> arg)
        {
            var result = rc.GetInstanceByUnknownCode<MonthUseResult[]>(arg);

            try
            {
                arg.Validate(out var message);
                //if (!arg.Validate(out var message))
                //    return JsonConvert.SerializeObject(result.Error(ErrorCode.LogicalError, message));

                var response = await SendRequest(arg.Header.RequestId, "ErhcBaseSvcUrl", "ErhcCardAnalysisMonthUseSvcUrl", async (client, requestUrl) =>
                {
                    var qStrings = new List<string>();
                    //日志记录
                    monitorScope.Add("中间件Url", requestUrl);

                    if (string.IsNullOrEmpty(arg.Data.city) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.city)}={arg.Data.city}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.year) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.year)}={arg.Data.year}");
                    }

                    if (qStrings.Count > 0)
                    {
                        requestUrl += $"?{string.Join("&", qStrings)}";
                    }
                    if (qStrings.Any())
                    {
                        monitorScope.Add("中间件参数", JsonConvert.SerializeObject(qStrings));
                    }
                    return await client.GetAsync(requestUrl);
                });
                string strResult = await response.Content.ReadAsStringAsync();
                var datas = JsonConvert.DeserializeObject<MonthUseResult[]>(strResult);
                //日志记录
                monitorScope.Add("中间件返回", strResult);

                result.Succeed((int)ResultCodes.Succeed, "", datas);
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return JsonConvert.SerializeObject(result);
        }

        [HttpPost,HttpGet,Route("useanalyze/city")]
        public async Task<string> CityUse([FromBody]ApiArgument<CityUseArg> arg)
        {
            var result = rc.GetInstanceByUnknownCode<CityUseResult[]>(arg);

            try
            {
                arg.Validate(out var message);
                //if (!arg.Validate(out var message))
                //    return JsonConvert.SerializeObject(result.Error(ErrorCode.LogicalError, message));

                var response = await SendRequest(arg.Header.RequestId, "ErhcBaseSvcUrl", "ErhcCardAnalysisCityUseSvcUrl", async (client, requestUrl) =>
                {
                    //日志记录
                    monitorScope.Add("中间件Url", requestUrl);
                    var qStrings = new List<string>();
                    if (string.IsNullOrEmpty(arg.Data.city) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.city)}={arg.Data.city}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.begin) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.begin)}={arg.Data.begin}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.end) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.end)}={arg.Data.end}");
                    }

                    if (qStrings.Count > 0)
                    {
                        requestUrl += $"?{string.Join("&", qStrings)}";
                        monitorScope.Add("中间件参数", JsonConvert.SerializeObject(qStrings));
                    }

                    return await client.GetAsync(requestUrl);
                });
                var resultStr = await response.Content.ReadAsStringAsync();
                var datas = JsonConvert.DeserializeObject<CityUseResult[]>(resultStr);
                monitorScope.Add("中间件返回", resultStr);

                result.Succeed((int)ResultCodes.Succeed, "", datas);
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return JsonConvert.SerializeObject(result);
        }

        [HttpGet,HttpPost,Route("useanalyze/step")]
        public async Task<string> StepUse(ApiArgument<StepUseArg> arg)
        {
            var result = rc.GetInstanceByUnknownCode<StepUseResult[]>(arg);

            try
            {
                arg.Validate(out var message);
                //if (!arg.Validate(out var message))
                //    return JsonConvert.SerializeObject(result.Error(ErrorCode.LogicalError, message));

                var response = await SendRequest(arg.Header.RequestId, "ErhcBaseSvcUrl", "ErhcCardAnalysisStepUseSvcUrl", async (client, requestUrl) =>
                {
                    //日志记录
                    monitorScope.Add("中间件Url", requestUrl);
                    var qStrings = new List<string>();
                    if (string.IsNullOrEmpty(arg.Data.city) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.city)}={arg.Data.city}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.begin) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.begin)}={arg.Data.begin}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.end) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.end)}={arg.Data.end}");
                    }

                    if (qStrings.Count > 0)
                    {
                        requestUrl += $"?{string.Join("&", qStrings)}";
                        monitorScope.Add("中间件参数", requestUrl);
                    }

                    return await client.GetAsync(requestUrl);
                });
                var resultStr = await response.Content.ReadAsStringAsync();
                var datas = JsonConvert.DeserializeObject<StepUseResult[]>(resultStr);
                monitorScope.Add("中间件返回", resultStr);

                result.Succeed((int)ResultCodes.Succeed, "", datas);
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return JsonConvert.SerializeObject(result);
        }

        [HttpPost,HttpGet,Route("useanalyze/age")]
        public async Task<string> AgeUse(ApiArgument<AgeUseArg> arg)
        {
            var result = rc.GetInstanceByUnknownCode<AgeUseResult[]>(arg);

            try
            {
                arg.Validate(out var message);
                //if (!arg.Validate(out var message))
                //    return JsonConvert.SerializeObject(result.Error(ErrorCode.LogicalError, message));
                var response = await SendRequest(arg.Header.RequestId, "ErhcBaseSvcUrl", "ErhcCardAnalysisAgeUseSvcUrl", async (client, requestUrl) =>
                {
                    //日志记录
                    monitorScope.Add("中间件Url", requestUrl);
                    var qStrings = new List<string>();
                    if (string.IsNullOrEmpty(arg.Data.city) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.city)}={arg.Data.city}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.begin) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.begin)}={arg.Data.begin}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.end) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.end)}={arg.Data.end}");
                    }

                    if (qStrings.Count > 0)
                    {
                        requestUrl += $"?{string.Join("&", qStrings)}";
                        monitorScope.Add("中间件参数", requestUrl);
                    }

                    return await client.GetAsync(requestUrl);
                });
                var resultStr = await response.Content.ReadAsStringAsync();
                var datas = JsonConvert.DeserializeObject<AgeUseResult[]>(resultStr);
                monitorScope.Add("中间件返回", resultStr);

                result.Succeed((int)ResultCodes.Succeed, "", datas);
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return JsonConvert.SerializeObject(result);
        }

        private readonly HttpClientHandler sslHandler = new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
        };

        private async Task<HttpResponseMessage> SendRequest(string requestId, string rootUrlKey, string actionUrlKey, Func<HttpClient, string, Task<HttpResponseMessage>> method)
        {
            //var sslHandler = new HttpClientHandler();
            //sslHandler.ClientCertificateOptions = ClientCertificateOption.Manual;
            //sslHandler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true;
            HttpClient client = null;
            using (client = _httpClientFactory.CreateClient(RemoteHttpNames.RemoteName))
            {
                try
                {
                    client.DefaultRequestHeaders.ConnectionClose = true;
                    client.DefaultRequestHeaders.Add("RequestId", requestId);

                    var host = config.GetAppSetting(rootUrlKey);
                    var url = config.GetAppSetting(actionUrlKey);
                    var requestUrl = Path.Combine(host, url);


                    var response = await method.Invoke(client, requestUrl);
                    response.EnsureSuccessStatusCode();


                    return response;
                }
                finally
                {
                    client?.Dispose();
                }
            }
        }

        [HttpPost,HttpGet,Route("applyanalyze/total")]
        public async Task<string> TotalApply(ApiArgument<TotalApplyArg> arg)
        {
            var result = rc.GetInstanceByUnknownCode<int>(arg);

            try
            {
                arg.Validate(out var message);
                //if (!arg.Validate(out var message))
                //    return JsonConvert.SerializeObject(result.Error(ErrorCode.LogicalError, message));

                var response = await SendRequest(arg.Header.RequestId, "ErhcBaseSvcUrl", "ErhcCardAnalysisYearApplySvcUrl", async (client, requestUrl) =>
                {
                    //日志记录
                    monitorScope.Add("中间件Url", requestUrl);
                    var qStrings = new List<string>();
                    if (string.IsNullOrEmpty(arg.Data.city) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.city)}={arg.Data.city}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.begin) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.begin)}={arg.Data.begin}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.end) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.end)}={arg.Data.end}");
                    }

                    if (qStrings.Count > 0)
                    {
                        requestUrl += $"?{string.Join("&", qStrings)}";
                        monitorScope.Add("中间件参数", requestUrl);
                    }

                    return await client.GetAsync(requestUrl);
                });
                var resultStr = await response.Content.ReadAsStringAsync();
                var datas = JsonConvert.DeserializeObject<int>(resultStr);
                monitorScope.Add("中间件返回", resultStr);
                result.Succeed((int)ResultCodes.Succeed, "", datas);
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return JsonConvert.SerializeObject(result);
        }

        [HttpPost,HttpGet,Route("applyanalyze/month")]
        public async Task<string> MonthApply(ApiArgument<MonthApplyArg> arg)
        {
            var result = rc.GetInstanceByUnknownCode<MonthApplyResult[]>(arg);

            try
            {
                arg.Validate(out var message);
                //if (!arg.Validate(out var message))
                //    return JsonConvert.SerializeObject(result.Error(ErrorCode.LogicalError, message));

                var response =await SendRequest(arg.Header.RequestId, "ErhcBaseSvcUrl", "ErhcCardAnalysisMonthApplySvcUrl", async (client, requestUrl) =>
                {
                    //日志记录
                    monitorScope.Add("中间件Url", requestUrl);
                    var qStrings = new List<string>();
                    if (string.IsNullOrEmpty(arg.Data.city) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.city)}={arg.Data.city}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.year) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.year)}={arg.Data.year}");
                    }

                    if (qStrings.Count > 0)
                    {
                        requestUrl += $"?{string.Join("&", qStrings)}";
                        monitorScope.Add("中间件参数", requestUrl);
                    }

                    return await client.GetAsync(requestUrl);
                });
                var resultStr = await response.Content.ReadAsStringAsync();
                var datas = JsonConvert.DeserializeObject<MonthApplyResult[]>(resultStr);
                monitorScope.Add("中间件返回", resultStr);
                result.Succeed((int)ResultCodes.Succeed, "", datas);
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return JsonConvert.SerializeObject(result);
        }

        [HttpPost,HttpGet,Route("applyanalyze/city")]
        public async Task<string> CityApply(ApiArgument<CityApplyArg> arg)
        {
            var result = rc.GetInstanceByUnknownCode<CityApplyResult[]>(arg);

            try
            {
                arg.Validate(out var message);
                //if (!arg.Validate(out var message))
                //    return JsonConvert.SerializeObject(result.Error(ErrorCode.LogicalError, message));

                var response =await SendRequest(arg.Header.RequestId, "ErhcBaseSvcUrl", "ErhcCardAnalysisCityApplySvcUrl", async (client, requestUrl) =>
                {
                    //日志记录
                    monitorScope.Add("中间件Url", requestUrl);
                    var qStrings = new List<string>();
                    if (string.IsNullOrEmpty(arg.Data.city) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.city)}={arg.Data.city}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.begin) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.begin)}={arg.Data.begin}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.end) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.end)}={arg.Data.end}");
                    }

                    if (qStrings.Count > 0)
                    {
                        requestUrl += $"?{string.Join("&", qStrings)}";
                        monitorScope.Add("中间件参数", requestUrl);
                    }

                    return await client.GetAsync(requestUrl);
                });
                var resultStr = await response.Content.ReadAsStringAsync();
                var datas = JsonConvert.DeserializeObject<CityApplyResult[]>(resultStr);
                monitorScope.Add("中间件返回", resultStr);
                result.Succeed((int)ResultCodes.Succeed, "", datas);
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return JsonConvert.SerializeObject(result);
        }

        [HttpPost,HttpGet,Route("applyanalyze/appmode")]
        public async Task<string> AppModeApply(ApiArgument<AppModeApplyArg> arg)
        {
            var result = rc.GetInstanceByUnknownCode<AppModeApplyResult[]>(arg);

            try
            {
                arg.Validate(out var message);
                //if (!arg.Validate(out var message))
                //    return JsonConvert.SerializeObject(result.Error(ErrorCode.LogicalError, message));

                var response = await SendRequest(arg.Header.RequestId, "ErhcBaseSvcUrl", "ErhcCardAnalysisAppModeApplySvcUrl", async (client, requestUrl) =>
                {
                    //日志记录
                    monitorScope.Add("中间件Url", requestUrl);
                    var qStrings = new List<string>();
                    if (string.IsNullOrEmpty(arg.Data.city) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.city)}={arg.Data.city}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.begin) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.begin)}={arg.Data.begin}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.end) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.end)}={arg.Data.end}");
                    }

                    if (qStrings.Count > 0)
                    {
                        requestUrl += $"?{string.Join("&", qStrings)}";
                        monitorScope.Add("中间件参数", requestUrl);
                    }

                    return await client.GetAsync(requestUrl);
                });
                var resultStr = await response.Content.ReadAsStringAsync();
                var datas = JsonConvert.DeserializeObject<AppModeApplyResult[]>(resultStr);
                monitorScope.Add("中间件返回", resultStr);
                result.Succeed((int)ResultCodes.Succeed, "", datas);
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return JsonConvert.SerializeObject(result);
        }

        [HttpPost, HttpGet, Route("useanalyze/query")]
        public async Task<IActionResult> UseAnalyzeQuery(ApiArgument<ErhcmemberUseAnalyzeQueryArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberUseAnalyzeQueryResponse>(arg);

            try
            {
                (bool state, string json) = arg.Verify(false);
                if (!state)
                {
                    result.Error(ErrorCode.LocalError, "参数验证失败");
                    return Ok(result);
                }

                var response = await SendRequest(arg.Header.RequestId, "ErhcBaseSvcUrl", "ErhcCardUseQuerySvcUrl", async (client, requestUrl) =>
                {
                    //日志记录
                    monitorScope.Add("中间件Url", requestUrl);
                    var qStrings = new List<string>();
                    if (string.IsNullOrEmpty(arg.Data.cardId) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.cardId)}={arg.Data.cardId}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.empi) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.empi)}={arg.Data.empi}");
                    }

                    if (string.IsNullOrEmpty(arg.Data.idCardNo) == false)
                    {
                        qStrings.Add($"{nameof(arg.Data.idCardNo)}={arg.Data.idCardNo}");
                    }

                    if (qStrings.Count > 0)
                    {
                        requestUrl += $"?{string.Join("&", qStrings)}";
                    }

                    return await client.GetAsync(requestUrl);
                });

                response.EnsureSuccessStatusCode();

                var resultStr = await response.Content.ReadAsStringAsync();
                monitorScope.Add("中间件返回", resultStr);

                var datas = JsonConvert.DeserializeObject<CardUseAnalyzeQueryResponse[]>(response.Content.ReadAsStringAsync().Result);

                result.Succeed((int)ResultCodes.Succeed, "", new ErhcmemberUseAnalyzeQueryResponse
                {
                    datas = datas
                });
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return Ok(result);
        }
    }
}