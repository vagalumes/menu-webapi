using Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.Services.Repositories;
using Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.Services
{
    public static class ImageServiceDependencyInjection
    {
        public static IServiceCollection AddImageDependencies(this IServiceCollection services) =>
            services.AddScoped<IImageRepository, ImageRepository>();
    }
}
