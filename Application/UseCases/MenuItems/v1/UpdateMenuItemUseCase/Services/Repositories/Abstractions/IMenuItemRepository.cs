using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Services.Repositories.Abstractions;

public interface IMenuItemRepository
{
    Task<MenuItem?> GetMenuItem(Guid menuItemId, CancellationToken cancellationToken);
    Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken);

    void UpdateMenuItem(MenuItem menuItems);
}