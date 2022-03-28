using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using product_microservice.Constants;

namespace product_microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {

        }

        [Authorize(Authorization.Policy.ReadProducts)]
        [HttpGet(Name = "GetProducts")]
        public IActionResult Get()
        {
            return Ok("products..abcd");
        }
    }
}
