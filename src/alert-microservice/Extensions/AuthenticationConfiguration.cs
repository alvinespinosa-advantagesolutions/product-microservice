using alert_microservice.Models.settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace authorization.Extensions
{
    public static class AuthenticationConfiguration
    {
        public static AuthenticationBuilder ConfigureAuthentication(this IServiceCollection services, Auth0Settings auth0Settings, IWebHostEnvironment webHostEnvironment)
            => services
                .AddAuthentication(options => { 
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    // If the access token does not have a `sub` claim, `User.Identity.Name` will be `null`. Map it to a different claim by setting the NameClaimType below.
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = auth0Settings.Domain,
                        ValidAudience = auth0Settings.Audience,
                        ValidateActor = true,
                        ValidateIssuerSigningKey = true,
                        NameClaimType = ClaimTypes.NameIdentifier,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(auth0Settings.ClientId))
                    };

                    if (webHostEnvironment.IsDevelopment())
                    {
                        options.RequireHttpsMetadata = false;
                    }
                    
                });
    }
}
