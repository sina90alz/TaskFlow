using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskFlow.Infrastructure.Data;
using TaskFlow.Application.Interfaces;
using TaskFlow.Infrastructure.Repositories;

namespace TaskFlow.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            // Database connection
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
