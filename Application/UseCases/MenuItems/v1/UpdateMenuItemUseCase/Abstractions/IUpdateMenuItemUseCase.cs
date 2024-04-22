using Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Models;

namespace Application.UseCases.MenuItems.v1.UpdateMenuItemUseCase.Abstractions;

public interface IUpdateMenuItemUseCase
{
    void SetOutputPort(IOutputPort outputPort);
    Task ExecuteAsync(Guid id, Guid menuItemId, UpdateMenuItemRequest request, CancellationToken cancellationToken);
}