
namespace WzHealthCard.Infrastructure.Api.Models
{
    using System.Collections.Generic;

    public abstract class BaseDictSettings
    {
        protected Dictionary<string, string> dict = new Dictionary<string, string>();

        public virtual string GetValue(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return string.Empty;
            }

            string result;
            var isGot = dict.TryGetValue(code, out result);
            return isGot ? result : $"unknown[{code}]";
        }
    }

    public class DistrictSettings : BaseDictSettings
    {
        public DistrictSettings()
        {
            dict.Add("330301", "市辖区");
            dict.Add("330302", "鹿城区");
            dict.Add("330303", "龙湾区");
            dict.Add("330304", "瓯海区");
            dict.Add("330305", "洞头区");
            dict.Add("330324", "永嘉县");
            dict.Add("330326", "平阳县");
            dict.Add("330327", "苍南县");
            dict.Add("330328", "文成县");
            dict.Add("330329", "泰顺县");
            dict.Add("330381", "瑞安市");
            dict.Add("330382", "乐清市");
        }
    }

    public class MsStepSettings : BaseDictSettings
    {
        public MsStepSettings()
        {
            dict.Add("010101", "挂号");
            dict.Add("010102", "诊断");
            dict.Add("010103", "取药");
            dict.Add("010104", "检查");
            dict.Add("010105", "收费");
            dict.Add("010106", "开放");
            dict.Add("010107", "手术");
            dict.Add("000000", "其他");
        }
    }

    public class AppModeSettings : BaseDictSettings
    {
        public AppModeSettings()
        {
            dict.Add("1", "App在线申请");
            dict.Add("2", "医疗卫生机构自助机申请");
            dict.Add("3", "医疗卫生机构窗口申请");
            dict.Add("4", "批量预生成");
        }
    }
}
