namespace Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Abstractions
{
    public interface IOutputPort
    {
        void RestaurantDeleted();

        void RestaurantNotFound();
    }
}
