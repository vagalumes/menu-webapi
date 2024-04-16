using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Models;

namespace Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Abstractions
{
    public interface IOutputPort
    {
        void MenuItemNotFound();
        void MenuItemFound(MenuItemResponse menuItem);
        void RestaurantNotFound();
    }
}
