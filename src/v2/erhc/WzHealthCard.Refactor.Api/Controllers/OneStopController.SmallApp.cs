using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WzHealthCard.Refactor.Api.Models.Refactor;
using WzHealthCard.Refactor.Api.Services.WRefactor;
using Xuhui.Internetpro.WzHealthCardService;

namespace WzHealthCard.Refactor.Api.Controllers
{
    /// <summary>
    /// 温州一站式登录
    /// </summary>
    [Route("wzhealthcard/api/v1/[controller]")]
    [ApiController]
    public class OneStopController : BaseApi
    {
        private readonly IOneStopService _service;

        public OneStopController(IOneStopService service)
        {
            _service = service;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("query"), HttpGet, HttpPost]
        public async Task<IActionResult> Query(ApiArgument<OneStopRequest> request)
        {
            return await ExecuteAsync(async () =>
            {
                var result = await _service.QueryAsync(request);
                
                return Ok(result);
            });
        }

        /// <summary>
        /// 绑定，新增
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("create"), HttpGet, HttpPost]
        public async Task<IActionResult> Create(ApiArgument<CreateOneStopRequest> request)
        {
            return await ExecuteAsync(async () =>
            {
                var result = await _service.InsertAsync(request);
                return Ok(result);
            });
        }
    }
}