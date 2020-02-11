using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WzHealthCard.Refactor.Api.DataAccess;
using WzHealthCard.Refactor.Api.Models.Refactor;
using WzHealthCard.Refactor.Api.Services.Refactor;
using WzHealthCard.Refactor.Api.Services.WRefactor;
using Xuhui.Internetpro.WzHealthCardService;

namespace WzHealthCard.Refactor.Api.Controllers
{
    [Route("wzhealthcard/api/v1/[controller]")]
    [ApiController]
    public class PersonSymbolController: BaseApi
    {
        private readonly IPersonSymbolService _service;

        public PersonSymbolController(IPersonSymbolService service)
        {
            _service = service;
        }


        /// <summary>
        /// 查询人员标识类型
        /// 根据姓名和身份证号码查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("query/info"), HttpGet, HttpPost]
        public async Task<IActionResult> PersonSymbolQuery(ApiArgument<PersonSymbolRequest> request)
        {
            return await ExecuteAsync(async ()=>
            {
                var result=await _service.PersonSymbolQueryAsync(request);
                return Ok(result);
            });
        }
    }
}