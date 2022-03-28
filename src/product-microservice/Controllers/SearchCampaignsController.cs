using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace product_microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SearchCampaignsController: ControllerBase
    {
        [HttpGet(Name = "GetSearchCampaigns")]
        public IActionResult Get()
        {
            return Ok("search campaigns..abcd");
        }
    }
}
