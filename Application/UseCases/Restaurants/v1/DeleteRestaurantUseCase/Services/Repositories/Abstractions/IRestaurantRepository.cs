using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Services.Repositories.Abstractions
{
    public interface IRestaurantRepository
    {
        void DeletedRestaurant(Restaurant restaurant);
        Task<Restaurant?> GetRestaurant(Guid restaurantId, CancellationToken cancellationToken);
    }
}
