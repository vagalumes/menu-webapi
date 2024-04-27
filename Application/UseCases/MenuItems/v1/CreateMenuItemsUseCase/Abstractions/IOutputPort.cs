using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Models;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Abstractions
{
    public interface IOutputPort
    {
        void InvalidRequest();
        void MenuItemsCreated(MenuItemResponse menuItem);
        void RestaurantNotFound(string message);
    }
}
