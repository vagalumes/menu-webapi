using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.GetMenuItemsUseCase.Services.Repositories.Abstractions;

public interface IMenuItemsRepository
{
    Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken);
    IEnumerable<MenuItem> GetMenuItems(Guid id);
}