
using Xuhui.Internetpro.WzHealthCardService;

namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using WzHealthCard.Refactor.Api.DataAccess.Erhc;
    using WzHealthCard.Refactor.Api.Models.Refactor;
    using WzHealthCard.Refactor.Api.Repositories.Erhc;
    using WzHealthCard.Refactor.Api.Repositories.ErhcManage;
    using WzHealthCard.Refactor.Api.UnitOfWorks;

    public interface ITempHealthCardService
    {
        /// <summary>
        /// 临时电子健康卡验证
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        ApiResultEx<TempeCardVerifyReponse> TempeCardVerify(ApiArgument<TempeCardVerifyArgument> arg);
    }

    public class TempHealthCardServiceLogical : ITempHealthCardService
    {
        private readonly ResultCodeHandler rc;
        private readonly ErhcUnitOfWork erhcUow;
        private readonly AppInfoRepository appRepo;
        private readonly TempCardRepository tmpCardRepo;
        private readonly TempHospitalRepository tmpHospRepo;

        public TempHealthCardServiceLogical(ResultCodeHandler rc, ErhcUnitOfWork erhcUow, AppInfoRepository appRepo, TempCardRepository tmpCardRepo, TempHospitalRepository tmpHospRepo)
        {
            this.rc = rc;
            this.erhcUow = erhcUow;
            this.appRepo = appRepo;
            this.tmpCardRepo = tmpCardRepo;
            this.tmpHospRepo = tmpHospRepo;
        }

        public ApiResultEx<TempeCardVerifyReponse> TempeCardVerify(ApiArgument<TempeCardVerifyArgument> arg)
        {
            var result = rc.GetInstanceByUnknownCode<TempeCardVerifyReponse>(arg);

            if (!"12001".Equals(arg.Header.TradeCode, StringComparison.OrdinalIgnoreCase))
            {
                return result.Error(ErrorCode.LogicalError, "traceCode:" + (arg.Header.TradeCode ?? "") + "无效");
            }

            var appInfo = appRepo.View.FirstOrDefault(i => i.app_key == arg.Header.AppId);
            if (appInfo == null)
            {
                return result.Error(ErrorCode.LogicalError, "无效AppId");
            }

            //var manag_orgcode = (appDb.ExecuteScalar("select manag_orgcode from `tb_org_organization` where id=" + appInfo.OrgId) ?? "").ToString();

            if (!arg.Validate(out var message))
            {
                result.Error(ErrorCode.LogicalError, message);
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
            var tempCardInfo = tmpCardRepo.View.FirstOrDefault(i => i.empi != null && i.empi == empi && i.qr_code_type == qrCodeType);
            if (tempCardInfo == null)
            {
                return result.Error(ErrorCode.LogicalError, "临时电子健康卡不存在");
            }
            //4)保存数据
            var entity = new TempHospitalEntity
            {
                address = tempCardInfo.address,
                appmode = arg.Data.AppMode,
                citizenship = tempCardInfo.citizenship,
                create_date = DateTime.Now,
                dep_code = arg.Data.DepCode,
                dep_type = arg.Data.DepType,
                empi = tempCardInfo.empi,
                erhc_cardno = tempCardInfo.erhc_card_no,
                erhc_end_date_time = DateTime.Parse(tempCardInfo.deadline),
                idcard_no = tempCardInfo.id_card_no,
                idcard_type = tempCardInfo.id_card_type,
                idcard_value = tempCardInfo.id_card_value,
                issuer_orgcode = arg.Header.OrganizationId,
                med_type = arg.Data.MedType,
                nationality = tempCardInfo.nationality,
                med_stepcode = arg.Data.MedStepCode,
                qrcode_info = arg.Data.QrCodeInfo,
                sex = tempCardInfo.sex,
                name = tempCardInfo.name,
                tel = tempCardInfo.tel,
                terminal_type = arg.Data.TerminalType,
                user_sign = arg.Header.Sign
            };
            //dbVerify.Insert(entity);

            tmpHospRepo.Insert(entity);
            var r1 = erhcUow.Commit();

            if (r1 > 0)
            {
                result.Msg = "操作成功";
                result.Code = (int)ResultCodes.Succeed;
                result.Data = new TempeCardVerifyReponse
                {
                    Name = entity.name,
                    Address = entity.address,
                    Sex = entity.sex,
                    Citizenship = entity.citizenship,
                    Deadline = entity.erhc_end_date_time == null ? DateTime.Now : entity.erhc_end_date_time.Value,
                    EMPI = entity.empi,
                    ErhcCardNo = entity.erhc_cardno,
                    IdCardNo = entity.idcard_no,
                    IdCardType = entity.idcard_type,
                    IdCardValue = entity.idcard_value,
                    IssuerOrgCode = entity.issuer_orgcode,
                    Nationality = entity.nationality,
                    Tel = entity.tel,
                    UserSign = entity.user_sign
                };
            }
            else
            {

            }

            return result;
        }
    }
}
