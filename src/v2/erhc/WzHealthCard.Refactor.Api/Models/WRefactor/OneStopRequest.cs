namespace Xuhui.Internetpro.WzHealthCardService
{
    public class OneStopRequest
    {
        public string Name { get; set; }

        public string IdCardNo { get; set; }

    }

    /// <summary>
    /// 新增请求参数
    /// </summary>
    public class CreateOneStopRequest
    {
        public string Name { get; set; }

        public string IdCardNo { get; set; }

        public string UserId { get; set; }
    }

}