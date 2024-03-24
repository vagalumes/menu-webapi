using Application.Shared.Entities;

namespace Application.UseCases.MenuItems.v1.CreateMenuItemsUseCase.Services.Repositories.Abstractions
{
    public interface IMenuItemRepository
    {
        bool RestaurantExists(long Cnpj);
        Task CreateMenuItems(MenuItem menuItem, CancellationToken cancellationToken);
    }
}
