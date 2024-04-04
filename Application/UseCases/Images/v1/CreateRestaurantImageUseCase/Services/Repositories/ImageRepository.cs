using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Services.Repositories
{
    public class ImageRepository(AppDbContext dbContext) : IImageRepository
    {
        public async Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken) =>
            await dbContext.Restaurants.Include(r => r.Images).FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }
}
