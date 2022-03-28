using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using product_microservice.Constants;

namespace product_microservice.Extensions
{
    public static class AuthorizationConfiguration
    {
        public static IMvcBuilder ConfigureAuthorization(this IServiceCollection services)
              => services.AddAuthorization(options =>
              {
                  options.AddPolicy(Authorization.Policy.ReadProducts, new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireClaim(Authorization.RequireClaim.Permissions, Authorization.Policy.ReadProducts)
                        .Build());

              }).AddMvc(config =>
              {
                  var policy = new AuthorizationPolicyBuilder()
                      .RequireAuthenticatedUser()
                      .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                      .Build();
                  config.Filters.Add(new AuthorizeFilter(policy));
              });

    }
}
    