using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Models;

namespace Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Abstractions
{
    public interface IOutputPort
    {
        void RestaurantNotFound();
        void MenuItemsFound(IEnumerable<MenuItemsResponse> menuItems);
    }
}
