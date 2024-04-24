using Application.Shared.Services;
using Application.Shared.Services.Abstractions;
using Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase.Services.Repositories;
using Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase.Services;

public static class MenuItemsImagesServiceDependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services) =>
        services.AddScoped<IMenuItemsImagesRepository, MenuItemsImagesRepository>()
                .AddScoped<IImagesService, ImagesService>();
}