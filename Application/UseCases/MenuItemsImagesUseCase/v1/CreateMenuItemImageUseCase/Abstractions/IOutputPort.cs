namespace Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.Abstractions
{
    public interface IOutputPort
    {
        void MenuNotFound();
        void RestaurantNotFound();
        void ImageSaved();
    }
}
