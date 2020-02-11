
using System.Globalization;
using WzHealthCard.Refactor.Api.Common;

namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;
    using WzHealthCard.Refactor.Api.Extensions;
    using WzHealthCard.Refactor.Api.Models.Refactor;
    using WzHealthCard.Refactor.Api.Repositories.Erhc;
    using WzHealthCard.Refactor.Api.UnitOfWorks;

    public class ErhcPrvService : IErhcService
    {
        private readonly IErhcPrvServiceProxy proxy;
        private readonly ConfigManager config;
        private readonly IErrorHandler error;
        private ILogger logger;
        private readonly ResultCodeHandler rc;
        private readonly ErhcUnitOfWork erhcUow;
        private readonly CardRepository cardRepo;
        private readonly CardExtendRepository cardExRepo;
        private readonly CardFamilyRepository cardFamilyRepo;
        private readonly ISocialCardServiceProxyHandler scsProxy;
        private readonly ISmsHandler sms;
        private readonly IHttpClientFactory _httpClientFactory;

        public ErhcPrvService(
            IErhcPrvServiceProxy proxy,
            ConfigManager config,
            IErrorHandler error,
            ILogger logger,
            ResultCodeHandler rc,
            ErhcUnitOfWork erhcUow,
            CardRepository cardRepo,
            CardExtendRepository cardExRepo,
            CardFamilyRepository cardFamilyRepo,
            ISocialCardServiceProxyHandler scsProxy,
            ISmsHandler sms, IHttpClientFactory httpClientFactory)
        {
            this.proxy = proxy;
            this.config = config;
            this.error = error;
            this.logger = logger;
            this.rc = rc;
            this.erhcUow = erhcUow;
            this.cardRepo = cardRepo;
            this.cardExRepo = cardExRepo;
            this.cardFamilyRepo = cardFamilyRepo;
            this.scsProxy = scsProxy;
            this.sms = sms;
            _httpClientFactory = httpClientFactory;
        }

        public int ServiceType => 1;

        private void ConvertHeaderCode(ErhcPrvHeader header)
        {
            switch (header.header.tradecode)
            {
                case "10001":
                    header.header.tradecode = "10001";
                    break;
                case "30001":
                    header.header.tradecode = "11001";
                    break;
                case "30002":
                    header.header.tradecode = "11002";
                    break;
                case "30003":
                    header.header.tradecode = "11003";
                    break;
                case "11004":
                    header.header.tradecode = "11004";
                    break;
                case "12001":
                    header.header.tradecode = "12001";
                    break;
                case "30005":
                    header.header.tradecode = "12002";
                    break;
                default: throw new Exception($"不是有效的{nameof(header.header.tradecode)}：{header.header.tradecode}。");
            }
        }

        private string ConvertToXmlString<PType>(PType parameter)
        {
            var proxyHeaderJson = JsonConvert.SerializeObject(parameter);
            return JsonConvert.DeserializeXmlNode(proxyHeaderJson).OuterXml;
        }

        private string DoProxyService(ErhcPrvHeader header, string headerXml, string bodyXml)
        {
            var proxyJsonResult = string.Empty;
            switch (header.header.tradecode)
            {
                case "10001":
                    proxyJsonResult = proxy.Do10001(headerXml, bodyXml);
                    break;
                case "11001":
                    proxyJsonResult = proxy.Do11001(headerXml, bodyXml);
                    break;
                case "11002":
                    proxyJsonResult = proxy.Do11002(headerXml, bodyXml);
                    break;
                case "11003":
                    proxyJsonResult = proxy.Do11003(headerXml, bodyXml);
                    break;
                case "11004":
                    proxyJsonResult = proxy.Do11004(headerXml, bodyXml);
                    break;
                case "12001":
                    proxyJsonResult = proxy.Do12001(headerXml, bodyXml);
                    break;
                case "12002":
                    proxyJsonResult = proxy.Do12002(headerXml, bodyXml);
                    break;
                default:
                    break;
            }

            return proxyJsonResult;
        }

        private void ServiceHandler<TArg, TProxyBody, TProxyResult>(ApiArgument<TArg> arg, Action<TProxyResult> resultHandler)
        {
            var header = Activator.CreateInstance(typeof(ErhcPrvHeader), arg.Header) as ErhcPrvHeader;
            ConvertHeaderCode(header);
            var headerXml = ConvertToXmlString(header);

            var body = Activator.CreateInstance(typeof(TProxyBody), arg.Data);
            var bodyXml = ConvertToXmlString(body);
            var proxyJsonResult = DoProxyService(header, headerXml, bodyXml);
            //#if !DEBUG
            //            var proxyJsonResult = DoProxyService(header, headerXml, bodyXml);
            //#else
            //            var proxyJsonResult = new ErhcPrv11001Result
            //            {
            //                body = new ErhcPrvResultInParm<ErhcWseResultParameter, ErhcPrv11001ResultParm>
            //                {
            //                    msg = new ErhcPrv11001ResultParm
            //                    {
            //                        address = "1",
            //                        citizenship = "2",
            //                        empi = "3",
            //                        erhc_cardno = "4",
            //                        erhc_enddate = DateTime.Now.ToString(),
            //                        idcard_no = "6",
            //                        idcard_type = "01",
            //                        idcard_value = "8",
            //                        issuer_orgcode = "9",
            //                        issuer_orgname = "10",
            //                        name = "11",
            //                        nationality = "12",
            //                        qrcode_imagedata = "13",
            //                        qrcode_type = "14",
            //                        sex = "15",
            //                        tel = "16"
            //                    },
            //                    result = new ErhcWseResultParameter
            //                    {
            //                        return_code = "1",
            //                        return_info = "",
            //                        tradecode = "1"
            //                    }
            //                }
            //            }.GetJsonString();
            //#endif

            var proxyResult = JsonConvert.DeserializeObject<TProxyResult>(proxyJsonResult);

            resultHandler(proxyResult);
        }

        private void DoService<TArg, TResult, TProxyBody, TProxyResult>(ApiArgument<TArg> arg, ApiResultEx<TResult> result, Action<TProxyResult> resultHandler)
        {
            try
            {
                logger.SaveRequestLog(arg);

                ServiceHandler<TArg, TProxyBody, TProxyResult>(arg, resultHandler);

                logger.SaveResponseLog(result, arg.Header.RequestId);
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }
        }

        private readonly HttpClientHandler sslHandler = new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
        };

        private void DoErhcCardData(
            Action<CardEntity> handler,
            CardEntity record,
            (string isApply, string address, string citizenship, string empi, string erhcCardNo, string erhcEndDate, string idCardNo, string idCardType, string idCardVaule, string issuerOrgCode, string issuerOrgName, string name, string nationality, string qrCodeImageInfo, string qrCodeType, string sex, string tel, string userSign) source)
        {
            if (record == null)
            {
                record = new CardEntity
                {
                    CreatedAt = DateTime.Now
                };
            }

            if (source.address != null)
            {
                record.Address = source.address;
            }

            if (source.citizenship != null)
            {
                record.Citizenship = source.citizenship;
            }

            if (source.empi != null)
            {
                record.Empi = source.empi;
            }

            if (source.erhcCardNo != null)
            {
                record.ErhcCardNo = source.erhcCardNo;
            }

            if (source.erhcEndDate != null)
            {
                record.ErhcEndDate = source.erhcEndDate;
            }

            if (source.idCardNo != null)
            {
                record.IdCardNo = source.idCardNo;
            }

            if (source.idCardType != null)
            {
                record.IdCardType = source.idCardType;
            }

            if (source.idCardVaule != null)
            {
                record.IdCardValue = source.idCardVaule;
            }

            if (source.issuerOrgCode != null)
            {
                record.IssuerOrgCode = source.issuerOrgCode;
            }

            if (source.issuerOrgName != null)
            {
                record.IssuerOrgName = source.issuerOrgName;
            }

            if (source.name != null)
            {
                record.Name = source.name;
            }

            if (source.nationality != null)
            {
                record.Nationality = source.nationality;
            }

            if (source.qrCodeImageInfo != null)
            {
                record.QrCodeImageData = source.qrCodeImageInfo;
            }

            if (source.qrCodeType != null)
            {
                record.QrCodeType = source.qrCodeType;
            }

            if (source.sex != null)
            {
                record.Sex = source.sex;
            }

            if (source.tel != null)
            {
                record.Tel = source.tel;
            }
            //record.Id

            if (source.isApply != null)
            {
                record.IsApply = source.isApply;
            }

            //record.IsClosed
            record.UserSign = source.userSign;
            //record.CreatedAt
            record.UpdatedAt = DateTime.Now;

            handler.Invoke(record);
        }

        private void DoErhcCardExtendData(Action<CardExtendEntity> handler, CardExtendEntity record, string[] addr, string[] regAddr, long refId, string qrCodeType, string qrCodeInfo)
        {
            if (record == null)
            {
                record = new CardExtendEntity
                {
                    CreatedAt = DateTime.Now,
                    ErhcCardId = refId
                };
            }

            record.AddrLv0 = addr?.Length >= 1 ? addr[0] : string.Empty;
            record.AddrLv1 = addr?.Length >= 2 ? addr[1] : string.Empty;
            record.AddrLv2 = addr?.Length >= 3 ? addr[2] : string.Empty;
            record.AddrLv3 = addr?.Length >= 4 ? addr[3] : string.Empty;
            record.AddrLv4 = addr?.Length >= 5 ? addr[4] : string.Empty;
            record.AddrLv5 = addr?.Length >= 6 ? addr[5] : string.Empty;

            record.DAddrLv0 = regAddr?.Length >= 1 ? regAddr[0] : string.Empty;
            record.DAddrLv1 = regAddr?.Length >= 2 ? regAddr[1] : string.Empty;
            record.DAddrLv2 = regAddr?.Length >= 3 ? regAddr[2] : string.Empty;
            record.DAddrLv3 = regAddr?.Length >= 4 ? regAddr[3] : string.Empty;
            record.DAddrLv4 = regAddr?.Length >= 5 ? regAddr[4] : string.Empty;
            record.DAddrLv5 = regAddr?.Length >= 6 ? regAddr[5] : string.Empty;

            if (qrCodeType == "1" && qrCodeInfo != record.StaticQrCode)
            {
                record.StaticQrCode = qrCodeInfo;
            }

            record.UpdatedAt = DateTime.Now;

            handler.Invoke(record);
        }

        // TODO
        // 此处两次提交会导致数据不一致
        private CardEntity CreateCard(
            string idCardType,
            string idCardValue,
            (string isApply, string address, string citizenship, string empi, string erhcCardNo, string erhcEndDate, string idCardNo, string idCardType, string idCardVaule, string issuerOrgCode, string issuerOrgName, string name, string nationality, string qrCodeImageInfo, string qrCodeType, string sex, string tel, string userSign) source,
            Action<string, string> smsHandler,
            string smsNumber,
            string smsUser)
        {
            var record = cardRepo.View.Where(p => p.IsClosed == false && p.IdCardType == idCardType && p.IdCardValue == idCardValue)?.OrderByDescending(p => p.CreatedAt)?.FirstOrDefault();
            if (record != null && record.Id != 0)
            {
                DoErhcCardData(cardRepo.Update, record, source);
            }
            else
            {
                //smsHandler?.Invoke(smsNumber, smsUser);

                record = new CardEntity
                {
                    CreatedAt = DateTime.Now
                };

                DoErhcCardData(cardRepo.Insert, record, source);
            }

            erhcUow.Commit();

            var recordEx = cardExRepo.View.Where(p => p.ErhcCardId == record.Id)?.OrderByDescending(p => p.CreatedAt)?.FirstOrDefault();
            if (recordEx != null && recordEx.Id != 0)
            {
                DoErhcCardExtendData(cardExRepo.Update, recordEx, null, null, 0, source.qrCodeType, source.qrCodeImageInfo);
            }
            else
            {
                DoErhcCardExtendData(cardExRepo.Insert, null, null, null, record.Id, source.qrCodeType, source.qrCodeImageInfo);
            }

            erhcUow.Commit();

            return record;
        }

        public void CreateHealthCard(ApiArgument<ErhcmemberApplyArgument> arg, ApiResultEx<ErhcmemberApplyResponse> result)
        {
            DoService<ErhcmemberApplyArgument, ErhcmemberApplyResponse, ErhcPrv11001Body, ErhcPrv11001Result>(arg, result, proxyResult =>
            {
                var proxyReturnCode = -1;
                var isSuccessful = int.TryParse(proxyResult.body.result.return_code, out proxyReturnCode);

                if (isSuccessful && proxyReturnCode == 1)
                {
                    var s = proxyResult.body.msg;

                    //Task.Factory.StartNew(() => IocHelper.Create<ISmsHandler>().SendMsg(s.tel, s.name));

                    result.Succeed(proxyReturnCode, proxyResult?.body?.result?.return_info, new ErhcmemberApplyResponse
                    {
                        EMPI = s.empi,
                        ErhcCardNo = s.erhc_cardno,
                        Name = s.name,
                        Sex = s.sex,
                        IdCardNo = s.idcard_no,
                        IdCardType = s.idcard_type,
                        IdCardValue = s.idcard_value,
                        Citizenship = s.citizenship,
                        Nationality = s.nationality,
                        Tel = s.tel,
                        Address = s.address,
                        IssuerOrgCode = s.issuer_orgcode,
                        IssuerOrgName = s.issuer_orgname,
                        ErhcEndDateTime = Convert.ToDateTime(s.erhc_enddate),
                        QrCodeType = s.qrcode_type,
                        QrCodeImageInfo = s.qrcode_imagedata
                        //QrCodeVaildDateTime = source.qrv
                    });

                    CreateCard(
                        arg.Data.IdCardType,
                        arg.Data.IdCardValue,
                        (null, s.address, s.citizenship, s.empi, s.erhc_cardno, s.erhc_enddate, s.idcard_no, s.idcard_type, s.idcard_value, $"{s.issuer_orgcode},{arg.Header.originAppId}", $"{s.issuer_orgname},{arg.Header.originalOrgName}", s.name, s.nationality, s.qrcode_imagedata, s.qrcode_type, s.sex, s.tel, null),
                        sms.SendMsg,
                        arg.Data.Tel,
                        s.name);

                    //DoApiRequest<WZSocialCardService1105Result, dynamic>(new
                    DoApiRequest<dynamic>(new
                    {
                        appId = arg.Header.originAppId,
                        appMode = arg.Data.AppMode,
                        cardId = s.erhc_cardno,
                        appSource = 0,
                        s.empi
                    }, "建卡分析", "ErhcCardApplyCreateSvcUrl");

                    //scsProxy.Do1005((arg.Data.Birthday.ToString("yyyyMMdd"), arg.Data.Sex, arg.Data.BirthPlace, arg.Data.Domicile), result, (s.erhc_cardno, s.idcard_type, s.idcard_value, s.name, s.tel, s.empi, s.citizenship, s.nationality, s.address));
                    // fix 20190826/birthday allow empty
                    scsProxy.Do1005((arg.Data.Birthday.Replace("-", string.Empty), arg.Data.Sex, arg.Data.BirthPlace, arg.Data.Domicile), result, (s.erhc_cardno, s.idcard_type, s.idcard_value, s.name, s.tel, s.empi, s.citizenship, s.nationality, s.address));
                }
                else
                {
                    result.Failed(proxyReturnCode, proxyResult?.body?.result?.return_info);
                }
            });
        }

        //private TResult DoApiRequest<TResult, TArg>(TArg request, string funCode, string apiUrlKey)
        private void DoApiRequest<TArg>(TArg request, string funCode, string apiUrlKey)
        {
            HttpClient client = null;
            using (client = _httpClientFactory.CreateClient(RemoteHttpNames.RemoteName))
            {
                try
                {
                    logger.Debug($"{funCode}_args:{JsonConvert.SerializeObject(request)}");

                    var host = config.GetAppSetting("ErhcBaseSvcUrl");
                    var url = config.GetAppSetting(apiUrlKey);
                    var path = Path.Combine(host, url);

                    logger.Debug($"{funCode}_path:{path}");

                    var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    var response = client.PostAsync(path, content).Result;

                    logger.Debug($"{funCode}_res_code:{response.StatusCode}");

                    response.EnsureSuccessStatusCode();
                    var resJson = response.Content.ReadAsStringAsync().Result;

                    logger.Debug($"{funCode}_res_content:{resJson}");
                }
                finally
                {
                    client?.Dispose();
                }
            }
            
            //return JsonConvert.DeserializeObject<TResult>(resJson);
        }

        private void DoQueryRegisterService<TArg, TResult, TProxyBody, TProxyResult>(ApiArgument<TArg> arg, ApiResultEx<TResult> result, Action<TProxyResult> resultHandler, Func<bool> queryRegisterHandler)
        {
            try
            {
                logger.SaveRequestLog(arg);

                var isRegistered = queryRegisterHandler();
                if (!isRegistered)
                {
                    ServiceHandler<TArg, TProxyBody, TProxyResult>(arg, resultHandler);
                }

                logger.SaveResponseLog(result, arg.Header.RequestId);
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }
        }

        private void ReadCard(ApiArgument<ErhcmemberApplyQueryArgument> arg, (string isApply, string idCardNo, string sex, string tel, string empi, string erhcCardNo) source)
        {
            var record = cardRepo.View.Where(p => p.IsClosed == false && p.IdCardType == arg.Data.IdCardType && p.IdCardValue == arg.Data.IdCardValue && p.Name == arg.Data.Name)?.OrderByDescending(p => p.CreatedAt)?.FirstOrDefault();
            if (record != null && record.Id != 0)
            {
                record.IsApply = source.isApply;
                record.IdCardNo = source.idCardNo;
                record.Sex = source.sex;
                record.Tel = source.tel;
                record.Empi = source.empi;
                record.ErhcCardNo = source.erhcCardNo;
                record.UpdatedAt = DateTime.Now;

                cardRepo.Update(record);

                erhcUow.Commit();
            }
        }

        private CardEntity QueryCardRegister(string name, string cardType, string cardValue)
        {
            var record = cardRepo.View.Where(p => p.IsClosed == false && p.IdCardType == cardType && p.IdCardValue == cardValue && p.Name == name)?.OrderByDescending(p => p.CreatedAt)?.FirstOrDefault();
            return record != null && record.Id != 0 ? record : null;
        }

        public void ReadHealthCard(ApiArgument<ErhcmemberApplyQueryArgument> arg, ApiResultEx<ErhcmemberApplyQueryResponse> result)
        {
            DoQueryRegisterService<ErhcmemberApplyQueryArgument, ErhcmemberApplyQueryResponse, ErhcPrv12002Body, ErhcPrv12002Result>(arg, result, proxyResult =>
            {
                var proxyReturnCode = -1;
                var isSuccessful = int.TryParse(proxyResult.body.result.return_code, out proxyReturnCode);

                //LogRecorder.MonitorTrace(JsonConvert.SerializeObject(proxyResult));

                if (isSuccessful && proxyReturnCode == 1)
                {
                    var s = proxyResult.body.msg;
                    result.Succeed(proxyReturnCode, proxyResult?.body?.result?.return_info, new ErhcmemberApplyQueryResponse
                    {
                        IsApply = string.IsNullOrEmpty(s.is_apply) ? "1" : s.is_apply,
                        IdCardNo = s.idcard_no,
                        Sex = s.sex,
                        Tel = s.tel,
                        Empi = s.empi,
                        ErhcCardNo = s.erhc_cardno
                    });

                    //ReadCard(arg, (result.Data.IsApply, s.idcard_no, s.sex, s.tel, s.empi, s.erhc_cardno));

                    if (s.is_apply == "1")
                    {
                        CreateCard(arg.Data.IdCardType, arg.Data.IdCardValue, (s.is_apply, null, null, s.empi, s.erhc_cardno, null, s.idcard_no, arg.Data.IdCardType, arg.Data.IdCardValue, null, null, arg.Data.Name, null, null, null, s.sex, s.tel, null), null, null, null);
                    }
                }
                else
                {
                    if (proxyReturnCode == -20010)
                    {
                        proxyReturnCode = 0;
                        result.Succeed(proxyReturnCode, proxyResult?.body?.result?.return_info, new ErhcmemberApplyQueryResponse
                        {
                            IsApply = "0",
                            IdCardNo = "",
                            Sex = "",
                            Tel = "",
                            Empi = "",
                            ErhcCardNo = ""
                        });
                    }
                    else
                    {
                        result.Failed(proxyReturnCode, proxyResult?.body?.result?.return_info);
                    }


                }
            }, () =>
            {
                var regRecord = QueryCardRegister(arg.Data.Name, arg.Data.IdCardType, arg.Data.IdCardValue);
                if (regRecord == null)
                {
                    return false;
                }
                else
                {
                    var (key, descOrName) = ResultCodes.Succeed.GetInfo();

                    result.Succeed(key, descOrName, new ErhcmemberApplyQueryResponse
                    {
                        IsApply = string.IsNullOrEmpty(regRecord.IsApply) ? "1" : regRecord.IsApply,
                        IdCardNo = regRecord.IdCardNo,
                        Sex = regRecord.Sex,
                        Tel = regRecord.Tel,
                        Empi = regRecord.Empi,
                        ErhcCardNo = regRecord.ErhcCardNo
                    });

                    return true;
                }
            });
        }

        private void DoService<TArg, TProxyBody, TProxyResult>(ApiArgument<TArg> arg, ApiResultEx result, Action<TProxyResult> resultHandler)
        {
            try
            {
                logger.SaveRequestLog(arg);

                ServiceHandler<TArg, TProxyBody, TProxyResult>(arg, resultHandler);

                logger.SaveResponseLog(result, arg.Header.RequestId);
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }
        }

        private void DeleteCard(ApiArgument<ErhcmemberCancelArgument> arg, ApiResultEx result)
        {
            var record = cardRepo.View.Where(p => p.IsClosed == false && p.IdCardType == arg.Data.IdCardType && p.IdCardValue == arg.Data.IdCardValue)?.OrderByDescending(p => p.CreatedAt)?.FirstOrDefault();
            if (record == null || record.Id == 0)
            {
                result.UnknownUser(string.Empty);
            }
            else
            {
                var r1 = cardExRepo.View.Where(p => p.ErhcCardId == record.Id);
                r1?.ToList().ForEach(p => cardExRepo.Delete(p));

                var r2 = cardFamilyRepo.View.Where(p => p.Empi == record.Empi);
                r2?.ToList().ForEach(p => cardFamilyRepo.Delete(p));

                cardRepo.Delete(record);

                erhcUow.Commit();
            }
        }

        public void DeleteHealthCard(ApiArgument<ErhcmemberCancelArgument> arg, ApiResultEx result)
        {
            DoService<ErhcmemberCancelArgument, ErhcPrv11003Body, ErhcPrv11003Result>(arg, result, proxyResult =>
            {
                var proxyReturnCode = -1;
                var isSuccessful = int.TryParse(proxyResult.body.result.return_code, out proxyReturnCode);

                if (isSuccessful && proxyReturnCode == 1)
                {
                    result.Succeed(proxyReturnCode, proxyResult?.body?.result?.return_info);

                    DeleteCard(arg, result);
                }
                else
                {
                    result.Failed(proxyReturnCode, proxyResult?.body?.result?.return_info);
                }
            });
        }

        private void UpdateCard(ApiArgument<ErhcmemberModifyArgument> arg, ApiResultEx<ErhcmemberModifyResponse> result, string empi, string erhcCardNo, string erhcEndDate)
        {
            try
            {
                var record = cardRepo.View.Where(p => p.IsClosed == false && p.IdCardType == arg.Data.IdCardType && p.IdCardValue == arg.Data.IdCardValue)?.OrderByDescending(p => p.CreatedAt)?.FirstOrDefault();
                if (record == null || record.Id == 0)
                {
                    //result.UnknownUser(string.Empty);
                    logger.Debug($"{nameof(UpdateCard)} => not found: {JsonConvert.SerializeObject(arg)}");
                }
                else
                {
                    record.Address = arg.Data.Address;
                    record.Citizenship = arg.Data.Citizenship;
                    record.Empi = empi;
                    record.ErhcCardNo = erhcCardNo;
                    record.ErhcEndDate = erhcEndDate;
                    //record.IdCardNo
                    record.IdCardType = arg.Data.IdCardType;
                    record.IdCardValue = arg.Data.IdCardValue;
                    //record.IssuerOrgCode
                    //record.IssuerOrgName
                    record.Name = arg.Data.Name;
                    record.Nationality = arg.Data.Nationality;
                    //record.QrCodeImageData
                    //record.QrCodeType
                    record.Sex = arg.Data.Sex;
                    record.Tel = arg.Data.Tel;
                    //record.Id
                    //record.IsApply
                    //record.IsClosed
                    //record.UserSign
                    //record.CreatedAt
                    record.UpdatedAt = DateTime.Now;

                    cardRepo.Update(record);

                    erhcUow.Commit();
                }
            }
            catch (Exception ex)
            {
                logger.Debug($"{nameof(UpdateCard)} => error: {ex.Message}: {JsonConvert.SerializeObject(arg)}");
            }
        }

        public void UpdateHealthCard(ApiArgument<ErhcmemberModifyArgument> arg, ApiResultEx<ErhcmemberModifyResponse> result)
        {
            DoService<ErhcmemberModifyArgument, ErhcmemberModifyResponse, ErhcPrv11002Body, ErhcPrv11002Result>(arg, result, proxyResult =>
            {
                var proxyReturnCode = -1;
                var isSuccessful = int.TryParse(proxyResult.body.result.return_code, out proxyReturnCode);

                if (isSuccessful && proxyReturnCode == 1)
                {
                    var s = proxyResult.body.msg;
                    result.Succeed(proxyReturnCode, proxyResult?.body?.result?.return_info, new ErhcmemberModifyResponse
                    {
                        EMPI = s.empi,
                        ErhcCardNo = s.erhc_cardno,
                        ErhcEndDateTime = Convert.ToDateTime(s.erhc_enddate)
                    });

                    UpdateCard(arg, result, s.empi, s.erhc_cardno, s.erhc_enddate);
                }
                else
                {
                    result.Failed(proxyReturnCode, proxyResult?.body?.result?.return_info);
                }
            });
        }

        public void QueryDynamicQrCode(ApiArgument<ErhcmemberQrCodeDynamicArgument> arg, ApiResultEx<ErhcmemberQrCodeDynamicResponse> result) =>
            result.Initialization(ResultCodes.AccessServiceFailedViaAppId, null, "");
        //rc.GetInstanceByErrorCode<ErhcmemberQrCodeDynamicArgument>(arg, code: ResultCodes.AccessServiceFailedViaAppId);

        private void UpdateCardWhenQueryStaticQrCode(ApiArgument<ErhcmemberQrCodeStaticArgument> arg, string empi, string erhcCardNo, string qrImageInfo)
        {
            var record = cardRepo.View.Where(p => p.IsClosed == false && p.IdCardType == arg.Data.IdcardType && p.IdCardValue == arg.Data.IdcardValue && p.Name == arg.Data.Name)?.OrderByDescending(p => p.CreatedAt)?.FirstOrDefault();
            if (record != null && record.Id != 0)
            {
                record.Empi = empi;
                record.ErhcCardNo = erhcCardNo;
                //record.QrCodeImageData = source.qrcode_imagedata;
                record.UpdatedAt = DateTime.Now;

                cardRepo.Update(record);

                var recordEx = cardExRepo.View.Where(p => p.ErhcCardId == record.Id)?.OrderByDescending(p => p.CreatedAt)?.FirstOrDefault();
                if (recordEx != null && recordEx.Id != 0)
                {
                    var addr = new[] { recordEx.AddrLv0, recordEx.AddrLv1, recordEx.AddrLv2, recordEx.AddrLv3, recordEx.AddrLv4, recordEx.AddrLv5 };
                    var regAddr = new[] { recordEx.DAddrLv0, recordEx.DAddrLv1, recordEx.DAddrLv2, recordEx.DAddrLv3, recordEx.DAddrLv4, recordEx.DAddrLv5 };
                    DoErhcCardExtendData(cardExRepo.Update, recordEx, addr, regAddr, 0, "1", qrImageInfo);
                }
                else
                {
                    DoErhcCardExtendData(cardExRepo.Insert, null, null, null, record.Id, "1", qrImageInfo);
                }

                erhcUow.Commit();
            }
        }

        public void QueryStaticQrCode(ApiArgument<ErhcmemberQrCodeStaticArgument> arg, ApiResultEx<ErhcmemberQrCodeStaticResponse> result)
        {
            DoService<ErhcmemberQrCodeStaticArgument, ErhcmemberQrCodeStaticResponse, ErhcPrv11004Body, ErhcPrv11004Result>(arg, result, proxyResult =>
            {
                var proxyReturnCode = -1;
                var isSuccessful = int.TryParse(proxyResult.body.result.return_code, out proxyReturnCode);

                if (isSuccessful && proxyReturnCode == 1)
                {
                    var s = proxyResult.body.msg;
                    result.Succeed(proxyReturnCode, proxyResult?.body?.result?.return_info, new ErhcmemberQrCodeStaticResponse
                    {
                        Empi = s.empi,
                        ErhcCardno = s.erhc_cardno,
                        QrcodeImagedata = s.qrcode_imagedata
                    });

                    UpdateCardWhenQueryStaticQrCode(arg, s.empi, s.erhc_cardno, s.qrcode_imagedata);
                }
                else
                {
                    result.Failed(proxyReturnCode, proxyResult?.body?.result?.return_info);
                }
            });
        }

        private void UpdateCardWehnQueryByHospital((string empi, string erhcCardNo, string name, string sex, string idCardNo, string idCardType, string idCardValue, string citizenship, string nationality, string tel, string address, string issuerOrgCode, string issuerOrgName, string erhcEndDate, string userSign) source)
        {
            var record = cardRepo.View.Where(p => p.IsClosed == false && p.IdCardType == source.idCardType && p.IdCardValue == source.idCardValue)?.OrderByDescending(p => p.CreatedAt)?.FirstOrDefault();
            if (record != null && record.Id != 0)
            {
                record.Empi = source.empi;
                record.ErhcCardNo = source.erhcCardNo;
                record.Name = source.name;
                record.Sex = source.sex;
                record.IdCardNo = source.idCardNo;
                record.IdCardType = source.idCardType;
                record.IdCardValue = source.idCardValue;
                record.Citizenship = source.citizenship;
                record.Nationality = source.nationality;
                record.Tel = source.tel;
                record.Address = source.address;
                record.IssuerOrgCode = source.issuerOrgCode;
                record.IssuerOrgName = source.issuerOrgName;
                record.ErhcEndDate = source.erhcEndDate;
                record.UserSign = source.userSign;
                record.UpdatedAt = DateTime.Now;

                cardRepo.Update(record);

                erhcUow.Commit();
            }
        }

        public void VerifyByHospital(ApiArgument<ErhcmemberVerifyHospitalArgument> arg, ApiResultEx<ErhcmemberVerifyResponse> result)
        {
            DoService<ErhcmemberVerifyHospitalArgument, ErhcmemberVerifyResponse, ErhcPrv12001Body, ErhcPrv12001Result>(arg, result, proxyResult =>
            {
                var proxyReturnCode = -1;
                var isSuccessful = int.TryParse(proxyResult.body.result.return_code, out proxyReturnCode);

                if (isSuccessful && proxyReturnCode == 1)
                {
                    var s = proxyResult.body.msg;
                    result.Succeed(proxyReturnCode, proxyResult?.body?.result?.return_info, new ErhcmemberVerifyResponse
                    {
                        Empi = s.empi,
                        ErhcCardno = s.erhc_cardno,
                        Name = s.name,
                        Sex = s.sex,
                        IdcardNo = s.idcard_no,
                        IdcardType = s.idcard_type,
                        IdcardValue = s.idcard_value,
                        Citizenship = s.citizenship,
                        Nationality = s.nationality,
                        Tel = s.tel,
                        Address = s.address,
                        IssuerOrgcode = s.issuer_orgcode,
                        IssuerOrgname = s.issuer_orgname,
                        ErhcEndDateTime = DateTime.Parse(s.erhc_enddate),
                        //UserSign = s.user_sign
                        UserSign = string.Empty
                    });

                    UpdateCardWehnQueryByHospital((s.empi, s.erhc_cardno, s.name, s.sex, s.idcard_no, s.idcard_type, s.idcard_value, s.citizenship, s.nationality, s.tel, s.address, s.issuer_orgcode, s.issuer_orgname, s.erhc_enddate, s.user_sign));

                    DoApiRequest<dynamic>(new
                    {
                        appId = arg.Header.AppId,
                        cardId = s.erhc_cardno,
                        appSource = 0,
                        depCode = arg.Data.DepCode,
                        depType = arg.Data.DepType,
                        s.empi,
                        idCardNo = s.idcard_no,
                        medType = arg.Data.MedType,
                        msCode = arg.Data.MedStepcode,
                        orgCode = s.issuer_orgcode,
                        orgName = s.issuer_orgname
                    }, "用卡分析", "ErhcCardUseCreateSvcUrl");
                }
                else
                {
                    result.Failed(proxyReturnCode, proxyResult?.body?.result?.return_info);
                }
            });
        }

        private void ServiceHandler<TProxyResult>(ApiArgument arg, Action<TProxyResult> resultHandler)
        {
            var header = Activator.CreateInstance(typeof(ErhcPrvHeader), arg.Header) as ErhcPrvHeader;
            ConvertHeaderCode(header);
            var headerXml = ConvertToXmlString(header);

            //var body = Activator.CreateInstance(typeof(TProxyBody), arg.Data);
            //var bodyXml = ConvertToXmlString(body);
            var bodyXml = string.Empty;

            var proxyJsonResult = DoProxyService(header, headerXml, bodyXml);

            var proxyResult = JsonConvert.DeserializeObject<TProxyResult>(proxyJsonResult);

            resultHandler(proxyResult);
        }

        private void DoService<TResult, TProxyResult>(ApiArgument arg, ApiResultEx<TResult> result, Action<TProxyResult> resultHandler) where TResult : class, new()
        {
            try
            {
                logger.SaveRequestLog(arg);

                ServiceHandler(arg, resultHandler);

                logger.SaveResponseLog(result, arg.Header.RequestId);
            }
            catch (ErhcRemoteException exErhc)
            {
                error.Execute(exErhc, result, ResultCodes.RemoteError);
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }
        }

        public void QueryServerTime(ApiArgument arg, ApiResultEx<HostTimeResponse> result)
        {
            DoService<HostTimeResponse, ErhcPrv10001Result>(arg, result, proxyResult =>
            {
                var proxyReturnCode = -1;
                var isSuccessful = int.TryParse(proxyResult.body.result.return_code, out proxyReturnCode);

                if (isSuccessful && proxyReturnCode == 1)
                {
                    var source = proxyResult.body.msg;
                    result.Succeed(proxyReturnCode, proxyResult?.body?.result?.return_info, new HostTimeResponse
                    {
                        ServerTime = DateTime.Parse(source.server_datetime)
                    });
                }
                else
                {
                    result.Failed(proxyReturnCode, proxyResult?.body?.result?.return_info);
                }
            });
        }

        public ApiResultEx<ErhcmemberApplyBySmallAppResponse> CreateHealthCardBySmallApp(ApiArgument<ErhcmemberApplyBySmallAppArgument> arg, ApiResultEx<ErhcmemberApplyBySmallAppResponse> result) => rc.GetInstanceByUnknownCode<ErhcmemberApplyBySmallAppResponse>(arg);
    }
}
