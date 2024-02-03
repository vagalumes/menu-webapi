using Application.Shared.Entities;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services.Repositories.Abstractions
{
    public interface IRestaurantRepository
    {
        bool RestaurantExists(long CNPJ);
        Task CreateRestaurant(Restaurant restaurant, CancellationToken cancellationToken);
    }
}
