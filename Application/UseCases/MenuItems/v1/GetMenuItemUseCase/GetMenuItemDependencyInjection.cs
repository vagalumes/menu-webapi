using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItems.v1.GetMenuItemUseCase
{
    public static class GetMenuItemDependencyInjection
    {
        public static IServiceCollection AddGetMenuItem(this IServiceCollection services) =>
            services.AddDependencies()
                    .AddScoped<IGetMenuItemUseCase, GetMenuItemUseCase>();
    }
}
