using System;
using System.Linq;
using WzHealthCard.Refactor.Api.Common;

namespace Xuhui.Internetpro.WzHealthCardService
{
    public partial class TempeCardModifyArgument
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
            if (string.IsNullOrWhiteSpace(Name))
                result.AddNoEmpty("姓名", nameof(Name));
            else
            {
                if (Name.Length > 50)
                    result.Add("姓名", nameof(Name), $"不能多于50个字");
            }
            if (string.IsNullOrWhiteSpace(IdCardType))
                result.AddNoEmpty("身份证件类型", nameof(IdCardType));
            else
            {
                if (IdCardType.Length > 2)
                    result.Add("身份证件类型", nameof(IdCardType), $"不能多于2个字");
            }
            if (string.IsNullOrWhiteSpace(IdCardValue))
                result.AddNoEmpty("证件号码", nameof(IdCardValue));
            else
            {
                if (IdCardValue.Length > 32)
                    result.Add("证件号码", nameof(IdCardValue), $"不能多于32个字");
            }
            if (!string.IsNullOrWhiteSpace(Citizenship))
            {
                if (Citizenship.Length > 3)
                    result.Add("国籍", nameof(Citizenship), $"不能多于3个字");
            }
            if (!string.IsNullOrWhiteSpace(Nationality))
            {
                if (Nationality.Length > 2)
                    result.Add("民族", nameof(Nationality), $"不能多于2个字");
            }

            if (!string.IsNullOrWhiteSpace(Tel))
            {
                if (Tel.Length > 16)
                    result.Add("手机号码", nameof(Tel), $"不能多于16个字");
            }
            if (!string.IsNullOrWhiteSpace(Address))
            {
                if (Address.Length > 200)
                    result.Add("联系地址", nameof(Address), $"不能多于200个字");
            }
            if (string.IsNullOrWhiteSpace(Sex))
                result.AddNoEmpty("性别", nameof(Sex));
            else
            {
                if (Sex.Length > 2)
                    result.Add("性别", nameof(Sex), $"不能多于2个字");
            }
            if (!string.IsNullOrWhiteSpace(BirthPlace))
            {
                if (BirthPlace.Length > 200)
                    result.Add("出生地", nameof(BirthPlace), $"不能多于200个字");
            }
            if (!string.IsNullOrWhiteSpace(Domicile))
            {
                if (Domicile.Length > 250)
                    result.Add("户籍所在地址", nameof(Domicile), $"不能多于250个字");
            }
            if (string.IsNullOrWhiteSpace(AppMode))
                result.AddNoEmpty("APP 申请方式", nameof(AppMode));
            else
            {
                if (AppMode.Length > 2)
                    result.Add("APP 申请方式", nameof(AppMode), $"不能多于2个字");
            }
            if (string.IsNullOrWhiteSpace(TerminalType))
                result.AddNoEmpty("终端类型", nameof(TerminalType));
            else
            {
                if (TerminalType.Length > 2)
                    result.Add("终端类型", nameof(TerminalType), $"不能多于2个字");
            }

            if (string.IsNullOrWhiteSpace(Deadline))
            {
                result.AddNoEmpty("有效日期", nameof(Deadline));
            }
            else
            {
                DateTime endDate;
                if (!DateTime.TryParse(Deadline, out endDate))
                {
                    result.Add("有效日期", nameof(Deadline), $"格式不正确");
                }

            }
            return result;
        }
        #endregion
    }
}