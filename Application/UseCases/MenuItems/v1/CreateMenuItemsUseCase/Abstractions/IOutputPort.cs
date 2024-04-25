using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Abstractions
{
    public interface IOutputPort
    {
        void InvalidRequest();
        void MenuItemsCreated(MenuItem menuItem);
        void RestaurantNotFound(string message);
    }
}
