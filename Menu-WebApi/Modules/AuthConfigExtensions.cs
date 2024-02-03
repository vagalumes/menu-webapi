using Application.Shared.Context;
using Application.Shared.Entities;
using Microsoft.AspNetCore.Identity;

namespace Cardapio_webapi.Modules
{
    public static class AutConfigExtensions
    {
        public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
        {
            _ = services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            _ = services.Configure<IdentityOptions>(opt =>
            {

                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 8;
                opt.Password.RequiredUniqueChars = 0;
            });
            return services;
        }
    }
}
