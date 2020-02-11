
namespace WzHealthCard.Refactor.Api.Services.Refactor
{
    using WzHealthCard.Refactor.Api.Models.Refactor;

    public interface IErhcService
    {
        int ServiceType { get; }

        void CreateHealthCard(ApiArgument<ErhcmemberApplyArgument> arg, ApiResultEx<ErhcmemberApplyResponse> result);

        void ReadHealthCard(ApiArgument<ErhcmemberApplyQueryArgument> arg, ApiResultEx<ErhcmemberApplyQueryResponse> result);

        void DeleteHealthCard(ApiArgument<ErhcmemberCancelArgument> arg, ApiResultEx result);

        void UpdateHealthCard(ApiArgument<ErhcmemberModifyArgument> arg, ApiResultEx<ErhcmemberModifyResponse> result);

        void QueryDynamicQrCode(ApiArgument<ErhcmemberQrCodeDynamicArgument> arg, ApiResultEx<ErhcmemberQrCodeDynamicResponse> result);

        void QueryStaticQrCode(ApiArgument<ErhcmemberQrCodeStaticArgument> arg, ApiResultEx<ErhcmemberQrCodeStaticResponse> result);

        void VerifyByHospital(ApiArgument<ErhcmemberVerifyHospitalArgument> arg, ApiResultEx<ErhcmemberVerifyResponse> result);

        void QueryServerTime(ApiArgument arg, ApiResultEx<HostTimeResponse> result);

        ApiResultEx<ErhcmemberApplyBySmallAppResponse> CreateHealthCardBySmallApp(ApiArgument<ErhcmemberApplyBySmallAppArgument> arg, ApiResultEx<ErhcmemberApplyBySmallAppResponse> result);
    }

    public class ErhcTranService : IErhcService
    {
        public int ServiceType => 3;

        private readonly ResultCodeHandler rc;

        public ErhcTranService(ResultCodeHandler rc)
        {
            this.rc = rc;
        }

        public void CreateHealthCard(ApiArgument<ErhcmemberApplyArgument> arg, ApiResultEx<ErhcmemberApplyResponse> result) { }

        public void ReadHealthCard(ApiArgument<ErhcmemberApplyQueryArgument> arg, ApiResultEx<ErhcmemberApplyQueryResponse> result) { }

        public void DeleteHealthCard(ApiArgument<ErhcmemberCancelArgument> arg, ApiResultEx result) { }

        public void UpdateHealthCard(ApiArgument<ErhcmemberModifyArgument> arg, ApiResultEx<ErhcmemberModifyResponse> result) { }

        public void QueryDynamicQrCode(ApiArgument<ErhcmemberQrCodeDynamicArgument> arg, ApiResultEx<ErhcmemberQrCodeDynamicResponse> result) =>
            result.Initialization(ResultCodes.AccessServiceFailedViaAppId, null, "");

        public void QueryStaticQrCode(ApiArgument<ErhcmemberQrCodeStaticArgument> arg, ApiResultEx<ErhcmemberQrCodeStaticResponse> result) { }

        public void VerifyByHospital(ApiArgument<ErhcmemberVerifyHospitalArgument> arg, ApiResultEx<ErhcmemberVerifyResponse> result) { }

        public void QueryServerTime(ApiArgument arg, ApiResultEx<HostTimeResponse> result) { }

        public ApiResultEx<ErhcmemberApplyBySmallAppResponse> CreateHealthCardBySmallApp(ApiArgument<ErhcmemberApplyBySmallAppArgument> arg, ApiResultEx<ErhcmemberApplyBySmallAppResponse> result) => rc.GetInstanceByUnknownCode<ErhcmemberApplyBySmallAppResponse>(arg);
    }
}
