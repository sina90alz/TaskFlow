using Microsoft.AspNetCore.Identity;
using TaskFlow.API;
using TaskFlow.API.Extensions;
using TaskFlow.Application.Extensions;
using TaskFlow.Infrastructure.Extensions;
using TaskFlow.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);
// ASP.NET Core Identity setup
builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
{
    options.User.RequireUniqueEmail = true;
})
        .AddEntityFrameworkStores<AppIdentityDbContext>()
        .AddDefaultTokenProviders();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

builder.Services.AddCustomOptions(builder.Configuration);
builder.Services.AddCustomSecurity(builder.Configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

//builder.Host.UseSerilog((ctx, lc) => lc
//   .ReadFrom.Configuration(ctx.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();