
namespace WzHealthCard.Refactor.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WzHealthCard.Refactor.Api.Extensions;
    using WzHealthCard.Refactor.Api.Models.Refactor;

    public partial class ErhcMemberController
    {
        [HttpGet, Route("test3")]
        public async Task<ActionResult> Test3(string user = "")
        {
            return await Task.FromResult(Ok($"{nameof(Test3)} on SmallApp, {user}."));
        }

        [HttpPost, Route("erhcquery/info")]
        public ActionResult QueryInfo(ApiArgument<ErhcmemberApplyQueryArgument> arg)
        {
            return Execute(() =>
            {
                (bool state, string json) = arg.Verify(false);
                if (!state)
                {
                    return Ok(json);
                }

                var result = healthCardService.ErhcmemberQueryInfo(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("erhcquery/phone")]
        public ActionResult QueryPhone(ApiArgument<ErhcmemberQueryByPhoneArgument> arg)
        {
            return Execute(() =>
            {
                var result = healthCardService.ErhcmemberQueryByPhone(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("apply/smallapp")]
        public ActionResult ApplyBySmallApp(ApiArgument<ErhcmemberApplyBySmallAppArgument> arg)
        {
            return Execute(() =>
            {
                var result = healthCardService.CreateHealthCardBySmallApp(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("family/create")]
        public ActionResult FamilyCreate(ApiArgument<ErhcmemberFamilyCreateArgument> arg)
        {
            return Execute(() =>
            {
                (bool state, string json) = arg.Verify(false);
                if (!state)
                {
                    return Ok(json);
                }

                var result = healthCardService.ErhcmemberFamilyCreate(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("family/read")]
        public ActionResult FamilyRead(ApiArgument<ErhcmemberFamilyReadArgument> arg)
        {
            return Execute(() =>
            {
                (bool state, string json) = arg.Verify(false);
                if (!state)
                {
                    return Ok(json);
                }

                var result = healthCardService.ErhcmemberFamilyRead(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("family/update")]
        public ActionResult FamilyUpdate(ApiArgument<ErhcmemberFamilyUpdateArgument> arg)
        {
            return Execute(() =>
            {
                (bool state, string json) = arg.Verify(false);
                if (!state)
                {
                    return Ok(json);
                }

                var result = healthCardService.ErhcmemberFamilyUpdate(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("family/delete")]
        public ActionResult FamilyDelete(ApiArgument<ErhcmemberFamilyDeleteArgument> arg)
        {
            return Execute(() =>
            {
                (bool state, string json) = arg.Verify(false);
                if (!state)
                {
                    return Ok(json);
                }

                var result = healthCardService.ErhcmemberFamilyDelete(arg);
                return Ok(result);
            });
        }

        [HttpPost, Route("adress/smallapp")]
        public ActionResult AddressBySmallApp(ApiArgument<ErhcmemberAddressBySmallAppArgument> arg)
        {
            return Execute(() =>
            {
                (bool state, string json) = arg.Verify(false);
                if (!state)
                {
                    return Ok(json);
                }

                var result = healthCardService.ErhcmemberAddressBySmallApp(arg);
                return Ok(result);
            });
        }
    }
}