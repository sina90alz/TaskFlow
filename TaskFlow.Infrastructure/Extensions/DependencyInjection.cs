using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

using TaskFlow.Infrastructure.Data;
using TaskFlow.Infrastructure.Identity;
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

            // Identity database
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("IdentityConnection")));

            // Repositories
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
