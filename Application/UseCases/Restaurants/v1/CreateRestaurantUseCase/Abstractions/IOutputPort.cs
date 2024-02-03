using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Models;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Abstractions
{
    public interface IOutputPort
    {
        void InvalidRequest();
        void RestaurantCreated(RestaurantDto restaurant);
    }
}
