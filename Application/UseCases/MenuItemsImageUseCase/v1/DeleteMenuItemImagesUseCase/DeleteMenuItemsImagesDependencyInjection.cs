using Application.Shared.Notifications;
using Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase.Abstractions;
using Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase;

public static class DeleteMenuItemsImagesDependencyInjection
{
    public static IServiceCollection AddDeleteMenuItemImageUseCase(this IServiceCollection service) =>
        service.AddDependencies()
               .AddNotifications()
               .AddScoped<IDeleteMenuItemImagesUseCase, DeleteMenuItemsImageUseCase>();
}