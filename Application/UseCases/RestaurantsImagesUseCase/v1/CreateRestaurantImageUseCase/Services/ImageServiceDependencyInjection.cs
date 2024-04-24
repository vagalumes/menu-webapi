using Application.Shared.Services.Abstractions;
using Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Services.Repositories;
using Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Services
{
    public static class ImageServiceDependencyInjection
    {
        public static IServiceCollection AddImageDependencies(this IServiceCollection services)
        {
            return services.AddScoped<IImageRepository, ImageRepository>()
                .AddScoped<IImagesService, Shared.Services.ImagesService>();
        }
    }
}
