using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using product_microservice.Models.settings;
using System.Security.Claims;

namespace product_microservice.Extensions
{
    public static class AuthenticationConfiguration
    {
        public static AuthenticationBuilder ConfigureAuthentication(this IServiceCollection services, Auth0Settings auth0Settings, IWebHostEnvironment webHostEnvironment)
            => services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = auth0Settings.Domain;
                    options.Audience = auth0Settings.Audience;

                    // If the access token does not have a `sub` claim, `User.Identity.Name` will be `null`. Map it to a different claim by setting the NameClaimType below.
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = auth0Settings.Domain,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = auth0Settings.Audience,
                        ValidateIssuerSigningKey = true,
                        NameClaimType = ClaimTypes.NameIdentifier
                    };

                    if (webHostEnvironment.IsDevelopment())
                    {
                        options.RequireHttpsMetadata = false;
                    }

                });
    }
}
