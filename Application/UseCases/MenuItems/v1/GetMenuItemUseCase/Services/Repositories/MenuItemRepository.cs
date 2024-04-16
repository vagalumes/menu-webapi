using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Services.Repositories
{
    public class MenuItemRepository(AppDbContext context) : IMenuItemRepository
    {
        public async Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken) =>
            await context.Restaurants.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

        public async Task<MenuItem?> GetMenuItem(Guid menuItemId, CancellationToken cancellationToken) =>
            await context.MenuItem.Include(m => m.Images)
                .FirstOrDefaultAsync(m => m.Id == menuItemId, cancellationToken);

    }
}
