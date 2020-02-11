
using System.Globalization;
using WzHealthCard.Refactor.Api.Common;

namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;
    using WzHealthCard.Refactor.Api.Models.Refactor;
    using WzHealthCard.Refactor.Api.Repositories.Erhc;
    using WzHealthCard.Refactor.Api.UnitOfWorks;

    public class ErhcPubService : IErhcService
    {
        public int ServiceType => 2;

        private readonly ConfigManager config;
        private readonly IErrorHandler error;
        private ILogger logger;
        private readonly ErhcUnitOfWork erhcUow;
        private readonly CardRepository cardRepo;
        private readonly CardExtendRepository cardExRepo;
        private readonly CardFamilyRepository cardFamilyRepo;
        private readonly IErhcPubServiceProxy proxy;
        private readonly ISocialCardServiceProxyHandler scsProxy;
        private readonly ISmsHandler sms;
        private readonly IHttpClientFactory _httpClientFactory;
        public ErhcPubService(
            ConfigManager config,
            IErrorHandler error,
            ILogger logger,
            ErhcUnitOfWork erhcUow,
            CardRepository cardRepo,
            CardExtendRepository cardExRepo,
            CardFamilyRepository cardFamilyRepo,
            IErhcPubServiceProxy proxy,
            ISocialCardServiceProxyHandler scsProxy,
            ISmsHandler sms, IHttpClientFactory httpClientFactory)
        {
            this.config = config;
            this.error = error;
            this.logger = logger;
            this.erhcUow = erhcUow;
            this.cardRepo = cardRepo;
            this.cardExRepo = cardExRepo;
            this.cardFamilyRepo = cardFamilyRepo;
            this.proxy = proxy;
            this.scsProxy = scsProxy;
            this.sms = sms;
            _httpClientFactory = httpClientFactory;
        }

        private string DoProxyService(ErhcPubHeader header, List<KeyValuePair<string, string>> body)
        {
            var proxyJsonResult = string.Empty;
            switch (header.tradeCode)
            {
                case "30001":
                    proxyJsonResult = proxy.Do30001(header, body);
                    break;
                case "30002":
                    proxyJsonResult = proxy.Do30002(header, body);
                    break;
                case "30003":
                    proxyJsonResult = proxy.Do30003(header, body);
                    break;
                case "30004":
                    proxyJsonResult = proxy.Do30004(header, body);
                    break;
                case "30005":
                    proxyJsonResult = proxy.Do30005(header, body);
                    break;
                //case "31001":
                //    proxyJsonResult = proxy.Do31001(header, body);
                //    break;
                default:
                    break;
            }

            return proxyJsonResult;
        }

        private void ConvertHeaderCode(ErhcPubHeader header)
        {
            switch (header.tradeCode)
            {
                case "30001":
                    header.tradeCode = "30001";
                    break;
                case "30002":
                    header.tradeCode = "30002";
                    break;
                case "30003":
                    header.tradeCode = "30003";
                    break;
                case "30004":
                    header.tradeCode = "30004";
                    break;
                case "30005":
                    header.tradeCode = "30005";
                    break;
                //case "31001":
                //    header.tradeCode = "31001";
                //    break;
                default: throw new Exception($"不是有效的{nameof(header.tradeCode)}：{header.tradeCode}。");
            }
        }

        private void ServiceHandler<TArg, TProxyResult>(ApiArgument<TArg> arg, Func<TArg, List<KeyValuePair<string, string>>> bodyHandler, Action<TProxyResult> resultHandler)
        {
            var header = Activator.CreateInstance(typeof(ErhcPubHeader), arg.Header) as ErhcPubHeader;
            ConvertHeaderCode(header);

            var body = bodyHandler(arg.Data);

            var proxyJsonResult = DoProxyService(header, body);

            var proxyResult = JsonConvert.DeserializeObject<TProxyResult>(proxyJsonResult);

            resultHandler(proxyResult);
        }

        private void DoService<TArg, TResult, TProxyResult>(ApiArgument<TArg> arg, ApiResultEx<TResult> result, Func<TArg, List<KeyValuePair<string, string>>> bodyHandler, Action<TProxyResult> resultHandler)
        {
            try
            {
                logger.SaveRequestLog(arg);

                ServiceHandler(arg, bodyHandler, resultHandler);

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

        private DateTime ConvertLongToDateTime(long time)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return date.AddMilliseconds(time).ToLocalTime();
        }

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

            if (addr != null)
            {
                record.AddrLv0 = addr?.Length >= 1 ? addr[0] : string.Empty;
                record.AddrLv1 = addr?.Length >= 2 ? addr[1] : string.Empty;
                record.AddrLv2 = addr?.Length >= 3 ? addr[2] : string.Empty;
                record.AddrLv3 = addr?.Length >= 4 ? addr[3] : string.Empty;
                record.AddrLv4 = addr?.Length >= 5 ? addr[4] : string.Empty;
                record.AddrLv5 = addr?.Length >= 6 ? addr[5] : string.Empty;
            }

            if (regAddr != null)
            {
                record.DAddrLv0 = regAddr?.Length >= 1 ? regAddr[0] : string.Empty;
                record.DAddrLv1 = regAddr?.Length >= 2 ? regAddr[1] : string.Empty;
                record.DAddrLv2 = regAddr?.Length >= 3 ? regAddr[2] : string.Empty;
                record.DAddrLv3 = regAddr?.Length >= 4 ? regAddr[3] : string.Empty;
                record.DAddrLv4 = regAddr?.Length >= 5 ? regAddr[4] : string.Empty;
                record.DAddrLv5 = regAddr?.Length >= 6 ? regAddr[5] : string.Empty;
            }

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
            string smsUser,
            string[] exAddr,
            string[] exRegAddr)
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
                DoErhcCardExtendData(cardExRepo.Update, recordEx, exAddr, exRegAddr, 0, source.qrCodeType, source.qrCodeImageInfo);
            }
            else
            {
                DoErhcCardExtendData(cardExRepo.Insert, null, exAddr, exRegAddr, record.Id, source.qrCodeType, source.qrCodeImageInfo);
            }

            erhcUow.Commit();

            return record;
        }

        public void CreateHealthCard(ApiArgument<ErhcmemberApplyArgument> arg, ApiResultEx<ErhcmemberApplyResponse> result)
        {
            DoService<ErhcmemberApplyArgument, ErhcmemberApplyResponse, ErhcPub30001Result>(arg, result, body =>
            {
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("name", arg.Data.Name),
                    new KeyValuePair<string, string>("idCardType", arg.Data.IdCardType),
                    new KeyValuePair<string, string>("idCardValue", arg.Data.IdCardValue),
                    new KeyValuePair<string, string>("citizenship", arg.Data.Citizenship),
                    new KeyValuePair<string, string>("nationality", arg.Data.Nationality),
                    new KeyValuePair<string, string>("tel", arg.Data.Tel),
                    new KeyValuePair<string, string>("address", arg.Data.Address),
                    new KeyValuePair<string, string>("sex", arg.Data.Sex),
                    //new KeyValuePair<string, string>("birthday", arg.Data.Birthday.ToString("yyyy-MM-dd")),
                    // fix 20190826/birthday allow empty
                    new KeyValuePair<string, string>("birthday", arg.Data.Birthday),
                    new KeyValuePair<string, string>("birthPlace", arg.Data.BirthPlace),
                    new KeyValuePair<string, string>("domicile", arg.Data.Domicile),
                    new KeyValuePair<string, string>("appMode", arg.Data.AppMode),
                    new KeyValuePair<string, string>("terminalType", arg.Data.TerminalType)
                };
            }, proxyResult =>
            {
                if (proxyResult.code == 1)
                {
                    var s = proxyResult.data;

                    //Task.Factory.StartNew(() => IocHelper.Create<ISmsHandler>().SendMsg(s.tel, s.name));

                    result.Succeed(proxyResult.code, proxyResult.msg, new ErhcmemberApplyResponse
                    {
                        EMPI = s.empi,
                        ErhcCardNo = s.erhcCardNo,
                        Name = s.name,
                        Sex = s.sex,
                        //IdCardNo = source.idcard_no,
                        IdCardType = s.idCardType,
                        IdCardValue = s.idCardVaule,
                        Citizenship = s.citizenship,
                        Nationality = s.nationality,
                        Tel = s.tel,
                        Address = s.address,
                        IssuerOrgCode = s.issuerOrgCode,
                        IssuerOrgName = s.issuerOrgName,
                        ErhcEndDateTime = ConvertLongToDateTime(s.erhcEndDate),
                        QrCodeType = s.qrCodeType,
                        QrCodeImageInfo = s.qrCodeImageInfo,
                        QrCodeVaildDateTime = Convert.ToInt32(s.qrCodeVaildDate),
                        QrContent = s.qrContent
                    });

                    CreateCard(
                        arg.Data.IdCardType,
                        arg.Data.IdCardValue,
                        (null, s.address, s.citizenship, s.empi, s.erhcCardNo, ConvertLongToDateTime(s.erhcEndDate).ToString("yyyy-MM-dd"), string.Empty, s.idCardType, s.idCardVaule, $"{s.issuerOrgCode},{arg.Header.originAppId}", $"{s.issuerOrgName},{arg.Header.originalOrgName}", s.name, s.nationality, s.qrCodeImageInfo, s.qrCodeType, s.sex, s.tel, null),
                        sms.SendMsg,
                        arg.Data.Tel,
                        s.name,
                        null,
                        null);

                    //DoApiRequest<WZSocialCardService1105Result, dynamic>(new
                    DoApiRequest<dynamic>(new
                    {
                        appId = arg.Header.originAppId,
                        appMode = arg.Data.AppMode,
                        cardId = s.erhcCardNo,
                        appSource = 0,
                        s.empi
                    }, "建卡分析", "ErhcCardApplyCreateSvcUrl", (path, content) =>
                    {
                        HttpClient client=null;
                        using (client = _httpClientFactory.CreateClient(RemoteHttpNames.RemoteName))
                        {
                            try
                            {
                                return client.PostAsync(path, content).Result;
                            }
                            catch
                            {
                                client?.Dispose();
                            }
                            return null;
                        }
                    });

                    //scsProxy.Do1005((arg.Data.Birthday.ToString("yyyyMMdd"), arg.Data.Sex, arg.Data.BirthPlace, arg.Data.Domicile), result, (s.erhcCardNo, s.idCardType, s.idCardVaule, s.name, s.tel, s.empi, s.citizenship, s.nationality, s.address));
                    // fix 20190826/birthday allow empty

                    scsProxy.Do1005((arg.Data.Birthday.Replace("-", string.Empty), arg.Data.Sex, arg.Data.BirthPlace, arg.Data.Domicile), result, (s.erhcCardNo, s.idCardType, s.idCardVaule, s.name, s.tel, s.empi, s.citizenship, s.nationality, s.address));
                }
                else
                {
                    result.Failed(proxyResult.code, proxyResult.msg);
                }
            });
        }

        //private TResult DoApiRequest<TResult, TArg>(TArg request, string funCode, string apiUrlKey)
        private void DoApiRequest<TArg>(TArg request, string funCode, string apiUrlKey, Func<string, HttpContent, HttpResponseMessage> doApi)
        {
            //var client = HttpClientFactory.Create(sslHandler);

            logger.Debug($"{funCode}_args:{JsonConvert.SerializeObject(request)}");

            var host = config.GetAppSetting("ErhcBaseSvcUrl");
            var url = config.GetAppSetting(apiUrlKey);
            var path = Path.Combine(host, url);

            logger.Debug($"{funCode}_path:{path}");

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            //var response = client.PostAsync(path, content).Result;
            var response = doApi(path, content);

            logger.Debug($"{funCode}_res_code:{response.StatusCode}");

            response.EnsureSuccessStatusCode();
            var resJson = response.Content.ReadAsStringAsync().Result;

            logger.Debug($"{funCode}_res_content:{resJson}");

            //return JsonConvert.DeserializeObject<TResult>(resJson);
        }

        private void DoQueryRegisterService<TArg, TResult, TProxyResult>(ApiArgument<TArg> arg, ApiResultEx<TResult> result, Func<TArg, List<KeyValuePair<string, string>>> bodyHandler, Action<TProxyResult> resultHandler, Func<bool> queryRegisterHandler)
        {
            try
            {
                logger.SaveRequestLog(arg);

                var isRegistered = queryRegisterHandler();
                if (!isRegistered)
                {
                    ServiceHandler(arg, bodyHandler, resultHandler);
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
            DoQueryRegisterService<ErhcmemberApplyQueryArgument, ErhcmemberApplyQueryResponse, ErhcPub30005Result>(arg, result, body =>
            {
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("idCardType", arg.Data.IdCardType),
                    new KeyValuePair<string, string>("idCardValue", arg.Data.IdCardValue),
                    new KeyValuePair<string, string>("name", arg.Data.Name)
                };
            }, proxyResult =>
            {
                if (proxyResult.code == 1)
                {
                    var s = proxyResult.data;
                    result.Succeed(proxyResult.code, proxyResult.msg, new ErhcmemberApplyQueryResponse
                    {
                        IsApply = s.isApply,
                        IdCardNo = s.idCardNo,
                        Sex = s.sex,
                        Tel = s.tel,
                        Empi = s.empi,
                        ErhcCardNo = s.erhcCardNo
                    });

                    //ReadCard(arg, (s.isApply, s.idCardNo, s.sex, s.tel, s.empi, s.erhcCardNo));

                    if (s.isApply == "1")
                    {
                        CreateCard(arg.Data.IdCardType, arg.Data.IdCardValue, (s.isApply, null, null, s.empi, s.erhcCardNo, null, s.idCardNo, arg.Data.IdCardType, arg.Data.IdCardValue, null, null, arg.Data.Name, null, null, null, s.sex, s.tel, null), null, null, null, null, null);
                    }
                }
                else
                {
                    result.Failed(proxyResult.code, proxyResult.msg);
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

        private void DoService<TArg, TProxyResult>(ApiArgument<TArg> arg, ApiResultEx result, Func<TArg, List<KeyValuePair<string, string>>> bodyHandler, Action<TProxyResult> resultHandler)
        {
            try
            {
                logger.SaveRequestLog(arg);

                ServiceHandler(arg, bodyHandler, resultHandler);

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

                erhcUow.Commit();
            }
        }

        public void DeleteHealthCard(ApiArgument<ErhcmemberCancelArgument> arg, ApiResultEx result)
        {
            DoService<ErhcmemberCancelArgument, ErhcPub30003Result>(arg, result, body =>
            {
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("erhcCardNo", arg.Data.ErhcCardNO),
                    new KeyValuePair<string, string>("appMode", arg.Data.AppMode),
                    new KeyValuePair<string, string>("terminalType", arg.Data.TerminalType)
                };
            }, proxyResult =>
            {
                if (proxyResult.code == 1)
                {
                    result.Succeed(proxyResult.code, proxyResult.msg);

                    DeleteCard(arg, result);
                }
                else
                {
                    result.Failed(proxyResult.code, proxyResult.msg);
                }
            });
        }

        public void UpdateHealthCard(ApiArgument<ErhcmemberModifyArgument> arg, ApiResultEx<ErhcmemberModifyResponse> result)
        {
            DoService<ErhcmemberModifyArgument, ErhcmemberModifyResponse, ErhcPub30002Result>(arg, result, body =>
            {
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("erhcCardNo", arg.Data.ErhcCardNo),
                    new KeyValuePair<string, string>("name", arg.Data.Name),
                    new KeyValuePair<string, string>("idCardType", arg.Data.IdCardType),
                    new KeyValuePair<string, string>("idCardValue", arg.Data.IdCardValue),
                    new KeyValuePair<string, string>("citizenship", arg.Data.Citizenship),
                    new KeyValuePair<string, string>("nationality", arg.Data.Nationality),
                    new KeyValuePair<string, string>("tel", arg.Data.Tel),
                    new KeyValuePair<string, string>("address", arg.Data.Address),
                    new KeyValuePair<string, string>("sex", arg.Data.Sex),
                    new KeyValuePair<string, string>("birthday", arg.Data.Birthday.ToString("yyyy-MM-dd")),
                    new KeyValuePair<string, string>("birthPlace", arg.Data.BirthPlace),
                    new KeyValuePair<string, string>("domicile", arg.Data.Domicile),
                    new KeyValuePair<string, string>("appMode", arg.Data.AppMode),
                    new KeyValuePair<string, string>("terminalType", arg.Data.TerminalType)
                };
            }, proxyResult =>
            {
                if (proxyResult.code == 1)
                {
                    var s = proxyResult.data;
                    result.Succeed(proxyResult.code, proxyResult.msg, new ErhcmemberModifyResponse
                    {
                        EMPI = s.empi,
                        ErhcCardNo = s.erhcCardNo,
                        ErhcEndDateTime = ConvertLongToDateTime(s.erhcEndDate)
                    });

                    // TODO
                    // 此处调用erhc-base的更新，如果主数据不存在，会导致引用的id为一个默认值
                    DoApiRequest<dynamic>(new
                    {
                        address = arg.Data.Address,
                        citizenship = arg.Data.Citizenship,
                        cardNo = s.erhcCardNo,
                        s.empi,
                        endDate = ConvertLongToDateTime(s.erhcEndDate).ToString("yyyy-MM-dd"),
                        idCardType = arg.Data.IdCardType,
                        idCardValue = arg.Data.IdCardValue,
                        name = arg.Data.Name,
                        nationality = arg.Data.Nationality,
                        sex = arg.Data.Sex,
                        tel = arg.Data.Tel,
                        extend = new
                        {
                            cardId = arg.Data.CardRefId,
                            addr = arg.Data.ExAddr,
                            dAddr = arg.Data.ExRegAddr
                        }
                    }, "同步电子健康卡", "ErhcCardUpdateSvcUrl", (path, content) =>
                    {
                        HttpClient client = null;
                        using (client = _httpClientFactory.CreateClient(RemoteHttpNames.RemoteName))
                        {
                            try
                            {
                                return client.PutAsync(path, content).Result;
                            }
                            finally
                            {
                                client?.Dispose();
                            }
                        }
                    });

                    scsProxy.Do1005((arg.Data.Birthday.ToString("yyyyMMdd").Replace("-", string.Empty), arg.Data.Sex, arg.Data.BirthPlace, arg.Data.Domicile), result, (s.erhcCardNo, arg.Data.IdCardType, arg.Data.IdCardValue, arg.Data.Name, arg.Data.Tel, s.empi, arg.Data.Citizenship, arg.Data.Nationality, arg.Data.Address));
                }
                else
                {
                    result.Failed(proxyResult.code, proxyResult.msg);
                }
            });
        }

        private void UpdateCardWhenQueryDynamicQrCode(ApiArgument<ErhcmemberQrCodeDynamicArgument> arg, string empi, string erhcCardNo)
        {
            var record = cardRepo.View.Where(p => p.IsClosed == false && p.ErhcCardNo == arg.Data.ErhcCardNo)?.OrderByDescending(p => p.CreatedAt)?.FirstOrDefault();
            if (record != null && record.Id != 0)
            {
                //record.IsApply = source.isApply;
                //record.IdCardNo = source.idCardNo;
                //record.Sex = source.sex;
                //record.Tel = source.tel;

                record.Empi = empi;
                record.ErhcCardNo = erhcCardNo;
                //record.QrCodeImageData = source.qrCodeImageInfo;
                //record.qrcodev
                record.UpdatedAt = DateTime.Now;

                cardRepo.Update(record);

                erhcUow.Commit();
            }
        }

        public void QueryDynamicQrCode(ApiArgument<ErhcmemberQrCodeDynamicArgument> arg, ApiResultEx<ErhcmemberQrCodeDynamicResponse> result)
        {
            DoService<ErhcmemberQrCodeDynamicArgument, ErhcmemberQrCodeDynamicResponse, ErhcPub30004Result>(arg, result, body =>
            {
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("erhcCardNo", arg.Data.ErhcCardNo),
                    new KeyValuePair<string, string>("appMode", arg.Data.AppMode),
                    new KeyValuePair<string, string>("terminalType", arg.Data.TerminalType)
                };
            }, proxyResult =>
            {
                if (proxyResult.code == 1)
                {
                    var s = proxyResult.data;
                    result.Succeed(proxyResult.code, proxyResult.msg, new ErhcmemberQrCodeDynamicResponse
                    {
                        EMPI = s.empi,
                        ErhcCardNo = s.erhcCardNo,
                        QrCodeImageInfo = s.qrCodeImageInfo,
                        QrCodeVaildDateTime = Convert.ToInt32(s.qrCodeVaildDate)
                    });

                    UpdateCardWhenQueryDynamicQrCode(arg, s.empi, s.erhcCardNo);
                }
                else
                {
                    result.Failed(proxyResult.code, proxyResult.msg);
                }
            });
        }

        public void QueryStaticQrCode(ApiArgument<ErhcmemberQrCodeStaticArgument> arg, ApiResultEx<ErhcmemberQrCodeStaticResponse> result) { }

        public void VerifyByHospital(ApiArgument<ErhcmemberVerifyHospitalArgument> arg, ApiResultEx<ErhcmemberVerifyResponse> result) { }

        public void QueryServerTime(ApiArgument arg, ApiResultEx<HostTimeResponse> result) { }

        public ApiResultEx<ErhcmemberApplyBySmallAppResponse> CreateHealthCardBySmallApp(ApiArgument<ErhcmemberApplyBySmallAppArgument> arg, ApiResultEx<ErhcmemberApplyBySmallAppResponse> result)
        {
            DoService<ErhcmemberApplyBySmallAppArgument, ErhcmemberApplyBySmallAppResponse, ErhcPub30001Result>(arg, result, body =>
            {
                return new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("name", arg.Data.Name),
                    new KeyValuePair<string, string>("idCardType", arg.Data.IdCardType),
                    new KeyValuePair<string, string>("idCardValue", arg.Data.IdCardValue),
                    new KeyValuePair<string, string>("citizenship", arg.Data.Citizenship),
                    new KeyValuePair<string, string>("nationality", arg.Data.Nationality),
                    new KeyValuePair<string, string>("tel", arg.Data.Tel),
                    new KeyValuePair<string, string>("address", arg.Data.Address),
                    new KeyValuePair<string, string>("sex", arg.Data.Sex),
                    //new KeyValuePair<string, string>("birthday", arg.Data.Birthday.ToString("yyyy-MM-dd")),
                    // fix 20190826/birthday allow empty
                    new KeyValuePair<string, string>("birthday", arg.Data.Birthday),
                    new KeyValuePair<string, string>("birthPlace", arg.Data.BirthPlace),
                    new KeyValuePair<string, string>("domicile", arg.Data.Domicile),
                    new KeyValuePair<string, string>("appMode", arg.Data.AppMode),
                    new KeyValuePair<string, string>("terminalType", arg.Data.TerminalType)
                };
            }, proxyResult =>
            {
                if (proxyResult.code == 1)
                {
                    var s = proxyResult.data;

                    //Task.Factory.StartNew(() => IocHelper.Create<ISmsHandler>().SendMsg(s.tel, s.name));

                    result.Succeed(proxyResult.code, proxyResult.msg, new ErhcmemberApplyBySmallAppResponse
                    {
                        EMPI = s.empi,
                        ErhcCardNo = s.erhcCardNo,
                        Name = s.name,
                        Sex = s.sex,
                        //IdCardNo = source.idcard_no,
                        IdCardType = s.idCardType,
                        IdCardValue = s.idCardVaule,
                        Citizenship = s.citizenship,
                        Nationality = s.nationality,
                        Tel = s.tel,
                        Address = s.address,
                        IssuerOrgCode = s.issuerOrgCode,
                        IssuerOrgName = s.issuerOrgName,
                        ErhcEndDateTime = ConvertLongToDateTime(s.erhcEndDate),
                        QrCodeType = s.qrCodeType,
                        QrCodeImageInfo = s.qrCodeImageInfo,
                        QrCodeVaildDateTime = Convert.ToInt32(s.qrCodeVaildDate),
                        QrContent = s.qrContent
                    });

                    var record = CreateCard(arg.Data.IdCardType, arg.Data.IdCardValue, (null, s.address, s.citizenship, s.empi, s.erhcCardNo, ConvertLongToDateTime(s.erhcEndDate).ToString("yyyy-MM-dd"), string.Empty, s.idCardType, s.idCardVaule, $"{s.issuerOrgCode},{arg.Header.originAppId}", $"{s.issuerOrgName},{arg.Header.originalOrgName}", s.name, s.nationality, s.qrCodeImageInfo, s.qrCodeType, s.sex, s.tel, null), sms.SendMsg, arg.Data.Tel, s.name, arg.Data.ExAddr, arg.Data.ExRegAddr);

                    DoApiRequest<dynamic>(new
                    {
                        appId = arg.Header.originAppId,
                        appMode = arg.Data.AppMode,
                        cardId = s.erhcCardNo,
                        appSource = 0,
                        s.empi
                    }, "建卡分析", "ErhcCardApplyCreateSvcUrl", (path, content) =>
                    {
                        HttpClient client = null;
                        using (client = _httpClientFactory.CreateClient(RemoteHttpNames.RemoteName))
                        {
                            try
                            {
                           
                                return client.PostAsync(path, content).Result;
                            }
                            finally
                            {
                                client?.Dispose();
                            }
                        }
                    });

                    //scsProxy.Do1005((arg.Data.Birthday.ToString("yyyyMMdd"), arg.Data.Sex, arg.Data.BirthPlace, arg.Data.Domicile), result, (s.erhcCardNo, s.idCardType, s.idCardVaule, s.name, s.tel, s.empi, s.citizenship, s.nationality, s.address));
                    // fix 20190826/birthday allow empty
                    scsProxy.Do1005((arg.Data.Birthday.Replace("-", string.Empty), arg.Data.Sex, arg.Data.BirthPlace, arg.Data.Domicile), result, (s.erhcCardNo, s.idCardType, s.idCardVaule, s.name, s.tel, s.empi, s.citizenship, s.nationality, s.address));
                }
                else
                {
                    result.Failed(proxyResult.code, proxyResult.msg);
                }
            });

            return result;
        }
    }
}
