namespace Application.UseCases.MenuItemsImagesUseCase.v1.DeleteMenuItemImagesUseCase.Abstractions;

public interface IOutputPort
{
    void MenuItemNotFound();
    void MenuItemImageDeleted();
    void ImagesNotFound();
}