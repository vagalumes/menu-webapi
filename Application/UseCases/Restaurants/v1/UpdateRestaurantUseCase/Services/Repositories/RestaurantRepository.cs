using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Restaurants.v1.UpdateRestaurantUseCase.Services.Repositories
{
    public class RestaurantRepository(AppDbContext dbContext) : IRestaurantRepository
    {
        public async Task<Restaurant?> GetRestaurant(Guid restaurantId, CancellationToken cancellationToken)
        {
            return await dbContext.Restaurants
                                               .Include(r => r.Address)
                                               .Include(r => r.Information)
                                                    .ThenInclude(i => i.Schedules)
                                               .FirstOrDefaultAsync(r => r.Id == restaurantId, cancellationToken);
        }

        public void UpdateRestaurant(Restaurant restaurant) => dbContext.Restaurants.Update(restaurant);
    }
}
