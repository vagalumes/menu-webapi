using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItems.v1.GetMenuItemsUseCase
{
    public static class GetMenuItemDependencyInjection
    {
        public static IServiceCollection AddGetMenuItem(this IServiceCollection services) =>
            services.AddDependencies()
                    .AddScoped<IGetMenuItemUseCase, GetMenuItemUseCase>();
    }
}
