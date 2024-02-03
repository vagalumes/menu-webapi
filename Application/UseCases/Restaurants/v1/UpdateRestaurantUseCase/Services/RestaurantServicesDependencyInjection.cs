using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Services.Repositories;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Services.Repositories.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Services
{
    public static class RestaurantServicesDependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<IRestaurantRepository, RestaurantRepository>();
        }
    }
}
