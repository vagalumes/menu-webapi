using Application.Shared.Notifications;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase;
using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase;
using Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase;
using Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase;
using Application.UseCases.Restaurants.v1.GetRestaurantUseCase;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase;
using Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase;
using Application.UseCases.Users.v1.CreateUserUseCase;
using Application.UseCases.Users.v1.DeleteUserUseCase;
using Application.UseCases.Users.v1.GetUserUseCase;
using Application.UseCases.Users.v1.UpdateUserUseCase;

namespace Menu_WebApi.Modules
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration) =>
            services.AddNotifications()
                .AddRestaurantsUseCases()
                .AddUsersUseCases()
                .AddMenuItemsUseCase()
                .AddRestaurantImageUseCase()
                .AddMenuItemsImageUseCase();

        private static IServiceCollection AddRestaurantsUseCases(this IServiceCollection services) =>
            services.AddCreateRestaurantUseCase()
                .AddDeleteRestaurantUseCase()
                .AddUpdateRestaurantUseCase()
                .AddGetRestaurantUseCase();

        private static IServiceCollection AddUsersUseCases(this IServiceCollection services) =>
            services.AddCreateUserUseCase()
                .AddGetUserUseCase()
                .AddDeleteUserUseCase()
                .AddUpdateUserUseCase();

        private static IServiceCollection AddMenuItemsUseCase(this IServiceCollection services) =>
            services.AddMenuItemUseCase()
                .AddGetMenuItemsUseCase()
                .AddGetMenuItemUseCase()
                .AddUpdateMenuItemUseCase()
                .AddDeleteMenuItemUseCase();

        private static IServiceCollection AddMenuItemsImageUseCase(this IServiceCollection services) =>
            services.AddCreateMenuItemsImageUseCase()
                .AddDeleteMenuItemImageUseCase();

        private static IServiceCollection AddRestaurantImageUseCase(this IServiceCollection services) =>
            services.AddCreateRestaurantImageUseCase();
    }
}