namespace Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Abstractions;

public interface IOutputPort
{
    void RestaurantNotFound();
    void MenuItemNotFound();
    void MenuItemDeleted();
}