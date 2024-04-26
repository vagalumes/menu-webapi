using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase;

public static class DeleteMenuItemDependencyInjection
{
    public static IServiceCollection AddDeleteMenuItemUseCase(this IServiceCollection service) =>
        service.AddDependencies()
            .AddScoped<IDeleteMenuItemUseCase, DeleteMenuItemUseCase>();
}