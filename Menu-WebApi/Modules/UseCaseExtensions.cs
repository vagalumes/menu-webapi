using Application.Shared.Notifications;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase;
using Application.UseCases.Restaurants.v1.GetRestaurantUseCase;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase;
using Application.UseCases.Users.v1.CreateUserUseCase;
using Application.UseCases.Users.v1.DeleteUserUseCase;
using Application.UseCases.Users.v1.GetUserUseCase;
using Application.UseCases.Users.v1.UpdateUserUseCase;

namespace Cardapio_webapi.Modules
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection servies, IConfiguration configuration)
        {
            return servies
                .AddNotifications()
                .AddRestaurantsUseCases()
                .AddUsersUseCases();
        }

        private static IServiceCollection AddRestaurantsUseCases(this IServiceCollection services)
        {
            return services
                .AddCreateRestaurantUseCase()
                .AddDeleteRestaurantUseCase()
                .AddUpdateRestaurantUseCase()
                .AddGetRestaurantUseCase();
        }

        private static IServiceCollection AddUsersUseCases(this IServiceCollection services)
        {
            return services
                   .AddCreateUserUseCase()
                   .AddGetUserUseCase()
                   .AddDeleteUserUseCase()
                   .AddUpdateUserUseCase();
        }
    }
}
