using Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Abstractions;
using Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase
{
    public static class CreateRestaurantImageDependencyInjection
    {
        public static IServiceCollection AddCreateRestaurantImageUseCase(this IServiceCollection services)
        {
            return services.AddScoped<ICreateRestaurantImageUseCase, CreateRestaurantCreateRestaurantImageUseCase>()
                           .AddImageDependencies();
        }
    }
}