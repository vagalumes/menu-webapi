using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase;

public static class DeleteRestaurantDependencyInjection
{
    public static IServiceCollection AddDeleteRestaurantUseCase(this IServiceCollection services)
    {
        return services
            .AddDependencies()
            .AddNotifications()
            .AddScoped<IDeleteRestaurantUseCase, DeleteRestaurantUseCase>();
    }
}