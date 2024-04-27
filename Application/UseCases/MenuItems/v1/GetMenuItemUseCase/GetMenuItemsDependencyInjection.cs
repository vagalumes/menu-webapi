using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItems.v1.GetMenuItemUseCase
{
    public static class GetMenuItemsDependencyInjection
    {
        public static IServiceCollection AddGetMenuItemUseCase(this IServiceCollection services) =>
            services.AddDependencies()
                    .AddScoped<IGetMenuItemUseCase, GetMenuItemUseCase>();
    }
}
