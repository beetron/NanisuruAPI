using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NanisuruAPI.Database;

namespace NanisuruAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        readonly IOptions<MongoDbSettings> _mongoDbSettings;

        public TestController(IOptions<MongoDbSettings> mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings;
        }

        [HttpGet("settings")]
        public IActionResult GetSettings()
        {
            var settings = _mongoDbSettings.Value;
            return Ok(settings);
        }
        
    }
}
