using Microsoft.AspNetCore.Mvc;

namespace alert_microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RuleSettingsController : ControllerBase
    {
        [HttpGet(Name = "GetRuleSettings")]
        public IActionResult Get()
        {
            return Ok("rulesettings is here");
        }
    }
}
