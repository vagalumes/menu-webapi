using Application.Shared.Notifications;
using Application.UseCases.MenuItemsImagesUseCase.v1.DeleteMenuItemImagesUseCase.Abstractions;
using Application.UseCases.MenuItemsImagesUseCase.v1.DeleteMenuItemImagesUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItemsImagesUseCase.v1.DeleteMenuItemImagesUseCase;

public static class DeleteMenuItemsImagesDependencyInjection
{
    public static IServiceCollection AddDeleteMenuItemImageUseCase(this IServiceCollection service)
    {
        return service.AddDependencies()
            .AddNotifications()
            .AddScoped<IDeleteMenuItemImagesUseCase, DeleteMenuItemsImageUseCase>();
    }
}