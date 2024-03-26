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
                                               .FirstOrDefaultAsync(r => r.Id == restaurantId, cancellationToken);
        }

        public async Task<bool> RestaurantExists(Guid? restaurantId, CancellationToken cancellationToken) =>
            await dbContext.Restaurants.AnyAsync(r => r.Id == restaurantId, cancellationToken: cancellationToken);
    }
}
