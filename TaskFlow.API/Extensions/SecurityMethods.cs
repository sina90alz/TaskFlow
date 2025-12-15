using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using TaskFlow.Infrastructure.Configurations;

namespace TaskFlow.API
{    
    public static class SecurityMethods
    {
        #region Constants
        public const string Default_Policy = "Default_Policy";
        #endregion

        #region Public Methods
        public static void AddCustomSecurity(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddCustomCors(configuration);
            service.AddCustomAuthentication(configuration);
            service.AddAuthorization();
        }

        public static void AddCustomAuthentication(this IServiceCollection service, IConfiguration configuration)
        {

            SecurityOption security = new();
            configuration.GetSection("Jwt").Bind(security);

            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = security.Issuer,
                    ValidAudience = security.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(security.Key)),
                    RoleClaimType = ClaimTypes.Role
                };
            });
        }

        public static void AddCustomCors(this IServiceCollection service, IConfiguration configuration)
        {
            CorsOption cors = new();
            configuration.GetSection("Cors").Bind(cors);
            service.AddCors(options =>
            {
                options.AddPolicy(Default_Policy, policy =>
                {
                    policy.WithOrigins(cors.Origin)
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
        }
        #endregion
    }
}