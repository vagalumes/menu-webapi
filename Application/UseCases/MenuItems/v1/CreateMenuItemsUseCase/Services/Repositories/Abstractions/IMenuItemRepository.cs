using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Services.Repositories.Abstractions
{
    public interface IMenuItemRepository
    {
        Task<Restaurant?> GetRestaurant(Guid restaurantId, CancellationToken cancellationToken);

        Task CreateMenuItems(MenuItem menuItem, CancellationToken cancellationToken);
    }
}
