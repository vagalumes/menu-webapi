using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Services.Repositories.Abstractions
{
    public interface IRestaurantRepository
    {
        Task<Restaurant?> GetRestaurant(Guid restaurantId, CancellationToken cancellationToken);

        Task<bool> RestaurantExists(Guid? restaurantId, CancellationToken cancellationToken);
    }
}
