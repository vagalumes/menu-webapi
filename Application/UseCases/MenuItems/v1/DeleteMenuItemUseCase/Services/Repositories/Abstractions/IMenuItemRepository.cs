using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Services.Repositories.Abstractions;

public interface IMenuItemRepository
{
    void DeletedMenuItem(MenuItem menuItem);
    Task<MenuItem?> GetMenuItem(Guid menuItemId, CancellationToken cancellationToken);
    Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken);
}