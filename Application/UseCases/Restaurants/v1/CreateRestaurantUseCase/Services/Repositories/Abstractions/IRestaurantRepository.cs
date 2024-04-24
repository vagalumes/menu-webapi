using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services.Repositories.Abstractions;

public interface IRestaurantRepository
{
    Task<bool> RestaurantExists(string cnpj);
    Task CreateRestaurant(Restaurant restaurant, CancellationToken cancellationToken);
}