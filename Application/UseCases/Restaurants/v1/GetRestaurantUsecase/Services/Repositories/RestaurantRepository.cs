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
                                 .Include(r => r.Payments)
                                 .Include(r => r.Adress)
                                 .Include(r => r.Login)
                                 .Include(r => r.Information)
                                 .Include(r => r.ServiceHours)
                                 .FirstOrDefaultAsync(r => r.Id == restaurantId, cancellationToken);
        }
    }
}
