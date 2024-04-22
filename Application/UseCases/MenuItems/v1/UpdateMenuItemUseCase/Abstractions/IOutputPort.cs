namespace Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Abstractions;

public interface IOutputPort
{
    void MenuitemUpdated();
    void InvalidRequest();
    void MenuItemNotFound();
    void RestaurantNotFound();
}