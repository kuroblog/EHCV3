
using System;
using WzHealthCard.Refactor.Api.Infrastructure.AspFilters;
using WzHealthCard.Refactor.Api.Models.Refactor;
using WzHealthCard.Refactor.Api.Services.WRefactor;
using Xuhui.Internetpro.WzHealthCardService;

namespace WzHealthCard.Refactor.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("wzhealthcard/api/v1/[controller]")]
    [ApiController]
    public partial class TempeCardController : BaseApi
    {
        private ITempHealthCardService lg;

        public TempeCardController(ITempHealthCardService lg)
        {
            this.lg = lg;
        }


        /// <summary>
        /// 注册临时健康卡
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [Route("apply"),HttpGet,HttpPost]
        public async Task<ActionResult> TempeCardApply(ApiArgument<TempeCardApplyArgument> arg)
        {
            return await ExecuteAsync(async () =>
            {
                var result = await lg.TempeCardApply(arg);
                return Ok(result);
            });
        }

        /// <summary>
        /// 更新临时健康卡
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [Route("modify"), HttpGet, HttpPost]
        public async Task<ActionResult> TempeCardUpdate(ApiArgument<TempeCardModifyArgument> arg)
        {
            return await ExecuteAsync(async () =>
            {
                var result = await lg.TempeCardUpdate(arg);
                return Ok(result);
            });
        }

        /// <summary>
        /// 二维码验证
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [Route("verify/hospital"), HttpGet, HttpPost]
        public async Task<ActionResult> TempeCardVerify(ApiArgument<TempeCardVerifyArgument> arg)
        {
            return await ExecuteAsync(async () =>
            {
                var result = await lg.TempeCardVerify(arg);
                return Ok(result);
            });
        }

        /// <summary>
        /// 查询临时电子健康卡
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [Route("tempApplyQuery"), HttpGet, HttpPost]
        [Obsolete("临时电子健康卡身份证非真实，因此弃用此查询")]
        public async Task<ActionResult> TempeCardQuerySingle(ApiArgument<TempeCardQuerySingleArgument> arg)
        {
            return await ExecuteAsync(async () =>
            {
                var result = await lg.TempeCardQuerySingle(arg);
                return Ok(result);
            });
        }

        /// <summary>
        /// 查询临时电子健康卡
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [Route("qrcode/info"), HttpGet, HttpPost]
        public async Task<ActionResult> TempeCardQrCodeInfoSingle(ApiArgument<TempeCardQueryQrCodeSingleArgument> arg)
        {
            return await ExecuteAsync(async () =>
            {
                var result = await lg.TempeCardQueryQrCodeSingle(arg);
                return Ok(result);
            });
        }
    }
}