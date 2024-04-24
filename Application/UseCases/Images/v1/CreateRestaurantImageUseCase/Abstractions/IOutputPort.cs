namespace Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Abstractions;

public interface IOutputPort
{
    void ImagesSaved();
    void RestaurantNotFound();
}