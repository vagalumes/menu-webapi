using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Services.Repositories;
using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Services;

public static class MenuItemServiceDependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection service) =>
        service.AddScoped<IMenuItemRepository, MenuItemRepository>();
}
