
using WzHealthCard.Refactor.Api.Common;
using WzHealthCard.Refactor.Api.Extensions;

namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using ErhcServiceProxy;
    using Newtonsoft.Json;
    using System;
    using System.ServiceModel;
    using System.Xml;

    public interface IErhcPrvServiceProxy
    {
        string Do10001(string header, string body);

        string Do11001(string header, string body);

        string Do11002(string header, string body);

        string Do11003(string header, string body);

        string Do11004(string header, string body);

        string Do12001(string header, string body);

        string Do12002(string header, string body);
    }

    public class ErhcPrvServiceProxy : IErhcPrvServiceProxy
    {
        private readonly ILogger logger;
        private readonly ConfigManager config;
        private readonly IMonitorModelScope _monitorScope;

        public ErhcPrvServiceProxy(ILogger logger, ConfigManager config, IMonitorModelScope monitorScope)
        {
            this.logger = logger;
            this.config = config;
            _monitorScope = monitorScope;
        }

        private string erhcUrl => config.GetAppSetting("ErhcPrvWsdlUrl");

        // TODO:
        // 1. exception handler
        // 2. timeout handler
        // 3. retry
        private string doService(string url, string HeaderInParm, string BodyInParm,string methodName="")
        {
            try
            {
                //日志记录
                var st = DateTime.Now;
                _monitorScope.Add(RemoteInterfaces.HealthInterface13, methodName);
                _monitorScope.Add(RemoteInterfaces.HealthInterface13, methodName, "开始时间", $"{st:yyyy-MM-dd HH:mm:ss fff}");


                var binding = new BasicHttpBinding
                {
                    ReceiveTimeout = new TimeSpan(0, 0, 60),
                    SendTimeout = new TimeSpan(0, 2, 0),
                    MaxReceivedMessageSize = int.MaxValue,
                    MaxBufferPoolSize = int.MaxValue,
                    MaxBufferSize = int.MaxValue,
                    ReaderQuotas = XmlDictionaryReaderQuotas.Max
                };

                binding.Security.Mode = BasicHttpSecurityMode.None;

                var endpoint = new EndpointAddress(erhcUrl);


                var soapFactory = new ChannelFactory<ErhcService>(binding, endpoint);
                var soapClient = soapFactory.CreateChannel();

                var doServiceRequest = new doService(new doServiceBody(HeaderInParm, BodyInParm));

                //var proxyResult = soapClient.doServiceAsync(doServiceRequest).Result;

                //日志记录
                _monitorScope.Add(RemoteInterfaces.HealthInterface13, methodName, "接口Url", erhcUrl);
                _monitorScope.Add(RemoteInterfaces.HealthInterface13, methodName, "接口参数", doServiceRequest.ToJson());

                var proxyResult = logger.SaveProxyLog(() =>
                {
                    logger.Debug($"request-header:{HeaderInParm}");
                    //LogRecorder.MonitorTrace($"request-content-type:{JsonConvert.SerializeObject(request.Content.Headers)}");
                    logger.Debug($"request-content:{BodyInParm}");

                    var result = soapClient.doServiceAsync(doServiceRequest).Result;

                    //LogRecorder.MonitorTrace($"response-status-code:{result.StatusCode}");
                    logger.Debug($"response-content:{result.Body.MsgOutParm}");

                    return result;
                });

                var xmlContent = proxyResult.Body.MsgOutParm;

                var docResult = new XmlDocument();
                docResult.LoadXml(xmlContent);
                //接口返回结果
                _monitorScope.Add(RemoteInterfaces.HealthInterface13, methodName, "接口返回", xmlContent);
                var et = DateTime.Now;
                _monitorScope.Add(RemoteInterfaces.HealthInterface13, methodName, "结束时间", $"{et:yyyy-MM-dd HH:mm:ss fff}  运行时间:{(et - st).TotalMilliseconds}");


                return JsonConvert.SerializeXmlNode(docResult, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception ex)
            {
                ErhcRemoteException.ThrowError(ex);
            }

            return string.Empty;
        }

        public string Do10001(string header, string body) => doService(erhcUrl, header, body,"10001");

        public string Do11001(string header, string body) => doService(erhcUrl, header, body, "11001");

        public string Do11002(string header, string body) => doService(erhcUrl, header, body, "11002");

        public string Do11003(string header, string body) => doService(erhcUrl, header, body, "11003");

        public string Do11004(string header, string body) => doService(erhcUrl, header, body, "11004");

        public string Do12001(string header, string body) => doService(erhcUrl, header, body, "12001");

        public string Do12002(string header, string body) => doService(erhcUrl, header, body, "12002");
    }
}