using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Images.v1.CreateMenuItemImageUseCase.Services.Repositories
{
    public class ImageRepository(AppDbContext dbContext) : IImageRepository
    {
        public async Task<MenuItem?> GetMenuItem(Guid id, CancellationToken cancellationToken) =>
            await dbContext.MenuItem.FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }
}
