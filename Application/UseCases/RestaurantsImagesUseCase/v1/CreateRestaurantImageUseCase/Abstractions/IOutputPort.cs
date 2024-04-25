namespace Application.UseCases.RestaurantsImagesUseCase.v1.CreateRestaurantImageUseCase.Abstractions
{
    public interface IOutputPort
    {
        void ImagesSaved();
        void RestaurantNotFound();
    }
}
