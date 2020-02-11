namespace WzHealthCard.Refactor.Api.Common
{
    public static class CommonConvert
    {
        /// <summary>
        /// 市民卡状态
        /// 0电子社保卡已签发
        /// 1电子健康卡已签发
        /// 2电子社保卡电子健康卡都已签发
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string ConvertToSocialCardState(string state)
        {
            switch (state)
            {
                case "0"://电子社保卡已签发
                case "2"://电子社保卡电子健康卡都已签发
                    return "1";
                case "1"://电子健康卡已签发
                    return "0";
                default:
                    return "0";
            }
        }
    }
}