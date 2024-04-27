using Application.Shared.Services.Abstractions;
using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Abstractions;
using Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase.Services.Repositories.Abstractions;

namespace Application.UseCases.MenuItems.v1.DeleteMenuItemUseCase;

public class DeleteMenuItemUseCase(IMenuItemRepository repository, IUnitOfWork unitOfWork) : IDeleteMenuItemUseCase
{
    private IOutputPort? _outputPort;

    public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

    public async Task ExecuteAsync(Guid id, Guid menuItemId, CancellationToken cancellationToken)
    {
        var restaurant = await repository.GetRestaurant(id, cancellationToken);
        if (restaurant is null)
        {
            _outputPort!.RestaurantNotFound();
            return;
        }

        var menuItem = await repository.GetMenuItem(menuItemId, cancellationToken);
        if (menuItem is null)
        {
            _outputPort!.MenuItemNotFound();
            return;
        }

        repository.DeletedMenuItem(menuItem);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        _outputPort!.MenuItemDeleted();
    }
}