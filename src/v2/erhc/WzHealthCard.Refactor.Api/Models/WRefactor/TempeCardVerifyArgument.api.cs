using System.Linq;
using WzHealthCard.Refactor.Api.Common;
using WzHealthCard.Refactor.Api.Models.Refactor;

namespace Xuhui.Internetpro.WzHealthCardService
{
    public partial class TempeCardVerifyArgument 
    {
        #region 数据校验
        /// <summary>数据校验</summary>
        /// <param name="message">返回的消息</param>
        /// <returns>成功则返回真</returns>
        public bool Validate(out string message)
        {
            var result = Validate();
            message = result.succeed ? null : result.Items.Where(p => !p.succeed).Select(p => $"{p.Caption}:{ p.Message}").LinkToString(';');
            return string.IsNullOrEmpty(message);
        }


        /// <summary>
        /// 数据校验
        /// </summary>
        /// <returns>数据校验对象</returns>
        public virtual ValidateResultEx Validate()
        {
            var result = new ValidateResultEx();

            if (string.IsNullOrWhiteSpace(QrCodeInfo))
                result.AddNoEmpty("临时电子健康卡二维码内容", nameof(QrCodeInfo));
            else
            {
                //if (QrCodeInfo.Length >130)
                //    result.Add("临时电子健康卡二维码内容", nameof(QrCodeInfo), $"不能多于130个字");
            }

            if (string.IsNullOrWhiteSpace(MedType))
                result.AddNoEmpty("就诊类型", nameof(MedType));
            else
            {
                if (MedType.Length > 2)
                    result.Add("就诊类型", nameof(MedType), $"不能多于2个字");
            }

            if (string.IsNullOrWhiteSpace(DepType))
                result.AddNoEmpty("科室类型", nameof(DepType));
            else
            {
                if (DepType.Length > 2)
                    result.Add("科室类型", nameof(DepType), $"不能多于2个字");
            }

            if (string.IsNullOrWhiteSpace(DepCode))
                result.AddNoEmpty("刷卡科室代码", nameof(DepCode));
            else
            {
                if (DepCode.Length > 4)
                    result.Add("刷卡科室代码", nameof(DepCode), $"不能多于4个字");
            }

            if (string.IsNullOrWhiteSpace(MedStepCode))
                result.AddNoEmpty("诊疗环节代码", nameof(MedStepCode));
            else
            {
                if (MedStepCode.Length > 10)
                    result.Add("诊疗环节代码", nameof(MedStepCode), $"不能多于10个字");
            }

            if (string.IsNullOrWhiteSpace(AppMode))
                result.AddNoEmpty("APP申请方式", nameof(AppMode));
            else
            {
                if (AppMode.Length > 2)
                    result.Add("APP申请方式", nameof(AppMode), $"不能多于2个字");
            }

            if (string.IsNullOrWhiteSpace(TerminalType))
                result.AddNoEmpty("终端类型", nameof(TerminalType));
            else
            {
                if (TerminalType.Length > 2)
                    result.Add("终端类型", nameof(TerminalType), $"不能多于2个字");
            }
            return result;
        }


        #endregion

        #region 参数转化
        /// <summary>
        /// 转换参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ApiArgument<TempeCardVerifyArgument> Converter( 
            ApiArgument<ErhcmemberVerifyHospitalArgument> model)
        {
            ApiArgument<TempeCardVerifyArgument> argument = new ApiArgument<TempeCardVerifyArgument>
            {
                Header=model.Header,
                Data=new TempeCardVerifyArgument
                {
                    AppMode=model.Data.Appmode,
                    DepCode=model.Data.DepCode,
                    DepType=model.Data.DepType,
                    MedStepCode=model.Data.MedStepcode,
                    MedType=model.Data.MedType,
                    QrCodeInfo=model.Data.QrcodeInfo,
                    TerminalType=model.Data.TerminalType
                }
            };
            return argument;
        }
        #endregion
    }
}