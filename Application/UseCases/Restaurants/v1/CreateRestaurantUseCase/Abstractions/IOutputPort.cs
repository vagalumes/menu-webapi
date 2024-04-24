namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Abstractions;

public interface IOutputPort
{
    void InvalidRequest();
    void RestaurantAlreadyExists();
    void RestaurantCreated();
}