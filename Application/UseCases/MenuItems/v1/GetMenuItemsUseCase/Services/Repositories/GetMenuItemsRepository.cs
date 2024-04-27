using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services.Repositories;

public class GetMenuItemsRepository(AppDbContext context) : IMenuItemsRepository
{
    public async Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken)
    {
        return await context.Restaurants.FindAsync(id, cancellationToken);
    }

    public IEnumerable<MenuItem> GetMenuItems(Guid id)
    {
        return context.MenuItem.Include(m => m.Images).Where(m => m.Restaurant.Id == id);
    }
}