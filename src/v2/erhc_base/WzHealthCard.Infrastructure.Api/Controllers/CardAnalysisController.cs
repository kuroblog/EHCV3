
namespace WzHealthCard.Infrastructure.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using WzHealthCard.Infrastructure.Api.DataAccess.Erhc;
    using WzHealthCard.Infrastructure.Api.Extensions;
    using WzHealthCard.Infrastructure.Api.Models;
    using WzHealthCard.Infrastructure.Api.Repositories.Erhc;
    using WzHealthCard.Infrastructure.Api.Repositories.ErhcManage;
    using WzHealthCard.Infrastructure.Api.UnitOfWorks;

    [Route("api/v1/[controller]")]
    [ApiController]
    public class CardAnalysisController : BaseApi
    {
        private readonly ILogger<CardAnalysisController> logger;

        private readonly UseAnalyzeRepository useAnyRepo;
        private readonly ApplyAnalyzeRepository appAnyRepo;
        private readonly CardRepository cardRepo;
        private readonly AppInfoRepository appRepo;
        private readonly ErhcUnitOfWork erhcUow;

        private readonly DistrictSettings distSettings;
        private readonly MsStepSettings msStepSettings;
        private readonly AppModeSettings appModeSettings;

        public CardAnalysisController(
            ILogger<CardAnalysisController> logger,
            UseAnalyzeRepository useAnyRepo,
            ApplyAnalyzeRepository appAnyRepo,
            CardRepository cardRepo,
            AppInfoRepository appRepo,
            ErhcUnitOfWork erhcUow,
            DistrictSettings distSettings,
            MsStepSettings msStepSettings,
            AppModeSettings appModeSettings)
        {
            this.logger = logger;

            this.useAnyRepo = useAnyRepo;
            this.appAnyRepo = appAnyRepo;
            this.cardRepo = cardRepo;
            this.appRepo = appRepo;
            this.erhcUow = erhcUow;

            this.distSettings = distSettings;
            this.msStepSettings = msStepSettings;
            this.appModeSettings = appModeSettings;
        }

        [HttpGet, Route("query/use")]
        public async Task<ActionResult> QueryUse(string cardId, string empi, string idCardNo)
        {
            var response = Execute(() =>
            {
                var query = useAnyRepo.View;

                if (string.IsNullOrEmpty(cardId) == false)
                {
                    query = query.Where(p => p.CardId == cardId);
                }

                if (string.IsNullOrEmpty(empi) == false)
                {
                    query = query.Where(p => p.Empi == empi);
                }

                if (string.IsNullOrEmpty(idCardNo) == false)
                {
                    query = query.Where(p => p.IdCardNo == idCardNo);
                }

                var result = query?.Select(p => new CardUseAnalyzeQueryResponse
                {
                    amount = p.Amount,
                    cardId = p.CardId,
                    cityCode = p.CityCode,
                    depCode = p.DepCode,
                    depType = p.DepType,
                    empi = p.Empi,
                    medType = p.MedType,
                    msCode = p.MsCode,
                    orgName = p.OrgName,//.Split(',', StringSplitOptions.RemoveEmptyEntries).LastOrDefault(),
                    payTime = p.CreatedAt,
                    payType = p.PayType
                })?.ToArray();

                var exResult = result.Select(p => new CardUseAnalyzeQueryResponse
                {
                    amount = p.amount,
                    cardId = p.cardId,
                    cityCode = p.cityCode,
                    depCode = p.depCode,
                    depType = p.depType,
                    empi = p.empi,
                    medType = p.medType,
                    msCode = p.msCode,
                    orgName = p.orgName.Split(',', StringSplitOptions.RemoveEmptyEntries).LastOrDefault(),
                    payTime = p.payTime,
                    payType = p.payType
                });

                return Ok(exResult);
            });

            return await Task.FromResult(response);
        }

        [HttpPost, Route("create/use")]
        public async Task<ActionResult> CreateUse([FromBody]CardUseAnalyzeCreateRequest request)
        {
            var response = Execute(() =>
            {
                var qCity = appRepo.View;
                if (request.appSource == 0)
                {
                    qCity = qCity.Where(p => p.app_key == request.appId);
                }
                else
                {
                    qCity = qCity.Where(p => p.sapp_id == request.appId);
                }

                var appInfo = qCity?.Select(p => new { p.city_code, p.district_code, p.manag_orgcode, p.manag_orgname })?.FirstOrDefault();
                if (appInfo == null)
                {
                    return NotFound(request.appId);
                }

                var nUse = new UseAnalyzeEntity
                {
                    Amount = 0M,
                    CardId = request.cardId,
                    CityCode = appInfo.city_code,
                    CreatedAt = DateTime.Now,
                    DepCode = request.depCode,
                    DepType = request.depType,
                    DistCde = appInfo.district_code,
                    Empi = request.empi,
                    //Id = 0,
                    IdCardNo = request.idCardNo,
                    MedType = request.medType,
                    MsCode = request.msCode,
                    OrgCode = $"{request.orgCode},{appInfo.manag_orgcode}",
                    OrgName = $"{request.orgName},{appInfo.manag_orgname}",
                    PayType = ""
                };

                useAnyRepo.Insert(nUse);

                erhcUow.Commit();

                return Accepted(new CardUseAnalyzeCreateResponse { id = nUse.Id });
            });

            return await Task.FromResult(response);
        }

        [HttpGet, Route("month/use")]
        public async Task<ActionResult> MonthUse(string city, string year)
        {
            var response = Execute(() =>
            {
                var query = useAnyRepo.View;
                if (!string.IsNullOrEmpty(city))
                {
                    query = query.Where(p => p.CityCode == city);
                }
                else
                {
                    return BadRequest($"{nameof(city)} can not be empty");
                }

                var isParsed = false;
                DateTime date = DateTime.Now;
                if (!string.IsNullOrEmpty(year))
                {
                    isParsed = DateTime.TryParse($"{year}/01/01", out date);
                }
                else
                {
                    return BadRequest($"{nameof(year)} can not be empty");
                }

                if (!isParsed)
                {
                    return BadRequest($"{nameof(year)} not a valid year format");
                }
                else
                {
                    query = query.Where(p => p.CreatedAt.Year == date.Year);
                }

                var result = query.GroupBy(p => p.CreatedAt.Month).Select(p => new { month = p.Key, quantity = p.Count() })?.ToArray();

                return Ok(result);
            });

            return await Task.FromResult(response);
        }

        [HttpGet, Route("city/use")]
        public async Task<ActionResult> CityUse(string city, string begin, string end)
        {
            var response = Execute(() =>
            {
                var query = useAnyRepo.View;
                if (!string.IsNullOrEmpty(city))
                {
                    query = query.Where(p => p.CityCode == city);
                }
                else
                {
                    return BadRequest($"{nameof(city)} can not be empty");
                }

                DateTime bDate = DateTime.Now;
                if (!string.IsNullOrEmpty(begin))
                {
                    var isParsed = DateTime.TryParse(begin, out bDate);

                    if (!isParsed)
                    {
                        return BadRequest($"{nameof(begin)} not a valid year format");
                    }
                    else
                    {
                        query = query.Where(p => p.CreatedAt >= bDate);
                    }
                }

                DateTime eDate = DateTime.Now;
                if (!string.IsNullOrEmpty(end))
                {
                    var isParsed = DateTime.TryParse(end, out eDate);

                    if (!isParsed)
                    {
                        return BadRequest($"{nameof(end)} not a valid year format");
                    }
                    else
                    {
                        eDate = eDate.AddDays(1).AddSeconds(-1);
                        query = query.Where(p => p.CreatedAt <= eDate);
                    }
                }

                var result = query
                    .GroupBy(p => p.DistCde)
                    .Select(p => new
                    {
                        code = p.Key,
                        name = distSettings.GetValue(p.Key),
                        quantity = p.Count()
                    })?
                    .ToArray();

                return Ok(result);
            });

            return await Task.FromResult(response);
        }

        [HttpGet, Route("step/use")]
        public async Task<ActionResult> StepUse(string city, string begin, string end)
        {
            var response = Execute(() =>
            {
                var query = useAnyRepo.View;
                if (!string.IsNullOrEmpty(city))
                {
                    query = query.Where(p => p.CityCode == city);
                }
                else
                {
                    return BadRequest($"{nameof(city)} can not be empty");
                }

                DateTime bDate = DateTime.Now;
                if (!string.IsNullOrEmpty(begin))
                {
                    var isParsed = DateTime.TryParse(begin, out bDate);

                    if (!isParsed)
                    {
                        return BadRequest($"{nameof(begin)} not a valid year format");
                    }
                    else
                    {
                        query = query.Where(p => p.CreatedAt >= bDate);
                    }
                }

                DateTime eDate = DateTime.Now;
                if (!string.IsNullOrEmpty(end))
                {
                    var isParsed = DateTime.TryParse(end, out eDate);

                    if (!isParsed)
                    {
                        return BadRequest($"{nameof(end)} not a valid year format");
                    }
                    else
                    {
                        eDate = eDate.AddDays(1).AddSeconds(-1);
                        query = query.Where(p => p.CreatedAt <= eDate);
                    }
                }

                var result = query
                    .GroupBy(p => p.MsCode)
                    .Select(p => new
                    {
                        code = p.Key,
                        name = msStepSettings.GetValue(p.Key),
                        quantity = p.Count()
                    })?.ToArray();

                return Ok(result);
            });

            return await Task.FromResult(response);
        }

        [HttpGet, Route("age/use")]
        public async Task<ActionResult> AgeUse(string city, string begin, string end)
        {
            var response = Execute(() =>
            {
                var query = useAnyRepo.View;
                if (!string.IsNullOrEmpty(city))
                {
                    query = query.Where(p => p.CityCode == city);
                }
                else
                {
                    return BadRequest($"{nameof(city)} can not be empty");
                }

                DateTime bDate = DateTime.Now;
                if (!string.IsNullOrEmpty(begin))
                {
                    var isParsed = DateTime.TryParse(begin, out bDate);

                    if (!isParsed)
                    {
                        return BadRequest($"{nameof(begin)} not a valid year format");
                    }
                    else
                    {
                        query = query.Where(p => p.CreatedAt >= bDate);
                    }
                }

                DateTime eDate = DateTime.Now;
                if (!string.IsNullOrEmpty(end))
                {
                    var isParsed = DateTime.TryParse(end, out eDate);

                    if (!isParsed)
                    {
                        return BadRequest($"{nameof(end)} not a valid year format");
                    }
                    else
                    {
                        eDate = eDate.AddDays(1).AddSeconds(-1);
                        query = query.Where(p => p.CreatedAt <= eDate);
                    }
                }

                //var result = query.Select(p => p.IdCardNo.Length == 18 ? p.IdCardNo.Substring(6, 8) : string.Empty).GroupBy(p => p).Select(p => new { date = p.Key, quantity = p.Count() })?.ToArray();

                //var result = query
                //    .GroupBy(p => p.IdCardNo.Length == 18 ? p.IdCardNo.Substring(6, 8) : string.Empty)
                //    .Select(p => new { age = GetAge(p.Key), quantity = p.Count() })?
                //    .ToArray();

                //var resultSource = query?.Select(p => string.IsNullOrEmpty(p.IdCardNo) ? string.Empty : p.IdCardNo).ToArray();
                //var result = resultSource
                //    .GroupBy(p => p.Length == 18 ? p.Substring(6, 8) : string.Empty)
                //    .Select(p => new { age = GetAgeEx(p.Key), quantity = p.Count() })?
                //    .ToArray();

                //var result2 = resultSource.Where(p => p.IdCardNo.Length != 18);

                var result = query
                    ?.Select(p => string.IsNullOrEmpty(p.IdCardNo) ? string.Empty : p.IdCardNo.Length == 18 ? GetAgeEx(p.IdCardNo.Substring(6, 8)) : string.Empty)
                    ?.ToArray()
                    ?.GroupBy(p => p)
                    ?.Select(p => new { age = p.Key, quantity = p.Count() })
                    ?.ToArray();

                return Ok(result);
            });

            return await Task.FromResult(response);
        }

        private string GetAgeEx(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return string.Empty;
            }

            var year = date.Substring(0, 4);
            var month = date.Substring(4, 2);
            var day = date.Substring(6, 2);

            var brDate = Convert.ToDateTime($"{year}-{month}-{day}");

            DateTime now = DateTime.Now;
            var age = now.Year - brDate.Year;
            if (now.Month < brDate.Month || (now.Month == brDate.Month && now.Day < brDate.Day))
            {
                age--;
            }

            return (age < 0 ? 0 : age).ToString();
        }

        private int? GetAge(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return null;
            }

            var year = date.Substring(0, 4);
            var month = date.Substring(4, 2);
            var day = date.Substring(6, 2);

            var brDate = Convert.ToDateTime($"{year}-{month}-{day}");

            DateTime now = DateTime.Now;
            var age = now.Year - brDate.Year;
            if (now.Month < brDate.Month || (now.Month == brDate.Month && now.Day < brDate.Day))
            {
                age--;
            }

            return age < 0 ? 0 : age;
        }

        [HttpPost, Route("create/apply")]
        public async Task<ActionResult> CreateApply([FromBody]CardApplyAnalyzeCreateRequest request)
        {
            var response = Execute(() =>
            {
                var qCity = appRepo.View;
                if (request.appSource == 0)
                {
                    qCity = qCity.Where(p => p.app_key == request.appId);
                }
                else
                {
                    qCity = qCity.Where(p => p.sapp_id == request.appId);
                }

                var appInfo = qCity?.Select(p => new { p.city_code, p.district_code })?.FirstOrDefault();
                if (appInfo == null)
                {
                    return NotFound(request.appId);
                }

                var nApply = new ApplyAnalyzeEntity
                {
                    AppId = request.appId,
                    AppMode = request.appMode,
                    CardId = request.cardId,
                    CityCode = appInfo.city_code,
                    CreatedAt = DateTime.Now,
                    DistCode = appInfo.district_code,
                    Empi = request.empi
                    //Id = 0
                };

                appAnyRepo.Insert(nApply);

                erhcUow.Commit();

                return Accepted(new CardApplyAnalyzeCreateResponse { id = nApply.Id });
            });

            return await Task.FromResult(response);
        }

        [HttpGet, Route("year/apply")]
        public async Task<ActionResult> YearApply(string city, string begin, string end)
        {
            var response = Execute(() =>
            {
                var query = appAnyRepo.View;
                if (!string.IsNullOrEmpty(city))
                {
                    query = query.Where(p => p.CityCode == city);
                }
                else
                {
                    return BadRequest($"{nameof(city)} can not be empty");
                }

                DateTime bDate = DateTime.Now;
                if (!string.IsNullOrEmpty(begin))
                {
                    var isParsed = DateTime.TryParse(begin, out bDate);

                    if (!isParsed)
                    {
                        return BadRequest($"{nameof(begin)} not a valid year format");
                    }
                    else
                    {
                        query = query.Where(p => p.CreatedAt >= bDate);
                    }
                }

                DateTime eDate = DateTime.Now;
                if (!string.IsNullOrEmpty(end))
                {
                    var isParsed = DateTime.TryParse(end, out eDate);

                    if (!isParsed)
                    {
                        return BadRequest($"{nameof(end)} not a valid year format");
                    }
                    else
                    {
                        eDate = eDate.AddDays(1).AddSeconds(-1);
                        query = query.Where(p => p.CreatedAt <= eDate);
                    }
                }

                var result = query.Count();

                return Ok(result);
            });

            return await Task.FromResult(response);
        }

        [HttpGet, Route("month/apply")]
        public async Task<ActionResult> MonthApply(string city, string year)
        {
            var response = Execute(() =>
            {
                var query = appAnyRepo.View;
                if (!string.IsNullOrEmpty(city))
                {
                    query = query.Where(p => p.CityCode == city);
                }
                else
                {
                    return BadRequest($"{nameof(city)} can not be empty");
                }

                var isParsed = false;
                DateTime date = DateTime.Now;
                if (!string.IsNullOrEmpty(year))
                {
                    isParsed = DateTime.TryParse($"{year}/01/01", out date);
                }
                else
                {
                    return BadRequest($"{nameof(year)} can not be empty");
                }

                if (!isParsed)
                {
                    return BadRequest($"{nameof(year)} not a valid year format");
                }
                else
                {
                    query = query.Where(p => p.CreatedAt.Year == date.Year);
                }

                var result = query.GroupBy(p => p.CreatedAt.Month).Select(p => new { month = p.Key, quantity = p.Count() })?.ToArray();

                return Ok(result);
            });

            return await Task.FromResult(response);
        }

        [HttpGet, Route("city/apply")]
        public async Task<ActionResult> CityApply(string city, string begin, string end)
        {
            var response = Execute(() =>
            {
                var query = appAnyRepo.View;
                if (!string.IsNullOrEmpty(city))
                {
                    query = query.Where(p => p.CityCode == city);
                }
                else
                {
                    return BadRequest($"{nameof(city)} can not be empty");
                }

                DateTime bDate = DateTime.Now;
                if (!string.IsNullOrEmpty(begin))
                {
                    var isParsed = DateTime.TryParse(begin, out bDate);

                    if (!isParsed)
                    {
                        return BadRequest($"{nameof(begin)} not a valid year format");
                    }
                    else
                    {
                        query = query.Where(p => p.CreatedAt >= bDate);
                    }
                }

                DateTime eDate = DateTime.Now;
                if (!string.IsNullOrEmpty(end))
                {
                    var isParsed = DateTime.TryParse(end, out eDate);

                    if (!isParsed)
                    {
                        return BadRequest($"{nameof(end)} not a valid year format");
                    }
                    else
                    {
                        eDate = eDate.AddDays(1).AddSeconds(-1);
                        query = query.Where(p => p.CreatedAt <= eDate);
                    }
                }

                var result = query
                    .GroupBy(p => p.DistCode)
                    .Select(p => new
                    {
                        code = p.Key,
                        name = distSettings.GetValue(p.Key),
                        quantity = p.Count()
                    })?
                    .ToArray();

                return Ok(result);
            });

            return await Task.FromResult(response);
        }

        [HttpGet, Route("appmode/apply")]
        public async Task<ActionResult> AppModeApply(string city, string begin, string end)
        {
            var response = Execute(() =>
            {
                var query = appAnyRepo.View;
                if (!string.IsNullOrEmpty(city))
                {
                    query = query.Where(p => p.CityCode == city);
                }
                else
                {
                    return BadRequest($"{nameof(city)} can not be empty");
                }

                DateTime bDate = DateTime.Now;
                if (!string.IsNullOrEmpty(begin))
                {
                    var isParsed = DateTime.TryParse(begin, out bDate);

                    if (!isParsed)
                    {
                        return BadRequest($"{nameof(begin)} not a valid year format");
                    }
                    else
                    {
                        query = query.Where(p => p.CreatedAt >= bDate);
                    }
                }

                DateTime eDate = DateTime.Now;
                if (!string.IsNullOrEmpty(end))
                {
                    var isParsed = DateTime.TryParse(end, out eDate);

                    if (!isParsed)
                    {
                        return BadRequest($"{nameof(end)} not a valid year format");
                    }
                    else
                    {
                        eDate = eDate.AddDays(1).AddSeconds(-1);
                        query = query.Where(p => p.CreatedAt <= eDate);
                    }
                }

                var result = query
                    .GroupBy(p => p.AppMode)
                    .Select(p => new
                    {
                        code = p.Key,
                        name = appModeSettings.GetValue(p.Key),
                        quantity = p.Count()
                    })?
                    .ToArray();

                return Ok(result);
            });

            return await Task.FromResult(response);
        }
    }
}