using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services.Repositories;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services;

public static class MenuItemsServicesDependencyInjection
{
    public static IServiceCollection AddDependencie(this IServiceCollection services)
    {
        return services.AddScoped<IMenuItemsRepository, GetMenuItemsRepository>();
    }
}