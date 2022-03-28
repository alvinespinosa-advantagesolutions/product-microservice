using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace authorization.Extensions
{
    public static class AuthorizationConfiguration
    {
        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services)
              => services.AddAuthorization(options =>
              {
                  options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireClaim(ClaimTypes.Email)
                        .Build());

              });
    }
}
    