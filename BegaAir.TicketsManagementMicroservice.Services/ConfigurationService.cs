using System.Text;
using BegaAir.TicketsManagementMicroservice.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BegaAir.TicketsManagementMicroservice.Services;

public static class ConfigurationService
{

    public static IServiceCollection AddServices(this IServiceCollection services, string connectionString)
    {
        services.AddDataServices(connectionString);
        services.AddHttpContextAccessor();
        return services;
    }
    
    private static void AddDataServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("BegaAir.TicketsManagementMicroservice.DataAccess")));
    }
    public static void AddAuth(this IServiceCollection service, string? secretKey)
    {
        if (secretKey is not null)
        {
            var Key = Encoding.UTF8.GetBytes(secretKey);
            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                };

            });
        }
    }

}