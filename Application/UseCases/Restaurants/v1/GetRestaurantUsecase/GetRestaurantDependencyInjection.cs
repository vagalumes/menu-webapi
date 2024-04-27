using Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Abstractions;
using Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUsecase;

public static class GetRestaurantDependencyInjection
{
    public static IServiceCollection AddGetRestaurantUseCase(this IServiceCollection services)
    {
        return services.AddGetRestaurantDependencies()
            .AddScoped<IGetRestaurantUseCase, GetRestaurantUseCase>();
    }
}