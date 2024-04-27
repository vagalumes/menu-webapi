using Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Models;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Abstractions;

public interface IOutputPort
{
    void RestaurantFound(GetRestaurantModel restaurantModel);
    void RestaurantNotFound();
}