using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUsecase.Services.Repositories.Abstractions;

public interface IRestaurantRepository
{
    Task<Restaurant?> GetRestaurant(Guid restaurantId, CancellationToken cancellationToken);
}