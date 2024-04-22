using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Services.Repositories;

public class MenuItemRepository(AppDbContext context) : IMenuItemRepository
{
    public async Task<MenuItem?> GetMenuItem(Guid id, CancellationToken cancellationToken) => await context.MenuItem
        .Include(mI => mI.Images).FirstOrDefaultAsync(mI => mI.Id == id, cancellationToken);

    public async Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken) =>
        await context.Restaurants.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

    public void UpdateMenuItem(MenuItem menuItem) => context.MenuItem.Update(menuItem);
}