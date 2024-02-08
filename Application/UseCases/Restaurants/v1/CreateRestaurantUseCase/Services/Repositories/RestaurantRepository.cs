using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _dbContext;

        public RestaurantRepository(AppDbContext dbContext) => _dbContext = dbContext;

        public bool RestaurantExists(long CNPJ) => _dbContext.Restaurants.Any(r => r.Cnpj == CNPJ);

        public async Task CreateRestaurant(Restaurant restaurant, CancellationToken cancellationToken) => await _dbContext.Restaurants.AddAsync(restaurant, cancellationToken);
    }
}
