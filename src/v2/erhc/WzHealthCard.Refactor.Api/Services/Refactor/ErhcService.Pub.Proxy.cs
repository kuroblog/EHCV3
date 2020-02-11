
using WzHealthCard.Refactor.Api.Common;
using WzHealthCard.Refactor.Api.Extensions;

namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Text;

    public interface IErhcPubServiceProxy
    {
        string Do30001(ErhcPubHeader header, List<KeyValuePair<string, string>> body);

        string Do30002(ErhcPubHeader header, List<KeyValuePair<string, string>> body);

        string Do30003(ErhcPubHeader header, List<KeyValuePair<string, string>> body);

        string Do30004(ErhcPubHeader header, List<KeyValuePair<string, string>> body);

        string Do30005(ErhcPubHeader header, List<KeyValuePair<string, string>> body);

        string Do31001(ErhcPubHeader header, List<KeyValuePair<string, string>> body);
    }

    public class ErhcPubServiceProxy : IErhcPubServiceProxy
    {
        private readonly ILogger logger;
        private readonly ConfigManager config;
        private readonly IMonitorModelScope _monitorScope;
        private readonly IHttpClientFactory _httpClientFactory;

        public ErhcPubServiceProxy(ILogger logger, ConfigManager config, IMonitorModelScope monitorScope, IHttpClientFactory httpClientFactory)
        {
            this.logger = logger;
            this.config = config;
            _monitorScope = monitorScope;
            _httpClientFactory = httpClientFactory;
        }

        private string erhcUrl => config.GetAppSetting("ErhcPubRootUrl");

        private readonly HttpClientHandler sslHandler = new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
        };

        // TODO:
        // 1. exception handler
        // 2. timeout handler
        // 3. retry
        private string doService(string url, string actionUrl, ErhcPubHeader header, List<KeyValuePair<string, string>> body)
        {
            HttpClient client = null;
            HttpRequestMessage request = null;
            try
            {
                //开始时间
                var st = DateTime.Now;
                _monitorScope.Add(RemoteInterfaces.HealthInterface12, header?.tradeCode);
                _monitorScope.Add(RemoteInterfaces.HealthInterface12, header?.tradeCode, "开始时间", $"{st:yyyy-MM-dd HH:mm:ss fff}");

                using (client = _httpClientFactory.CreateClient(RemoteHttpNames.RemoteName))
                {

                    request = new HttpRequestMessage(HttpMethod.Post, Path.Combine(url, actionUrl))
                    {
                        Content = new StringContent(string.Empty, Encoding.UTF8, "application/x-www-form-urlencoded")
                    };

                    request.Headers.Add(nameof(header.organizationId), header.organizationId);
                    request.Headers.Add(nameof(header.appId), header.appId);
                    request.Headers.Add(nameof(header.tradeCode), header.tradeCode);
                    request.Headers.Add(nameof(header.requestTime), header.requestTime);
                    request.Headers.Add(nameof(header.sign), header.sign);
                    request.Headers.Add(nameof(header.dataSources), header.dataSources);
                    if (!string.IsNullOrEmpty(header.guaranteeCode))
                    {
                        request.Headers.Add(nameof(header.guaranteeCode), header.guaranteeCode);
                    }

                    //日志记录
                    _monitorScope.Add(RemoteInterfaces.HealthInterface12, header?.tradeCode, "请求Url", url);
                    _monitorScope.Add(RemoteInterfaces.HealthInterface12, header?.tradeCode, "请求头", request.Headers.ToJson());

                    request.Content = new FormUrlEncodedContent(body);

                    //参数记录
                    _monitorScope.Add(RemoteInterfaces.HealthInterface12, header?.tradeCode, "请求参数", body.ToJson());

                    //var response = client.SendAsync(request).Result;

                    var response = logger.SaveProxyLog(() =>
                    {
                        logger.Debug($"request-header:{JsonConvert.SerializeObject(request.Headers)}");
                        logger.Debug($"request-content-type:{JsonConvert.SerializeObject(request.Content.Headers)}");
                        logger.Debug($"request-content:{request.Content.ReadAsStringAsync().Result}");

                        var result = client.SendAsync(request).Result;


                        logger.Debug($"response-status-code:{result.StatusCode}");
                        logger.Debug($"response-content:{result.Content.ReadAsStringAsync().Result}");

                        return result;
                    });

                    response.EnsureSuccessStatusCode();

                    //记录结果
                    _monitorScope.Add(RemoteInterfaces.HealthInterface12, header?.tradeCode, "返回结果", response.Content.ReadAsStringAsync().Result);
                    var et = DateTime.Now;
                    _monitorScope.Add(RemoteInterfaces.HealthInterface12, header?.tradeCode, "结束时间", $"{et:yyyy-MM-dd HH:mm:ss fff}  运行时间:{(et - st).TotalMilliseconds}");

                    return response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                ErhcRemoteException.ThrowError(ex);
            }
            finally
            {
                request?.Dispose();
                client?.Dispose();
            }

            return string.Empty;
        }

        public string Do30001(ErhcPubHeader header, List<KeyValuePair<string, string>> body) => doService(erhcUrl, config.GetAppSetting("ErhcPubCreateHealthCardUrl"), header, body);

        public string Do30002(ErhcPubHeader header, List<KeyValuePair<string, string>> body) => doService(erhcUrl, config.GetAppSetting("ErhcPubUpdateHealthCardUrl"), header, body);

        public string Do30003(ErhcPubHeader header, List<KeyValuePair<string, string>> body) => doService(erhcUrl, config.GetAppSetting("ErhcPubDeleteHealthCardUrl"), header, body);

        public string Do30004(ErhcPubHeader header, List<KeyValuePair<string, string>> body) => doService(erhcUrl, config.GetAppSetting("ErhcPubQueryDynamicQrCodeUrl"), header, body);

        public string Do30005(ErhcPubHeader header, List<KeyValuePair<string, string>> body) => doService(erhcUrl, config.GetAppSetting("ErhcPubReadHealthCardUrl"), header, body);

        public string Do31001(ErhcPubHeader header, List<KeyValuePair<string, string>> body) => doService(erhcUrl, config.GetAppSetting("ErhcPubQueryOrgUrl"), header, body);
    }
}