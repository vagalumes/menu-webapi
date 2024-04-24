using Application.Shared.Entities;

namespace Application.UseCases.MenuItemsImagesUseCase.v1.CreateMenuItemImageUseCase.Services.Repositories.Abstractions
{
    public interface IImageRepository
    {
        Task<Restaurant?> GetRestaurant(Guid id, CancellationToken cancellationToken);
        Task<MenuItem?> GetMenuItem(Guid menuItemId, CancellationToken cancellationToken);
    }
}
