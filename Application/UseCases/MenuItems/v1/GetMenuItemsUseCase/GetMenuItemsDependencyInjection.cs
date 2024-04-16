using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItems.v1.GetMenuItemsUseCase
{
    public static class GetMenuItemsDependencyInjection
    {
        public static IServiceCollection AddGetMenuItemsUseCase(this IServiceCollection services) =>
            services.AddDependencie()
                    .AddScoped<IGetMenuItemsUseCase, GetMenuItemsUseCase>();
    }
}
