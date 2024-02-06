using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Services.Repositories.Abstractions
{
    public interface IRestaurantRepository
    {
        Task<Restaurant?> GetRestaurant(Guid restaurantId, CancellationToken cancellationToken);
    }
}
