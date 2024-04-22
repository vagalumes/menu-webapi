using Application.Shared.Entities;

namespace Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase.Services.Repositories.Abstractions;

public interface IMenuItemsImagesRepository
{
    void DeletedMenuItemImage(MenuItemsImages menuItemsImages);
    Task<MenuItem?> GetMenuItem(Guid id, CancellationToken cancellationToken);
}