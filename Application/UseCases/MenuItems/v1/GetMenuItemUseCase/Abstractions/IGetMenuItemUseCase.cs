namespace Application.UseCases.MenuItems.v1.GetMenuItemUseCase.Abstractions;

public interface IGetMenuItemUseCase
{
    void SetOutputPort(IOutputPort outputPort);
    Task ExecuteAsync(Guid id, Guid menuItemId, CancellationToken cancellationToken);
}