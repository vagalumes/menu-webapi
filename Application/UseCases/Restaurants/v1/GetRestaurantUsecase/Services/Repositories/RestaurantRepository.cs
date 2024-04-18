using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Restaurants.v1.GetRestaurantUseCase.Services.Repositories
{
    public class RestaurantRepository(AppDbContext context) : IRestaurantRepository
    {
        public async Task<Restaurant?> GetRestaurant(Guid restaurantId, CancellationToken cancellationToken)
        {
            return await context.Restaurants
                .Include(r => r.Address)
                .Include(r => r.Information)
                    .ThenInclude(i => i.Schedules)   
                .FirstOrDefaultAsync(r => r.Id == restaurantId, cancellationToken);
        }
    }
}
