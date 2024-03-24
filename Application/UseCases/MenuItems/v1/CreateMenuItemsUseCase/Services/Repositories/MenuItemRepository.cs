using Application.Shared.Context;
using Application.Shared.Entities;
using Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Services.Repositories
{
    public class MenuItemRepository(AppDbContext dbContext) : IMenuItemRepository
    {
        public bool RestaurantExists(long cnpj) => dbContext.Restaurants.Any(r => r.CNPJ == cnpj);

        public async Task CreateMenuItems(MenuItem menuItem, CancellationToken cancellationToken) =>
            await dbContext.AddAsync(menuItem, cancellationToken);
    }
}
