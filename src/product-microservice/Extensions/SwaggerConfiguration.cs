using Microsoft.OpenApi.Models;

namespace product_microservice.Extensions
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
                     => services.AddSwaggerGen(opt =>
                     {
                         opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Products API", Version = "v1" });
                         opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                         {
                             In = ParameterLocation.Header,
                             Description = "Please enter token",
                             Name = "Authorization",
                             Type = SecuritySchemeType.Http,
                             BearerFormat = "JWT",
                             Scheme = "bearer"
                         });

                         opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                         {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                         });
                     });
    }
}
