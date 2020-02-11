
namespace WzHealthCard.Refactor.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            this.logger = logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //logger.LogCritical("{0}, Critical!", Guid.NewGuid());
            //logger.LogDebug("{0}, Debug!", Guid.NewGuid());
            //logger.LogError("{0}, Error!", Guid.NewGuid());
            //logger.LogInformation("{0}, Information!", Guid.NewGuid());
            //logger.LogTrace("{0}, Trace!", Guid.NewGuid());
            //logger.LogWarning("{0}, Warning!", Guid.NewGuid());

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) => "value";

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) { }
    }
}
