using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Abstractions;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase
{
    public static class UpdateRestaurantDependencyInjection
    {
        public static IServiceCollection AddUpdateRestaurantUseCase(this IServiceCollection services)
        {
            return services
                .AddDependencies()
                .AddNotifications()
                .AddScoped<IUpdateRestaurantUseCase, UpdateRestaurantUseCase>()
                .Decorate<IUpdateRestaurantUseCase, UpdateRestaurantValidationUseCase>();
                
        }
    }
}
