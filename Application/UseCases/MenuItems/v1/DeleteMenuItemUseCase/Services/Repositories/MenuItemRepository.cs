using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Services.Repositories;

public class MenuItemRepository(AppDbContext context) : IMenuItemRepository
{
    public void DeletedMenuItem(MenuItem menuItem) => context.Remove(menuItem);

    public async Task<MenuItem?> GetMenuItem(Guid menuItemId, CancellationToken cancellationToken) =>
        await context.MenuItem.FindAsync(keyValues: [menuItemId], cancellationToken: cancellationToken);

    public async Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken) =>
        await context.Restaurants.FindAsync(keyValues: [id], cancellationToken: cancellationToken);
}