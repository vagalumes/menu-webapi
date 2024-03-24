using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Images.v1.CreateRestaurantImageUseCase.Services.Repositories
{
    public class ImageRepository(AppDbContext dbContext) : IImageRepository
    {
        public async Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken)
        {
            return await dbContext.Restaurants
                .Include(r => r.Payments)
                .Include(r => r.Adress)
                .Include(r => r.Login)
                .Include(r => r.Information)
                .Include(r => r.ServiceHours)
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }
    }
}
