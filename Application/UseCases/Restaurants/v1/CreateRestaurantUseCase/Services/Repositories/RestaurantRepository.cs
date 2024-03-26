using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Restaurants.v1.CreateRestaurantUseCase.Services.Repositories
{
    public class RestaurantRepository(AppDbContext dbContext) : IRestaurantRepository
    {
        public async Task<bool> RestaurantExists(string cnpj) => await dbContext.Restaurants.AnyAsync(r => r.Cnpj == cnpj);

        public async Task CreateRestaurant(Restaurant restaurant, CancellationToken cancellationToken) => await dbContext.Restaurants.AddAsync(restaurant, cancellationToken);
    }
}
