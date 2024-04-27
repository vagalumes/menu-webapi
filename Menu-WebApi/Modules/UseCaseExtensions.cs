using Application.Shared.Notifications;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase;
using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase;
using Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase;
using Application.UseCases.MenuItemsImagesUseCase.v1.DeleteMenuItemImagesUseCase;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase;
using Application.UseCases.Restaurants.v1.GetRestaurantUsecase;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase;
using Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase;

namespace Menu_WebApi.Modules
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration) =>
            services.AddNotifications()
                .AddRestaurantsUseCases()
                .AddMenuItemsUseCase()
                .AddRestaurantImageUseCase()
                .AddMenuItemsImageUseCase();

        private static IServiceCollection AddRestaurantsUseCases(this IServiceCollection services) =>
            services.AddCreateRestaurantUseCase()
                .AddDeleteRestaurantUseCase()
                .AddUpdateRestaurantUseCase()
                .AddGetRestaurantUseCase();

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