using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Services.Repositories;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Services;

public static class MenuItemServiceDependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services) =>
        services.AddScoped<IMenuItemRepository, MenuItemRepository>();
}