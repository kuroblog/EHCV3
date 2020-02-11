
using WzHealthCard.Refactor.Api.Common;

namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using Newtonsoft.Json;
    using QRCoder;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using WzHealthCard.Refactor.Api.Extensions;
    using WzHealthCard.Refactor.Api.Models.Refactor;
    using WzHealthCard.Refactor.Api.Repositories.Erhc;

    public class WZSocialCardServiceResult<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 是否验证失败
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 提示内容
        /// </summary>
        public string Msg { get; set; }
    }

    public class WZSocialCardServiceResult1005Data
    {
        /// <summary>
        /// 命令字类型
        /// </summary>
        public string funcode { get; set; }

        /// <summary>
        /// 返回值 00 成功
        /// </summary>
        public string retcode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string retmsg { get; set; }

        /// <summary>
        /// 日期 YYMMDD
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 时间 HHMMSS
        /// </summary>
        public string time { get; set; }
    }

    public class WZSocialCardService1005Result : WZSocialCardServiceResult<WZSocialCardServiceResult1005Data> { }

    public class WZSocialCardServiceResult1105Data
    {
        /// <summary>
        /// 命令字类型
        /// </summary>
        public string funcode { get; set; }

        /// <summary>
        /// 返回值 00 成功
        /// </summary>
        public string retcode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string retmsg { get; set; }

        /// <summary>
        /// 日期 YYMMDD
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 时间 HHMMSS
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 二维码信息串
        /// </summary>
        public string qrcode { get; set; }

        /// <summary>
        /// 有效时间 单位秒
        /// </summary>
        public string validseconds { get; set; }

        /// <summary>
        /// 签发卡类型
        /// 参考附录D 电子社保卡电子健康卡签发情况
        /// </summary>
        public string cardsign { get; set; }
    }

    public class WZSocialCardService1105Result : WZSocialCardServiceResult<WZSocialCardServiceResult1105Data> { }

    public class WZSocialCardServiceResult1411Data
    {
        /// <summary>
        /// 命令字类型
        /// </summary>
        public string funcode { get; set; }

        /// <summary>
        /// 返回值 00 成功
        /// </summary>
        public string retcode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string retmsg { get; set; }

        /// <summary>
        /// 日期 YYMMDD
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// 时间 HHMMSS
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 实体社保卡号，成功时返回
        /// </summary>
        public string cardno { get; set; }

        /// <summary>
        /// 持卡人姓名，成功时返回
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string certno { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string certtype { get; set; }

        /// <summary>
        /// 统筹区 发卡地区行政区划代码，成功时返回
        /// </summary>
        public string zone { get; set; }

        /// <summary>
        /// 卡状态 0未启用1正常2挂失7作废8预挂失9注销，成功时返回
        /// </summary>
        public string cardstate { get; set; }

        /// <summary>
        /// 市民卡账户余额 单位分，成功时返回
        /// </summary>
        public string balance { get; set; }

        /// <summary>
        /// 健康卡ID 电子健康卡账户的唯一识别号
        /// </summary>
        public string erhccardno { get; set; }

        /// <summary>
        /// 健康卡主索引 个人唯一识别号
        /// </summary>
        public string empi { get; set; }

        /// <summary>
        /// 授权过期时间 yyyyMMddHHmmss
        /// </summary>
        public string invalidtime { get; set; }

        /// <summary>
        /// 签发卡类型
        /// 参考附录D 电子社保卡电子健康卡签发情况
        /// </summary>
        public string cardsign { get; set; }

        /// <summary>
        /// 市民卡卡号
        /// </summary>
        public string smkcardno { get; set; }
    }

    public class WZSocialCardService1411Result : WZSocialCardServiceResult<WZSocialCardServiceResult1411Data> { }

    public interface ISocialCardServiceProxyHandler
    {
        void Do1005<TResult>((string birthday, string sex, string birthplace, string domicile) arg, ApiResultEx<TResult> result, (string erhc_cardno, string idcard_type, string idcard_value, string name, string tel, string empi, string citizenship, string nationality, string address) s)
            where TResult : class, new();

        Task Do1005Async<TResult>((string birthday, string sex, string birthplace, string domicile) arg, ApiResultEx<TResult> result, (string erhc_cardno, string idcard_type, string idcard_value, string name, string tel, string empi, string citizenship, string nationality, string address) s)
            where TResult : class, new();

        void Do1105((string erhc_cardno, string empi, string idcard_type, string idcard_value) s, ApiResultEx<ErhcmemberQrCodeDynamicResponse> result);

        void Do1411(string qrCodeInfo, ApiResultEx<ErhcmemberVerifyResponse> result);

        ApiResultEx<ErhcmemberVerifyResponse> Do1411(ApiArgument<ErhcmemberVerifyHospitalArgument> arg);

        void Do1411V2(string qrCodeInfo, ApiResultEx<ErhcmemberVerifyResponseV2> result);

        ApiResultEx<ErhcmemberVerifyResponseV2> Do1411V2(ApiArgument<ErhcmemberVerifyHospitalArgument> arg);

        WZSocialCardService1413Result Do1413(string hosid, string hosname, string termid, string terminfo, string phone);

        WZSocialCardService1106Result Do1106(string hosid, string hosname, string termid, string terminfo, string ftokenurl);

        WZSocialCardService1105Result Do1105(string erhcCardNo, string empi, string idCardType, string idCardNo);

        #region 异步
        Task<WZSocialCardService1413Result> Do1413Async(string hosid, string hosname, string termid, string terminfo, string phone);

        Task<WZSocialCardService1105Result> Do1105Async(string erhcCardNo, string empi, string idCardType, string idCardNo);

        Task<WZSocialCardService1106Result> Do1106Async(string hosid, string hosname, string termid, string terminfo, string ftokenurl);
        #endregion

    }

    public class WZSocialCardService1413Result : WZSocialCardServiceResult<WZSocialCardServiceResult1413Data> { }

    public class WZSocialCardService1106Result : WZSocialCardServiceResult<WZSocialCardServiceResult1106Data> { }

    public class WZSocialCardServiceProxyHandler : ISocialCardServiceProxyHandler
    {
        private readonly ConfigManager config;
        private readonly ResultCodeHandler rc;
        //private readonly ErhcUnitOfWork erhcUow;
        private readonly CardRepository cardRepo;
        private readonly IErrorHandler error;
        private readonly ILogger logger;
        private readonly IMonitorModelScope _monitorScope;
        private readonly IHttpClientFactory _httpClientFactory;

        public WZSocialCardServiceProxyHandler(ConfigManager config, ResultCodeHandler rc/*, ErhcUnitOfWork erhcUow*/, CardRepository cardRepo, IErrorHandler error, ILogger logger, IMonitorModelScope monitorScope, IHttpClientFactory httpClientFactory)
        {
            this.config = config;
            this.rc = rc;
            //this.erhcUow = erhcUow;
            this.cardRepo = cardRepo;
            this.error = error;
            this.logger = logger;
            _monitorScope = monitorScope;
            _httpClientFactory = httpClientFactory;
        }

        private readonly Dictionary<string, string> dicCertType = new Dictionary<string, string> {
            { "01", "01" },
            { "02", "02" },
            { "03", "04" },
            { "04", "03" },
            { "05", "06" },
            { "06", "06" },
            { "07", "06" },
            { "08", "06" },
            { "99", "06" } };

        private readonly HttpClientHandler sslHandler = new HttpClientHandler
        {
            ClientCertificateOptions = ClientCertificateOption.Manual,
            ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
        };

        private TResult DoApiRequest<TResult, TArg>(TArg request, string funCode, string apiHostKey, string apiUrlKey) => JsonConvert.DeserializeObject<TResult>(DoApiRequest(request, funCode, apiHostKey, apiUrlKey));

        private string DoApiRequest<TArg>(TArg request, string funCode, string apiHostKey, string apiUrlKey)
        {
            HttpClient client = null;
            
            //日志记录
            var st = DateTime.Now;
            _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode);
            _monitorScope.Add(RemoteInterfaces.SocialInterface,funCode, "开始时间", $"{st:yyyy-MM-dd HH:mm:ss fff}");

            using (client = _httpClientFactory.CreateClient(RemoteHttpNames.RemoteName))
            {

                try
                {
                    logger.Debug($"{funCode}_args:{JsonConvert.SerializeObject(request)}");

                    //var host = config.GetAppSetting("WZSocialApiHostUrl");
                    var host = config.GetAppSetting(apiHostKey);
                    var url = config.GetAppSetting(apiUrlKey);
                    var path = Path.Combine(host, url);

                    //日志
                    _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode, $"接口Url", path);
                    _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode, "接口参数", request.ToJson());

                    logger.Debug($"{funCode}_path:{path}");

                    var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    var response = client.PostAsync(path, content).Result;

                    logger.Debug($"{funCode}_res_code:{response.StatusCode}");

                    response.EnsureSuccessStatusCode();
                    var resJson = response.Content.ReadAsStringAsync().Result;

                    //日志结果
                    _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode, "接口返回", resJson);
                    var et = DateTime.Now;
                    _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode, "结束时间", $"{et:yyyy-MM-dd HH:mm:ss fff}  运行时间:{(et - st).TotalMilliseconds}");

                    logger.Debug($"{funCode}_res_content:{resJson}");

                    //return JsonConvert.DeserializeObject<TResult>(resJson);

                    return resJson;
                }
                finally
                {
                    client?.Dispose();
                }
            }
        }

        public void Do1005<TResult>(
            (string birthday, string sex, string birthplace, string domicile) arg, ApiResultEx<TResult> result,
            (string erhc_cardno, string idcard_type, string idcard_value, string name, string tel, string empi, string citizenship, string nationality, string address) s)
            where TResult : class, new() => DoApiRequest<WZSocialCardService1005Result, dynamic>(new
            {
                funcode = "1005",                                               // 命令字类型
                safecontrol = config.GetAppSetting("WZSocialApiSafeControl"),   // 安全级别
                appbizid = config.GetAppSetting("WZSocialApiAppBizId"),         // 机构代码
                channel = config.GetAppSetting("WZSocialApiChannel"),           // 发码渠道
                userid = s.erhc_cardno,                                         // 用户编号/电子健康卡ID
                certtype = dicCertType[s.idcard_type],                          // 证件类型
                certno = s.idcard_value,                                        // 证件号码
                s.name,                                                         // 姓名
                phone = s.tel,                                                  // 手机号
                sbchannel = config.GetAppSetting("WZSocialApiSbChannel"),       // 社保渠道
                signno = s.empi,                                                // 签发号或主索引IDEMPI
                arg.birthday,                                                   // 出生日期
                s.citizenship,                                                  // 国籍
                s.nationality,                                                  // 民族
                s.address,                                                      // 联系地址
                arg.sex,                                                        // 性别
                arg.birthplace,                                                 // 出生地
                arg.domicile                                                    // 户籍所在地
            }, "1005", "WZSocialApiHostUrl", "WZSocialApi1005Url");


        public async Task Do1005Async<TResult>(
            (string birthday, string sex, string birthplace, string domicile) arg, ApiResultEx<TResult> result,
            (string erhc_cardno, string idcard_type, string idcard_value, string name, string tel, string empi, string citizenship, string nationality, string address) s)
            where TResult : class, new() =>await DoApiRequestAsync<WZSocialCardService1005Result, dynamic>(new
            {
                funcode = "1005",                                               // 命令字类型
                safecontrol = config.GetAppSetting("WZSocialApiSafeControl"),   // 安全级别
                appbizid = config.GetAppSetting("WZSocialApiAppBizId"),         // 机构代码
                channel = config.GetAppSetting("WZSocialApiChannel"),           // 发码渠道
                userid = s.erhc_cardno,                                         // 用户编号/电子健康卡ID
                certtype = dicCertType[s.idcard_type],                          // 证件类型
                certno = s.idcard_value,                                        // 证件号码
                s.name,                                                         // 姓名
                phone = s.tel,                                                  // 手机号
                sbchannel = config.GetAppSetting("WZSocialApiSbChannel"),       // 社保渠道
                signno = s.empi,                                                // 签发号或主索引IDEMPI
                arg.birthday,                                                   // 出生日期
                s.citizenship,                                                  // 国籍
                s.nationality,                                                  // 民族
                s.address,                                                      // 联系地址
                arg.sex,                                                        // 性别
                arg.birthplace,                                                 // 出生地
                arg.domicile                                                    // 户籍所在地
            }, "1005", "WZSocialApi1005Url");


        private readonly Func<string, string> qrCodeGenerator = (key) =>
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(key, QRCodeGenerator.ECCLevel.H);
            var qrCode = new Base64QRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        };

        //private Bitmap GetQRCode(string msg, int pixel, string icon_path, int icon_size, int icon_border, bool white_edge, int version)
        //{
        //    QRCodeGenerator code_generator = new QRCodeGenerator();
        //    QRCodeData code_data = code_generator.CreateQrCode(msg, QRCodeGenerator.ECCLevel.M, true, true, QRCoder.QRCodeGenerator.EciMode.Utf8);
        //    QRCode code = new QRCode(code_data);

        //    Bitmap icon = new Bitmap(icon_path);
        //    Bitmap bmp = code.GetGraphic(pixel, Color.Black, Color.White, icon, icon_size, icon_border, white_edge);

        //    return bmp;
        //}

        //private string ImgToBase64String(Bitmap bmp)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    byte[] arr = new byte[ms.Length];
        //    ms.Position = 0;
        //    ms.Read(arr, 0, (int)ms.Length);
        //    ms.Close();
        //    String strbaser64 = Convert.ToBase64String(arr);
        //    //"data:image/jpeg;base64," 
        //    return strbaser64;
        //}

        //private string QrCodeGeneratorByLogo(string key)
        //{
        //    string logo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "erweima.png");
        //    using (var btm = GetQRCode(key, 6, logo, 20, 1, false, 5))
        //    {
        //        return ImgToBase64String(btm);
        //    }
        //}

        public void Do1105((string erhc_cardno, string empi, string idcard_type, string idcard_value) s, ApiResultEx<ErhcmemberQrCodeDynamicResponse> result)
        {
            try
            {
                var response = DoApiRequest<WZSocialCardService1105Result, dynamic>(new
                {
                    funcode = "1105",                                               // 命令字类型
                    safecontrol = config.GetAppSetting("WZSocialApiSafeControl"),   // 安全级别
                    appbizid = config.GetAppSetting("WZSocialApiAppBizId"),         // 机构代码
                    channel = config.GetAppSetting("WZSocialApiChannel"),           // 发码渠道
                    userid = s.erhc_cardno,                                         // 用户编号/电子健康卡ID
                                                                                    //phone = s.tel,                                                              // 手机号
                                                                                    //appver = ConfigurationManager.GetAppSetting("WZSocialApiAppVer"),           // App版本号
                                                                                    //phonever = ConfigurationManager.GetAppSetting("WZSocialApiPhoneVer"),       // 手机型号
                                                                                    //s.lng,                                                                      // 经度
                                                                                    //s.lat,                                                                      // 纬度
                    sbchannel = config.GetAppSetting("WZSocialApiSbChannel"),       // 社保渠道
                    signno = s.empi,                                                // 签发号或主索引IDEMPI
                    certtype = dicCertType[s.idcard_type],                          // 证件类型
                    certno = s.idcard_value
                }, "1105", "WZSocialApiHostUrl", "WZSocialApi1105Url");

                if (!response.Success)
                {
                    result.Failed(response.StatusCode, response.Msg);
                }
                else
                {
                    var resCode = response.Data.retcode;
                    if (resCode != "00")
                    {
                        result.Failed(response.Data.retcode, response.Data.retmsg.Trim());
                    }
                    else
                    {
                        var vSeconds = Convert.ToDouble(response.Data.validseconds);
                        var vMinutes = TimeSpan.FromSeconds(vSeconds).TotalMinutes;

                        result.Succeed(response.Data.retcode, response.Data.retmsg, new ErhcmemberQrCodeDynamicResponse
                        {
                            EMPI = s.empi,
                            ErhcCardNo = s.erhc_cardno,
                            //QrCodeImageInfo = res.Data.qrcode,
                            QrCodeImageInfo = qrCodeGenerator(response.Data.qrcode),
                            //QrCodeVaildDateTime = Convert.ToInt32(res.Data.validseconds),
                            QrCodeVaildDateTime = (int)vMinutes,
                            eSocialSecurityCard_Sign = response.Data.cardsign
                        });

                        logger.Debug($"result:{JsonConvert.SerializeObject(result)}");
                    }
                }
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }
        }

        public WZSocialCardService1106Result Do1106(string hosid, string hosname, string termid, string terminfo, string ftokenurl) => DoApiRequest<WZSocialCardService1106Result, dynamic>(new
        {
            funcode = "1106",                                                           // 命令字类型
            safecontrol = config.GetAppSetting("WZSocialApiSafeControl"), // 安全级别
            appbizid = config.GetAppSetting("WZSocialApiAppBizId"),       // 机构代码
            channel = config.GetAppSetting("WZSocialApiChannel"),         // 发码渠道
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            hosid,
            hosname,
            termid,
            terminfo,
            ftokenurl
        }, "1106", "WZSocialApiHostUrl", "WZSocialApi1106Url");

        public WZSocialCardService1105Result Do1105(string erhcCardNo, string empi, string idCardType, string idCardNo) => DoApiRequest<WZSocialCardService1105Result, dynamic>(new
        {
            funcode = "1105",                                                           // 命令字类型
            safecontrol = config.GetAppSetting("WZSocialApiSafeControl"), // 安全级别
            appbizid = config.GetAppSetting("WZSocialApiAppBizId"),       // 机构代码
            channel = config.GetAppSetting("WZSocialApiChannel"),         // 发码渠道
            //timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            userid = erhcCardNo,
            sbchannel = config.GetAppSetting("WZSocialApiSbChannel"),     // 社保渠道
            signno = empi,
            certtype = dicCertType[idCardType],
            certno = idCardNo
        }, "1105", "WZSocialApiHostUrl", "WZSocialApi1105Url");

        public WZSocialCardService1413Result Do1413(string hosid, string hosname, string termid, string terminfo, string phone) => DoApiRequest<WZSocialCardService1413Result, dynamic>(new
        {
            funcode = "1413",                                                           // 命令字类型
            safecontrol = config.GetAppSetting("WZSocialApiSafeControl"), // 安全级别
            appbizid = config.GetAppSetting("WZSocialApiAppBizId"),       // 机构代码
            //channel = ConfigurationManager.GetAppSetting("WZSocialApiChannel"),         // 发码渠道
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            hosid,
            hosname,
            termid,
            terminfo,
            phone
        }, "1413", "WZSocialApiHostUrl", "WZSocialApi1413Url");

        #region Do1411和1411V2
        //private WZSocialCardService1411Result do1411(string qrCode, ConfigManager config)
        //{
        //    var client = HttpClientFactory.Create(sslHandler);

        //    var request = new
        //    {
        //        funcode = "1411",                                                           // 命令字类型
        //        safecontrol = config.GetAppSetting("WZSocialApiSafeControl"), // 安全级别
        //        appbizid = config.GetAppSetting("WZSocialApiAppBizId"),       // 机构代码
        //        channel = config.GetAppSetting("WZSocialApiChannel"),         // 发码渠道
        //        qrcode = qrCode
        //    };
        //    var host = config.GetAppSetting("WZSocialApiHostUrl");
        //    var url = config.GetAppSetting("WZSocialApi1411Url");
        //    var path = Path.Combine(host, url);
        //    var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        //    var response = client.PostAsync(path, content).Result;


        //    response.EnsureSuccessStatusCode();
        //    var resJson = response.Content.ReadAsStringAsync().Result;
        //    var res = JsonConvert.DeserializeObject<WZSocialCardService1411Result>(resJson);
        //    return res;
        //}

        public void Do1411(string qrCodeInfo, ApiResultEx<ErhcmemberVerifyResponse> result)
        {
            try
            {
                //var response = do1105((result.Data.ErhcCardno, result.Data.Empi, result.Data.IdcardType, result.Data.IdcardValue));
                var response = DoApiRequest<WZSocialCardService1411Result, dynamic>(new
                {
                    funcode = "1411",                                               // 命令字类型
                    safecontrol = config.GetAppSetting("WZSocialApiSafeControl"),   // 安全级别
                    appbizid = config.GetAppSetting("WZSocialApiAppBizId"),         // 机构代码
                    channel = config.GetAppSetting("WZSocialApiChannel"),           // 发码渠道
                    qrcode = qrCodeInfo
                }, "1411", "WZSocialApiHostUrl", "WZSocialApi1411Url");

                if (!response.Success)
                {
                    // 不处理，确保电子健康卡的验证信息返回
                    //result.Failed(response.StatusCode, response.Msg);
                }
                else
                {
                    var resCode = response.Data.retcode;
                    if (resCode != "00")
                    {
                        // 不处理，确保电子健康卡的验证信息返回
                        //result.Failed(response.Data.retcode, response.Data.retmsg.Trim());
                    }
                    else
                    {
                        result.Succeed(response.Data.retcode, response.Data.retmsg, result.Data);

                        result.Data.Category = string.Empty;
                        result.Data.CitizenCardBalance = response.Data.balance;
                        result.Data.CitizenCardStatus = response.Data.cardstate;
                        result.Data.SocialSecurityCard = response.Data.cardno;
                        result.Data.SocialSecurityCardCity = response.Data.zone;
                        result.Data.ESocialSecurityCardSign = response.Data.cardsign;

                        logger.Debug($"result:{JsonConvert.SerializeObject(result)}");
                    }
                }
            }
            catch (Exception ex)
            {
                //error.Execute(ex, result, ResultCodes.LocalError);

                // 不处理，确保电子健康卡的验证信息返回
                error.ErrorLog(ex);
            }
        }

        public ApiResultEx<ErhcmemberVerifyResponse> Do1411(ApiArgument<ErhcmemberVerifyHospitalArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberVerifyResponse>(arg);

            try
            {
                var response = DoApiRequest<WZSocialCardService1411Result, dynamic>(new
                {
                    funcode = "1411",                                               // 命令字类型
                    safecontrol = config.GetAppSetting("WZSocialApiSafeControl"),   // 安全级别
                    appbizid = config.GetAppSetting("WZSocialApiAppBizId"),         // 机构代码
                    channel = config.GetAppSetting("WZSocialApiChannel"),           // 发码渠道
                    qrcode = arg.Data.QrcodeInfo
                }, "1411", "WZSocialApiHostUrl", "WZSocialApi1411Url");

                if (!response.Success)
                {
                    result.Failed(response.StatusCode, response.Msg);
                }
                else
                {
                    var resCode = response.Data.retcode;
                    if (resCode != "00")
                    {
                        result.Failed(response.Data.retcode, response.Data.retmsg.Trim());
                    }
                    else
                    {
                        var card = cardRepo.View.FirstOrDefault(p => p.ErhcCardNo == response.Data.erhccardno);

                        if (card == null)
                        {
                            //result.Failed(response.Data.retcode, response.Data.retmsg.Trim());
                            result.UnknownUser("没有在本地查询到相关用户");
                        }
                        else
                        {
                            DoApiRequest<dynamic>(new
                            {
                                appId = arg.Header.AppId,
                                cardId = card.ErhcCardNo,
                                appSource = 0,
                                depCode = arg.Data.DepCode,
                                depType = arg.Data.DepType,
                                empi = card.Empi,
                                idCardNo = card.IdCardNo,
                                medType = arg.Data.MedType,
                                msCode = arg.Data.MedStepcode,
                                orgCode = card.IssuerOrgCode,
                                orgName = card.IssuerOrgName
                            }, "用卡分析", "ErhcBaseSvcUrl", "ErhcCardUseCreateSvcUrl");

                            result.Succeed(response.Data.retcode, response.Data.retmsg.Trim(), new ErhcmemberVerifyResponse
                            {
                                Empi = card.Empi,
                                ErhcCardno = card.ErhcCardNo,
                                Name = card.Name,
                                Sex = card.Sex,
                                IdcardNo = card.IdCardNo.ReplaceNullValue(),
                                IdcardType = card.IdCardType,
                                IdcardValue = card.IdCardValue,
                                Citizenship = card.Citizenship,
                                Nationality = card.Nationality,
                                Tel = card.Tel,
                                Address = card.Address,
                                IssuerOrgcode = card.IssuerOrgCode,
                                IssuerOrgname = card.IssuerOrgName,
                                ErhcEndDateTime = string.IsNullOrEmpty(card.ErhcEndDate) ? DateTime.Now : DateTime.Parse(card.ErhcEndDate),
                                //UserSign = s.user_sign
                                UserSign = string.Empty,
                                //category = res.Data.MessageContent.HealthPersonType,
                                //citizencard_balance = res.Data.MessageContent.CityCardAmount,
                                //citizencard_status = res.Data.MessageContent.CityCardStatus,
                                //socialsecuritycard = res.Data.MessageContent.SocialCard,
                                //socialsecuritycard_city = res.Data.MessageContent.CardAreaCode
                                Category = string.Empty,
                                CitizenCardBalance = response.Data.balance,
                                CitizenCardStatus = response.Data.cardstate,
                                SocialSecurityCard = response.Data.cardno,
                                SocialSecurityCardCity = response.Data.zone,
                                ESocialSecurityCardSign = response.Data.cardsign
                            });
                        }

                        logger.Debug($"result:{JsonConvert.SerializeObject(result)}");
                    }
                }
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return result;
        }

        public void Do1411V2(string qrCodeInfo, ApiResultEx<ErhcmemberVerifyResponseV2> result)
        {
            try
            {
                //var response = do1105((result.Data.ErhcCardno, result.Data.Empi, result.Data.IdcardType, result.Data.IdcardValue));
                var response = DoApiRequest<WZSocialCardService1411Result, dynamic>(new
                {
                    funcode = "1411",                                               // 命令字类型
                    safecontrol = config.GetAppSetting("WZSocialApiSafeControl"),   // 安全级别
                    appbizid = config.GetAppSetting("WZSocialApiAppBizId"),         // 机构代码
                    channel = config.GetAppSetting("WZSocialApiChannel"),           // 发码渠道
                    qrcode = qrCodeInfo
                }, "1411", "WZSocialApiHostUrl", "WZSocialApi1411Url");

                if (!response.Success)
                {
                    // 不处理，确保电子健康卡的验证信息返回
                    //result.Failed(response.StatusCode, response.Msg);
                }
                else
                {
                    var resCode = response.Data.retcode;
                    if (resCode != "00")
                    {
                        // 不处理，确保电子健康卡的验证信息返回
                        //result.Failed(response.Data.retcode, response.Data.retmsg.Trim());
                    }
                    else
                    {
                        result.Succeed(response.Data.retcode, response.Data.retmsg, result.Data);

                        result.Data.Category = string.Empty;
                        result.Data.CitizenCardBalance = response.Data.balance;
                        result.Data.CitizenCardStatus = response.Data.cardstate;
                        result.Data.SocialSecurityCard = response.Data.cardno;
                        result.Data.SocialSecurityCardCity = response.Data.zone;
                        result.Data.ESocialSecurityCardSign = response.Data.cardsign;
                        result.Data.validseconds = long.TryParse(response.Data.invalidtime, out long time) ? time : 0;
                        result.Data.CertNo = response.Data.smkcardno;

                        logger.Debug($"result:{JsonConvert.SerializeObject(result)}");
                    }
                }
            }
            catch (Exception ex)
            {
                //error.Execute(ex, result, ResultCodes.LocalError);

                // 不处理，确保电子健康卡的验证信息返回
                error.ErrorLog(ex);
            }
        }

        public ApiResultEx<ErhcmemberVerifyResponseV2> Do1411V2(ApiArgument<ErhcmemberVerifyHospitalArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<ErhcmemberVerifyResponseV2>(arg);

            try
            {
                var response = DoApiRequest<WZSocialCardService1411Result, dynamic>(new
                {
                    funcode = "1411",                                               // 命令字类型
                    safecontrol = config.GetAppSetting("WZSocialApiSafeControl"),   // 安全级别
                    appbizid = config.GetAppSetting("WZSocialApiAppBizId"),         // 机构代码
                    channel = config.GetAppSetting("WZSocialApiChannel"),           // 发码渠道
                    qrcode = arg.Data.QrcodeInfo
                }, "1411", "WZSocialApiHostUrl", "WZSocialApi1411Url");

                if (!response.Success)
                {
                    result.Failed(response.StatusCode, response.Msg);
                }
                else
                {
                    var resCode = response.Data.retcode;
                    if (resCode != "00")
                    {
                        result.Failed(response.Data.retcode, response.Data.retmsg.Trim());
                    }
                    else
                    {
                        var card = cardRepo.View.FirstOrDefault(p => p.ErhcCardNo == response.Data.erhccardno);

                        if (card == null)
                        {
                            //result.Failed(response.Data.retcode, response.Data.retmsg.Trim());
                            result.UnknownUser("没有在本地查询到相关用户");
                        }
                        else
                        {
                            DoApiRequest<dynamic>(new
                            {
                                appId = arg.Header.AppId,
                                cardId = card.ErhcCardNo,
                                appSource = 0,
                                depCode = arg.Data.DepCode,
                                depType = arg.Data.DepType,
                                empi = card.Empi,
                                idCardNo = card.IdCardNo,
                                medType = arg.Data.MedType,
                                msCode = arg.Data.MedStepcode,
                                orgCode = card.IssuerOrgCode,
                                orgName = card.IssuerOrgName
                            }, "用卡分析", "ErhcBaseSvcUrl", "ErhcCardUseCreateSvcUrl");

                            var data = new ErhcmemberVerifyResponseV2
                            {
                                Empi = card.Empi,
                                ErhcCardno = card.ErhcCardNo,
                                Name = card.Name,
                                Sex = card.Sex,
                                IdcardNo = card.IdCardNo.ReplaceNullValue(),
                                IdcardType = card.IdCardType,
                                IdcardValue = card.IdCardValue,
                                Citizenship = card.Citizenship,
                                Nationality = card.Nationality,
                                Tel = card.Tel,
                                Address = card.Address,
                                IssuerOrgcode = card.IssuerOrgCode,
                                IssuerOrgname = card.IssuerOrgName,
                                ErhcEndDateTime = string.IsNullOrEmpty(card.ErhcEndDate) ? DateTime.Now : DateTime.Parse(card.ErhcEndDate),
                                //UserSign = s.user_sign
                                UserSign = string.Empty,
                                //category = res.Data.MessageContent.HealthPersonType,
                                //citizencard_balance = res.Data.MessageContent.CityCardAmount,
                                //citizencard_status = res.Data.MessageContent.CityCardStatus,
                                //socialsecuritycard = res.Data.MessageContent.SocialCard,
                                //socialsecuritycard_city = res.Data.MessageContent.CardAreaCode
                                Category = string.Empty,
                                CitizenCardBalance = response.Data.balance,
                                CitizenCardStatus = response.Data.cardstate,
                                SocialSecurityCard = response.Data.cardno,
                                SocialSecurityCardCity = response.Data.zone,
                                ESocialSecurityCardSign = response.Data.cardsign,
                                validseconds = long.TryParse(response.Data.invalidtime, out long time) ? time : 0,
                                CertNo = response.Data.smkcardno
                            };

                            result.Succeed(response.Data.retcode, response.Data.retmsg.Trim(), data);
                        }

                        //logger.Debug($"result:{JsonConvert.SerializeObject(result)}");
                    }
                }
            }
            catch (Exception ex)
            {
                error.Execute(ex, result, ResultCodes.LocalError);
            }

            return result;
        }
        #endregion


        #region 异步请求
        /// <summary>
        /// 异步请求
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TArg"></typeparam>
        /// <param name="request"></param>
        /// <param name="funCode"></param>
        /// <param name="apiUrlKey"></param>
        /// <returns></returns>
        private async Task<TResult> DoApiResultAsync<TResult, TArg>(TArg request, string funCode, string apiUrlKey)
        {
            //日志记录
            var st = DateTime.Now;
            _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode);
            _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode, "开始时间", $"{st:yyyy-MM-dd HH:mm:ss fff}");
            HttpClient client = null;
            using (client = _httpClientFactory.CreateClient(RemoteHttpNames.RemoteName))
            {
                try
                {
                    logger.Debug($"{funCode}_args:{JsonConvert.SerializeObject(request)}");

                    var host = config.GetAppSetting("WZSocialApiHostUrl");
                    var url = config.GetAppSetting(apiUrlKey);
                    var path = Path.Combine(host, url);
                    //记录请求接口
                    _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode, "市民卡接口Url", path);
                    _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode, "市民卡接口参数", request.ToJson());

                    logger.Debug($"{funCode}_path:{path}");

                    var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(path, content);

                    logger.Debug($"{funCode}_res_code:{response.StatusCode}");

                    response.EnsureSuccessStatusCode();
                    var resJson = response.Content.ReadAsStringAsync().Result;

                    //日志结果
                    _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode, "接口返回", resJson);
                    var et = DateTime.Now;
                    _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode, "结束时间", $"{et:yyyy-MM-dd HH:mm:ss fff}  运行时间:{(et - st).TotalMilliseconds}");


                    logger.Debug($"{funCode}_res_content:{resJson}");

                    return JsonConvert.DeserializeObject<TResult>(resJson);
                }
                finally
                {
                    client?.Dispose();
                }
            }
        }

        /// <summary>
        /// 1106异步请求
        /// </summary>
        /// <param name="hosid"></param>
        /// <param name="hosname"></param>
        /// <param name="termid"></param>
        /// <param name="terminfo"></param>
        /// <param name="ftokenurl"></param>
        /// <returns></returns>
        public async Task<WZSocialCardService1106Result> Do1106Async(string hosid, string hosname, string termid, string terminfo, string ftokenurl) => await DoApiRequestAsync<WZSocialCardService1106Result, dynamic>(new
        {
            funcode = "1106",                                                           // 命令字类型
            safecontrol = config.GetAppSetting("WZSocialApiSafeControl"), // 安全级别
            appbizid = config.GetAppSetting("WZSocialApiAppBizId"),       // 机构代码
            channel = config.GetAppSetting("WZSocialApiChannel"),         // 发码渠道
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            hosid,
            hosname,
            termid,
            terminfo,
            ftokenurl
        }, "1106", "WZSocialApi1106Url");

        /// <summary>
        /// 市民卡异步请求
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TArg"></typeparam>
        /// <param name="request"></param>
        /// <param name="funCode"></param>
        /// <param name="apiUrlKey"></param>
        /// <returns></returns>
        private async Task<TResult> DoApiRequestAsync<TResult, TArg>(TArg request, string funCode, string apiUrlKey)
        {
            HttpClient client=null;
            using (client = _httpClientFactory.CreateClient(RemoteHttpNames.RemoteName))
            {
                try
                {
                    logger.Debug($"{funCode}_args:{JsonConvert.SerializeObject(request)}");

                    var host = config.GetAppSetting("WZSocialApiHostUrl");
                    var url = config.GetAppSetting(apiUrlKey);
                    var path = Path.Combine(host, url);

                    //记录请求接口
                    _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode);
                    _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode, "市民卡接口Url", path);
                    _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode, "市民卡接口参数", request.ToJson());


                    logger.Debug($"{funCode}_path:{path}");

                    var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(path, content);

                    logger.Debug($"{funCode}_res_code:{response.StatusCode}");

                    response.EnsureSuccessStatusCode();
                    var resJson = response.Content.ReadAsStringAsync().Result;

                    //接口返回
                    _monitorScope.Add(RemoteInterfaces.SocialInterface, funCode, "市民卡接口返回", resJson);
                    logger.Debug($"{funCode}_res_content:{resJson}");

                    return JsonConvert.DeserializeObject<TResult>(resJson);
                }
                finally
                {
                    client?.Dispose();
                }
            }
        }

        public async Task<WZSocialCardService1105Result> Do1105Async(string erhcCardNo, string empi, string idCardType, string idCardNo) => await DoApiRequestAsync<WZSocialCardService1105Result, dynamic>(new
        {
            funcode = "1105",                                                           // 命令字类型
            safecontrol = config.GetAppSetting("WZSocialApiSafeControl"), // 安全级别
            appbizid = config.GetAppSetting("WZSocialApiAppBizId"),       // 机构代码
            channel = config.GetAppSetting("WZSocialApiChannel"),         // 发码渠道
            //timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            userid = erhcCardNo,
            sbchannel = config.GetAppSetting("WZSocialApiSbChannel"),     // 社保渠道
            signno = empi,
            certtype = dicCertType[idCardType],
            certno = idCardNo
        }, "1105", "WZSocialApi1105Url");

        /// <summary>
        /// 1413获取证件列表信息
        /// </summary>
        /// <param name="hosid"></param>
        /// <param name="hosname"></param>
        /// <param name="termid"></param>
        /// <param name="terminfo"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public async Task<WZSocialCardService1413Result> Do1413Async(string hosid, string hosname, string termid, string terminfo, string phone) => await DoApiRequestAsync<WZSocialCardService1413Result, dynamic>(new
        {
            funcode = "1413",                                                           // 命令字类型
            safecontrol = config.GetAppSetting("WZSocialApiSafeControl"), // 安全级别
            appbizid = config.GetAppSetting("WZSocialApiAppBizId"),       // 机构代码
            //channel = ConfigurationManager.GetAppSetting("WZSocialApiChannel"),         // 发码渠道
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            hosid,
            hosname,
            termid,
            terminfo,
            phone
        }, "1413", "WZSocialApi1413Url");
        #endregion
    }

    public class WZSocialCardServiceResult1413Data
    {
        /// <summary>
        /// 命令字类型
        /// </summary>
        public string funcode { get; set; }

        /// <summary>
        /// 返回值 00 成功
        /// </summary>
        public string retcode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string retmsg { get; set; }

        /// <summary>
        /// json格式
        /// </summary>
        public WZSocialCardServiceResult1413Item[] certinfos { get; set; }
    }


    public class WZSocialCardServiceResult1413Item
    {
        /// <summary>
        /// 持卡人姓名，成功时返回
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string certno { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string certtype { get; set; }
    }

    public class WZSocialCardServiceResult1106Data
    {
        /// <summary>
        /// 命令字类型
        /// </summary>
        public string funcode { get; set; }

        /// <summary>
        /// 返回值 00 成功
        /// </summary>
        public string retcode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string retmsg { get; set; }

        /// <summary>
        /// YYMMDD
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// HHMMSS
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 返回组装好的二维码信息串
        /// </summary>
        public string qrcode { get; set; }

        /// <summary>
        /// 单位秒
        /// </summary>
        public string validseconds { get; set; }

        private string _eSocialSecurityCard_Sign;

        /// <summary>
        /// 电子社保卡是否签发标志（0=未签发；1=已签发,其他非1或0 的情况表明未知，建议按是否等于1来判断）
        /// </summary>
        public string cardsign
        {
            set => _eSocialSecurityCard_Sign = value;
            get
            {
                switch (_eSocialSecurityCard_Sign)
                {
                    case "2": return "1";
                    case "0": return "1";
                    case "1": return "0";
                    default: return _eSocialSecurityCard_Sign;
                }
            }
        }
    }

}
