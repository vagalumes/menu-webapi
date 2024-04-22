using Application.Shared.Services.Abstractions;
using Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase.Abstractions;
using Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.MenuItemsImageUseCase.v1.DeleteMenuItemImagesUseCase;

public class DeleteMenuItemsImageUseCase(
    IMenuItemsImagesRepository repository,
    IDeleteImagesService service,
    IUnitOfWork unitOfWork)
    : IDeleteMenuItemImagesUseCase
{
    private IOutputPort? _outputPort;

    public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

    public async Task ExecuteAsync(Guid id, Guid imageId, CancellationToken cancellationToken)
    {
        var menuItem = await repository.GetMenuItem(id, cancellationToken);
        if (menuItem is null)
        {
            _outputPort!.MenuItemNotFound();
            return;
        }

        var imageMenuItem = menuItem.Images.FirstOrDefault(i => i.Id == imageId);
        if (imageMenuItem is null)
        {
            _outputPort!.ImagesNotFound();
            return;
        }

        service.DeleteFiles($"menuItem-{id}", imageMenuItem.Name);

        repository.DeletedMenuItemImage(imageMenuItem);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        _outputPort!.MenuItemImageDeleted();
    }
}