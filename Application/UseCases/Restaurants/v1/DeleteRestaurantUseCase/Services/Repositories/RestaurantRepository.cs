using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Restaurants.v1.DeleteRestaurantUseCase.Services.Repositories
{

    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _context;

        public RestaurantRepository(AppDbContext context) => _context = context;

        public void DeletedRestaurant(Restaurant restaurant) => _context.Remove(restaurant);

        public async Task<Restaurant?> GetRestaurant(Guid restaurantId, CancellationToken cancellationToken)
            => await _context.Restaurants
                          .Include(r => r.Address)
                          .Include(r => r.Information)
                          .Include(r => r.Payments)
                          .FirstOrDefaultAsync(r => r.Id == restaurantId, cancellationToken);
    }
}
