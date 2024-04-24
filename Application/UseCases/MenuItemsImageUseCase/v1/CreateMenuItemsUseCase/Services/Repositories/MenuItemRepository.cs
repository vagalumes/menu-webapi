using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.MenuItemsImageUseCase.v1.CreateMenuItemsUseCase.Services.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.MenuItemsImageUseCase.v1.CreateMenuItemsUseCase.Services.Repositories;

public class MenuItemRepository(AppDbContext dbContext) : IMenuItemRepository
{
    public async Task<Restaurant?> GetRestaurant(Guid restaurantId, CancellationToken cancellationToken)
    {
        return await dbContext.Restaurants.FirstOrDefaultAsync(r => r.Id == restaurantId, cancellationToken);
    }

    public async Task CreateMenuItems(MenuItem menuItem, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(menuItem, cancellationToken);
    }
}