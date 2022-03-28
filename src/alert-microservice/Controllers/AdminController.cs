using alert_microservice.Models.settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace alert_microservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController: ControllerBase
    {
        private readonly IOptions<Auth0Settings> options;

        public AdminController(IOptions<Auth0Settings> options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        [HttpGet(Name = "GetToken")]
        public IActionResult Get()
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.ClientId));
            var signingcredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var token = new JwtSecurityToken(options.Value.Domain,
                               options.Value.Audience,
                               new List<Claim> {
                                   new Claim("sub", ""),
                                   new Claim(ClaimTypes.Email, "alvin.espinosa@advantagesolutions.net"),
                                   new Claim("permissions",  JsonConvert.SerializeObject(GetPermissions(), jsonSerializerSettings) ),
                               },
                               notBefore: DateTime.Now,
                               expires: DateTime.Now.AddDays(1),
                               signingCredentials: signingcredentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwt_token);
        }

        private static IEnumerable<string> GetPermissions()
        {
            return new List<string>() { "read:business", "read: users", "write:business" };
        }
    }
}
