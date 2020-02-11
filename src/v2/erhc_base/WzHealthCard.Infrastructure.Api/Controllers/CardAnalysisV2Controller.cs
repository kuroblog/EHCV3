
namespace WzHealthCard.Infrastructure.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using WzHealthCard.Infrastructure.Api.Repositories.Erhc;

    [Route("api/v2/cardanalysis")]
    [ApiController]
    public class CardAnalysisV2Controller : BaseApi
    {
        private readonly City3303ViewRepository cv3303;
        private readonly AppModeViewRepository cvAppMode;

        public CardAnalysisV2Controller(City3303ViewRepository cv3303, AppModeViewRepository cvAppMode)
        {
            this.cv3303 = cv3303;
            this.cvAppMode = cvAppMode;
        }

        [HttpGet, Route("city/apply")]
        public async Task<ActionResult> CityApply(string city)
        {
            var response = Execute(() =>
            {
                var result = cv3303.View.Where(p => p.quantity > 0)?.ToArray();

                return Ok(result);
            });

            return await Task.FromResult(response);
        }
        [HttpGet, Route("appmode/apply")]
        public async Task<ActionResult> AppModeApply(string city, string begin, string end)
        {
            var response = Execute(() =>
            {
                var result = cvAppMode.View.Where(p => p.quantity > 0)?.ToArray();

                return Ok(result);
            });

            return await Task.FromResult(response);
        }
    }
}
