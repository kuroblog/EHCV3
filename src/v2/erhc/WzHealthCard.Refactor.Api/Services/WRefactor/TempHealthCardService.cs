using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WzHealthCard.Refactor.Api.Common;
using WzHealthCard.Refactor.Api.DataAccess;
using WzHealthCard.Refactor.Api.DataAccess.Erhc;
using WzHealthCard.Refactor.Api.Models.Refactor;
using WzHealthCard.Refactor.Api.Services.Refactor;
using Xuhui.Internetpro.WzHealthCardService;
namespace WzHealthCard.Refactor.Api.Services.WRefactor
{
    /// <summary>
    /// 临时电子健康卡实现
    /// </summary>
    public class TempHealthCardService: ITempHealthCardService
    {
        /// <summary>
        /// 加密密文
        /// </summary>
        private const string secret = "WenZhouXuhui";

        private readonly ErhcContext _erhcDb;
        private readonly ErhcManageContext _manageDb;
        private readonly ResultCodeHandler rc;

        public TempHealthCardService(ErhcContext db, ErhcManageContext manageDb, 
            ResultCodeHandler rc, IMonitorModelScope monitorScope)
        {
            _erhcDb = db;
            _manageDb = manageDb;
            this.rc = rc;
        }

        /// <summary>
        /// 临时健康卡信息注册
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public async Task<ApiResultEx<TempeCardApplyResponse>> TempeCardApply(ApiArgument<TempeCardApplyArgument> arg)
        {

            //1）验证信息是否已经存在有效期内临时健康卡
            //2) 存在则返回当前临时健康卡信息
            //3) 不存在创建新临时电子健康卡，新增临时健康卡二维码操作
            //3.1) 获取机构信息
            //3.2) jWT加密信息,存储身份证号码、机构代码、有效日期
            var result = rc.GetInstanceByUnknownCode<TempeCardApplyResponse>(arg);

            //基础验证

            if (!"T0001".Equals(arg.Header.TradeCode, StringComparison.OrdinalIgnoreCase))
            {
                return result.Error(ErrorCode.LogicalError, "traceCode:" + (arg.Header.TradeCode ?? "") + "无效");
            }
            var appInfo = await _manageDb.AppInfos.FirstOrDefaultAsync(i => i.app_key == arg.Header.AppId);
            if (appInfo == null)
            {
                return result.Error(ErrorCode.LogicalError, "无效AppId");
            }

            var orgEntity = await _manageDb.Organziation.FirstOrDefaultAsync(i => i.Id.Equals(appInfo.org_id));

            var orgName = (orgEntity?.Manag_Orgname)??"";
            var manag_orgcode = (orgEntity?.Manag_Orgcode) ?? ""; ;

            if (!arg.Validate(out var message))
                return result.Error(ErrorCode.LogicalError, message);
            if(!arg.Data.Validate(out var errMsg))
            {
                return result.Error(ErrorCode.LogicalError, errMsg);
            }


            //验证身份证判断是否已申请临时健康卡
            var entity = _erhcDb.TempeCards.FirstOrDefault(i => i.IdCardNo == arg.Data.IdCardValue
                                                && i.Name == arg.Data.Name
                                                && i.IdCardType == arg.Data.IdCardType
                                                && !string.IsNullOrEmpty(i.Deadline)
                                                &&Convert.ToDateTime(i.Deadline)>DateTime.Now);
            if (entity == null)
            {
                string empi = RandomOperate.Generate(64);
                var exist = _erhcDb.TempeCards.FirstOrDefault(i => i.Empi == empi);
                while (exist != null)
                {
                    empi = RandomOperate.Generate(64);
                    exist = _erhcDb.TempeCards.FirstOrDefault(i => i.Empi == empi);
                }

                string qrCodeType = "9"; //临时健康卡
                string baseImg = QRCodeBase64($"{empi}:{qrCodeType}");
                entity = new TempeCardEntity
                {
                    Address = arg.Data.Address,
                    Citizenship = arg.Data.Citizenship,
                    CreatedAt = DateTime.Now,
                    DataSources = arg.Header.DataSources,
                    Empi = empi,
                    ErhcCardNo = RandomOperate.Generate(64),
                    Deadline = arg.Data.Deadline,
                    IdCardNo = arg.Data.IdCardValue,
                    IdCardType = arg.Data.IdCardType,
                    IdCardValue = arg.Data.IdCardValue,
                    IsApply = "1",
                    IssuerOrgCode = manag_orgcode,
                    Name = arg.Data.Name,
                    Nationality = arg.Data.Nationality,
                    QrCodeType = qrCodeType, //临时静态二维码
                    Token = arg.Header.Token,
                    QrCodeImageData = baseImg,
                    UpdatedAt = DateTime.Now,
                    Sex = arg.Data.Sex,
                    Tel = arg.Data.Tel,
                    AppMode = arg.Data.AppMode,
                    BirthPlace = arg.Data.BirthPlace,
                    Domicile = arg.Data.Domicile,
                    TerminalType = arg.Data.TerminalType,
                    IssuerOrgName = orgName
                };
                _erhcDb.TempeCards.Add(entity);
                await _erhcDb.SaveChangesAsync();
            }

            result.Data = new TempeCardApplyResponse
            {
                EMPI = entity.Empi,
                ErhcCardNo = entity.ErhcCardNo,
                IdCardNo = entity.IdCardNo,
                Address = entity.Address,
                Citizenship = entity.Citizenship,
                IdCardType = entity.IdCardType,
                IdCardValue = entity.IdCardValue,
                Name = entity.Name,
                IssuerOrgCode = entity.IssuerOrgCode,
                Deadline = DateTime.Parse(entity.Deadline),
                QrCodeImageInfo = entity.QrCodeImageData,
                QrCodeType = entity.QrCodeType,
                QrCodeVaildDateTime = (int)(DateTime.Parse(entity.Deadline) - DateTime.Now).TotalMinutes,
                Nationality = entity.Nationality,
                Sex = entity.Sex,
                Tel = entity.Tel,
                IssuerOrgName = entity.IssuerOrgName
            };

            result.Msg = "操作成功";
            result.Code = (int)ResultCodes.Succeed;
            return result;
        }

        /// <summary>
        /// 更新临时健康卡信息
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public async Task<ApiResultEx<TempeCardUpdateResponse>> TempeCardUpdate(ApiArgument<TempeCardModifyArgument> arg)
        {

            var result = rc.GetInstanceByUnknownCode<TempeCardUpdateResponse>(arg);

            if (!"30002".Equals(arg.Header.TradeCode, StringComparison.OrdinalIgnoreCase))
            {
                return result.Error(ErrorCode.LogicalError, "traceCode:" + (arg.Header.TradeCode ?? "") + "无效");
            }

            var appInfo = await _manageDb.AppInfos.FirstOrDefaultAsync(i => i.app_key == arg.Header.AppId);

            if (appInfo == null)
            {
                return result.Error(ErrorCode.LogicalError, "无效AppId");
            }

            if (!arg.Validate(out var message))
            {
                result.Error(ErrorCode.LogicalError, message);
                return result;
            }
            if (!arg.Data.Validate(out var errMsg))
            {
                return result.Error(ErrorCode.LogicalError, errMsg);
            }

            if (string.IsNullOrEmpty(arg.Data.ErhcCardNo))
            {
                return result.Error(ErrorCode.LogicalError, "临时电子健康卡ID不能空");
            }
            if (string.IsNullOrEmpty(arg.Data.QrCodeInfo))
            {
                return result.Error(ErrorCode.LogicalError, "临时电子健康卡二维码内容不能空");
            }

            string[] arrcodeArray = arg.Data.QrCodeInfo.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (arrcodeArray.Length < 2)
            {
                return result.Error(ErrorCode.LogicalError, "临时电子健康卡二维码内容错误");
            }

            string empi = arrcodeArray[0];

            var entity = await _erhcDb.TempeCards.FirstOrDefaultAsync(i => i.Empi == empi);
            if (entity == null)
            {
                return result.Error(ErrorCode.LogicalError, "还未创建临时电子健康卡");
            }
            

            entity.Citizenship = arg.Data.Citizenship;
            entity.Nationality = arg.Data.Nationality;
            entity.Tel = arg.Data.Tel;
            entity.Address = arg.Data.Address;
            entity.Sex = arg.Data.Sex;
            entity.BirthPlace = arg.Data.BirthPlace;
            entity.Domicile = arg.Data.Domicile;
            entity.AppMode = arg.Data.AppMode;
            entity.TerminalType = arg.Data.TerminalType;

            _erhcDb.TempeCards.Update(entity);
            await _erhcDb.SaveChangesAsync();

            result.Msg = "操作成功";
            result.Code = (int)ResultCodes.Succeed;
            result.Data = new TempeCardUpdateResponse
            {
                EMPI = entity.Empi,
                Deadline = DateTime.Parse(entity.Deadline),
                ErhcCardNo = entity.ErhcCardNo
            };
            return result;
        }


        #region 临时电子健康卡验证操作
        /// <summary>
        /// 验证临时健康卡信息
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public async Task<ApiResultEx<TempeCardVerifyReponse>> TempeCardVerify(ApiArgument<TempeCardVerifyArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<TempeCardVerifyReponse>(arg);

            if (!"12001".Equals(arg.Header.TradeCode, StringComparison.OrdinalIgnoreCase))
            {
                return result.Error(ErrorCode.LogicalError, "traceCode:" + (arg.Header.TradeCode ?? "") + "无效");
            }

            var appInfo = await _manageDb.AppInfos.FirstOrDefaultAsync(i => i.app_key == arg.Header.AppId);
            if (appInfo == null)
            {
                return result.Error(ErrorCode.LogicalError, "无效AppId");
            }
            var orgEntity = await _manageDb.Organziation.FirstOrDefaultAsync(i => i.Id.Equals(appInfo.id));
            var manag_orgcode = (orgEntity?.Manag_Orgname)??"";

            if (!arg.Validate(out var message))
            {
                result.Error(ErrorCode.LogicalError, message);
                return result;
            }
            if (!arg.Data.Validate(out var errMsg))
            {
                result.Error(ErrorCode.LogicalError, errMsg);
                return result;
            }
            //1)解密JWT内容
            //var payload = new JwtBuilder()
            //    .WithSecret(secret)
            //    .MustVerifySignature()
            //    .Decode<IDictionary<string, object>>(arg.Data.QrCodeInfo);
            //"idCardValue" 身份证号码
            //"issuerOrgCode" 机构代码
            if (string.IsNullOrEmpty(arg.Data.QrCodeInfo))
            {
                return result.Error(ErrorCode.LogicalError, "临时电子健康卡二维码内容不能空");
            }
            string[] payload = arg.Data.QrCodeInfo.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (payload.Length < 2)
            {
                return result.Error(ErrorCode.LogicalError, "临时电子健康卡二维码内容有误");
            }


            var empi = payload[0];
            var qrCodeType = payload[1];
            //2)判断是否检验成功
            //if (string.IsNullOrEmpty(manag_orgcode))
            //{
            //    return result.Error(ErrorCode.LogicalError, "机构代码不能为空");
            //}
            //if (!arg.Header.OrganizationId.Equals(manag_orgcode))
            //{
            //    return result.Error(ErrorCode.LogicalError, "该二维码信息不能跨机构使用");
            //}

            //3)获取临时健康卡信息
            var tempCardInfo = _erhcDb.TempeCards.FirstOrDefault(i => i.Empi != null 
                                                                      && i.Empi == empi 
                                                                      && i.QrCodeType == qrCodeType
                                                                      &&!string.IsNullOrEmpty(i.Deadline)
                                                                      && Convert.ToDateTime(i.Deadline)>DateTime.Now);
            if (tempCardInfo == null)
            {
                return result.Error(ErrorCode.LogicalError, "临时电子健康卡不存在或已失效");
            }
            //4)保存数据
            TempHospitalEntity entity = new TempHospitalEntity
            {
                address = tempCardInfo.Address,
                appmode = arg.Data.AppMode,
                citizenship = tempCardInfo.Citizenship,
                create_date = DateTime.Now,
                dep_code = arg.Data.DepCode,
                dep_type = arg.Data.DepType,
                empi = tempCardInfo.Empi,
                erhc_cardno = tempCardInfo.ErhcCardNo,
                erhc_end_date_time = DateTime.Parse(tempCardInfo.Deadline),
                idcard_no = tempCardInfo.IdCardNo,
                idcard_type = tempCardInfo.IdCardType,
                idcard_value = tempCardInfo.IdCardValue,
                issuer_orgcode = arg.Header.OrganizationId,
                med_type = arg.Data.MedType,
                nationality = tempCardInfo.Nationality,
                med_stepcode = arg.Data.MedStepCode,
                qrcode_info = arg.Data.QrCodeInfo,
                sex = tempCardInfo.Sex,
                name = tempCardInfo.Name,
                tel = tempCardInfo.Tel,
                terminal_type = arg.Data.TerminalType,
                //user_sign = arg.Header.Sign
            };
            _erhcDb.Temphospital.Add(entity);
            await _erhcDb.SaveChangesAsync();
            result.Msg = "操作成功";
            result.Code = (int)ResultCodes.Succeed;
            result.Data = new TempeCardVerifyReponse
            {
                Name = entity.name,
                Address = entity.address,
                Sex = entity.sex,
                Citizenship = entity.citizenship,
                Deadline = entity.erhc_end_date_time,
                EMPI = entity.empi,
                ErhcCardNo = entity.erhc_cardno,
                IdCardNo = entity.idcard_no,
                IdCardType = entity.idcard_type,
                IdCardValue = entity.idcard_value,
                IssuerOrgCode = entity.issuer_orgcode,
                Nationality = entity.name,
                Tel = entity.tel,
                UserSign = entity.user_sign

            };
            return result;
        }


        /// <summary>
        /// 临时健康卡信息查询
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public async Task<ApiResultEx<TempeCardQuerySingleResponse>> TempeCardQuerySingle(ApiArgument<TempeCardQuerySingleArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<TempeCardQuerySingleResponse>(arg);

            if (!"30005".Equals(arg.Header.TradeCode, StringComparison.OrdinalIgnoreCase))
            {
                return result.Error(ErrorCode.LogicalError, "traceCode:" + (arg.Header.TradeCode ?? "") + "无效");
            }

            var appInfo = await _manageDb.AppInfos.FirstOrDefaultAsync(i => i.app_key == arg.Header.AppId);
            if (appInfo == null)
            {
                return result.Error(ErrorCode.LogicalError, "无效AppId");
            }
            var orgEntity = await _manageDb.Organziation.FirstOrDefaultAsync(i => i.Id == appInfo.org_id);
            var manag_orgcode = (orgEntity?.Manag_Orgname) ?? "";


            var entity = _erhcDb.TempeCards.FirstOrDefault(i =>
                i.IdCardType == arg.Data.IdCardType && i.IdCardValue == arg.Data.IdCardValue
                                                    && i.Name == arg.Data.Name
                                                    &&!string.IsNullOrEmpty(i.Deadline)
                                                    &&Convert.ToDateTime(i.Deadline)>DateTime.Now);
            if (entity == null)
            {
                return result.Error(ErrorCode.LogicalError, "未注册临时电子健康卡或者已失效");
            }

            result.Data = new TempeCardQuerySingleResponse
            {
                EMPI = entity.Empi,
                ErhcCardNo = entity.ErhcCardNo,
                IdCardNo = entity.IdCardNo,
                Sex = entity.Sex,
                Tel = entity.Tel
            };
            result.Code = (int)ResultCodes.Succeed;
            result.Msg = "操作成功";
            return result;
        }

        /// <summary>
        /// 根据二维码内容查询信息
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public async Task<ApiResultEx<TempeCardQuerySingleResponse>> TempeCardQueryQrCodeSingle(ApiArgument<TempeCardQueryQrCodeSingleArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<TempeCardQuerySingleResponse>(arg);

            if (!"30005".Equals(arg.Header.TradeCode, StringComparison.OrdinalIgnoreCase))
            {
                return result.Error(ErrorCode.LogicalError, "traceCode:" + (arg.Header.TradeCode ?? "") + "无效");
            }
            var appInfo = await _manageDb.AppInfos.FirstOrDefaultAsync(i => i.app_key == arg.Header.AppId);
            if (appInfo == null)
            {
                return result.Error(ErrorCode.LogicalError, "无效AppId");
            }

            string[] arr = arg.Data.QrCodeInfo.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length < 2)
            {
                return result.Error(ErrorCode.LogicalError, "无效二维码内容");
            }

            string empi = arr[0];
            string qrCodeType = arr[1];

            var entity = await _erhcDb.TempeCards.FirstOrDefaultAsync(i => i.Empi == empi 
                                                                           && i.QrCodeType == qrCodeType
                                                                           && Convert.ToDateTime(i.Deadline)>DateTime.Now);
            if (entity == null)
            {
                return result.Error(ErrorCode.LogicalError, "临时电子健康卡不存在或已失效");
            }

            result.Data = new TempeCardQuerySingleResponse
            {
                EMPI = entity.Empi,
                ErhcCardNo = entity.ErhcCardNo,
                IdCardNo = entity.IdCardNo,
                Sex = entity.Sex,
                Tel = entity.Tel
            };
            result.Code = (int)ResultCodes.Succeed;
            result.Msg = "操作成功";
            return result;
        }

        #endregion



        #region 二维码

        /// <summary>
        /// 返回二维码base64位字符串
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private string QRCodeBase64(string message)
        {
            string logo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "erweima.png");
            using (Bitmap btm = GetQRCode(message, 6, logo, 20, 1, false, 5))
            {
                return ImgToBase64String(btm);
            }
        }




        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="pixel">像素点大小</param>
        /// <param name="icon_path">图标路径</param>
        /// <param name="icon_size">图标尺寸</param>
        /// <param name="icon_border">图标边框厚度</param>
        /// <param name="white_edge">二维码白边</param>
        /// <param name="version"></param>
        /// <returns>位图</returns>
        private Bitmap GetQRCode(string msg, int pixel, string icon_path, int icon_size, int icon_border, bool white_edge, int version)
        {

            QRCoder.QRCodeGenerator code_generator = new QRCoder.QRCodeGenerator();
            QRCoder.QRCodeData code_data = code_generator.CreateQrCode(msg, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(code_data);

            Bitmap icon = new Bitmap(icon_path);
            Bitmap bmp = code.GetGraphic(pixel, Color.Black, Color.White, icon, icon_size, icon_border, white_edge);

            return bmp;
        }
        /// <summary>
        /// 图片转base64字符串
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        private string ImgToBase64String(Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();
            String strbaser64 = Convert.ToBase64String(arr);
            //"data:image/jpeg;base64," 
            return strbaser64;
        }
        #endregion

        #region 身份证号码验证

        /// <summary>
        /// 身份证验证
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private bool ValidCardIdValue(string card)
        {
            if (card.Length.Equals(15))
            {
                return CheckIDCard15(card);
            }
            else if (card.Length.Equals(18))
            {
                return CheckIDCard18(card);
            }
            return false;
        }


        /// <summary>
        /// 18位身份证验证
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private bool CheckIDCard18(string Id)
        {
            long n = 0;
            if (long.TryParse(Id.Remove(17), out n) == false || n < Math.Pow(10, 16) ||
                long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;
            }

            string address =
                "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2), StringComparison.Ordinal) == -1)
            {
                return false;
            }

            string birth = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;
            }

            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] Ai = Id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());
            }

            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != Id.Substring(17, 1).ToLower())
            {
                return false;
            }

            return true; //正确
        }

        /// <summary>
        /// 15位身份证号码验证
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private bool CheckIDCard15(string Id)
        {
            long n = 0;
            if (long.TryParse(Id, out n) == false || n < Math.Pow(10, 14))
            {
                return false;
            }
            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(Id.Remove(2), StringComparison.Ordinal) == -1)
            {
                return false;
            }
            string birth = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;
            }
            return true;//正确
        }
        #endregion

        //private TempecardDataAccess db => new TempecardDataAccess();
        //private TemphospitalDataAccess dbVerify => new TemphospitalDataAccess();
        //private ResultCodeHandler rc => IocHelper.Create<ResultCodeHandler>();
    }

    /// <summary>
    /// 临时电子健康卡服务接口
    /// </summary>
    public interface ITempHealthCardService: IRegisterScopeServices
    {
        /// <summary>
        /// 临时健康卡信息注册
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        Task<ApiResultEx<TempeCardApplyResponse>> TempeCardApply(ApiArgument<TempeCardApplyArgument> arg);

        /// <summary>
        /// 临时电子健康卡更新
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        Task<ApiResultEx<TempeCardUpdateResponse>> TempeCardUpdate(ApiArgument<TempeCardModifyArgument> arg);

        /// <summary>
        /// 临时电子健康卡验证
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        Task<ApiResultEx<TempeCardVerifyReponse>> TempeCardVerify(ApiArgument<TempeCardVerifyArgument> arg);

        /// <summary>
        /// 临时电子健康卡查询
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        Task<ApiResultEx<TempeCardQuerySingleResponse>> TempeCardQuerySingle(ApiArgument<TempeCardQuerySingleArgument> arg);

        Task<ApiResultEx<TempeCardQuerySingleResponse>> TempeCardQueryQrCodeSingle(ApiArgument<TempeCardQueryQrCodeSingleArgument> arg);
    }
}