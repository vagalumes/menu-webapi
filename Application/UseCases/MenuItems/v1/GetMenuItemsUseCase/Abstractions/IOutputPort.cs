using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Abstractions
{
    public interface IOutputPort
    {
        void MenuItemNotFound();
        void MenuItemFound(MenuItem menuItem);
        void RestaurantNotFound();
    }
}
