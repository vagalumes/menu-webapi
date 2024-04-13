using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Services.Repositories
{

    public class RestaurantRepository(AppDbContext context) : IRestaurantRepository
    {
        public void DeletedRestaurant(Restaurant restaurant) => context.Remove(restaurant);

        public async Task<Restaurant?> GetRestaurant(Guid restaurantId, CancellationToken cancellationToken)
            => await context.Restaurants
                            .FirstOrDefaultAsync(r => r.Id == restaurantId, cancellationToken);
    }
}
