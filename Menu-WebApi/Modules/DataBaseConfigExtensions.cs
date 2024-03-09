using Application.Shared.Context;
using Application.Shared.Services;
using Application.Shared.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Cardapio_webapi.Modules
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
    }
}
