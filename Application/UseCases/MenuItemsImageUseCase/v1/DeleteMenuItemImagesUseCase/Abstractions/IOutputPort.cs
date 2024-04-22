namespace Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase.Abstractions;

public interface IOutputPort
{
    void MenuItemNotFound();
    void MenuItemImageDeleted();
    void ImagesNotFound();
}