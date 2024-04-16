using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Services.Repositories.Abstractions
{
    public interface IMenuItemRepository
    {
        Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken);
        Task<MenuItem?> GetMenuItem(Guid menuItemId, CancellationToken cancellationToken);
    }
}
