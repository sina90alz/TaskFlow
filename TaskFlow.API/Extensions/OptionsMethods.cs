using TaskFlow.Infrastructure.Configurations;

namespace TaskFlow.API.Extensions
{
    public static class OptionsMethods
    {
        public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecurityOption>(configuration.GetSection("Jwt"));
            services.Configure<SecurityOption>(configuration.GetSection("Cors"));
        }
    }
}
