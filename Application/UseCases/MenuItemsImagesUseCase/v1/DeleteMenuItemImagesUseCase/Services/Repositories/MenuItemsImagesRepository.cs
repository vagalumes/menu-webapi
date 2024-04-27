using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.MenuItemsImagesUseCase.v1.DeleteMenuItemImagesUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.MenuItemsImagesUseCase.v1.DeleteMenuItemImagesUseCase.Services.Repositories;

public class MenuItemsImagesRepository(AppDbContext context) : IMenuItemsImagesRepository
{
    public void DeletedMenuItemImage(MenuItemsImages menuItemsImages)
    {
        context.Remove(menuItemsImages);
    }

    public async Task<MenuItem?> GetMenuItem(Guid id, CancellationToken cancellationToken)
    {
        return await context.MenuItem
            .Include(m => m.Images).FirstOrDefaultAsync(m => m.Id == id, cancellationToken);
    }
}