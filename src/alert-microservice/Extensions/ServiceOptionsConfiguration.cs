using alert_microservice.Models.settings;

namespace alert_microservice.Extensions
{
    public static class ServiceOptionsConfiguration
    {
        public static IServiceCollection ConfigureServiceOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<Auth0Settings>(configuration.GetSection("Auth0"));

            return services;
        }
    }
}
