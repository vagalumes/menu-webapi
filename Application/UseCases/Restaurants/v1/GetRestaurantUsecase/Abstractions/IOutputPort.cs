using Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Models;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Abstractions;

public interface IOutputPort
{
    void RestaurantFound(GetRestaurantModel restaurantModel);
    void RestaurantNotFound();
}