namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Abstractions
{
    public interface IOutputPort
    {
        void RestaurantUpdated();
        void InvalidRequest();
        void RestaurantNotFound();
    }
}
