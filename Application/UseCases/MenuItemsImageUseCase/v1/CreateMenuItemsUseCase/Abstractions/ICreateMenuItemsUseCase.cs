using Application.UseCases.MenuItemsImageUseCase.v1.CreateMenuItemsUseCase.Models;

namespace Application.UseCases.MenuItemsImageUseCase.v1.CreateMenuItemsUseCase.Abstractions;

public interface ICreateMenuItemsUseCase
{
    void SetOutputPort(IOutputPort outputPort);
    Task ExecuteAsync(Guid id, CreateMenuItemsRequest request, CancellationToken cancellationToken);
}