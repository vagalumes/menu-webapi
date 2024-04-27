using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services.Repositories;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services;

public static class RestaurantsServicesDependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        return services.AddScoped<IRestaurantRepository, RestaurantRepository>();
    }
}