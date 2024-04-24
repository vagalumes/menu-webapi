using Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUseCase;

public static class GetRestaurantDependencyInjection
{
    public static IServiceCollection AddGetRestaurantUseCase(this IServiceCollection services)
    {
        return services.AddGetRestaurantDependencies()
            .AddScoped<IGetRestaurantUseCase, GetRestaurantUseCase>();
    }
}