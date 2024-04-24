using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.Services.Repositories
{
    public class ImageRepository(AppDbContext dbContext) : IImageRepository
    {
        public async Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken) =>
            await dbContext.Restaurants.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

        public async Task<MenuItem?> GetMenuItem(Guid menuItemId, CancellationToken cancellationToken) =>
            await dbContext.MenuItem.FirstOrDefaultAsync(m => m.Id == menuItemId, cancellationToken);

    }
}
