using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase
{
    public static class CreateRestaurantDependencyInjection
    {
        public static IServiceCollection AddCreateRestaurantUseCase(this IServiceCollection services) => services
            .AddDependencies()
            .AddNotifications()
            .AddScoped<ICreateRestaurantUseCase, CreateRestaurantUseCase>()
            .Decorate<ICreateRestaurantUseCase, CreateRestaurantValidationUseCase>();
    }
}
