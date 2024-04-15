using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services.Repositories;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services
{
    public static class MenuItemServicesDependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services) =>
            services.AddScoped<IMenuItemRepository, MenuItemRepository>();
    }
}
