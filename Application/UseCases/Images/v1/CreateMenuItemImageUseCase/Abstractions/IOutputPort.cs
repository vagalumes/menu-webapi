namespace Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Abstractions;

public interface IOutputPort
{
    void MenuNotFound();
    void RestaurantNotFound();
    void ImageSaved();
}