namespace WzHealthCard.Refactor.Api.Models
{
    public class AppModeApplyArg : AgeUseArg { }

    public class AppModeApplyResult : StepUseResult { }

    public class CityApplyArg : AgeUseArg { }

    public class CityApplyResult : StepUseResult { }

    public class MonthApplyArg : MonthUseArg { }

    public class MonthApplyResult : MonthUseResult { }

    public class TotalApplyArg : AgeUseArg { }

    public class MonthUseArg 
    {
        public string city { get; set; }

        public string year { get; set; }
    }

    public class MonthUseResult
    {
        public int month { get; set; }

        public int quantity { get; set; }
    }

    public class CityUseArg : AgeUseArg { }

    public class CityUseResult : StepUseResult { }

    public class StepUseArg : AgeUseArg { }

    public class StepUseResult
    {
        public string code { get; set; }

        public string name { get; set; }

        public int quantity { get; set; }
    }

    public class AgeUseArg 
    {
        
        public string city { get; set; }

        public string begin { get; set; }

        public string end { get; set; }
    }

    public class AgeUseResult
    {
        public int? age { get; set; }

        public int quantity { get; set; }
    }
}