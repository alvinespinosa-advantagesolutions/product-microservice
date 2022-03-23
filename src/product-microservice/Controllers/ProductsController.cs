using Microsoft.AspNetCore.Mvc;

namespace product_microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet(Name = "GetProducts")]
        public IActionResult Get()
        {
            return Ok("products..");
        }
    }
}
