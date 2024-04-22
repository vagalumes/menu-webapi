namespace Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase.Abstractions;

public interface IDeleteMenuItemImagesUseCase
{
    void SetOutputPort(IOutputPort outputPort);

    Task ExecuteAsync(Guid id, Guid imageId, CancellationToken cancellationToken);
}