namespace Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Abstractions;

public interface IDeleteMenuItemUseCase
{
    void SetOutputPort(IOutputPort outputPort);
    Task ExecuteAsync(Guid id, Guid menuItemId, CancellationToken cancellationToken);
}