using Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Services.Repositories;
using Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Services;

public static class RestaurantServicesDependencyInjection
{
    public static IServiceCollection AddGetRestaurantDependencies(this IServiceCollection services)
    {
        return services.AddScoped<IRestaurantRepository, RestaurantRepository>();
    }
}