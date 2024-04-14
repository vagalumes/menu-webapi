using System.Formats.Asn1;
using Application.Shared.Context;
using Application.Shared.Services;
using Application.Shared.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Menu_WebApi.Modules
{
    public static class DataBaseConfigExtensions
    {
        public static IServiceCollection ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlServer"))
                           .EnableSensitiveDataLogging()
                           .EnableDetailedErrors())
                           .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceProvider CreateDatabase(this IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            _ = context.Database.EnsureCreated();

            return services;
        }
    }
}
