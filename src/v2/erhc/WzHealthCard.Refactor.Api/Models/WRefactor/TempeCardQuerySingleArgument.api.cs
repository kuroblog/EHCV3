using System.Linq;
using WzHealthCard.Refactor.Api.Common;
using WzHealthCard.Refactor.Api.Models.Refactor;

namespace Xuhui.Internetpro.WzHealthCardService
{
    public partial class TempeCardQuerySingleArgument
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
            if (string.IsNullOrWhiteSpace(IdCardType))
            {
                result.AddNoEmpty("证件类型", nameof(IdCardType));
            }
            else
            {
                if (IdCardType.Length > 2)
                {
                    result.Add("证件类型", nameof(IdCardType), "长度无效");
                }
            }
            if (string.IsNullOrWhiteSpace(IdCardValue))
            {
                result.AddNoEmpty("证件号", nameof(IdCardValue));
            }
            else
            {
                if (IdCardValue.Length > 20)
                {
                    result.Add("证件号", nameof(IdCardValue), "长度无效");
                }
            }
            if (string.IsNullOrWhiteSpace(Name))
            {
                result.AddNoEmpty("姓名", nameof(Name));
            }
            else
            {
                if (Name.Length > 50)
                {
                    result.Add("姓名", nameof(Name), "长度无效");
                }
            }
            return result;
        }
        #endregion

    }
}