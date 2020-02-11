
namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;
    using WzHealthCard.Refactor.Api.Extensions;
    using WzHealthCard.Refactor.Api.Models.Refactor;
    using WzHealthCard.Refactor.Api.Repositories.Erhc;
    using WzHealthCard.Refactor.Api.Repositories.ErhcManage;
    using WzHealthCard.Refactor.Api.UnitOfWorks;

    public interface IHealthCardService
    {
        /// <summary>
        ///     电子健康卡申请
        /// </summary>
        /// <remarks>
        ///     根据居民实名身份信息申请开通电子健康卡，申请成功后，可直接将电子健康卡二维码显示在移动智能终端设备。本交易仅返回动态二维码。
        /// 对于已经存在注销状态的电子健康卡时，将做注销恢复处理。
        /// 当居民已经申请过电子健康卡而重复申请时，本交易将会把该居民已申请成功的电子健康卡信息直接返回，不再复注册。
        /// </remarks>
        /// <param name="arg">ErhcmemberApplyArgument</param>
        /// <returns>ErhcmemberApplyResponse</returns>
        ApiResultEx<ErhcmemberApplyResponse> ErhcmemberApply(ApiArgument<ErhcmemberApplyArgument> arg);

        /// <summary>
        ///     电子健康卡注册查询
        /// </summary>
        /// <remarks>
        ///     根据居民证件类型、证件号码查询是否已经存在电子居民健康卡注册记录。已注册时，返回该居民相应的电子健康卡注册基本信息
        /// </remarks>
        /// <param name="arg">ErhcmemberApplyQueryArgument</param>
        /// <returns>ErhcmemberApplyQueryResponse</returns>
        ApiResultEx<ErhcmemberApplyQueryResponse> ErhcmemberApplyQuery(ApiArgument<ErhcmemberApplyQueryArgument> arg);

        /// <summary>
        ///     电子健康卡注销
        /// </summary>
        /// <remarks>
        ///     用于已申请成功的电子健康卡进行注销停用，业务应用时需谨慎。
        /// </remarks>
        /// <param name="arg">ErhcmemberCancelArgument</param>
        /// <returns>操作结果</returns>
        ApiResultEx ErhcmemberCancel(ApiArgument<ErhcmemberCancelArgument> arg);

        /// <summary>
        ///     电子健康卡信息更新
        /// </summary>
        /// <remarks>
        ///     电子健康卡信息更新主要用于对居民个人基本信息的更新。
        /// </remarks>
        /// <param name="arg">ErhcmemberModifyArgument</param>
        /// <returns>ErhcmemberModifyResponse</returns>
        ApiResultEx<ErhcmemberModifyResponse> ErhcmemberModify(ApiArgument<ErhcmemberModifyArgument> arg);

        /// <summary>
        ///     电子健康卡动态二维码获取
        /// </summary>
        /// <remarks>
        ///     用于居民电子健康卡动态二维码获取，一般用于动态二维码超过有效期后自动刷新或者居民手工点击按钮后主动刷新二维码
        /// </remarks>
        /// <param name="arg">ErhcmemberQrCodeDynamicArgument</param>
        /// <returns>ErhcmemberQrCodeDynamicResponse</returns>
        ApiResultEx<ErhcmemberQrCodeDynamicResponse> ErhcmemberQrCodeDynamic(ApiArgument<ErhcmemberQrCodeDynamicArgument> arg);

        /// <summary>
        ///     电子健康卡静态二维码下载
        /// </summary>
        /// <remarks>
        ///     用于居民电子健康卡静态二维码下载打印，一般用于静态二维码标签补打印
        /// </remarks>
        /// <param name="arg">ErhcmemberQrCodeStaticArgument</param>
        /// <returns>ErhcmemberQrCodeStaticResponse</returns>
        ApiResultEx<ErhcmemberQrCodeStaticResponse> ErhcmemberQrCodeStatic(ApiArgument<ErhcmemberQrCodeStaticArgument> arg);

        /// <summary>
        ///     电子健康卡身份验证（医院）
        /// </summary>
        /// <remarks>
        ///     电子健康卡二维码身份验证包括静态二维码和动态二维码的身份验证，  电子健康卡二维码通过扫码设备读取内容后，将该二维码内容发送到服务平台验证，验证通过时，则一并返回个人基本信息。
        /// </remarks>
        /// <param name="arg">ErhcmemberVerifyHospitalArgument</param>
        /// <returns>ErhcmemberVerifyResponse</returns>
        ApiResultEx<ErhcmemberVerifyResponse> ErhcmemberVerifyHospital(ApiArgument<ErhcmemberVerifyHospitalArgument> arg);

        /// <summary>
        ///     取中心服务器时间
        /// </summary>
        /// <remarks>
        ///     获取中心服务平台系统时间，验证医院本地服务器时间与中心服务平台时差
        /// </remarks>
        /// <param name="arg">标准参数</param>
        /// <returns>HostTimeResponse</returns>
        ApiResultEx<HostTimeResponse> HostTime(ApiArgument arg);

        /// <summary>
        /// 小程序信息查询
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        ApiResultEx<ErhcmemberQueryInfoResponse> ErhcmemberQueryInfo(ApiArgument<ErhcmemberApplyQueryArgument> arg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        ApiResultEx<ErhcmemberQueryByPhoneResponse> ErhcmemberQueryByPhone(ApiArgument<ErhcmemberQueryByPhoneArgument> arg);

        ApiResultEx<ErhcmemberApplyBySmallAppResponse> CreateHealthCardBySmallApp(ApiArgument<ErhcmemberApplyBySmallAppArgument> arg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        ApiResultEx<ErhcmemberFamilyResponse> ErhcmemberFamilyCreate(ApiArgument<ErhcmemberFamilyCreateArgument> arg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        ApiResultEx<ErhcmemberFamilyReadResponse> ErhcmemberFamilyRead(ApiArgument<ErhcmemberFamilyReadArgument> arg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        ApiResultEx<ErhcmemberFamilyResponse> ErhcmemberFamilyUpdate(ApiArgument<ErhcmemberFamilyUpdateArgument> arg);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        ApiResultEx<ErhcmemberFamilyResponse> ErhcmemberFamilyDelete(ApiArgument<ErhcmemberFamilyDeleteArgument> arg);

        ApiResultEx<ErhcmemberFamilyResponse> ErhcmemberAddressBySmallApp(ApiArgument<ErhcmemberAddressBySmallAppArgument> arg);
    }

    public class HealthCardServiceLogical : IHealthCardService
    {
        private readonly ConfigManager config;
        private readonly ILogger logger;
        private readonly ResultCodeHandler rc;
        private readonly ErhcUnitOfWork erhcUow;
        private readonly CardRepository cardRepo;
        private readonly CardExtendRepository cardExRepo;
        private readonly CardFamilyRepository cardFmRepo;
        private readonly AppInfoRepository appInfoRepo;
        private readonly IEnumerable<IErhcService> erhcServces;
        private readonly IErhcService erhcPrvService;
        private readonly ISocialCardServiceProxyHandler scsProxy;

        public HealthCardServiceLogical(
            ConfigManager config,
            ILogger logger,
            ResultCodeHandler rc,
            ErhcUnitOfWork erhcUow,
            CardRepository cardRepo,
            CardExtendRepository cardExRepo,
            CardFamilyRepository cardFmRepo,
            AppInfoRepository appInfoRepo,
            IEnumerable<IErhcService> erhcServces,
            ISocialCardServiceProxyHandler scsProxy)
        {
            this.config = config;
            this.logger = logger;
            this.rc = rc;
            this.erhcUow = erhcUow;
            this.cardRepo = cardRepo;
            this.cardExRepo = cardExRepo;
            this.cardFmRepo = cardFmRepo;
            this.appInfoRepo = appInfoRepo;
            this.erhcServces = erhcServces;
            this.scsProxy = scsProxy;

            erhcPrvService = erhcServces?.FirstOrDefault(p => p.ServiceType == 1);
        }

        private IErhcService GetClassifyByAppId<TArg>(string appId, ApiArgument<TArg> arg)
        {
            arg.Header.originAppId = appId;

            var pubDataSources = config.GetAppSetting("ErhcPubDataSources");
            var enableErhcServiceSwitchSetting = config.GetAppSetting("EnableErhcServiceSwitch");
            bool.TryParse(enableErhcServiceSwitchSetting, out bool isEnable);

            logger.Debug($"enableDatabaseAppIdSwitch:{isEnable}");

            if (isEnable)
            {
                var classifyType = ClassifyType.None;
                var sAppId = string.Empty;

                var record = appInfoRepo.View.FirstOrDefault(p => p.app_key == appId);

                logger.Debug($"erhc record:{record.GetJsonString()}");

                if (record == null || record.id == 0)
                {
                    return null;
                }

                classifyType = (ClassifyType)record.Classify;
                sAppId = record.sapp_id;

                arg.Header.originalOrgName = record.full_name;

                switch (classifyType)
                {
                    case ClassifyType.Hospital: return erhcServces.FirstOrDefault(p => p.ServiceType == 1);
                    case ClassifyType.App:
                        arg.Header.AppId = sAppId;
                        arg.Header.DataSources = pubDataSources;
                        return erhcServces.FirstOrDefault(p => p.ServiceType == 2);
                    case ClassifyType.None:
                    default: return null;
                }
            }
            else
            {
                switch (config.GetAppSetting("ErhcServiceMode"))
                {
                    case "1":
                        logger.Debug($"erhc service ver:{1.3}");
                        return erhcServces.FirstOrDefault(p => p.ServiceType == 1);
                    case "2":
                        logger.Debug($"erhc service ver:{1.2}");
                        return erhcServces.FirstOrDefault(p => p.ServiceType == 2);
                    default: return null;
                }
            }
        }

        public ApiResultEx<ErhcmemberApplyResponse> ErhcmemberApply(ApiArgument<ErhcmemberApplyArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberApplyResponse>(arg);

            if (!arg.Validate(out var message))
                return result.Error(ErrorCode.LogicalError, message);

            var erhc = GetClassifyByAppId(arg.Header.AppId, arg);
            if (erhc != null)
            {
                erhc.CreateHealthCard(arg, result);
            }
            else
            {
                result.AccessServiceFailedViaAppId(string.Empty);
            }

            return result;
        }

        public ApiResultEx<ErhcmemberApplyQueryResponse> ErhcmemberApplyQuery(ApiArgument<ErhcmemberApplyQueryArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberApplyQueryResponse>(arg);
            if (!arg.Validate(out var message))
                return result.Error(ErrorCode.LogicalError, message);

            var erhc = GetClassifyByAppId(arg.Header.AppId, arg);
            if (erhc != null)
            {
                erhc.ReadHealthCard(arg, result);
            }
            else
            {
                result.AccessServiceFailedViaAppId(string.Empty);
            }

            return result;
        }

        public ApiResultEx ErhcmemberCancel(ApiArgument<ErhcmemberCancelArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode(arg);
            if (!arg.Validate(out var message))
                return result.Error(ErrorCode.LogicalError, message);

            var erhc = GetClassifyByAppId(arg.Header.AppId, arg);
            if (erhc != null)
            {
                erhc.DeleteHealthCard(arg, result);
            }
            else
            {
                result.AccessServiceFailedViaAppId(string.Empty);
            }

            return result;
        }

        public ApiResultEx<ErhcmemberModifyResponse> ErhcmemberModify(ApiArgument<ErhcmemberModifyArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberModifyResponse>(arg);
            if (!arg.Validate(out var message))
                return result.Error(ErrorCode.LogicalError, message);

            var erhc = GetClassifyByAppId(arg.Header.AppId, arg);
            if (erhc != null)
            {
                erhc.UpdateHealthCard(arg, result);
            }
            else
            {
                result.AccessServiceFailedViaAppId(string.Empty);
            }

            return result;
        }

        public ApiResultEx<ErhcmemberQrCodeDynamicResponse> ErhcmemberQrCodeDynamic(ApiArgument<ErhcmemberQrCodeDynamicArgument> arg)
        {
            //var result = new ApiResultEx <ErhcmemberQrCodeDynamicResponse>(arg);
            var result = rc.GetInstanceByUnknownCode<ErhcmemberQrCodeDynamicResponse>(arg);
            if (!arg.Validate(out var message))
                return result.Error(ErrorCode.LogicalError, message);



            if (arg.Data.QrCodeType == "2")
            {
                var erhc = GetClassifyByAppId(arg.Header.AppId, arg);
                if (erhc != null)
                {
                    erhc.QueryDynamicQrCode(arg, result);
                }
                else
                {
                    result.AccessServiceFailedViaAppId(string.Empty);
                }
            }
            else if (arg.Data.QrCodeType == "1")
            {
                scsProxy.Do1105((arg.Data.ErhcCardNo, arg.Data.EMPI, arg.Data.IdCardType, arg.Data.IdCardValue), result);
            }

            return result;
        }

        public ApiResultEx<ErhcmemberQrCodeStaticResponse> ErhcmemberQrCodeStatic(ApiArgument<ErhcmemberQrCodeStaticArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberQrCodeStaticResponse>(arg);
            if (!arg.Validate(out var message))
                return result.Error(ErrorCode.LogicalError, message);

            erhcPrvService.QueryStaticQrCode(arg, result);
            return result;
        }

        public ApiResultEx<ErhcmemberVerifyResponse> ErhcmemberVerifyHospital(ApiArgument<ErhcmemberVerifyHospitalArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberVerifyResponse>(arg);
            if (!arg.Validate(out var message))
                return result.Error(ErrorCode.LogicalError, message);

            erhcPrvService.VerifyByHospital(arg, result);
            return result;
        }

        public ApiResultEx<HostTimeResponse> HostTime(ApiArgument arg)
        {
            var result = rc.GetInstanceByUnknownCode<HostTimeResponse>(arg);
            if (!arg.Validate(out var message))
                return result.Error(ErrorCode.LogicalError, message);

            erhcPrvService.QueryServerTime(arg, result);
            return result;
        }

        public ApiResultEx<ErhcmemberQueryInfoResponse> ErhcmemberQueryInfo(ApiArgument<ErhcmemberApplyQueryArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberQueryInfoResponse>(arg);
            //if (!arg.Validate(out var message))
            //    return result.Error(ErrorCode.LogicalError, message);

            //var dal = new ErhcCardDataAccess();
            //var extend = new ErhcCardExtendDataAccess();
            var record = cardRepo.View.FirstOrDefault(p => p.IsClosed == false && p.Name == arg.Data.Name
                                         && p.IdCardType == arg.Data.IdCardType
                                         && p.IdCardValue == arg.Data.IdCardValue);
            if (record != null)
            {
                var exist = cardExRepo.View.FirstOrDefault(p => p.ErhcCardId == record.Id);
                if (exist != null)
                {
                    result.Succeed(string.Empty, new ErhcmemberQueryInfoResponse
                    {
                        EMPI = record.Empi,
                        ErhcCardNo = record.ErhcCardNo,
                        IdCardNo = record.IdCardNo,
                        Address = record.Address,
                        Nationality = record.Nationality,
                        Name = record.Name,
                        Sex = record.Sex,
                        IdCardValue = record.IdCardValue,
                        IdCardType = record.IdCardType,
                        ExAddr = new string[] { exist.AddrLv0, exist.AddrLv1, exist.AddrLv2, exist.AddrLv3, exist.AddrLv4, exist.AddrLv5 },
                        ExRegAddr = new string[] { exist.DAddrLv0, exist.DAddrLv1, exist.DAddrLv2, exist.DAddrLv3, exist.DAddrLv4, exist.DAddrLv5 },
                        Id = record.Id,
                        Tel = record.Tel
                    });
                    return result;
                }
            }
            result.Succeed(string.Empty, null);
            return result;
        }

        public ApiResultEx<ErhcmemberQueryByPhoneResponse> ErhcmemberQueryByPhone(ApiArgument<ErhcmemberQueryByPhoneArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberQueryByPhoneResponse>(arg);
            if (!arg.Validate(out var message))
                return result.Error(ErrorCode.LogicalError, message);

            var records = cardRepo.View.Where(p => p.IsClosed == false && p.Tel == arg.Data.Phone).OrderByDescending(p => p.CreatedAt);
            if (records != null && records.Count() > 0)
            {
                result.Succeed(string.Empty, new ErhcmemberQueryByPhoneResponse
                {
                    Cards = records.Select(p => new ErhcmemberQrCodeStaticResponse
                    {
                        Empi = p.Empi,
                        ErhcCardno = p.ErhcCardNo,
                        QrcodeImagedata = p.QrCodeImageData
                    })?.ToArray()
                });
            }
            else
            {
                result.Succeed(string.Empty, null);
            }

            return result;
        }

        public ApiResultEx<ErhcmemberApplyBySmallAppResponse> CreateHealthCardBySmallApp(ApiArgument<ErhcmemberApplyBySmallAppArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberApplyBySmallAppResponse>(arg);
            var erhc = GetClassifyByAppId(arg.Header.AppId, arg);
            if (erhc != null)
            {
                erhc.CreateHealthCardBySmallApp(arg, result);
            }
            else
            {
                result.AccessServiceFailedViaAppId(string.Empty);
            }

            return result;
        }

        public ApiResultEx<ErhcmemberFamilyResponse> ErhcmemberFamilyCreate(ApiArgument<ErhcmemberFamilyCreateArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberFamilyResponse>(arg);
            //if (!arg.Validate(out var message))
            //    return result.Error(ErrorCode.LogicalError, message);

            var record = cardRepo.View.Where(p => p.IsClosed == false && p.Empi == arg.Data.Empi)?.OrderByDescending(p => p.CreatedAt)?.FirstOrDefault();
            if (record == null || record.Id == 0)
            {
                result.UnknownUser(string.Empty);
            }
            else
            {
                var recordEx = cardFmRepo.View.Where(p => p.IsDeleted == false && p.Empi == arg.Data.Empi && p.IdCardType == arg.Data.IdCardType && p.IdCardValue == arg.Data.IdCardValue)?.OrderByDescending(p => p.CreatedAt)?.FirstOrDefault();
                if (recordEx != null && recordEx.Id != 0)
                {
                    result.ExistedUser(string.Empty);
                }
                else
                {
                    recordEx = new CardFamilyEntity
                    {
                        CreatedAt = DateTime.Now
                    };

                    recordEx.Empi = arg.Data.Empi;
                    recordEx.IdCardType = arg.Data.IdCardType;
                    recordEx.IdCardValue = arg.Data.IdCardValue;
                    recordEx.IsDeleted = false;
                    recordEx.Name = arg.Data.Name;
                    recordEx.RelType = arg.Data.RelType;

                    recordEx.UpdatedAt = DateTime.Now;

                    cardFmRepo.Insert(recordEx);
                }

                erhcUow.Commit();

                result.Succeed(string.Empty, new ErhcmemberFamilyResponse
                {
                    Id = recordEx.Id
                });
            }

            return result;
        }

        public ApiResultEx<ErhcmemberFamilyReadResponse> ErhcmemberFamilyRead(ApiArgument<ErhcmemberFamilyReadArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberFamilyReadResponse>(arg);
            //if (!arg.Validate(out var message))
            //    return result.Error(ErrorCode.LogicalError, message);

            var records = cardFmRepo.View.Where(p => p.IsDeleted == false && p.Empi == arg.Data.Empi)?.ToList();
            if (records != null && records.Count() > 0 && arg.Data.Id != 0)
            {
                records = records.Where(p => p.Id == arg.Data.Id).ToList();
            }

            if (records != null && records.Count > 0)
            {
                var datas = new List<ErhcmemberFamilyItem>();

                records?.ToList().ForEach(p =>
                {
                    var d = new ErhcmemberFamilyItem
                    {
                        IdCardType = p.IdCardType,
                        IdCardValue = p.IdCardValue,
                        Name = p.Name,
                        RelType = p.RelType,
                        Id = p.Id
                    };
                    var cc = cardRepo.View.FirstOrDefault(x => x.IdCardType == p.IdCardType && x.IdCardValue == p.IdCardValue);
                    if (cc != null)
                    {
                        d.Address = cc.Address;
                        d.Citizenship = cc.Citizenship;
                        d.Empi = cc.Empi;
                        d.ErhcCardNo = cc.ErhcCardNo;
                        d.ErhcEndDateTime = cc.ErhcEndDate;
                        d.IdCardNo = cc.IdCardNo;
                        d.IssuerOrgCode = cc.IssuerOrgCode;
                        d.IssuerOrgName = cc.IssuerOrgName;
                        d.Nationality = cc.Nationality;
                        d.QrCodeImageInfo = cc.QrCodeImageData;
                        d.QrCodeType = cc.QrCodeType;
                        d.Sex = cc.Sex;
                        d.Tel = cc.Tel;
                    }

                    datas.Add(d);
                });

                result.Succeed(string.Empty, new ErhcmemberFamilyReadResponse { Families = datas?.ToArray() });
            }
            else
            {
                result.Succeed(string.Empty, null);
            }

            return result;
        }

        public ApiResultEx<ErhcmemberFamilyResponse> ErhcmemberFamilyUpdate(ApiArgument<ErhcmemberFamilyUpdateArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberFamilyResponse>(arg);
            //if (!arg.Validate(out var message))
            //    return result.Error(ErrorCode.LogicalError, message);

            var record = cardFmRepo.View.Where(p => p.IsDeleted == false && p.Empi == arg.Data.Empi && p.IdCardType == arg.Data.IdCardType && p.IdCardValue == arg.Data.IdCardValue && p.Id != arg.Data.Id)?.OrderByDescending(p => p.CreatedAt).FirstOrDefault();
            if (record != null && record.Id != 0)
            {
                result.ExistedUser(string.Empty);
            }

            record = cardFmRepo.View.Where(p => p.IsDeleted == false && p.Empi == arg.Data.Empi && p.Id == arg.Data.Id)?.OrderByDescending(p => p.CreatedAt).FirstOrDefault();
            if (record == null || record.Id == 0)
            {
                result.UnknownUser(string.Empty);
            }
            else
            {
                record.Empi = arg.Data.Empi;
                record.IdCardType = arg.Data.IdCardType;
                record.IdCardValue = arg.Data.IdCardValue;
                record.Name = arg.Data.Name;
                record.RelType = arg.Data.RelType;

                record.UpdatedAt = DateTime.Now;

                cardFmRepo.Update(record);

                erhcUow.Commit();
            }

            result.Succeed(string.Empty, new ErhcmemberFamilyResponse
            {
                Id = record.Id
            });

            return result;
        }

        public ApiResultEx<ErhcmemberFamilyResponse> ErhcmemberFamilyDelete(ApiArgument<ErhcmemberFamilyDeleteArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberFamilyResponse>(arg);
            //if (!arg.Validate(out var message))
            //    return result.Error(ErrorCode.LogicalError, message);

            var record = cardFmRepo.View.Where(p => p.IsDeleted == false && p.Empi == arg.Data.Empi && p.Id == arg.Data.Id)?.OrderByDescending(p => p.CreatedAt).FirstOrDefault();
            if (record == null || record.Id == 0)
            {
                result.UnknownUser(string.Empty);
            }
            else
            {
                //record.IsDeleted = true;
                //record.UpdatedAt = DateTime.Now;
                //dal.Update(record);

                cardFmRepo.Delete(record);

                erhcUow.Commit();

                result.Succeed(string.Empty, new ErhcmemberFamilyResponse
                {
                    Id = record.Id
                });
            }

            return result;
        }

        public ApiResultEx<ErhcmemberFamilyResponse> ErhcmemberAddressBySmallApp(ApiArgument<ErhcmemberAddressBySmallAppArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberFamilyResponse>(arg);
            //if (!arg.Validate(out var message))
            //    return result.Error(ErrorCode.LogicalError, message);

            var id = arg.Data.Id;
            var addr = arg.Data.ExAddr;
            var regAddr = arg.Data.ExRegAddr;

            var record = cardExRepo.View.FirstOrDefault(p => p.ErhcCardId == id);

            if (record == null || record.Id == 0)
            {
                record = new CardExtendEntity
                {
                    CreatedAt = DateTime.Now
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

            record.UpdatedAt = DateTime.Now;

            if (record.Id == 0)
            {
                record.ErhcCardId = id;
                cardExRepo.Insert(record);
            }
            else
            {
                cardExRepo.Update(record);
            }

            erhcUow.Commit();

            result.Succeed(string.Empty, new ErhcmemberFamilyResponse
            {
                Id = record.Id
            });

            return result;
        }
    }
}
