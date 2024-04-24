using Application.UseCases.MenuItemsImageUseCase.v1.CreateMenuItemsUseCase.Services.Repositories;
using Application.UseCases.MenuItemsImageUseCase.v1.CreateMenuItemsUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItemsImageUseCase.v1.CreateMenuItemsUseCase.Services;

public static class MenuItemServicesDependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        return services.AddScoped<IMenuItemRepository, MenuItemRepository>();
    }
}