using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [Route("simple/")]
        public IActionResult Get()
        {
            return Ok(new
            {
                Message = "up and running",
                env = Environment.GetEnvironmentVariable("ENV_NAME")
            });
        }
    }
}
